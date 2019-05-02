using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public class FPagosPos
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        
            public SqlDataReader consultaFormaPag()
        {
            cn = conexion.genearConexion();

            string consulta = "SELECT TOP 1000  * FROM wmm_fpagoPOS";
            SqlCommand conmand = new SqlCommand(consulta, cn);
            SqlDataReader dr = conmand.ExecuteReader();
            
            return dr;
           
        }

        
    }
}
