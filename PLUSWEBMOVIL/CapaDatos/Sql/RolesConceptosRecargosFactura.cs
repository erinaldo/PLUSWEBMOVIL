using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public  class RolesConceptosRecargosFactura
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
       
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "RolesconceptosRecrgoFactura.cs";
        //Consulta prar crear una nueva Concepto Fiscal
        public string RespuestaRolAcceso(string usuario, string empresa)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string cod_rol = null;
                    string consulta = ("SELECT cod_rol FROM wm_userroles WHERE usuario = @usuario AND cod_rol='3017'");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        cod_rol = Convert.ToString(dr["cod_rol"]);
                    }
                    return cod_rol;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "RespuestaRolAcceso", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        //Consulta prar crear una nueva Concepto Fiscal
        public string RespuestaRolNuevo(string usuario, string empresa)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string cod_rol = null;
                    string consulta = ("SELECT cod_rol FROM wm_userroles WHERE usuario = @usuario AND cod_rol='30171'");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                       cod_rol = Convert.ToString(dr["cod_rol"]);
                    }
                    return cod_rol;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "RespuestaRolNuevo", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        //Consulta prar crear actualizar Concepto Fiscal
        public string RespuestaRolActualizar(string usuario, string empresa)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string cod_rol = null;
                    string consulta = ("SELECT cod_rol FROM wm_userroles WHERE usuario = @usuario AND cod_rol='30172'");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        cod_rol = Convert.ToString(dr["cod_rol"]);
                    }
                    return cod_rol;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "RespuestaRolActualizar", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        //Consulta prar crear eliminar Concepto Fiscal
        public string RespuestaRolEliminar(string usuario, string empresa)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string cod_rol = null;
                    string consulta = ("SELECT cod_rol FROM wm_userroles WHERE usuario = @usuario AND cod_rol='30173'");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        cod_rol = Convert.ToString(dr["cod_rol"]);
                    }
                    return cod_rol;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "RespuestaRolEliminar", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        //Consulta prar acceso Concepto Factura
        public string RespuestaRolAccesoCF(string usuario, string empresa)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string cod_rol = null;
                    string consulta = ("SELECT cod_rol FROM wm_userroles WHERE usuario = @usuario AND cod_rol='3114'");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        cod_rol = Convert.ToString(dr["cod_rol"]);
                    }
                    return cod_rol;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "RespuestaRolAccesoCF", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        //Consulta prar crear una nueva Concepto Factura
        public string RespuestaRolNuevoCF(string usuario, string empresa)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string cod_rol = null;
                    string consulta = ("SELECT cod_rol FROM wm_userroles WHERE usuario = @usuario AND cod_rol='31141'");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        cod_rol = Convert.ToString(dr["cod_rol"]);
                    }
                    return cod_rol;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "RespuestaRolNuevoCF", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }

        //Consulta prar crear actualizar Concepto Factura
        public string RespuestaRolActualizarCF(string usuario, string empresa)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string cod_rol = null;
                    string consulta = ("SELECT cod_rol FROM wm_userroles WHERE usuario = @usuario AND cod_rol='31142'");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        cod_rol = Convert.ToString(dr["cod_rol"]);
                    }
                    return cod_rol;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "RespuestaRolActualizarCF", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }

        //Consulta prar crear eliminar Concepto  Factura
        public string RespuestaRolEliminarCF(string usuario, string empresa)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string cod_rol = null;
                    string consulta = ("SELECT cod_rol FROM wm_userroles WHERE usuario = @usuario AND cod_rol='31143'");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        cod_rol = Convert.ToString(dr["cod_rol"]);
                    }
                    return cod_rol;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "RespuestaRolEliminarCF", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
    }
}
