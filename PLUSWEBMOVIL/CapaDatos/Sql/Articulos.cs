using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CapaProceso.Modelos;
using CapaDatos.Modelos;

namespace CapaDatos.Sql
{
   public  class Articulos
    {
        
            Conexion conexion = new Conexion();
            public SqlConnection cn = null;            
            modelowmspcarticulos modeloarticulos = new modelowmspcarticulos();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public List<modelowmspcarticulos> ListaArticulos(string ArtB__usuario, string ArtB__cod_emp, string ArtB__articulo, string ArtB__tipo, string ArtB__compras, string ArtB__ventas)
        {
            try {

                using (cn = conexion.genearConexion())
                {
                    List<modelowmspcarticulos> lista = new List<modelowmspcarticulos>();

                    string consulta = ("wmspc_articulos");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = ArtB__usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = ArtB__cod_emp;
                    conmand.Parameters.Add("@articulo", SqlDbType.VarChar).Value = ArtB__articulo;
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = ArtB__tipo;
                    conmand.Parameters.Add("@compras", SqlDbType.VarChar).Value = ArtB__compras;
                    conmand.Parameters.Add("@ventas", SqlDbType.VarChar).Value = ArtB__ventas;



                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modelowmspcarticulos item = new modelowmspcarticulos();
                        item.cod_articulo = Convert.ToString(dr["cod_articulo"]);
                        item.nom_articulo = Convert.ToString(dr["nom_articulo"]);
                        item.nom_det_art = Convert.ToString(dr["nom_det_art"]);
                        item.cod_grpunidad = Convert.ToString(dr["cod_grpunidad"]);
                        item.activo_stk = Convert.ToString(dr["activo_stk"]);
                        item.activo_com = Convert.ToString(dr["activo_com"]);
                        item.cod_tipoart = Convert.ToString(dr["cod_tipoart"]);
                        item.volumen_art = Convert.ToDecimal(dr["volumen_art"]);
                        item.activo_cmp = Convert.ToString(dr["activo_cmp"]);
                        item.cod_concepret = Convert.ToString(dr["cod_concepret"]);
                        item.cod_cta_vtas = Convert.ToString(dr["cod_cta_vtas"]);
                        item.cod_cta_inve = Convert.ToString(dr["cod_cta_inve"]);
                        item.cod_cta_cos = Convert.ToString(dr["cod_cta_cos"]);
                        item.cod_tipo_impu = Convert.ToString(dr["cod_tipo_impu"]);
                        item.cod_tasa_impu = Convert.ToString(dr["cod_tasa_impu"]);
                        decimal fomImpu = Convert.ToDecimal(dr["porc_impuesto"]);
                        item.porc_impuesto = String.Format("{0:N2}", fomImpu).ToString();
                        item.nom_impuesto = Convert.ToString(dr["nom_impuesto"]);
                        item.precio = Convert.ToString(dr["precio"]);

                        item.valor_impu = Convert.ToString(dr["valor_impu"]);
                        decimal formPrecio = Convert.ToDecimal(dr["precio_total"]);
                        item.precio_total = String.Format("{0:N2}", formPrecio).ToString();


                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, "Articulos.cs", "ListaArticulos", e.ToString(), DateTime.Today, ArtB__usuario);
                return null;
            }
        }

        }
}
