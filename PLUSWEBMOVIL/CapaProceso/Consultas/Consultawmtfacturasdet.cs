using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
    public class Consultawmtfacturasdet
    {
        FacturaDetalle consulta = new FacturaDetalle();
        ModeloDetalleFactura modelconsulta = new ModeloDetalleFactura();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "Consultawmtfacturasdet.cs";
        //consulta por line
        public List<ModeloDetalleFactura> ConsultaDetalleFacuraLinea(string nro_trans, string linea)
        {
            try
            {
                List<ModeloDetalleFactura> lista = new List<ModeloDetalleFactura>();
                SqlDataReader dr = consulta.ConsultaDetalleFacturaLinea(nro_trans, linea);

                while (dr.Read())
                {
                    ModeloDetalleFactura item = new ModeloDetalleFactura();
                    item.nro_trans = Convert.ToString(dr["nro_trans"]);
                    item.linea = Convert.ToInt16(dr["linea"]);
                    item.cod_emp = Convert.ToString(dr["cod_emp"]);
                    item.cod_doca = Convert.ToString(dr["cod_doca"]);
                    item.nro_doca = Convert.ToString(dr["nro_doca"]);
                    item.serie_doca = Convert.ToString(dr["serie_doca"]);
                    item.cod_articulo = Convert.ToString(dr["cod_articulo"]);
                    item.cod_articulo2 = Convert.ToString(dr["cod_articulo2"]);
                    item.nom_articulo = Convert.ToString(dr["nom_articulo"]);
                    item.nom_articulo2 = Convert.ToString(dr["nom_articulo2"]);
                    item.cantidad = Convert.ToDecimal(dr["cantidad"]);
                    item.precio_unit = Convert.ToDecimal(dr["precio_unit"]);
                    item.base_imp = Convert.ToDecimal(dr["base_imp"]);
                    item.cod_concepret = Convert.ToString(dr["cod_concepret"]);
                    item.subtotal = Convert.ToDecimal(dr["subtotal"]);
                    item.cod_impu1 = Convert.ToString(dr["cod_impu1"]);
                    item.tasa_iva = Convert.ToString(dr["tasa_iva"]);
                    item.porc_iva = Convert.ToDecimal(dr["porc_iva"]);
                    item.base_iva = Convert.ToDecimal(dr["base_iva"]);
                    item.valor_iva = Convert.ToDecimal(dr["valor_iva"]);
                    item.cod_impu2 = Convert.ToString(dr["cod_impu2"]);
                    item.tasa_impu2 = Convert.ToString(dr["tasa_impu2"]);
                    item.porc_impu2 = Convert.ToDecimal(dr["porc_impu2"]);
                    item.valor_impu2 = Convert.ToDecimal(dr["valor_impu2"]);
                    item.cod_impu3 = Convert.ToString(dr["cod_impu3"]);
                    item.tasa_impu3 = Convert.ToString(dr["tasa_impu3"]);
                    item.porc_impu3 = Convert.ToDecimal(dr["porc_impu3"]);
                    item.valor_impu3 = Convert.ToDecimal(dr["valor_impu3"]);
                    item.cod_impu4 = Convert.ToString(dr["cod_impu4"]);
                    item.tasa_impu4 = Convert.ToString(dr["tasa_impu4"]);
                    item.porc_impu4 = Convert.ToDecimal(dr["porc_impu4"]);
                    item.valor_impu4 = Convert.ToDecimal(dr["valor_impu4"]);
                    item.cod_impu5 = Convert.ToString(dr["cod_impu5"]);
                    item.tasa_impu5 = Convert.ToString(dr["tasa_impu5"]);
                    item.porc_impu5 = Convert.ToDecimal(dr["porc_impu5"]);
                    item.valor_impu5 = Convert.ToDecimal(dr["valor_impu5"]);
                    item.total = Convert.ToDecimal(dr["total"]);
                    item.porc_descto = Convert.ToDecimal(dr["porc_descto"]);
                    item.valor_descto = Convert.ToDecimal(dr["valor_descto"]);
                    item.cod_cta_vtas = Convert.ToString(dr["cod_cta_vtas"]);
                    item.cod_cta_cos = Convert.ToString(dr["cod_cta_cos"]);
                    item.cod_cta_inve = Convert.ToString(dr["cod_cta_inve"]);
                    item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                    item.nro_audit = Convert.ToString(dr["nro_audit"]);
                    item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                    item.cod_ccostos = Convert.ToString(dr["cod_ccostos"]);
                    item.detadescuento = Convert.ToDecimal(dr["valor_descto"]);
                    item.detaiva = Convert.ToDecimal(dr["valor_iva"]);
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ConsultaDetalleFacura", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }

        public List<ModeloDetalleFactura> ConsultaDetalleFacura(string nro_trans)
        {
            try
            {
                List<ModeloDetalleFactura> lista = new List<ModeloDetalleFactura>();
                SqlDataReader dr = consulta.ConsultaDetalleFactura(nro_trans);

                while (dr.Read())
                {
                    ModeloDetalleFactura item = new ModeloDetalleFactura();
                    item.nro_trans = Convert.ToString(dr["nro_trans"]);
                    item.linea = Convert.ToInt16(dr["linea"]);
                    item.cod_emp = Convert.ToString(dr["cod_emp"]);
                    item.cod_doca = Convert.ToString(dr["cod_doca"]);
                    item.nro_doca = Convert.ToString(dr["nro_doca"]);
                    item.serie_doca = Convert.ToString(dr["serie_doca"]);
                    item.cod_articulo = Convert.ToString(dr["cod_articulo"]);
                    item.cod_articulo2 = Convert.ToString(dr["cod_articulo2"]);
                    item.nom_articulo = Convert.ToString(dr["nom_articulo"]);
                    item.nom_articulo2 = Convert.ToString(dr["nom_articulo2"]);
                    item.cantidad = Convert.ToDecimal(dr["cantidad"]);
                    item.precio_unit = Convert.ToDecimal(dr["precio_unit"]);
                    item.base_imp = Convert.ToDecimal(dr["base_imp"]);
                    item.cod_concepret = Convert.ToString(dr["cod_concepret"]);
                    item.subtotal = Convert.ToDecimal(dr["subtotal"]);
                    item.cod_impu1 = Convert.ToString(dr["cod_impu1"]);
                    item.tasa_iva = Convert.ToString(dr["tasa_iva"]);
                    item.porc_iva = Convert.ToDecimal(dr["porc_iva"]);
                    item.base_iva = Convert.ToDecimal(dr["base_iva"]);
                    item.valor_iva = Convert.ToDecimal(dr["valor_iva"]);
                    item.cod_impu2 = Convert.ToString(dr["cod_impu2"]);
                    item.tasa_impu2 = Convert.ToString(dr["tasa_impu2"]);
                    item.porc_impu2 = Convert.ToDecimal(dr["porc_impu2"]);
                    item.valor_impu2 = Convert.ToDecimal(dr["valor_impu2"]);
                    item.cod_impu3 = Convert.ToString(dr["cod_impu3"]);
                    item.tasa_impu3 = Convert.ToString(dr["tasa_impu3"]);
                    item.porc_impu3 = Convert.ToDecimal(dr["porc_impu3"]);
                    item.valor_impu3 = Convert.ToDecimal(dr["valor_impu3"]);
                    item.cod_impu4 = Convert.ToString(dr["cod_impu4"]);
                    item.tasa_impu4 = Convert.ToString(dr["tasa_impu4"]);
                    item.porc_impu4 = Convert.ToDecimal(dr["porc_impu4"]);
                    item.valor_impu4 = Convert.ToDecimal(dr["valor_impu4"]);
                    item.cod_impu5 = Convert.ToString(dr["cod_impu5"]);
                    item.tasa_impu5 = Convert.ToString(dr["tasa_impu5"]);
                    item.porc_impu5 = Convert.ToDecimal(dr["porc_impu5"]);
                    item.valor_impu5 = Convert.ToDecimal(dr["valor_impu5"]);
                    item.total = Convert.ToDecimal(dr["total"]);
                    item.porc_descto = Convert.ToDecimal(dr["porc_descto"]);
                    item.valor_descto = Convert.ToDecimal(dr["valor_descto"]);
                    item.cod_cta_vtas = Convert.ToString(dr["cod_cta_vtas"]);
                    item.cod_cta_cos = Convert.ToString(dr["cod_cta_cos"]);
                    item.cod_cta_inve = Convert.ToString(dr["cod_cta_inve"]);
                    item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                    item.nro_audit = Convert.ToString(dr["nro_audit"]);
                    item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                    item.cod_ccostos = Convert.ToString(dr["cod_ccostos"]);
                    item.detadescuento = Convert.ToDecimal(dr["valor_descto"]);
                    item.detaiva = Convert.ToDecimal(dr["valor_iva"]);
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ConsultaDetalleFacura", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }

        //Consulta detalle factura para NC por devolucion
        public List<ModeloDetalleFactura> ConsultaDetFacNCDev(string nro_trans, string articulo)
        {
            try
            {
                List<ModeloDetalleFactura> lista = new List<ModeloDetalleFactura>();
                 
               
                SqlDataReader dr = consulta.ConsultaDetalleFacNCDev(nro_trans, articulo);

                while (dr.Read())
                {
                    ModeloDetalleFactura item = new ModeloDetalleFactura();
                    item.nro_trans = Convert.ToString(dr["nro_trans"]);
                    item.linea = Convert.ToInt16(dr["linea"]);
                    item.cod_emp = Convert.ToString(dr["cod_emp"]);
                    item.cod_doca = Convert.ToString(dr["cod_doca"]);
                    item.nro_doca = Convert.ToString(dr["nro_doca"]);
                    item.serie_doca = Convert.ToString(dr["serie_doca"]);
                    item.cod_articulo = Convert.ToString(dr["cod_articulo"]);
                    item.nom_articulo = Convert.ToString(dr["nom_articulo"]);
                    item.nom_articulo2 = Convert.ToString(dr["nom_articulo2"]);
                    item.cantidad = Convert.ToDecimal(dr["cantidad"]);
                    item.precio_unit = Convert.ToDecimal(dr["precio_unit"]);
                    item.base_imp = Convert.ToDecimal(dr["base_imp"]);
                    item.cod_concepret = Convert.ToString(dr["cod_concepret"]);
                    item.subtotal = Convert.ToDecimal(dr["subtotal"]);
                    item.cod_impu1 = Convert.ToString(dr["cod_impu1"]);
                    item.tasa_iva = Convert.ToString(dr["tasa_iva"]);
                    item.porc_iva = Convert.ToDecimal(dr["porc_iva"]);
                    item.base_iva = Convert.ToDecimal(dr["base_iva"]);
                    item.valor_iva = Convert.ToDecimal(dr["valor_iva"]);
                    item.cod_impu2 = Convert.ToString(dr["cod_impu2"]);
                    item.tasa_impu2 = Convert.ToString(dr["tasa_impu2"]);
                    item.porc_impu2 = Convert.ToDecimal(dr["porc_impu2"]);
                    item.valor_impu2 = Convert.ToDecimal(dr["valor_impu2"]);
                    item.cod_impu3 = Convert.ToString(dr["cod_impu3"]);
                    item.tasa_impu3 = Convert.ToString(dr["tasa_impu3"]);
                    item.porc_impu3 = Convert.ToDecimal(dr["porc_impu3"]);
                    item.valor_impu3 = Convert.ToDecimal(dr["valor_impu3"]);
                    item.cod_impu4 = Convert.ToString(dr["cod_impu4"]);
                    item.tasa_impu4 = Convert.ToString(dr["tasa_impu4"]);
                    item.porc_impu4 = Convert.ToDecimal(dr["porc_impu4"]);
                    item.valor_impu4 = Convert.ToDecimal(dr["valor_impu4"]);
                    item.cod_impu5 = Convert.ToString(dr["cod_impu5"]);
                    item.tasa_impu5 = Convert.ToString(dr["tasa_impu5"]);
                    item.porc_impu5 = Convert.ToDecimal(dr["porc_impu5"]);
                    item.valor_impu5 = Convert.ToDecimal(dr["valor_impu5"]);
                    item.total = Convert.ToDecimal(dr["total"]);
                    item.porc_descto = Convert.ToDecimal(dr["porc_descto"]);
                    item.valor_descto = Convert.ToDecimal(dr["valor_descto"]);
                    item.cod_cta_vtas = Convert.ToString(dr["cod_cta_vtas"]);
                    item.cod_cta_cos = Convert.ToString(dr["cod_cta_cos"]);
                    item.cod_cta_inve = Convert.ToString(dr["cod_cta_inve"]);
                    item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                    item.nro_audit = Convert.ToString(dr["nro_audit"]);
                    item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                    item.cod_ccostos = Convert.ToString(dr["cod_ccostos"]);
                    item.detadescuento = Convert.ToDecimal(dr["valor_descto"]);
                    item.detaiva = Convert.ToDecimal(dr["valor_iva"]);

                    item.nc_pvp = String.Format("{0:N}", Math.Round(item.precio_unit, 2)).ToString();
                    item.nc_iva = String.Format("{0:N}", Math.Round(item.porc_iva, 2)).ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ConsultaDetFacNCDev", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }

        //Consulta Cantidades de NC existentes, NC por devolucion
        public List<ModeloDetalleFactura> ConsultaCantidadesNCDev(string cod_emp, string nro_doca, string serie_doca, string cod_articulo)
        {
            try
            {
                List<ModeloDetalleFactura> lista = new List<ModeloDetalleFactura>();
                SqlDataReader dr = consulta.ConsultaDetCantNCDev(cod_emp, nro_doca, serie_doca, cod_articulo);

                while (dr.Read())
                {
                    ModeloDetalleFactura item = new ModeloDetalleFactura();

                    item.cod_emp = Convert.ToString(dr["cod_emp"]);
                    item.nro_doca = Convert.ToString(dr["nro_doca"]);
                    item.serie_doca = Convert.ToString(dr["serie_doca"]);
                    item.cod_articulo = Convert.ToString(dr["cod_articulo"]);
                    item.cantidad = Convert.ToDecimal(dr["cantidad"]);

                    lista.Add(item);
                }
                return lista;

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaCantidadesNCDev", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
        }

}
