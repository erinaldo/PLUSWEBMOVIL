﻿using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;
using CapaDatos.Modelos.ModelosNC;

namespace CapaWeb
{
    public partial class BuscarFacturasNDF : System.Web.UI.Page
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
        modelowmtfacturascab conscabceraTipo = new modelowmtfacturascab();
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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                RecuperarCokie();

                if (!IsPostBack)
                {
                    Session.Remove("listaFacturas_ndf");
                    Session.Remove("saldoFacturas_ndf");
                    Session.Remove("usuario_ndf");
                    Session.Remove("suc_emp_ndf");
                    Session.Remove("tipo_ndf1");
                    if (Session["Tipo_ndf"] != null)
                    {
                        Session["tipo_ndf1"] = Session["Tipo_ndf"].ToString();
                    }
                    if (Session["Sucursal_ndf"] != null)
                    {
                        Session["suc_emp_ndf"] = Session["Sucursal_ndf"].ToString();
                    }
                    if (Session["cod_Cliente_ndf"] != null)
                    {
                        Session["usuario_ndf"] = Session["cod_Cliente_ndf"].ToString();
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
            ModeloExcepcion.proceso = "BuscarFacturasNDF.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
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
                decimal saldo;
                switch (e.CommandName) //ultilizo la variable para la opcion
                {

                    case "Select":
                        try
                        {
                            Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                            saldo = Convert.ToDecimal(((Label)e.Item.Cells[5].FindControl("saldo")).Text);
                            //Consultamos la opcion seleccionada
                            //Cnnsultar tipo de factura
                            conscabceraTipo = null;
                            conscabceraTipo = buscarTipoFac(Id.ToString());
                            Ccf_tipo2 = conscabceraTipo.tipo_nce;
                            //Consulta de cabeecra
                            listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Id.ToString(), Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);

                            foreach (modelowmtfacturascab item in listaConsCab)
                            {
                                if (item.nro_trans == Id.ToString())
                                {
                                    item.tipo_nce = conscabceraTipo.tipo_nce;

                                    conscabcera = item;

                                    break;
                                }

                            }
                            // Crea la variable de sessión
                            Session["listaFacturas_ndf"] = conscabcera;
                            Session["saldoFacturas_ndf"] = saldo;
                            // Refrescamos el formuario padre
                            ClientScript.RegisterClientScriptBlock(GetType(), "Refresca", "window.opener.location.reload(); window.close();", true);

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
                if (txtDocumento.Text == null || txtDocumento.Text == "")
                {
                    BusquedasFiltradas("FEC");

                }
                else
                {
                    if (fechainicio.Text == null || fechainicio.Text == "")
                    {
                        BusquedasFiltradas("NRO");
                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("CargarGrilla", ex.ToString());

            }


        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                if (txtDocumento.Text == null || txtDocumento.Text == "")
                {
                    BusquedasFiltradas("FEC");

                }
                else
                {
                    if (fechainicio.Text == null || fechainicio.Text == "")
                    {
                        BusquedasFiltradas("NRO");
                    }
                }
            }

            catch (Exception ex)
            {
                GuardarExcepciones("btn_buscar_Click", ex.ToString());

            }
        }

        public void BusquedasFiltradas(string tipo_busqueda)
        {
            try
            {
                if (tipo_busqueda.Trim() == "FEC")
                {

                    string tipo_doc = Session["tipo_ndf1"].ToString();
                    switch (tipo_doc)
                    {
                      
                        case "NDV":
                            ListaSaldoFacturas = consultaSaldoFactura.ConsultaFacturasVTASaldos(AmUsrLog, ComPwm, Session["usuario_ndf"].ToString(), "C", "N", Session["suc_emp_ndf"].ToString(), fechainicio.Text, fechafin.Text, "0");
                            break;
                        case "NDVE":
                            ListaSaldoFacturas = consultaSaldoFactura.BuscartaFacturaSaldos(AmUsrLog, ComPwm, Session["usuario_ndf"].ToString(), "C", "N", Session["suc_emp_ndf"].ToString(), fechainicio.Text, fechafin.Text, "0");
                            break;

                    }

                }
                else
                {
                    string tipo_doc = Session["tipo_ndf1"].ToString();
                    switch (tipo_doc)
                    {
                        
                        case "NDV":
                            ListaSaldoFacturas = consultaSaldoFactura.ConsultaFacturasVTASaldosXNroDoc(AmUsrLog, ComPwm, Session["usuario_ndf"].ToString(), "C", "N", Session["suc_emp_ndf"].ToString(), txtDocumento.Text.Trim());
                            break;
                        case "NDVE":
                            ListaSaldoFacturas = consultaSaldoFactura.BuscarFacturaSaldosXNroDocumento(AmUsrLog, ComPwm, Session["usuario_ndf"].ToString(), "C", "N", Session["suc_emp_ndf"].ToString(), txtDocumento.Text.Trim());
                            break;

                    }
                }
                Grid.DataSource = ListaSaldoFacturas;
                Grid.DataBind();
                Grid.Height = 100;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BusquedasFiltradas", ex.ToString());

            }
        }
        protected void cbx_tipo_filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbx_tipo_filtro.SelectedValue == "0")
                {
                    lbl_error.Text = "Seleccione un tipo de filtro";
                    lbl_fecha_fin.Visible = false;
                    lbl_fec_ini.Visible = false;
                    fechainicio.Visible = false;
                    fechafin.Visible = false;
                    lbl_doc.Visible = false;
                    txtDocumento.Visible = false;
                    btn_buscar.Visible = false;
                    txtDocumento.Text = null;
                    fechafin.Text = null;

                }
                else
                {
                    if (cbx_tipo_filtro.SelectedValue == "FEC")
                    {
                        lbl_fecha_fin.Visible = true;
                        lbl_fec_ini.Visible = true;
                        fechainicio.Visible = true;
                        fechafin.Visible = true;
                        lbl_doc.Visible = false;
                        txtDocumento.Visible = false;
                        txtDocumento.Text = null;
                        btn_buscar.Visible = true;
                    }
                    else
                    {
                        lbl_doc.Visible = true;
                        txtDocumento.Visible = true;
                        btn_buscar.Visible = true;
                        lbl_fecha_fin.Visible = false;
                        lbl_fec_ini.Visible = false;
                        fechainicio.Visible = false;
                        fechainicio.Text = null;
                        fechafin.Visible = false;
                        fechafin.Text = null;
                    }
                }

            }
            catch (Exception ex)
            {
                GuardarExcepciones("cbx_tipo_filtro_SelectedIndexChanged", ex.ToString());

            }
        }
    }
}