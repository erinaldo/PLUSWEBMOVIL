using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class Empresa
    {
            
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;

        public SqlDataReader ConsultaEmpresa(string cod_emp, string tipo)
        {
            cn = conexion.genearConexion();

            string consulta = "SELECT TOP 1  * FROM wmt_facturas_cab WHERE cod_emp = @cod_emp AND tipo = @tipo AND cod_docum = 'FV' AND estado = 'F' AND cod_docum = 'FV' AND serie_docum = 'S' AND nro_docum = '3948'";
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
            conmand.Parameters.Add("tipo", SqlDbType.VarChar).Value = tipo;


            SqlDataReader dr = conmand.ExecuteReader();

            return dr;

        }
    }
}
