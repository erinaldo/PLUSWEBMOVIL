using System;
using CapaProceso.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace CapaDatos.Sql
{
    public class UsuarioSucursal
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        public string InsertarUsuarioSucursal(modeloUsuariosucursal usuariosucursal)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "INSERT INTO  wmm_userxsucur (cod_emp, cod_sucursal, usuario, usuario_mod, fecha_mod) VALUES (@cod_emp, @cod_sucursal, @usuario, @usuario_mod, @fecha_mod)";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = usuariosucursal.cod_emp;
                conmand.Parameters.Add("@cod_sucursal", SqlDbType.VarChar).Value = usuariosucursal.cod_sucursal;
                conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuariosucursal.usuario;
                conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = usuariosucursal.usuario_mod;
                conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = usuariosucursal.fecha_mod;
               /* conmand.Parameters.Add("@nro_audit", SqlDbType.VarChar).Value = usuariosucursal.nro_audit;
                conmand.Parameters.Add("@cod_proc_aud", SqlDbType.VarChar).Value = usuariosucursal.cod_proc_aud;*/
                int dr = conmand.ExecuteNonQuery();
                return "Usuario sucursal guardado correctamente";
            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }

        public SqlDataReader ConsultaUsuarioxSucursal(string cod_emp, string usuario)
        {
            cn = conexion.genearConexion();
            string consulta = "SELECT TOP 1 * FROM wmm_userxsucur WHERE cod_emp =@cod_emp AND usuario = @usuario";
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
            conmand.Parameters.Add("usuario", SqlDbType.VarChar).Value = usuario;

            SqlDataReader dr = conmand.ExecuteReader();

            return dr;
        }
    }
}
