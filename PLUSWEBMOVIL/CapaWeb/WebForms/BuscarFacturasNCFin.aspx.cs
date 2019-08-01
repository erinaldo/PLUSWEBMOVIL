using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;
using CapaDatos.Modelos.ModelosNC;

namespace CapaWeb.WebForms
{
    public partial class BuscarFacturasNCFin : System.Web.UI.Page
    {
        Consultaestadosfactura Consultaestados = new Consultaestadosfactura();
        List<modeloestadosfactura> Listaestados = null;

        public ConsultaRolesFactura ConsultaRoles = new ConsultaRolesFactura();
        public modeloRolesFacturacion ModeloRoles = new modeloRolesFacturacion();
        public List<modeloRolesFacturacion> ListaModelosRoles = null;

        public ConsultaCodProceso ConsultaCodProceso = new ConsultaCodProceso();
        public modeloCodProcesoFactura ModeloCodProceso = new modeloCodProcesoFactura();
        public List<modeloCodProcesoFactura> ListaModeloCodProceso = null;

        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        List<modelowmtfacturascab> listaConsCab = null;
        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

        ConsumoRest consumoRest = new ConsumoRest();

        Consultawmsptitulares ConsultaTitulares = new Consultawmsptitulares();
        public List<modelowmspctitulares> lista = null;
        modelowmspctitulares cliente = new modelowmspctitulares();

        public List<modelowmspcfacturasWMimpuRest> ListaModeloimpuesto = new List<modelowmspcfacturasWMimpuRest>();
        public modelowmspcfacturasWMimpuRest ModeloImpuesto = new modelowmspcfacturasWMimpuRest();
        public ConsultawmspcfacturasWMimpuRest consultaImpuesto = new ConsultawmspcfacturasWMimpuRest();

        public List<modeloSaldosFacturas> ListaSaldoFacturas = null;
        public modeloSaldosFacturas ModeloSaldoFactura = new modeloSaldosFacturas();
        public ConsultaSaldosFacturas consultaSaldoFactura = new ConsultaSaldosFacturas();

        public string ComPwm;
        public string AmUsrLog;
        public string cod_proceso;
        public string Ccf_tipo1 = "CLIENTES";
        public string Ccf_tipo2 = "VTAE";
        public string Ccf_nro_trans = " ";
        public string Ccf_estado = "0";
        public string Ccf_cliente = "0";
        public string Ccf_cod_docum = "0";
        public string Ccf_serie_docum = "xxx";
        public string Ccf_nro_docum = "0";
        public string Ccf_diai = "";
        public string Ccf_mesi = "";
        public string Ccf_anioi = "";
        public string Ccf_diaf = "";
        public string Ccf_mesf = "";
        public string Ccf_aniof = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            RecuperarCokie();

            if (!IsPostBack)
            {


                Session.Remove("listaFacturas");
                Session.Remove("usuario");

                if (Request.Cookies["ComPwm"] != null)
                {
                    string ComPwm = Request.Cookies["ComPwm"].Value;

                }

                if (Session["listaClienteFac"] != null)
                {
                    // recupera la variable de secion con el objeto persona 

                    ListaSaldoFacturas = (List<modeloSaldosFacturas>)Session["listaClienteFac"];
                    Session["listaConsCab"] = ListaSaldoFacturas;
                    foreach (var item in ListaSaldoFacturas)
                    {
                        Session["usuario"] = item.cod_cliente;

                    }

                    Grid.DataSource = ListaSaldoFacturas;
                    Grid.DataBind();
                }

            }
        }

        protected void Grid_ItemCommand(object source, DataGridCommandEventArgs e)
        {

            //1 primero creo un objeto Clave/Valor de QueryString 
            QueryString qs = new QueryString();
            //Escoger opcion

            int Id;
            decimal saldo;
            switch (e.CommandName) //ultilizo la variable para la opcion
            {

                case "Select":
                    Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                    saldo = Convert.ToDecimal(((Label)e.Item.Cells[5].FindControl("saldo")).Text);
                    //Consultamos la opcion seleccionada
                    //Consulta de cabeecra
                    listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Id.ToString(), Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);

                    foreach (modelowmtfacturascab item in listaConsCab)
                    {
                        if (item.nro_trans == Id.ToString())
                        {
                            conscabcera = item;

                            break;
                        }

                    }


                    // Crea la variable de sessión
                    Session["listaFacturas"] = conscabcera;
                    Session["saldoFacturas"] = saldo;
                    // Refrescamos el formuario padre
                    ClientScript.RegisterClientScriptBlock(GetType(), "Refresca", "window.opener.location.reload(); window.close();", true);

                    break;

            }
        }

        public modelowmtfacturascab buscarCabezeraFactura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {

            listaConsCab = ConsultaCabe.ConsultaCabFacura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
            int count = 0;
            conscabcera = null;
            foreach (modelowmtfacturascab item in listaConsCab)
            {
                count++;
                conscabcera = item;

            }
            return conscabcera;
        }
        public void RecuperarCokie()
        {
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
            if (Request.Cookies["ProcAud"] != null)
            {
                cod_proceso = Request.Cookies["ProcAud"].Value;
            }
            else
            {
                cod_proceso = Convert.ToString(Request.QueryString["cod_proceso"]);
                if (cod_proceso != null)
                {
                    //Crear cookie de cod_proceso
                    Response.Cookies["ProcAud"].Value = cod_proceso;
                }
            }


        }
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            // paginar la grilla asegurarse que la obcion que la propiedad AllowPaging sea True.
            Grid.CurrentPageIndex = 0;
            Grid.CurrentPageIndex = e.NewPageIndex;
            CargarGrilla();
        }

        private void CargarGrilla()
        {


            ListaSaldoFacturas = consultaSaldoFactura.BuscartaFacturaSaldos(AmUsrLog, ComPwm, Session["usuario"].ToString(), "C");

            Session["listaConsCab"] = ListaSaldoFacturas;
            Grid.DataSource = ListaSaldoFacturas;
            Grid.DataBind();
            Grid.Height = 100;


        }
    }
}