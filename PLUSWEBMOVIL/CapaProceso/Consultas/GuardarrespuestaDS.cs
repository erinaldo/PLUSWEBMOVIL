using CapaDatos.Modelos;
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
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<JsonRespuestaDE> ListaModelorespuestaDs = new List<JsonRespuestaDE>();
        public List<JsonRespuestaDE> ListaBuscarQr = null;
        public JsonRespuestaDE ModeloResQr = new JsonRespuestaDE();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();
        string metodo = "GuardarrespuestaDS.cs";
        public string InsertarRespuestaJson(JsonRespuestaDE jsonRespuestaDE)
        {
            try
            {
                //consultar datos en la tabla wmt_respuestaDS secuencial para insertar linea
                ModeloResQr = null;
                ModeloResQr = BuscarRespuestaDS(jsonRespuestaDE.nro_trans);
                if (ModeloResQr == null)
                {
                    if (jsonRespuestaDE.linea <= 0)
                    {
                        jsonRespuestaDE.linea = 1;
                    }

                }
                else
                {
                    jsonRespuestaDE.linea = ModeloResQr.linea + 1;

                }
                string respuesta = guardar.InsertarRespuestaDS(jsonRespuestaDE);

                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(jsonRespuestaDE.nro_trans, metodo, "InsertarRespuestaJson", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }


        public JsonRespuestaDE BuscarRespuestaDS(string Ccf_nro_trans)
        {
            try
            {
                ListaModelorespuestaDs = consultaRespuestaDS.ConsultaRespuestaQr(Ccf_nro_trans);

                foreach (var item in ListaModelorespuestaDs)
                {
                    ModeloResQr = item;
                    break;
                }

                return ModeloResQr;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_nro_trans, metodo, "BuscarRespuestaDS", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
    }
}
