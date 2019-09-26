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

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();

        modelowmtfacturascab conscabceraTipo = new modelowmtfacturascab();
        public string numerador = "trans";
        public string ComPwm;
        public string AmUsrLog;
        public string cod_proceso;     
        public string Ccf_tipo1 = "C";
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
        public string Ven__cod_tipotit = "cliente";
        public string Ven__cod_tit = " ";
       


        public string EstF_proceso = "RCOMFACT";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
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
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());
            }
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
        public void GuardarExcepciones(string metodo, string error)
        {
           
            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "BuscarFacturas.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Today;
            ModeloExcepcion.usuario_mod = AmUsrLog;
           
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción" + metodo + "." + " Por favor notificar al administrador.";

        }
        private void CargarRolesUsuario()
        {
            try
            {
                lbl_error.Text = "";
                //Rol crear factura nueva
                ListaModelosRoles = ConsultaRoles.BuscarRolNuevo(AmUsrLog);
                int count1 = 0;
                foreach (var item in ListaModelosRoles)
                {
                    count1++;

                }

                if (count1 > 0)
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
                ListaModelosRoles = ConsultaRoles.BuscarRolEliminar(AmUsrLog);
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
                ListaModelosRoles = ConsultaRoles.BuscarRolPrint(AmUsrLog);
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
            catch (Exception ex)
            {
                GuardarExcepciones("CargarRolesUsuario", ex.ToString());
            }

        }
        private void CargarGrillaInicial()
        {
            try
            {
                lbl_error.Text = "";
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
            catch (Exception ex)
            {
                GuardarExcepciones("CargarGrillaInicial", ex.ToString());
            }


        }
        public void cargarListaDesplegables()
        {
            try
            {
                lbl_error.Text = "";
                //Lista Estados facturas
                Listaestados = Consultaestados.ConsultaEstadosFac(EstF_proceso);
                estados.DataSource = Listaestados;

                estados.DataTextField = "nom_estado";
                estados.DataValueField = "estado";
                estados.DataBind();

                estados.Items.Insert(0, new ListItem("TODOS", "0"));
                estados.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("cargarListaDesplegables", ex.ToString());
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

        protected void NuevaFactura_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                //1 primero creo un objeto Clave/Valor de QueryString 
                QueryString qs = new QueryString();

                //2 voy a agregando los valores que deseo
                qs.Add("TRN", "INS");
                qs.Add("Id", "");
                Response.Redirect("Factura.aspx" + Encryption.EncryptQueryString(qs).ToString());
            }
            catch (Exception ex)
            {
                GuardarExcepciones("NuevaFactura_Click", ex.ToString());
            }

        }
        private void CargarGrilla()
        {
            try
            {
                lbl_error.Text = "";
                DateTime Fechainicio = Convert.ToDateTime(fechainicio.Text);
                DateTime Fechafin = Convert.ToDateTime(fechafin.Text);
                string Ccf_cliente = txtCliente.Text;
                Ccf_tipo2 = cbx_tipo_factura.SelectedValue.Trim();
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
            catch (Exception ex)
            {
                GuardarExcepciones("CargarGrilla", ex.ToString());
            }


        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
            DateTime Fechainicio = Convert.ToDateTime(fechainicio.Text);
            DateTime Fechafin = Convert.ToDateTime(fechafin.Text);
                Ccf_tipo2 = cbx_tipo_factura.SelectedValue.Trim();
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
            catch (Exception ex)
            {
                GuardarExcepciones("Buscar_Click", ex.ToString());
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
                string estadoM = "";
                string estadoIM = "";

              
                switch (e.CommandName) //ultilizo la variable para la opcion
                {

                    case "Editar":
                        try
                        {
                            lbl_error.Text = "";
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
                                    this.Page.Response.Write("<script language='JavaScript'>window.alert('FACTURA ESTÁ " + estadoM + ", NO SE PUEDE EDITAR')+ error;</script>");
                                    break;

                            }

                            break;
                        }
                         
                        catch (Exception ex)
                              {
                            GuardarExcepciones("Grid_ItemCommand, Editar", ex.ToString());
                               }
                        break;

                    case "Imprimir":
                        try
                        {
                            lbl_error.Text = "";
                            Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                            estadoM = Convert.ToString(((Label)e.Item.Cells[5].FindControl("nom_corto")).Text);
                            //cOSNULTA BUSCAR TIPO DE FACTURA
                            conscabceraTipo = null;
                            conscabceraTipo = buscarTipoFac(Id.ToString());
                            if (conscabcera.tipo_nce.Trim() == "VTA")
                            {
                                qs.Add("Id", Id.ToString());
                                Response.Write("<script>window.open('" + "ReporteFactura.aspx" + Encryption.EncryptQueryString(qs).ToString() + "')</script>");
                            }
                            else
                            {
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
                            }
                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("Grid_ItemCommand, Imprimir", ex.ToString());
                        }
                        break;

                    case "Eliminar":
                        try
                        {
                            Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);

                            estadoIM = Convert.ToString(((Label)e.Item.Cells[5].FindControl("nom_corto")).Text);
                            //cOSNULTA BUSCAR TIPO DE FACTURA
                            conscabceraTipo = null;
                            conscabceraTipo = buscarTipoFac(Id.ToString());
                            Ccf_tipo2 = conscabceraTipo.tipo_nce.Trim();
                            switch (estadoIM)
                            {
                                case "CONTABILIZADO":

                                    this.Page.Response.Write("<script language='JavaScript'>window.alert('LA  FACTURA ESTÁ EN ESTADO " + estadoIM + " , POR FAVOR ANULARLA MEDIANTE NOTA DE CRÉDITO')+ error;</script>");
                                    break;
                                case "FINALIZADO":

                                    this.Page.Response.Write("<script language='JavaScript'>window.alert('LA  FACTURA ESTÁ EN ESTADO " + estadoIM + " , POR FAVOR ANULARLA MEDIANTE NOTA DE CRÉDITO')+ error;</script>");
                                    break;
                                default:
                                    Encabezado encabezado = new Encabezado();
                                    conscabcera = null;
                                    conscabcera = buscarCabezeraFactura(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Convert.ToString(Id));
                                    Response.Redirect(Modelowmspclogo.sitio_app + conscabcera.pagina_elimina + "?nro_trans=" + Convert.ToString(Id) + "&cod_docum=" + conscabcera.cod_docum.Trim() + "&serie_docum=" + conscabcera.serie_docum.Trim() + "&nro_docum=" + conscabcera.nro_docum.Trim() + "&tipo="+ conscabceraTipo.tipo_nce.Trim());
                                    break;

                            }
                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("Grid_ItemCommand, Eliminar", ex.ToString());
                        }
                        break;


                    case "Impuestos":
                        try
                        {
                            Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);

                            ListaModeloimpuesto = consultaImpuesto.BuscarImpuestoRest(AmUsrLog, ComPwm, Id.ToString(), "0");
                            Session["listaImpuestos"] = ListaModeloimpuesto;
                            this.Page.Response.Write("<script language='JavaScript'>window.open('./FormDetalleImpuestos.aspx', 'Detalle Impuesto', 'top=100,width=800 ,height=400, left=400');</script>");
                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("Grid_ItemCommand, Impuestos", ex.ToString());
                        }
                        break;

                    case "Ver":
                        try
                        {
                            Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);


                            qs.Add("TRN", "VER");
                            qs.Add("Id", Id.ToString());
                            Response.Redirect("Factura.aspx" + Encryption.EncryptQueryString(qs).ToString());
                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("Grid_ItemCommand, Ver", ex.ToString());
                        }
                        break;

                    case "Mostrar":
                        try
                        {

                            Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                            estadoM = Convert.ToString(((Label)e.Item.Cells[5].FindControl("nom_corto")).Text);
                            //cOSNULTA BUSCAR TIPO DE FACTURA
                            conscabceraTipo = null;
                            conscabceraTipo = buscarTipoFac(Id.ToString());
                            if (conscabceraTipo.tipo_nce.Trim() == "VTA")
                            {

                                this.Page.Response.Write("<script language='JavaScript'>window.alert('SU FACTURA NO TIENE HABILITADA ESTA OPCION')+ error;</script>");
                            }
                            else
                            {
                                qs.Add("TRN", "MTR");
                                qs.Add("Id", Id.ToString());
                                Response.Redirect("PortalFacturas.aspx" + Encryption.EncryptQueryString(qs).ToString());

                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("Grid_ItemCommand, Mostrar", ex.ToString());
                        }
                        break;

                    case "Reenviar":
                        try
                        {
                            Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                            estadoM = Convert.ToString(((Label)e.Item.Cells[5].FindControl("nom_corto")).Text);
                            //cOSNULTA BUSCAR TIPO DE FACTURA
                            conscabceraTipo = null;
                            conscabceraTipo = buscarTipoFac(Id.ToString());
                            if (conscabceraTipo.tipo_nce.Trim() == "VTA")
                            {

                                this.Page.Response.Write("<script language='JavaScript'>window.alert('SU FACTURA NO TIENE HABILITADA ESTA OPCION')+ error;</script>");
                            }
                            else
                            {
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
                        catch (Exception ex)
                        {
                            GuardarExcepciones("Grid_ItemCommand, Reenviar", ex.ToString());
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Grid_ItemCommand", ex.ToString());
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

        public modelowmtfacturascab buscarCabezeraFactura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
           
            try
            {
                lbl_error.Text = "";
                listaConsCab = ConsultaCabe.ConsultaCabFacura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
               
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                  
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

        public modeloRolesFacturacion BuscarRolNuevo(string usuario)
        {
            try
            {
                lbl_error.Text = "";
                ListaModelosRoles = ConsultaRoles.BuscarRolNuevo(usuario);
                ModeloRoles = null;
                foreach (modeloRolesFacturacion item in ListaModelosRoles)
                {
                    
                    ModeloRoles = item;

                }
                return ModeloRoles;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarRolNuevo", ex.ToString());
                return null;

            }
        }

        public modeloRolesFacturacion BuscarRolEditar(string usuario)
        {
            try
            {
                lbl_error.Text = "";
                ListaModelosRoles = ConsultaRoles.BuscarRolEditar(usuario);
                ModeloRoles = null;
                foreach (modeloRolesFacturacion item in ListaModelosRoles)
                {
                    
                    ModeloRoles = item;

                }
                return ModeloRoles;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarRolEditar", ex.ToString());
                return null;

            }
        }

        public modeloRolesFacturacion BuscarRolEliminar(string usuario)
        {
            try
            {
                lbl_error.Text = "";
                ListaModelosRoles = ConsultaRoles.BuscarRolEditar(usuario);
                ModeloRoles = null;
                foreach (modeloRolesFacturacion item in ListaModelosRoles)
                {
                    
                    ModeloRoles = item;

                }
                return ModeloRoles;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarRolEliminar", ex.ToString());
                return null;

            }
        }

        public modeloRolesFacturacion BuscarRolImprimir(string usuario)
        {
            try
            {
                lbl_error.Text = "";
                ListaModelosRoles = ConsultaRoles.BuscarRolEditar(usuario);
                ModeloRoles = null;
                foreach (modeloRolesFacturacion item in ListaModelosRoles)
                {
                    
                    ModeloRoles = item;

                }
                return ModeloRoles;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarRolImprimir", ex.ToString());
                return null;

            }
        }
        public modeloRolesFacturacion BuscarAccesoFactura(string usuario)
        {
            try
            {
                lbl_error.Text = "";
                ListaModelosRoles = ConsultaRoles.BuscarAccesoFactura(usuario);

              
                ModeloRoles = null;
                foreach (modeloRolesFacturacion item in ListaModelosRoles)
                {
                    
                    ModeloRoles = item;

                }
                return ModeloRoles;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarAccesoFactura", ex.ToString());
                return null;

            }
        }

        public modeloCodProcesoFactura BuscarCodProceso(string cod_proceso)
        {
            try
            {
                lbl_error.Text = "";

                ListaModeloCodProceso = ConsultaCodProceso.DatosCodProceso(cod_proceso);

                
                ModeloCodProceso = null;
                foreach (modeloCodProcesoFactura item in ListaModeloCodProceso)
                {
                    
                    ModeloCodProceso = item;

                }
                return ModeloCodProceso;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarCodProceso", ex.ToString());
                return null;

            }

        }
        public modeloRolesFacturacion BuscarCargarTablero(string usuario)
        {
            try
            {
                lbl_error.Text = "";
                ListaModelosRoles = ConsultaRoles.BuscarCargarTablero(usuario);

                  ModeloRoles = null;
                foreach (modeloRolesFacturacion item in ListaModelosRoles)
                {
                  
                    ModeloRoles = item;

                }
                return ModeloRoles;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarCargarTablero", ex.ToString());
                return null;

            }
        }
        protected void ImgAyuda_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                //Enviar codigo de porceso = nombre del proceso
                //rEcibir de cookie
                ModeloCodProceso = BuscarCodProceso(cod_proceso);
                Response.Redirect("Ayuda.asp" + "?cod_proceso=" + cod_proceso);
            }
            catch (Exception ex)
            {
                GuardarExcepciones("ImgAyuda_Click", ex.ToString());
              
            }
        }

       
    }
}