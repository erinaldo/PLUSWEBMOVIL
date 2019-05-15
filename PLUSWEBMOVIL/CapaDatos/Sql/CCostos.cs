using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public class CCostos
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;

        public SqlDataReader ListaBuscaCCostos(string CC__usuario, string CC__cod_emp, string CC__cod_dpto)
        {

            cn = conexion.genearConexion();

            string consulta = ("wmspc_ccostos");
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.CommandType = CommandType.StoredProcedure;
            conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = CC__usuario;
            conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = CC__cod_emp;
            conmand.Parameters.Add("@cod_dpto", SqlDbType.VarChar).Value = CC__cod_dpto;
            


            SqlDataReader dr = conmand.ExecuteReader();

            return dr;

        }
    }
}
