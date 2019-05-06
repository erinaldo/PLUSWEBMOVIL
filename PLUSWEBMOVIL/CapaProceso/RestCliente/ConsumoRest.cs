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

namespace CapaProceso.RestCliente
{
    public class ConsumoRest
    {
        public string ConsultarRest()
        {
            StreamReader sr = new StreamReader("F:\\factura.txt");
            string contenido = sr.ReadToEnd();
            sr.Close();

           
            string user = "tUNXlvbVCGaYXlIsP/ycevcfb+72i3e/QvGOvJofKDo=";
            string password = "jlO749qCdKRwZXUr/M/KC6KHxcr7Ubfq7J/9B0somVQgI85vtKAYrtFG4bY53Bcr";

            string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{user}:{password}"));


            string output = JsonConvert.SerializeObject(LlenarJSONFactura(), Formatting.Indented);

            



            var client = new RestClient("https://ws.dsnube.co/dsrest/dsdatasnapfe.dll/datasnap/rest/TFactura/docfe");
            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", "Basic " + credentials);
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddParameter("application/json", output, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            string tipo = response.ContentType;
            JsonRespuestaDE jsonRespuestaDE = new JsonRespuestaDE();

            if (tipo.Equals("application/json"))
            {
                jsonRespuestaDE = JsonConvert.DeserializeObject<JsonRespuestaDE>(response.Content);
            }

            if (tipo.Equals("text/html"))
            {
                jsonRespuestaDE.error = response.Content;
            }

            return output;//"Error " + jsonRespuestaDE.error + "\nqrdata " + jsonRespuestaDE.qrdata;
        }

        public ComprobanteFacturaJSON LlenarJSONFactura()
        {
            ComprobanteFacturaJSON comprobanteFacturaJSON = new ComprobanteFacturaJSON();
            /* Datos de encabezado de la factura */

            comprobanteFacturaJSON.encabezado = LlenarEnacabezadoFacturaJSON();
            comprobanteFacturaJSON.detalle = LlenarDetalleFacturaJSON();
            comprobanteFacturaJSON.impuesto = LlenarImpuestoFacturaJSON();
            comprobanteFacturaJSON.pago = LlenarPagotoFacturaJSON();
            comprobanteFacturaJSON.sucursal = LlenarSucursalFacturaJSON();
            comprobanteFacturaJSON.tercero = LlenarTerceroFacturaJSON();

            return comprobanteFacturaJSON;
        }

        public Encabezado LlenarEnacabezadoFacturaJSON()
        {
            Encabezado encabezado = new Encabezado();
            FacturACab facturACab = new FacturACab();

            SqlDataReader dr = facturACab.ConsultaCabezaraFactura("04", "VTA");

            while (dr.Read())
            {
                encabezado.anulado = "N";
                encabezado.comentarios = Convert.ToString(dr["observaciones"]);
                encabezado.descuento = Convert.ToDecimal(dr["descuento"]);
                encabezado.fecha = Convert.ToDateTime(dr["fec_doc"]);

            }
                return encabezado;
        }

        public List<Detalle> LlenarDetalleFacturaJSON()
        {
            List<Detalle> detalle = new List<Detalle>();
            Detalle item = new Detalle();

            detalle.Add(item);
            return detalle;
        }

        public List<Impuesto> LlenarImpuestoFacturaJSON()
        {
            List<Impuesto> impuesto = new List<Impuesto>();
            Impuesto item = new Impuesto();
            impuesto.Add(item);
            return impuesto;
        }

        public List<Pago> LlenarPagotoFacturaJSON()
        {
            List<Pago> pago = new List<Pago>();
            Pago item = new Pago();
            pago.Add(item);
            return pago;
        }

        public Sucursal LlenarSucursalFacturaJSON()
        {
            
            Sucursal sucursal = new Sucursal();
            
            return sucursal;
        }

        public Tercero LlenarTerceroFacturaJSON()
        {

            Tercero tercero = new Tercero();

            return tercero;
        }

    }
}
