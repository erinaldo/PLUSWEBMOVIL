using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;

namespace CapaWeb.WebForms
{
    public partial class ReenviarNotaDebitoJson : System.Web.UI.Page
    {
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        public CabezeraFactura ActualizarEstadoFact = new CabezeraFactura();


        modelocabecerafactura cabecerafactura = new modelocabecerafactura();
        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

        List<ModeloDetalleFactura> ModeloDetalleFactura = new List<ModeloDetalleFactura>();
        Consultawmtfacturasdet ConsultaDeta = new Consultawmtfacturasdet();
        ModeloDetalleFactura detallefactura = new ModeloDetalleFactura();

        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        ModeloDetalleFactura consdetalle = new ModeloDetalleFactura();
        List<modelowmtfacturascab> listaConsCab = null;
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
                Int64 ide = Int64.Parse(qs["Id"].ToString());
                lbl_nro_trans.Text = ide.ToString();


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

        public modelowmtfacturascab buscarTipoFac(string nro_trans)
        {

            listaConsCab = ConsultaCabe.ConsultaTipoFactura(nro_trans);
            int count = 0;
            conscabcera = null;
            foreach (modelowmtfacturascab item in listaConsCab)
            {
                count++;
                conscabcera = item;

            }
            return conscabcera;
        }
        public QueryString ulrDesencriptada()
        {
            //1- guardo el Querystring encriptado que viene desde el request en mi objeto
            QueryString qs = new QueryString(Request.QueryString);

            ////2- Descencripto y de esta manera obtengo un array Clave/Valor normal
            qs = Encryption.DecryptQueryString(qs);
            return qs;
        }

        protected void btn_reenviar_Click(object sender, EventArgs e)
        {
            conscabcera = null;
            conscabcera = buscarTipoFac(lbl_nro_trans.Text);
            string Tipo_fac = null;
            if (conscabcera.tipo_nce.ToString() == "VTAE")
            {
                Tipo_fac = "VTAE";
            }
            else
            {

                Tipo_fac = "POSE";
            }
            ConsumoRest consumoRest = new ConsumoRest();
            string respuesta = "";
            respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", Tipo_fac, lbl_nro_trans.Text);
            if (respuesta == "")
            {
                mensaje.Text = "Su factura fue enviada exitosamente";
                btn_reenviar.Enabled = false;
                ActualizarEstadoFact.ActualizarEstadoFactura(lbl_nro_trans.Text, "F");


            }
            else
            {
                mensaje.Text = respuesta;

            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            conscabcera = null;
            conscabcera = buscarTipoFac(lbl_nro_trans.Text);

            if (conscabcera.tipo_nce.ToString() == "VTAE")
            {
                Response.Redirect("BuscarFacturas.aspx");
            }
            else
            {

                Response.Redirect("BuscarFacturaPOS.aspx");
            }

        }

        protected void btn_reenviarpdf_Click(object sender, EventArgs e)
        {
            conscabcera = null;
            conscabcera = buscarTipoFac(lbl_nro_trans.Text);
            string Tipo_fac = null;
            if (conscabcera.tipo_nce.ToString() == "VTAE")
            {
                Tipo_fac = "VTAE";
            }
            else
            {

                Tipo_fac = "POSE";
            }
            ConsumoRest consumoRest = new ConsumoRest();
            string respuesta = "";
            respuesta = consumoRest.enviarPDF(ComPwm, AmUsrLog, "C", Tipo_fac, lbl_nro_trans.Text);
            if (respuesta == "")
            {
                mensaje.Text = "Su factura fue enviada exitosamente"; ;
                btn_reenviar.Enabled = false;
                ActualizarEstadoFact.ActualizarEstadoFactura(lbl_nro_trans.Text, "F");


            }
            else
            {
                mensaje.Text = respuesta;

            }
        }
    }
}