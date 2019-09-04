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
    public partial class BuscarNotasVenta : System.Web.UI.Page
    {
        ConsultaIngresoFacturas consultaIngFaturas = new ConsultaIngresoFacturas();
        modeloIngresoFacturas modeloFaturasPgs = new modeloIngresoFacturas();
        List<modeloIngresoFacturas> listaIngresosFac = null;

        Consultawmspcmonedas ConsultaCMonedas = new Consultawmspcmonedas();
        List<modelowmspcmonedas> listaMonedas = null;
        modelowmspcmonedas DecimalesMoneda = new modelowmspcmonedas();
        ConsultaEmpresa consultaEmpresa = new ConsultaEmpresa();
        List<modelowmspcempresas> listaEmpresa = null;
        modelowmspcempresas modeloEmpresa = new modelowmspcempresas();

        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();
        List<modelowmtfacturascab> listaConsCab = null;
        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        modelocabecerafactura cabecerafactura = new modelocabecerafactura();

        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

   
        public string ComPwm;
        public string AmUsrLog;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["ComPwm"] != null)
            {
                ComPwm = Request.Cookies["ComPwm"].Value;

            }
            if (Request.Cookies["AmUsrLog"] != null)
            {
                AmUsrLog = Request.Cookies["AmUsrLog"].Value;


            }
            ListaModelowmspclogo = consultaLogo.BuscartaLogo(ComPwm, AmUsrLog);
            foreach (var item in ListaModelowmspclogo)
            {
                Modelowmspclogo = item;
                break;
            }
            if (!IsPostBack)
            {

                if (Session["Fecha"] != null)
                {
                    Session["Fecha1"] = Session["Fecha"];
                    listaIngresosFac = consultaIngFaturas.BuscarNotasVenta(ComPwm, Session["Fecha"].ToString(), AmUsrLog, "clientes", "0", "0");
                 
                  

                    gvProducto.DataSource = listaIngresosFac;
                    gvProducto.DataBind();
                    
                }
            }
        }

        //Calcular totales del grid
        private void CalcularTotales()
        {
            listaIngresosFac = consultaIngFaturas.BuscarNotasVenta(ComPwm, Session["Fecha"].ToString(), AmUsrLog, "clientes", "0", "0");
            if(listaIngresosFac.Count >0)
            {

                DecimalesMoneda = null;
                DecimalesMoneda = BuscarDecimales();
                decimal TotalFactura = 0;
             decimal TotalEfectivo = 0;
            foreach (GridViewRow item in gvProducto.Rows)
            {
                TotalFactura += Convert.ToDecimal(item.Cells[4].Text);
                TotalEfectivo += Convert.ToDecimal(item.Cells[5].Text);
            }
            gvProducto.FooterRow.Cells[3].Text = "TOTALES:";
            gvProducto.FooterRow.Cells[4].Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, TotalFactura);
            gvProducto.FooterRow.Cells[5].Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, TotalEfectivo);
            }
        }
        public void gvProducto_DataBound(Object sender, EventArgs e)
        {
            CalcularTotales();
        }
        public modelowmspcmonedas BuscarDecimales()
        {
            listaEmpresa = consultaEmpresa.BuscartaEmpresa(AmUsrLog, ComPwm);
            modeloEmpresa = null;
            foreach (modelowmspcempresas item in listaEmpresa)
            {

                modeloEmpresa = item;
                break;

            }

            listaMonedas = ConsultaCMonedas.ConsultaCMonedas(AmUsrLog, ComPwm, modeloEmpresa.mone_mn.Trim());

            DecimalesMoneda = null;
            foreach (modelowmspcmonedas item in listaMonedas)
            {

                DecimalesMoneda = item;
                break;

            }
            Session["redondeo"] = DecimalesMoneda.redondeo;
            Session["redondeo_pu"] = DecimalesMoneda.redondeo_pu;
            return DecimalesMoneda;
        }

        protected void gvProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProducto.PageIndex = 0;
            gvProducto.PageIndex = e.NewPageIndex;

            CargarGrid();
        }
        public void CargarGrid()
        {
            listaIngresosFac = consultaIngFaturas.BuscarNotasVenta(ComPwm, Session["Fecha1"].ToString(), AmUsrLog, "clientes", "0", "0");
            gvProducto.DataSource = listaIngresosFac;
            gvProducto.DataBind();
        }
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            this.Page.Response.Write("<script language='JavaScript'>window.close('./BuscarNotasVenta.aspx', 'Ingreso Notas Venta', 'top=100,width=800 ,height=600, left=400');</script>");
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
            string nro_trans = Convert.ToString(gvProducto.DataKeys[row.RowIndex].Value);
            //Buscar tipo factura
            listaConsCab = ConsultaCabe.ConsultaTipoFactura(nro_trans.Trim());
            conscabcera = null;
            foreach (modelowmtfacturascab item in listaConsCab)
            {
                conscabcera = item;

            }
            string Tipo = conscabcera.tipo_nce.Trim();
            listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, "c", Tipo, nro_trans.Trim(), "0", "0", "0", "xxx", "0", "", "", "", "", "", "");
            conscabcera = null;
            foreach (modelowmtfacturascab item in listaConsCab)
            {
                conscabcera = item;

            }
            string pagina = Modelowmspclogo.sitio_app + "Cons_DetalleDocs.asp" + "?cod_docum=" + conscabcera.cod_docum.Trim() + "&nro_docum=" + conscabcera.nro_docum.Trim() + "&serie_docum=" + conscabcera.serie_docum.Trim() + "&cod_tit=" + conscabcera.cod_cliente.Trim() + "&tipo=C";


            Response.Redirect(pagina);


        }

       
    }
}