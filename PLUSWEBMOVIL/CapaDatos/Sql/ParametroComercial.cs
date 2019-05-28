using System;
using CapaProceso.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace CapaDatos.Sql
{
    public class ParametroComercial
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        public SqlDataReader ConsultaComercial(string cod_emp)
        {
            cn = conexion.genearConexion();
            string consulta = "SELECT * FROM dbo.wmm_param_comercial WHERE cod_emp = @cod_emp";
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;



            SqlDataReader dr = conmand.ExecuteReader();

            return dr;
        }
    }
}
