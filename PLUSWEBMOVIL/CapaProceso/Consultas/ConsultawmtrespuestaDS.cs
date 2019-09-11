using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace CapaProceso.Consultas
{
    public class ConsultawmtrespuestaDS
    {


        RespuestaDC consultaRespuesta = new RespuestaDC();
        JsonRespuestaDE modelorespuestaQR = new JsonRespuestaDE();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public List<JsonRespuestaDE> ConsultaRespuestaQr(string nro_trans)
        {
            try
            {
                List<JsonRespuestaDE> lista = new List<JsonRespuestaDE>();
                lista = consultaRespuesta.ConsultaRespuestaQR(nro_trans);

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, "ConsultawmtrespuestaDs.cs", "ConsultaRespuestaQR", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
        //Conusulta respuesta x linea
        public List<JsonRespuestaDE> RespuestaLineaQr(string nro_trans, string linea)
        {
            try
            {
                List<JsonRespuestaDE> lista = new List<JsonRespuestaDE>();
                lista = consultaRespuesta.RespuestaLineaQR(nro_trans, linea);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, "ConsultawmtrespuestaDs.cs", "RespuestaLineaQR", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

    }
}
