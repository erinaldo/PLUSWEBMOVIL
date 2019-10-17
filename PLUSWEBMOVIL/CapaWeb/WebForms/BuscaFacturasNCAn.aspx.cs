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
    public partial class BuscaFacturasNCAn : System.Web.UI.Page
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

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();

        modelowmtfacturascab conscabceraTipo = new modelowmtfacturascab();
        public string numerador = "trans";

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
        public string tipo_nc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                RecuperarCokie();

                if (!IsPostBack)
                {


                    Session.Remove("listaFacturas");
                    Session.Remove("usuario");
                    Session.Remove("TipoFactura");

                    if (Request.Cookies["ComPwm"] != null)
                    {
                        string ComPwm = Request.Cookies["ComPwm"].Value;

                    }
                   if( Session["TipoFactura"] != null)
                    {
                        tipo_nc = Session["TipoFactura"].ToString();
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
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());
            }
        }
        public void GuardarExcepciones(string metodo, string error)
        {
           
            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "BuscarFacturasNCAn.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Today;
            ModeloExcepcion.usuario_mod = AmUsrLog;
           
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }


        public modelowmtfacturascab buscarTipoFac(string nro_trans)
        {
            try
            {
                lbl_error.Text = "";

                listaConsCab = ConsultaCabe.ConsultaTipoFactura(nro_trans);
                int count = 0;
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                    count++;
                    conscabcera = item;

                }
                return conscabcera;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("buscarTipoFac", ex.ToString());
                return null;
            }
        }
        protected void Grid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                //1 primero creo un objeto Clave/Valor de QueryString 
                QueryString qs = new QueryString();
                //Escoger opcion

                int Id;
                decimal total;
                decimal saldo;

                switch (e.CommandName) //ultilizo la variable para la opcion
                {

                    case "Select":
                        try
                        {
                            Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                            total = Convert.ToDecimal(((Label)e.Item.Cells[4].FindControl("total")).Text);
                            saldo = Convert.ToDecimal(((Label)e.Item.Cells[5].FindControl("saldo")).Text);
                            //Consultamos la opcion seleccionada saldos y totales
                            if (total != saldo)
                            {
                                this.Page.Response.Write("<script language='JavaScript'>window.alert('La Factura seleccionada no se puede Anular ')+ error;</script>");
                            }
                            else
                            {
                                //cOSNULTA BUSCAR TIPO DE FACTURA
                                conscabceraTipo = null;
                                conscabceraTipo = buscarTipoFac(Id.ToString());
                                Ccf_tipo2 = conscabceraTipo.tipo_nce.Trim();
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

                                // Refrescamos el formuario padre
                                ClientScript.RegisterClientScriptBlock(GetType(), "Refresca", "window.opener.location.reload(); window.close();", true);
                            }
                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("Grid_ItemCommand, Select", ex.ToString());

                        }
                        break;

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Grid_ItemCommand", ex.ToString());

            }
        }

        public modelowmtfacturascab buscarCabezeraFactura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {

            try
            {
                lbl_error.Text = "";


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
            catch (Exception ex)
            {
                GuardarExcepciones("buscarCabezeraFactura", ex.ToString());
                return null;
            }
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
            catch (Exception ex)
            {
                GuardarExcepciones("RecuperarCokie", ex.ToString());

            }


        }
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                // paginar la grilla asegurarse que la obcion que la propiedad AllowPaging sea True.
                Grid.CurrentPageIndex = 0;
                Grid.CurrentPageIndex = e.NewPageIndex;
                CargarGrilla();
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Grid_PageIndexChanged", ex.ToString());

            }
        }

        private void CargarGrilla()
        {
            try
            {
                lbl_error.Text = "";

                if (tipo_nc.Trim() == "NCVE")
                {
                    ListaSaldoFacturas = consultaSaldoFactura.BuscartaFacturaSaldos(AmUsrLog, ComPwm, Session["usuario"].ToString(), "C");
                }
                else
                {
                    ListaSaldoFacturas = consultaSaldoFactura.ConsultaFacturasVTASaldos(AmUsrLog, ComPwm, Session["usuario"].ToString(), "C");
                }
               

                Session["listaConsCab"] = ListaSaldoFacturas;
                Grid.DataSource = ListaSaldoFacturas;
                Grid.DataBind();
                Grid.Height = 100;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("CargarGrilla", ex.ToString());

            }


        }
    }
}