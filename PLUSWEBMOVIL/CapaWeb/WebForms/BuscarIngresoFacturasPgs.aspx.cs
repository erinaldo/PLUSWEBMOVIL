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

        
        public string ComPwm;
        public string AmUsrLog;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


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
                DecimalesMoneda = null;
                DecimalesMoneda = BuscarDecimales();
                if (Session["Fecha"] != null)
                {
                    Session["Fecha1"] = Session["Fecha"];
                    listaIngresosFac = consultaIngFaturas.BuscarPgsFacturas(ComPwm, Session["Fecha"].ToString(), AmUsrLog, "clientes", "0", "0");
                    modeloFaturasPgs = null;
                    decimal totalFacturado = 0;
                    decimal totalEfecitivo = 0;
                    foreach (modeloIngresoFacturas item in listaIngresosFac)
                    {
                        
                        modeloFaturasPgs = item;
                        totalFacturado += modeloFaturasPgs.total;
                        totalEfecitivo += modeloFaturasPgs.efectivo;
                    }
                    //Decimales
                    totalFacturado = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, totalFacturado);

                    txt_total_facturas.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, totalFacturado);
                    totalEfecitivo = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, totalEfecitivo);

                    txt_total_efectivo.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, totalEfecitivo);

                    Grid.DataSource = listaIngresosFac;
                   Grid.DataBind();
                    // recupera la variable de secion con el objeto persona   
                    //CargarGrid(Session["Fecha"].ToString());
                }
            }
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
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            // paginar la grilla asegurarse que la obcion que la propiedad AllowPaging sea True.
            Grid.CurrentPageIndex = 0;
            Grid.CurrentPageIndex = e.NewPageIndex;
            CargarGrid();
        }
        public void CargarGrid()
        {
            listaIngresosFac = consultaIngFaturas.BuscarPgsFacturas(ComPwm, Session["Fecha1"].ToString(), AmUsrLog, "clientes", "0", "0");
            Grid.DataSource = listaIngresosFac;
            Grid.DataBind();
        }
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            this.Page.Response.Write("<script language='JavaScript'>window.close('./BuscarIngresoFacturasPgs.aspx', 'Ingreso Facturas', 'top=100,width=800 ,height=600, left=400');</script>");

        }

      
        protected void Grid_ItemCommand(object source, DataGridCommandEventArgs e)
        {

            //1 primero creo un objeto Clave/Valor de QueryString 
           // QueryString qs = new QueryString();
            //Escoger opcion

            int Id;
            string codigo = "";
            string serie = "";
            string nro = "";
            string titular = "";
            switch (e.CommandName) //ultilizo la variable para la opcion
            {

                

                case "Mostrar":
                    Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                    codigo = Convert.ToString(((Label)e.Item.Cells[2].FindControl("cod_docum")).Text);
                    nro = Convert.ToString(((Label)e.Item.Cells[3].FindControl("nro_docum")).Text);
                    serie = Convert.ToString(((Label)e.Item.Cells[4].FindControl("serie_docum")).Text);
                    titular = Convert.ToString(((Label)e.Item.Cells[5].FindControl("cod_tit")).Text);

                    string pagina = "Cons_DetalleDocs.asp"+"?usuario="+Session["usuario"]+"&cod_emp="+Session["empresa"]+"&cod_docum="+codigo.Trim()+"&nro_docum=" +nro.Trim()+"&serie_docum="+serie.Trim()+ "&cod_tit="+titular.Trim()+"&tipo=C";
                    

                    Response.Write("<script> window.open('"+pagina+"','_blank');</script>");
                    break;

                
                   
            }
        }

      
       
    }
}