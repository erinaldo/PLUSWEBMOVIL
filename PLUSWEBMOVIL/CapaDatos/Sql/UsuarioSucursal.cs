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
    public class UsuarioSucursal
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "UsuarioSucursal.cs";
        //Eliminar usuario x sucursal
        public string EliminarUsuarioSucursal(modeloUsuariosucursal sucursalEmpresa)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "DELETE FROM wmm_userxsucur WHERE  usuario = @usuario AND cod_sucursal = @cod_sucursal AND cod_emp =@cod_emp";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = sucursalEmpresa.usuario;
                    conmand.Parameters.Add("@cod_sucursal", SqlDbType.VarChar).Value = sucursalEmpresa.cod_sucursal;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = sucursalEmpresa.cod_emp;

                    int dr = conmand.ExecuteNonQuery();
                    return "Usuario eliminado correctamente";
                }                
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(sucursalEmpresa.cod_emp, metodo, "EliminarUsuarioSucursal", e.ToString(), DateTime.Today, sucursalEmpresa.usuario_mod);
                return "No se pudo completar la acción." + "EliminarUsuarioSucursal." + " Por favor notificar al administrador.";
            }

        }

        //Actualizar usuario x sucursal
        public string ActualizarUsuarioSucursal(modeloUsuariosucursal sucursalEmpresa)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "UPDATE wmm_userxsucur SET  usuario = @usuario where cod_emp = @cod_emp AND cod_sucursal = @cod_sucursal AND usuario = @usu_ante";
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
                
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(sucursalEmpresa.cod_emp, metodo, "ActualizarUsuarioSucursal", e.ToString(), DateTime.Now, sucursalEmpresa.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarUsuarioSucursal." + " Por favor notificar al administrador.";
            }

        }
        //Insertar usuario x sucursal
        public string InsertarUsuarioSucursal(modeloUsuariosucursal usuariosucursal)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO  wmm_userxsucur (cod_emp, cod_sucursal, usuario, usuario_mod, fecha_mod, nro_audit, cod_proc_aud) VALUES (@cod_emp, @cod_sucursal, @usuario, @usuario_mod, @fecha_mod, @nro_audit, @cod_proc_aud)";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = usuariosucursal.cod_emp;
                    conmand.Parameters.Add("@cod_sucursal", SqlDbType.VarChar).Value = usuariosucursal.cod_sucursal;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuariosucursal.usuario;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = usuariosucursal.usuario_mod;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = usuariosucursal.fecha_mod;
                    conmand.Parameters.Add("@nro_audit", SqlDbType.VarChar).Value = usuariosucursal.nro_audit;
                     conmand.Parameters.Add("@cod_proc_aud", SqlDbType.VarChar).Value = usuariosucursal.cod_proc_aud;
                    int dr = conmand.ExecuteNonQuery();
                    return "Usuario sucursal guardado correctamente";
                }               
               
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(usuariosucursal.cod_emp, metodo, "InsertarUsuarioSucursal", e.ToString(), DateTime.Now, usuariosucursal.usuario_mod);
                return "No se pudo completar la acción." + "InsertarUsuarioSucursal." + " Por favor notificar al administrador.";
            }

        }
        //CArgar vista principal
        public List<modeloUsuariosucursal> ListaUsuarioxSucursal(string cod_emp)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloUsuariosucursal> lista = new List<modeloUsuariosucursal>();
                    string consulta = "SELECT u.usuario,u.usuario_mod,u.fecha_mod,u.nro_audit,u.cod_proc_aud,u.cod_emp,u.cod_sucursal,e.nom_sucursal FROM wmm_userxsucur AS u , wmm_sucuremp AS e WHERE u.cod_emp = @cod_emp AND u.cod_sucursal = e.cod_sucursal AND u.cod_emp = e.cod_emp";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {
                        modeloUsuariosucursal item = new modeloUsuariosucursal();
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                        item.usuario = Convert.ToString(dr["usuario"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.nom_sucursal = Convert.ToString(dr["nom_sucursal"]);
                        item.usu_ante = Convert.ToString(dr["usuario"]);
                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaUsuarioxSucursal", e.ToString(), DateTime.Now, "consulta");
                return null;
            }


        }
        public modeloUsuariosucursal PrefijoSucursalXUsuFacturaNormal(string cod_emp, string usuario, string serie_factura)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    modeloUsuariosucursal item = new modeloUsuariosucursal();
                    string consulta = "SELECT u.usuario,u.fecha_mod,u.cod_emp,u.cod_sucursal,e.nom_sucursal,e.serie_factura,e.serie_facturan,e.serie_nc,e.serie_nd FROM wmm_userxsucur AS u , wmm_sucuremp AS e WHERE u.cod_emp = @cod_emp AND u.cod_sucursal = e.cod_sucursal AND u.usuario =@usuario and e.serie_facturan = @serie_facturan";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@serie_facturan", SqlDbType.VarChar).Value = serie_factura;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        item.usuario = Convert.ToString(dr["usuario"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                        item.nom_sucursal = Convert.ToString(dr["nom_sucursal"]);
                        item.serie_factura = Convert.ToString(dr["serie_factura"]);
                        item.serie_facturan = Convert.ToString(dr["serie_facturan"]);
                        item.serie_nc = Convert.ToString(dr["serie_nc"]);
                        item.serie_nd = Convert.ToString(dr["serie_nd"]);

                    }
                    return item;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijoSucursalXUsuFacturaNormal", e.ToString(), DateTime.Now, usuario);
                return null;
            }


        }
        //Buscar por prefijo , usuario, empresa. factura
        public modeloUsuariosucursal PrefijoSucursalXUsuFactura(string cod_emp, string usuario, string serie_factura)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    modeloUsuariosucursal item = new modeloUsuariosucursal();
                    string consulta = "SELECT u.usuario,u.fecha_mod,u.cod_emp,u.cod_sucursal,e.nom_sucursal,e.serie_factura,e.serie_nc,e.serie_nd FROM wmm_userxsucur AS u , wmm_sucuremp AS e WHERE u.cod_emp = @cod_emp AND u.cod_sucursal = e.cod_sucursal AND u.usuario =@usuario and e.serie_factura = @serie_factura";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@serie_factura", SqlDbType.VarChar).Value = serie_factura;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {
                        
                        item.usuario = Convert.ToString(dr["usuario"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                        item.nom_sucursal = Convert.ToString(dr["nom_sucursal"]);
                        item.serie_factura = Convert.ToString(dr["serie_factura"]);
                        item.serie_nc = Convert.ToString(dr["serie_nc"]);
                        item.serie_nd = Convert.ToString(dr["serie_nd"]);
                        
                    }
                    return item;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijoSucursalXUsuFactura", e.ToString(), DateTime.Now, usuario);
                return null;
            }


        }

        public modeloUsuariosucursal PrefijoSucursalXUsuFacturaN(string cod_emp, string usuario, string serie_factura)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    modeloUsuariosucursal item = new modeloUsuariosucursal();
                    string consulta = "SELECT u.usuario,u.fecha_mod,u.cod_emp,u.cod_sucursal,e.nom_sucursal,e.serie_factura, e.serie_facturan,e.serie_nc,e.serie_nd FROM wmm_userxsucur AS u , wmm_sucuremp AS e WHERE u.cod_emp = @cod_emp AND u.cod_sucursal = e.cod_sucursal AND u.usuario =@usuario and e.serie_facturan = @serie_facturan";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@serie_facturan", SqlDbType.VarChar).Value = serie_factura;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        item.usuario = Convert.ToString(dr["usuario"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                        item.nom_sucursal = Convert.ToString(dr["nom_sucursal"]);
                        item.serie_factura = Convert.ToString(dr["serie_factura"]);
                        item.serie_nc = Convert.ToString(dr["serie_nc"]);
                        item.serie_nd = Convert.ToString(dr["serie_nd"]);

                    }
                    return item;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijoSucursalXUsuFacturaN", e.ToString(), DateTime.Now, usuario);
                return null;
            }


        }
        //Buscar por prefijo , usuario, empresa. nc
        public modeloUsuariosucursal PrefijoSucursalXUsuNC(string cod_emp, string usuario, string serie_nc)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    modeloUsuariosucursal item = new modeloUsuariosucursal();
                    string consulta = "SELECT u.usuario,u.fecha_mod,u.cod_emp,u.cod_sucursal,e.nom_sucursal,e.serie_factura,e.serie_nc,e.serie_nd FROM wmm_userxsucur AS u , wmm_sucuremp AS e WHERE u.cod_emp = @cod_emp AND u.cod_sucursal = e.cod_sucursal AND u.usuario =@usuario and e.serie_nc = @serie_nc";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@serie_nc", SqlDbType.VarChar).Value = serie_nc;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        item.usuario = Convert.ToString(dr["usuario"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                        item.nom_sucursal = Convert.ToString(dr["nom_sucursal"]);
                        item.serie_factura = Convert.ToString(dr["serie_factura"]);
                        item.serie_nc = Convert.ToString(dr["serie_nc"]);
                        item.serie_nd = Convert.ToString(dr["serie_nd"]);

                    }
                    return item;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijoSucursalXUsuNC", e.ToString(), DateTime.Now, usuario);
                return null;
            }


        }

        //Buscar por prefijo , usuario, empresa. nc BUSCA PREFIJO PARA NC ERP
        public modeloUsuariosucursal PrefijoSucuXUsuNCERP(string cod_emp, string usuario, string serie_ncn)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    modeloUsuariosucursal item = new modeloUsuariosucursal();
                    string consulta = "SELECT u.usuario,u.fecha_mod,u.cod_emp,u.cod_sucursal,e.nom_sucursal,e.serie_factura,e.serie_nc, e.serie_ncn,e.serie_nd, e.serie_ndn FROM wmm_userxsucur AS u , wmm_sucuremp AS e WHERE u.cod_emp = @cod_emp AND u.cod_sucursal = e.cod_sucursal AND u.usuario =@usuario and e.serie_ncn = @serie_ncn";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@serie_ncn", SqlDbType.VarChar).Value = serie_ncn;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        item.usuario = Convert.ToString(dr["usuario"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                        item.nom_sucursal = Convert.ToString(dr["nom_sucursal"]);
                        item.serie_factura = Convert.ToString(dr["serie_factura"]);
                        item.serie_nc = Convert.ToString(dr["serie_nc"]);
                        item.serie_ncn = Convert.ToString(dr["serie_ncn"]);
                        item.serie_nd = Convert.ToString(dr["serie_nd"]);
                        item.serie_ndn = Convert.ToString(dr["serie_ndn"]);

                    }
                    return item;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijoSucuXUsuNCERP", e.ToString(), DateTime.Now, usuario);
                return null;
            }


        }
        //Buscar por prefijo , usuario, empresa. ND ELECTRONICAS
        public modeloUsuariosucursal PrefijoSucursalXUsuND(string cod_emp, string usuario, string serie_nd)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    modeloUsuariosucursal item = new modeloUsuariosucursal();
                    string consulta = "SELECT u.usuario,u.fecha_mod,u.cod_emp,u.cod_sucursal,e.nom_sucursal,e.serie_factura,e.serie_nc,e.serie_nd FROM wmm_userxsucur AS u , wmm_sucuremp AS e WHERE u.cod_emp = @cod_emp AND u.cod_sucursal = e.cod_sucursal AND u.cod_emp = e.cod_emp AND u.usuario =@usuario and e.serie_nd = @serie_nd";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@serie_nd", SqlDbType.VarChar).Value = serie_nd;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        item.usuario = Convert.ToString(dr["usuario"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                        item.nom_sucursal = Convert.ToString(dr["nom_sucursal"]);
                        item.serie_factura = Convert.ToString(dr["serie_factura"]);
                        item.serie_nc = Convert.ToString(dr["serie_nc"]);
                        item.serie_nd = Convert.ToString(dr["serie_nd"]);

                    }
                    return item;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijoSucursalXUsuND", e.ToString(), DateTime.Now, usuario);
                return null;
            }


        }
        //Buscar por prefijo , usuario, empresa. nc
        public modeloUsuariosucursal PrefijoSucXUsuNDERP(string cod_emp, string usuario, string serie_nd)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    modeloUsuariosucursal item = new modeloUsuariosucursal();
                    string consulta = "SELECT u.usuario,u.fecha_mod,u.cod_emp,u.cod_sucursal,e.nom_sucursal,e.serie_factura,e.serie_nc, e.serie_ncn,e.serie_nd, e.serie_ndn FROM wmm_userxsucur AS u , wmm_sucuremp AS e WHERE u.cod_emp = @cod_emp AND u.cod_sucursal = e.cod_sucursal AND u.usuario =@usuario and e.serie_ndn = @serie_ndn";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@serie_ndn", SqlDbType.VarChar).Value = serie_nd;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        item.usuario = Convert.ToString(dr["usuario"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                        item.nom_sucursal = Convert.ToString(dr["nom_sucursal"]);
                        item.serie_factura = Convert.ToString(dr["serie_factura"]);
                        item.serie_nc = Convert.ToString(dr["serie_nc"]);
                        item.serie_nd = Convert.ToString(dr["serie_nd"]);
                        item.serie_ncn = Convert.ToString(dr["serie_ncn"]);
                        item.serie_ndn = Convert.ToString(dr["serie_ndn"]);

                    }
                    return item;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijoSucursalXUsuND", e.ToString(), DateTime.Now, usuario);
                return null;
            }


        }
        public List<modeloUsuariosucursal> SucursalXUsuario(string cod_emp, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloUsuariosucursal> lista = new List<modeloUsuariosucursal>();
                    string consulta = "SELECT u.usuario,u.fecha_mod,u.cod_emp,u.cod_sucursal,e.nom_sucursal,e.serie_factura,e.serie_nc,e.serie_nd FROM wmm_userxsucur AS u , wmm_sucuremp AS e WHERE u.cod_emp = @cod_emp AND u.cod_sucursal = e.cod_sucursal AND u.usuario =@usuario";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {
                        modeloUsuariosucursal item = new modeloUsuariosucursal();
                        item.usuario = Convert.ToString(dr["usuario"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                        item.nom_sucursal = Convert.ToString(dr["nom_sucursal"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.serie_factura = Convert.ToString(dr["serie_factura"]);
                        item.serie_nc = Convert.ToString(dr["serie_nc"]);
                        item.serie_nd = Convert.ToString(dr["serie_nd"]);
                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "SucursalXUsuario", e.ToString(), DateTime.Now, "consulta");
                return null;
            }


        }

        //Consultar si el vendedor tiene asignado una sucursal
        public List<modeloUsuariosucursal> ConsultaUsuarioxSucursal(string cod_emp, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloUsuariosucursal> lista = new List<modeloUsuariosucursal>();
                    string consulta = "SELECT TOP 1 * FROM wmm_userxsucur WHERE cod_emp =@cod_emp AND usuario = @usuario";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {
                        modeloUsuariosucursal item = new modeloUsuariosucursal();
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                        item.usuario = Convert.ToString(dr["usuario"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.usu_ante = Convert.ToString(dr["usuario"]);
                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaUsuarioxSucursal", e.ToString(), DateTime.Now, "consulta");
                return null;
            }


        }
        /*Buscar Unico usuario x sucursal*/
        public List<modeloUsuariosucursal> UnicoUsuarioxSucursal(string cod_emp,  string usuario, string cod_sucursal)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloUsuariosucursal> lista = new List<modeloUsuariosucursal>();
                    string consulta = "SELECT S.cod_emp,S.cod_sucursal,S.usuario,S.usuario_mod,S.fecha_mod,S.nro_audit,S.cod_proc_aud,E.nom_sucursal FROM wmm_userxsucur AS S ,wmm_sucuremp AS E WHERE S.cod_emp = @cod_emp AND S.usuario = @usuario AND S.cod_sucursal = E.cod_sucursal AND S.cod_emp = E.cod_emp ";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("usuario", SqlDbType.VarChar).Value = usuario;
                    //conmand.Parameters.Add("cod_sucursal", SqlDbType.VarChar).Value = cod_sucursal;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {
                        modeloUsuariosucursal item = new modeloUsuariosucursal();
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                        item.usuario = Convert.ToString(dr["usuario"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.usu_ante = Convert.ToString(dr["usuario"]);
                        item.nom_sucursal = Convert.ToString(dr["nom_sucursal"]);
                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "UnicoUsuarioxSucursal", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        
    }
}
