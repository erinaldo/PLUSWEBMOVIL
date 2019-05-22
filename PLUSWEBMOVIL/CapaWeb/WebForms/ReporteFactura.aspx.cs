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
        protected void Page_Load(object sender, EventArgs e)
        {
            PdfFacturaElectronica pdf = new PdfFacturaElectronica();
            string path = pdf.generarPdf();

            Response.ContentType = "application/pdf";
            Response.WriteFile(path);            
            Response.End();

        }
    }
}