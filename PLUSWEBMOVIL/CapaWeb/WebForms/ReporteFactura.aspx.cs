using CapaWeb.GenerarPDF.FacturaElectronica;
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
        public string Ccf_cod_emp = "04";
        public string Ccf_usuario = "desarrollo";
        public string Ccf_tipo1 = "C";
        public string Ccf_tipo2 = "VTA";
        public string Ccf_nro_trans = "6407";
        protected void Page_Load(object sender, EventArgs e)
        {
            PdfFacturaElectronica pdf = new PdfFacturaElectronica();
            string path = pdf.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);

            Response.ContentType = "application/pdf";
            Response.WriteFile(path);            
            Response.End();

        }
    }
}