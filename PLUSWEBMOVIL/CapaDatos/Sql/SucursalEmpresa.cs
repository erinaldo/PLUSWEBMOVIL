using System;
using CapaProceso.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using CapaDatos.Modelos;

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
                using (cn = conexion.genearConexion())
                {
                    string insert = "DELETE FROM wmm_sucuremp WHERE  cod_sucursal = @cod_sucursal";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@cod_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.cod_sucursal;
                    int dr = conmand.ExecuteNonQuery();
                    return "Sucursal eliminada correctamente";
                }               
               
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
                using (cn = conexion.genearConexion())
                {
                    string insert = "UPDATE wmm_sucuremp SET  nom_sucursal = @nom_sucursal, dir_sucursal = @dir_sucursal, tel_sucursal = @tel_sucursal,email_sucursal = @email_sucursal, usuario_mod = @usuario_mod, fecha_mod = @fecha_mod WHERE cod_emp = @cod_emp AND  cod_sucursal = @cod_sucursal";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = sucursalEmpresa.cod_emp;
                    conmand.Parameters.Add("@cod_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.cod_sucursal.Trim();
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

                string insert = "INSERT INTO  wmm_sucuremp (cod_emp, cod_sucursal, nom_sucursal, dir_sucursal, tel_sucursal,email_sucursal, usuario_mod, fecha_mod, nro_audit, cod_proc_aud) VALUES (@cod_emp, @cod_sucursal, @nom_sucursal, @dir_sucursal, @tel_sucursal, @email_sucursal, @usuario_mod, @fecha_mod, @nro_audit, @cod_proc_aud)";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = sucursalEmpresa.cod_emp;
                conmand.Parameters.Add("@cod_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.cod_sucursal;
                conmand.Parameters.Add("@nom_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.nom_sucursal;
                conmand.Parameters.Add("@dir_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.dir_sucursal;
                conmand.Parameters.Add("@tel_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.tel_sucursal;
                conmand.Parameters.Add("@email_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.email_sucursal;
                conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = sucursalEmpresa.usuario_mod;
                conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = sucursalEmpresa.fecha_mod;
                conmand.Parameters.Add("@nro_audit", SqlDbType.VarChar).Value = sucursalEmpresa.nro_audit;
                conmand.Parameters.Add("@cod_proc_aud", SqlDbType.VarChar).Value = sucursalEmpresa.cod_proc_aud;
                int dr = conmand.ExecuteNonQuery();
                return "Sucursal guardada correctamente";
            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }
        //Buscar unico sucrsal x empresa
        public List<modeloSucuralempresa> UnicoSucursalEmpresa(string cod_emp, string cod_sucursal)
        {
            using (cn = conexion.genearConexion())
            {
                List<modeloSucuralempresa> lista = new List<modeloSucuralempresa>();
                string consulta = "SELECT * FROM wmm_sucuremp WHERE cod_emp =@cod_emp AND cod_sucursal = @cod_sucursal";
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
                conmand.Parameters.Add("cod_sucursal", SqlDbType.VarChar).Value = cod_sucursal;

                SqlDataReader dr = conmand.ExecuteReader();
                while (dr.Read())
                {
                    modeloSucuralempresa item = new modeloSucuralempresa();
                    item.sucursales = Convert.ToString(dr["cod_sucursal"]) + " - " + Convert.ToString(dr["nom_sucursal"]);
                    item.cod_emp = Convert.ToString(dr["cod_emp"]);
                    item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                    item.nom_sucursal = Convert.ToString(dr["nom_sucursal"]);
                    item.dir_sucursal = Convert.ToString(dr["dir_sucursal"]);
                    item.tel_sucursal = Convert.ToString(dr["tel_sucursal"]);
                    item.email_sucursal = Convert.ToString(dr["email_sucursal"]);
                    item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                    item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                    item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                    item.nro_audit = Convert.ToString(dr["nro_audit"]);
                    lista.Add(item);
                }
                return lista;
            }
            
            
        }
        public List<modeloSucuralempresa> ConsultaSucursalEmpresa(string cod_emp)
        {
            using (cn = conexion.genearConexion())
            {
                List<modeloSucuralempresa> lista = new List<modeloSucuralempresa>();
                string consulta = "SELECT * FROM wmm_sucuremp WHERE cod_emp =@cod_emp";
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;

                SqlDataReader dr = conmand.ExecuteReader();
                while (dr.Read())
                {
                    modeloSucuralempresa item = new modeloSucuralempresa();
                    item.sucursales = Convert.ToString(dr["cod_sucursal"]) + " - " + Convert.ToString(dr["nom_sucursal"]);
                    item.cod_emp = Convert.ToString(dr["cod_emp"]);
                    item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                    item.nom_sucursal = Convert.ToString(dr["nom_sucursal"]);
                    item.dir_sucursal = Convert.ToString(dr["dir_sucursal"]);
                    item.tel_sucursal = Convert.ToString(dr["tel_sucursal"]);
                    item.email_sucursal = Convert.ToString(dr["email_sucursal"]);
                    item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                    item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                    item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                    item.nro_audit = Convert.ToString(dr["nro_audit"]);
                    lista.Add(item);
                }
                return lista;
            }           
            
        }

        public List<modeloSucuralempresa> ConsultaSucursal(string cod_emp,string cod_sucursal)
        {
            using (cn = conexion.genearConexion())
            {
                List<modeloSucuralempresa> lista = new List<modeloSucuralempresa>();
                string consulta = "SELECT * FROM wmm_sucuremp WHERE cod_emp = @cod_emp AND cod_sucursal = @cod_sucursal";
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
                conmand.Parameters.Add("cod_sucursal", SqlDbType.VarChar).Value = cod_sucursal;

                SqlDataReader dr = conmand.ExecuteReader();
                while (dr.Read())
                {
                    modeloSucuralempresa item = new modeloSucuralempresa();
                    item.sucursales = Convert.ToString(dr["cod_sucursal"]) + " - " + Convert.ToString(dr["nom_sucursal"]);
                    item.cod_emp = Convert.ToString(dr["cod_emp"]);
                    item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                    item.nom_sucursal = Convert.ToString(dr["nom_sucursal"]);
                    item.dir_sucursal = Convert.ToString(dr["dir_sucursal"]);
                    item.tel_sucursal = Convert.ToString(dr["tel_sucursal"]);
                    item.email_sucursal = Convert.ToString(dr["email_sucursal"]);
                    item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                    item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                    item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                    item.nro_audit = Convert.ToString(dr["nro_audit"]);
                    lista.Add(item);
                }
                return lista;
            }            
            
        }
    }
}
