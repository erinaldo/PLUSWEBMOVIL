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
        public List<modeloRemisionesFactura> BuscarRemisiones(string cod_cliente, string estado, string tipo)
        {
            List<modeloRemisionesFactura> lista = new List<modeloRemisionesFactura>();
            lista = consultaRemisiones.ListaRemisionesFactura(cod_cliente, estado, tipo);            
            return lista;
        }

        public List<modeloRemisionesFactura> BuscarRemisionUnica(string nro_trans)
        {
            List<modeloRemisionesFactura> lista = new List<modeloRemisionesFactura>();
            lista = consultaRemisiones.RemisionesFacturaUnico(nro_trans);
            
            return lista;
        }
    }
}
