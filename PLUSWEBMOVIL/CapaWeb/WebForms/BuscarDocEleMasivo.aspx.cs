﻿using System;
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
using Ionic.Zip;

namespace CapaWeb.WebForms
{
    public partial class BuscarDocEleMasivo : System.Web.UI.Page
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
        List<modelowmtfacturascab> listaPathPdf = null;
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


                    fechainicio.Text = DateTime.Today.ToString("yyyy-MM-dd");
                    fechafin.Text = DateTime.Today.ToString("yyyy-MM-dd");
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
            ModeloExcepcion.proceso = "BuscarDocEleMasivo.aspx";
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
                DateTime Fechainicio = Convert.ToDateTime(fechainicio.Text);
                DateTime Fechafin = Convert.ToDateTime(fechafin.Text);
                string Ccf_estado = "F";
                string Ccf_cliente = txtCliente.Text.Trim();
                string Ccf_serie_docum = "xxx";
                string Ccf_nro_docum = "0";
                string Ccf_diai = string.Format("{0:00}", Fechainicio.Day);
                string Ccf_mesi = string.Format("{0:00}", Fechainicio.Month);
                string Ccf_anioi = Fechainicio.Year.ToString();
                string Ccf_diaf = string.Format("{0:00}", Fechafin.Day);
                string Ccf_mesf = string.Format("{0:00}", Fechafin.Month);
                string Ccf_aniof = Fechafin.Year.ToString();
                if(cbx_tipo1.SelectedValue =="NOR")
                {
                    if(cbx_tipo_doc.SelectedValue =="VTAE")
                    {
                        Ccf_tipo2 = "VTA";
                    }
                    if (cbx_tipo_doc.SelectedValue == "POSE")
                    {
                        Ccf_tipo2 = "POS";
                    }
                    if (cbx_tipo_doc.SelectedValue == "NDVE")
                    {
                        Ccf_tipo2 = "NDV";
                    }
                    if (cbx_tipo_doc.SelectedValue == "NC")
                    {
                        Ccf_tipo2 = "NC";
                    }
                    Ccf_estado ="0";
                }
                else
                {
                    Ccf_estado = "F";
                    Ccf_tipo2 = cbx_tipo_doc.SelectedValue.Trim();
                }

                listaConsCab = ConsultaCabe.ConsultaDocsXSucursal(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof, lbl_cod_suc.Text.Trim(), cbx_tipo1.SelectedValue.Trim());
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
                CargarGrilla();
                if (listaConsCab.Count > 0)
                {
                    lbl_fac_txt.Visible = true;
                    lbl_tot_doc.Visible = true;
                    lbl_tot_doc.Text = listaConsCab.Count.ToString();
                    btn_descargar.Visible = true;
                }
                else
                {
                    lbl_fac_txt.Visible = false;
                    lbl_tot_doc.Visible = false;
                    lbl_tot_doc.Text = "";
                    btn_descargar.Visible = false;
                }
            }

            catch (Exception ex)
            {
                GuardarExcepciones("Buscar_Click", ex.ToString());

            }
        }

       
        protected void btn_descargar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarGrilla();
                if (listaConsCab.Count > 0)
                {
                    using (ZipFile zip = new ZipFile())
                    {

                        foreach (var item in listaConsCab)
                        {


                            string pathPdf1 = null;
                            if (cbx_tipo1.SelectedValue == "NOR")
                            {
                                if (cbx_tipo_doc.SelectedValue == "POSE" || cbx_tipo_doc.SelectedValue == "VTAE")
                                {
                                    cod_proceso = "RCOMFELECT";
                                    pathPdf1 = generer_pdfElectronico.GenerarPDFFacturaNormal(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, item.tipo.Trim(), item.nro_trans.Trim());
                                }
                                if (cbx_tipo_doc.SelectedValue == "NC")
                                {
                                    cod_proceso = "RCOMNCELEC";
                                    pathPdf1 = generer_pdfElectronico.GenerarPDFNotaCreditoNormal(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, item.tipo.Trim(), item.nro_trans.Trim());
                                }
                                if (cbx_tipo_doc.SelectedValue == "NDVE")
                                {
                                    cod_proceso = "RCOMNDEB";
                                    pathPdf1 = generer_pdfElectronico.GenerarPDFNotaDebitoNormal(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, item.tipo.Trim(), item.nro_trans.Trim());
                                }
                            }
                            else
                            {
                                if (cbx_tipo_doc.SelectedValue == "POSE" || cbx_tipo_doc.SelectedValue == "VTAE")
                                {
                                    cod_proceso = "RCOMFELECT";
                                    pathPdf1 = generer_pdfElectronico.GenerarPDFFacturaElectronica(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, item.tipo.Trim(), item.nro_trans.Trim());
                                }
                                if (cbx_tipo_doc.SelectedValue == "NC")
                                {
                                    cod_proceso = "RCOMNCELEC";
                                    pathPdf1 = generer_pdfElectronico.GenerarPDFNotaCreditoElectronica(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, item.tipo.Trim(), item.nro_trans.Trim());
                                }
                                if (cbx_tipo_doc.SelectedValue == "NDVE")
                                {
                                    cod_proceso = "RCOMNDEB";
                                    pathPdf1 = generer_pdfElectronico.GenerarPDFNotaDebitoElectronica(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, item.tipo.Trim(), item.nro_trans.Trim());
                                }
                            }
                            var nombre_archivo = Path.GetFileName(pathPdf1);
                            var archivo_byte = File.ReadAllBytes(pathPdf1);
                            zip.AddEntry(nombre_archivo, archivo_byte);

                        }
                        var nombre_zip = "DocumentosComerciales.zip";
                        using (MemoryStream output = new MemoryStream())
                        {
                            zip.Save(Response.OutputStream);

                        }
                        Response.AppendHeader("content-disposition", "attachment; filename=" +nombre_zip);
                        Response.ContentType = "application/zip";
                        Response.End();
                    }

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_descargar_Click", ex.ToString());

            }
        }
    }

}