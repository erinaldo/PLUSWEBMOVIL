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
    public class ConsultawmtrespuestaND
    {


        RespuestaNDebito consultaRespuesta = new RespuestaNDebito();
        JsonRespuestaNDV2 modelorespuestaQR = new JsonRespuestaNDV2();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public List<JsonRespuestaNDV2> ConsultaCUFE(string nro_trans)
        {
            try
            {
                List<JsonRespuestaNDV2> lista = new List<JsonRespuestaNDV2>();
                lista = consultaRespuesta.ConsultaCUFE(nro_trans);

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, "ConsultawmtrespuestaNC.cs", "ConsultaCUFE", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }
        public List<JsonRespuestaNDV2> ConsultaRespuestaQr(string nro_trans)
        {
            try
            {
                List<JsonRespuestaNDV2> lista = new List<JsonRespuestaNDV2>();
                lista = consultaRespuesta.ConsultaRespuestaQR(nro_trans);

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, "ConsultawmtrespuestaNC.cs", "ConsultaRespuestaQR", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }
        //Conusulta respuesta x linea
        public List<JsonRespuestaNDV2> RespuestaLineaQr(string nro_trans, string linea)
        {
            try
            {
                List<JsonRespuestaNDV2> lista = new List<JsonRespuestaNDV2>();
                lista = consultaRespuesta.RespuestaLineaQR(nro_trans, linea);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans,"ConsultawmtrespuestaNC.cs", "RespuestaLineaQR", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }

    }
}
