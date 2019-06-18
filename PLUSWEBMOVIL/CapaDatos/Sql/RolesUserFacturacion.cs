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
   public  class RolesUserFacturacion
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        modeloRolesFacturacion modelorol = new modeloRolesFacturacion();
       

         //Consulta prar crear una imprimir factura
        public List<modeloRolesFacturacion> RespuestaRolPrint(string usuario)
        {

            using (cn = conexion.genearConexion())
            {
                List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                string consulta = ("SELECT cod_rol FROM dbo.wm_userroles WHERE usuario = 'desarrollo' AND cod_rol IN ('30','31','312','3121','31214')");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {

                    modeloRolesFacturacion item = new modeloRolesFacturacion();
                    item.cod_rol = Convert.ToString("cod_rol");

                    lista.Add(item);
                }
                return lista;
            }
        }
        //Consulta prar crear una nueva factura
        public List<modeloRolesFacturacion> RespuestaRolNuevo(string usuario)
        {

            using (cn = conexion.genearConexion())
            {
                List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                string consulta = ("SELECT cod_rol FROM dbo.wm_userroles WHERE usuario = @usuario AND cod_rol IN ('30','31','312','3121','31211')");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {

                    modeloRolesFacturacion item = new modeloRolesFacturacion();
                    item.cod_rol = Convert.ToString("cod_rol");

                    lista.Add(item);
                }
                return lista;
            }
        }

        //Consulat rol editar
        public List<modeloRolesFacturacion> RespuestaRolEditar(string usuario)
        {

            using (cn = conexion.genearConexion())
            {
                List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                string consulta = ("SELECT cod_rol FROM dbo.wm_userroles WHERE usuario = 'desarrollo' AND cod_rol IN ('30','31','312','3121','31212')");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {

                    modeloRolesFacturacion item = new modeloRolesFacturacion();
                    item.cod_rol = Convert.ToString("cod_rol");

                    lista.Add(item);
                }
                return lista;
            }
        }

        //Consulatr rol eliminar
        public List<modeloRolesFacturacion> RespuestaRolEliminar(string usuario)
        {

            using (cn = conexion.genearConexion())
            {
                List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                string consulta = ("SELECT cod_rol FROM dbo.wm_userroles WHERE usuario = 'desarrollo' AND cod_rol IN ('30','31','312','3121','31212')");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {

                    modeloRolesFacturacion item = new modeloRolesFacturacion();
                    item.cod_rol = Convert.ToString("cod_rol");

                    lista.Add(item);
                }
                return lista;
            }
        }
        //Consultar rol reactivar
        public List<modeloRolesFacturacion> RespuestaRolReactivar(string usuario)
        {

            using (cn = conexion.genearConexion())
            {
                List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                string consulta = ("SELECT cod_rol FROM dbo.wm_userroles WHERE usuario = 'desarrollo' AND cod_rol IN ('30','31','312','3121','31212')");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {

                    modeloRolesFacturacion item = new modeloRolesFacturacion();
                    item.cod_rol = Convert.ToString("cod_rol");

                    lista.Add(item);
                }
                return lista;
            }
        }
    }
}
