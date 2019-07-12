using CapaDatos.Modelos;
using CapaDatos.Modelos.ModelosNC;
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
   public  class GuardarrespuestaNCDS
    {
  
        RespuestaNC guardar = new RespuestaNC();
        JsonRespuestaNC modeloRespuestaJson = new JsonRespuestaNC();
        public List<JsonRespuestaNC> ListaModelorespuestaDs = new List<JsonRespuestaNC>();
        public List<JsonRespuestaNC> ListaBuscarQr = null;
        public JsonRespuestaNC ModeloResQr = new JsonRespuestaNC();
        public ConsultawmtrespuestaNC consultaRespuestaDS = new ConsultawmtrespuestaNC();
        public string InsertarRespuestaJson(JsonRespuestaNC jsonRespuestaNC)
        {
            //consultar datos en la tabla wmt_respuestaDS secuencial para insertar linea
            ModeloResQr = null;
            ModeloResQr = BuscarRespuestaDS(jsonRespuestaNC.nro_trans);
            if (ModeloResQr == null)
            {
                if (jsonRespuestaNC.linea <= 0)
                {
                    jsonRespuestaNC.linea = 1;
                }

            }
            else
            {
                jsonRespuestaNC.linea = ModeloResQr.linea + 1;

            }
            string respuesta = guardar.InsertarRespuestaNC(jsonRespuestaNC);

            return respuesta;
        }


        public JsonRespuestaNC BuscarRespuestaDS(string Ccf_nro_trans)
        {
            ListaModelorespuestaDs = consultaRespuestaDS.ConsultaRespuestaQr(Ccf_nro_trans);

            foreach (var item in ListaModelorespuestaDs)
            {
                ModeloResQr = item;
                break;
            }

            return ModeloResQr;
        }
    }
}
