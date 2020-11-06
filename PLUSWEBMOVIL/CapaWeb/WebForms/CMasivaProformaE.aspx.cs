using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;
using CapaProceso.FacturaMasiva;
using System.IO;


namespace CapaWeb.WebForms
{
    public partial class CMasivaProformaE : System.Web.UI.Page
    {
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();
        FacturaMasivaProforma carga = new FacturaMasivaProforma();
        List<modeloClientesproforma> lista = null;
        modeloClientesproforma modeloClientes = new modeloClientesproforma();

        modelowmspctitulares clientes_suc = new modelowmspctitulares();
        Consultawmspcresfact ConsultaResolucion = new Consultawmspcresfact();
        modelowmspcresfact resolucion = new modelowmspcresfact();
        List<modelowmspcresfact> listaRes = null;

        ConsultaProformasFac ConsultaProformas = new ConsultaProformasFac();
        modelowmtproformascab ModeloProformas = new modelowmtproformascab();
        List<modelowmtproformascab> ListaProformas = null;
        ConsultaProformaIns InsertarProIns = new ConsultaProformaIns();
       
        public modeloUsuariosucursal ModelousuarioSucursal = new modeloUsuariosucursal();
        public List<modeloUsuariosucursal> ListaModeloUsuarioSucursal = new List<modeloUsuariosucursal>();
        public ConsultawmusuarioSucursal ConsultaUsuxSuc = new ConsultawmusuarioSucursal();
        public ConsultausuarioSucursal consultaUsuarioSucursal = new ConsultausuarioSucursal();
        List<modeloFacturaEMasiva> listaFacturar = new List<modeloFacturaEMasiva>();

        Consultawmspcmonedas ConsultaCMonedas = new Consultawmspcmonedas();
        List<modelowmspcmonedas> listaMonedas = null;

        public string ComPwm;
        public string socio;
        public string AmUsrLog;
        public string cod_proceso;
        public string sesion;
        public string AmComCod;
        public string ResF_estado = "S";
        public string ResF_serie = "0";
        public string ResF_tipo = "F";
        public string MonB__moneda = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //lbl_error.Text = "";
                RecuperarCokie();
                ListaModelowmspclogo = consultaLogo.BuscartaLogo(ComPwm, AmUsrLog);
                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }
                if (Session["nro_trans_proforma"] != null)
                {
                    btn_verificar.Visible = true;
                    nro_trans_pro_sele.Text = Session["nro_trans_proforma"].ToString();
                    nro_trans_pro_sele.Visible = true;
                    lbl_nro.Visible = true;
                }
                if (!IsPostBack)
                {
                    Session.Remove("nro_trans_proforma");
                    //Cargar sucursal del usuario
                    //Cargar la sucursal del usuario logeado
                    ListaModeloUsuarioSucursal = ConsultaUsuxSuc.UnicoUsuarioSucursal(ComPwm, AmUsrLog, ""); //Solo se envia empresa y usuario
                    if (ListaModeloUsuarioSucursal.Count == 0)
                    {
                        lbl_mensaje.Text = "Usuario no tiene sucursal asignada, por favor asignar sucursarl para continuar.";
                    }
                    else
                    {
                        foreach (var item in ListaModeloUsuarioSucursal)
                        {
                            ModelousuarioSucursal = item;
                            break;
                        }
                        lbl_cod_suc.Text = ModelousuarioSucursal.cod_sucursal.Trim();
                        lbl_sucursal.Text = "-" + ModelousuarioSucursal.nom_sucursal.Trim();

                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());
            }
        }

       

        protected void btn_verificar_Click(object sender, EventArgs e)
        {
            //Analizamos antes de procesar--resolucion por sucursal usuario
            //vALIDAR QUE SOLO EXISTA UNA RESOLUCION ACTIVA-
            listaRes = null;
            listaRes = ConsultaResolucion.ConsultaResolusionXSucursal(AmUsrLog, ComPwm, ResF_estado, ResF_serie, ResF_tipo, lbl_cod_suc.Text.Trim());
            resolucion = null;
            foreach (modelowmspcresfact item in listaRes)
            {
                resolucion = item;
            }
            if (listaRes.Count == 0)
            {

                lbl_mensaje.Text = "No existe una resolución activa para Facturar.";
            }
            else
            {
                if (listaRes.Count > 1)
                {

                    lbl_mensaje.Text = "Existe más de una resolución activa, para Facturar habilite una solamente.";
                }
                else
                {
                    lbl_prefijo.Text = resolucion.prefijo;
                    //Tipo factura
                    if (resolucion.tipo_fac == "S")
                    { Session["Tipo_facturaP"] = "VTAE"; }
                    else { Session["Tipo_facturaP"] = "VTA"; }
                        lbl_prefijo.Visible = true;
                    lbl_pre.Visible = true;
                    lista = ConsultaProformas.TotalProformasAFacturar(AmUsrLog, ComPwm, nro_trans_pro_sele.Text); //Buscar el total de clientes a facturar
                    int count = 0;
                    modeloClientes = null;
                    foreach (modeloClientesproforma item in lista)
                    {

                        modeloClientes = item;
                        count++;
                    }
                    if (lista.Count > 0)
                    {
                        btn_verificar.Visible = false;
                        btn_cancelar.Visible = true;
                        BtnIniciar.Enabled = true;
                        BtnIniciar.Visible = true;
                        lbl_facturas.Text = Convert.ToString(count);
                        //Cargar moneda para facturar
                        listaMonedas = ConsultaCMonedas.ConsultaCMonedas(AmUsrLog, ComPwm, MonB__moneda);
                        cbx_moneda.DataSource = listaMonedas;
                        cbx_moneda.DataTextField = "descripcion";
                        cbx_moneda.DataValueField = "cod_moneda";
                        cbx_moneda.DataBind();
                        cbx_moneda.Visible = true;
                        lbl_moneda.Visible = true;
                        //validar fecha de factura
                        ValidarFecha();

                    }
                    if(lista.Count==0)
                    {
                        btn_proformas.Visible = true;
                        btn_cancelar.Visible = true;
                    }
                    

                }
            }
        }

        public Boolean ValidarFecha()
        {
            try
            {
                lbl_mensaje.Text = "";
                ListaProformas = ConsultaProformas.BuscarProformasCab(nro_trans_pro_sele.Text.Trim());
                foreach (var item in ListaProformas)
                {
                    ModeloProformas = item;
                }

                bool fecha_validar = false;
                DateTime Fecha_seleccion = ModeloProformas.fec_doc;
                if (Session["Tipo_facturaP"].ToString() == "VTAE")
                {

                    DateTime Fecha_actual = DateTime.Today;
                    DateTime Fecha_minima = DateTime.Today.AddDays(-5);


                    if (Fecha_seleccion < Fecha_minima)
                    {
                        lbl_mensaje.Text = "La fecha de la factura no puede ser menor a cinco días de la fecha actual";
                        lbl_mensaje.Visible = true;
                        fecha_validar = true;
                    }
                    if (Fecha_seleccion > Fecha_actual)
                    {

                        lbl_mensaje.Text = "La fecha de la factura no puede ser mayor a  la fecha actual";
                        lbl_mensaje.Visible = true;
                        fecha_validar = true;

                    }
                }
                return fecha_validar;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("ValidarFecha", ex.ToString());
                return true;
            }
        }
        public void RecuperarCokie()
        {
            try
            {
                // lbl_error.Text = "";

                if (Request.Cookies["ComPwm"] != null)
                {
                    ComPwm = Request.Cookies["ComPwm"].Value;
                }
                else
                {
                    Response.Redirect("../Inicio.asp");
                }

                if (Request.Cookies["AmScNCod"] != null)
                {
                    socio = Request.Cookies["AmScNCod"].Value;
                }
                if (Request.Cookies["AmSesId"] != null)
                {
                    sesion = Request.Cookies["AmSesId"].Value;
                }

                if (Request.Cookies["AmComCod"] != null)
                {
                    AmComCod = Request.Cookies["AmComCod"].Value;
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
                }
                //Codigo empresa
                string empresa_codigo = ComPwm;
                string empresa_canorus = AmComCod;
                Response.Cookies["empresa_codigo"].Value = empresa_codigo;
                Response.Cookies["empresa_canorus"].Value = empresa_canorus;
                Response.Cookies["socio_codigo"].Value = socio;
                Response.Cookies["usuario"].Value = AmUsrLog;
                Response.Cookies["sesion"].Value = sesion;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("RecuperarCokie", ex.ToString());

            }

        }
        public void GuardarExcepciones(string metodo, string error)
        {

            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "CMasivaProformaE.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
             lbl_error.Text = "No se pudo completar la acción" + metodo + "." + " Por favor notificar al administrador.";

        }
        //PROGRESS BAR
        private int Prop_CoTareas
        {
            get
            {
                if (ViewState["CoTareas"] == null)
                {
                    ViewState["CoTareas"] = 0;
                }
                return (int)ViewState["CoTareas"];
            }

            set
            {
                ViewState["CoTareas"] = value;
            }
        }

        private int Prop_TotalTareas = 0;


        private int f_PorcentajeAvance(int Par_TotalTareas, int Par_TareaActual)
        {
            int liPorcentaje = 0;
            //aplicar una regla de 3 simple
            liPorcentaje = (Par_TareaActual * 100) / Par_TotalTareas;
            return liPorcentaje;
        }

        private int f_ancho_control_porcentaje(int Par_AnchoTotalControl, int Par_Porcentaje)
        {
            int liAnchoControl = 0;
            liAnchoControl = (Par_Porcentaje * Par_AnchoTotalControl) / 100;
            return liAnchoControl;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

            Prop_TotalTareas = Convert.ToInt16(lbl_facturas.Text);
            //limitar el numero de tareas al total de tareas a realizar
            if (Prop_CoTareas <= Prop_TotalTareas)
            {
                int liPorcentajeAvance = 0;

                //contador de tarea??
                Prop_CoTareas += 1;

                //tarea actual con total tareas
                LblAvance.Text = Prop_CoTareas.ToString() + " de " + Prop_TotalTareas.ToString();

                //porcentaje de avance segun el numero de tareas
                liPorcentajeAvance = f_PorcentajeAvance(Prop_TotalTareas, Prop_CoTareas);
                LblPorcentajeAvance.Text = liPorcentajeAvance.ToString() + "%";

                //barra de progreso
                LblProgressBar.Visible = true;
                LblProgressBar.Width = f_ancho_control_porcentaje(400, liPorcentajeAvance);

                //tareas a realizar poner todo el codigo para facturar electronicamente
                string error_fac = null;
                
                clientes_suc = ConsultaProformas.ClienteProformasAFacturar(AmUsrLog, ComPwm, nro_trans_pro_sele.Text.Trim());

                try
                {
                    if (!string.IsNullOrEmpty(clientes_suc.cod_tit.Trim()))
                    {
                       error_fac= carga.GenerarFactura(AmUsrLog, ComPwm, lbl_cod_suc.Text.Trim(), clientes_suc.cod_tit.Trim(),clientes_suc.cod_sucursal.Trim(), nro_trans_pro_sele.Text.Trim(), cbx_moneda.SelectedValue.Trim(), clientes_suc.nro_id.Trim());
                       
                        if (!string.IsNullOrEmpty(error_fac))
                        {
                            carga.ActualizarErrorProformaTit(AmUsrLog, ComPwm, "E", nro_trans_pro_sele.Text.Trim());//Estado E cuando ocurre un error 

                            lbl_error_factura.Text = error_fac + " Cliente: " + clientes_suc.cod_tit + " sucursal: "+ clientes_suc.cod_sucursal;
                            lbl_error_factura.Visible = true;
                            return;

                        }
                    }
                }
                catch (Exception aee)
                {

                    throw;
                }

                //.....
            }

            if (Prop_CoTareas == Prop_TotalTareas)
            {
                Prop_CoTareas = 0;
                Timer1.Enabled = false;
                LblAvance.Text = "Tarea finalizada";
                BtnIniciar.Visible = false;
                btn_verificar.Visible = true;
                btn_proformas.Enabled = true;

                //finalizar proforma
                carga.ActualizarEstadoProformaCab(AmUsrLog, ComPwm, nro_trans_pro_sele.Text.Trim(), "F");
                btn_limpiar.Visible = true;
             
            }
        }
        protected void BtnIniciar_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = true;
            BtnIniciar.Enabled = false;
            Prop_TotalTareas = 10;
            
        }

        protected void btn_proformas_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (Session["nro_trans_proforma"] == null)
                {
                   
                    this.Page.Response.Write("<script language='JavaScript'>window.open('./BuscarProformasM.aspx', 'Buscar Proformas', 'top=100,width=800 ,height=400, left=400');</script>");

                }
                else
                {
                    btn_proformas.Visible = false;
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_proformas_Click", ex.ToString());

            }
        }

        protected void btn_limpiar_Click(object sender, EventArgs e)
        {
            //limpiar todas las pantallas
            Session.Remove("nro_trans_proforma");
             lbl_facturas.Text = "";
             lbl_nro.Visible = false;
             nro_trans_pro_sele.Text = "";
             LblPorcentajeAvance.Text = "";
             LblAvance.Text = "";
            btn_limpiar.Visible = false;
            LblProgressBar.Width = 0;
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            btn_cancelar.Visible = false;
            btn_proformas.Visible = true;
             BtnIniciar.Visible = false;
            cbx_moneda.Visible = false;
            lbl_moneda.Visible = false;
            btn_verificar.Visible = false;
            //limpiar todas las pantallas
            Session.Remove("nro_trans_proforma");
            lbl_facturas.Text = "";
            lbl_nro.Visible = false;
            nro_trans_pro_sele.Text = "";
            btn_limpiar.Visible = false;
            
        }
    }
}