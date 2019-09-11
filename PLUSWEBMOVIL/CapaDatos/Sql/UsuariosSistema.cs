using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class UsuariosSistema
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public string  NombreUsuario(string usuario)
        {
            try
            {
                string Nombre_usu = "";
                using (cn = conexion.genearConexion())
                {
                    string insert = "SELECT Nombre FROM wm_usuario where usuario= @usuario ";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        Nombre_usu = Convert.ToString(dr["Nombre"]);


                    }

                    return Nombre_usu;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "UsuarioSistema.cs", "NombreUsuario", e.ToString(), DateTime.Today, usuario);
                return "No se pudo completar la acción." + "NombreUsuario." + " Por favor notificar al administrador.";
            }
        }
    }
}
