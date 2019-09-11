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
   public  class UsuarioxEmpresa
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<modeloUsuarioxempresa> ConsultaUsuarioEmpresa(string cod_emp)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloUsuarioxempresa> lista = new List<modeloUsuarioxempresa>();

                    string consulta = "SELECT * FROM wm_userxemp WHERE cod_emp =@cod_emp";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        modeloUsuarioxempresa item = new modeloUsuarioxempresa();

                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.usuario = Convert.ToString(dr["usuario"]);
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

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "UsuarioxEmpresa.cs", "ConsultaUsuarioEmpresa", e.ToString(), DateTime.Today, "consulta");
                return null;
            }

        }
    }
}
