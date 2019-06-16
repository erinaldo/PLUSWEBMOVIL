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
   public  class ProcesoRest
    {
        public JsonRespuestaDE EnviarJSONDS(string linkemidocuelec, string credentials, string jsonRes)
        {
            JsonRespuestaDE jsonRespuestaDE = new JsonRespuestaDE();

            var client = new RestClient(linkemidocuelec);
            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", "Basic " + credentials);
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddParameter("application/json", jsonRes, ParameterType.RequestBody);

             IRestResponse response = client.Execute(request);
            string tipo = response.ContentType;
            if (tipo.Equals("application/json"))
            {
                jsonRespuestaDE = JsonConvert.DeserializeObject<JsonRespuestaDE>(response.Content);
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

            return jsonRespuestaDE;
        }
    }
}
