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
    public class ParametroComercial
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public List<modeloparametrocomercial> ConsultaComercial(string cod_emp)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloparametrocomercial> lista = new List<modeloparametrocomercial>();

                    string consulta = "SELECT * FROM wmm_param_comercial WHERE cod_emp = @cod_emp";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        modeloparametrocomercial item = new modeloparametrocomercial();
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.impresion_factura = Convert.ToString(dr["impresion_factura"]);
                        item.impresion_proforma = Convert.ToString(dr["impresion_proforma"]);
                        item.impresion_remision = Convert.ToString(dr["impresion_remision"]);
                        item.impresion_nc = Convert.ToString(dr["impresion_nc"]);
                        item.impresion_post = Convert.ToString(dr["impresion_pos"]);
                        item.impresion_pedcom = Convert.ToString(dr["impresion_pedcom"]);
                        item.info_trib1 = Convert.ToString(dr["info_trib1"]);
                        item.info_trib2 = Convert.ToString(dr["info_trib2"]);
                        item.info_trib3 = Convert.ToString(dr["info_trib3"]);
                        item.info_trib4 = Convert.ToString(dr["info_trib4"]);
                        item.info_trib5 = Convert.ToString(dr["info_trib5"]);
                        item.letra_cambio1 = Convert.ToString(dr["letra_cambio1"]);
                        item.letra_cambio2 = Convert.ToString(dr["letra_cambio2"]);
                        item.letra_cambio3 = Convert.ToString(dr["letra_cambio3"]);
                        item.letra_cambio4 = Convert.ToString(dr["letra_cambio4"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.maneja_recurso = Convert.ToString(dr["maneja_recurso"]);
                        item.meses_historia = Convert.ToString(dr["meses_historia"]);
                        lista.Add(item);


                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "ParametroComercial.cs", "ConsultaComercial", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
    }
}
