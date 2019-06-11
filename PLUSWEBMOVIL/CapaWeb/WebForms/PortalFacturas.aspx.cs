using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;

namespace CapaWeb.WebForms
{
    public partial class PortalFacturas : System.Web.UI.Page
    {

     
        modelocabecerafactura cabecerafactura = new modelocabecerafactura();
        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

        List<ModeloDetalleFactura> ModeloDetalleFactura = new List<ModeloDetalleFactura>();
        Consultawmtfacturasdet ConsultaDeta = new Consultawmtfacturasdet();
        ModeloDetalleFactura detallefactura = new ModeloDetalleFactura();

        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        ModeloDetalleFactura consdetalle = new ModeloDetalleFactura();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        public List<JsonRespuestaDE> ListaModelorespuestaDs = null;
        public JsonRespuestaDE ModeloResQr = new JsonRespuestaDE();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();

        public string ComPwm;
        public string AmUsrLog;
        public string nro_trans = null;
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
                        break;

                    case "MTR":
                        Int64 ide = Int64.Parse(qs["Id"].ToString());
                        string nro_trans = ide.ToString();
                        //CargarFormularioRespuestaDS(nro_trans);
                        CargarGrilla(nro_trans);
                        FormularioRes.Visible = false;
                        break;
                }

            }
        }

        private void MostrarCamposFormulario()
        {
            FormularioRes.Visible = true;
        }
       
        private void CargarFormularioRespuestaDS(string nro_trans)
        {

            ListaModelorespuestaDs = consultaRespuestaDS.ConsultaRespuestaQr(nro_trans);
            int count = 0;
            foreach (var item in ListaModelorespuestaDs)
            {
                ModeloResQr = item;
                count++;
                break;
            }

            txt_nro_trans.Text = ModeloResQr.nro_trans;
            txt_linea.Text = Convert.ToString(ModeloResQr.linea);
            txt_id.Text = ModeloResQr.id;
            txt_qrdata.Text = ModeloResQr.qrdata;
            txt_xml.Text = ModeloResQr.xml;
            txt_cufe.Text = ModeloResQr.cufe;
            txt_error.Text = ModeloResQr.error;
            txt_json.Text = ModeloResQr.json;


        }
        private void CargarGrilla(string nro_trans)
        {

            ListaModelorespuestaDs = consultaRespuestaDS.ConsultaRespuestaQr(nro_trans);
            Grid.DataSource = ListaModelorespuestaDs;
            Grid.DataBind();
            Grid.Height = 100;
        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            // paginar la grilla asegurarse que la obcion que la propiedad AllowPaging sea True.
            Grid.CurrentPageIndex = 0;
            Grid.CurrentPageIndex = e.NewPageIndex;
            CargarGrilla(nro_trans);
        }

        protected void Grid_ItemCommand(object source, DataGridCommandEventArgs e)
        {

            //1 primero creo un objeto Clave/Valor de QueryString 
            QueryString qs = new QueryString();
            //Escoger opcion

            int Id;

            switch (e.CommandName) //ultilizo la variable para la opcion
            {

                case "Mostrar": //ejecuta el codigo si el usuario ingresa el numero 3
                    Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                    CargarFormularioRespuestaDS(Id.ToString());
                    MostrarCamposFormulario();
                    Grid.Visible = false;

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

        public QueryString ulrDesencriptada()
        {
            //1- guardo el Querystring encriptado que viene desde el request en mi objeto
            QueryString qs = new QueryString(Request.QueryString);

            ////2- Descencripto y de esta manera obtengo un array Clave/Valor normal
            qs = Encryption.DecryptQueryString(qs);
            return qs;
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
           // Response.Redirect("BuscarFacturas.aspx");
            //ocultar campos
            FormularioRes.Visible = false;
            Grid.Visible = true;

        }
    }
}