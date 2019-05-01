using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class conexion
    {
        public void genearConexion()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            cn.Open();
        }

    }
}
