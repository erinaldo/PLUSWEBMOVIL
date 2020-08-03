using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Consultas;
using CapaWeb.Urlencriptacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaWeb.WebForms
{
    public partial class FormConceptoFiscal : System.Web.UI.Page
    {
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();


        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();

        ModeloConcFiscal modeloFiscal = new ModeloConcFiscal();
        List<ModeloConcFiscal> ListaFiscal = new List<ModeloConcFiscal>();
        Articulos concepto = new Articulos();
        public string numerador1 = "trans";

        public string numerador = "auditoria";
        public string ComPwm;
        public string AmUsrLog; 
        public string usuario;
        public string cod_proceso = "RMACONFIS";
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

                            break;

                        case "UDP":
                            string ide = (qs["Id"].ToString());
                            string empresa = ide.ToString();
                            txt_codigo.Enabled = false;
                            CargarFormulario(ide);
                            break;

                        case "DLT":

                            string id = (qs["Id"].ToString());
                            usuario = id.ToString();
                            CargarFormulario(usuario);
                            BloquearFormulario();
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
            ModeloExcepcion.proceso = "FormConceptoFiscal.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;

            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }
        private void BloquearFormulario()
        {

            txt_codigo.Enabled = false;
            txt_nombre.Enabled = false;
            cbx_signo.Enabled = false;
            mensaje.Text = "Confirme la eliminacion de datos";

        }
        private void CargarFormulario(string codigo)
        {
            try
            {

                lbl_error.Text = "";
                modeloFiscal = concepto.BuscarConceptoFiscal(AmUsrLog, ComPwm, codigo);
                txt_codigo.Text = modeloFiscal.cod_concepto_fis;
                txt_nombre.Text = modeloFiscal.nom_concepto_fis;
                cbx_signo.SelectedValue = modeloFiscal.signo;
               
            }
            catch (Exception ex)
            {
                GuardarExcepciones("CargarFormularioHost", ex.ToString());

            }

        }
        public QueryString ulrDesencriptada()
        {
            try
            {
                lbl_error.Text = "";

                //1- guardo el Querystring encriptado que viene desde el request en mi objeto
                QueryString qs = new QueryString(Request.QueryString);

                ////2- Descencripto y de esta manera obtengo un array Clave/Valor normal
                qs = Encryption.DecryptQueryString(qs);
                return qs;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("ulrDesencriptada", ex.ToString());
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

                //Guardar datos de host mail
                QueryString qs = ulrDesencriptada();
                string error = "";


                switch (qs["TRN"].Substring(0, 3)) //ultilizo la variable para la opcion
                {
                    case "INS":
                        try
                        {

                            //verificar si es unico
                            modeloFiscal = concepto.BuscarConceptoFiscal(AmUsrLog, ComPwm, txt_codigo.Text);


                            if (modeloFiscal.cod_concepto_fis != null)
                            {
                                this.Page.Response.Write("<script language='JavaScript'>window.alert('Concepto Fiscal ya existe')+ error;</script>");
                            }
                            else
                            {
                                if(txt_codigo.Text =="0")
                                {
                                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Concepto Fiscal no valido')+ error;</script>");
                                }
                                else
                                {
                                    //obtener numero de auditoria
                                    nrotrans = ConsultaNroTran.ConsultaNumeradores(numerador);
                                    string nro_audit = nrotrans.valor_asignado;
                                    DateTime hoy = DateTime.Today;
                                    //buscar datos empresa


                                    error = concepto.InsertConceptoFiscal(AmUsrLog, ComPwm, txt_codigo.Text, txt_nombre.Text, cbx_signo.SelectedValue, DateTime.Now, nro_audit, "RMACONFIS");

                                    if (string.IsNullOrEmpty(error))
                                    {

                                    }
                                    else
                                    {

                                        this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                                        Response.Redirect("BuscarConceptoFiscal.aspx");
                                    }
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
                            string ide = (qs["Id"].ToString());
                            string usuario = ide.ToString();

                            error = concepto.ActualizarConceptoFiscal(AmUsrLog, ComPwm, txt_codigo.Text, txt_nombre.Text, cbx_signo.SelectedValue, DateTime.Now);

                            if (string.IsNullOrEmpty(error))
                            {

                            }
                            else
                            {

                                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                                Response.Redirect("BuscarConceptoFiscal.aspx");
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


                            error = concepto.EliminarConceptoFiscal(AmUsrLog, ComPwm, txt_codigo.Text);
                            if (string.IsNullOrEmpty(error))
                            {

                            }
                            else
                            {
                                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "');</script>");
                                Response.Redirect("BuscarConceptoFiscal.aspx");
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
                Response.Redirect("BuscarConceptoFiscal.aspx");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_cancela_Click", ex.ToString());

            }

        }
    }
}