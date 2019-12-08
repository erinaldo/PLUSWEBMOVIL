using CapaDatos.Modelos;
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
    public partial class BuscarArticuloNCDevolucion : System.Web.UI.Page
    {
        ModeloDetalleFactura consdetalle = new ModeloDetalleFactura();
        List<ModeloDetalleFactura> listaConsDetalle = null;
        List<ModeloDetalleFactura> ModeloDetalleFactura = new List<ModeloDetalleFactura>();
        Consultawmtfacturasdet ConsultaDeta = new Consultawmtfacturasdet();
        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        public string numerador = "trans";

        public string ComPwm;
        public string AmUsrLog;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = ""; 
                RecuperarCokie();

                if (!IsPostBack)
                {


                    Session.Remove("articulo");
                    Session.Remove("nro_factura");


                    if (Request.Cookies["ComPwm"] != null)
                    {
                        string ComPwm = Request.Cookies["ComPwm"].Value;

                    }
                    if (Session["listaProducto"] != null)
                    {
                        // recupera la variable de secion con el objeto persona   
                        listaConsDetalle = (List<ModeloDetalleFactura>)Session["listaProducto"];
                        Session["listaArticulos"] = listaConsDetalle;
                        foreach (var item in listaConsDetalle)
                        {
                            Session["nro_factura"] = item.nro_trans;

                        }
                        gvProducto.DataSource = listaConsDetalle;
                        gvProducto.DataBind();

                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());
            }
        }
        public void GuardarExcepciones(string metodo, string error)
        {
          
            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "BuscarArticuloNCDevolucion.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;
            
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }
        public void RecuperarCokie()
        {
            try
            {
                lbl_error.Text = "";

                if (Request.Cookies["ComPwm"] != null)
                {
                    ComPwm = Request.Cookies["ComPwm"].Value;
                }
                else
                {
                    Response.Redirect("../Inicio.asp");
                }


                if (Request.Cookies["AmUsrLog"] != null)
                {
                    AmUsrLog = Request.Cookies["AmUsrLog"].Value;

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("RecuperarCokie", ex.ToString());

            }
        }
        protected void TxtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                CargarGrilla(TxtBuscarProducto.Text);
            }
            catch (Exception ex)
            {
                GuardarExcepciones("TxtBuscarProducto_TextChanged", ex.ToString());

            }
        }


        public void CargarGrilla(string ArtB__articulo)
        {
            try
            {
                lbl_error.Text = "";
                listaConsDetalle = ConsultaDeta.ConsultaDetFacNCDev(Session["nro_factura"].ToString(), ArtB__articulo);
                Session["listaArticulos"] = listaConsDetalle;
                gvProducto.DataSource = listaConsDetalle;
                gvProducto.DataBind();
            }
            catch (Exception ex)
            {
                GuardarExcepciones("CargarGrilla", ex.ToString());

            }


        }
        protected void gvProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                gvProducto.PageIndex = 0;
                gvProducto.PageIndex = e.NewPageIndex;

                CargarGrilla(TxtBuscarProducto.Text);
            }
            catch (Exception ex)
            {
                GuardarExcepciones("gvProducto_PageIndexChanging", ex.ToString());

            }

        }
        protected void gvProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                lbl_error.Text = "";

                //
                // Se obtiene la fila seleccionada del gridview
                //
                GridViewRow row = gvProducto.SelectedRow;

                //
                // Obtengo el id de la entidad que se esta editando
                // en este caso de la entidad Person
                //
                string cod_articulo = Convert.ToString(gvProducto.DataKeys[row.RowIndex].Value);

                listaConsDetalle = (List<ModeloDetalleFactura>)Session["listaArticulos"];
                foreach (var item in listaConsDetalle)
                {
                    if (item.cod_articulo == cod_articulo)
                    {
                        consdetalle = item;

                        break;
                    }

                }
                // Crea la variable de sessión
                Session["articulo"] = consdetalle;

                // Refrescamos el formuario padre
                ClientScript.RegisterClientScriptBlock(GetType(), "Refresca", "window.opener.location.reload(); window.close();", true);
            }


            catch (Exception ex)
            {
                GuardarExcepciones("gvProducto_SelectedIndexChanged", ex.ToString());

            }

        }
    }
}