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
        //Eliminar usuario x sucursal
        public string EliminarUsuarioSucursal(modeloUsuariosucursal sucursalEmpresa)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "DELETE FROM dbo.wmm_userxsucur WHERE  usuario = @usuario AND cod_sucursal = @cod_sucursal";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = sucursalEmpresa.usuario;
                conmand.Parameters.Add("@cod_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.cod_sucursal;

                int dr = conmand.ExecuteNonQuery();
                return "Usuario eliminado correctamente";
            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }

        //Actualizar usuario x sucursal
        public string ActualizarUsuarioSucursal(modeloUsuariosucursal sucursalEmpresa)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "UPDATE dbo.wmm_userxsucur SET  usuario = @usuario where cod_emp = @cod_emp AND cod_sucursal = @cod_sucursal AND usuario = @usu_ante";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = sucursalEmpresa.cod_emp;
                conmand.Parameters.Add("@cod_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.cod_sucursal;
                conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = sucursalEmpresa.usuario;
                conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = sucursalEmpresa.usuario_mod;
                conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = sucursalEmpresa.fecha_mod;
                conmand.Parameters.Add("@usu_ante", SqlDbType.VarChar).Value = sucursalEmpresa.usu_ante;
                /* conmand.Parameters.Add("@nro_audit", SqlDbType.VarChar).Value = sucursalEmpresa.nro_audit;
                 conmand.Parameters.Add("@cod_proc_aud", SqlDbType.VarChar).Value = sucursalEmpresa.cod_proc_aud;*/
                int dr = conmand.ExecuteNonQuery();
                return "Usuario guardado correctamente";
            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }
        //Insertar usuario x sucursal
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
        //CArgar vista principal
        public SqlDataReader ListaUsuarioxSucursal(string cod_emp, string cod_sucursal)
        {
            cn = conexion.genearConexion();
            string consulta = "SELECT dbo.wmm_userxsucur.cod_emp,dbo.wmm_userxsucur.cod_sucursal,dbo.wmm_userxsucur.usuario,dbo.wmm_userxsucur.usuario_mod,dbo.wmm_userxsucur.fecha_mod,dbo.wmm_userxsucur.nro_audit,dbo.wmm_userxsucur.cod_proc_aud,dbo.wmm_sucuremp.nom_sucursal FROM dbo.wmm_userxsucur ,dbo.wmm_sucuremp WHERE dbo.wmm_userxsucur.cod_emp = @cod_emp AND dbo.wmm_userxsucur.cod_sucursal = @cod_sucursal AND dbo.wmm_userxsucur.cod_sucursal = dbo.wmm_sucuremp.cod_sucursal ";
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
            conmand.Parameters.Add("cod_sucursal", SqlDbType.VarChar).Value = cod_sucursal;
            SqlDataReader dr = conmand.ExecuteReader();

            return dr;
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
        /*Buscar Unico usuario x sucursal*/
        public SqlDataReader UnicoUsuarioxSucursal(string cod_emp,  string usuario, string cod_sucursal)
        {
            cn = conexion.genearConexion();
            string consulta = "SELECT  * FROM wmm_userxsucur WHERE cod_emp =@cod_emp AND usuario = @usuario AND cod_sucursal = @cod_sucursal";
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
            conmand.Parameters.Add("usuario", SqlDbType.VarChar).Value = usuario;
            conmand.Parameters.Add("cod_sucursal", SqlDbType.VarChar).Value = cod_sucursal;

            SqlDataReader dr = conmand.ExecuteReader();

            return dr;
        }
    }
}
