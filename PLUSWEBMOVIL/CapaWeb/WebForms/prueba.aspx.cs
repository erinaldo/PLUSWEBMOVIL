using System;

using CapaWeb.GenerarPDF.FacturaElectronica;
using System.IO;

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
    }
}