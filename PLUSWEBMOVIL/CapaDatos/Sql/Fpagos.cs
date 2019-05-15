using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class Fpagos
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;

        public SqlDataReader ListaBuscaFPago(string FP__usuario, string FP__cod_emp, string FP__cod_fpago)
        {

            cn = conexion.genearConexion();

            string consulta = ("wmspc_formaspag");
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.CommandType = CommandType.StoredProcedure;
            conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = FP__usuario;
            conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = FP__cod_emp;
            conmand.Parameters.Add("@cod_fpago", SqlDbType.VarChar).Value = FP__cod_fpago;



            SqlDataReader dr = conmand.ExecuteReader();

            return dr;

        }
    }
}
