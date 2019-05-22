using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public class EstadosFactura
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;

        public SqlDataReader ListaEstadosFactura(string EstF_proceso)
        {

            cn = conexion.genearConexion();

            string consulta = ("SELECT * FROM dbo.wmm_procesos_est WHERE cod_proceso = @proceso ORDER BY nom_estado ASC");
            SqlCommand conmand = new SqlCommand(consulta, cn);

          
            conmand.Parameters.Add("@proceso", SqlDbType.VarChar).Value = EstF_proceso;
          
            SqlDataReader dr = conmand.ExecuteReader();

            return dr;

        }
    }
}

