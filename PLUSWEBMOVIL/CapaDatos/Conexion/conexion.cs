using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace CapaDatos
{
    public class Conexion
    {
        public SqlConnection genearConexion()
        {
            try
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                cn.Open();
                return cn;
            }
            catch (IOException e)
            {

                return null;
                
            }
            
           
        }

        public SqlConnection genearConexionERP(String stringConexion)
        {
            try
            {
                SqlConnection cn = new SqlConnection(stringConexion);
                cn.Open();
                return cn;
            }
            catch (IOException e)
            {

                return null;

            }


        }

    }
}
