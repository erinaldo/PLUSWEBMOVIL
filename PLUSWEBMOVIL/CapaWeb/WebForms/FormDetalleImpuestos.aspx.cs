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
        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        public string numerador = "trans";
        public string ComPwm;
        public string AmUsrLog;
        public string nro_trans = null;
        public string cod_proceso;
       
        public string valor_asignado = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                if (Request.Cookies["ComPwm"] != null)
                {
                    ComPwm = Request.Cookies["ComPwm"].Value;
                    Session["empresa"] = ComPwm;

                }
                if (Request.Cookies["AmUsrLog"] != null)
                {
                    AmUsrLog = Request.Cookies["AmUsrLog"].Value;

                    Session["usuario"] = AmUsrLog;
                }

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
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());

            }
        }

        public void GuardarExcepciones(string metodo, string error)
        {
          
            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "DetalleImpuestos.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Today;
            ModeloExcepcion.usuario_mod = AmUsrLog;
       
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }
        protected void gvProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                lbl_error.Text = "";


                gvProducto.PageIndex = 0;
                gvProducto.PageIndex = e.NewPageIndex;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("gvProducto_PageIndexChanging", ex.ToString());

            }


        }
 
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                this.Page.Response.Write("<script language='JavaScript'>window.close('./FormDetalleImpuestos.aspx', 'Detalle Impuesto', 'top=100,width=800 ,height=600, left=400');</script>");

            }
            catch (Exception ex)
            {
                GuardarExcepciones("Cancelar_Click", ex.ToString());

            }
        }
    }
}