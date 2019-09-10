using CapaDatos.Modelos;
using CapaProceso.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaWeb.WebForms
{
    public partial class MediosPagoPos : System.Web.UI.Page
    {
        ConsultaMediosPago consultaMediosPago = new ConsultaMediosPago();

        public List<modeloMediosPago> listaMedios = null;
        modeloMediosPago modeloMedios = new modeloMediosPago(); //Medios de pago por empresa

        public List<ModeloTipoPagoTem> listaTemporal = null; //para temporales sp
        ModeloTipoPagoTem modeloTemporal = new ModeloTipoPagoTem(); //para temporales sp

        public List<ModelosPagosTitular> listaTitular = null; //para titular sp
        ModelosPagosTitular modeloTitular = new ModelosPagosTitular(); //para temporales sp
        ModeloDiferenciaPagos modeloDiferencia = new ModeloDiferenciaPagos(); //Trae los saldos
        public List<ModeloDiferenciaPagos> listaSaldos = null;

        public List<modeloFacturasPagos> listaPagosPgs = null; //Modelos recuperar de la tabla wmt_facturas_pgs
        modeloFacturasPagos modeloPagosPgs = new modeloFacturasPagos(); //Modelos recuperar de la tabla wmt_facturas_pgs

        public List<modeloFacturaPgs> listaTotalPgs = null; //Modelos recuperar total pagos sp
        modeloFacturaPgs modeloTotalPgs = new modeloFacturaPgs(); //Modelos total pagos sp

        public List<modeloFacturasPagos> listaPagosFactura = null; //Modelos guardar tabla wmt_facturas_pgs
        modeloFacturasPagos modeloPagosFactura = new modeloFacturasPagos();
        modeloFacturasPagos detallePagosFactura = new modeloFacturasPagos();
        List<modeloFacturasPagos> modeloFacturasPagos = new List<modeloFacturasPagos>();
        ConsultaMediosPago guardarPagos = new ConsultaMediosPago(); //Guarda en tabla wmt_facturas_pgs

        modeloFacturasPagos modeloTiposPagos = new modeloFacturasPagos(); //Modelo tipos de pagos
        public List<modeloFacturasPagos> listaTiposPagos = null;

        Consultawmspcmonedas ConsultaCMonedas = new Consultawmspcmonedas();
        List<modelowmspcmonedas> listaMonedas = null;
        modelowmspcmonedas DecimalesMoneda = new modelowmspcmonedas();

        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();
        List<modelowmtfacturascab> listaConsCab = null;
        modelowmtfacturascab conscabcera = new modelowmtfacturascab();

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        public string numerador = "trans";

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

                    if (Request.Cookies["ComPwm"] != null)
                    {
                        string ComPwm = Request.Cookies["ComPwm"].Value;

                    }
                    if (Session["TotalFactura"] != null)
                    {
                        txt_total_factura.Text = Session["TotalFactura"].ToString();
                    }
                    if (Session["valor_asignado1"] != null)
                    {
                        txt_nro_trans.Text = Session["valor_asignado1"].ToString();
                    }
                    if (Session["Tipo"] != null)
                    {

                        transaccion = Session["Tipo"].ToString();
                        if (transaccion.Trim() == "UDP")
                        {
                            BuscarPagosPrevios();
                        }
                        if (transaccion.Trim() == "VER")
                        {
                            BuscarPagosPrevios();
                            Agregar_MedioPago.Visible = false;
                        }



                    }
                    cargarListaDesplegables();
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());

            }
        }

        public void GuardarExcepciones(string metodo, string error)
        {

            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "MediosPagosPos.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Today;
            ModeloExcepcion.usuario_mod = AmUsrLog;
            ModeloExcepcion.fecha_mod = DateTime.Today;
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }

        public void cargarListaDesplegables()
        {
            try
            {
                lbl_error.Text = "";


                //LIsta medios pago
                listaMedios = consultaMediosPago.BuscarMediosPago(ComPwm);
                cbx_medios.DataSource = listaMedios;
                cbx_medios.DataTextField = "observacion";
                cbx_medios.DataValueField = "cod_fpago";
                cbx_medios.DataBind();
            }
            catch (Exception ex)
            {
                GuardarExcepciones("cargarListaDesplegables", ex.ToString());

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
                listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
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
        public void BuscarPagosPrevios()
        {
            try
            {
                lbl_error.Text = "";

                //Cargar en el mismo modelo modeloFacturasPagos
                //Buscar tabla wmt_facturas_pgs
                if (transaccion == "UDP" || transaccion == "VER")
                {
                    //Si es pago en efectivo si puede ser mayor el pago xq se puede dar vuelto
                    listaPagosPgs = consultaMediosPago.ConsultaTablaPgs(AmUsrLog, ComPwm, txt_nro_trans.Text);
                    Session["detallePagos"] = listaPagosPgs;

                    gv_Producto.DataSource = listaPagosPgs;
                    gv_Producto.DataBind();
                    gv_Producto.Height = 100;

                    /*  foreach (var item in listaPagosPgs)
                      {
                          modeloPagosPgs = item;
                          break;
                      }


                      if (Convert.ToString(modeloPagosPgs.diferencia) != "0.00")
                      {
                          txt_vuelto.Text = Convert.ToString(modeloPagosPgs.diferencia);
                      }
                      */
                    //Buscar el tipo de moneda
                    conscabcera = null;
                    conscabcera = BuscarCabecera();
                    //Consultamos cuantos descimales se van a usar redondeo
                    DecimalesMoneda = null;
                    DecimalesMoneda = BuscarDecimales(conscabcera.cod_moneda.Trim());
                    listaSaldos = consultaMediosPago.BuscarDiferenciaSaldos(AmUsrLog, ComPwm, txt_nro_trans.Text);
                    foreach (var item in listaSaldos)
                    {
                        modeloDiferencia = item;
                    }
                    decimal pago = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(modeloDiferencia.pagado));
                    txt_total_pago.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, pago);
                    decimal pago1 = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(modeloDiferencia.diferencia));
                    txt_Diferencia.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, pago1);

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarPagosPrevios", ex.ToString());

            }

        }
        //Buscar cantidad de decimales q se va ausar x tipo de moneda
        public modelowmspcmonedas BuscarDecimales(string moneda)
        {
            try
            {
                lbl_error.Text = "";

                listaMonedas = ConsultaCMonedas.ConsultaCMonedas(AmUsrLog, ComPwm, moneda);

                DecimalesMoneda = null;
                foreach (modelowmspcmonedas item in listaMonedas)
                {

                    DecimalesMoneda = item;
                    break;

                }

                return DecimalesMoneda;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarDecimales", ex.ToString());
                return null;
            }
        }
        public void HabilitarCajas()
        {
            lblDes.Visible = true;
            lblBanco.Visible = true;
            lblMedio.Visible = true;
            lblPre.Visible = true;
            txt_Descripcion.Visible = true;
            txt_numero.Visible = true;
            txt_Precio.Visible = true;
            AgregarPago.Visible = true;
            cbx_tercero.Visible = true;
            cbx_medios.Visible = false;
            Agregar_MedioPago.Visible = false;

        }

        public void InhabilitarCajas()
        {
            lblDes.Visible = false;
            lblBanco.Visible = false;
            lblMedio.Visible = false;
            lblPre.Visible = false;
            txt_Descripcion.Visible = false;
            txt_numero.Visible = false;
            txt_Precio.Visible = false;
            AgregarPago.Visible = false;
            cbx_tercero.Visible = false;
            cbx_medios.Visible = true;
            Agregar_MedioPago.Visible = true;

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

        public void GuardarPagos()
        {
            try
            {
                lbl_error.Text = "";

                string error;
                //Busca en gv_producto todos los items añadidos que estan en la variable de session detallePagos
                modeloFacturasPagos = new List<modeloFacturasPagos>();
                modeloFacturasPagos = (Session["detallePagos"] as List<modeloFacturasPagos>);

                //Elimina forma de pago
                consultaMediosPago.EliminarPagosFactura(txt_nro_trans.Text);
                //Va añadiendo linea por linea al modelo insertar detalle factura
                int contarLinea = 0;
                foreach (var item in modeloFacturasPagos)
                {
                    contarLinea++;
                    detallePagosFactura.cod_tit = item.cod_tit;
                    detallePagosFactura.nro_docum = item.nro_docum;
                    detallePagosFactura.recibido = item.recibido;
                    detallePagosFactura.nro_trans = item.nro_trans;
                    detallePagosFactura.cod_emp = item.cod_emp;
                    detallePagosFactura.linea = contarLinea;
                    detallePagosFactura.cod_docum = item.cod_docum;
                    detallePagosFactura.cod_cta = item.cod_cta;
                    detallePagosFactura.cod_fpago = item.cod_fpago;

                    error = guardarPagos.InsertarPagosFactura(detallePagosFactura);
                    if (string.IsNullOrEmpty(error))
                    {

                    }
                    else
                    {
                        //this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                        lbl_mensaje.Text = error;

                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("GuardarPagos", ex.ToString());

            }

        }
        public ModeloTipoPagoTem BuscarDetallePago(string nro_trans)
        {
            try
            {
                lbl_error.Text = "";



                listaTemporal = consultaMediosPago.BuscarMediosPagoTemporal(AmUsrLog, ComPwm, nro_trans);


                modeloTemporal = null;
                foreach (ModeloTipoPagoTem item in listaTemporal)
                {

                    modeloTemporal = item;
                    break;

                }

                return modeloTemporal;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarDetallePago", ex.ToString());
                return null;
            }
        }



        public void AgregarPagoGrilla()
        {

            try
            {
                lbl_error.Text = "";

                modeloFacturasPagos item = new modeloFacturasPagos();
                modeloTemporal = null;
                modeloTemporal = BuscarDetallePago(txt_nro_trans.Text);

                //Consulta si existe el pago en la lista

                if (Session["detallePagos"] == null)
                {
                    modeloFacturasPagos = new List<modeloFacturasPagos>();
                }
                else
                {
                    modeloFacturasPagos = (Session["detallePagos"] as List<modeloFacturasPagos>);
                }

                Boolean existe = false;
                foreach (modeloFacturasPagos itemSuma in modeloFacturasPagos)
                {
                    if (itemSuma.nro_docum == modeloTemporal.nro_doc && itemSuma.cod_fpago.Trim() == modeloTemporal.cod_fpago.Trim())
                    {
                        existe = true;

                        itemSuma.recibido = Convert.ToDecimal(txt_Precio.Text);

                    }

                }

                if (!existe)
                {

                    item.cod_tit = cbx_tercero.SelectedValue;
                    if (txt_numero.Text == "")
                    { item.nro_docum = "0"; }
                    else { item.nro_docum = txt_numero.Text; }

                    item.recibido = Convert.ToDecimal(txt_Precio.Text);
                    item.nro_trans = txt_nro_trans.Text;
                    item.cod_emp = ComPwm;
                    item.cod_docum = modeloTemporal.cod_docum;
                    item.cod_cta = modeloTemporal.cod_cta;
                    item.cod_fpago = modeloTemporal.cod_fpago;
                    item.forma_pago = cbx_medios.SelectedItem.ToString();
                    item.tercero = cbx_tercero.SelectedItem.ToString();

                    modeloFacturasPagos.Add(item);
                }

                Session["detallePagos"] = modeloFacturasPagos;

                modeloFacturasPagos = (Session["detallePagos"] as List<modeloFacturasPagos>);
                gv_Producto.DataSource = modeloFacturasPagos;
                gv_Producto.DataBind();

                txt_Descripcion.Text = "";
                txt_numero.Text = "0";
                txt_Precio.Text = "0";
                txt_cal_vuelto.Text = "";
                item = null;
                InhabilitarCajas();
            }
            catch (Exception ex)
            {
                GuardarExcepciones("AgregarPagoGrilla", ex.ToString());

            }
        }



        protected void AgregarPago_Click(object sender, EventArgs e)
        {

            try
            {
                lbl_error.Text = "";

                /*Validar que la diferencia sea diferente de 0*/
                if (txt_total_factura.Text == txt_total_pago.Text)
                {
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Pago Finalizado, no puede pagar más de lo que Factura')+ error;</script>");
                }
                else
                {
                    //Buscar el tipo de moneda
                    conscabcera = null;
                    conscabcera = BuscarCabecera();
                    //Consultamos cuantos descimales se van a usar redondeo
                    DecimalesMoneda = null;
                    DecimalesMoneda = BuscarDecimales(conscabcera.cod_moneda.Trim());
                    //Preguntamos si calcula vuelto dependiendo del medio de pago
                    if (txt_cal_vuelto.Text == "N")
                    {
                        if (Convert.ToDecimal(txt_Precio.Text) > Convert.ToDecimal(txt_total_factura.Text))
                        {
                            this.Page.Response.Write("<script language='JavaScript'>window.alert('No puede pagar más de lo que Factura')+ error;</script>");
                        }
                        else
                        {
                            //agregar a grilla medio de pago para insertar
                            AgregarPagoGrilla();
                            GuardarPagos();


                            //Mostrar saldos
                            listaSaldos = consultaMediosPago.BuscarDiferenciaSaldos(AmUsrLog, ComPwm, txt_nro_trans.Text);
                            foreach (var item in listaSaldos)
                            {
                                modeloDiferencia = item;
                            }
                            decimal pago = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(modeloDiferencia.pagado));
                            txt_total_pago.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, pago);
                            decimal pago1 = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(modeloDiferencia.diferencia));
                            txt_Diferencia.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, pago1);

                            //Si es pago en efectivo si puede ser mayor el pago xq se puede dar vuelto
                            listaPagosPgs = consultaMediosPago.ObtenerVueltoPgs(txt_nro_trans.Text);
                            foreach (var item in listaPagosPgs)
                            {
                                modeloPagosPgs = item;
                                break;
                            }
                            if (Convert.ToString(modeloPagosPgs.diferencia) != "0.00")
                            {
                                decimal vuelto = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(modeloPagosPgs.diferencia));
                                txt_vuelto.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, vuelto);
                            }
                        }
                    }
                    else
                    {
                        //agregar a grilla medio de pago para insertar
                        AgregarPagoGrilla();
                        GuardarPagos();
                        //Mostrar saldos
                        listaSaldos = consultaMediosPago.BuscarDiferenciaSaldos(AmUsrLog, ComPwm, txt_nro_trans.Text);
                        foreach (var item in listaSaldos)
                        {
                            modeloDiferencia = item;
                        }
                        decimal pago = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(modeloDiferencia.pagado));
                        txt_total_pago.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, pago);
                        decimal pago1 = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(modeloDiferencia.diferencia));
                        txt_Diferencia.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, pago1);

                        //Si es pago en efectivo si puede ser mayor el pago xq se puede dar vuelto
                        listaPagosPgs = consultaMediosPago.ObtenerVueltoPgs(txt_nro_trans.Text);
                        foreach (var item in listaPagosPgs)
                        {
                            modeloPagosPgs = item;
                            break;
                        }
                        if (Convert.ToString(modeloPagosPgs.diferencia) != "0.00")
                        {
                            decimal vuelto = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(modeloPagosPgs.diferencia));
                            txt_vuelto.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, vuelto);
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("AgregarPago_Click", ex.ToString());

            }
        }

        protected void Agregar_MedioPago_Click(object sender, EventArgs e)
        {

            try
            {
                lbl_error.Text = "";

                if (txt_total_factura.Text == txt_total_pago.Text)
                {
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Pago Finalizado, no puede pagar más de lo que Factura')+ error;</script>");
                }
                else
                {
                    //Agregar medio de pago en la tabla wmt_facturas_pgstmp

                    modeloTiposPagos.nro_trans = txt_nro_trans.Text;
                    modeloTiposPagos.cod_fpago = cbx_medios.SelectedValue;
                    modeloTiposPagos.cod_emp = ComPwm;
                    consultaMediosPago.InsertarTipoPago(modeloTiposPagos);
                    //Recupero datos con wmspc_fpagoPOS_tmp--Recupera el medio de pago insertado en ese momento con sus restricciones
                    listaTemporal = consultaMediosPago.BuscarMediosPagoTemporal(AmUsrLog, ComPwm, txt_nro_trans.Text);
                    foreach (var item in listaTemporal)
                    {
                        modeloTemporal = item;
                    }
                    txt_Descripcion.Text = modeloTemporal.nom_fpago;
                    txt_cal_vuelto.Text = modeloTemporal.vuelto.Trim();
                    //Habilitar y deshabilitar campos segun medio de pago campo_numero, campo_terero
                    if (modeloTemporal.modif_ter == " ")
                    {
                        cbx_tercero.Enabled = true;
                    }
                    else { cbx_tercero.Enabled = false; }
                    if (modeloTemporal.modif_doc == " ")
                    {
                        txt_numero.Enabled = true;
                    }
                    else { txt_numero.Enabled = false; }

                    //buscar titulars sp wmspc_fpagoPOS_tittmp
                    listaTitular = consultaMediosPago.BuscartitularPagos(AmUsrLog, ComPwm, txt_nro_trans.Text);
                    cbx_tercero.DataSource = listaTitular;
                    cbx_tercero.DataTextField = "nom_tit";
                    cbx_tercero.DataValueField = "cod_tit";
                    cbx_tercero.DataBind();
                    txt_Precio.Text = "0";

                    HabilitarCajas();
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Agregar_MedioPago_Click", ex.ToString());

            }
        }

        //Grilla de medios de pago
        protected void gv_Producto_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                if (Session["detallePagos"] != null)
                {
                    modeloFacturasPagos detalle = new modeloFacturasPagos();
                    modeloFacturasPagos = (Session["detallePagos"] as List<modeloFacturasPagos>);// tomo la variable de secion 
                    foreach (var item in modeloFacturasPagos)
                    {
                        if (item.cod_fpago == Convert.ToString(((Label)e.Item.Cells[2].FindControl("cod_fpago")).Text) && item.nro_docum == Convert.ToString(((Label)e.Item.Cells[5].FindControl("nro_docum")).Text))// comparo si la lista el cosigo de producto es igual al selecionado
                        {
                            detalle = item; // saco el item seleccionado
                            break;
                        }
                    }
                    //Buscar el tipo de moneda
                    conscabcera = null;
                    conscabcera = BuscarCabecera();
                    //Consultamos cuantos descimales se van a usar redondeo
                    DecimalesMoneda = null;
                    DecimalesMoneda = BuscarDecimales(conscabcera.cod_moneda.Trim());

                    switch (e.CommandName) //ultilizo la variable para la opcion            
                    {
                        case "Editar":// lleno las cajas de texto con los datos para la edicon del item seleccionado
                            try
                            {
                                txt_Descripcion.Text = detalle.forma_pago;
                                cbx_tercero.SelectedValue = detalle.cod_tit;
                                txt_numero.Text = Convert.ToString(detalle.nro_docum);
                                txt_Precio.Text = Convert.ToString(detalle.recibido);

                                //Agregar medio de pago en la tabla wmt_facturas_pgstmp

                                modeloTiposPagos.nro_trans = txt_nro_trans.Text;
                                modeloTiposPagos.cod_fpago = detalle.cod_fpago.Trim();
                                modeloTiposPagos.cod_emp = ComPwm;
                                consultaMediosPago.InsertarTipoPago(modeloTiposPagos);

                                HabilitarCajas();
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
                                /*Eliminar item de la grilla*/
                                //Eliminar de la tabla temporal
                                consultaMediosPago.EliminarTemporal(txt_nro_trans.Text, ComPwm, detalle.cod_fpago);
                                consultaMediosPago.EliminarPagosSaldos(txt_nro_trans.Text, detalle.cod_fpago, detalle.nro_docum);
                                listaSaldos = consultaMediosPago.BuscarDiferenciaSaldos(AmUsrLog, ComPwm, txt_nro_trans.Text);
                                foreach (var item in listaSaldos)
                                {
                                    modeloDiferencia = item;
                                }
                                decimal pago = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(modeloDiferencia.pagado));
                                txt_total_pago.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, pago);
                                decimal pago1 = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(modeloDiferencia.diferencia));
                                txt_Diferencia.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, pago1);
                                //Si es pago en efectivo si puede ser mayor el pago xq se puede dar vuelto
                                listaPagosPgs = consultaMediosPago.ObtenerVueltoPgs(txt_nro_trans.Text);
                                foreach (var item in listaPagosPgs)
                                {
                                    modeloPagosPgs = item;
                                    break;
                                }
                                if (Convert.ToString(modeloPagosPgs.diferencia) != "0.00")
                                {
                                    decimal vuelto = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(modeloPagosPgs.diferencia));
                                    txt_vuelto.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, vuelto);
                                }

                                modeloFacturasPagos.RemoveAt(e.Item.ItemIndex);
                                Session["detallePagos"] = modeloFacturasPagos;
                                modeloFacturasPagos = (Session["detallePagos"] as List<modeloFacturasPagos>);
                                gv_Producto.DataSource = modeloFacturasPagos;
                                gv_Producto.DataBind();
                                break;
                            }
                            catch (Exception ex)
                            {
                                GuardarExcepciones("gv_Producto_ItemCommand, Eliminar", ex.ToString());

                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("gv_Producto_ItemCommand", ex.ToString());

            }



        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                Session.Remove("valor_asignado1");
                Session.Remove("Tipo");
                this.Page.Response.Write("<script language='JavaScript'>window.close('./MediosPagoPos.aspx', 'Medios Pago', 'top=100,width=800 ,height=600, left=400');</script>");
            }

            catch (Exception ex)
            {
                GuardarExcepciones("Cancelar_Click", ex.ToString());

            }
        }

      
    }
    }
