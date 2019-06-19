using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CapaProceso.Modelos;
using CapaDatos.Modelos;

namespace CapaDatos.Sql
{
   public  class ModificarPrecioFactura
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        modeloRolModificarPrecio modeloRol = new modeloRolModificarPrecio();


        //Buscar permiso para modificar precio por usuario
        public List<modeloRolModificarPrecio> RespuestaRolModPrecio(string usuario, string cod_emp, string tipo, string campo, string accion)
        {

            using (cn = conexion.genearConexion())
            {
                List<modeloRolModificarPrecio> lista = new List<modeloRolModificarPrecio>();
                string consulta = ("wmspc_rolfact");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.CommandType = CommandType.StoredProcedure;
                conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                conmand.Parameters.Add("@campo", SqlDbType.VarChar).Value = campo;
                conmand.Parameters.Add("@accion", SqlDbType.VarChar).Value = accion;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {

                    modeloRolModificarPrecio item = new modeloRolModificarPrecio();
                    item.usuario = Convert.ToString(dr["usuario"]);

                    item.control_uso = Convert.ToString(dr["control_uso"]);

                    lista.Add(item);
                }
                return lista;
            }
        }
    }
}
