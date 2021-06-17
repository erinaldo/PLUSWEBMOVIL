using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaDatos.Modelos;
using System.IO;
using CapaDatos.Sql;

namespace CapaWeb.WebForms
{
    public partial class ParametrosComerciales : System.Web.UI.Page
    {
        public modeloSucuralempresa ModelosucursalEmpresa = new modeloSucuralempresa();
        public List<modeloSucuralempresa> ListaModeloSucursalEmpresa = new List<modeloSucuralempresa>();
        public Consultawmsucempresa ConsultaSucEmpresa = new Consultawmsucempresa();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();

        ConsultaParComerciales consultaParametros = new ConsultaParComerciales();
        modeloParametrosComerciales modParametros = new modeloParametrosComerciales();
        modeloParametrosComerciales modParGuardar = new modeloParametrosComerciales();
        modeloParFacElec modGuardarFac = new modeloParFacElec();
        List<modeloFormato> listaFormatos = null;
        List<modeloParFacElec> listaParFactura = null;
        RolesUserFacturacion roles = new RolesUserFacturacion();

        public string ComPwm;
        public string AmUsrLog;
        public string nro_trans = null;
        public string cod_proceso;
        public string proceso;
        public string numerador = "trans";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                RecuperarCokie();
                ListaModelowmspclogo = consultaLogo.BuscartaLogo(ComPwm, AmUsrLog);
                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }
                if (!IsPostBack)
                {
                    BuscarRol();

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());
            }
        }

        public void BuscarRol()
        {
            try
            {

                string rol = roles.RespuestaAccesoParamComerciales(AmUsrLog, ComPwm);
                if (string.IsNullOrEmpty(rol.Trim()))
                {
                    txtAcceso.Visible = true;
                    btn_formatosim.Enabled = false;
                    btn_contenido.Enabled = false;
                    btn_facturacion.Enabled = false;

                }
                else
                {
                    btn_formatosim.Enabled = true;
                    btn_contenido.Enabled = true;
                    btn_facturacion.Enabled = true;
                    CargarFormatosImpresion();
                    CargarContenido();
                    ActivarCabecera();
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarRol", ex.ToString());

            }
        }
        public void ActivarCabecera()
        {
            Panel4.Visible = true;

        }
        public void DesactivarCabecera()
        {
            Panel4.Visible = false;
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
                if (Request.Cookies["ProcAud"] != null)
                {
                    cod_proceso = Request.Cookies["ProcAud"].Value;
                }
                else
                {
                    cod_proceso = Convert.ToString(Request.QueryString["cod_proceso"]);
                    if (cod_proceso != null)
                    {
                        //Crear cookie de cod_proceso
                        Response.Cookies["ProcAud"].Value = cod_proceso;
                    }
                    proceso = "BuscarDenominaciones.aspx";
                }

            }
            catch (Exception ex)
            {
                GuardarExcepciones("RecuperarCokie", ex.ToString());
            }
        }

        public void GuardarExcepciones(string metodo, string error)
        {

            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "ParametrosComerciales.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            lbl_error.Text = "No se pudo completar la acción." + metodo + " Por favor notificar al administrador.";

        }
        public QueryString ulrDesencriptada()
        {

            //1- guardo el Querystring encriptado que viene desde el request en mi objeto
            QueryString qs = new QueryString(Request.QueryString);

            ////2- Descencripto y de esta manera obtengo un array Clave/Valor normal
            qs = Encryption.DecryptQueryString(qs);
            return qs;

        }

        protected void gv_Producto_ItemCommand(object source, DataGridCommandEventArgs e)
        {

            try
            {
                lbl_error.Text = "";
                string dato = Convert.ToString(((Label)e.Item.Cells[0].FindControl("linea")).Text);
                switch (e.CommandName) //ultilizo la variable para la opcion            
                {

                    case "Eliminar":
                        lbl_error.Text = consultaParametros.EliminarLineaDatosContratosFacturas(ComPwm, AmUsrLog, dato);
                        listaParFactura = consultaParametros.ListaParametrosFacturacion(AmUsrLog, ComPwm);
                        gv_Producto.DataSource = listaParFactura;
                        gv_Producto.DataBind();
                        gv_Producto.Height = 100;
                        break;
                }

            }
            catch (Exception ex)
            {
                GuardarExcepciones("gv_Producto_ItemCommand", ex.ToString());

            }
        }

        public void CargarFormatosImpresion()
        {
            try
            {
                listaFormatos = null;
                listaFormatos = consultaParametros.ListaFormatoFacturaVenta(AmUsrLog, ComPwm);
                cbx_forfactura.DataSource = listaFormatos;
                cbx_forfactura.DataTextField = "nom_formato";
                cbx_forfactura.DataValueField = "cod_formato";
                cbx_forfactura.DataBind();

                listaFormatos = null;
                listaFormatos = consultaParametros.ListaFormatoFacturaPOS(AmUsrLog, ComPwm);
                cbx_fac_pos.DataSource = listaFormatos;
                cbx_fac_pos.DataTextField = "nom_formato";
                cbx_fac_pos.DataValueField = "cod_formato";
                cbx_fac_pos.DataBind();

                listaFormatos = null;
                listaFormatos = consultaParametros.ListaFormatoPedido(AmUsrLog, ComPwm);
                cbx_for_pedido.DataSource = listaFormatos;
                cbx_for_pedido.DataTextField = "nom_formato";
                cbx_for_pedido.DataValueField = "cod_formato";
                cbx_for_pedido.DataBind();

                listaFormatos = null;
                listaFormatos = consultaParametros.ListaFormatoProforma(AmUsrLog, ComPwm);
                cbx_for_proforma.DataSource = listaFormatos;
                cbx_for_proforma.DataTextField = "nom_formato";
                cbx_for_proforma.DataValueField = "cod_formato";
                cbx_for_proforma.DataBind();

                listaFormatos = null;
                listaFormatos = consultaParametros.ListaFormatoRemision(AmUsrLog, ComPwm);
                cbx_for_remision.DataSource = listaFormatos;
                cbx_for_remision.DataTextField = "nom_formato";
                cbx_for_remision.DataValueField = "cod_formato";
                cbx_for_remision.DataBind();

                listaFormatos = null;
                listaFormatos = consultaParametros.ListaFormatoNotaCredito(AmUsrLog, ComPwm);
                cbx_for_nc.DataSource = listaFormatos;
                cbx_for_nc.DataTextField = "nom_formato";
                cbx_for_nc.DataValueField = "cod_formato";
                cbx_for_nc.DataBind();

                listaFormatos = null;
                listaFormatos = consultaParametros.ListaFormatoNotaDebito(AmUsrLog, ComPwm);
                cbx_for_nd.DataSource = listaFormatos;
                cbx_for_nd.DataTextField = "nom_formato";
                cbx_for_nd.DataValueField = "cod_formato";
                cbx_for_nd.DataBind();

                listaFormatos = null;
                listaFormatos = consultaParametros.ListaFormatoInterfazContable(AmUsrLog, ComPwm);
                cbx_int_con.DataSource = listaFormatos;
                cbx_int_con.DataTextField = "nom_formato";
                cbx_int_con.DataValueField = "cod_formato";
                cbx_int_con.DataBind();


            }
            catch (Exception ex)
            {
                GuardarExcepciones("CargarFormatosImpresion", ex.ToString());
            }
        }


        public void GuardarFormatosImpresion()
        {
            try
            {
                //Actualizar datos
                modParGuardar.impresion_factura = cbx_forfactura.SelectedValue.Trim();
                modParGuardar.impresion_pos = cbx_fac_pos.SelectedValue.Trim();
                modParGuardar.impresion_nc = cbx_for_nc.SelectedValue.Trim();
                modParGuardar.impresion_ndeb = cbx_for_nd.SelectedValue.Trim();
                modParGuardar.impresion_pedcom = cbx_for_pedido.SelectedValue.Trim();
                modParGuardar.impresion_proforma = cbx_for_proforma.SelectedValue.Trim();
                modParGuardar.impresion_remision = cbx_for_remision.SelectedValue.Trim();
                modParGuardar.impresion_interfaz = cbx_int_con.SelectedValue.Trim();
                modParGuardar.maneja_recurso = cbx_maneja_recurso.SelectedValue.Trim();
                modParGuardar.meses_historia = Convert.ToInt16(txt_historia.Text);
                modParGuardar.cod_emp = ComPwm;
                modParGuardar.usuario_mod = AmUsrLog;
                lbl_error.Text = consultaParametros.ActualizarFormatosImpresion(modParGuardar);
            }
            catch (Exception ex)
            {
                GuardarExcepciones("GuardarFormatosImpresion", ex.ToString());
            }
        }

        public void GuardarContenidoFacturas()
        {
            try
            {
                modParGuardar.info_trib1 = txt_info1.Text.Trim();
                modParGuardar.info_trib2 = txt_info2.Text.Trim();
                modParGuardar.info_trib3 = txt_info3.Text.Trim();
                modParGuardar.info_trib4 = txt_info4.Text.Trim();
                modParGuardar.info_trib5 = txt_info5.Text.Trim();
                modParGuardar.letra_cambio1 = txt_letra1.Text.Trim();
                modParGuardar.letra_cambio2 = txt_letra2.Text.Trim();
                modParGuardar.letra_cambio3 = txt_letra3.Text.Trim();
                modParGuardar.cod_emp = ComPwm;
                modParGuardar.usuario_mod = AmUsrLog;
                lbl_error.Text = consultaParametros.ActualizarContenidoFactura(modParGuardar);

            }
            catch (Exception ex)
            {
                GuardarExcepciones("GuardarContenidoFacturas", ex.ToString());
            }
        }

        public void limpiar()
        {
            fechainicio.Text = "";
            txt_cantidad.Text = "";
            txt_detalle.Text = "";
            txt_det1.Text = "";
            txt_det2.Text = "";
            txt_tolerancia.Text = "";
            txt_tot1.Text = "";
            txt_to2.Text = "";
            txt_inicio.Text = "";
            txt_fin.Text = "";
            fec_ini.Text = "";
            fec_fin.Text = "";

        }
        public void GuardarContratosFacturas(string tipo)
        {
            try
            {
                //insertar por linea

                string linea = consultaParametros.LineaDatosContratosFacturas(ComPwm, AmUsrLog);
                modGuardarFac.cod_emp = ComPwm;
                modGuardarFac.linea = linea.Trim();
                modGuardarFac.usuario_mod = AmUsrLog;
                modGuardarFac.fecha_mod = DateTime.Now;
                modGuardarFac.tipo_documento = cbx_tipo_doc.SelectedValue.Trim();
                modGuardarFac.tipo_contrato = cbx_tipo_contrato.SelectedValue.Trim();
                modGuardarFac.tolerancia_dias = "0";
                modGuardarFac.estado = "A";
                DateTime fecreg = Convert.ToDateTime(fechainicio.Text);
                modGuardarFac.fec_r1 = string.Format("{0:00}", fecreg.Day);
                modGuardarFac.fec_r2 = string.Format("{0:00}", fecreg.Month);
                modGuardarFac.fec_r3 = fecreg.Year.ToString();
                if (tipo == "CAN")
                {

                    modGuardarFac.cantidad = txt_cantidad.Text.Trim();
                    modGuardarFac.tolerancia_num = txt_tolerancia.Text.Trim();
                    modGuardarFac.detalle = txt_detalle.Text.Trim();
                    //por defecto
                    DateTime Fechainicio = DateTime.Now;
                    DateTime Fechafin = DateTime.Now;
                    modGuardarFac.fec_ini1 = string.Format("{0:00}", Fechainicio.Day);
                    modGuardarFac.fec_ini2 = string.Format("{0:00}", Fechainicio.Month);
                    modGuardarFac.fec_ini3 = Fechainicio.Year.ToString();
                    modGuardarFac.fec_fin1 = string.Format("{0:00}", Fechafin.Day);
                    modGuardarFac.fec_fin2 = string.Format("{0:00}", Fechafin.Month);
                    modGuardarFac.fec_fin3 = Fechafin.Year.ToString();
                    modGuardarFac.nro_docum_ini = "0";
                    modGuardarFac.nro_docum_fin = "0";
                }
                if (tipo == "NUM")
                {
                    modGuardarFac.nro_docum_ini = txt_inicio.Text.Trim();
                    modGuardarFac.nro_docum_fin = txt_fin.Text.Trim();
                    modGuardarFac.tolerancia_num = txt_tot1.Text.Trim();
                    modGuardarFac.detalle = txt_det1.Text.Trim();
                    //POR DEFECTO
                    DateTime Fechainicio = DateTime.Now;
                    DateTime Fechafin = DateTime.Now;
                    modGuardarFac.fec_ini1 = string.Format("{0:00}", Fechainicio.Day);
                    modGuardarFac.fec_ini2 = string.Format("{0:00}", Fechainicio.Month);
                    modGuardarFac.fec_ini3 = Fechainicio.Year.ToString();
                    modGuardarFac.fec_fin1 = string.Format("{0:00}", Fechafin.Day);
                    modGuardarFac.fec_fin2 = string.Format("{0:00}", Fechafin.Month);
                    modGuardarFac.fec_fin3 = Fechafin.Year.ToString();
                    modGuardarFac.cantidad = "0";
                }
                if (tipo == "FEC")
                {
                    DateTime Fechainicio = Convert.ToDateTime(fec_ini.Text);
                    DateTime Fechafin = Convert.ToDateTime(fec_fin.Text);
                    modGuardarFac.fec_ini1 = string.Format("{0:00}", Fechainicio.Day);
                    modGuardarFac.fec_ini2 = string.Format("{0:00}", Fechainicio.Month);
                    modGuardarFac.fec_ini3 = Fechainicio.Year.ToString();
                    modGuardarFac.fec_fin1 = string.Format("{0:00}", Fechafin.Day);
                    modGuardarFac.fec_fin2 = string.Format("{0:00}", Fechafin.Month);
                    modGuardarFac.fec_fin3 = Fechafin.Year.ToString();
                    modGuardarFac.tolerancia_num = txt_to2.Text.Trim();
                    modGuardarFac.detalle = txt_det2.Text.Trim();
                    //DEFECTO
                    modGuardarFac.cantidad = "0";
                    modGuardarFac.nro_docum_ini = "0";
                    modGuardarFac.nro_docum_fin = "0";
                }
                lbl_error.Text = consultaParametros.InsertarContratoFactura(modGuardarFac);
                //limpiar y cargar grilla
                listaParFactura = consultaParametros.ListaParametrosFacturacion(AmUsrLog, ComPwm);
                gv_Producto.DataSource = listaParFactura;
                gv_Producto.DataBind();
                gv_Producto.Height = 100;
                limpiar();
                Panel4.Visible = true;
                Pnl_cant.Visible = false;
                Pnl_fec.Visible = false;
                Pnl_numero.Visible = false;

            }
            catch (Exception ex)
            {
                GuardarExcepciones("GuardarContratosFacturas", ex.ToString());
            }
        }
        public void CargarContenido()
        {
            try
            {
                //Parametros comerciales
                modParametros = consultaParametros.FormatosImpresionPC(AmUsrLog, ComPwm);
                if (modParametros.cod_emp.Trim() != null)
                {
                    cbx_forfactura.SelectedValue = modParametros.impresion_factura.Trim();
                    cbx_fac_pos.SelectedValue = modParametros.impresion_pos.Trim();
                    cbx_for_nc.SelectedValue = modParametros.impresion_nc.Trim();
                    cbx_for_nd.SelectedValue = modParametros.impresion_ndeb.Trim();
                    cbx_for_pedido.SelectedValue = modParametros.impresion_pedcom.Trim();
                    cbx_for_proforma.SelectedValue = modParametros.impresion_proforma.Trim();
                    cbx_for_remision.SelectedValue = modParametros.impresion_remision.Trim();
                    cbx_int_con.SelectedValue = modParametros.impresion_interfaz.Trim();
                    cbx_maneja_recurso.SelectedValue = modParametros.maneja_recurso.Trim();
                    txt_historia.Text = modParametros.meses_historia.ToString();
                    txt_info1.Text = modParametros.info_trib1;
                    txt_info2.Text = modParametros.info_trib2;
                    txt_info3.Text = modParametros.info_trib3;
                    txt_info4.Text = modParametros.info_trib4;
                    txt_info5.Text = modParametros.info_trib5;
                    txt_letra1.Text = modParametros.letra_cambio1;
                    txt_letra2.Text = modParametros.letra_cambio2;
                    txt_letra3.Text = modParametros.letra_cambio3;
                    listaParFactura = consultaParametros.ListaParametrosFacturacion(AmUsrLog, ComPwm);
                    gv_Producto.DataSource = listaParFactura;
                    gv_Producto.DataBind();
                    gv_Producto.Height = 100;
                    if (listaParFactura.Count > 0)
                    {
                        string cod_email = consultaParametros.EnvioCorreosContratosFacturas(ComPwm, AmUsrLog);
                        if (string.IsNullOrEmpty(cod_email.Trim()))
                        {
                            txt_avisoemail.Visible = true;
                        }
                        else
                        {
                            txt_avisoemail.Visible = false;

                        }
                        string mensaje1 = consultaParametros.MensajesContratosFacturas(ComPwm, AmUsrLog);
                        if (string.IsNullOrEmpty(mensaje1.Trim()))
                        {
                            txt_mensaje.Visible = false;
                            txt_mensaje.Text = "";
                        }
                        else
                        {
                            txt_mensaje.Visible = true;
                            txt_mensaje.Text = mensaje1;
                        }
                        string control = consultaParametros.ControlUsuarioContratosFacturas(ComPwm, AmUsrLog);
                        if (string.IsNullOrEmpty(control.Trim()))
                        {
                            lbl_conusu.Visible = false;
                        }
                        else { lbl_conusu.Visible = true; }
                    }



                }

        }
            catch (Exception ex)
            {
                GuardarExcepciones("CargarContenido", ex.ToString());
            }
}

        protected void btn_formatosim_Click(object sender, EventArgs e)
        {
            CargarFormatosImpresion();
            CargarContenido();
            ActivarCabecera();
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            btn_facturacion.BackColor = System.Drawing.Color.White;
            btn_contenido.BackColor = System.Drawing.Color.White;
            btn_formatosim.BackColor = System.Drawing.Color.SteelBlue;
        }

        protected void btn_contenido_Click(object sender, EventArgs e)
        {
            CargarFormatosImpresion();
            CargarContenido();
            ActivarCabecera();
            Panel2.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = false;
            btn_facturacion.BackColor = System.Drawing.Color.White;
            btn_contenido.BackColor = System.Drawing.Color.SteelBlue;
            btn_formatosim.BackColor = System.Drawing.Color.White;
        }

        protected void btn_facturacion_Click(object sender, EventArgs e)
        {
            CargarFormatosImpresion();
            CargarContenido();
            ActivarCabecera();
            Panel3.Visible = true;
            Panel2.Visible = false;
            Panel1.Visible = false;
            btn_facturacion.BackColor = System.Drawing.Color.SteelBlue;
            btn_contenido.BackColor = System.Drawing.Color.White;
            btn_formatosim.BackColor = System.Drawing.Color.White;

        }

        protected void btn_agregar_con_Click(object sender, EventArgs e)
        {
            lbl_error.Text = "";
            if (fechainicio.Text.Trim() == "")
            {
                lbl_error.Text = "Ingrese fecha";
            }
            else
            {
                lbl_contrato.Text = cbx_tipo_contrato.SelectedItem.Text;
                lbl_contrato1.Text = cbx_tipo_contrato.SelectedItem.Text;
                lbl_con2.Text = cbx_tipo_contrato.SelectedItem.Text;
                lbl_documento.Text = cbx_tipo_doc.SelectedItem.Text;
                lbl_docu1.Text = cbx_tipo_doc.SelectedItem.Text;
                lbl_docu2.Text = cbx_tipo_doc.SelectedItem.Text;
                DesactivarCabecera();

                if (cbx_tipo_contrato.SelectedValue.Trim() == "C")
                {
                    //Activar por cantidad

                    Pnl_cant.Visible = true;
                    Pnl_fec.Visible = false;
                    Pnl_numero.Visible = false;
                }
                if (cbx_tipo_contrato.SelectedValue.Trim() == "F")
                {
                    //Activar por rango fechas
                    Pnl_fec.Visible = true;
                    Pnl_numero.Visible = false;
                    Pnl_cant.Visible = false;
                }
                if (cbx_tipo_contrato.SelectedValue.Trim() == "N")
                {
                    //Activar por rango numeros
                    Pnl_numero.Visible = true;
                    Pnl_cant.Visible = false;
                    Pnl_fec.Visible = false;
                }
            }
        }

        protected void btn_volver_Click(object sender, EventArgs e)
        {
            limpiar();
            Pnl_cant.Visible = false;
            ActivarCabecera();
        }

        protected void btn_volver_fec_Click(object sender, EventArgs e)
        {
            limpiar();
            Pnl_fec.Visible = false;
            ActivarCabecera();
        }

        protected void btn_volver_num_Click(object sender, EventArgs e)
        {
            limpiar();
            Pnl_numero.Visible = false;
            ActivarCabecera();
        }

        protected void btn_guardar_fimp_Click(object sender, EventArgs e)
        {
            GuardarFormatosImpresion();
        }

        protected void btn_cont_fac_Click(object sender, EventArgs e)
        {
            GuardarContenidoFacturas();
        }

        protected void btn_aceptar_fec_Click(object sender, EventArgs e)
        {
            lbl_error.Text = "";
            //Guardar parametros de facelec por fecha
            if (fec_fin.Text.Trim() == "")
            {
                lbl_error.Text = "Ingrese fecha inicio";
            }
            else
            {
                if (fec_fin.Text.Trim() == "")
                {
                    lbl_error.Text = "Ingrese fecha fin";
                }
                else
                {
                    if (txt_to2.Text.Trim() == "")
                    {
                        lbl_error.Text = "Ingrese tolerancia";
                    }
                    else { GuardarContratosFacturas("FEC"); }
                }
            }

        }

        protected void btn_cantidad_Click(object sender, EventArgs e)
        {
            lbl_error.Text = "";
            if (txt_cantidad.Text.Trim() == "")
            {
                lbl_error.Text = "Ingrese cantidad";
            }
            else
            {
                if (txt_tolerancia.Text.Trim() == "")
                {
                    lbl_error.Text = "Ingrese tolerancia";
                }
                else { GuardarContratosFacturas("CAN"); }
            }
        }

        protected void btn_aceptar_num_Click(object sender, EventArgs e)
        {
            lbl_error.Text = "";
            if (txt_inicio.Text.Trim() == "")
            {
                lbl_error.Text = "Ingrese número inicio";
            }
            else
            {
                if (txt_inicio.Text.Trim() == "")
                {
                    lbl_error.Text = "Ingrese número fin";
                }
                else
                {
                    if (txt_tot1.Text.Trim() == "")
                    {
                        lbl_error.Text = "Ingrese tolerancia";
                    }
                    else { GuardarContratosFacturas("NUM"); }
                }
            }

        }
    }
}