using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class CMonedas
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;

        public SqlDataReader ListaBuscaCMonedas(string MonB__usuario, string MonB__cod_emp, string MonB__moneda)
        {

            cn = conexion.genearConexion();

            string consulta = ("wmspc_monedas");
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.CommandType = CommandType.StoredProcedure;
            conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = MonB__usuario;
            conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = MonB__cod_emp;
            conmand.Parameters.Add("@moneda", SqlDbType.VarChar).Value = MonB__moneda;



            SqlDataReader dr = conmand.ExecuteReader();

            return dr;

        }
    }
}
