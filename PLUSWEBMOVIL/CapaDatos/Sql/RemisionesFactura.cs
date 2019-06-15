using System;
using CapaProceso.Modelos;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
namespace CapaDatos.Sql
{
   public  class RemisionesFactura
    {
       
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;

        //Insertar en la tabla wmt_remision_ins
        public string InsertarRemisionIns(modeloRemisionesFactura remisionCab)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "INSERT INTO  wmt_remision_ins (nro_trans, nro_docum, cod_emp, cod_cliente, usuario_mod, nro_audit, cod_proceso) VALUES (@nro_trans, @nro_docum, @cod_emp, @cod_cliente, @usuario_mod, @nro_audit, @cod_proceso)";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = remisionCab.nro_trans;
                conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = remisionCab.nro_docum;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = remisionCab.cod_emp;
                conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = remisionCab.cod_cliente;
                conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = remisionCab.usuario_mod;
                conmand.Parameters.Add("@nro_audit", SqlDbType.VarChar).Value = remisionCab.nro_audit;
                conmand.Parameters.Add("@cod_proceso", SqlDbType.VarChar).Value = remisionCab.cod_proceso;

                int dr = conmand.ExecuteNonQuery();
                return "Proforma";
            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }

        //Cargar remisiones nro_trans para la factura cabecera

        public SqlDataReader RemisionesFacturaUnico(string nro_trans)
        {

            cn = conexion.genearConexion();

            string consulta = ("SELECT * FROM  dbo.wmt_remision_cab WHERE nro_trans = @nro_trans");
            SqlCommand conmand = new SqlCommand(consulta, cn);


            conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;

            SqlDataReader dr = conmand.ExecuteReader();

            return dr;

        }
        //Cargar remisiones para la factura cabecera

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
