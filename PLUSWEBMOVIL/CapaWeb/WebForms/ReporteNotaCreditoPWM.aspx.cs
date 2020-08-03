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
    public partial class ReporteNotaCreditoPWM : System.Web.UI.Page
    {
   
        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();
        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        modelowmtfacturascab conscabcera1 = new modelowmtfacturascab();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        List<modelowmtfacturascab> listaConsCab = null;
        CabezeraFactura GuardarCabezera = new CabezeraFactura();

        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();
        public string ComPwm;
        public string AmUsrLog;
        public string Ccf_tipo1 = "C";
        public string Ccf_tipo2 = "NC";
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
        string cod_proceso = "RCOMNCELEC";
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
                cod_proceso = "RCOMNCELEC";
                ConsultaLogoSql tipo_factura = new ConsultaLogoSql();
                string tipo_doc = tipo_factura.TipoDocImprimir(ComPwm, cod_proceso, AmUsrLog);
                listaConsCab = null;
                listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, cod_docum, serie, numero, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                foreach (var item1 in listaConsCab)
                {
                    conscabcera1 = item1;
                    break;
                }
                Ccf_nro_trans = conscabcera1.nro_trans;
                conscabcera = null;
                conscabcera = buscarTipoFac(Ccf_nro_trans);
                if (conscabcera.tipo_nce.Trim() == "NCV" || conscabcera.tipo_nce.Trim() == "NCM")
                {
             
                    switch (tipo_doc.Trim())
                    {
                        case "DEFECTO2":

                            PdfNCV2Default2 pdf1 = new PdfNCV2Default2();
                            string pathPdf1 = pdf1.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, conscabcera.tipo_nce.Trim(), Ccf_nro_trans);
                            Response.ContentType = "application/pdf";
                            Response.WriteFile(pathPdf1);
                            Response.End();
                            break;
                        case "DEFECTO":
                            PdfNotaCredito pdf = new PdfNotaCredito();
                            string pathPdf = pdf.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, conscabcera.tipo_nce.Trim(), Ccf_nro_trans);
                            Response.ContentType = "application/pdf";
                            Response.WriteFile(pathPdf);
                            Response.End();
                            break;
                        case "DEFECTO3":
                            PdfNCV3Default3 pdf2 = new PdfNCV3Default3();
                            string pathPdf2 = pdf2.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, conscabcera.tipo_nce.Trim(), Ccf_nro_trans);
                            Response.ContentType = "application/pdf";
                            Response.WriteFile(pathPdf2);
                            Response.End();
                            break;
                    }


                }
                else
                {
                    switch (tipo_doc.Trim())
                    {
                        case "DEFECTO2":
                            if (conscabcera.estado.Trim() == "C")
                            {

                                PdfNCV2Default2 pdf1 = new PdfNCV2Default2();
                                string pathPdf1 = pdf1.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, conscabcera.tipo_nce.Trim(), Ccf_nro_trans);
                                Response.ContentType = "application/pdf";
                                Response.WriteFile(pathPdf1);
                                Response.End();
                                break;

                            }
                            else
                            {
                                PdfNCEleV2Default2 pdf1 = new PdfNCEleV2Default2();
                                string pathPdf1 = pdf1.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                                Response.ContentType = "application/pdf";
                                Response.WriteFile(pathPdf1);
                                Response.End();
                                break;
                            }
                        case "DEFECTO3":
                            if (conscabcera.estado.Trim() == "C")
                            {

                                PdfNCV3Default3 pdf1 = new PdfNCV3Default3();
                                string pathPdf1 = pdf1.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, conscabcera.tipo_nce.Trim(), Ccf_nro_trans);
                                Response.ContentType = "application/pdf";
                                Response.WriteFile(pathPdf1);
                                Response.End();
                                break;

                            }
                            else
                            {
                                PdfNCEleV3Default3 pdf1 = new PdfNCEleV3Default3();
                                string pathPdf1 = pdf1.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                                Response.ContentType = "application/pdf";
                                Response.WriteFile(pathPdf1);
                                Response.End();
                                break;
                            }

                        case "DEFECTO":

                            PdfNotaCreditoElectronica pdf = new PdfNotaCreditoElectronica();
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
            ModeloExcepcion.proceso = "ReporteNotaCreditoPWM.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
        }
        public void RecuperarCokie()
        {
            try
            {


                if (Request.Cookies["ComPwm"] != null)
                {
                    ComPwm = Request.Cookies["ComPwm"].Value;
                }

                if (Request.Cookies["ComPwm"] != null)
                {
                    AmUsrLog = Request.Cookies["AmUsrLog"].Value;

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("RecuperarCokie", ex.ToString());

            }
        }
    }
}