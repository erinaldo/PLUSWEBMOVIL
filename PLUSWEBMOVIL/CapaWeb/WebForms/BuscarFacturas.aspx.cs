using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;

namespace CapaWeb.WebForms
{
    public partial class BuscarFacturas : System.Web.UI.Page
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
                CargarGrillaInicial();
                CargarRolesUsuario();
               
            }
        }

        private void CargarRolesUsuario()
        {
            //Rol crear factura nueva
            ListaModelosRoles = ConsultaRoles.BuscarRolNuevo(AmUsrLog);
            int count1 = 0;
            foreach (var item in ListaModelosRoles)
            {
                count1++;

            }
 
            if (count1 >0)
            {
                NuevaFactura.Visible = true;
            }
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
        private void CargarGrillaInicial()
        {
            DateTime Fechainicio = DateTime.Today;
            DateTime Fechafin = DateTime.Today;

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
            string estadoM = "";
            switch (e.CommandName) //ultilizo la variable para la opcion
            {

                case "Editar": 
                    Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                    estadoM = Convert.ToString(((Label)e.Item.Cells[5].FindControl("nom_corto")).Text);

                    switch (estadoM)
                    {
                         case "PENDIENTE":
                           
                            qs.Add("TRN", "UDP");
                            qs.Add("Id", Id.ToString());

                            Response.Redirect("Factura.aspx" + Encryption.EncryptQueryString(qs).ToString());
                            break;
                        default:
                            this.Page.Response.Write("<script language='JavaScript'>window.alert('SU FACTURA ESTA "+ estadoM  + "')+ error;</script>");
                            break;
                        
                    }
                   
                    break;                

                case "Imprimir": 
                    Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                    estadoM = Convert.ToString(((Label)e.Item.Cells[5].FindControl("nom_corto")).Text);
                    switch (estadoM)
                    {
                        case "FINALIZADO":

                            qs.Add("Id", Id.ToString());
                            Response.Write("<script>window.open('" + "ReporteFactura.aspx" + Encryption.EncryptQueryString(qs).ToString() + "')</script>");
                            break;
                        default:
                            this.Page.Response.Write("<script language='JavaScript'>window.alert('SU FACTURA ESTA " + estadoM + "')+ error;</script>");
                            break;

                    }
                    
                    break;

                case "Eliminar": 
                    Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                    Encabezado encabezado = new Encabezado();                  

                    conscabcera = null;
                    conscabcera = buscarCabezeraFactura(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Convert.ToString(Id));
                    Response.Redirect(Modelowmspclogo.sitio_app + conscabcera.pagina_elimina + "?nro_trans="+ Convert.ToString(Id)+ "&cod_docum=" + conscabcera.cod_docum.Trim() + "&serie_docum=" + conscabcera.serie_docum.Trim() + "&nro_docum=" + conscabcera.nro_docum.Trim() + "&tipo=VTA");
                    break;

                case "Impuestos":
                    Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);

                    ListaModeloimpuesto = consultaImpuesto.BuscarImpuestoRest(AmUsrLog, ComPwm, Id.ToString(), "0");
                    Session["listaImpuestos"] = ListaModeloimpuesto;
                    this.Page.Response.Write("<script language='JavaScript'>window.open('./FormDetalleImpuestos.aspx', 'Detalle Impuesto', 'top=100,width=800 ,height=400, left=400');</script>");
                    break;

                case "Ver": 
                    Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);

                   
                    qs.Add("TRN", "VER");
                    qs.Add("Id", Id.ToString());
                    Response.Redirect("Factura.aspx" + Encryption.EncryptQueryString(qs).ToString());
                    break;

                case "Mostrar": 
                    Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                    estadoM = Convert.ToString(((Label)e.Item.Cells[5].FindControl("nom_corto")).Text);

                    qs.Add("TRN", "MTR");
                    qs.Add("Id", Id.ToString());
                    Response.Redirect("PortalFacturas.aspx" + Encryption.EncryptQueryString(qs).ToString());
                
                    break;

                case "Reenviar": 
                    Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                    estadoM = Convert.ToString(((Label)e.Item.Cells[5].FindControl("nom_corto")).Text);

                    switch (estadoM)
                    {
                        case "CONTABILIZADO":
                            
                            qs.Add("Id", Id.ToString());
                            Response.Redirect("ReenviarFacturaJson.aspx" + Encryption.EncryptQueryString(qs).ToString());
                            break;
                        default:
                            this.Page.Response.Write("<script language='JavaScript'>window.alert('SU FACTURA ESTA " + estadoM + "')+ error;</script>");
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
            ModeloCodProceso = BuscarCodProceso(AmUsrLog);
            Response.Redirect("Ayuda.asp");
        }
    }
}