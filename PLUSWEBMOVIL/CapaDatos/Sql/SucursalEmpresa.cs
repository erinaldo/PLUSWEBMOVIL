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
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "SucursalEmpresa.cs";
        //Eliminar sucursal empresa
        public string EliminarSucursalEmpresa(modeloSucuralempresa sucursalEmpresa)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "DELETE FROM wmm_sucuremp WHERE  cod_sucursal = @cod_sucursal AND cod_emp =@cod_emp";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@cod_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.cod_sucursal;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = sucursalEmpresa.cod_emp;
                    
                    int dr = conmand.ExecuteNonQuery();
                    return "Sucursal eliminada correctamente";
                }               
               
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(sucursalEmpresa.cod_emp, metodo, "EliminarSucursalEmpresa", e.ToString(), DateTime.Now, sucursalEmpresa.usuario_mod);
                return "No se pudo completar la acción." + "EliminarSucursalEmpresa." + " Por favor notificar al administrador.";
            }

        }
        public string ActualizarSucursalEmpresa(modeloSucuralempresa sucursalEmpresa)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "UPDATE wmm_sucuremp SET  nom_sucursal = @nom_sucursal, dir_sucursal = @dir_sucursal, tel_sucursal = @tel_sucursal,email_sucursal = @email_sucursal, usuario_mod = @usuario_mod, fecha_mod = @fecha_mod, serie_factura =@serie_factura, serie_nc =@serie_nc, serie_nd =@serie_nd, serie_ncn =@serie_ncn, serie_ndn =@serie_ndn, serie_facturan =@serie_facturan, cod_ciudad =@cod_ciudad, cod_provincia=@cod_provincia, cod_pais =@cod_pais WHERE cod_emp = @cod_emp AND  cod_sucursal = @cod_sucursal";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = sucursalEmpresa.cod_emp;
                    conmand.Parameters.Add("@cod_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.cod_sucursal.Trim();
                    conmand.Parameters.Add("@nom_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.nom_sucursal;
                    conmand.Parameters.Add("@dir_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.dir_sucursal;
                    conmand.Parameters.Add("@tel_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.tel_sucursal;
                    conmand.Parameters.Add("@email_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.email_sucursal;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = sucursalEmpresa.usuario_mod;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = sucursalEmpresa.fecha_mod;
                    conmand.Parameters.Add("@serie_factura", SqlDbType.VarChar).Value = sucursalEmpresa.serie_factura;
                    conmand.Parameters.Add("@serie_facturan", SqlDbType.VarChar).Value = sucursalEmpresa.serie_facn;
                    conmand.Parameters.Add("@serie_nc", SqlDbType.VarChar).Value = sucursalEmpresa.serie_nc;
                    conmand.Parameters.Add("@serie_nd", SqlDbType.VarChar).Value = sucursalEmpresa.serie_nd;
                    conmand.Parameters.Add("@serie_ncn", SqlDbType.VarChar).Value = sucursalEmpresa.serie_ncn;
                    conmand.Parameters.Add("@serie_ndn", SqlDbType.VarChar).Value = sucursalEmpresa.serie_ndn;
                    conmand.Parameters.Add("@cod_ciudad", SqlDbType.VarChar).Value = sucursalEmpresa.cod_ciudad;
                    conmand.Parameters.Add("@cod_provincia", SqlDbType.VarChar).Value = sucursalEmpresa.cod_provincia;
                    conmand.Parameters.Add("@cod_pais", SqlDbType.VarChar).Value = sucursalEmpresa.cod_pais;
                    int dr = conmand.ExecuteNonQuery();
                    return "Sucursal guardada correctamente";
                }                
                
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(sucursalEmpresa.cod_emp, metodo, "ActualizarSucursalEmpresa", e.ToString(), DateTime.Now, sucursalEmpresa.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarSucursalEmpresa." + " Por favor notificar al administrador.";
            }

        }
        public string InsertarSucursalEmpresa(modeloSucuralempresa sucursalEmpresa)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "INSERT INTO  wmm_sucuremp (cod_emp, cod_sucursal, nom_sucursal, dir_sucursal, tel_sucursal,email_sucursal, usuario_mod, fecha_mod, nro_audit, cod_proc_aud,cod_ciudad, cod_provincia, cod_pais, serie_factura, serie_nc, serie_nd,serie_ncn, serie_ndn, serie_facturan) VALUES (@cod_emp, @cod_sucursal, @nom_sucursal, @dir_sucursal, @tel_sucursal, @email_sucursal, @usuario_mod, @fecha_mod, @nro_audit, @cod_proc_aud,@cod_ciudad, @cod_provincia, @cod_pais, @serie_factura, @serie_nc, @serie_nd, @serie_ncn, @serie_ndn, @serie_facturan)";
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
                conmand.Parameters.Add("@cod_ciudad", SqlDbType.VarChar).Value = sucursalEmpresa.cod_ciudad;
                conmand.Parameters.Add("@cod_provincia", SqlDbType.VarChar).Value = sucursalEmpresa.cod_provincia;
                conmand.Parameters.Add("@cod_pais", SqlDbType.VarChar).Value = sucursalEmpresa.cod_pais;
                conmand.Parameters.Add("@serie_factura", SqlDbType.VarChar).Value = sucursalEmpresa.serie_factura;
                conmand.Parameters.Add("@serie_facturan", SqlDbType.VarChar).Value = sucursalEmpresa.serie_facn;
                conmand.Parameters.Add("@serie_nc", SqlDbType.VarChar).Value = sucursalEmpresa.serie_nc;
                conmand.Parameters.Add("@serie_nd", SqlDbType.VarChar).Value = sucursalEmpresa.serie_nd;
                conmand.Parameters.Add("@serie_ncn", SqlDbType.VarChar).Value = sucursalEmpresa.serie_ncn;
                conmand.Parameters.Add("@serie_ndn", SqlDbType.VarChar).Value = sucursalEmpresa.serie_ndn;
                int dr = conmand.ExecuteNonQuery();
                return "Sucursal guardada correctamente";
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(sucursalEmpresa.cod_emp, metodo, "InsertarSucursalEmpresa", e.ToString(), DateTime.Now, sucursalEmpresa.usuario_mod);
                return "No se pudo completar la acción." + "InsertarSucursalEmpresa." + " Por favor notificar al administrador.";
            }

        }
        //Buscar unico sucrsal x empresa
        public List<modeloSucuralempresa> UnicoSucursalEmpresa(string cod_emp, string cod_sucursal)
        {
            try
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
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "UnicoSucursalEmpresa", e.ToString(), DateTime.Now, "consulta");
                return null;
            }

        }

        //Buscar prefijos , deben ser unicos para poder insertar
        public string  PrefijosSucEmpFactura(string cod_emp,  string serie_factura, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {

                    string serie_factura_consulta =null;
                    string consulta = "SELECT serie_factura  FROM wmm_sucuremp WHERE cod_emp =@cod_emp AND serie_factura=@serie_factura";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("serie_factura", SqlDbType.VarChar).Value = serie_factura;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        serie_factura_consulta = Convert.ToString(dr["serie_factura"]);
                     }

                        return serie_factura_consulta;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijosSucEmpFactura", e.ToString(), DateTime.Now, usuario);
                return null;
            }

        }

        //Buscar prefijos , deben ser unicos para poder insertar
        public string PrefijosSucEmpFacturaNormal(string cod_emp, string serie_facturan, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {

                    string serie_factura_consulta = null;
                    string consulta = "SELECT serie_facturan  FROM wmm_sucuremp WHERE cod_emp =@cod_emp AND serie_facturan=@serie_facturan";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("serie_facturan", SqlDbType.VarChar).Value = serie_facturan;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        serie_factura_consulta = Convert.ToString(dr["serie_facturan"]);
                    }

                    return serie_factura_consulta;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijosSucEmpFacturaNormal", e.ToString(), DateTime.Now, usuario);
                return null;
            }

        }
        //SERIE NC UNICO SERIE_NC
        public string PrefijosSucEmpNC(string cod_emp, string serie_nc, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {

                    string serie_factura_consulta = null;
                    string consulta = "SELECT serie_nc  FROM wmm_sucuremp WHERE cod_emp =@cod_emp AND serie_nc=@serie_nc";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("serie_nc", SqlDbType.VarChar).Value = serie_nc;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        serie_factura_consulta = Convert.ToString(dr["serie_nc"]);
                    }

                    return serie_factura_consulta;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijosSucEmpNC", e.ToString(), DateTime.Now, usuario);
                return null;
            }

        }

        //SERIE NC UNICO SERIE_NCN
        public string PrefijosSucEmpNCN(string cod_emp, string serie_ncn, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {

                    string serie_factura_consulta = null;
                    string consulta = "SELECT serie_ncn  FROM wmm_sucuremp WHERE cod_emp =@cod_emp AND serie_nc=@serie_ncn";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("serie_ncn", SqlDbType.VarChar).Value = serie_ncn;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        serie_factura_consulta = Convert.ToString(dr["serie_ncn"]);
                    }

                    return serie_factura_consulta;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijosSucEmpNCN", e.ToString(), DateTime.Now, usuario);
                return null;
            }

        }

        //SERIE NC UNICO SERIE_NC
        public string PrefijosSucEmpND(string cod_emp, string serie_nd, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {

                    string serie_factura_consulta = null;
                    string consulta = "SELECT serie_nd  FROM wmm_sucuremp WHERE cod_emp =@cod_emp AND serie_nd=@serie_nd";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("serie_nd", SqlDbType.VarChar).Value = serie_nd;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        serie_factura_consulta = Convert.ToString(dr["serie_nd"]);
                    }

                    return serie_factura_consulta;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijosSucEmpND", e.ToString(), DateTime.Now, usuario);
                return null;
            }

        }

        //SERIE NC UNICO SERIE_NC
        public string PrefijosSucEmpNDN(string cod_emp, string serie_ndn, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {

                    string serie_factura_consulta = null;
                    string consulta = "SELECT serie_ndn  FROM wmm_sucuremp WHERE cod_emp =@cod_emp AND serie_ndn=@serie_ndn";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("serie_ndn", SqlDbType.VarChar).Value = serie_ndn;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        serie_factura_consulta = Convert.ToString(dr["serie_ndn"]);
                    }

                    return serie_factura_consulta;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijosSucEmpNDN", e.ToString(), DateTime.Now, usuario);
                return null;
            }

        }
        public List<modeloSucuralempresa> ConsultaSucursalEmpresa(string cod_emp)
        {
            try
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
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaSucursalEmpresa", e.ToString(), DateTime.Now, "consulta");
                return null;
            }

        }

        public List<modeloSucuralempresa> ConsultaSucursal(string cod_emp,string cod_sucursal)
        {
            try
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
                        item.serie_factura = Convert.ToString(dr["serie_factura"]);
                        item.serie_facn = Convert.ToString(dr["serie_facturan"]);
                        item.serie_nc = Convert.ToString(dr["serie_nc"]);
                        item.serie_ncn = Convert.ToString(dr["serie_ncn"]);
                        item.serie_ndn = Convert.ToString(dr["serie_ndn"]);
                        item.serie_nd = Convert.ToString(dr["serie_nd"]);
                        item.cod_ciudad = Convert.ToString(dr["cod_ciudad"]);
                        item.cod_provincia = Convert.ToString(dr["cod_provincia"]);
                        item.cod_pais = Convert.ToString(dr["cod_pais"]);
                       // item.nom_ciudad = Convert.ToString(dr["nom_ciudad"]);
                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaSucursal", e.ToString(), DateTime.Now, "consulta");
                return null;
            }

        }

        //Buscar si existen usuarios asignados a una sucursal
        public string ConsultaUsuarioSucursal(string cod_emp, string cod_sucursal, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string sucursal = null;
                    string consulta = "SELECT cod_sucursal FROM wmm_userxsucur where cod_emp =@cod_emp and cod_sucursal =@cod_sucursal";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("cod_sucursal", SqlDbType.VarChar).Value = cod_sucursal;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {
          
                        sucursal = Convert.ToString(dr["cod_sucursal"]);
                    }
                    return sucursal;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaUsuariosSucursal", e.ToString(), DateTime.Now, usuario);
                return null;
            }

        }
    }
}
