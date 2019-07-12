using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using CapaDatos;
using CapaDatos.Sql.SqlNC;
using System.Data.SqlClient;
using RestSharp;
using CapaProceso.Modelos;
using CapaProceso.Consultas;
using CapaDatos.Modelos;
using CapaDatos.Modelos.ModelosNC;

namespace CapaProceso.RestCliente
{
   public  class ProcesoRestNC
    {
        public JsonRespuestaNC EnviarJSONDS(string linkemidocuelec, string credentials, string jsonRes)
        {
            JsonRespuestaNC jsonRespuestaNC = new JsonRespuestaNC();

            var client = new RestClient(linkemidocuelec);
            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", "Basic " + credentials);
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddParameter("application/json", jsonRes, ParameterType.RequestBody);

             IRestResponse response = client.Execute(request);
            string tipo = response.ContentType;
            if (tipo.Equals("application/json"))
            {
                jsonRespuestaNC = JsonConvert.DeserializeObject<JsonRespuestaNC>(response.Content);
            }

            if (tipo.Equals("text/html"))
            {
                jsonRespuestaNC.error = response.Content;
            }


            if (jsonRespuestaNC.qrdata == null)
            {
                jsonRespuestaNC.qrdata = " ";
            }

            if (jsonRespuestaNC.id == null)
            {
                jsonRespuestaNC.id = " ";
            }
            if (jsonRespuestaNC.cufe == null)
            {
                jsonRespuestaNC.cufe = " ";
            }

            if (jsonRespuestaNC.error == null)
            {
                jsonRespuestaNC.error = " ";
            }

            if (jsonRespuestaNC.result == null)
            {
                jsonRespuestaNC.result = " ";
            }

            if (jsonRespuestaNC.xml == null)
            {
                jsonRespuestaNC.xml = " ";
            }
            else
            {
                string base64Encoded = jsonRespuestaNC.xml;
                string base64Decoded;
                byte[] data = Convert.FromBase64String(base64Encoded);
                base64Decoded = ASCIIEncoding.ASCII.GetString(data);
                jsonRespuestaNC.xml = base64Decoded;
            }

            return jsonRespuestaNC;
        }
    }
}
