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
            SqlDataReader dr = consultaRespuesta.ConsultaRespuestaQR(nro_trans);

            while (dr.Read())
            {
                JsonRespuestaDE item = new JsonRespuestaDE();
                item.nro_trans = Convert.ToString(dr["nro_trans"]);
                item.linea = Convert.ToInt16(dr["linea"]);
                item.qrdata = Convert.ToString(dr["qrdata"]);
                item.xml = Convert.ToString(dr["xml"]);
                item.id = Convert.ToString(dr["id"]);
                item.cufe = Convert.ToString(dr["cufe"]);
                item.error = Convert.ToString(dr["error"]);
                item.json = Convert.ToString(dr["json"]);
                lista.Add(item);
            }
            return lista;
        }
    }
}
