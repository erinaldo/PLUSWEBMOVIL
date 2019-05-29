﻿using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;

namespace CapaWeb.WebForms
{
    public partial class BuscarFacturas : System.Web.UI.Page
    {
        Consultaestadosfactura Consultaestados = new Consultaestadosfactura();
        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

             

        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        

        List<modelowmtfacturascab> listaConsCab = null;
        List<modeloestadosfactura> Listaestados = null;
        EnviarCorreo correo = new EnviarCorreo();
        Consultawmsptitulares ConsultaTitulares = new Consultawmsptitulares();
        public List<modelowmspctitulares> lista = null;
        modelowmspctitulares cliente = new modelowmspctitulares();
        public string ComPwm;
        public string AmUsrLog;        
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
                cargarListaDesplegables();              
                fechainicio.Text = DateTime.Today.ToString("yyyy-MM-dd");
                fechafin.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }
        }

    
        public void cargarListaDesplegables()
        {
            //Lista Estados facturas
            Listaestados = Consultaestados.ConsultaEstadosFac(EstF_proceso);
            estados.DataSource = Listaestados;
            
            estados.DataTextField = "nom_estado";
            estados.DataValueField = "estado";
            estados.DataBind();

            estados.Items.Insert(0, new ListItem("TODOS", "0"));
            estados.SelectedIndex = 0;

        }

       
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            // paginar la grilla asegurarse que la obcion que la propiedad AllowPaging sea True.
            Grid.CurrentPageIndex = 0;
            Grid.CurrentPageIndex = e.NewPageIndex;
            CargarGrilla();
        }

        protected void NuevaFactura_Click(object sender, EventArgs e)
        {
            //1 primero creo un objeto Clave/Valor de QueryString 
            QueryString qs = new QueryString();

            //2 voy a agregando los valores que deseo
            qs.Add("TRN", "INS");
            qs.Add("Id", "");
            Response.Redirect("Factura.aspx" + Encryption.EncryptQueryString(qs).ToString());
           
        }
        private void CargarGrilla()
        {
            DateTime Fechainicio = Convert.ToDateTime(fechainicio.Text);
            DateTime Fechafin = Convert.ToDateTime(fechafin.Text);
            string Ccf_cliente = txtCliente.Text;
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

        protected void Buscar_Click(object sender, EventArgs e)
        {
            DateTime Fechainicio = Convert.ToDateTime(fechainicio.Text);
            DateTime Fechafin = Convert.ToDateTime(fechafin.Text);
            string Ccf_estado = estados.SelectedValue;
            string Ccf_cliente = txtCliente.Text;
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

            switch (e.CommandName) //ultilizo la variable para la opcion
            {

                case "Editar": //ejecuta el codigo si el usuario ingresa el numero 1
                    Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);

                    //2 voy a agregando los valores que deseo
                    qs.Add("TRN", "UDP");
                    qs.Add("Id", Id.ToString());

                    Response.Redirect("Factura.aspx" + Encryption.EncryptQueryString(qs).ToString());
                    break;//termina la ejecucion del programa despues de ejecutar el codigo                   

                

                case "Imprimir": //ejecuta el codigo si el usuario ingresa el numero 3
                    Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);

                    //2 voy a agregando los valores que deseo                  
                    qs.Add("Id", Id.ToString());
                  
                    Response.Write("<script>window.open('" + "ReporteFactura.aspx" + Encryption.EncryptQueryString(qs).ToString() + "')</script>");
                    break;
                case "Ver": //ejecuta el codigo si el usuario ingresa el numero 3
                    Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);

                    //2 voy a agregando los valores que deseo
                    qs.Add("TRN", "VER");
                    qs.Add("Id", Id.ToString());
                    Response.Redirect("Factura.aspx" + Encryption.EncryptQueryString(qs).ToString());
                    break;
            }
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
        }
    }
}