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
        public string InsertarProformaIns(modelowmtproformascab ProformaIns)
        {
            string respuesta = insertar.InsertarProformaIns(ProformaIns);
            return respuesta;
        }
    }
}
