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
    public partial class FormSucursalempresa : System.Web.UI.Page
    {
        public modeloSucuralempresa ModelosucursalEmpresa = new modeloSucuralempresa();
        public List<modeloSucuralempresa> ListaModeloSucursalEmpresa = new List<modeloSucuralempresa>();
        public ConsultaSucursalempresa ConsultaSucEmpresa = new ConsultaSucursalempresa();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();
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
            ModelosucursalEmpresa.cod_emp = ComPwm;
            ModelosucursalEmpresa.cod_sucursal = txt_cod_sucursal.Text;
            ModelosucursalEmpresa.nom_sucursal = txt_nom_sucursal.Text;
            ModelosucursalEmpresa.dir_sucursal = txt_dir_sucursal.Text;
            ModelosucursalEmpresa.email_sucursal = txt_email_sucursal.Text;
            ModelosucursalEmpresa.tel_sucursal = txt_tel_sucursal.Text;
            ModelosucursalEmpresa.fecha_mod = hoy;
            ModelosucursalEmpresa.usuario_mod = AmUsrLog;
           error = ConsultaSucEmpresa.InsertarSucursalEmpresa(ModelosucursalEmpresa);

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
            Response.Redirect("BuscarFacturas.aspx");
        }
    }
}