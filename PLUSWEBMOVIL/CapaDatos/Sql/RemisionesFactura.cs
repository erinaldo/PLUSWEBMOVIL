﻿using System;
using CapaProceso.Modelos;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CapaDatos.Modelos;

namespace CapaDatos.Sql
{
   public  class RemisionesFactura
    {
       
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        //Insertar en la tabla wmt_remision_ins
        public string InsertarRemisionIns(modeloRemisionesFactura remisionCab)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO  wmt_remision_ins (nro_trans, nro_docum, cod_emp, cod_cliente, usuario_mod, nro_audit, cod_proceso) VALUES (@nro_trans, @nro_docum, @cod_emp, @cod_cliente, @usuario_mod, @nro_audit, @cod_proceso)";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = remisionCab.nro_trans;
                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = remisionCab.nro_docum;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = remisionCab.cod_emp;
                    conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = remisionCab.cod_cliente;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = remisionCab.usuario_mod;
                    conmand.Parameters.Add("@nro_audit", SqlDbType.VarChar).Value = remisionCab.nro_audit;
                    conmand.Parameters.Add("@cod_proceso", SqlDbType.VarChar).Value = remisionCab.cod_proceso;

                    int dr = conmand.ExecuteNonQuery();
                    return "Proforma";
                }
                
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(remisionCab.cod_emp, "RemisionesFactura.cs", "InsertarRemisionIns", e.ToString(), DateTime.Today, remisionCab.usuario_mod);
                return "No se pudo completar la acción." + "InsertarRemisionIns." + " Por favor notificar al administrador.";
            }
        }

        //Cargar remisiones nro_trans para la factura cabecera

        public List<modeloRemisionesFactura> RemisionesFacturaUnico(string nro_trans)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloRemisionesFactura> lista = new List<modeloRemisionesFactura>();
                    string consulta = ("SELECT * FROM  wmt_remision_cab WHERE nro_trans = @nro_trans");
                    SqlCommand conmand = new SqlCommand(consulta, cn);


                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;

                    SqlDataReader dr = conmand.ExecuteReader();
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
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, "RemisionesFactura.cs", "RemisionesFacturaUnicos", e.ToString(), DateTime.Today, "consulta");
                return null;
            }


        }
        //Cargar remisiones para la factura cabecera

        public List<modeloRemisionesFactura> ListaRemisionesFactura(string cod_cliente, string estado, string tipo)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloRemisionesFactura> lista = new List<modeloRemisionesFactura>();
                    string consulta = ("SELECT * FROM  dbo.wmt_remision_cab WHERE cod_cliente = @cod_cliente AND estado = @estado AND tipo = @tipo");
                    SqlCommand conmand = new SqlCommand(consulta, cn);


                    conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = cod_cliente;
                    conmand.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;

                    SqlDataReader dr = conmand.ExecuteReader();
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
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "RemisionesFactura.cs", "ListaRemisionesFactura", e.ToString(), DateTime.Today, "consulta");
                return null;
            }

        }
    }
}
