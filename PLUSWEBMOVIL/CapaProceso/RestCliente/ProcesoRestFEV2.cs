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
using CapaDatos.Modelos;

namespace CapaProceso.RestCliente
{
    public class ProcesoRestFEV2
    {
        public JsonRespuestaDSFEV2 EnviarJSONDS(string linkemidocuelec, string credentials, string jsonRes)
        {
            try
            {

                JsonRespuestaDSFEV2 jsonRespuestaDE = new JsonRespuestaDSFEV2();
                bool error = false;
                var client = new RestClient(linkemidocuelec);
                var request = new RestRequest(Method.POST);

                request.AddHeader("Authorization", "Basic " + credentials);
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                request.AddParameter("application/json", jsonRes, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                string tipo = response.ContentType;
                if (tipo.Equals("application/json"))
                {
                    jsonRespuestaDE = JsonConvert.DeserializeObject<JsonRespuestaDSFEV2>(response.Content);
                }

                if (tipo.Equals("text/html"))
                {
                    jsonRespuestaDE.error = response.Content;
                }


                if (jsonRespuestaDE.qrdata == null)
                {
                    jsonRespuestaDE.qrdata = " ";
                }

                if (jsonRespuestaDE.id == null)
                {
                    jsonRespuestaDE.id = " ";
                }
                if (jsonRespuestaDE.cufe == null)
                {
                    jsonRespuestaDE.cufe = " ";
                }

                if (jsonRespuestaDE.error == null)
                {
                    jsonRespuestaDE.error = " ";
                }

                if (jsonRespuestaDE.result == null)
                {
                    jsonRespuestaDE.result = " ";
                }

                if (jsonRespuestaDE.xml == null)
                {
                    jsonRespuestaDE.xml = " ";
                }
                else
                {
                    string base64Encoded = jsonRespuestaDE.xml;
                    string base64Decoded;
                    byte[] data = Convert.FromBase64String(base64Encoded);
                    base64Decoded = ASCIIEncoding.ASCII.GetString(data);
                    jsonRespuestaDE.xml = base64Decoded;
                }

                if (jsonRespuestaDE.DIAN != null)
                {
                    foreach (var item in jsonRespuestaDE.DIAN)
                {
                    if (item.Xml == null)
                    {
                        item.Xml = " ";
                    }
                    else
                    {
                        string base64Encoded = item.Xml;
                        string base64Decoded;
                        byte[] data = Convert.FromBase64String(base64Encoded);
                        base64Decoded = ASCIIEncoding.ASCII.GetString(data);
                        item.Xml = base64Decoded;
                    }
                    if (item.Mensaje == null)
                    {
                        item.Mensaje = " ";
                    }
                    if (item.Valido == null)
                    {
                        item.Valido = " ";
                    }
                    if (item.Descripcion == null)
                    {
                        item.Descripcion = " ";
                    }

                    if (item.StatusCode == null)
                    {
                        item.StatusCode = " ";
                    }

                    if (item.Valido == "true")
                    {
                        item.StatusCode = " ";
                    }
                    else
                    {
                        error = true;
                    }
                    


                }
                }

                jsonRespuestaDE.respuestaerror = error;

                
                return jsonRespuestaDE;
            }

            catch (Exception e)
            {
                JsonRespuestaDSFEV2 jsonRespuestaDE = new JsonRespuestaDSFEV2();
              
                return jsonRespuestaDE;
            }
        }
}
}

