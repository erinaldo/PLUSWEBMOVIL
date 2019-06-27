using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaDatos.Modelos;

namespace CapaWeb.WebForms
{
    public partial class FormRespuestaJson : System.Web.UI.Page
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
                        Int64 lin = Int64.Parse(qs["linea"].ToString());
                        
                        string nro_trans = ide.ToString();
                        mensaje.Text = nro_trans;
                        string linea = lin.ToString();
                        CargarFormularioRespuestaDS(nro_trans, linea);
                       
                        break;
                }

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

        private void CargarFormularioRespuestaDS(string nro_trans, string linea)
        {

            ListaModelorespuestaDs = consultaRespuestaDS.RespuestaLineaQr(nro_trans, linea);
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
            txt_result.Text = ModeloResQr.result;
            FormularioRes.Visible = true;

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
            

            QueryString qs = new QueryString();

            //2 voy a agregando los valores que deseo
            qs.Add("TRN", "MTR");
            qs.Add("Id", mensaje.Text);
            Response.Redirect("PortalFacturas.aspx" + Encryption.EncryptQueryString(qs).ToString());
        }
    }
}