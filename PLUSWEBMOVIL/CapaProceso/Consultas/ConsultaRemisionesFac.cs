using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
   public  class ConsultaRemisionesFac
    {
        RemisionesFactura consultaRemisiones = new RemisionesFactura();
        public List<modeloRemisionesFactura> BuscarRemisiones(string cod_cliente, string estado, string tipo)
        {
            List<modeloRemisionesFactura> lista = new List<modeloRemisionesFactura>();
            SqlDataReader dr = consultaRemisiones.ListaRemisionesFactura(cod_cliente, estado, tipo);

            while (dr.Read())
            {

                modeloRemisionesFactura item = new modeloRemisionesFactura();

                item.nro_trans_ndm = Convert.ToString(dr["nro_trans_ndm"]);

                item.nro_trans = Convert.ToString(dr["nro_trans"]);
                item.cod_emp = Convert.ToString(dr["cod_emp"]);
                item.fec_doc = Convert.ToDateTime(dr["fec_doc"]);
                DateTime fec_doc_str = Convert.ToDateTime(dr["fec_doc"]);
                item.fec_doc_str = fec_doc_str.ToString("yyyy-MM-dd");
                item.proformas = Convert.ToString(dr["nro_docum"]) + " - " + item.fec_doc_str;
                item.cod_docum = Convert.ToString(dr["cod_docum"]);
                item.serie_docum = Convert.ToString(dr["serie_docum"]);
                item.nro_docum = Convert.ToString(dr["nro_docum"]);
                item.cod_cliente = Convert.ToString(dr["cod_cliente"]);
                item.cod_ccostos = Convert.ToString(dr["cod_ccostos"]);
                item.cod_fpago = Convert.ToString(dr["cod_fpago"]);
                item.observaciones = Convert.ToString(dr["observaciones"]);
                item.cod_vendedor = Convert.ToString(dr["cod_vendedor"]);
                item.estado = Convert.ToString(dr["estado"]);
                item.subtotal = Convert.ToDecimal(dr["subtotal"]);
                item.iva = Convert.ToDecimal(dr["iva"]);
                item.total = Convert.ToDecimal(dr["total"]);
                item.monto_imponible = Convert.ToDecimal(dr["monto_imponible"]);
                item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                item.nro_audit = Convert.ToString(dr["nro_audit"]);
                item.cod_moneda = Convert.ToString(dr["cod_moneda"]);
                item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                lista.Add(item);
            }
            return lista;
        }

        public List<modeloRemisionesFactura> BuscarRemisionUnica(string nro_trans)
        {
            List<modeloRemisionesFactura> lista = new List<modeloRemisionesFactura>();
            SqlDataReader dr = consultaRemisiones.RemisionesFacturaUnico(nro_trans);

            while (dr.Read())
            {

                modeloRemisionesFactura item = new modeloRemisionesFactura();

                item.nro_trans_ndm = Convert.ToString(dr["nro_trans_ndm"]);

                item.nro_trans = Convert.ToString(dr["nro_trans"]);
                item.cod_emp = Convert.ToString(dr["cod_emp"]);
                item.fec_doc = Convert.ToDateTime(dr["fec_doc"]);
                DateTime fec_doc_str = Convert.ToDateTime(dr["fec_doc"]);
                item.fec_doc_str = fec_doc_str.ToString("yyyy-MM-dd");
                item.proformas = Convert.ToString(dr["nro_docum"]) + " - " + item.fec_doc_str;
                item.cod_docum = Convert.ToString(dr["cod_docum"]);
                item.serie_docum = Convert.ToString(dr["serie_docum"]);
                item.nro_docum = Convert.ToString(dr["nro_docum"]);
                item.cod_cliente = Convert.ToString(dr["cod_cliente"]);
                item.cod_ccostos = Convert.ToString(dr["cod_ccostos"]);
                item.cod_fpago = Convert.ToString(dr["cod_fpago"]);
                item.observaciones = Convert.ToString(dr["observaciones"]);
                item.cod_vendedor = Convert.ToString(dr["cod_vendedor"]);
                item.estado = Convert.ToString(dr["estado"]);
                item.subtotal = Convert.ToDecimal(dr["subtotal"]);
                item.iva = Convert.ToDecimal(dr["iva"]);
                item.total = Convert.ToDecimal(dr["total"]);
                item.monto_imponible = Convert.ToDecimal(dr["monto_imponible"]);
                item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                item.nro_audit = Convert.ToString(dr["nro_audit"]);
                item.cod_moneda = Convert.ToString(dr["cod_moneda"]);
                item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                lista.Add(item);
            }
            return lista;
        }
    }
}
