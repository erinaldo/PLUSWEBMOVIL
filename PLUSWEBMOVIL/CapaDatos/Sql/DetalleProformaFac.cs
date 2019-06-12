using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
  public   class DetalleProformaFac
    {
        //Cargar proformas detalle para la factura cabecera
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;



        public SqlDataReader ListaProformasDetalle(string nro_trans)
        {

            cn = conexion.genearConexion();

            string consulta = ("SELECT * FROM wmt_proformas_det WHERE  nro_trans = @nro_trans");
            SqlCommand conmand = new SqlCommand(consulta, cn);


            conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
            SqlDataReader dr = conmand.ExecuteReader();

            return dr;

        }
    }
}
