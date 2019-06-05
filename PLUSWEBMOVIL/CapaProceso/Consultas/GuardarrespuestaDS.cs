using CapaDatos.Sql;
using CapaProceso.Modelos;
using CapaProceso.RestCliente;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
   public  class GuardarrespuestaDS
    {
  
        RespuestaDC guardar = new RespuestaDC();
        JsonRespuestaDE modeloRespuestaJson = new JsonRespuestaDE();

        public string InsertarRespuestaJson(string nro_trans, int linea, string qrdata, string xml, string id, string cufe, string error, string json )
        {
            string respuesta = guardar.InsertarRespuestaDS(nro_trans, linea, qrdata, xml, id, cufe, error, json);

            return respuesta;
        }


        /*   public string InsertarRespuestaJson(JsonRespuestaDE detalleRespuesta)
           {
               string respuesta = guardar.InsertarRespuestaDS(detalleRespuesta);
               return respuesta;
           }*/
    }
}
