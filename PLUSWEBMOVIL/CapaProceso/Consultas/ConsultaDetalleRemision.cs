﻿using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace CapaProceso.Consultas
{
    public class ConsultaDetalleRemision
    {
        DetalleProformaFac consultaProformasDetalle = new DetalleProformaFac();
        DetalleRemision consRemFac = new DetalleRemision();
        public List<modeloDetalleRemision> BuscarRemisionDetalle(string nro_trans)
        {
            List<modeloDetalleRemision> lista = new List<modeloDetalleRemision>();
            SqlDataReader dr = consRemFac.ListaRemisionDetalle(nro_trans);

            while (dr.Read())
            {

                modeloDetalleRemision item = new modeloDetalleRemision();

                item.nro_trans = Convert.ToString(dr["nro_trans"]);
                item.linea = Convert.ToInt16(dr["linea"]);
                item.cod_emp = Convert.ToString(dr["cod_emp"]);
                item.cod_articulo = Convert.ToString(dr["cod_articulo"]);
                item.nom_articulo = Convert.ToString(dr["nom_articulo"]);
                item.nom_articulo2 = Convert.ToString(dr["nom_articulo2"]);
                item.cantidad = Convert.ToDecimal(dr["cantidad"]);
                item.precio_unit = Convert.ToDecimal(dr["precio_unit"]);
                item.base_imp = Convert.ToDecimal(dr["base_imp"]);
                item.cod_concepret = Convert.ToString(dr["cod_concepret"]);
                item.subtotal = Convert.ToDecimal(dr["subtotal"]);
                item.tasa_iva = Convert.ToString(dr["tasa_iva"]);
                item.porc_iva = Convert.ToDecimal(dr["porc_iva"]);
                item.valor_iva = Convert.ToDecimal(dr["valor_iva"]);
                item.total = Convert.ToDecimal(dr["total"]);
                item.porc_descto = Convert.ToDecimal(dr["porc_descto"]);
                item.valor_descto = Convert.ToDecimal(dr["valor_descto"]);
                item.cod_cta_vtas = Convert.ToString(dr["cod_cta_vtas"]);
                item.cod_cta_cos = Convert.ToString(dr["cod_cta_cos"]);
                item.cod_cta_inve = Convert.ToString(dr["cod_cta_inve"]);
                item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                item.nro_audit = Convert.ToString(dr["nro_audit"]);
                item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                item.detadescuento = Convert.ToDecimal(dr["valor_descto"]);
                item.detaiva = Convert.ToDecimal(dr["valor_iva"]);
                lista.Add(item);
            }
            return lista;
        }

    }
}
