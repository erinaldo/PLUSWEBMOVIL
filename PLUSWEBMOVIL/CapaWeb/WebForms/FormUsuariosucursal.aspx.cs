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
    public partial class FormUsuariosucursal : System.Web.UI.Page
    {
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        public Consultawmsucempresa consultaSucursalEmpresa = new Consultawmsucempresa();
        public modeloSucuralempresa ModeloSucursalEmpresa = new modeloSucuralempresa();
        public List<modeloSucuralempresa> ListaSucursalEmpresa = null;


        public ConsultaUsuarioEmpresa consultaUsuarioEmp = new ConsultaUsuarioEmpresa();
        public modeloUsuarioxempresa ModeloUsuarioempresa = new modeloUsuarioxempresa();
            public List<modeloUsuarioxempresa> ListausuarioEmpresa = null;


        public modeloUsuariosucursal ModelousuarioSucursal = new modeloUsuariosucursal();
        public List<modeloUsuariosucursal> ListaModeloUsuarioSucursal = new List<modeloUsuariosucursal>();
        public ConsultawmusuarioSucursal ConsultaUsuxSuc = new ConsultawmusuarioSucursal();
        public ConsultausuarioSucursal consultaUsuarioSucursal= new ConsultausuarioSucursal();
        
        public modeloUsuariosucursal UsuarioSucursal = new modeloUsuariosucursal();

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        public string numerador1 = "trans";

        public string numerador = "auditoria";
        public string ComPwm;
        public string AmUsrLog;
        public string usuario;
        public string cod_proceso ;
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
                            cargarListaDesplegables();
                            break;

                        case "UDP":
                            string ide = (qs["Id"].ToString());
                            string usuario = ide.ToString();
                            cargarListaDesplegables();
                            CargarFormularioSucursal(usuario);
                            break;

                        case "DLT":
                            cargarListaDesplegables();
                            string id = (qs["Id"].ToString());
                            usuario = id.ToString();
                            CargarFormularioSucursal(usuario);
                            BloquearFormularioSucursal();
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
            ModeloExcepcion.proceso = "FormUsuariosucursal.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Today;
            ModeloExcepcion.usuario_mod = AmUsrLog;
            
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }
        private void BloquearFormularioSucursal()
        {

            cbx_sucursal.Enabled = false;
            cbx_usuarios.Enabled = false;
            mensaje.Text = "Confirme la eliminacion de datos";

        }
        private void CargarFormularioSucursal(string usuario)
        {
            try
            {
                lbl_error.Text = "";

                ListaModeloUsuarioSucursal = ConsultaUsuxSuc.ConsultaUsuarioSucursal(ComPwm, usuario);
                int count = 0;
                foreach (var item in ListaModeloUsuarioSucursal)
                {
                    ModelousuarioSucursal = item;
                    count++;
                    break;
                }
                cbx_sucursal.SelectedValue = ModelousuarioSucursal.cod_sucursal;
                cbx_usuarios.SelectedValue = ModelousuarioSucursal.usuario;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("CargarFormularioSucursal", ex.ToString());

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
        public void cargarListaDesplegables()
        {
            try
            {
                lbl_error.Text = "";

                //LIsta sucursales x empresa
                ListaSucursalEmpresa = consultaSucursalEmpresa.ConsultaSucursalEmpresa(ComPwm);
                cbx_sucursal.DataSource = ListaSucursalEmpresa;
                cbx_sucursal.DataTextField = "sucursales";
                cbx_sucursal.DataValueField = "cod_sucursal";
                cbx_sucursal.DataBind();

                //LIsta usuario x empresa
                ListausuarioEmpresa = consultaUsuarioEmp.ConsultaUsuariosEmpresa(ComPwm);
                cbx_usuarios.DataSource = ListausuarioEmpresa;
                cbx_usuarios.DataTextField = "usuario";
                cbx_usuarios.DataValueField = "usuario";
                cbx_usuarios.DataBind();
            }
            catch (Exception ex)
            {
                GuardarExcepciones("cargarListaDesplegables", ex.ToString());

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

                QueryString qs = ulrDesencriptada();
                string error = "";


                switch (qs["TRN"].Substring(0, 3)) //ultilizo la variable para la opcion
                {
                    case "INS":
                        try
                        {
                            //verificar si es unico
                            ListaModeloUsuarioSucursal = ConsultaUsuxSuc.ConsultaUsuarioSucursal(ComPwm, cbx_usuarios.SelectedValue);
                            int count = 0;
                            foreach (var item in ListaModeloUsuarioSucursal)
                            {
                                ModelousuarioSucursal = item;
                                count++;
                                break;
                            }
                            if (count > 0)
                            {
                                this.Page.Response.Write("<script language='JavaScript'>window.alert('Usuario ya existe')+ error;</script>");
                            }
                            else
                            {
                                //obtener numero de auditoria
                                nrotrans = ConsultaNroTran.ConsultaNumeradores(numerador);
                                string nro_audit = nrotrans.valor_asignado;
                                DateTime hoy = DateTime.Today;
                                ModelousuarioSucursal.cod_emp = ComPwm;
                                ModelousuarioSucursal.cod_sucursal = cbx_sucursal.SelectedValue.Trim();
                                ModelousuarioSucursal.usuario = cbx_usuarios.SelectedValue.Trim();
                                ModelousuarioSucursal.fecha_mod = hoy;
                                ModelousuarioSucursal.usuario_mod = AmUsrLog;
                                ModelousuarioSucursal.nro_audit = nro_audit;
                                ModelousuarioSucursal.cod_proc_aud = "AUSRXSUC";
                                error = consultaUsuarioSucursal.InsertarUsuarioSucursal(ModelousuarioSucursal);

                                if (string.IsNullOrEmpty(error))
                                {

                                }
                                else
                                {

                                    this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                                    Response.Redirect("FormListaUsuarioSucursal.aspx");
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
                            ModelousuarioSucursal.cod_emp = ComPwm;
                            ModelousuarioSucursal.cod_sucursal = cbx_sucursal.SelectedValue.Trim();
                            ModelousuarioSucursal.usuario = cbx_usuarios.SelectedValue.Trim();
                            ModelousuarioSucursal.fecha_mod = hoy1;
                            ModelousuarioSucursal.usuario_mod = AmUsrLog;
                            ModelousuarioSucursal.usu_ante = usuario;
                            error = consultaUsuarioSucursal.ActualizarUsuarioSucursal(ModelousuarioSucursal);

                            if (string.IsNullOrEmpty(error))
                            {

                            }
                            else
                            {

                                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                                Response.Redirect("FormListaUsuarioSucursal.aspx");
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
                            ModelousuarioSucursal.cod_emp = ComPwm;
                            ModelousuarioSucursal.cod_sucursal = cbx_sucursal.SelectedValue;
                            ModelousuarioSucursal.usuario = cbx_usuarios.SelectedValue;
                            error = consultaUsuarioSucursal.EliminarrUsuarioSucursal(ModelousuarioSucursal);
                            if (string.IsNullOrEmpty(error))
                            {

                            }
                            else
                            {
                                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "');</script>");
                                Response.Redirect("FormListaUsuarioSucursal.aspx");
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

                Response.Redirect("FormListaUsuarioSucursal.aspx");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_cancela_Click", ex.ToString());

            }
        }
    }
}