using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaWeb.WebForms
{
    public partial class DescuentosCargosFac : System.Web.UI.Page
    {
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();
        ModeloConcFiscal modeloFiscal = new ModeloConcFiscal();
        List<ModeloConcFiscal> ListaFiscal = new List<ModeloConcFiscal>();
        Articulos concepto = new Articulos();
        ModeloFacturaDescuento ModeloDescuento = new ModeloFacturaDescuento();
        CabezeraFactura BuscarDescuento = new CabezeraFactura();
        List<ModeloFacturaDescuento> ListaDescuento = new List<ModeloFacturaDescuento>();

        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        FacturaDescuento consultaDesc = new FacturaDescuento();
        List<ModeloDescCargoFac> ListaDesc = new List<ModeloDescCargoFac>();
        ModeloDescCargoFac modelodescuento = new ModeloDescCargoFac();

        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();
        List<modelowmtfacturascab> listaConsCab = null;
        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        Consultawmspcmonedas ConsultaCMonedas = new Consultawmspcmonedas();
        List<modelowmspcmonedas> listaMonedas = null;
        modelowmspcmonedas DecimalesMoneda = new modelowmspcmonedas();
        ConsultaEmpresa consultaEmpresa = new ConsultaEmpresa();
        List<modelowmspcempresas> listaEmpresa = null;
        modelowmspcempresas modeloEmpresa = new modelowmspcempresas();
        public string ComPwm;
        public string AmUsrLog;
        public decimal sumaTotalPago;
        public decimal sumaDiferencia;
        public string transaccion;
        public string Ccf_tipo1 = "C";
        public string Ccf_tipo2 = "POSE";
        public string Ccf_nro_trans = "0";
        public string Ccf_estado = null;
        public string Ccf_cliente = null;
        public string Ccf_cod_docum = null;
        public string Ccf_serie_docum = null;
        public string Ccf_nro_docum = null;
        public string Ccf_diai = null;
        public string Ccf_mesi = null;
        public string Ccf_anioi = null;
        public string Ccf_diaf = null;
        public string Ccf_mesf = null;
        public string Ccf_aniof = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                RecuperarCokie();

                if (!IsPostBack)
                {

                    Session.Remove("desc_carg");
                    if (Session["valor_asignado1"] != null)
                    {
                        txt_nro_trans.Text = Session["valor_asignado1"].ToString();
                        DecimalesMoneda = null;
                        DecimalesMoneda = BuscarDecimales();
                        //Buscar monto imponible de factura
                        conscabcera = null;
                        conscabcera = BuscarCabecera();
                        txt_total_factura.Text = conscabcera.monto_imponible.ToString();
                        BuscarTotales();
                        ListaDesplegable();
                    }
                    if (Session["Tipo"] != null)
                    {
                        transaccion = Session["Tipo"].ToString();
                        if (transaccion.Trim() == "VER")
                        {
                            lbl_concepto.Visible = false;
                            cbx_concepto.Visible = false;
                            lbl_tipo_cal.Visible = false;
                            cbx_tipo.Visible = false;
                            gv_Producto.Columns[5].Visible = false;
                            gv_Producto.Columns[6].Visible = false;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());

            }
        }
        public modelowmtfacturascab BuscarCabecera()
        {
            try
            {
                lbl_error.Text = "";


                //Busca el nro de auditoria para poder insertar el detalle factura
                //consulta nro_auditoria de la cabecera
                string Ccf_nro_trans = txt_nro_trans.Text;
                listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Session["Ccf_tipo2"].ToString(), Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                int count = 0;
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                    count++;
                    conscabcera = item;
                }


                return conscabcera;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarCabecera", ex.ToString());
                return null;
            }
        }

        public void RecuperarCokie()
        {
            try
            {
                lbl_error.Text = "";

                if (Request.Cookies["ComPwm"] != null)
                {
                    ComPwm = Request.Cookies["ComPwm"].Value;
                }
                else
                {
                    Response.Redirect("../Inicio.asp");
                }


                if (Request.Cookies["AmUsrLog"] != null)
                {
                    AmUsrLog = Request.Cookies["AmUsrLog"].Value;

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("RecuperarCokie", ex.ToString());

            }
        }
        public void GuardarExcepciones(string metodo, string error)
        {
            try
            {
                ModeloExcepcion.cod_emp = ComPwm;
                ModeloExcepcion.proceso = "DescuentosCargosFac.aspx";
                ModeloExcepcion.metodo = metodo;
                ModeloExcepcion.error = error;
                ModeloExcepcion.fecha_hora = DateTime.Now;
                ModeloExcepcion.usuario_mod = AmUsrLog;

                consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
                //mandar mensaje de error a label
                lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";
            }
            catch (Exception ex)
            {
                GuardarExcepciones("GuardarExcepciones", ex.ToString());

            }

        }
        protected void Agregar_Tipo_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbx_tipo.SelectedValue == "D")
                {
                    //Por porcentaje tomando encuenta la base imponible
                    cbx_concepto.Visible = true;
                    lbl_concepto.Visible = true;
                    txt_porc_desc.Visible = true;
                    lbl_porc.Visible = true;
                    AgregarPago.Visible = true;
                    lbl_signo.Visible = true;
                    Agregar_Tipo.Visible = false;
                    // txt_valor.Visible = true;
                    //lbl_valor.Visible = true;
                    
                }
                else
                {
                    cbx_concepto.Visible = true;
                    lbl_concepto.Visible = true;
                    lbl_signo.Visible = true;
                    Agregar_Tipo.Visible = false;
                    // txt_porc_desc.Visible = true;
                    //lbl_porc.Visible = true;
                    txt_valor.Visible = true;
                    lbl_valor.Visible = true;
                    AgregarPago.Visible = true;
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Agregar_Tipo_Click", ex.ToString());

            }

        }
        public void ListaDesplegable()
        {
            try
            {
                lbl_error.Text = "";

                //Cargar cbx_fiscal
                ListaDescuento = BuscarDescuento.ListaRecDesFactura(AmUsrLog, ComPwm);

                cbx_concepto.DataSource = ListaDescuento;
                cbx_concepto.DataTextField = "nomcod";
                cbx_concepto.DataValueField = "cod_concepto";
                cbx_concepto.DataBind();
                cbx_concepto.Items.Insert(0, new ListItem("Seleccione...", "0"));
                cbx_concepto.SelectedIndex = 0;

                ListaDesc = consultaDesc.ConsultaDescCargTrans(ComPwm, AmUsrLog, txt_nro_trans.Text);
                gv_Producto.DataSource = ListaDesc;
                gv_Producto.DataBind();
                gv_Producto.Height = 100;

            }
            catch (Exception ex)
            {
                GuardarExcepciones("ListaDesplegable", ex.ToString());

            }
        }

        protected void AgregarPago_Click(object sender, EventArgs e)
        {
            try
            {
                string numero = null;
                ModeloDescCargoFac modeloDesCargo = new ModeloDescCargoFac();
                ModeloFacturaDescuento modeloParaDesc = new ModeloFacturaDescuento();
                ListaDescuento = BuscarDescuento.ListaRecDesFactura(AmUsrLog, ComPwm);
                foreach (ModeloFacturaDescuento item in ListaDescuento)
                {
                    if (item.cod_concepto == cbx_concepto.SelectedValue)
                    {
                        modeloParaDesc = item;
                        break;
                    }
                }
                if (lbl_linea.Text == null || lbl_linea.Text == "")
                {
                    //consulta el nro de lineas
                    
                    numero = consultaDesc.ConsultaDescCargNro(ComPwm, AmUsrLog, txt_nro_trans.Text);
                    //NRO LINEA
                    int linea = Convert.ToInt16(numero) + 1;
                    //Buscar datos de concepto

            
                    if (txt_porc_desc.Text == null || txt_porc_desc.Text =="" )
                    {
                        txt_porc_desc.Text = "0";
                    }

                    if (txt_valor.Text == null || txt_valor.Text =="")
                    {
                        txt_valor.Text = "0";
                    }
                    if (txt_total_factura.Text == null || txt_total_factura.Text == "")
                    {
                        txt_total_factura.Text = "0";
                    }
                    //Insertar pago en wmt_facturas_descto

                    modeloDesCargo.nro_trans = txt_nro_trans.Text;
                    modeloDesCargo.linea = linea.ToString();
                    modeloDesCargo.cod_emp = ComPwm;
                    modeloDesCargo.cod_concepto = cbx_concepto.SelectedValue;
                    modeloDesCargo.nom_concepto = modeloParaDesc.nom_concepto;
                    modeloDesCargo.signo = modeloParaDesc.signo;
                    modeloDesCargo.porc_descto = Convert.ToDecimal(txt_porc_desc.Text);
                    modeloDesCargo.valor_descto = Convert.ToDecimal(txt_valor.Text);
                    modeloDesCargo.monto_imponible = Convert.ToDecimal(txt_total_factura.Text);
                    //Calcular total
                    if (modeloDesCargo.porc_descto==0)
                    {
                        modeloDesCargo.total = modeloDesCargo.valor_descto;
                    }
                    else { modeloDesCargo.total = (modeloDesCargo.porc_descto / 100) * Convert.ToDecimal(txt_total_factura.Text); }
                    
                    
                    modeloDesCargo.cod_ccostos = modeloParaDesc.cod_ccostos;
                    modeloDesCargo.cod_cta = modeloParaDesc.cod_cta;
                    modeloDesCargo.usuario_mod = AmUsrLog;
                    modeloDesCargo.fecha_mod = DateTime.Now.ToString();
                    consultaDesc.InsertarDescCargTrans(modeloDesCargo);
                }
                else
                {

                    //Actualizar pago en wmt_facturas_descto
                    modeloDesCargo.nro_trans = txt_nro_trans.Text;
                    modeloDesCargo.linea = lbl_linea.Text;
                    modeloDesCargo.cod_emp = ComPwm;
                    modeloDesCargo.cod_concepto = cbx_concepto.SelectedValue;
                    modeloDesCargo.nom_concepto = modeloParaDesc.nom_concepto;
                    modeloDesCargo.signo = modeloParaDesc.signo;
                    if (txt_porc_desc.Text == null || txt_porc_desc.Text =="" )
                    {
                        txt_porc_desc.Text = "0";
                    }

                    if (txt_valor.Text == null || txt_valor.Text =="")
                    {
                        txt_valor.Text = "0";
                    }
                    if (txt_total_factura.Text == null || txt_total_factura.Text == "")
                    {
                        txt_total_factura.Text = "0";
                    }
                    modeloDesCargo.porc_descto = Convert.ToDecimal(txt_porc_desc.Text);
                    modeloDesCargo.valor_descto = Convert.ToDecimal(txt_valor.Text);
                    modeloDesCargo.monto_imponible = Convert.ToDecimal(txt_total_factura.Text);
                    modeloDesCargo.cod_ccostos = modeloParaDesc.cod_ccostos;
                    modeloDesCargo.cod_cta = modeloParaDesc.cod_cta;
                    modeloDesCargo.usuario_mod = AmUsrLog;
                    modeloDesCargo.fecha_mod = DateTime.Now.ToString();
                    if (modeloDesCargo.porc_descto == 0)
                    {
                        modeloDesCargo.total = modeloDesCargo.valor_descto;
                    }
                    else { modeloDesCargo.total = (modeloDesCargo.porc_descto / 100) * Convert.ToDecimal(txt_total_factura.Text); }
                    consultaDesc.ActualizarDescCargTrans(modeloDesCargo);
                    
                }
                ListaDesc = consultaDesc.ConsultaDescCargTrans(ComPwm, AmUsrLog, txt_nro_trans.Text);
                gv_Producto.DataSource = ListaDesc;
                gv_Producto.DataBind();
                gv_Producto.Height = 100;
                Bloquear();
                lbl_linea.Text = "";
                conscabcera = null;
                conscabcera = BuscarCabecera();
                BuscarTotales();
                // Crea la variable de sessión para actualizar los totales en formulario padre
                Session["desc_carg"] = "Desc_cargos";
                // Refrescamos el formuario padre
                ClientScript.RegisterClientScriptBlock(GetType(), "Refresca", "window.opener.location.reload();", true);

            }
            catch (Exception ex)
            {
                GuardarExcepciones("AgregarPago_Click", ex.ToString());

            }
        }
        protected void BuscarTotales()
        {
            try
            {
                decimal cargo = 0;
                decimal descuento = 0;
                ListaDesc = consultaDesc.ConsultaDescCargTrans(ComPwm, AmUsrLog, txt_nro_trans.Text);
                foreach (ModeloDescCargoFac item in ListaDesc)
                {
                    if (item.signo.Trim() == "D")
                    {
                        descuento += item.total;
                       
                    }
                    if(item.signo.Trim()=="C")
                    {
                        cargo += item.total;
                    }
                   
                }
                decimal desc_imp = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), Convert.ToDecimal(descuento));
                decimal carg_imp = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), Convert.ToDecimal(cargo));
                txt_tot_cargo.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), carg_imp);
                txt_tot_des.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), desc_imp);
            }

            catch (Exception ex)
            {
                GuardarExcepciones("BuscarTotales", ex.ToString());

            }
        }
        protected void Desbloquear()
        {
            if(txt_porc_desc.Text =="0.00")
            {
                lbl_porc.Visible = false;
                txt_porc_desc.Visible = false;
            }
            else
            {
                lbl_porc.Visible = true;
                txt_porc_desc.Visible = true;
            }

            cbx_concepto.Visible = true;
            lbl_concepto.Visible = true;
          
            lbl_signo.Visible = true;
            if(txt_valor.Text=="0.00")
            {
                lbl_valor.Visible = false;
                txt_valor.Visible = false;
            }
            else
            {
                lbl_valor.Visible = true;
                txt_valor.Visible = true;
            }
            
            AgregarPago.Visible = true;
        }
        protected void Bloquear()
        {
            lbl_monto_imp.Visible = false;
            txt_total_factura.Text = "";
            txt_total_factura.Visible = false;
            txt_porc_desc.Text = "";
            lbl_porc.Visible = false;
            txt_porc_desc.Visible = false;
            lbl_signo.Visible = false;
            txt_valor.Text = "";
            txt_valor.Visible = false;
            lbl_valor.Visible = false;
            
            cbx_tipo.SelectedValue = "0";
            cbx_concepto.SelectedValue = "0";
            AgregarPago.Visible = false;
        }
   
        protected void gv_Producto_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                lbl_linea.Text = Convert.ToString(((Label)e.Item.Cells[1].FindControl("linea")).Text);
                modelodescuento = null;
                modelodescuento = consultaDesc.BuscarDescCargTransLinea(ComPwm, AmUsrLog, txt_nro_trans.Text, lbl_linea.Text);

                switch (e.CommandName) //ultilizo la variable para la opcion            
                {
                    case "Editar":// lleno las cajas de texto con los datos para la edicon del item seleccionado
                        try
                        {
                            cbx_concepto.SelectedValue = modelodescuento.cod_concepto;
                            lbl_signo.Text = modelodescuento.detalle;
                            txt_porc_desc.Text = modelodescuento.porcen_desc;
                            txt_valor.Text = modelodescuento.valor_descuento;
                            Desbloquear();
                            
                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("gv_Producto_ItemCommand, Editar", ex.ToString());

                        }
                        break;



                    case "Eliminar":
                        try
                        {
                            
                            consultaDesc.EliminarDescCargTrans(modelodescuento);
                            ListaDesc = null;
                            ListaDesc = consultaDesc.ConsultaDescCargTrans(ComPwm, AmUsrLog, txt_nro_trans.Text);
                            if(ListaDesc.Count==0)
                            {
                                consultaDesc.ActualizarDescCargFac(ComPwm, AmUsrLog, txt_nro_trans.Text,"0");//Setear en cero campo descuento 
                            }
                            gv_Producto.DataSource = ListaDesc;
                            gv_Producto.DataBind();
                            gv_Producto.Height = 100;
                            conscabcera = null;
                            conscabcera = BuscarCabecera();
                            BuscarTotales();
                            // Crea la variable de sessión para actualizar los totales en formulario padre
                            Session["desc_carg"] = "Desc_cargos";
                            // Refrescamos el formuario padre
                            ClientScript.RegisterClientScriptBlock(GetType(), "Refresca", "window.opener.location.reload();", true);
                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("gv_Producto_ItemCommand, Eliminar", ex.ToString());

                        }
                        break;
                }
            }
            
    
            catch (Exception ex)
            {
                GuardarExcepciones("gv_Producto_ItemCommand", ex.ToString());

            }

        }

        protected void cbx_concepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Al seleccionar un item diferente de 0
                modeloFiscal = concepto.BuscarConFisCon(AmUsrLog, ComPwm, cbx_concepto.SelectedValue.Trim());
                lbl_signo.Text = modeloFiscal.concepto;
                lbl_signo.Visible = true;

            }
            catch (Exception ex)
            {
                GuardarExcepciones("cbx_concepto_SelectedIndexChanged", ex.ToString());

            }
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                Session.Remove("valor_asignado1");
                Session.Remove("Tipo");

                this.Page.Response.Write("<script language='JavaScript'>window.close('./DescuentosCargosFac.aspx', 'Descuentos y Cargos', 'top=100,width=800 ,height=600, left=400');</script>");
            }

            catch (Exception ex)
            {
                GuardarExcepciones("Cancelar_Click", ex.ToString());

            }
        }

        protected void cbx_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbx_tipo.SelectedValue == "D")
                {
                    //Por porcentaje tomando encuenta la base imponible
                    cbx_concepto.Visible = true;
                    lbl_concepto.Visible = true;
                    txt_porc_desc.Visible = true;
                    lbl_porc.Visible = true;
                    AgregarPago.Visible = true;
                    lbl_signo.Visible = true;
                    lbl_monto_imp.Visible = true;
                    txt_total_factura.Visible = true;
                    txt_valor.Visible = false;
                    lbl_valor.Visible = false;

                }
                else
                {
                    if (cbx_tipo.SelectedValue == "V")
                    {
                        cbx_concepto.Visible = true;
                        lbl_concepto.Visible = true;
                        lbl_signo.Visible = true;
                        txt_valor.Visible = true;
                        lbl_valor.Visible = true;
                        AgregarPago.Visible = true;
                        txt_porc_desc.Visible = false;
                        lbl_porc.Visible = false;
                        lbl_monto_imp.Visible = false;
                        txt_total_factura.Visible = false;
                    }
                    else
                    {
                        cbx_concepto.Visible = true;
                        lbl_concepto.Visible = true;
                        lbl_signo.Visible = false;
                        txt_valor.Visible = false;
                        lbl_valor.Visible = false;
                        AgregarPago.Visible = false;
                        lbl_monto_imp.Visible = false;
                        txt_total_factura.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("cbx_tipo_SelectedIndexChanged", ex.ToString());

            }
        }
        public bool ValidarNumero(string texto)
        {
            try
            {
                lbl_error.Text = "";

                decimal valor = Convert.ToDecimal(texto);
                if (valor < 0)
                {
                    return false;
                }

                return true;


            }
            catch (Exception e)
            {
                GuardarExcepciones("ValidarNumero", e.ToString());
                lbl_error.Text = "";
                return false;
            }
        }
        protected void txt_total_factura_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                lbl_mensaje.Text = "";

                if (ValidarNumero(txt_total_factura.Text))
                {
                    decimal valor = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), Convert.ToDecimal(txt_total_factura.Text));
                    txt_total_factura.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), valor);
                }
                else
                {
                    txt_total_factura.Text = "";
                    lbl_mensaje.Text = "Números con formato incorrecto.";
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("txt_total_factura_TextChanged", ex.ToString());
                lbl_mensaje.Text = "Números con formato incorrecto.";
                lbl_error.Text = "";
            }
        }

        protected void txt_valor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                lbl_mensaje.Text = "";

                if (ValidarNumero(txt_valor.Text))
                {
                    decimal valor = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), Convert.ToDecimal(txt_valor.Text));
                    txt_valor.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), valor);
                }
                else
                {
                    txt_valor.Text = "";
                    lbl_mensaje.Text = "Números con formato incorrecto.";
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("txt_valor_TextChanged", ex.ToString());
                lbl_mensaje.Text = "Números con formato incorrecto.";
                lbl_error.Text = "";
            }
        }
        public modelowmspcmonedas BuscarDecimales()
        {

            try
            {
                lbl_error.Text = "";

                listaEmpresa = consultaEmpresa.BuscartaEmpresa(AmUsrLog, ComPwm);
                modeloEmpresa = null;
                foreach (modelowmspcempresas item in listaEmpresa)
                {

                    modeloEmpresa = item;
                    break;

                }

                listaMonedas = ConsultaCMonedas.ConsultaCMonedas(AmUsrLog, ComPwm, modeloEmpresa.mone_mn.Trim());

                DecimalesMoneda = null;
                foreach (modelowmspcmonedas item in listaMonedas)
                {

                    DecimalesMoneda = item;
                    break;

                }
                Session["redondeo"] = DecimalesMoneda.redondeo;
                Session["redondeo_pu"] = DecimalesMoneda.redondeo_pu;
                return DecimalesMoneda;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarDecimales", ex.ToString());
                return null;

            }
        }
    }
}