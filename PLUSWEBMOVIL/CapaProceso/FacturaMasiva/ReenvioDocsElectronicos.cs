using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Consultas;
using CapaProceso.RestCliente;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CapaProceso.FacturaMasiva
{
   public  class ReenvioDocsElectronicos
    {
        CabezeraFactura ActualizarEstadoFact = new CabezeraFactura();
        Enviarcorreocliente enviarcorreocliente = new Enviarcorreocliente();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<JsonRespuestaDE> ListaModelorespuestaDs = null;
        public JsonRespuestaDE ModeloResQr = new JsonRespuestaDE();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();
        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();
        List<modelowmtfacturascab> listaConsCab = null;
        modelowmtfacturascab conscabcera = new modelowmtfacturascab();

        GenerarPDFDocumentos generer_pdfElectronico = new GenerarPDFDocumentos();
        string metodo = "ReenvioDocsElectronicos.cs";
        public string ReenviarDocumentoDIAN(string ComPwm,string  AmUsrLog, string tipo_doc, string nro_trans, string doc_adjunto, string version_fe, string path_doc)
        {
            try
            {
                string respuesta = null;
                if (tipo_doc.Trim() == "VTAE" || tipo_doc == "POSE")
                {

                    switch (version_fe.Trim())  //AVERIGUAR QUE VERSION  DE FACTURACION USA
                    {
                        case "2":

                            if (doc_adjunto == null || doc_adjunto == "")
                            {
                                ConsumoRestFEV3 consumoRest1 = new ConsumoRestFEV3();

                                respuesta = consumoRest1.EnviarFactura(ComPwm, AmUsrLog, "C", tipo_doc.Trim(), nro_trans.Trim());
                            }
                            else
                            {
                                ConsumoRestFEV3_PDF consumoRest1 = new ConsumoRestFEV3_PDF();
                                respuesta = consumoRest1.EnviarFactura(ComPwm, AmUsrLog, "C", tipo_doc.Trim(), nro_trans.Trim());
                            }
                            break;
                        case "1":
                            ConsumoRestFEV2 consumoRest = new ConsumoRestFEV2();
                            respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", tipo_doc.Trim(), nro_trans.Trim());
                            break;
                    }

                    if (respuesta == "")
                    {
                        ActualizarEstadoFact.ActualizarEstadoFactura(nro_trans.Trim(), "F");
                        EnviarCorreoRemitente(ComPwm, AmUsrLog,nro_trans.Trim(), tipo_doc.Trim(),path_doc, "RCOMFELECT");
                    }
                    return respuesta;
                }
                if (tipo_doc.Trim() == "NCME" || tipo_doc == "NCVE")
                {
                    //Consulta nro_trans factura 
                    listaConsCab = ConsultaCabe.ConsultaNCTransPadre(nro_trans);
                    conscabcera = null;
                    foreach (modelowmtfacturascab item in listaConsCab)
                    {
                        conscabcera = item;

                    }
 
                    if (version_fe.Trim() == "2")
                    {
                        ConsumoRestNCFinV3 consumoRest = new ConsumoRestNCFinV3();
                        respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", "NC", nro_trans, conscabcera.nro_trans_padre);
                    }
                    else
                    {
                        ConsumoRestNCFinV2 consumoRest = new ConsumoRestNCFinV2();
                        respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", "NC", nro_trans, conscabcera.nro_trans_padre);
                    }


                    if (respuesta == "")
                    {
                        ActualizarEstadoFact.ActualizarEstadoFactura(nro_trans, "F"); //Actualizar estado nc
                        if (conscabcera.mot_nce.Trim() == "2")
                        {
                            ActualizarEstadoFact.ActualizarEstadoFactura(conscabcera.nro_trans_padre.Trim(), "N");//Actualiza factura a Anulada
                        }
                        EnviarCorreoRemitente(ComPwm, AmUsrLog,nro_trans, conscabcera.tipo_nce, path_doc, "RCOMNCELEC");//CORREO REMITENTE
                    }
                }
                if(tipo_doc.Trim()=="NDVE")
                {
                    listaConsCab = ConsultaCabe.ConsultaNCTransPadre(nro_trans);
                    conscabcera = null;
                    foreach (modelowmtfacturascab item in listaConsCab)
                    {
                        conscabcera = item;

                    }
                    if (version_fe.Trim() == "2")
                    {
                        ConsumoRestNDV3 consumoRest = new ConsumoRestNDV3();
                        respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", conscabcera.tipo_nce, nro_trans.Trim(), conscabcera.nro_trans_padre);
                    }

                    if (respuesta == "")
                    {
                        ActualizarEstadoFact.ActualizarEstadoFactura(nro_trans, "F"); //Actualizar estado nNOTA DEBITO
                        if (conscabcera.mot_nce.Trim() == "4")
                        {
                            ActualizarEstadoFact.ActualizarEstadoFactura(conscabcera.nro_trans_padre.Trim(), "N");//Actualiza NOTA CREDITO a Anulada
                        }
                        EnviarCorreoRemitente(ComPwm, AmUsrLog, nro_trans, conscabcera.tipo_nce, path_doc, "RCOMNDEB");//CORREO REMITENTE
                    }
                }
                    return respuesta;
            }
            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "ReenviarDocumentoDIAN", ex.ToString(), DateTime.Now, AmUsrLog);
                return ex.ToString();
            }

        }


        public string ReenviarPDFDIAN(string ComPwm, string AmUsrLog, string tipo_doc, string nro_trans, string doc_adjunto, string version_fe, string path_doc)
        {
            try
            {
                string respuesta = null;
                if (tipo_doc.Trim() == "VTAE" || tipo_doc == "POSE")
                {

                    switch (version_fe.Trim())  //AVERIGUAR QUE VERSION  DE FACTURACION USA
                    {
                        case "2":

                            if (doc_adjunto == null || doc_adjunto == "")
                            {
                                ConsumoRestFEV3 consumoRest1 = new ConsumoRestFEV3();

                                respuesta = consumoRest1.enviarPDF(ComPwm, AmUsrLog, "C", tipo_doc.Trim(), nro_trans.Trim());
                            }
                            else
                            {
                                ConsumoRestFEV3_PDF consumoRest1 = new ConsumoRestFEV3_PDF();
                                respuesta = consumoRest1.enviarPDF(ComPwm, AmUsrLog, "C", tipo_doc.Trim(), nro_trans.Trim());
                            }
                            break;
                        case "1":
                            ConsumoRestFEV2 consumoRest = new ConsumoRestFEV2();
                            respuesta = consumoRest.enviarPDF(ComPwm, AmUsrLog, "C", tipo_doc.Trim(), nro_trans.Trim());
                            break;
                    }

                    if (respuesta == "")
                    {
                        ActualizarEstadoFact.ActualizarEstadoFactura(nro_trans.Trim(), "F");
                        EnviarCorreoRemitente(ComPwm, AmUsrLog, nro_trans.Trim(), tipo_doc.Trim(), path_doc, "RCOMFELECT");
                    }
                    return respuesta;
                }
                if (tipo_doc.Trim() == "NCME" || tipo_doc == "NCVE")
                {
                    //Consulta nro_trans factura 
                    listaConsCab = ConsultaCabe.ConsultaNCTransPadre(nro_trans);
                    conscabcera = null;
                    foreach (modelowmtfacturascab item in listaConsCab)
                    {
                        conscabcera = item;

                    }

                    if (version_fe.Trim() == "2")
                    {
                        ConsumoRestNCFinV3 consumoRest = new ConsumoRestNCFinV3();
                        respuesta = consumoRest.enviarPDF(ComPwm, AmUsrLog, "C", "NC", nro_trans);
                    }
                    else
                    {
                        ConsumoRestNCFinV2 consumoRest = new ConsumoRestNCFinV2();
                        respuesta = consumoRest.enviarPDF(ComPwm, AmUsrLog, "C", "NC", nro_trans);
                    }


                    if (respuesta == "")
                    {
                        ActualizarEstadoFact.ActualizarEstadoFactura(nro_trans, "F"); //Actualizar estado nc
                        if (conscabcera.mot_nce.Trim() == "2")
                        {
                            ActualizarEstadoFact.ActualizarEstadoFactura(conscabcera.nro_trans_padre.Trim(), "N");//Actualiza factura a Anulada
                        }
                        EnviarCorreoRemitente(ComPwm, AmUsrLog, nro_trans, conscabcera.tipo_nce, path_doc, "RCOMNCELEC");//CORREO REMITENTE
                    }
                }
                if (tipo_doc.Trim() == "NDVE")
                {
                    listaConsCab = ConsultaCabe.ConsultaNCTransPadre(nro_trans);
                    conscabcera = null;
                    foreach (modelowmtfacturascab item in listaConsCab)
                    {
                        conscabcera = item;

                    }
                    if (version_fe.Trim() == "2")
                    {
                        ConsumoRestNDV3 consumoRest = new ConsumoRestNDV3();
                        respuesta = consumoRest.enviarPDF(ComPwm, AmUsrLog, "C", conscabcera.tipo_nce, nro_trans.Trim());
                    }

                    if (respuesta == "")
                    {
                        ActualizarEstadoFact.ActualizarEstadoFactura(nro_trans, "F"); //Actualizar estado nNOTA DEBITO
                        if (conscabcera.mot_nce.Trim() == "4")
                        {
                            ActualizarEstadoFact.ActualizarEstadoFactura(conscabcera.nro_trans_padre.Trim(), "N");//Actualiza NOTA CREDITO a Anulada
                        }
                        EnviarCorreoRemitente(ComPwm, AmUsrLog, nro_trans, conscabcera.tipo_nce, path_doc, "RCOMNDEB");//CORREO REMITENTE
                    }
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "ReenviarPDFDIAN", ex.ToString(), DateTime.Now, AmUsrLog);
                return ex.ToString();
            }

        }

        public void EnviarCorreoRemitente(string ComPwm, string AmUsrLog, string nro_trans, string tipo, string pathtmpfac, string cod_proceso)
        {
            try
            {

                string Ccf_tipo2 = tipo;
                string Ccf_nro_trans = nro_trans;
                string Ccf_tipo1 = "C";
                //Buscar el xml TRAE TODAS LAS RESPUESTAS
                ListaModelorespuestaDs = consultaRespuestaDS.ConsultaRespuestaQr(nro_trans);
                foreach (var item in ListaModelorespuestaDs)
                {
                    if (item.xml != "")
                    {
                        ModeloResQr = item;
                    }

                }

                string StringXml = ModeloResQr.xml;
                string pathTemporal = pathtmpfac;
                string nombreXml = ModeloResQr.cufe.Trim() + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".xml";
                string pathXml = pathTemporal + nombreXml;
                File.WriteAllText(pathXml, StringXml);
                //-------------OBTENER EL XML Y PDF PARA EL ENVIO-------------------//
                if (cod_proceso == "RCOMFELECT")
                {
                    string pathPdf = generer_pdfElectronico.GenerarPDFFacturaElectronica(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    Boolean error = enviarcorreocliente.EnviarCorreoRemitente(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, pathPdf, pathXml);
                }
                if (cod_proceso == "RCOMNCELEC")
                {
                    string pathPdf = generer_pdfElectronico.GenerarPDFFacturaElectronica(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    Boolean error = enviarcorreocliente.EnviarCorreoRemitente(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, pathPdf, pathXml);
                }
                if (cod_proceso == "RCOMNDEB")
                {
                    string pathPdf = generer_pdfElectronico.GenerarPDFFacturaElectronica(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    Boolean error = enviarcorreocliente.EnviarCorreoRemitente(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, pathPdf, pathXml);
                }
            }

            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "EnviarCorreoRemitente", ex.ToString(), DateTime.Now, AmUsrLog);
            }
        }

    }
}
