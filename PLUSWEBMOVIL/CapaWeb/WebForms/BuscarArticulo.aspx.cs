using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using CapaDatos.Modelos;

namespace CapaWeb.WebForms
{
    public partial class BuscarArticulo : System.Web.UI.Page
    {
        Cosnsultawmspcarticulos ConsultaArticulo = new Cosnsultawmspcarticulos();
       public List<modelowmspcarticulos> listaArticulos = null;
        modelowmspcarticulos articulo = new modelowmspcarticulos();
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


                Session.Remove("articulo");



                if (Request.Cookies["ComPwm"] != null)
                {
                    string ComPwm = Request.Cookies["ComPwm"].Value;

                }
                if (Session["listaProducto"] != null)
                {
                    // recupera la variable de secion con el objeto persona   
                    listaArticulos = (List<modelowmspcarticulos>)Session["listaProducto"];
                    Session["listaArticulos"] = listaArticulos;
                    gvProducto.DataSource = listaArticulos;
                    gvProducto.DataBind();

                }
            }
        }

       
        protected void TxtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            CargarGrilla(TxtBuscarProducto.Text);
        }


        public void CargarGrilla(string ArtB__articulo)
        {
            listaArticulos = ConsultaArticulo.ConsultaArticulos(ArtB__usuario, ArtB__cod_emp, ArtB__articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);
            Session["listaArticulos"] = listaArticulos;

            /*gv_Producto.DataSource = listaArticulos;
            gv_Producto.DataBind();*/
            gvProducto.DataSource = listaArticulos;
            gvProducto.DataBind();


        }
     /*   protected void gv_Producto_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            // paginar la grilla asegurarse que la obcion que la propiedad AllowPaging sea True.
            gv_Producto.CurrentPageIndex = 0;
            gv_Producto.CurrentPageIndex = e.NewPageIndex;
           
            CargarGrilla(TxtBuscarProducto.Text);
        }
        protected void gv_Producto_ItemCommand(object source, DataGridCommandEventArgs e)
        {


            switch (e.CommandName) //ultilizo la variable para la opcion            
            {
                case "Select":// lleno las cajas de texto con los datos para la edicon del item seleccionado
                    
                    string cod_articulo = ((Label)e.Item.Cells[1].FindControl("cod_articulo")).Text; 

                    listaArticulos = (List<modelowmspcarticulos>)Session["listaArticulos"];
                    foreach (var item in listaArticulos)
                    {
                        if (item.cod_articulo == cod_articulo)
                        {
                            articulo = item;

                            break;
                        }

                    }
                    // Crea la variable de sessión
                    Session["articulo"] = articulo;

                    // Refrescamos el formuario padre
                    ClientScript.RegisterClientScriptBlock(GetType(), "Refresca", "window.opener.location.reload(); window.close();", true);


                    break;

            }

            }
            */

        
        protected void gvProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProducto.PageIndex = 0;
            gvProducto.PageIndex = e.NewPageIndex;

            CargarGrilla(TxtBuscarProducto.Text);
        }
         protected void gvProducto_SelectedIndexChanged(object sender, EventArgs e)
         {
             //
             // Se obtiene la fila seleccionada del gridview
             //
             GridViewRow row = gvProducto.SelectedRow;

             //
             // Obtengo el id de la entidad que se esta editando
             // en este caso de la entidad Person
             //
             string cod_articulo = Convert.ToString(gvProducto.DataKeys[row.RowIndex].Value);

             listaArticulos = (List<modelowmspcarticulos>)Session["listaArticulos"];
             foreach (var item in listaArticulos)
             {
                 if (item.cod_articulo == cod_articulo)
                 {
                   articulo = item;

                     break;
                 }

             }
             // Crea la variable de sessión
             Session["articulo"] = articulo;

             // Refrescamos el formuario padre
             ClientScript.RegisterClientScriptBlock(GetType(), "Refresca", "window.opener.location.reload(); window.close();", true);


         }
    }
}