using CapaWeb.GenerarPDF.FacturaElectronica;
using CapaWeb.Urlencriptacion;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaWeb.WebForms
{
    public partial class ReporteFactura : System.Web.UI.Page
    {
        public string ComPwm;
        public string AmUsrLog;       
        public string Ccf_tipo1 = "C";
        public string Ccf_tipo2 = "VTA";
        public string Ccf_nro_trans = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            RecuperarCokie();

            QueryString qs = ulrDesencriptada();
            Int64 id = Int64.Parse(qs["Id"].ToString());
            Ccf_nro_trans = id.ToString();

            PdfFacturaElectronica pdf = new PdfFacturaElectronica();
            string path = pdf.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);

            Response.ContentType = "application/pdf";
            Response.WriteFile(path);            
            Response.End();

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

            if (Request.Cookies["ComPwm"] != null)
            {
                AmUsrLog = Request.Cookies["AmUsrLog"].Value;

            }
        }
    }
}