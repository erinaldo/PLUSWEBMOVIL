using CapaDatos.Modelos;
using CapaDatos.Modelos.ModelosNC;
using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace CapaProceso.Consultas
{
    public class ConsultawmtrespuestaNC
    {


        RespuestaNC consultaRespuesta = new RespuestaNC();
        JsonRespuestaNC modelorespuestaQR = new JsonRespuestaNC();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<JsonRespuestaNC> ConsultaRespuestaQr(string nro_trans)
        {
            try
            {
                List<JsonRespuestaNC> lista = new List<JsonRespuestaNC>();
                lista = consultaRespuesta.ConsultaRespuestaQR(nro_trans);

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, "ConsultawmtrespuestaNC.cs", "ConsultaRespuestaQR", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
        //Conusulta respuesta x linea
        public List<JsonRespuestaNC> RespuestaLineaQr(string nro_trans, string linea)
        {
            try
            {
                List<JsonRespuestaNC> lista = new List<JsonRespuestaNC>();
                lista = consultaRespuesta.RespuestaLineaQR(nro_trans, linea);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans,"ConsultawmtrespuestaNC.cs", "RespuestaLineaQR", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

    }
}
