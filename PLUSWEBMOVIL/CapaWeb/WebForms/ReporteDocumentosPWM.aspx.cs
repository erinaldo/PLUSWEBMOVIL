using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using CapaProceso.GenerarPDF.FacturaElectronica;
using CapaDatos.Modelos;
using CapaProceso.ReslClientePdf;
using CapaDatos.Sql;

namespace CapaWeb.WebForms
{
    public partial class ReporteDocumentosPWM : System.Web.UI.Page
    {

        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();
        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        modelowmtfacturascab conscabcera1 = new modelowmtfacturascab();
        modelocabecerafactura cabecerafactura = new modelocabecerafactura();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        CabezeraFactura GuardarCabezera = new CabezeraFactura();
        List<modelowmtfacturascab> listaConsCab = null;
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();
        public string ComPwm;
        public string AmUsrLog;
        public string Ccf_tipo1 = "C";
        public string Ccf_tipo2 = null;
        public string Ccf_nro_trans = null;
        public string Ccf_estado = null;
        public string Ccf_cliente = null;
        public string Ccf_cod_docum = null;
        public string Ccf_serie_docum = null;
        public string Ccf_nro_docum = null;
        public string Ccf_diai = null;
        public string Ccf_mesi = null;
        public string Ccf_anioi = null;
        public string Ccf_diaf = null;
        public string Ccf_mesf = null;
        public string Ccf_aniof = null;
        string cod_proceso = "";
        string socio = null;
        string sesion = null;
        string serie;
        string numero;
        string cod_docum;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            { 
                RecuperarParametros();
                RecuperarCokie();
                ListaModelowmspclogo = consultaLogo.BuscartaLogo(ComPwm, AmUsrLog);
                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }

                 ConsultaLogoSql tipo_factura = new ConsultaLogoSql();
                 cod_proceso = "RCOMFELECT";
                 listaConsCab = null;
                 listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, cod_docum, serie,numero, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                foreach (var item1 in listaConsCab)
                {
                    conscabcera1 = item1;
                    break;
                }
                string tipo_doc = tipo_factura.TipoDocImprimir(ComPwm, cod_proceso, AmUsrLog);
          
                conscabcera = null;
                 conscabcera = buscarTipoFac(conscabcera1.nro_trans);
                Ccf_nro_trans = conscabcera1.nro_trans;

                if (conscabcera.tipo_nce.Trim() == "VTA" || conscabcera.tipo_nce.Trim() == "POS")
                {
                    switch (tipo_doc.Trim())
                    {
                        case "DEFECTO2":
                            PdfFacVTAV2 pdf1 = new PdfFacVTAV2();
                            string pathPdf1 = pdf1.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, conscabcera.tipo_nce.Trim(), conscabcera1.nro_trans);
                            Response.ContentType = "application/pdf";
                            Response.WriteFile(pathPdf1);
                            Response.End();
                            break;
                        case "DEFECTO3":
                            PdfFacVTAV3 pdf2 = new PdfFacVTAV3();
                            string pathPdf2 = pdf2.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, conscabcera.tipo_nce.Trim(), Ccf_nro_trans);
                            Response.ContentType = "application/pdf";
                            Response.WriteFile(pathPdf2);
                            Response.End();
                            break;
                        case "DEFECTO":
                            PdfFacturaVTA pdf = new PdfFacturaVTA();
                            string pathPdf = pdf.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, conscabcera.tipo_nce.Trim(), Ccf_nro_trans);
                            Response.ContentType = "application/pdf";
                            Response.WriteFile(pathPdf);
                            Response.End();
                            break;
                    }
                }
                else
                {

                    if (conscabcera.tipo_nce.Trim() == "VTAE")
                    {
                        Ccf_tipo2 = "VTAE";
                    }
                    else
                    {
                        Ccf_tipo2 = "POSE";
                    }

                    //Clase para pdf de cada empresa 
                    switch (tipo_doc.Trim())
                    {
                        case "DEFECTO3":
                            if (conscabcera.estado.Trim() == "C")
                            {
                                PdfFacVTAV3 pdf1 = new PdfFacVTAV3();
                                string pathPdf1 = pdf1.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, conscabcera.tipo_nce.Trim(), Ccf_nro_trans);
                                Response.ContentType = "application/pdf";
                                Response.WriteFile(pathPdf1);
                                Response.End();

                            }
                            else
                            {
                                PdfFacEleV3Default3 pdf1 = new PdfFacEleV3Default3();
                                string pathPdf1 = pdf1.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                                Response.ContentType = "application/pdf";
                                Response.WriteFile(pathPdf1);
                                Response.End();

                            }

                            break;
                        case "DEFECTO2":
                            if (conscabcera.estado.Trim() == "C")
                            {
                                PdfFacVTAV2 pdf1 = new PdfFacVTAV2();
                                string pathPdf1 = pdf1.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, conscabcera.tipo_nce.Trim(), Ccf_nro_trans);
                                Response.ContentType = "application/pdf";
                                Response.WriteFile(pathPdf1);
                                Response.End();

                            }
                            else
                            {
                                PdfFacEleV2Default2 pdf1 = new PdfFacEleV2Default2();
                                string pathPdf1 = pdf1.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                                Response.ContentType = "application/pdf";
                                Response.WriteFile(pathPdf1);
                                Response.End();

                            }

                            break;
                        case "DEFECTO":
                            PdfFacturaElectronica pdf = new PdfFacturaElectronica();
                            string pathPdf = pdf.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                            Response.ContentType = "application/pdf";
                            Response.WriteFile(pathPdf);
                            Response.End();
                            break;


                    }


                }
                    
               
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());

            }

        }
        public void RecuperarParametros()
        {
            try
            {
                serie = Request.QueryString["serie"];
                numero = Request.QueryString["numero"];
                 cod_docum = Request.QueryString["cod_docum"];
            }
            catch (Exception ex)
            {
                GuardarExcepciones("RecuperarParametros", ex.ToString());

            }

        }
        public void RecuperarCokie()
        {
            try
            {
                // lbl_error.Text = "";

                if (Request.Cookies["ComPwm"] != null)
                {
                    ComPwm = Request.Cookies["ComPwm"].Value;
                }
                else
                {
                    Response.Redirect("../Inicio.asp");
                }

                if (Request.Cookies["AmScNCod"] != null)
                {
                    socio = Request.Cookies["AmScNCod"].Value;
                }
                if (Request.Cookies["AmSesId"] != null)
                {
                    sesion = Request.Cookies["AmSesId"].Value;
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
                //Codigo empresa
                string empresa_codigo = ComPwm;
                Response.Cookies["empresa_codigo"].Value = empresa_codigo;
                //socio negocio
                // string socio_codigo = "100";
                Response.Cookies["socio_codigo"].Value = socio;
                Response.Cookies["usuario"].Value = AmUsrLog;
                Response.Cookies["sesion"].Value = sesion;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("RecuperarCokie", ex.ToString());

            }

        }

        public modelowmtfacturascab buscarTipoFac(string nro_trans)
        {
            try
            {



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
            ModeloExcepcion.proceso = "ReporteDocumentosPWM.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;

            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);

        }
    }
}