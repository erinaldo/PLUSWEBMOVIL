using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;
using System.Text;
using CapaProceso.RestCliente;

namespace CapaWeb.RestCliente
{
    public partial class consumorest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void generar(object sender, EventArgs e)
        {
            ConsumoRest consumoRest = new ConsumoRest();

            TextBox1.Text = consumoRest.ConsultarRest("04","desarrollo","c","VTA","6385");

        }

    }

    
}