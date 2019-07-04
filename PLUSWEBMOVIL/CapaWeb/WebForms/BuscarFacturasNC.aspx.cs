﻿using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;

namespace CapaWeb.WebForms
{
    public partial class BuscarFacturasNC : System.Web.UI.Page
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

        public string ComPwm;
        public string AmUsrLog;
        public string cod_proceso;
        public string Ccf_tipo1 = "C";
        public string Ccf_tipo2 = "VTA";
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
        public string Ven__cod_tipotit = "cliente";
        public string Ven__cod_tit = " ";



        public string EstF_proceso = "RCOMFACT";
        protected void Page_Load(object sender, EventArgs e)
        {

            RecuperarCokie();

            ListaModelowmspclogo = consultaLogo.BuscartaLogo(ComPwm, AmUsrLog);
            foreach (var item in ListaModelowmspclogo)
            {
                Modelowmspclogo = item;
                break;
            }

            if (!IsPostBack)
            {
               

                    Session.Remove("cliente");

                    if (Request.Cookies["ComPwm"] != null)
                    {
                        string ComPwm = Request.Cookies["ComPwm"].Value;

                    }

                    if (Session["listaClienteFac"] != null)
                    {
                    // recupera la variable de secion con el objeto persona   
                        listaConsCab = (List<modelowmtfacturascab>)Session["listaClienteFac"];
                        Session["listaConsCab"] = listaConsCab;
                    foreach (var item in listaConsCab)
                    {
                        Session["usuario"] = item.cod_cliente;

                    }

                    Grid.DataSource = listaConsCab;
                        Grid.DataBind();
                }

                fechainicio.Text = DateTime.Today.ToString("yyyy-MM-dd");
                fechafin.Text = DateTime.Today.ToString("yyyy-MM-dd");
               // CargarGrillaInicial();
              

            }

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            DateTime Fechainicio = Convert.ToDateTime(fechainicio.Text);
            DateTime Fechafin = Convert.ToDateTime(fechafin.Text);
            string Ccf_estado = "F";
            string Ccf_cliente = Session["usuario"].ToString();
            string Ccf_serie_docum = txtSerie.Text;
            string Ccf_nro_docum = txtDocumento.Text;
            string Ccf_diai = string.Format("{0:00}", Fechainicio.Day);
            string Ccf_mesi = string.Format("{0:00}", Fechainicio.Month);
            string Ccf_anioi = Fechainicio.Year.ToString();
            string Ccf_diaf = string.Format("{0:00}", Fechafin.Day);
            string Ccf_mesf = string.Format("{0:00}", Fechafin.Month);
            string Ccf_aniof = Fechafin.Year.ToString();


            listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
            Grid.DataSource = listaConsCab;
            Grid.DataBind();
            Grid.Height = 100;
        }
        protected void Grid_ItemCommand(object source, DataGridCommandEventArgs e)
        {

            //1 primero creo un objeto Clave/Valor de QueryString 
            QueryString qs = new QueryString();
            //Escoger opcion

            int Id;
            string estadoM = "";
           
            switch (e.CommandName) //ultilizo la variable para la opcion
            {

                case "Select":
                    Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                    estadoM = Convert.ToString(((Label)e.Item.Cells[5].FindControl("nom_corto")).Text);
                    //Consultamos la opcion seleccionada


                    listaConsCab = (List<modelowmtfacturascab>)Session["listaConsCab"];
                    foreach (var item in listaConsCab)
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
            DateTime Fechainicio = Convert.ToDateTime(fechainicio.Text);
            DateTime Fechafin = Convert.ToDateTime(fechafin.Text);
            string Ccf_cliente = Session["usuario"].ToString();
            string Ccf_serie_docum = txtSerie.Text;
            string Ccf_nro_docum = txtDocumento.Text;
            string Ccf_diai = string.Format("{0:00}", Fechainicio.Day);
            string Ccf_mesi = string.Format("{0:00}", Fechainicio.Month);
            string Ccf_anioi = Fechainicio.Year.ToString();
            string Ccf_diaf = string.Format("{0:00}", Fechafin.Day);
            string Ccf_mesf = string.Format("{0:00}", Fechafin.Month);
            string Ccf_aniof = Fechafin.Year.ToString();


            listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
            Grid.DataSource = listaConsCab;
            Grid.DataBind();
            Grid.Height = 100;


        }
        
    }
}