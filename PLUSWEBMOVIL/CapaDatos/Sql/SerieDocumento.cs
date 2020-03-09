using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class SerieDocumento
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<modelowmspcresfact> ListaBuscaSerieDocumento(string ResF_usuario, string ResF_cod_emp, string ResF_estado, string ResF_serie, string ResF_tipo)
        {

            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelowmspcresfact> lista = new List<modelowmspcresfact>();
                    string consulta = ("wmspc_resfact");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;

                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = ResF_usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = ResF_cod_emp;
                    conmand.Parameters.Add("@estado", SqlDbType.VarChar).Value = ResF_estado;
                    conmand.Parameters.Add("@serie", SqlDbType.VarChar).Value = ResF_serie;
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = ResF_tipo;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modelowmspcresfact item = new modelowmspcresfact();
                        item.cod_atrib1 = Convert.ToString(dr["cod_atrib1"]);
                        item.serie_docum = Convert.ToString(dr["serie_docum"]);
                        item.nro_docum = Convert.ToString(dr["nro_docum"]);
                        item.nro_docum_ref = Convert.ToString(dr["nro_docum_ref"]);
                        item.activo = Convert.ToString(dr["activo"]);
                        item.numerador = Convert.ToString(dr["numerador"]);
                        item.fec_valor = Convert.ToDateTime(dr["fec_valor"]);
                        item.fec_emision = item.fec_valor.ToString("yyyy-MM-dd");
                        item.fec_venc = Convert.ToDateTime(dr["fec_venc"]);
                        item.fec_caducidad = item.fec_venc.ToString("yyyy-MM-dd");
                        item.tipo = Convert.ToString(dr["tipo"]);
                        item.tipo_fac =Convert.ToString(dr["factura_elec"]);
                        item.meses = Convert.ToString(dr["meses"]);
                        item.prefijo = Convert.ToString(dr["prefijo"]);
                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ResF_cod_emp, "SerieDocumento.cs", "ListaBuscaSerieDocumento", e.ToString(), DateTime.Today, ResF_usuario);
                return null;
            }


        }
    }
}
