using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;
using System.IO;

namespace CapaWeb.WebForms
{
    public partial class FormParametros : System.Web.UI.Page
    {
        public modeloSucuralempresa ModelosucursalEmpresa = new modeloSucuralempresa();
        public List<modeloSucuralempresa> ListaModeloSucursalEmpresa = new List<modeloSucuralempresa>();
        public ConsultaSucursalempresa ConsultaSucEmpresa = new ConsultaSucursalempresa();
        public Consultawmsucempresa ConsultaSucursal = new Consultawmsucempresa();

        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();

        Consultawmspcmonedas ConsultaCMonedas = new Consultawmspcmonedas();
        List<modelowmspcmonedas> listaMonedas = null;
        List<modeloDenominacionesMoneda> listaDenominacion = null;
        modeloDenominacionesMoneda ModeloDenominacion = new modeloDenominacionesMoneda();
        modelowmspcmonedas DecimalesMoneda = new modelowmspcmonedas();

        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();

        ConsultaParametrosPWM consultaParametros = new ConsultaParametrosPWM();
        modeloParametrosPWM modeloParametro = new modeloParametrosPWM();
        List<modeloParametrosPWM> ListaParametros = null;

        public string MonB__moneda = "0";
        public string ComPwm;
        public string AmUsrLog;
        public string cod_sucursal = null;
        public string cod_proceso = "";

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

                    QueryString qs = ulrDesencriptada();

                    //Recibir opciones
                    switch (qs["TRN"].Substring(0, 3))
                    {

                        case "INS":
                            try
                            {
                               
                                break;
                            }
                            catch (Exception ex)
                            {
                                GuardarExcepciones("Page_Load, INS", ex.ToString());
                            }
                            break;

                        case "UDP":
                            try
                            {
                                
                                LlenarFormulario();

                                break;
                            }
                            catch (Exception ex)
                            {
                                GuardarExcepciones("Page_Load, UDP", ex.ToString());
                            }
                            break;

                       
                        case "DLT":
                            try
                            {
                               
                                LlenarFormulario();
                               // BloquearFormulario();
                                mensaje.Text = "Confirme datos para la eliminación";
                                break;
                            }
                            catch (Exception ex)
                            {
                                GuardarExcepciones("Page_Load, DLT", ex.ToString());
                            }
                            break;
                    }

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
            ModeloExcepcion.proceso = "FormParametros.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;

            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción."+ metodo+ " Por favor notificar al administrador.";

        }
     
        public void LlenarFormulario()
        {
            try
            {

                lbl_error.Text = "";
                ListaParametros = consultaParametros.ListaParametrosPWM(ComPwm, AmUsrLog);
                foreach (var item in ListaParametros)
                {
                    modeloParametro = item;

                    break;
                }
                  txt_conexion_erp.Text = modeloParametro.conexion_erp;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("LlenarFormulario", ex.ToString());
            }

        }
      
        public QueryString ulrDesencriptada()
        {
            //1- guardo el Querystring encriptado que viene desde el request en mi objeto
            QueryString qs = new QueryString(Request.QueryString);

            ////2- Descencripto y de esta manera obtengo un array Clave/Valor normal
            qs = Encryption.DecryptQueryString(qs);
            return qs;
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
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("RecuperarCokie", ex.ToString());
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                //GUARDAR DENOMINACION
                QueryString qs = ulrDesencriptada();
                string error = "";


                switch (qs["TRN"].Substring(0, 3)) //ultilizo la variable para la opcion
                {
                    case "INS":
                        try
                        {
                            //verificar si es unico
                            ListaParametros = consultaParametros.ListaParametrosPWM(ComPwm, AmUsrLog);
                            if (ListaParametros.Count > 0)
                            {
                                this.Page.Response.Write("<script language='JavaScript'>window.alert('Parámetro ya existe')+ error;</script>");
                            }

                            else
                            {

                               error = consultaParametros.InsertarParametro(ComPwm, AmUsrLog, txt_conexion_erp.Text);

                                if (string.IsNullOrEmpty(error))
                                {

                                }
                                else
                                {

                                    this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                                    Response.Redirect("BuscarParametros.aspx");
                                }
                            }
                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("btn_guardar_Click, INS", ex.ToString());
                        }
                        break;

                    case "UDP":
                        try
                        {
                            error = consultaParametros.ActualizarParametro(ComPwm, AmUsrLog, txt_conexion_erp.Text);

                            if (string.IsNullOrEmpty(error))
                            {

                            }
                            else
                            {

                                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                                Response.Redirect("BuscarParametros.aspx");
                            }
                            break;
                        }

                        catch (Exception ex)
                        {
                            GuardarExcepciones("btn_guardar_Click, UDP", ex.ToString());
                        }
                        break;
                    case "DLT":
                        try
                        {
                            string ide1 = (qs["Id"].ToString());
                            string usuario1 = ide1.ToString();
                            ModeloDenominacion.id = usuario1;

                            error = ConsultaCMonedas.EliminarDenominacion(ModeloDenominacion);
                            if (string.IsNullOrEmpty(error))
                            {

                            }
                            else
                            {
                                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "');</script>");
                                Response.Redirect("BuscarParametros.aspx.aspx");
                            }

                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("btn_guardar_Click, DLT", ex.ToString());
                        }
                        break;

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_guardar_Click", ex.ToString());
            }
        }


        protected void btn_cancela_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                Response.Redirect("BuscarParametros.aspx");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_cancela_Click", ex.ToString());
            }
        }
    }
}