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
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "GuardarrespuestaNCDS";
        public string InsertarRespuestaJson(JsonRespuestaNC jsonRespuestaNC)
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

                guardarExcepcion.ClaseInsertarExcepcion(jsonRespuestaNC.nro_trans, "GuardarrespuestaNCDS.cs", "InsertarRespuestaJson", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }


        public JsonRespuestaNC BuscarRespuestaDS(string Ccf_nro_trans)
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_nro_trans, "GuardarrespuestaNCDS.cs", "BuscarRespuestaD", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }


        //INSERTAR RESPUESTA DIAN-DA NOTA CREDITO
        public string InsertarRespuestaJsonDIANDS(JsonRespuestaNCV2 jsonRespuestaDE)
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

                guardarExcepcion.ClaseInsertarExcepcion(jsonRespuestaDE.nro_trans, metodo, "InsertarRespuestaJsonDIANDS", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }

        //INSERTAR RESPUESTA DIAN-DA NOTA CREDITO
        public string InsertarRespuestaJsonDIANDSND(JsonRespuestaNDV2 jsonRespuestaDE)
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

                string respuesta = guardar.InsertarRespuestaDS_DIANNDV2(jsonRespuestaDE);

                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(jsonRespuestaDE.nro_trans, metodo, "InsertarRespuestaJsonDIANDS", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }


    }
}
