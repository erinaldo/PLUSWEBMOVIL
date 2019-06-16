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
      
        public modelonumerador ConsultaNumeradores(string numerador)
        {
            modelonumerador Mnumerador = new modelonumerador();

            Mnumerador = numeradores.ConsultaNroTransaccion(numerador);
            
            return Mnumerador;
        }
    }
}
