using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaProceso.Consultas;
using CapaProceso.Modelos;

namespace CapaWeb.WebForms
{
    public partial class BuscarArticulo : System.Web.UI.Page
    {
        Cosnsultawmspcarticulos ConsultaArticulo = new Cosnsultawmspcarticulos();
        List<modelowmspcarticulos> listaArticulos = null;
        public string ArtB__usuario = "desarrollo";
        public string ArtB__cod_emp = "04";
        public string ArtB__articulo = " ";
        public string ArtB__tipo = "0";
        public string ArtB__compras = "0";
        public string ArtB__ventas = "S";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();





                if (Request.Cookies["ComPwm"] != null)
                {
                    string ComPwm = Request.Cookies["ComPwm"].Value;

                }
            }
        }

        public void CargarGrilla()
        {
            listaArticulos = ConsultaArticulo.ConsultaArticulos(ArtB__usuario, ArtB__cod_emp, ArtB__articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);
            Grid.DataSource = listaArticulos;
            Grid.DataBind();
            Grid.Height = 100;

        }
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            // paginar la grilla asegurarse que la obcion que la propiedad AllowPaging sea True.
            Grid.CurrentPageIndex = 0;
            Grid.CurrentPageIndex = e.NewPageIndex;
            CargarGrilla();
        }
        protected void TxtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            //listar todos los articulos
            string ArtB_articulo = TxtBuscarProducto.Text;

            listaArticulos = ConsultaArticulo.ConsultaArticulos(ArtB__usuario, ArtB__cod_emp, ArtB__articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);

            Grid.DataSource = listaArticulos;
            Grid.DataBind();
            Grid.Height = 100;
        }
    }
}