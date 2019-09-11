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
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public string InsertarRemisionaIns(modeloRemisionesFactura RemisionIns)
        {
            try
            {
                string respuesta = insertarRe.InsertarRemisionIns(RemisionIns);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(RemisionIns.cod_emp, "ConsultaRemisionIns.cs", "InsertarRemisionIns", e.ToString(), DateTime.Today, RemisionIns.usuario_mod);
                return "No se pudo completar la acción." + "InsertarRemisionIns." + " Por favor notificar al administrador.";
            }
        }
    }
}
