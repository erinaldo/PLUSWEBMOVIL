using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
   public  class DetalleFactura
    {
        FacturaDetalle detalleFacturas = new FacturaDetalle();
        ModeloDetalleFactura modeloDetFactura = new ModeloDetalleFactura();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "DetalleFactura.cs";

        //actualizar detalle factura sin lista
        public string ActualizarDetalleFacturaNCSL(string nom_articulo2, decimal cantidad, decimal precio_unit, string nro_trans, int linea, string cod_emp, decimal porc_descto, string usuario_mod, string cod_ccostos)
        {
            try
            {
                string respuesta = detalleFacturas.ActualizarDetalleSL(nom_articulo2, cantidad, precio_unit, nro_trans, linea, cod_emp, porc_descto, usuario_mod, cod_ccostos);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ActualizarDetalleFacturaNCSL", e.ToString(), DateTime.Now, usuario_mod);
                return "No se pudo completar la acción." + "ActualizarDetalleFacturaNCSL." + " Por favor notificar al administrador.";
            }

        }

        //actualizar detalle factura sin lista
        public string ActualizarDetalleFacturaSL(string nom_articulo2, decimal cantidad, decimal precio_unit, string nro_trans, int linea, string cod_emp, decimal porc_descto, string usuario_mod, string cod_ccostos)
        {
            try
            {
                string respuesta = detalleFacturas.ActualizarDetalleSL(nom_articulo2,  cantidad,  precio_unit,  nro_trans, linea,  cod_emp,  porc_descto, usuario_mod, cod_ccostos);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ActualizarDetalleFacturaSL", e.ToString(), DateTime.Now, usuario_mod);
                return "No se pudo completar la acción." + "ActualizarDetalleFacturaSL." + " Por favor notificar al administrador.";
            }

        }

        //INSERTAR DETALLE NC SIN LISTA
        public string InsertarDetalleNCSL(string cod_doca, string nro_doca, string serie_doca, string nom_articulo, string nom_articulo2, decimal cantidad, decimal precio_unit, decimal base_imp, decimal porc_iva, string nro_trans, int linea, string cod_emp, string cod_articulo, string cod_concepret, decimal porc_descto, decimal valor_descto, string cod_cta_vtas, string cod_cta_cos, string cod_cta_inve, string usuario_mod, string nro_audit, DateTime fecha_mod, string tasa_iva, string cod_ccostos, string cod_articulo2)
        {
            try
            {
                string respuesta = detalleFacturas.InsertarDetalleNCSL(cod_doca, nro_doca,serie_doca, nom_articulo, nom_articulo2, cantidad, precio_unit, base_imp, porc_iva, nro_trans, linea, cod_emp, cod_articulo, cod_concepret, porc_descto, valor_descto, cod_cta_vtas, cod_cta_cos, cod_cta_inve, usuario_mod, nro_audit, fecha_mod, tasa_iva, cod_ccostos, cod_articulo2);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "InsertarDetalleNCSL", e.ToString(), DateTime.Now, usuario_mod);
                return "No se pudo completar la acción." + "InsertarDetalleNCSL." + " Por favor notificar al administrador.";
            }

        }

        //INSERTAR DETALLE FACTURA SIN LISTA
        public string InsertarDetalleFacturaSL(string nom_articulo, string nom_articulo2, decimal cantidad, decimal precio_unit, decimal base_imp, decimal porc_iva, string nro_trans, int linea, string cod_emp, string cod_articulo, string cod_concepret, decimal porc_descto, decimal valor_descto, string cod_cta_vtas, string cod_cta_cos, string cod_cta_inve, string usuario_mod, string nro_audit, DateTime fecha_mod, string tasa_iva, string cod_ccostos, string cod_articulo2)
        {
            try
            {
                string respuesta = detalleFacturas.InsertarDetalleSL(nom_articulo, nom_articulo2, cantidad, precio_unit, base_imp, porc_iva, nro_trans, linea, cod_emp, cod_articulo, cod_concepret, porc_descto, valor_descto, cod_cta_vtas, cod_cta_cos, cod_cta_inve, usuario_mod, nro_audit, fecha_mod, tasa_iva, cod_ccostos, cod_articulo2);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "InsertarDetalleFacturaS", e.ToString(), DateTime.Now, usuario_mod);
                return "No se pudo completar la acción." + "InsertarDetalleFacturaS." + " Por favor notificar al administrador.";
            }

        }
        public string EliminarDetalleFactura(string nro_trans, string linea, string cod_emp, string usuario)
        { 
            try
            {
                string respuesta = detalleFacturas.EliminarDetalle( nro_trans,  linea,  cod_emp, usuario);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "EliminarDetalleFactura", e.ToString(), DateTime.Today, usuario);
                return "No se pudo completar la acción." + "EliminarDetalleFactura." + " Por favor notificar al administrador.";
            }

        }
        //ulyima linea
        public string UltimaLinea(string nro_trans, string cod_emp, string usuario)
        {
            try
            {
                string respuesta = detalleFacturas.UltimaLinea(nro_trans,cod_emp,usuario);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "UltimaLinea", e.ToString(), DateTime.Today, usuario);
                return "No se pudo completar la acción." + "UltimaLinea." + " Por favor notificar al administrador.";
            }

        }
        public string InsertarDetalleFactura(ModeloDetalleFactura detalleFactura)
        {
            try
            {
                string respuesta = detalleFacturas.InsertarDetalle(detalleFactura);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(detalleFactura.cod_emp, metodo, "InsertarDetalleFactura", e.ToString(), DateTime.Today, detalleFactura.usuario_mod);
                return "No se pudo completar la acción." + "InsertarDetalleFactura." + " Por favor notificar al administrador.";
            }

        }
        /*Detalle NC por anulacion afectacion total*/
        public string InsertarDetallNCFina(ModeloDetalleFactura detalleFactura)
        {
            try
            {
                string respuesta = detalleFacturas.InsertarDetalleNCFinanciera(detalleFactura);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(detalleFactura.cod_emp, metodo, "InsertarDetallNCFina", e.ToString(), DateTime.Today, detalleFactura.usuario_mod);
                return "No se pudo completar la acción." + "InsertarDetallNCFina." + " Por favor notificar al administrador.";
            }
        }
    }
}
