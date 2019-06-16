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
    public class ConsultawmspctctrxCotizacion
    {
    
        CotizacionMonedaTrm consultatrmMoneda = new CotizacionMonedaTrm();
        public List<modelowmspctctrxCotizacion> BuscartatrmCotizacion(string usuario, string cod_emp, string nro_trans)
        {
            List<modelowmspctctrxCotizacion> lista = new List<modelowmspctctrxCotizacion>();
            lista = consultatrmMoneda.ListaMonedaTrm(usuario, cod_emp, nro_trans);           
            return lista;
        }

        //Consulta tasa de cambio de la fecha actual
        public List<modelowmspctctrxCotizacion> TasaCambioActual(string usuario, string cod_emp, string dia, string mes, string anio, string moneda)
        {
            List<modelowmspctctrxCotizacion> lista = new List<modelowmspctctrxCotizacion>();
            lista  = consultatrmMoneda.ActualMonedaTrm(usuario, cod_emp, dia, mes, anio, moneda);           
            return lista;
        }
    }
}
