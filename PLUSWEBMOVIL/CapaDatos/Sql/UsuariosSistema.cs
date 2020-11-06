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

                guardarExcepcion.ClaseInsertarExcepcion("0", "UsuarioSistema.cs", "NombreUsuario", e.ToString(), DateTime.Now, usuario);
                return "No se pudo completar la acción." + "NombreUsuario." + " Por favor notificar al administrador.";
            }
        }

        public List<modeloUsuarioSistema> ListaUsuariosSistema(string usuario_mod, string cod_emp)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloUsuarioSistema> lista = new List<modeloUsuarioSistema>();
                    string consulta = ("select * from wmv_usersxemp where cod_emp =@cod_emp and estado_usuario ='A'");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloUsuarioSistema item = new modeloUsuarioSistema();
                        item.usuario = Convert.ToString(dr["usuario"]);
                        item.Nombre = Convert.ToString(dr["nombre"]);
                        item.estado_usuario = Convert.ToString(dr["estado_usuario"]);
                      
                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "UsuariosSistema.cs", "ListaUsuariosSistema", e.ToString(), DateTime.Now, usuario_mod);
                return null;
            }


        }
    }
}
