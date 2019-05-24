using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class ConsultaLogoSql
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;

        public SqlDataReader ConsultaLogo(string cod_emp, string usuario)
        {
            cn = conexion.genearConexion();

            string consulta = ("wmspc_logo");
            SqlCommand conmand = new SqlCommand(consulta, cn);
            conmand.CommandType = CommandType.StoredProcedure;
            conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
            conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;           

            SqlDataReader dr = conmand.ExecuteReader();

            return dr;


        }

        public SqlDataReader CosnualtaUsuario(string usuario)
        {

            cn = conexion.genearConexion();

            string consulta = ("SELECT * FROM wm_usuario WHERE usuario = @usuario");
            SqlCommand conmand = new SqlCommand(consulta, cn);


            conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

            SqlDataReader dr = conmand.ExecuteReader();

            return dr;

        }
    }
}
