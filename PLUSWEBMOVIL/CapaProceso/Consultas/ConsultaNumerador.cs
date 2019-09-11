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
   public  class ConsultaNumerador
    {
        Numeradores numeradores = new Numeradores();
        modelonumerador modelonum = new modelonumerador();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public modelonumerador ConsultaNumeradores(string numerador)
        {
            try
            {
                modelonumerador Mnumerador = new modelonumerador();

                Mnumerador = numeradores.ConsultaNroTransaccion(numerador);

                return Mnumerador;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "ConsultaNumerador.cs", "ConsultaNumeradores", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
    }
}
