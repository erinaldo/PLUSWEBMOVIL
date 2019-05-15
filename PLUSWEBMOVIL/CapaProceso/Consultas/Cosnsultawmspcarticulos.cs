using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
    public class Cosnsultawmspcarticulos
    {
        Articulos articulos = new Articulos();
        modelowmspcarticulos modeloarticulos = new modelowmspcarticulos();

        public List<modelowmspcarticulos> ConsultaArticulos(string ArtB__usuario, string ArtB__cod_emp, string ArtB__articulo, string ArtB__tipo, string ArtB__compras, string ArtB__ventas)
        {
            List<modelowmspcarticulos> lista = new List<modelowmspcarticulos>();
            SqlDataReader dr = articulos.ListaArticulos(ArtB__usuario, ArtB__cod_emp, ArtB__articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);


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
                item.volumen_art = Convert.ToString(dr["volumen_art"]);
                item.activo_cmp = Convert.ToString(dr["activo_cmp"]);
                item.cod_concepret = Convert.ToString(dr["cod_concepret"]);
                item.cod_cta_vtas = Convert.ToString(dr["cod_cta_vtas"]);
                item.cod_cta_inve = Convert.ToString(dr["cod_cta_inve"]);
                item.cod_cta_cos = Convert.ToString(dr["cod_cta_cos"]);
                item.cod_tipo_impu = Convert.ToString(dr["cod_tipo_impu"]);
                item.cod_tasa_impu = Convert.ToString(dr["cod_tasa_impu"]);
                item.porc_impuesto = Convert.ToString(dr["porc_impuesto"]);
                item.nom_impuesto = Convert.ToString(dr["nom_impuesto"]);
                item.precio = Convert.ToString(dr["precio"]);
                item.valor_impu = Convert.ToString(dr["valor_impu"]);
                item.precio_total = Convert.ToString(dr["precio_total"]);

                lista.Add(item);

            }
            return lista;
        }
    }
}
    

