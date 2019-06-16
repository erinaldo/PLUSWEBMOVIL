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
    public class Consultaestadosfactura
    {
        EstadosFactura estados = new EstadosFactura();
        modeloestadosfactura modelestafactura = new modeloestadosfactura();

        public List<modeloestadosfactura> ConsultaEstadosFac(string EstF_proceso)
        {
            List<modeloestadosfactura> lista = new List<modeloestadosfactura>();
            lista = estados.ListaEstadosFactura(EstF_proceso);
           
            return lista;
        }
    }
}
