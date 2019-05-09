using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public  class Articulos
    {
        
            Conexion conexion = new Conexion();
            public SqlConnection cn = null;

            public SqlDataReader ListaArticulos(string ArtB__usuario, string ArtB__cod_emp, string ArtB__articulo, string ArtB__tipo, string ArtB__compras, string ArtB__ventas)
            {

                cn = conexion.genearConexion();

                string consulta = ("wmspc_articulos");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.CommandType = CommandType.StoredProcedure;
                conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = ArtB__usuario;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = ArtB__cod_emp;
                conmand.Parameters.Add("@articulo", SqlDbType.VarChar).Value = ArtB__articulo;
                conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = ArtB__tipo;

                conmand.Parameters.Add("@compras", SqlDbType.VarChar).Value = ArtB__compras;
                conmand.Parameters.Add("@ventas", SqlDbType.VarChar).Value = ArtB__ventas;
            


            SqlDataReader dr = conmand.ExecuteReader();

                return dr;

            }
        }
}
