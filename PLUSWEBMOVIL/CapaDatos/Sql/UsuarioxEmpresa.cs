using System;
using CapaProceso.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace CapaDatos.Sql
{
   public  class UsuarioxEmpresa
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;

        public SqlDataReader ConsultaUsuarioEmpresa(string cod_emp)
        {
            cn = conexion.genearConexion();
            string consulta = "SELECT * FROM wm_userxemp WHERE cod_emp =@cod_emp";
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;

            SqlDataReader dr = conmand.ExecuteReader();

            return dr;
        }
    }
}
