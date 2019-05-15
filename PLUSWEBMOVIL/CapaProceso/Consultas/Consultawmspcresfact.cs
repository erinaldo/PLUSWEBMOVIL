using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
    public class Consultawmspcresfact
    {
        SerieDocumento seriedocumento = new SerieDocumento();
        modelowmspcresfact resolucionesfac = new modelowmspcresfact();
        public List<modelowmspcresfact> ConsultaResolusiones(string ResF_usuario, string ResF_cod_emp, string ResF_estado, string ResF_serie, string ResF_tipo)
        {
            List<modelowmspcresfact> lista = new List<modelowmspcresfact>();
            SqlDataReader dr = seriedocumento.ListaBuscaSerieDocumento(ResF_usuario, ResF_cod_emp, ResF_estado,  ResF_serie,  ResF_tipo);

            while (dr.Read())
            {

                modelowmspcresfact item = new modelowmspcresfact(Convert.ToString(dr["cod_atrib1"]), Convert.ToString(dr["serie_docum"]), Convert.ToString(dr["nro_docum"]), Convert.ToString(dr["nro_docum_ref"]), Convert.ToString(dr["activo"]),Convert.ToString(dr["numerador"]), Convert.ToDateTime(dr["fec_valor"]), Convert.ToDateTime(dr["fec_venc"]), Convert.ToString(dr["tipo"]));
                lista.Add(item);

            }
            return lista;
        }

    }
}
