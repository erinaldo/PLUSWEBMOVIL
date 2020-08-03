using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public class CCostos
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "CCostos.cs";

        public List<ModeloCtasContables> ListaBuscaCContable(string CC__usuario, string CC__cod_emp, string libro)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<ModeloCtasContables> lista = new List<ModeloCtasContables>();
                    string consulta = ("wmspc_cuentas");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = CC__usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = CC__cod_emp;
                    conmand.Parameters.Add("@libro", SqlDbType.VarChar).Value = libro;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        ModeloCtasContables item = new ModeloCtasContables();
                        item.cod_cta = Convert.ToString(dr["cod_cta"]);
                        item.nom_cta = Convert.ToString(dr["nom_cta"]);
                        item.cod_tipocta = Convert.ToString(dr["cod_tipocta"]);
                        item.negocio_cta = Convert.ToString(dr["negocio_cta"]);
                        item.ccostos_cta = Convert.ToString(dr["ccosto_cta"]);
                        item.analisis_tit = Convert.ToString(dr["analisis_tit"]);
                        item.actividad_cta = Convert.ToString(dr["actividad_cta"]);
                        item.cuenta = Convert.ToString(dr["cuenta"]);
                        item.cod_tipotit = Convert.ToString(dr["cod_tipotit"]);
                        item.cod_moneda = Convert.ToString(dr["cod_moneda"]);
                        item.mayor = Convert.ToString(dr["mayor"]);
                        item.subgrupo = Convert.ToString(dr["subgrupo"]);
                        item.niif = Convert.ToString(dr["niif"]);
                        item.grupo = Convert.ToString(dr["grupo"]);
                        item.capitulo = Convert.ToString(dr["capitulo"]);
                        item.sec = Convert.ToString(dr["sec"]);

                        lista.Add(item);
                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(CC__cod_emp, metodo, "ListaBuscaCContable", e.ToString(), DateTime.Now, CC__usuario);
                return null;
            }
        }
        public List<modelowmspcccostos> ListaBuscaCCostos(string CC__usuario, string CC__cod_emp, string CC__cod_dpto)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelowmspcccostos> lista = new List<modelowmspcccostos>();
                    string consulta = ("wmspc_ccostos");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = CC__usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = CC__cod_emp;
                    conmand.Parameters.Add("@cod_dpto", SqlDbType.VarChar).Value = CC__cod_dpto;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modelowmspcccostos item = new modelowmspcccostos();
                        item.descripcion = Convert.ToString(dr["cod_dpto"]) + " - " + Convert.ToString(dr["nom_dpto"]);
                        item.cod_dpto = Convert.ToString(dr["cod_dpto"]);
                        item.nom_dpto = Convert.ToString(dr["nom_dpto"]);
                        item.activo = Convert.ToString(dr["activo"]);

                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(CC__cod_emp, metodo, "ListaBuscaCCostos", e.ToString(), DateTime.Now, CC__usuario);
                return null;
            }


        }
    }
}
