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
using CapaDatos.Sql;
using CapaProceso.FacturaMasiva;

namespace CapaWeb.WebForms
{
    public partial class ReenvioMasivoDE : System.Web.UI.Page
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

        Consultawmsptitulares ConsultaTitulares = new Consultawmsptitulares();
        public List<modelowmspctitulares> lista = null;
        modelowmspctitulares cliente = new modelowmspctitulares();

        public List<modelowmspcfacturasWMimpuRest> ListaModeloimpuesto = new List<modelowmspcfacturasWMimpuRest>();
        public modelowmspcfacturasWMimpuRest ModeloImpuesto = new modelowmspcfacturasWMimpuRest();
        public ConsultawmspcfacturasWMimpuRest consultaImpuesto = new ConsultawmspcfacturasWMimpuRest();

        public List<JsonRespuestaDE> ListaModelorespuestaDs = null;
        public JsonRespuestaDE ModeloResQr = new JsonRespuestaDE();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();

        public modeloUsuariosucursal ModelousuarioSucursal = new modeloUsuariosucursal();
        public List<modeloUsuariosucursal> ListaModeloUsuarioSucursal = new List<modeloUsuariosucursal>();
        public ConsultawmusuarioSucursal ConsultaUsuxSuc = new ConsultawmusuarioSucursal();
        public ConsultausuarioSucursal consultaUsuarioSucursal = new ConsultausuarioSucursal();

        Enviarcorreocliente enviarcorreocliente = new Enviarcorreocliente();
        GenerarPDFDocumentos generer_pdfElectronico = new GenerarPDFDocumentos();

         CabezeraFactura ActualizarEstadoFact = new CabezeraFactura();
        ReenvioDocsElectronicos enviar_doc = new ReenvioDocsElectronicos();

        List<modelowmtfacturascab> ListaDoc = new List<modelowmtfacturascab>();
        modelowmtfacturascab modeloDosc = new modelowmtfacturascab();
        List<modelowmtfacturascab> listaRespuesta = new List<modelowmtfacturascab>();
        List<modelowmtfacturascab> listaRespuestaVer = new List<modelowmtfacturascab>();
        public string numerador = "trans";
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
        string tipo_envio = null;
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

                    //Cargar la sucursal del usuario logeado
                    ListaModeloUsuarioSucursal = ConsultaUsuxSuc.UnicoUsuarioSucursal(ComPwm, AmUsrLog, ""); //Solo se envia empresa y usuario
                    if (ListaModeloUsuarioSucursal.Count == 0)
                    {
                        lbl_mensaje.Text = "Usuario no tiene sucursal asignada, por favor asignar sucursarl para continuar.";
                    }
                    else
                    {
                        foreach (var item in ListaModeloUsuarioSucursal)
                        {
                            ModelousuarioSucursal = item;
                            break;
                        }
                        lbl_cod_suc.Text = ModelousuarioSucursal.cod_sucursal.Trim();
                        lbl_sucursal.Text = "-" + ModelousuarioSucursal.nom_sucursal.Trim();
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
            ModeloExcepcion.proceso = "ReenvioMasivoDE.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

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
            try
            {
                lbl_error.Text = "";
               
                Ccf_estado = "C";
                Ccf_tipo2 = cbx_tipo_doc.SelectedValue.Trim();

                listaConsCab = ConsultaCabe.ConsultaDocsElectronicosXSucursal(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof, lbl_cod_suc.Text.Trim());
                Grid.DataSource = listaConsCab;
                Grid.DataBind();
                Grid.Height = 100;
            }

            catch (Exception ex)
            {
                GuardarExcepciones("CargarGrilla", ex.ToString());

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
                //--------------------------------DATOS PARA LOS CASOS--------------------------------
                Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                estadoM = Convert.ToString(((Label)e.Item.Cells[5].FindControl("nom_corto")).Text);
                Ccf_nro_trans = Id.ToString();
                //Saber si en nc o factura
                listaConsCab = ConsultaCabe.ConsultaNCTransPadre(Id.ToString());
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                    conscabcera = item;
                }
                Ccf_tipo2 = conscabcera.tipo_nce;
                //Buscar el xml TRAE TODAS LAS RESPUESTAS
                ListaModelorespuestaDs = consultaRespuestaDS.ConsultaRespuestaQr(Id.ToString());
                foreach (var item in ListaModelorespuestaDs)
                {
                    if (item.xml != "")
                    {
                        ModeloResQr = item;
                    }

                }
                switch (e.CommandName) //ultilizo la variable para la opcion
                {


                    case "Reenviar":
                        try
                        {
                            switch (estadoM)
                            {
                                case "FINALIZADO":

                                    string pathPdf = "";
                                    string StringXml = ModeloResQr.xml;
                                    string pathTemporal = Modelowmspclogo.pathtmpfac;
                                    string nombreXml = ModeloResQr.cufe.Trim() + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".xml";
                                    string pathXml = pathTemporal + nombreXml;
                                    File.WriteAllText(pathXml, StringXml);

                                    if (conscabcera.tipo_nce == "NCVE" || conscabcera.tipo_nce == "NCME")
                                    {
                                        //Tipo NCE siempre trae lleno cuando es nc
                                        cod_proceso = "RCOMNCELEC";
                                        pathPdf = generer_pdfElectronico.GenerarPDFNotaCreditoElectronica(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, conscabcera.tipo_nce.Trim(), Ccf_nro_trans);
                                    }
                                    else
                                    {
                                        if (conscabcera.tipo_nce == "VTAE" || conscabcera.tipo_nce == "POSE")
                                        {
                                            cod_proceso = "RCOMFELECT";
                                            pathPdf = generer_pdfElectronico.GenerarPDFFacturaElectronica(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, conscabcera.tipo_nce.Trim(), Ccf_nro_trans);

                                        }
                                        else
                                        {
                                            if (conscabcera.tipo_nce == "NDVE")
                                            {
                                                cod_proceso = "RCOMFELECT";
                                                pathPdf = generer_pdfElectronico.GenerarPDFNotaDebitoElectronica(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, conscabcera.tipo_nce.Trim(), Ccf_nro_trans);

                                            }
                                        }
                                    }


                                    Boolean error = enviarcorreocliente.EnviarCorreoRemitente(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Id.ToString(), pathPdf, pathXml);
                                    if (error == false)
                                    {
                                        lbl_error.Text = "Ocurrio un problema al enviar por favor verifique que el documento sea electronico y las credenciales";
                                    }
                                    else
                                    {
                                        lbl_error.Text = "Se envío correctamente el documento";
                                    }
                                    break;
                                default:
                                    this.Page.Response.Write("<script language='JavaScript'>window.alert('SU DOCUMENTO ESTA " + estadoM + "')+ error;</script>");
                                    break;

                            }

                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("Grid_ItemCommand, Reenviar Remitente", ex.ToString());

                        }
                        break;
                    case "Reenviar Cliente": //envio de correo directamente al cliente
                        try
                        {
                            switch (estadoM)
                            {
                                case "FINALIZADO":

                                    string pathPdf = "";
                                    string StringXml = ModeloResQr.xml;
                                    string pathTemporal = Modelowmspclogo.pathtmpfac;
                                    string nombreXml = ModeloResQr.cufe.Trim() + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".xml";
                                    string pathXml = pathTemporal + nombreXml;
                                    File.WriteAllText(pathXml, StringXml);

                                    if (conscabcera.tipo_nce == "NCVE" || conscabcera.tipo_nce == "NCME")
                                    {
                                        //Tipo NCE siempre trae lleno cuando es nc
                                        cod_proceso = "RCOMNCELEC";
                                        pathPdf = generer_pdfElectronico.GenerarPDFNotaCreditoElectronica(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, conscabcera.tipo_nce.Trim(), Ccf_nro_trans);
                                    }
                                    else
                                    {
                                        if (conscabcera.tipo_nce == "VTAE" || conscabcera.tipo_nce == "POSE")
                                        {
                                            cod_proceso = "RCOMFELECT";
                                            pathPdf = generer_pdfElectronico.GenerarPDFFacturaElectronica(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, conscabcera.tipo_nce.Trim(), Ccf_nro_trans);

                                        }
                                        else
                                        {
                                            if (conscabcera.tipo_nce == "NDVE")
                                            {
                                                cod_proceso = "RCOMFELECT";
                                                pathPdf = generer_pdfElectronico.GenerarPDFNotaDebitoElectronica(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, conscabcera.tipo_nce.Trim(), Ccf_nro_trans);

                                            }
                                        }
                                    }





                                    Boolean error = enviarcorreocliente.EnviarCorreoCliente(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Id.ToString(), pathPdf, pathXml);

                                    if (error == false)
                                    {
                                        lbl_error.Text = "Ocurrio un problema al enviar por favor verifique que el documento sea electronico y las credenciales";
                                    }
                                    else
                                    {
                                        lbl_error.Text = "Se envío correctamente el documento";
                                    }
                                    break;
                                default:
                                    this.Page.Response.Write("<script language='JavaScript'>window.alert('SU DOCUMENTO ESTA " + estadoM + "')+ error;</script>");
                                    break;

                            }

                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("Grid_ItemCommand, Reenviar Cliente", ex.ToString());

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

        protected void Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                Grid.Visible = false;
                btn_reenviarpdf.Enabled = true;
                BtnIniciar.Enabled = true;
                CargarGrilla();
                if (listaConsCab.Count > 0)
                {
                    lbl_fac_txt.Visible = true;
                    lbl_tot_doc.Visible = true;
                    lbl_tot_doc.Text = listaConsCab.Count.ToString();
                    BtnIniciar.Visible = true;
                    btn_reenviarpdf.Visible = true;
                }
                else
                {
                    lbl_fac_txt.Visible = false;
                    lbl_tot_doc.Visible = false;
                    lbl_tot_doc.Text = "";
                    BtnIniciar.Visible = false;
                    btn_reenviarpdf.Visible = false;
                }
            }

            catch (Exception ex)
            {
                GuardarExcepciones("Buscar_Click", ex.ToString());

            }
        }

       

        //PROGRESS BAR
        private int Prop_CoTareas
        {
            get
            {
                if (ViewState["CoTareas"] == null)
                {
                    ViewState["CoTareas"] = 0;
                }
                return (int)ViewState["CoTareas"];
            }

            set
            {
                ViewState["CoTareas"] = value;
            }
        }

        private int Prop_TotalTareas = 0;


        private int f_PorcentajeAvance(int Par_TotalTareas, int Par_TareaActual)
        {
            int liPorcentaje = 0;
            //aplicar una regla de 3 simple
            liPorcentaje = (Par_TareaActual * 100) / Par_TotalTareas;
            return liPorcentaje;
        }

        private int f_ancho_control_porcentaje(int Par_AnchoTotalControl, int Par_Porcentaje)
        {
            int liAnchoControl = 0;
            liAnchoControl = (Par_Porcentaje * Par_AnchoTotalControl) / 100;
            return liAnchoControl;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

            Prop_TotalTareas = Convert.ToInt16(lbl_tot_doc.Text);
            //limitar el numero de tareas al total de tareas a realizar
            if (Prop_CoTareas <= Prop_TotalTareas)
            {
                int liPorcentajeAvance = 0;

                //contador de tarea??
                Prop_CoTareas += 1;

                //tarea actual con total tareas
                LblAvance.Text = Prop_CoTareas.ToString() + " de " + Prop_TotalTareas.ToString();

                //porcentaje de avance segun el numero de tareas
                liPorcentajeAvance = f_PorcentajeAvance(Prop_TotalTareas, Prop_CoTareas);
                LblPorcentajeAvance.Text = liPorcentajeAvance.ToString() + "%";

                //barra de progreso
                LblProgressBar.Visible = true;
                LblProgressBar.Width = f_ancho_control_porcentaje(400, liPorcentajeAvance);

                //tareas a realizar poner todo el codigo para facturar electronicamente
                string error_fac = null;
                ListaDoc = (Session["ListaDocs"] as List<modelowmtfacturascab>);
                tipo_envio = Session["tipo_envio"].ToString();
                foreach (var item in ListaDoc)
                {
                    modeloDosc = item;
                    break;
                }

                try
                {
                    if (ListaDoc.Count>0)
                    {
                        if (tipo_envio == "DOC")
                        {
                            string respuesta = enviar_doc.ReenviarDocumentoDIAN(ComPwm, AmUsrLog, modeloDosc.tipo.Trim(), modeloDosc.nro_trans.Trim(), modeloDosc.doc_adjunto, Modelowmspclogo.version_fe.Trim(), Modelowmspclogo.pathtmpfac);
                            foreach (var item in ListaDoc)
                            {
                                if (item.nro_trans == modeloDosc.nro_trans)
                                {
                                    ListaDoc.Remove(item);
                                    Session["LisataDocs"] = ListaDoc;
                                }
                            }
                        }
                        else
                        {
                            string respuesta = enviar_doc.ReenviarPDFDIAN(ComPwm, AmUsrLog, modeloDosc.tipo.Trim(), modeloDosc.nro_trans.Trim(), modeloDosc.doc_adjunto, Modelowmspclogo.version_fe.Trim(), Modelowmspclogo.pathtmpfac);
                            foreach (var item in ListaDoc)
                            {
                                if (item.nro_trans == modeloDosc.nro_trans)
                                {
                                    ListaDoc.Remove(item);
                                    Session["LisataDocs"] = ListaDoc;
                                }
                            }
                        }

                    }
            
                }
                catch (Exception aee)
                {

                    throw;
                }

                //.....
            }

            if (Prop_CoTareas == Prop_TotalTareas)
            {
                Prop_CoTareas = 0;
                Timer1.Enabled = false;
                LblAvance.Text = "Tarea finalizada";
                BtnIniciar.Visible = false;
                btn_reenviarpdf.Visible = false;
                btn_limpiar.Visible = true;
                CargarGrilla();
                if (listaConsCab.Count > 0)
                {
                    Grid.Visible = true;
                    lbl_lisdoc.Visible = true;
                }else
                {
                    lbl_error_factura.Text = "Documentos autorizados correctamente";
                    lbl_error_factura.Visible = true;
                }
                Session.Remove("LisataDocs");
                Session.Remove("tipo_envio");
            }
        }
        protected void BtnIniciar_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = true;
            Session["tipo_envio"] = "DOC";
            BtnIniciar.Enabled = false;
            btn_reenviarpdf.Enabled = false;
            Prop_TotalTareas = 10;
            Documento();
        }
        public void Documento()
        {
            CargarGrilla();
            Session["ListaDocs"]= listaConsCab;
            
        }

        protected void btn_reenviarpdf_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = true;
            Session["tipo_envio"] = "PDF";
            btn_reenviarpdf.Enabled = false;
            BtnIniciar.Enabled = false;
            Prop_TotalTareas = 10;
            Documento();
        }

        protected void btn_limpiar_Click(object sender, EventArgs e)
        {
            //limpiar todas las pantallas

            LblPorcentajeAvance.Text = "";
            LblAvance.Text = "";
            btn_limpiar.Visible = false;
            LblProgressBar.Width = 0;
            Grid.Visible = false;
            lbl_lisdoc.Visible = false;
            lbl_error_factura.Text = "";
            lbl_error_factura.Visible = false;
            lbl_tot_doc.Text = "";
                
        }
    }
}