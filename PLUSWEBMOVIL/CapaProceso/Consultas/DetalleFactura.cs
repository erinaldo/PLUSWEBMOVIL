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
