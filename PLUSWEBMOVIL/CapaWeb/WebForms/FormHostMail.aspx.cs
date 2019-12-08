using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaDatos.Modelos;
using CapaProceso.Consultas.ConsultaHost;
using CapaDatos.Modelos.ModeloHost;

namespace CapaWeb.WebForms
{
    public partial class FormHostMail : System.Web.UI.Page
    {
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        public modeloHostmail ModeloHostamail = new modeloHostmail();
        public List<modeloHostmail> ListaModelHost = new List<modeloHostmail>();
        public ConsultaHostmail ConsultaHost = new ConsultaHostmail();

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        public string numerador1 = "trans";

        public string numerador = "auditoria";
        public string ComPwm;
        public string AmUsrLog;
        public string usuario;
        public string cod_proceso;
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

                            CargarFormularioHost(empresa);
                            break;

                        case "DLT":

                            string id = (qs["Id"].ToString());
                            usuario = id.ToString();
                            CargarFormularioHost(usuario);
                            BloquearFormularioHost();
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
            ModeloExcepcion.proceso = "FormHostMail.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;
           
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }
        private void BloquearFormularioHost()
        {

            txt_remitente.Enabled = false;
            txt_correo.Enabled = false;
            txt_contrasenia.Enabled = false;
            txt_puerto.Enabled = false;
            txt_smtp.Enabled = false;
            check_aut.Enabled = false;
            check_secure.Enabled = false;
            txt_subject.Enabled = false;
            txt_html.Enabled = false;
            txt_firma.Enabled = false;
            mensaje.Text = "Confirme la eliminacion de datos";

        }
        private void CargarFormularioHost(string empresa)
        {
            try
            {

                lbl_error.Text = "";
                ListaModelHost = ConsultaHost.BuscarHostmail(empresa);
                int count = 0;
                foreach (var item in ListaModelHost)
                {
                    ModeloHostamail = item;
                    count++;
                    break;
                }
                txt_remitente.Text = ModeloHostamail.remitente;
                txt_correo.Text = ModeloHostamail.correo;
                txt_contrasenia.Text = ModeloHostamail.contrasenia;
                txt_puerto.Text = Convert.ToString(ModeloHostamail.puerto);
                txt_smtp.Text = ModeloHostamail.smtp;
                if (ModeloHostamail.autentificacion == 1)
                {
                    check_aut.Checked = true;
                }
                else
                {
                    check_aut.Checked = false;
                }
                if (ModeloHostamail.secure == 1)
                {
                    check_secure.Checked = true;
                }
                else
                {
                    check_secure.Checked = false;
                }

                txt_subject.Text = ModeloHostamail.subject;
                txt_html.Text = ModeloHostamail.html_text;
                txt_firma.Text = ModeloHostamail.firma;
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
                            ListaModelHost = ConsultaHost.BuscarHostmail(ComPwm);
                            int count = 0;
                            foreach (var item in ListaModelHost)
                            {
                                ModeloHostamail = item;
                                count++;
                                break;
                            }
                            if (count > 0)
                            {
                                this.Page.Response.Write("<script language='JavaScript'>window.alert('Host mail ya existe')+ error;</script>");
                            }
                            else
                            {
                                //obtener numero de auditoria
                                /* nrotrans = ConsultaNroTran.ConsultaNumeradores(numerador);
                                 string nro_audit = nrotrans.valor_asignado;
                                 DateTime hoy = DateTime.Today;*/
                                //buscar datos empresa

                                ModeloHostamail.cod_emp = ComPwm;
                                ModeloHostamail.nom_empresa = Modelowmspclogo.nom_emp;
                                ModeloHostamail.remitente = txt_remitente.Text;
                                ModeloHostamail.correo = txt_correo.Text;
                                ModeloHostamail.contrasenia = txt_contrasenia.Text;
                                ModeloHostamail.puerto = Convert.ToInt32(txt_puerto.Text);
                                ModeloHostamail.smtp = txt_smtp.Text;
                                if (check_aut.Checked)
                                {
                                    ModeloHostamail.autentificacion = 1;
                                }
                                else { ModeloHostamail.autentificacion = 0; }
                                if (check_secure.Checked)
                                {
                                    ModeloHostamail.secure = 1;
                                }
                                else { ModeloHostamail.secure = 0; }

                                ModeloHostamail.subject = txt_subject.Text;
                                ModeloHostamail.html_text = txt_html.Text;
                                ModeloHostamail.firma = txt_firma.Text;

                                error = ConsultaHost.InsertarHostmail(ModeloHostamail);

                                if (string.IsNullOrEmpty(error))
                                {

                                }
                                else
                                {

                                    this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                                    Response.Redirect("FormListaHostMail.aspx");
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
                            DateTime hoy1 = DateTime.Today;
                            ModeloHostamail.cod_emp = ComPwm;
                            // ModeloHostamail.nom_empresa = Modelowmspclogo.nom_emp;
                            ModeloHostamail.remitente = txt_remitente.Text;
                            ModeloHostamail.correo = txt_correo.Text;
                            ModeloHostamail.contrasenia = txt_contrasenia.Text;
                            ModeloHostamail.puerto = Convert.ToInt32(txt_puerto.Text);
                            ModeloHostamail.smtp = txt_smtp.Text;
                            if (check_aut.Checked)
                            {
                                ModeloHostamail.autentificacion = 1;
                            }
                            else { ModeloHostamail.autentificacion = 0; }
                            if (check_secure.Checked)
                            {
                                ModeloHostamail.secure = 1;
                            }
                            else { ModeloHostamail.secure = 0; }

                            ModeloHostamail.subject = txt_subject.Text;
                            ModeloHostamail.html_text = txt_html.Text;
                            ModeloHostamail.firma = txt_firma.Text;

                            error = ConsultaHost.ActualizarHostmaila(ModeloHostamail);

                            if (string.IsNullOrEmpty(error))
                            {

                            }
                            else
                            {

                                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                                Response.Redirect("FormListaHostMail.aspx");
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
                            ModeloHostamail.cod_emp = ComPwm;

                            error = ConsultaHost.EliminarHostmail(ModeloHostamail);
                            if (string.IsNullOrEmpty(error))
                            {

                            }
                            else
                            {
                                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "');</script>");
                                Response.Redirect("FormListaHostMail.aspx");
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
                Response.Redirect("FormListaHostMaIl.aspx");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_cancela_Click", ex.ToString());

            }
            
        }
    }
    }
