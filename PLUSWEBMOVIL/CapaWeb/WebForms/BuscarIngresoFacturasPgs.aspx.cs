﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using CapaDatos.Modelos;
using CapaWeb.Urlencriptacion;

namespace CapaWeb.WebForms
{
    public partial class BuscarIngresoFacturasPgs : System.Web.UI.Page
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
        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();

        List<modeloCajasCierre> listaCajasUsuario = null;
        List<modeloPagoProveedores> ListaPProveedores = null;
        ConsultaCierecaja ConsultaCCaja = new ConsultaCierecaja();
        public string numerador = "trans";

        public string ComPwm;
        public string AmUsrLog;
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
                        Session["cta_banco"] = Session["Cod_cta_cja"];
                        Session["nom_cta"] = Session["Nom_cta_cja"];
                        //Buscar codigo de cuenta

                        listaCajasUsuario = ConsultaCCaja.ConsultaCajasCierre(AmUsrLog, ComPwm, "", "");
                        foreach (modeloCajasCierre item in listaCajasUsuario)
                        {
                            if (item.nrocta_banco.Trim() == Session["cta_banco"].ToString().Trim() && item.nomtcta_banco.Trim() == Session["nom_cta"].ToString().Trim())
                            {
                                Session["cod_cta"] = item.cod_cta.Trim();
                                break;
                            }
                        }
                        //TOTAL PAGO EN EFECTIVO DE FACTURAS
                        string fecha = Session["Fecha"].ToString();
                        DateTime Fechainicio = Convert.ToDateTime(fecha);
                        string dia = string.Format("{0:00}", Fechainicio.Day);
                        string mes = string.Format("{0:00}", Fechainicio.Month);
                        string anio = Fechainicio.Year.ToString();
                        ListaPProveedores = null;
                        ListaPProveedores = ConsultaCCaja.ListaFacturasNV(AmUsrLog, ComPwm, dia, mes, anio, "FV", "D", Session["cod_cta"].ToString().Trim());

                        gvProducto.DataSource = ListaPProveedores;
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
            ModeloExcepcion.proceso = "BuscarIngresoFacturasPgs.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;

            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }

        //Calcular totales del grid
        private void CalcularTotales()
        {
            try
            {
                lbl_error.Text = "";



                string fecha = Session["Fecha"].ToString();
                DateTime Fechainicio = Convert.ToDateTime(fecha);
                string dia = string.Format("{0:00}", Fechainicio.Day);
                string mes = string.Format("{0:00}", Fechainicio.Month);
                string anio = Fechainicio.Year.ToString();
                ListaPProveedores = null;
                ListaPProveedores = ConsultaCCaja.ListaFacturasNV(AmUsrLog, ComPwm, dia, mes, anio, "FV", "D", Session["cod_cta"].ToString().Trim());
                if (ListaPProveedores.Count > 0)
                {


                    decimal TotalFactura = 0;
                    decimal TotalRedondeado = 0;

                    foreach (GridViewRow item in gvProducto.Rows)
                    {

                        TotalRedondeado = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), Convert.ToDecimal(item.Cells[4].Text));
                        TotalFactura += TotalRedondeado;
                    }
                    gvProducto.FooterRow.Cells[3].Text = "TOTALES:";

                    gvProducto.FooterRow.Cells[4].Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), TotalFactura);

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("CalcularTotales", ex.ToString());

            }
        }
        public void gvProducto_DataBound(Object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                CalcularTotales();
            }
            catch (Exception ex)
            {
                GuardarExcepciones("gvProducto_DataBound", ex.ToString());

            }
        }
        public modelowmspcmonedas BuscarDecimales()
        {
            try
            {
                lbl_error.Text = "";
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
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarDecimales", ex.ToString());
                return null;
            }
        }


        protected void gvProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                lbl_error.Text = "";


                gvProducto.PageIndex = 0;
                gvProducto.PageIndex = e.NewPageIndex;

                CargarGrid();
            }
            catch (Exception ex)
            {
                GuardarExcepciones("gvProducto_PageIndexChanging", ex.ToString());

            }
        }
        public void CargarGrid()
        {
            try
            {
                lbl_error.Text = "";
                //TOTAL PAGO EN EFECTIVO DE FACTURAS
                string fecha = Session["Fecha"].ToString();
                DateTime Fechainicio = Convert.ToDateTime(fecha);
                string dia = string.Format("{0:00}", Fechainicio.Day);
                string mes = string.Format("{0:00}", Fechainicio.Month);
                string anio = Fechainicio.Year.ToString();
                ListaPProveedores = null;
                ListaPProveedores = ConsultaCCaja.ListaFacturasNV(AmUsrLog, ComPwm, dia, mes, anio, "FV", "D", Session["cod_cta"].ToString().Trim());
                gvProducto.DataSource = ListaPProveedores;
                gvProducto.DataBind();
            }

            catch (Exception ex)
            {
                GuardarExcepciones("CargarGrid", ex.ToString());

            }
        }
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                this.Page.Response.Write("<script language='JavaScript'>window.close('./BuscarIngresoFacturasPgs.aspx', 'Ingreso Facturas', 'top=100,width=800 ,height=600, left=400');</script>");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Cancelar_Click", ex.ToString());

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

                //1 primero creo un objeto Clave/Valor de QueryString 
                QueryString qs = new QueryString();

                string Id = Convert.ToString(gvProducto.DataKeys[row.RowIndex].Value);
                //Buscar tipo factura
                listaConsCab = ConsultaCabe.ConsultaTipoFactura(Id.Trim());
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                    conscabcera = item;

                }
                string Tipo = conscabcera.tipo_nce.Trim();


                qs.Add("TRN", "VER");
                qs.Add("Id", Id.ToString());
                qs.Add("Tipo", Tipo);
                Response.Redirect("VerDetalleFacturas.aspx" + Encryption.EncryptQueryString(qs).ToString());
                /* listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, "c", Tipo, nro_trans.Trim(), "0", "0", "0", "xxx", "0", "", "", "", "", "", "");
                 conscabcera = null;
                 foreach (modelowmtfacturascab item in listaConsCab)
                 {
                     conscabcera = item;

                 }
                 string pagina = Modelowmspclogo.sitio_app + "Cons_DetalleDocs.asp" + "?cod_docum=" + conscabcera.cod_docum.Trim() + "&nro_docum=" + conscabcera.nro_docum.Trim() + "&serie_docum=" + conscabcera.serie_docum.Trim() + "&cod_tit=" + conscabcera.cod_cliente.Trim() + "&tipo=C";


                 Response.Redirect(pagina);
                 */
            }
            catch (Exception ex)
            {
                GuardarExcepciones("gvProducto_SelectedIndexChanged", ex.ToString());

            }

        }

    }

}
