using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
    public class ConsultaLogo
    {
        ConsultaLogoSql consultaLogoSql = new ConsultaLogoSql();
        public List<modelowmspclogo> BuscartaLogo(string cod_emp, string usuario)
        {
            List<modelowmspclogo> lista = new List<modelowmspclogo>();
            SqlDataReader dr = consultaLogoSql.ConsultaLogo(cod_emp, usuario);

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

                lista.Add(item);

               
            }
            return lista;
        }

        public List<modelowmusuario> BuscarUsuario(string usuario)
        {
            List<modelowmusuario> lista = new List<modelowmusuario>();
            SqlDataReader dr = consultaLogoSql.CosnualtaUsuario(usuario);

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
}
