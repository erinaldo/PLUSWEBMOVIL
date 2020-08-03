using CapaDatos.Modelos;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class ConsultaLogoSql
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public List<modelowmspclogo> ConsultaLogo(string cod_emp, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelowmspclogo> lista = new List<modelowmspclogo>();
                    string consulta = ("wmspc_logo");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modelowmspclogo item = new modelowmspclogo();

                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.nom_emp = Convert.ToString(dr["nom_emp"]);
                        item.nro_id = Convert.ToString(dr["nro_id"]);
                        item.direccion = Convert.ToString(dr["direccion"]);
                        item.telefono = Convert.ToString(dr["telefono"]);
                        item.cod_pais = Convert.ToString(dr["cod_pais"]);
                        item.nom_pais = Convert.ToString(dr["nom_pais"]);
                        item.cod_provincia = Convert.ToString(dr["cod_provincia"]);
                        item.cod_ciudad = Convert.ToString(dr["cod_ciudad"]);
                        item.sitio_app = ConfigurationManager.AppSettings["path"];
                        item.nom_ciudad = Convert.ToString(dr["nom_ciudad"]);
                        item.logo = Convert.ToString(dr["logo"]);
                        item.username = Convert.ToString(dr["username"]);
                        item.password = Convert.ToString(dr["password"]);
                        item.linkemidocuelec = Convert.ToString(dr["linkemidocuelec"]);
                        item.linkgenpdf = Convert.ToString(dr["linkgenpdf"]);
                        item.pathtmpfac = Convert.ToString(dr["pathtmpfac"]);
                        item.sitio_erp = Convert.ToString(dr["sitio_erp"]);
                        item.version_fe = Convert.ToString(dr["version_fe"]);
                        item.cod_emp_erp = Convert.ToString(dr["cod_emp_erp"]);
                        item.pdf_fe = Convert.ToString(dr["pdf_fe"]);
                        item.pdf_nc = Convert.ToString(dr["pdf_nc"]);
                        item.cantidad_decimal = Convert.ToInt32(dr["cantidad_decimal"]);
                        item.pvp_decimal = Convert.ToInt32(dr["pvp_decimal"]);

                        lista.Add(item);


                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "ConsultaLogoSql.cs", "ConsultaLogo", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }

        public List<modelowmusuario> CosnualtaUsuario(string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelowmusuario> lista = new List<modelowmusuario>();

                    string consulta = ("SELECT * FROM wm_usuario WHERE usuario = @usuario");
                    SqlCommand conmand = new SqlCommand(consulta, cn);


                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modelowmusuario item = new modelowmusuario();

                        item.usuario = Convert.ToString(dr["usuario"]);
                        item.clave = Convert.ToString(dr["clave"]);
                        item.Nombre = Convert.ToString(dr["Nombre"]);
                        item.fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]);
                        item.fecha_actualizacion = Convert.ToDateTime(dr["fecha_actualizacion"]);
                        item.estado_usuario = Convert.ToString(dr["estado_usuario"]);
                        item.usuario_sistema = Convert.ToString(dr["usuario_sistema"]);
                        item.pregunta = Convert.ToString(dr["pregunta"]);
                        item.respuesta = Convert.ToString(dr["respuesta"]);
                        item.fecha_ult_login = Convert.ToDateTime(dr["fecha_ult_login"]);
                        item.nro_login = Convert.ToInt64(dr["nro_login"]);
                        item.nro_audit = Convert.ToInt64(dr["nro_audit"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.email = Convert.ToString(dr["email"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        item.usuario_erp = Convert.ToString(dr["usuario_erp"]);

                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "ConsultaLogoSql.cs", "CosnualtaUsuario", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }

        public string TipoDocImprimir(string cod_emp, string cod_proceso, string usuario)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {
                    string tipo_doc = null;

                    string consulta = ("SELECT * FROM wmv_impresion where wmv_impresion.cod_emp =@cod_emp and wmv_impresion.cod_proceso = @cod_proceso");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    //conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@cod_proceso", SqlDbType.VarChar).Value = cod_proceso;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        tipo_doc = Convert.ToString(dr["pagina"]);
                    }
                    return tipo_doc;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "ConsultaLogoSql.cs", "TipoDocImprimir", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
    }
}
