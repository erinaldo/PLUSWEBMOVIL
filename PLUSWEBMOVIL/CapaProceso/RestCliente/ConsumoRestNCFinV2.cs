using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using CapaDatos;
using CapaDatos.Sql;
using System.Data.SqlClient;
using RestSharp;
using CapaProceso.Modelos;
using CapaProceso.Consultas;
using CapaProceso.GenerarPDF.FacturaElectronica;
using CapaProceso.ReslClientePdf;
using CapaDatos.Modelos;
using CapaDatos.Modelos.ModelosNC;

namespace CapaProceso.RestCliente
{
    public class ConsumoRestNCFinV2
    {
 
        public ConsultaLogo consultaLogo = new ConsultaLogo(); 
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultawmtrespuestaNC consultaRespuestaDS = new ConsultawmtrespuestaNC();
        public GuardarrespuestaNCDS guardarResJson = new GuardarrespuestaNCDS();
        public JsonNCFinancieraElectronicaV2 consultaResJson = new JsonNCFinancieraElectronicaV2();
        public ProcesoRestNCV2 procesoRest = new ProcesoRestNCV2();
        public JsonNCPDFV2 jsonFacturapdf = new JsonNCPDFV2();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "ConsumoRestNCFin.cs";

        public string EnviarFactura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string nro_factura)
        {
            try
            {
                //Consultar usuario y contraseña
                Modelowmspclogo = null;
                Modelowmspclogo = BuscarUsuarioLogo(Ccf_cod_emp, Ccf_usuario);


                //StreamReader sr = new StreamReader("F:\\factura.txt");
                // string contenido = sr.ReadToEnd();
                //string jsonRes = contenido;
                //sr.Close();

                //Proporcionar credenciales
                string username = Modelowmspclogo.username;
                string password = Modelowmspclogo.password;
                string linkemidocuelec = Modelowmspclogo.linkemidocuelec;

                string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{username}:{password}"));

                //Consultar datos para enviar el json arma la consulta y la estructura de json factura
                string jsonRes = "";
                string jsonrRespuesta = "";
                jsonRes = JsonConvert.SerializeObject(consultaResJson.LlenarJSONNC(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, nro_factura), Formatting.Indented);

                JsonRespuestaNCV2 jsonRespuestaDE = new JsonRespuestaNCV2();
                //Envia el json armado para y obtiene la respuesta
               
                jsonRespuestaDE = procesoRest.EnviarJSONDS(linkemidocuelec, credentials, jsonRes);
                jsonrRespuesta = JsonConvert.SerializeObject(jsonRespuestaDE);
                jsonRespuestaDE.json = jsonRes;
                jsonRespuestaDE.jsonrRespuesta = jsonrRespuesta;
                jsonRespuestaDE.nro_trans = Ccf_nro_trans;

                guardarResJson.InsertarRespuestaJsonDIANDS(jsonRespuestaDE);//Inserta la respuesta obtenida del servicio rest en la tabla



                if (!jsonRespuestaDE.respuestaerror)//Si la factura no tiene errores
                {
                    //Envia Pdf el pdf si es autorizado
                    //sr = new StreamReader("F:\\pdf.txt");
                    //contenido = sr.ReadToEnd();
                    string jsonResPdf = "";
                    //sr.Close();

                    string linkgenpdf = Modelowmspclogo.linkgenpdf;//Obtengo link para enviara pdf

                    PdfNotaCreditoElectronica pdf = new PdfNotaCreditoElectronica();
                    string pathPdf = pdf.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);//Genero el pdf

                    byte[] pdfBytes = File.ReadAllBytes(pathPdf);
                    string pdfBase64 = Convert.ToBase64String(pdfBytes);//Convierto el pdf en base 64

                    //Consultar pdf, convertir a json
                    jsonResPdf = JsonConvert.SerializeObject(jsonFacturapdf.RespuestaJSONPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, pdfBase64), Formatting.Indented);




                    //Envia el json armado para y obtiene la respuesta
                    jsonRespuestaDE = procesoRest.EnviarJSONDS(linkgenpdf, credentials, jsonResPdf);
                    /*Volver a preguntar si error es igul a nulo*/
                    if (jsonRespuestaDE.error.Trim() == null)
                    {
                        jsonRespuestaDE.error = "";
                    }

                    if (jsonRespuestaDE.result.Trim() == null)
                    {
                        return "";
                    }
                    //PRUEBA JSON jsonrRespuesta
                   
                        jsonRespuestaDE.jsonrRespuesta = "";
                    
                    jsonRespuestaDE.json = jsonResPdf;
                    jsonRespuestaDE.nro_trans = Ccf_nro_trans;
                    guardarResJson.InsertarRespuestaJsonDIANDS(jsonRespuestaDE);//Inserta la respuesta obtenida del servicio rest en la tabla


                    return "";


                }
                else
                {
                    return "Se produjo un error al enviar " + jsonRespuestaDE.error;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "EnviarFactura", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }


        }
        public modelowmspclogo BuscarUsuarioLogo(string Ccf_cod_emp, string Ccf_usuario)
        {
            try
            {
                ListaModelowmspclogo = consultaLogo.BuscartaLogo(Ccf_cod_emp, Ccf_usuario);

                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }

                return Modelowmspclogo;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarUsuarioLogo", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }

        public string enviarPDF(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                //Consultar usuario y contraseña
                Modelowmspclogo = null;
                Modelowmspclogo = BuscarUsuarioLogo(Ccf_cod_emp, Ccf_usuario);


                //StreamReader sr = new StreamReader("F:\\factura.txt");
                // string contenido = sr.ReadToEnd();
                //string jsonRes = contenido;
                //sr.Close();

                //Proporcionar credenciales
                string username = Modelowmspclogo.username;
                string password = Modelowmspclogo.password;
                string linkemidocuelec = Modelowmspclogo.linkemidocuelec;

                string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{username}:{password}"));
                //Envia Pdf el pdf si es autorizado
                //sr = new StreamReader("F:\\pdf.txt");
                //contenido = sr.ReadToEnd();
                string jsonResPdf = "";
                //sr.Close();

                string linkgenpdf = Modelowmspclogo.linkgenpdf;//Obtengo link para enviara pdf

                PdfNotaCreditoElectronica pdf = new PdfNotaCreditoElectronica();
                string pathPdf = pdf.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);//Genero el pdf

                byte[] pdfBytes = File.ReadAllBytes(pathPdf);
                string pdfBase64 = Convert.ToBase64String(pdfBytes);//Convierto el pdf en base 64

                //Consultar pdf, convertir a json
                jsonResPdf = JsonConvert.SerializeObject(jsonFacturapdf.RespuestaJSONPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, pdfBase64), Formatting.Indented);



                JsonRespuestaNCV2 jsonRespuestaDE = new JsonRespuestaNCV2();
                //Envia el json armado para y obtiene la respuesta
                jsonRespuestaDE = procesoRest.EnviarJSONDS(linkgenpdf, credentials, jsonResPdf);
                /*Volver a preguntar si error es igul a nulo*/
                Boolean respuesta = false;
                if (jsonRespuestaDE.error.Trim() == "")
                {
                    respuesta = false;
                }
                else
                {
                    respuesta = true;
                }
                //PRUEBA JSON jsonrRespuesta
               
                    jsonRespuestaDE.jsonrRespuesta = "";
                

                jsonRespuestaDE.json = jsonResPdf;
                jsonRespuestaDE.nro_trans = Ccf_nro_trans;
                guardarResJson.InsertarRespuestaJsonDIANDS(jsonRespuestaDE);//Inserta la respuesta obtenida del servicio rest en la tabla

                if (respuesta)
                {
                    return jsonRespuestaDE.error;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "enviarPDF", e.ToString(), DateTime.Today, Ccf_usuario);
                return "No se pudo completar la acción." + "enviarPDF." + " Por favor notificar al administrador.";
            }



        }


    }
}
