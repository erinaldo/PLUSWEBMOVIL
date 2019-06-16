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

namespace CapaProceso.RestCliente
{
    public class ConsumoRest
    {
 
        public ConsultaLogo consultaLogo = new ConsultaLogo(); 
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();
        public GuardarrespuestaDS guardarResJson = new GuardarrespuestaDS();
        public JsonFacturacionElectronica consultaResJson = new JsonFacturacionElectronica();
        public ProcesoRest procesoRest = new ProcesoRest();
        public JsonFacturaPDF jsonFacturapdf = new JsonFacturaPDF();

        public string EnviarFactura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            //Consultar usuario y contraseña
            Modelowmspclogo = null;
            Modelowmspclogo = BuscarUsuarioLogo( Ccf_cod_emp, Ccf_usuario);
            
           
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
            jsonRes = JsonConvert.SerializeObject(consultaResJson.LlenarJSONFactura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans), Formatting.Indented);
           
            JsonRespuestaDE jsonRespuestaDE = new JsonRespuestaDE();
            //Envia el json armado para y obtiene la respuesta
            jsonRespuestaDE = procesoRest.EnviarJSONDS(linkemidocuelec, credentials, jsonRes);   
           
            jsonRespuestaDE.json = jsonRes;
            jsonRespuestaDE.nro_trans = Ccf_nro_trans;

            
            guardarResJson.InsertarRespuestaJson(jsonRespuestaDE);//Inserta la respuesta obtenida del servicio rest en la tabla

            

            if (jsonRespuestaDE.error.Trim() == "" )//Si la factura no tiene errores
            {
                //Envia Pdf el pdf si es autorizado
                //sr = new StreamReader("F:\\pdf.txt");
                //contenido = sr.ReadToEnd();
                string jsonResPdf = "";
                //sr.Close();

                string linkgenpdf = Modelowmspclogo.linkgenpdf;//Obtengo link para enviara pdf
                
                PdfFacturaElectronica pdf = new PdfFacturaElectronica();
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
                jsonRespuestaDE.json = jsonResPdf;
                jsonRespuestaDE.nro_trans = Ccf_nro_trans;
                guardarResJson.InsertarRespuestaJson(jsonRespuestaDE);//Inserta la respuesta obtenida del servicio rest en la tabla
               
               
                    return "";
                

            }
            else
            {
                return jsonRespuestaDE.error;
            }
            
        }
        public modelowmspclogo BuscarUsuarioLogo(string Ccf_cod_emp, string Ccf_usuario)
        {
            ListaModelowmspclogo = consultaLogo.BuscartaLogo(Ccf_cod_emp, Ccf_usuario);

            foreach (var item in ListaModelowmspclogo)
            {
                Modelowmspclogo = item;
                break;
            }

            return Modelowmspclogo;
        }

        public string enviarPDF(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
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

            PdfFacturaElectronica pdf = new PdfFacturaElectronica();
            string pathPdf = pdf.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);//Genero el pdf

            byte[] pdfBytes = File.ReadAllBytes(pathPdf);
            string pdfBase64 = Convert.ToBase64String(pdfBytes);//Convierto el pdf en base 64

            //Consultar pdf, convertir a json
            jsonResPdf = JsonConvert.SerializeObject(jsonFacturapdf.RespuestaJSONPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, pdfBase64), Formatting.Indented);



            JsonRespuestaDE jsonRespuestaDE = new JsonRespuestaDE();
            //Envia el json armado para y obtiene la respuesta
            jsonRespuestaDE = procesoRest.EnviarJSONDS(linkgenpdf, credentials, jsonResPdf);
            /*Volver a preguntar si error es igul a nulo*/
            Boolean respuesta = false;
            if (jsonRespuestaDE.error.Trim() == null)
            {
                jsonRespuestaDE.error = "";
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
           
            jsonRespuestaDE.json = jsonResPdf;
            jsonRespuestaDE.nro_trans = Ccf_nro_trans;
            guardarResJson.InsertarRespuestaJson(jsonRespuestaDE);//Inserta la respuesta obtenida del servicio rest en la tabla

            if (respuesta)
            {
                return jsonRespuestaDE.error;
            }
            else
            {
                return "";
            }



        }


    }
}
