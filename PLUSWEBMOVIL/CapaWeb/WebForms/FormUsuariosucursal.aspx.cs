using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        public string ComPwm;
        public string AmUsrLog;
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
                cargarListaDesplegables();
            }

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
            string error = "";
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
                Response.Redirect("BuscarFacturas.aspx");
            }
        }

        protected void btn_cancela_Click(object sender, EventArgs e)
        {

        }
    }
}