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
    public partial class FormDetalleImpuestos : System.Web.UI.Page
    {
        public List<modelowmspcfacturasWMimpuRest> ListaModeloimpuesto = null;
        public modelowmspcfacturasWMimpuRest ModeloImpuesto = new modelowmspcfacturasWMimpuRest();
        public ConsultawmspcfacturasWMimpuRest consultaImpuesto = new ConsultawmspcfacturasWMimpuRest();

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                Session.Remove("articulo");



                if (Request.Cookies["ComPwm"] != null)
                {
                    string ComPwm = Request.Cookies["ComPwm"].Value;

                }
                if (Session["listaImpuestos"] != null)
                {
                    // recupera la variable de secion con el objeto persona   
                    ListaModeloimpuesto = (List<modelowmspcfacturasWMimpuRest>)Session["listaImpuestos"];
                    Session["ListaModeloimpuesto"] = ListaModeloimpuesto;
                    gvProducto.DataSource = ListaModeloimpuesto;
                    gvProducto.DataBind();

                }
            }
        }
        protected void gvProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProducto.PageIndex = 0;
            gvProducto.PageIndex = e.NewPageIndex;

           
        }
 
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            this.Page.Response.Write("<script language='JavaScript'>window.close('./FormDetalleImpuestos.aspx', 'Detalle Impuesto', 'top=100,width=800 ,height=600, left=400');</script>");
            
        }
    }
}