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
  public   class ConsultaProformaIns
    {
       
        ConsultaProformas insertar = new ConsultaProformas();
        modelowmtproformascab ModeloInsertarPro = new modelowmtproformascab();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public string InsertarProformaIns(modelowmtproformascab ProformaIns)
        {
            try
            {
                string respuesta = insertar.InsertarProformaIns(ProformaIns);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ProformaIns.cod_emp, "ConsultaProformaIns.cs", "InsertarProformaIns", e.ToString(), DateTime.Today, ProformaIns.usuario_mod);
                return "No se pudo completar la acción." + "InsertarProformaIns." + " Por favor notificar al administrador.";
            }
        }
    }
}
