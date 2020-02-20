using CapaWeb.Urlencriptacion;
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

namespace CapaWeb.WebForms
{
    public partial class ReporteFactura : System.Web.UI.Page
    {
        public string ComPwm;
        public string AmUsrLog;       
        public string Ccf_tipo1 = "C";
        public string Ccf_tipo2 = "VTAE";
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


        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();
        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        modelocabecerafactura cabecerafactura = new modelocabecerafactura();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        CabezeraFactura GuardarCabezera = new CabezeraFactura();
        List<modelowmtfacturascab> listaConsCab = null;
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
              

                RecuperarCokie();
                ListaModelowmspclogo = consultaLogo.BuscartaLogo(ComPwm, AmUsrLog);
                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }

                QueryString qs = ulrDesencriptada();
                Int64 id = Int64.Parse(qs["Id"].ToString());
                Ccf_nro_trans = id.ToString();

                //Buscar que tipo de factura es pose / vtae
                conscabcera = null;
                conscabcera = buscarTipoFac(Ccf_nro_trans);
                if (conscabcera.tipo_nce.Trim() == "VTA" || conscabcera.tipo_nce.Trim() == "POS")
                {
                    if (conscabcera.estado.Trim() == "C")
                    {
                        GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "F");
                    }
                   
                    //Clase para pdf de cada empresa 
                    switch (Modelowmspclogo.pdf_fe.Trim())
                    {
                        case "DEFECTO2":
                            PdfFacVTAV2 pdf1 = new PdfFacVTAV2();
                            string pathPdf1 = pdf1.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, conscabcera.tipo_nce.Trim(), Ccf_nro_trans);
                            Response.ContentType = "application/pdf";
                            Response.WriteFile(pathPdf1);
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
                else {

                    if (conscabcera.tipo_nce.Trim() == "VTAE")
                    {
                        Ccf_tipo2 = "VTAE";
                    }
                    else
                    {
                        Ccf_tipo2 = "POSE";
                    }

                    //Clase para pdf de cada empresa 
                    switch (Modelowmspclogo.pdf_fe.Trim())
                    {
                        case "DEFECTO2":
                            PdfFacEleV2Default2 pdf1 = new PdfFacEleV2Default2();
                            string pathPdf1 = pdf1.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                            Response.ContentType = "application/pdf";
                            Response.WriteFile(pathPdf1);
                            Response.End();
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

        public void GuardarExcepciones(string metodo, string error)
        {
            //obtener numero de transaccion

            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "ReporteFactura.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;

            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            
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

        public QueryString ulrDesencriptada()
        {
            try
            {
                //1- guardo el Querystring encriptado que viene desde el request en mi objeto
                QueryString qs = new QueryString(Request.QueryString);

                ////2- Descencripto y de esta manera obtengo un array Clave/Valor normal
                qs = Encryption.DecryptQueryString(qs);
                return qs;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("ulrDesencriptada", ex.ToString());
                return null;

            }
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