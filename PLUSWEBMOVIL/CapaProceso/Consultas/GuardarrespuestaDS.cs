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
        public List<JsonEstadoDocElec> ListaEstados = new List<JsonEstadoDocElec>();
        JsonEstadoDocElec modeloestados = new JsonEstadoDocElec();
        public List<JsonRespuestaDE> ListaBuscarQr = null;
        public JsonRespuestaDE ModeloResQr = new JsonRespuestaDE();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();

        public List<DIAN> DIAN = new List<DIAN>();
        public List<JsonRespuestaDSFEV2> ListaBuscarDIAN = null;
        public DIAN ModeloResDIAN = new DIAN();

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

                guardarExcepcion.ClaseInsertarExcepcion(jsonRespuestaDE.nro_trans, metodo, "InsertarRespuestaJson", e.ToString(), DateTime.Now, "consulta");
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_nro_trans, metodo, "BuscarRespuestaDS", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }

        public JsonEstadoDocElec BuscarEstadosDocumento(string Ccf_nro_trans, string usuario, string empresa)
        {
            try
            {
                RespuestaDC consulta = new RespuestaDC();
                ListaEstados = consulta.ConsultaEstados(Ccf_nro_trans);

                foreach (var item in ListaEstados)
                {
                    modeloestados = item;
                    break;
                }

                return modeloestados;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "BuscarEstadosDocumento", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }

        //INSERTAR RESPUESTA DIAN-DA
        public string InsertarRespuestaJsonDIANDS(JsonRespuestaDSFEV2 jsonRespuestaDE)
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

                string respuesta = guardar.InsertarRespuestaDS_DIANFEV2(jsonRespuestaDE);               
               
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(jsonRespuestaDE.nro_trans, metodo, "InsertarRespuestaJsonDIANDS", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }

        //INSERTAR RESPUESTA DIAN-DA version 3 adjunto pdf
        public string InsertarRespuestaJsonDIANDS_Adjunto(JsonRespuestaDSFEV3 jsonRespuestaDE)
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

                string respuesta = guardar.InsertarRespuestaDS_DIANFEV3(jsonRespuestaDE);

                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(jsonRespuestaDE.nro_trans, metodo, "InsertarRespuestaJsonDIANDS_Adjunto", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }

        //Insertar respuesta de estados de documentos electronicos
        public string InsertarEstadoDocumento(JsonEstadoDocElec jsonRespuestaDE)
        {
            try
            {
                //consultar datos en la tabla wmt_respuestaDS secuencial para insertar linea
                modeloestados = null;
                modeloestados= BuscarEstadosDocumento(jsonRespuestaDE.nro_trans, jsonRespuestaDE.usuario_mod, jsonRespuestaDE.cod_emp);
                if (modeloestados == null)
                {
                    if (jsonRespuestaDE.linea <= 0)
                    {
                        jsonRespuestaDE.linea = 1;
                    }

                }
                else
                {
                    jsonRespuestaDE.linea = modeloestados.linea + 1;

                }

                string respuesta = guardar.InsertarEstadoDoc(jsonRespuestaDE);

                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(jsonRespuestaDE.cod_emp, metodo, "InsertarEstadoDocumento", e.ToString(), DateTime.Now, jsonRespuestaDE.cod_emp);
                return null;
            }
        }
    }
}
