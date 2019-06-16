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
   public class ConsultaRemisionIns
    {
        
   
        RemisionesFactura insertarRe = new RemisionesFactura();
        modeloRemisionesFactura Modelo = new modeloRemisionesFactura();

        public string InsertarRemisionaIns(modeloRemisionesFactura RemisionIns)
        {
            string respuesta = insertarRe.InsertarRemisionIns(RemisionIns);
            return respuesta;
        }
    }
}
