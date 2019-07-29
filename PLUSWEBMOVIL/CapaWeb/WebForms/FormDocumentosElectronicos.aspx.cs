using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;
using CapaProceso.GenerarPDF.FacturaElectronica;
using System.IO;
using System.Text;

namespace CapaWeb.WebForms
{
    public partial class FormDocumentosElectronicos : System.Web.UI.Page
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

        public List<JsonRespuestaDE> ListaModelorespuestaDs = null;
        public JsonRespuestaDE ModeloResQr = new JsonRespuestaDE();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();

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
              

                fechainicio.Text = DateTime.Today.ToString("yyyy-MM-dd");
                fechafin.Text = DateTime.Today.ToString("yyyy-MM-dd");
               
                CargarRolesUsuario();

            }
        }
        private void CargarRolesUsuario()
        {
           
            //Rol acceso a la pantalla de Buscar facturas
            ListaModelosRoles = ConsultaRoles.BuscarAccesoFactura(AmUsrLog);
            int count2 = 0;
            foreach (var item in ListaModelosRoles)
            {
                count2++;
            }

            if (count2 == 0)
            {
                txtAcceso.Visible = true;
            }

            //Rol editar factura
            ListaModelosRoles = ConsultaRoles.BuscarRolEditar(AmUsrLog);
            int count3 = 0;
            foreach (var item in ListaModelosRoles)
            {
                count3++;
            }

            if (count3 == 0)
            {
                Grid.Columns[6].Visible = false;
            }

            //Rol eliminar factura
            ListaModelosRoles = ConsultaRoles.BuscarRolEditar(AmUsrLog);
            int count4 = 0;
            foreach (var item in ListaModelosRoles)
            {
                count4++;
            }

            if (count4 == 0)
            {
                Grid.Columns[7].Visible = false;
            }

            //Rol imprimir factura
            ListaModelosRoles = ConsultaRoles.BuscarRolEditar(AmUsrLog);
            int count5 = 0;
            foreach (var item in ListaModelosRoles)
            {
                count5++;
            }

            if (count5 == 0)
            {
                Grid.Columns[8].Visible = false;
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
            string Ccf_cliente = txtCliente.Text;
            string Ccf_tipo2 = cbx_tipo_doc.SelectedValue;
            string Ccf_serie_docum = txtSerie.Text;
            string Ccf_nro_docum = txtDocumento.Text;
            string Ccf_estado = "F";
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
            string Ccf_estado = "F";
            string Ccf_tipo2 = cbx_tipo_doc.SelectedValue;
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
            string estadoM = "";
            string estadoIM = "";
            switch (e.CommandName) //ultilizo la variable para la opcion
            {


                case "Reenviar":
                    Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                    estadoM = Convert.ToString(((Label)e.Item.Cells[5].FindControl("nom_corto")).Text);
                    //Saber si en nc o factura
                    listaConsCab = ConsultaCabe.ConsultaNCTransPadre(Id.ToString());
                    int count1 = 0;
                    conscabcera = null;
                    foreach (modelowmtfacturascab item in listaConsCab)
                    {
                        count1++;
                        conscabcera = item;

                    }
                    //Buscar el xml TRAE TODAS LAS RESPUESTAS
                    ListaModelorespuestaDs = consultaRespuestaDS.ConsultaRespuestaQr(Id.ToString());
                    int count = 0;
                    foreach (var item in ListaModelorespuestaDs)
                    {
                        if(item.xml != "")
                        {
                        ModeloResQr = item;
                        count++;
                        }
                        
                    }

                    switch (estadoM)
                    {
                        case "FINALIZADO":
                            Enviarcorreocliente enviarcorreocliente = new Enviarcorreocliente();
                            string pathPdf = "";
                            string StringXml = ModeloResQr.xml;
                            string pathTemporal = Modelowmspclogo.pathtmpfac;
                            string nombreXml = ModeloResQr.cufe.Trim() + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".xml";
                            string pathXml = pathTemporal + nombreXml;
                            File.WriteAllText(pathXml, StringXml);

                            if (conscabcera.tipo_nce != "")
                            {
                                //Tipo NCE siempre trae lleno cuando es nc
                                PdfNotaCreditoElectronica pdf = new PdfNotaCreditoElectronica();
                                Ccf_tipo2 = "NC";
                                pathPdf = pdf.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Id.ToString());

                            }
                            else
                            { 
                                PdfFacturaElectronica pdf = new PdfFacturaElectronica();
                                pathPdf = pdf.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Id.ToString());
                            }                          

                            
                            Boolean error = enviarcorreocliente.EnviarCorreoCliente(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Id.ToString(), pathPdf, pathXml);



                            break;
                        default:
                            this.Page.Response.Write("<script language='JavaScript'>window.alert('SU DOCUMENTO ESTA " + estadoM + "')+ error;</script>");
                            break;

                    }

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

        public modeloRolesFacturacion BuscarRolNuevo(string usuario)
        {
            ListaModelosRoles = ConsultaRoles.BuscarRolNuevo(usuario);

            int count = 0;
            ModeloRoles = null;
            foreach (modeloRolesFacturacion item in ListaModelosRoles)
            {
                count++;
                ModeloRoles = item;

            }
            return ModeloRoles;
        }

        public modeloRolesFacturacion BuscarRolEditar(string usuario)
        {
            ListaModelosRoles = ConsultaRoles.BuscarRolEditar(usuario);

            int count = 0;
            ModeloRoles = null;
            foreach (modeloRolesFacturacion item in ListaModelosRoles)
            {
                count++;
                ModeloRoles = item;

            }
            return ModeloRoles;
        }

        public modeloRolesFacturacion BuscarRolEliminar(string usuario)
        {
            ListaModelosRoles = ConsultaRoles.BuscarRolEditar(usuario);

            int count = 0;
            ModeloRoles = null;
            foreach (modeloRolesFacturacion item in ListaModelosRoles)
            {
                count++;
                ModeloRoles = item;

            }
            return ModeloRoles;
        }

        public modeloRolesFacturacion BuscarRolImprimir(string usuario)
        {
            ListaModelosRoles = ConsultaRoles.BuscarRolEditar(usuario);

            int count = 0;
            ModeloRoles = null;
            foreach (modeloRolesFacturacion item in ListaModelosRoles)
            {
                count++;
                ModeloRoles = item;

            }
            return ModeloRoles;
        }
        public modeloRolesFacturacion BuscarAccesoFactura(string usuario)
        {
            ListaModelosRoles = ConsultaRoles.BuscarAccesoFactura(usuario);

            int count = 0;
            ModeloRoles = null;
            foreach (modeloRolesFacturacion item in ListaModelosRoles)
            {
                count++;
                ModeloRoles = item;

            }
            return ModeloRoles;
        }

        public modeloCodProcesoFactura BuscarCodProceso(string cod_proceso)
        {
            ListaModeloCodProceso = ConsultaCodProceso.DatosCodProceso(cod_proceso);

            int count = 0;
            ModeloCodProceso = null;
            foreach (modeloCodProcesoFactura item in ListaModeloCodProceso)
            {
                count++;
                ModeloCodProceso = item;

            }
            return ModeloCodProceso;
        }
        public modeloRolesFacturacion BuscarCargarTablero(string usuario)
        {
            ListaModelosRoles = ConsultaRoles.BuscarCargarTablero(usuario);

            int count = 0;
            ModeloRoles = null;
            foreach (modeloRolesFacturacion item in ListaModelosRoles)
            {
                count++;
                ModeloRoles = item;

            }
            return ModeloRoles;
        }
        protected void ImgAyuda_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            //Enviar codigo de porceso = nombre del proceso
            //rEcibir de cookie
            ModeloCodProceso = BuscarCodProceso(cod_proceso);
            Response.Redirect("Ayuda.asp" + "?cod_proceso=" + cod_proceso);
        }
    }
}