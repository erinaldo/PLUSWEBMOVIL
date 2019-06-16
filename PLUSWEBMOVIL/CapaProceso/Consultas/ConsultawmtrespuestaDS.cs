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

        public List<JsonRespuestaDE> ConsultaRespuestaQr(string nro_trans)
        {
            List<JsonRespuestaDE> lista = new List<JsonRespuestaDE>();
            lista = consultaRespuesta.ConsultaRespuestaQR(nro_trans);
            
            return lista;
        }
        //Conusulta respuesta x linea
        public List<JsonRespuestaDE> RespuestaLineaQr(string nro_trans, string linea)
        {
            List<JsonRespuestaDE> lista = new List<JsonRespuestaDE>();
            lista = consultaRespuesta.RespuestaLineaQR(nro_trans, linea);            
            return lista;
        }

    }
}
