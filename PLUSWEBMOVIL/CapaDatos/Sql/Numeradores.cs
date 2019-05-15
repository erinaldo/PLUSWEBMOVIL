using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
public class Numeradores
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        
        public SqlDataReader ConsultaNroTransaccion(string numerador)
        {
            cn = conexion.genearConexion();

            string insert = "UPDATE n SET n.valor_asignado = (SELECT SUM (valor_asignado + incremento)AS TotAcum FROM wm_numeradores  WHERE numerador = @numerador) FROM wm_numeradores n WHERE n.numerador = @numerador";

            SqlCommand conmand = new SqlCommand(insert, cn);

            conmand.Parameters.Add("@numerador", SqlDbType.VarChar).Value = numerador;

            conmand.ExecuteNonQuery();


            string consulta = "SELECT TOP 1 *  FROM wm_numeradores WHERE numerador = @numerador";
            conmand = new SqlCommand(consulta, cn);

            conmand.Parameters.Add("@numerador", SqlDbType.VarChar).Value = numerador;
       
            SqlDataReader dr = conmand.ExecuteReader();

            return dr;

        }
    }
}
