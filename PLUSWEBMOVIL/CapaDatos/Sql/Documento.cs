using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class Documento
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public List<modelowmspctitulares> ListaBuscaTitulares(string Ven__usuario, string Ven__cod_emp, string Ven__cod_tipotit, string Ven__cod_tit, string Ven__cod_dgi)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelowmspctitulares> lista = new List<modelowmspctitulares>();
                    string consulta = ("wmspc_titulares");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = Ven__usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = Ven__cod_emp;
                    conmand.Parameters.Add("@cod_tipotit", SqlDbType.VarChar).Value = Ven__cod_tipotit;
                    conmand.Parameters.Add("@cod_tit", SqlDbType.VarChar).Value = Ven__cod_tit;
                    conmand.Parameters.Add("@cod_dgi", SqlDbType.VarChar).Value = Ven__cod_dgi;




                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modelowmspctitulares item = new modelowmspctitulares();
                        item.cod_tit = Convert.ToString(dr["cod_tit"]);
                        item.nom_tit = Convert.ToString(dr["nom_tit"]);
                        item.cod_dgi = Convert.ToString(dr["cod_dgi"]);
                        item.nro_dgi = Convert.ToString(dr["nro_dgi"]);
                        item.nro_dgi1 = Convert.ToString(dr["nro_dgi1"]);
                        item.nro_dgi2 = Convert.ToString(dr["nro_dgi2"]);
                        item.dir_tit = Convert.ToString(dr["dir_tit"]);
                        item.tel_tit = Convert.ToString(dr["tel_tit"]);
                        item.fax_tit = Convert.ToString(dr["fax_tit"]);
                        item.email_tit = Convert.ToString(dr["email_tit"]);
                        item.dir_web = Convert.ToString(dr["dir_web"]);
                        item.cod_pais = Convert.ToString(dr["cod_pais"]);
                        item.nom_pais = Convert.ToString(dr["nom_pais"]);
                        item.cod_provincia = Convert.ToString(dr["cod_provincia"]);
                        item.nom_provincia = Convert.ToString(dr["nom_provincia"]);
                        item.ciudad_tit = Convert.ToString(dr["ciudad_tit"]);
                        item.nom_ciudad = Convert.ToString(dr["nom_ciudad"]);
                        item.cod_tipo_emp_gan = Convert.ToString(dr["cod_tipo_emp_gan"]);
                        item.nom_tipo_emp_gan = Convert.ToString(dr["nom_tipo_emp_gan"]);
                        item.cod_tipo_emp_iva = Convert.ToString(dr["cod_tipo_emp_iva"]);
                        item.nom_tipo_emp_iva = Convert.ToString(dr["nom_tipo_emp_iva"]);
                        item.primer_nombre = Convert.ToString(dr["primer_nombre"]);
                        item.segundo_nombre = Convert.ToString(dr["segundo_nombre"]);
                        item.primer_apellido = Convert.ToString(dr["primer_apellido"]);
                        item.segundo_apellido = Convert.ToString(dr["segundo_apellido"]);
                        item.razon_social = Convert.ToString(dr["razon_social"]);
                        item.control_tit = Convert.ToString(dr["control_tit"]);

                        item.control_uso = Convert.ToString(dr["control_uso"]);
                        item.control_uso2 = Convert.ToString(dr["control_uso2"]);
                        item.cod_sop = Convert.ToString(dr["cod_sop"]);
                        item.moncli = Convert.ToString(dr["moncli"]);
                        item.regimen_tributacion = Convert.ToString(dr["regimen_tributacion"]);

                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ven__cod_emp, "Documenton.cs", "ListaBuscaTitulares", e.ToString(), DateTime.Today, Ven__usuario);
                return null;
            }

        }
      
        //buscar solo un cliente para cierre de caja
        public modelowmspctitulares ListaBuscaCliente(string Ven__usuario, string Ven__cod_emp, string Ven__cod_tipotit, string Ven__cod_tit, string Ven__cod_dgi)
        {
            try
            {
                modelowmspctitulares item1 = new modelowmspctitulares();
              
                using (cn = conexion.genearConexion())
                {
                    
                    
                    string consulta = ("wmspc_titulares");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = Ven__usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = Ven__cod_emp;
                    conmand.Parameters.Add("@cod_tipotit", SqlDbType.VarChar).Value = Ven__cod_tipotit;
                    conmand.Parameters.Add("@cod_tit", SqlDbType.VarChar).Value = Ven__cod_tit.Trim();
                    conmand.Parameters.Add("@cod_dgi", SqlDbType.VarChar).Value = Ven__cod_dgi;

                    SqlDataReader dr = conmand.ExecuteReader();
                    
                    while (dr.Read())
                    {
                       
                        item1.cod_tit = Convert.ToString(dr["cod_tit"]);
                        item1.nom_tit = Convert.ToString(dr["nom_tit"]);
                        item1.cod_dgi = Convert.ToString(dr["cod_dgi"]);
                        item1.nro_dgi = Convert.ToString(dr["nro_dgi"]);
                        item1.nro_dgi1 = Convert.ToString(dr["nro_dgi1"]);
                        item1.nro_dgi2 = Convert.ToString(dr["nro_dgi2"]);
                        item1.razon_social = Convert.ToString(dr["razon_social"]);
                       
                       
                    }

                    return item1;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ven__cod_emp, "Documenton.cs", "ListaBuscaCliente", e.ToString(), DateTime.Today, Ven__usuario);
                return null;
            }

        }

    }
}
