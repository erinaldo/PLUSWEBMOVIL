﻿using Newtonsoft.Json;
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
using System.IO.Compression;
using CapaProceso.FacturaMasiva;

namespace CapaProceso.RestCliente
{
    public class ConsumoRestFEV3_PDF
    {

        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();
        public GuardarrespuestaDS guardarResJson = new GuardarrespuestaDS();
        public JsonFacturacionElectronicaV3 consultaResJson = new JsonFacturacionElectronicaV3();
        public ProcesoRestFEV3 procesoRest = new ProcesoRestFEV3();
        public JsonFacElecVer3PDF jsonFacturapdf = new JsonFacElecVer3PDF();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        ConsultaLogoSql tipo_factura = new ConsultaLogoSql();//Trae que version de pdf usa la empresa
        GenerarPDFDocumentos generer_pdfElectronico = new GenerarPDFDocumentos();
        string metodo = "ConsumoRestFEV3_PDF.cs";
        string cod_proceso = "RCOMFELECT"; //Con este codigo busca pdf de cada empresa ya sea  pose,vtae, pos, vta
        string tipo_doc = null;//Aqui se llena el tipo o version de pdf que usa para la facturacion cada empresa

        public string EnviarFactura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                //Consultar usuario y contraseña
                Modelowmspclogo = null;
                Modelowmspclogo = BuscarUsuarioLogo(Ccf_cod_emp, Ccf_usuario);

                string username = Modelowmspclogo.username;
                string password = Modelowmspclogo.password;
                string linkemidocuelec = Modelowmspclogo.linkemidocuelec;

                string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{username}:{password}"));

                //Consultar datos para enviar el json arma la consulta y la estructura de json factura
                string jsonRes = "";
                string jsonrRespuesta = "";
                string json_concepto = "";
                json_concepto = JsonConvert.SerializeObject(consultaResJson.LlenarJSONFactura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans), Formatting.Indented);
                jsonRes = json_concepto.Replace("Base", "base");
                JsonRespuestaDSFEV3 jsonRespuestaDE = new JsonRespuestaDSFEV3();
                //Envia el json armado para y obtiene la respuesta
                jsonRespuestaDE = procesoRest.EnviarJSONDS(linkemidocuelec, credentials, jsonRes);
                jsonrRespuesta = JsonConvert.SerializeObject(jsonRespuestaDE);
                jsonRespuestaDE.json = jsonRes;
                jsonRespuestaDE.jsonrRespuesta = jsonrRespuesta;
                jsonRespuestaDE.nro_trans = Ccf_nro_trans;

                guardarResJson.InsertarRespuestaJsonDIANDS_Adjunto(jsonRespuestaDE);//Inserta la respuesta obtenida del servicio rest en la tabla

                if (!jsonRespuestaDE.respuestaerror)//Si la factura no tiene errores
                {

                    string jsonResPdf = "";
                    string linkgenpdf = Modelowmspclogo.linkgenpdf;//Obtengo link para enviara pdf
                    //Clase para generar  pdf de cada empresa 
                    string pathPdf = generer_pdfElectronico.GenerarPDFFacturaElectronica(Ccf_cod_emp, cod_proceso, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);

                    byte[] pdfBytes = File.ReadAllBytes(pathPdf);
                    string pdfBase64 = Convert.ToBase64String(pdfBytes);//Convierto el pdf en base 64

                    //Consultar pdf, convertir a json
                    jsonResPdf = JsonConvert.SerializeObject(jsonFacturapdf.RespuestaJSONPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, pdfBase64), Formatting.Indented);

                    //Envia el json armado para y obtiene la respuesta final de DS
                    jsonRespuestaDE = procesoRest.EnviarJSONDS(linkgenpdf, credentials, jsonResPdf);
                    /*Volver a preguntar si error es igul a nulo*/
                    if (jsonRespuestaDE.error == " ")
                    {
                        jsonRespuestaDE.error = "";
                    }
                    else
                    {
                        //Primero se guarda el error y luego sale de la excepcion
                        jsonRespuestaDE.jsonrRespuesta = "";
                        jsonRespuestaDE.json = jsonResPdf;
                        jsonRespuestaDE.nro_trans = Ccf_nro_trans;
                        guardarResJson.InsertarRespuestaJsonDIANDS_Adjunto(jsonRespuestaDE);//Inserta la respuesta obtenida del servicio rest en la tabla
                        return "Existe Errores, notificacion DS";
                    }

                    if (jsonRespuestaDE.result.Trim() == null)
                    {
                        return "";
                    }
                    //PRUEBA JSON jsonrRespuesta 
                    jsonRespuestaDE.jsonrRespuesta = "";
                    jsonRespuestaDE.json = jsonResPdf;
                    jsonRespuestaDE.nro_trans = Ccf_nro_trans;
                    guardarResJson.InsertarRespuestaJsonDIANDS_Adjunto(jsonRespuestaDE);//Inserta la respuesta obtenida del servicio rest en la tabla

                    return "";
                }
                else
                {
                    return "Se produjo un error al enviar " + jsonRespuestaDE.error;
                }
            }

            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "EnviarFactura", e.ToString(), DateTime.Now, Ccf_usuario);
                return "Se produjo un error al enviar " + e.ToString();
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarUsuarioLogo", e.ToString(), DateTime.Now, Ccf_usuario);
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

                //Proporcionar credenciales
                string username = Modelowmspclogo.username;
                string password = Modelowmspclogo.password;
                string linkemidocuelec = Modelowmspclogo.linkemidocuelec;

                string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{username}:{password}"));
                //Envia Pdf el pdf si es autorizado
                string jsonResPdf = "";
                //sr.Close();

                string linkgenpdf = Modelowmspclogo.linkgenpdf;//Obtengo link para enviara pdf
                                                               //Clase para pdf de cada empresa 
                //Clase para generar  pdf de cada empresa 
                string pathPdf = generer_pdfElectronico.GenerarPDFFacturaElectronica(Ccf_cod_emp, cod_proceso, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);

                byte[] pdfBytes = File.ReadAllBytes(pathPdf);
                string pdfBase64 = Convert.ToBase64String(pdfBytes);//Convierto el pdf en base 64

                //Consultar pdf, convertir a json
                jsonResPdf = JsonConvert.SerializeObject(jsonFacturapdf.RespuestaJSONPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, pdfBase64), Formatting.Indented);

                JsonRespuestaDSFEV3 jsonRespuestaDE = new JsonRespuestaDSFEV3();
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
                guardarResJson.InsertarRespuestaJsonDIANDS_Adjunto(jsonRespuestaDE);//Inserta la respuesta obtenida del servicio rest en la tabla

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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "enviarPDF", e.ToString(), DateTime.Now, Ccf_usuario);
                return "No se pudo completar la acción." + "enviarPDF." + " Por favor notificar al administrador.";
            }
        }
    }
}
