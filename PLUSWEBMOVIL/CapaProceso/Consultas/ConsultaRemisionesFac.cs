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
   public  class ConsultaRemisionesFac
    {
        RemisionesFactura consultaRemisiones = new RemisionesFactura();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<modeloRemisionesFactura> BuscarRemisiones(string cod_cliente, string estado, string tipo)
        {
            try
            {
                List<modeloRemisionesFactura> lista = new List<modeloRemisionesFactura>();
                lista = consultaRemisiones.ListaRemisionesFactura(cod_cliente, estado, tipo);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "ConsultaRemisionesFac.cs", "BuscarRemisiones", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

        public List<modeloRemisionesFactura> BuscarRemisionUnica(string nro_trans)
        {
            try
            {
                List<modeloRemisionesFactura> lista = new List<modeloRemisionesFactura>();
                lista = consultaRemisiones.RemisionesFacturaUnico(nro_trans);

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, "ConsultaRemisionesFac.cs", "BuscarRemisionUnica", e.ToString(), DateTime.Today, "consulta");
                return null;
            }

        }
    }
}
