using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;

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
        public ConsultausuarioSucursal consultaUsuarioSucursal= new ConsultausuarioSucursal();
        public ConsultawmusuarioSucursal ConsultaUsuxSuc = new ConsultawmusuarioSucursal();
        public modeloUsuariosucursal UsuarioSucursal = new modeloUsuariosucursal();
        public string ComPwm;
        public string AmUsrLog;
        public string usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
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
        private void BloquearFormularioSucursal()
        {

            cbx_sucursal.Enabled = false;
            cbx_usuarios.Enabled = false;
            mensaje.Text = "Confirme la eliminacion de datos";

        }
        private void CargarFormularioSucursal(string usuario)
        {

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
        public QueryString ulrDesencriptada()
        {
            //1- guardo el Querystring encriptado que viene desde el request en mi objeto
            QueryString qs = new QueryString(Request.QueryString);

            ////2- Descencripto y de esta manera obtengo un array Clave/Valor normal
            qs = Encryption.DecryptQueryString(qs);
            return qs;
        }
        public void cargarListaDesplegables()
        {
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
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            QueryString qs = ulrDesencriptada();
            string error = "";
         

            switch (qs["TRN"].Substring(0, 3)) //ultilizo la variable para la opcion
            {
                case "INS":
                    
                    DateTime hoy = DateTime.Today;
                    ModelousuarioSucursal.cod_emp = ComPwm;
                    ModelousuarioSucursal.cod_sucursal = cbx_sucursal.SelectedValue;
                    ModelousuarioSucursal.usuario = cbx_usuarios.SelectedValue;
                    ModelousuarioSucursal.fecha_mod = hoy;
                    ModelousuarioSucursal.usuario_mod = AmUsrLog;
                    error = consultaUsuarioSucursal.InsertarUsuarioSucursal(ModelousuarioSucursal);

                    if (string.IsNullOrEmpty(error))
                    {

                    }
                    else
                    {

                        this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                        Response.Redirect("FormListaUsuarioSucursal.aspx");
                    }
                    break;
                case "UPD":

                    DateTime hoy1 = DateTime.Today;
                    ModelousuarioSucursal.cod_emp = ComPwm;
                    ModelousuarioSucursal.cod_sucursal = cbx_sucursal.SelectedValue;
                    ModelousuarioSucursal.usuario = cbx_usuarios.SelectedValue;
                    ModelousuarioSucursal.fecha_mod = hoy1;
                    ModelousuarioSucursal.usuario_mod = AmUsrLog;
                    error = consultaUsuarioSucursal.InsertarUsuarioSucursal(ModelousuarioSucursal);

                    if (string.IsNullOrEmpty(error))
                    {

                    }
                    else
                    {

                        this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                        Response.Redirect("FormListaUsuarioSucursal.aspx");
                    }
                    break;
                case "DLT":
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
        }

        protected void btn_cancela_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormListaUsuarioSucursal.aspx");
        }
    }
}