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

namespace CapaWeb.WebForms
{
    public partial class FormSucursalempresa : System.Web.UI.Page
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
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        public string numerador1 = "trans";

        public string ComPwm;
        public string AmUsrLog;
        public string cod_sucursal = null;
        public string cod_proceso = "AEMPSUC";
        public string numerador = "auditoria";
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
                            try
                            {
                                string ide = (qs["Id"].ToString());
                                string cod_sucursal = ide.ToString();
                                CargarFormularioSucursal(cod_sucursal);
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
                                string id = (qs["Id"].ToString());
                                cod_sucursal = id.ToString();
                                CargarFormularioSucursal(cod_sucursal);
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
            ModeloExcepcion.proceso = "FormSucursalempresa.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Today;
            ModeloExcepcion.usuario_mod = AmUsrLog;
           
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }
        private void CargarFormularioSucursal(string cod_sucursal)
        {

            ListaModeloSucursalEmpresa  = ConsultaSucursal.ConsultaSucursalUnico(ComPwm, cod_sucursal);
            int count = 0;
            foreach (var item in ListaModeloSucursalEmpresa)
            {
                ModelosucursalEmpresa = item;
                count++;
                break;
            }
            txt_cod_sucursal.Text = ModelosucursalEmpresa.cod_sucursal;
            txt_nom_sucursal.Text = ModelosucursalEmpresa.nom_sucursal;
            txt_dir_sucursal.Text = ModelosucursalEmpresa.dir_sucursal;
            txt_tel_sucursal.Text = ModelosucursalEmpresa.tel_sucursal;
            txt_email_sucursal.Text = ModelosucursalEmpresa.email_sucursal;
            txt_cod_sucursal.Enabled = false;
            
          
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
        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            QueryString qs = ulrDesencriptada();
            string error = "";
            

            switch (qs["TRN"].Substring(0, 3)) //ultilizo la variable para la opcion
            {
                case "INS":
                    ListaModeloSucursalEmpresa = ConsultaSucursal.UnicoSucursalEmpresa(ComPwm, txt_cod_sucursal.Text);
                    int count = 0;
                    foreach (var item in ListaModeloSucursalEmpresa)
                    {
                        ModelosucursalEmpresa = item;
                        count++;
                        break;
                    }
                    if (count > 0)
                    {
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('Sucursal ya existe')+ error;</script>");
                    }
                    else
                    {
                        //obtener numero de transaccion
                        nrotrans = ConsultaNroTran.ConsultaNumeradores(numerador);
                        string nro_audit = nrotrans.valor_asignado;
                        DateTime hoy = DateTime.Today;
                        ModelosucursalEmpresa.cod_emp = ComPwm;
                        ModelosucursalEmpresa.cod_sucursal = txt_cod_sucursal.Text;
                        ModelosucursalEmpresa.nom_sucursal = txt_nom_sucursal.Text;
                        ModelosucursalEmpresa.dir_sucursal = txt_dir_sucursal.Text;
                        ModelosucursalEmpresa.email_sucursal = txt_email_sucursal.Text;
                        ModelosucursalEmpresa.tel_sucursal = txt_tel_sucursal.Text;
                        ModelosucursalEmpresa.fecha_mod = hoy;
                        ModelosucursalEmpresa.usuario_mod = AmUsrLog;
                        ModelosucursalEmpresa.nro_audit = nro_audit;
                        ModelosucursalEmpresa.cod_proc_aud = "AEMPSUC";
                        error = ConsultaSucEmpresa.InsertarSucursalEmpresa(ModelosucursalEmpresa);

                        if (string.IsNullOrEmpty(error))
                        {

                        }
                        else
                        {

                            this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                            Response.Redirect("FormListaSucursalEmpresa.aspx");
                        }
                    }
                    break;
                case "UDP":

                    DateTime hoy1 = DateTime.Today;
                    ModelosucursalEmpresa.cod_emp = ComPwm;
                    ModelosucursalEmpresa.cod_sucursal = txt_cod_sucursal.Text;
                    ModelosucursalEmpresa.nom_sucursal = txt_nom_sucursal.Text;
                    ModelosucursalEmpresa.dir_sucursal = txt_dir_sucursal.Text;
                    ModelosucursalEmpresa.email_sucursal = txt_email_sucursal.Text;
                    ModelosucursalEmpresa.tel_sucursal = txt_tel_sucursal.Text;
                    ModelosucursalEmpresa.fecha_mod = hoy1;
                    ModelosucursalEmpresa.usuario_mod = AmUsrLog;
                    error = ConsultaSucEmpresa.ActualizarSucursalEmpresa(ModelosucursalEmpresa);

                    if (string.IsNullOrEmpty(error))
                    {

                    }
                    else
                    {

                        this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                        Response.Redirect("FormListaSucursalEmpresa.aspx");
                    }
                    break;
                case "DLT":

                    ModelosucursalEmpresa.cod_sucursal = txt_cod_sucursal.Text;
                     error = ConsultaSucEmpresa.EliminarSucursalEmpresa(ModelosucursalEmpresa);

                    if (string.IsNullOrEmpty(error))
                    {

                    }
                    else
                    {

                        this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                        Response.Redirect("FormListaSucursalEmpresa.aspx");
                    }
                    break;
            }
        }

        protected void btn_cancela_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormListaSucursalEmpresa.aspx");
        }
    }
}