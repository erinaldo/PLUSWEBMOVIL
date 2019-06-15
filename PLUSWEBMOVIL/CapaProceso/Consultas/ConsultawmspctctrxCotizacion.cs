using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
    public class ConsultawmspctctrxCotizacion
    {
    
        CotizacionMonedaTrm consultatrmMoneda = new CotizacionMonedaTrm();
        public List<modelowmspctctrxCotizacion> BuscartatrmCotizacion(string usuario, string cod_emp, string nro_trans)
        {
            List<modelowmspctctrxCotizacion> lista = new List<modelowmspctctrxCotizacion>();
            SqlDataReader dr = consultatrmMoneda.ListaMonedaTrm(usuario, cod_emp, nro_trans);

            while (dr.Read())
            {

                modelowmspctctrxCotizacion item = new modelowmspctctrxCotizacion();

                item.tc_mov1c = Convert.ToString(dr["tc_mov1c"]);
                item.nro_trans = Convert.ToString(dr["nro_trans"]);
                item.cod_emp = Convert.ToString(dr["cod_emp"]);
                item.mone_mn = Convert.ToString(dr["mone_mn"]);
                item.mone_trad = Convert.ToString(dr["mone_trad"]);
                item.cod_moneda = Convert.ToString(dr["cod_moneda"]);

                lista.Add(item);
            }
            return lista;
        }

        //Consulta tasa de cambio de la fecha actual
        public List<modelowmspctctrxCotizacion> TasaCambioActual(string usuario, string cod_emp, string dia, string mes, string anio, string moneda)
        {
            List<modelowmspctctrxCotizacion> lista = new List<modelowmspctctrxCotizacion>();
            SqlDataReader dr = consultatrmMoneda.ActualMonedaTrm(usuario, cod_emp, dia, mes, anio, moneda);

            while (dr.Read())
            {

                modelowmspctctrxCotizacion item = new modelowmspctctrxCotizacion();
                item.tc_mov = Convert.ToString(dr["tc_mov"]);
                item.tc_trad = Convert.ToString(dr["tc_trad"]);
              lista.Add(item);
            }
            return lista;
        }
    }
}
