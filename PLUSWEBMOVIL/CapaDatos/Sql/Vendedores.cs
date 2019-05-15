using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class Vendedores
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;

        public SqlDataReader ListaBuscaVendedores(string Vend__usuario, string Vend__cod_emp, string Vend__cod_tipotit, string Vend__cod_tit)
        {

            cn = conexion.genearConexion();

            string consulta = ("wmspc_titulares");
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.CommandType = CommandType.StoredProcedure;
            conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = Vend__usuario;
            conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = Vend__cod_emp;
            conmand.Parameters.Add("@cod_tipotit", SqlDbType.VarChar).Value = Vend__cod_tipotit;
            conmand.Parameters.Add("@cod_tit", SqlDbType.VarChar).Value = Vend__cod_tit;



            SqlDataReader dr = conmand.ExecuteReader();

            return dr;

        }
    }
}
