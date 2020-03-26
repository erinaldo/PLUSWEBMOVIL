using CapaDatos.Modelos;
using CapaDatos.Modelos.ModelosNC;
using CapaDatos.Sql.SqlNC;
using CapaProceso.Modelos;
using CapaProceso.RestCliente;
using CapaDatos.Sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
   public  class GuardarrespuestaNDDS
    {

       RespuestaNDebito guardar = new RespuestaNDebito();
        JsonRespuestaNC modeloRespuestaJson = new JsonRespuestaNC();
        public List<JsonRespuestaNDV2> ListaModelorespuestaDs = new List<JsonRespuestaNDV2>();
        public List<JsonRespuestaNDV2> ListaBuscarQr = null;
        public JsonRespuestaNDV2 ModeloResQr = new JsonRespuestaNDV2();
        public ConsultawmtrespuestaND consultaRespuestaDS = new ConsultawmtrespuestaND();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "GuardarrespuestaNDDS";
        public string InsertarRespuestaJson(JsonRespuestaNDV2 jsonRespuestaNC)
        {
            try
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
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(jsonRespuestaNC.nro_trans, "GuardarrespuestaNCDS.cs", "InsertarRespuestaJson", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }


        public JsonRespuestaNDV2 BuscarRespuestaDS(string Ccf_nro_trans)
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_nro_trans, "GuardarrespuestaNCDS.cs", "BuscarRespuestaD", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }


        //INSERTAR RESPUESTA DIAN-DA NOTA CREDITO
        public string InsertarRespuestaJsonDIANDS(JsonRespuestaNDV2 jsonRespuestaDE)
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

                string respuesta = guardar.InsertarRespuestaDS_DIANNCV2(jsonRespuestaDE);

                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(jsonRespuestaDE.nro_trans, metodo, "InsertarRespuestaJsonDIANDS", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
    }
}
