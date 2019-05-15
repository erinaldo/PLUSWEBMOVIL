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

            SqlDataReader dr = numeradores.ConsultaNroTransaccion(numerador);

            while (dr.Read())
            {


                Mnumerador.numerador = Convert.ToString(dr["numerador"]);
                Mnumerador.nombre = Convert.ToString(dr["nombre"]);
                Mnumerador.valor_asignado= Convert.ToString(dr["valor_asignado"]);
                Mnumerador.incremento = Convert.ToString(dr["incremento"]);
                Mnumerador.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                Mnumerador.fecha_mod= Convert.ToDateTime(dr["fecha_mod"]);
                Mnumerador.nro_audit= Convert.ToString(dr["nro_audit"]);
                Mnumerador.cod_pro_aud= Convert.ToString(dr["cod_proc_aud"]);
               

            }
            return Mnumerador;
        }
    }
}
