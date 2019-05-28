using System;
using CapaProceso.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace CapaDatos.Sql
{
    public class CuentasBanco
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        public SqlDataReader ConsultaBancos(string usuario, string cod_emp)
        {
            cn = conexion.genearConexion();

            string consulta = ("wmspc_ctasbco");
            SqlCommand conmand = new SqlCommand(consulta, cn);
            conmand.CommandType = CommandType.StoredProcedure;
            conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
            conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
            
            

            SqlDataReader dr = conmand.ExecuteReader();

            return dr;
        }
    }
}
