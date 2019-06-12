using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public  class RemisionesFactura
    {
        //Cargar remisiones para la factura cabecera
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;



        public SqlDataReader ListaRemisionesFactura(string cod_cliente, string estado, string tipo)
        {

            cn = conexion.genearConexion();

            string consulta = ("SELECT * FROM  dbo.wmt_remision_cab WHERE cod_cliente = @cod_cliente AND estado = @estado AND tipo = @tipo");
            SqlCommand conmand = new SqlCommand(consulta, cn);


            conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = cod_cliente;
            conmand.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;
            conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;

            SqlDataReader dr = conmand.ExecuteReader();

            return dr;

        }
    }
}
