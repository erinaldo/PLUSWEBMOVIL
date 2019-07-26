using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaDatos.Modelos;
using CapaDatos.Modelos.ModeloHost;
using CapaProceso.Consultas.ConsultaHost;

namespace CapaWeb.WebForms
{
    public partial class FormListaHostMail : System.Web.UI.Page
    {
        public modeloHostmail ModeloHostamail = new modeloHostmail();
        public List<modeloHostmail> ListaModelHost = new List<modeloHostmail>();
        public ConsultaHostmail ConsultaHost = new ConsultaHostmail();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();
        public string ComPwm;
        public string AmUsrLog;
        public string nro_trans = null;
        public string cod_proceso;
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

                CargarGrilla(ComPwm);
            }
        }

        private void CargarGrilla(string ComPwm)
        {

            ListaModelHost = ConsultaHost.BuscarHostmail(ComPwm);
            Grid.DataSource = ListaModelHost;
            Grid.DataBind();
            Grid.Height = 100;
        }
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            // paginar la grilla asegurarse que la obcion que la propiedad AllowPaging sea True.
            Grid.CurrentPageIndex = 0;
            Grid.CurrentPageIndex = e.NewPageIndex;
            CargarGrilla(ComPwm);
        }

        protected void Grid_ItemCommand(object source, DataGridCommandEventArgs e)
        {

            //1 primero creo un objeto Clave/Valor de QueryString 
            QueryString qs = new QueryString();
            //Escoger opcion

            string Id;

            switch (e.CommandName) //ultilizo la variable para la opcion
            {

                case "Editar": //ejecuta el codigo si el usuario ingresa el numero 1
                    Id = Convert.ToString(((Label)e.Item.Cells[1].FindControl("cod_emp")).Text);

                    //2 voy a agregando los valores que deseo
                    qs.Add("TRN", "UDP");
                    qs.Add("Id", Id.ToString());

                    Response.Redirect("FormHostMail.aspx" + Encryption.EncryptQueryString(qs).ToString());
                    break;//termina la ejecucion del programa despues de ejecutar el codigo                   



                case "Eliminar": //ejecuta el codigo si el usuario ingresa el numero 3
                    Id = Convert.ToString(((Label)e.Item.Cells[1].FindControl("cod_emp")).Text);

                    qs.Add("TRN", "DLT");
                    qs.Add("Id", Id.ToString());

                    Response.Redirect("FormHostMail.aspx" + Encryption.EncryptQueryString(qs).ToString());
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

        public QueryString ulrDesencriptada()
        {
            //1- guardo el Querystring encriptado que viene desde el request en mi objeto
            QueryString qs = new QueryString(Request.QueryString);

            ////2- Descencripto y de esta manera obtengo un array Clave/Valor normal
            qs = Encryption.DecryptQueryString(qs);
            return qs;
        }
        protected void NuevoHost_Click(object sender, EventArgs e)
        {
            //1 primero creo un objeto Clave/Valor de QueryString 
            QueryString qs = new QueryString();

            //2 voy a agregando los valores que deseo
            qs.Add("TRN", "INS");
            qs.Add("Id", "");
            Response.Redirect("FormHostMail.aspx" + Encryption.EncryptQueryString(qs).ToString());
        }
    }
}