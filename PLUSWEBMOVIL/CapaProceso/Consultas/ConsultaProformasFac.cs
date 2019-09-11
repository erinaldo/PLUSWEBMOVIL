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
   public  class ConsultaProformasFac
    {
        ConsultaProformas consultaProformas = new ConsultaProformas();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();


        //Consultar unica cabecera
        public List<modelowmtproformascab> BuscarProformasCab(string nro_trans)
        {
            try
            {
                List<modelowmtproformascab> lista = new List<modelowmtproformascab>();
                lista = consultaProformas.ConsultaProformasFactura(nro_trans);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, "ConsultaProformasFac.cs", "BuscarProformasCab", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
        public List<modelowmtproformascab> BuscarProformas(string cod_cliente, string estado, string tipo)
        {
            try
            {
                List<modelowmtproformascab> lista = new List<modelowmtproformascab>();
                lista = consultaProformas.ListaProformasFactura(cod_cliente, estado, tipo);

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "ConsultaProformasFac.cs", "BuscarProformas", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
    }
}
