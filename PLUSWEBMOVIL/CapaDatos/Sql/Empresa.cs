using CapaDatos.Modelos;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class Empresa
    {
            
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public List<modelowmspcempresas> BuscarEmpresa(string Ven__usuario, string Ven__cod_emp)
        {

            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelowmspcempresas> lista = new List<modelowmspcempresas>();
                    string consulta = ("wmspc_empresas");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = Ven__usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = Ven__cod_emp;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modelowmspcempresas item = new modelowmspcempresas();
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.mone_mn = Convert.ToString(dr["mone_mn"]);
                        item.nom_emp = Convert.ToString(dr["nom_emp"]);
                        item.nro_dgi = Convert.ToString(dr["nro_dgi"]);
                        item.nro_dgi1 = Convert.ToString(dr["nro_dgi1"]);
                        item.nro_dgi2 = Convert.ToString(dr["nro_dgi2"]);
                        item.dir_tit = Convert.ToString(dr["dir_tit"]);
                        item.tel_tit = Convert.ToString(dr["tel_tit"]);
                        item.fax_tit = Convert.ToString(dr["fax_tit"]);
                        item.cod_pais = Convert.ToString(dr["cod_pais"]);
                        item.nom_pais = Convert.ToString(dr["nom_pais"]);
                        item.cod_provincia = Convert.ToString(dr["cod_provincia"]);
                        item.nom_provincia = Convert.ToString(dr["nom_provincia"]);
                        item.ciudad_tit = Convert.ToString(dr["ciudad_tit"]);
                        item.nom_ciudad = Convert.ToString(dr["nom_ciudad"]);
                        item.email_tit = Convert.ToString(dr["email_tit"]);
                        item.dir_web = Convert.ToString(dr["dir_web"]);
                        item.cod_tipo_emp_gan = Convert.ToString(dr["cod_tipo_emp_gan"]);
                        item.nom_tipo_emp_gan = Convert.ToString(dr["nom_tipo_emp_gan"]);
                        item.cod_tipo_emp_iva = Convert.ToString(dr["cod_tipo_emp_iva"]);
                        item.nom_tipo_emp_iva = Convert.ToString(dr["nom_tipo_emp_iva"]);
                        item.personeria = Convert.ToString(dr["personeria"]);
                        item.tributacion = Convert.ToString(dr["tributacion"]);
                        item.tipo_ide= Convert.ToString(dr["tipo_ide"]);
                        item.sigla_ide = Convert.ToString(dr["sigla_ide"]);

                        lista.Add(item);

                    }
                    return lista;
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ven__cod_emp, "Empresa.cs", "BuscarEmpresa", e.ToString(), DateTime.Today, Ven__usuario);
                return null;
            }

        }

    }
}
