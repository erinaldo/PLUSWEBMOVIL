using System;
using CapaProceso.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace CapaDatos.Sql
{
    public class SucursalEmpresa
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;

        //Eliminar sucursal empresa
        public string EliminarSucursalEmpresa(modeloSucuralempresa sucursalEmpresa)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "DELETE FROM wmm_sucuremp WHERE  cod_sucursal = @cod_sucursal";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@cod_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.cod_sucursal;
                   int dr = conmand.ExecuteNonQuery();
                return "Sucursal eliminada correctamente";
            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }
        public string ActualizarSucursalEmpresa(modeloSucuralempresa sucursalEmpresa)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "UPDATE wmm_sucuremp SET  nom_sucursal = @nom_sucursal, dir_sucursal = @dir_sucursal, tel_sucursal = @tel_sucursal,email_sucursal = @email_sucursal, usuario_mod = @usuario_mod, fecha_mod = @fecha_mod WHERE cod_emp = @cod_emp AND  cod_sucursal = @cod_sucursal";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = sucursalEmpresa.cod_emp;
                conmand.Parameters.Add("@cod_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.cod_sucursal;
                conmand.Parameters.Add("@nom_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.nom_sucursal;
                conmand.Parameters.Add("@dir_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.dir_sucursal;
                conmand.Parameters.Add("@tel_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.tel_sucursal;
                conmand.Parameters.Add("@email_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.email_sucursal;
                conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = sucursalEmpresa.usuario_mod;
                conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = sucursalEmpresa.fecha_mod;
                /* conmand.Parameters.Add("@nro_audit", SqlDbType.VarChar).Value = sucursalEmpresa.nro_audit;
                 conmand.Parameters.Add("@cod_proc_aud", SqlDbType.VarChar).Value = sucursalEmpresa.cod_proc_aud;*/
                int dr = conmand.ExecuteNonQuery();
                return "Sucursal guardada correctamente";
            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }
        public string InsertarSucursalEmpresa(modeloSucuralempresa sucursalEmpresa)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "INSERT INTO  wmm_sucuremp (cod_emp, cod_sucursal, nom_sucursal, dir_sucursal, tel_sucursal,email_sucursal, usuario_mod, fecha_mod) VALUES (@cod_emp, @cod_sucursal, @nom_sucursal, @dir_sucursal, @tel_sucursal, @email_sucursal, @usuario_mod, @fecha_mod)";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = sucursalEmpresa.cod_emp;
                conmand.Parameters.Add("@cod_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.cod_sucursal;
                conmand.Parameters.Add("@nom_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.nom_sucursal;
                conmand.Parameters.Add("@dir_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.dir_sucursal;
                conmand.Parameters.Add("@tel_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.tel_sucursal;
                conmand.Parameters.Add("@email_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.email_sucursal;
                conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = sucursalEmpresa.usuario_mod;
                conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = sucursalEmpresa.fecha_mod;
               /* conmand.Parameters.Add("@nro_audit", SqlDbType.VarChar).Value = sucursalEmpresa.nro_audit;
                conmand.Parameters.Add("@cod_proc_aud", SqlDbType.VarChar).Value = sucursalEmpresa.cod_proc_aud;*/
                int dr = conmand.ExecuteNonQuery();
                return "Sucursal guardada correctamente";
            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }
        //Buscar unico sucrsal x empresa
        public SqlDataReader UnicoSucursalEmpresa(string cod_emp, string cod_sucursal)
        {
            cn = conexion.genearConexion();
            string consulta = "SELECT * FROM wmm_sucuremp WHERE cod_emp =@cod_emp AND cod_sucursal = @cod_sucursal";
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
            conmand.Parameters.Add("cod_sucursal", SqlDbType.VarChar).Value = cod_sucursal;

            SqlDataReader dr = conmand.ExecuteReader();

            return dr;
        }
        public SqlDataReader ConsultaSucursalEmpresa(string cod_emp)
        {
            cn = conexion.genearConexion();
            string consulta = "SELECT * FROM wmm_sucuremp WHERE cod_emp =@cod_emp";
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;

            SqlDataReader dr = conmand.ExecuteReader();

            return dr;
        }

        public SqlDataReader ConsultaSucursal(string cod_emp,string cod_sucursal)
        {
            cn = conexion.genearConexion();
            string consulta = "SELECT * FROM wmm_sucuremp WHERE cod_emp = @cod_emp AND cod_sucursal = @cod_sucursal";
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
            conmand.Parameters.Add("cod_sucursal", SqlDbType.VarChar).Value = cod_sucursal;

            SqlDataReader dr = conmand.ExecuteReader();

            return dr;
        }
    }
}
