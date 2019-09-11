using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
  public  class DetalleRemision
    {
        //Cargar remision detalle para la factura cabecera
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();



        public List<modeloDetalleRemision> ListaRemisionDetalle(string nro_trans)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloDetalleRemision> lista = new List<modeloDetalleRemision>();
                    string consulta = ("SELECT * FROM wmt_remision_det WHERE  nro_trans = @nro_trans");
                    SqlCommand conmand = new SqlCommand(consulta, cn);


                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    SqlDataReader dr = conmand.ExecuteReader();

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
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, "DetalleRemision.cs", "ListaRemisionDetalle", e.ToString(), DateTime.Today, "consulta");
                return null;
            }


        }
    }
}
