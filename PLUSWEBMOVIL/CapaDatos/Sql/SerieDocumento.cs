using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class SerieDocumento
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        public SqlDataReader ListaBuscaSerieDocumento(string ResF_usuario, string ResF_cod_emp, string ResF_estado, string ResF_serie, string ResF_tipo)
        {
      

            cn = conexion.genearConexion();

            string consulta = ("wmspc_resfact");
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.CommandType = CommandType.StoredProcedure;
            
            conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = ResF_usuario;
            conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = ResF_cod_emp;
            conmand.Parameters.Add("@estado", SqlDbType.VarChar).Value = ResF_estado;
            conmand.Parameters.Add("@serie", SqlDbType.VarChar).Value = ResF_serie;
            conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = ResF_tipo;

            SqlDataReader dr = conmand.ExecuteReader();


            return dr;

        }
    }
}
