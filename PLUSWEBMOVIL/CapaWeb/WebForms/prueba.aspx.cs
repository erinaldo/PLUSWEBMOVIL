using System;

using CapaWeb.GenerarPDF.FacturaElectronica;
using System.IO;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing;
using System.Drawing.Imaging;

namespace CapaWeb.WebForms
{
    public partial class prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            


        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string url = "ReporteFactura.aspx";
            Response.Write("<script>window.open('"+ url + "')</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}