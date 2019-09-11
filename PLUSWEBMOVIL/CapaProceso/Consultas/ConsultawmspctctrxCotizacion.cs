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
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<modelowmspctctrxCotizacion> BuscartatrmCotizacion(string usuario, string cod_emp, string nro_trans)
        {
            try
            {
                List<modelowmspctctrxCotizacion> lista = new List<modelowmspctctrxCotizacion>();
                lista = consultatrmMoneda.ListaMonedaTrm(usuario, cod_emp, nro_trans);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "ConsultawmspctctrxCotizacion.cs", "BuscartatrmCotizacion", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }

        //Consulta tasa de cambio de la fecha actual
        public List<modelowmspctctrxCotizacion> TasaCambioActual(string usuario, string cod_emp, string dia, string mes, string anio, string moneda)
        {
            try
            {
                List<modelowmspctctrxCotizacion> lista = new List<modelowmspctctrxCotizacion>();
                lista = consultatrmMoneda.ActualMonedaTrm(usuario, cod_emp, dia, mes, anio, moneda);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "ConsultawmspctctrxCotizacion.cs", "TasaCambioActual", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
    }
}
