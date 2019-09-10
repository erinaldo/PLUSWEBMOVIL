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
   public  class ConsultaExcepciones
    {
        ExepcionesPW excepcion = new ExepcionesPW();
        //Insertar  wmt_excepcion
        public string InsertarExcepciones(modeloExepciones ModeloExcepcion)
        {
            string respuesta = excepcion.InsertarExcepcion(ModeloExcepcion);
            return respuesta;
        }
    }
}
