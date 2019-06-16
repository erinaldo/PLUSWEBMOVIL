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
    public partial class ReenviarFacturaJson : System.Web.UI.Page
    {

      
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        public CabezeraFactura ActualizarEstadoFact = new CabezeraFactura();
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
            ConsumoRest consumoRest = new ConsumoRest();
            string respuesta = "";
            respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", "VTA", lbl_nro_trans.Text);
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
            Response.Redirect("BuscarFacturas.aspx");
        }

        protected void btn_reenviarpdf_Click(object sender, EventArgs e)
        {
            ConsumoRest consumoRest = new ConsumoRest();
            string respuesta = "";
            respuesta = consumoRest.enviarPDF(ComPwm, AmUsrLog, "C", "VTA", lbl_nro_trans.Text);
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