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
        public string ComPwm;
        public string AmUsrLog;
        public string cod_sucursal = null;
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

                        break;

                    case "UDP":
                       string ide = (qs["Id"].ToString());
                        string cod_sucursal = ide.ToString();
                        CargarFormularioSucursal(cod_sucursal);
                        break;

                    case "DLT":
                        string id = (qs["Id"].ToString());
                         cod_sucursal = id.ToString();
                        CargarFormularioSucursal(cod_sucursal);
                        break;
                }

            }
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
                        DateTime hoy = DateTime.Today;
                        ModelosucursalEmpresa.cod_emp = ComPwm;
                        ModelosucursalEmpresa.cod_sucursal = txt_cod_sucursal.Text;
                        ModelosucursalEmpresa.nom_sucursal = txt_nom_sucursal.Text;
                        ModelosucursalEmpresa.dir_sucursal = txt_dir_sucursal.Text;
                        ModelosucursalEmpresa.email_sucursal = txt_email_sucursal.Text;
                        ModelosucursalEmpresa.tel_sucursal = txt_tel_sucursal.Text;
                        ModelosucursalEmpresa.fecha_mod = hoy;
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
                    }
                    break;
                case "UPD":

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