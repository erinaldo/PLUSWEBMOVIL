using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaWeb.WebForms
{
    public partial class FPagoPos : System.Web.UI.Page
    {
        ConsultafpagoPos ConsultafpagoPos = new ConsultafpagoPos();
        List<modelowmmfpagoPOS> lista = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();
            }
        }
        public void CargarGrilla()
        {
            lista = ConsultafpagoPos.ConsultaFormaPago();
            Grid.DataSource = lista;
            Grid.DataBind();
            Grid.Height = 100;
        }
    }
}
