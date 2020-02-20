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
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "RolesUserFacturacion.cs";

        //Cargar administracion
        public List<modeloRolesFacturacion> RespuestaRolAdministracion(string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                    string consulta = ("SELECT * FROM wmc_menu_ppal WHERE usuario= @usuario AND menu='A'");
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
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "RespuestaRolAdministracion", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }

        //Cargar tablero
        public List<modeloRolesFacturacion> RespuestaRolTablero(string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                    string consulta = ("SELECT cod_rol FROM wm_userroles WHERE usuario = @usuario AND cod_rol IN ('401','402')");
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
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "RespuestaRolAdministracion", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }

        //Consulta prar crear una imprimir factura
        public List<modeloRolesFacturacion> RespuestaRolPrint(string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                    string consulta = ("SELECT cod_rol FROM wm_userroles WHERE usuario = @usuario AND cod_rol IN ('30','31','312','3121','31214')");
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
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "RespuestaRolPrint", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }

        //Consulta acceso rol para visualizar buscar factura una nueva factura
        public List<modeloRolesFacturacion> RespuestaAccesoFacturacion(string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                    string consulta = ("SELECT cod_rol FROM wm_userroles WHERE usuario = @usuario AND cod_rol IN ('30','31','312','3121','31211','31212','31213','31214','31215','31219')");
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
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "RespuestaAccesoFacturacion", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }

        //Consulta prar crear una nueva factura
        public List<modeloRolesFacturacion> RespuestaRolNuevo(string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                    string consulta = ("SELECT cod_rol FROM wm_userroles WHERE usuario = @usuario AND cod_rol IN ('30','31','312','3121','31211')");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloRolesFacturacion item = new modeloRolesFacturacion();
                        item.cod_rol = Convert.ToString(dr["cod_rol"]);

                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "RespuestaRolNuevo", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }

        //Consulat rol editar
        public List<modeloRolesFacturacion> RespuestaRolEditar(string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                    string consulta = ("SELECT cod_rol FROM wm_userroles WHERE usuario = @usuario AND cod_rol IN ('30','31','312','3121','31212')");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloRolesFacturacion item = new modeloRolesFacturacion();
                        item.cod_rol = Convert.ToString(dr["cod_rol"]);

                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "RespuestaRolEditar", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }

        //Consulatr rol eliminar
        public List<modeloRolesFacturacion> RespuestaRolEliminar(string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                    string consulta = ("SELECT cod_rol FROM wm_userroles WHERE usuario = @usuario AND cod_rol IN ('30','31','312','3121','31212')");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloRolesFacturacion item = new modeloRolesFacturacion();
                        item.cod_rol = Convert.ToString(dr["cod_rol"]);

                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "RespuestaRolEliminar", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
        //Consultar rol reactivar factura vta, vtae
        public List<modeloRolesFacturacion> RespuestaRolReactivar(string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                    string consulta = ("SELECT cod_rol FROM wm_userroles WHERE usuario = @usuario AND cod_rol IN ('31219')");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloRolesFacturacion item = new modeloRolesFacturacion();
                        item.cod_rol = Convert.ToString(dr["cod_rol"]);

                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "RespuestaRolReactivar", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }

        //Consultar rol reactivar POS
        public List<modeloRolesFacturacion> RespuestaRolReactivarPOS(string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                    string consulta = ("SELECT cod_rol FROM wm_userroles WHERE usuario = @usuario AND cod_rol IN ('31269')");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloRolesFacturacion item = new modeloRolesFacturacion();
                        item.cod_rol = Convert.ToString(dr["cod_rol"]);

                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "RespuestaRolReactivarPOS", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
    }
}
