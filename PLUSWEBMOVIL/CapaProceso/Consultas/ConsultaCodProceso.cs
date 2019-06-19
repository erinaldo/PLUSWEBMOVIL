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
   public  class ConsultaCodProceso
    {
        
        CodProcesoFactura consultaCodProceso = new CodProcesoFactura();
        //Rol consulta opcion facturacion general
        public List<modeloCodProcesoFactura> DatosCodProceso(string cod_proceso)
        {
            List<modeloCodProcesoFactura> lista = new List<modeloCodProcesoFactura>();
            lista = consultaCodProceso.ConsultaProceso(cod_proceso);
            return lista;
        }
    }
}
