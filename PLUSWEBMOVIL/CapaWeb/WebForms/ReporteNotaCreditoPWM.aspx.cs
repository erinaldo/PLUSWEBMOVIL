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
using CapaProceso.FacturaMasiva;
using Newtonsoft.Json;
using Ionic.Zip;

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
        GenerarPDFDocumentos generer_pdfElectronico = new GenerarPDFDocumentos();
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
                JsonDocumentosPWMItem modeloDoc = new JsonDocumentosPWMItem();
                string json = "";
                json = Request.QueryString["jsonDocumento"];

                List<JsonDocumentosPWMItem> ListDoc = (List<JsonDocumentosPWMItem>)Newtonsoft.Json.JsonConvert.DeserializeObject((json), typeof(List<JsonDocumentosPWMItem>));

                foreach (var item in ListDoc)
                {
                    modeloDoc = item;
                    break;
                }

                ComPwm = modeloDoc.AmComComPwm;
                AmUsrLog = modeloDoc.AmUsrLog;

                ListaModelowmspclogo = consultaLogo.BuscartaLogo(ComPwm, AmUsrLog);
                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }
                cod_proceso = "RCOMNCELEC";

                if (ListDoc.Count > 1)
                {
                    using (ZipFile zip = new ZipFile())
                    {

                        foreach (var item in ListDoc)
                        {
                            string pathPdf1 = null;
                            listaConsCab = null;
                            listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, item.XcCxCSer.Trim(), item.XcCxCNum.Trim(), Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                            foreach (var item1 in listaConsCab)
                            {
                                conscabcera = item1;
                                break;
                            }
                            Ccf_nro_trans = conscabcera.nro_trans;

                            if (conscabcera.tipo.Trim() == "NCV" || conscabcera.tipo.Trim() == "NCM")
                            {
                                pathPdf1 = generer_pdfElectronico.GenerarPDFNotaCreditoNormal(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, conscabcera.tipo.Trim(), Ccf_nro_trans);
                            }

                            else
                            {
                                if (conscabcera.estado.Trim() == "C")
                                {
                                    pathPdf1 = generer_pdfElectronico.GenerarPDFNotaCreditoNormal(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, conscabcera.tipo.Trim(), Ccf_nro_trans);
                                }

                                else
                                {
                                    pathPdf1 = generer_pdfElectronico.GenerarPDFNotaCreditoElectronica(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, conscabcera.tipo.Trim(), Ccf_nro_trans);

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
                        Response.AppendHeader("content-disposition", "attachment; filename=" + nombre_zip);
                        Response.ContentType = "application/zip";
                        Response.End();
                    }
                }
                else
                {
                    listaConsCab = null;
                    listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, modeloDoc.XmTDcCod.Trim(), modeloDoc.XcCxCSer.Trim(), modeloDoc.XcCxCNum.Trim(), Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                    foreach (var item1 in listaConsCab)
                    {
                        conscabcera = item1;
                        break;
                    }

                    Ccf_nro_trans = conscabcera.nro_trans;

                    if (conscabcera.tipo.Trim() == "NCV" || conscabcera.tipo.Trim() == "NCM")
                    {

                        string pathPdf1 = generer_pdfElectronico.GenerarPDFNotaCreditoNormal(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, conscabcera.tipo.Trim(), Ccf_nro_trans);
                        Response.ContentType = "application/pdf";
                        Response.WriteFile(pathPdf1);
                        Response.End();
                    }

                    else
                    {
                        if (conscabcera.estado.Trim() == "C")
                        {
                            string pathPdf1 = generer_pdfElectronico.GenerarPDFNotaCreditoNormal(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, conscabcera.tipo.Trim(), Ccf_nro_trans);
                            Response.ContentType = "application/pdf";
                            Response.WriteFile(pathPdf1);
                            Response.End();
                        }

                        else
                        {
                            string pathPdf1 = generer_pdfElectronico.GenerarPDFNotaCreditoElectronica(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, conscabcera.tipo.Trim(), Ccf_nro_trans);
                            Response.ContentType = "application/pdf";
                            Response.WriteFile(pathPdf1);
                            Response.End();
                        }
                    }
                }
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
      
    }
}