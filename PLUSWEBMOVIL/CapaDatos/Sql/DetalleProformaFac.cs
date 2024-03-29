﻿using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
  public   class DetalleProformaFac
    {
        //Cargar proformas detalle para la factura cabecera
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "DetalleProformaFac";
        //Vendedor proforma
        public string VendedorProforma(string nro_trans, string empresa, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string vendedor = null;

                    string consulta = ("SELECT cod_vendedor FROM wmt_proformas_cab WHERE  nro_trans = @nro_trans");
                    SqlCommand conmand = new SqlCommand(consulta, cn);


                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        vendedor = Convert.ToString(dr["cod_vendedor"]);
                    }
                    return vendedor;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "VendedorProforma", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }

        public List<modeloDetalleProforma> ListaProformasDetalle(string nro_trans)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloDetalleProforma> lista = new List<modeloDetalleProforma>();

                    string consulta = ("SELECT * FROM wmt_proformas_det WHERE  nro_trans = @nro_trans");
                    SqlCommand conmand = new SqlCommand(consulta, cn);


                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloDetalleProforma item = new modeloDetalleProforma();

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
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ListaProformasDetalle", e.ToString(), DateTime.Now, "consulta");
                return null;
            }


        }
    }
}
