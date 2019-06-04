using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class ImpuestosRest
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;

        public SqlDataReader ListaImpuestosRest(string usuario, string cod_emp, string nro_trans, string linea)
        {
            //Buscar cotizacion moneda trm

            cn = conexion.genearConexion();

            string consulta = ("wmspc_facturasWM_impu");
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.CommandType = CommandType.StoredProcedure;
            conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
            conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
            conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
            conmand.Parameters.Add("@linea", SqlDbType.VarChar).Value = linea;

            SqlDataReader dr = conmand.ExecuteReader();

            return dr;

        }
    }
}
