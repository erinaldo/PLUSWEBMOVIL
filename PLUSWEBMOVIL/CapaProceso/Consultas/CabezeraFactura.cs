using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
    public class CabezeraFactura
    {
        FacturACab factura = new FacturACab();
        modelocabecerafactura modelocabfactura = new modelocabecerafactura();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "CabezeaFactura.cs";

        public string ActualizaDetalleFactura(ModeloDetalleFactura detalleFactura)
        {
            try
            {
                string respuesta = factura.ActualizarDetalleFactura(detalleFactura);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(detalleFactura.cod_emp, metodo, "ActualizaDetalleFactura", e.ToString(), DateTime.Today, detalleFactura.usuario_mod);
                return "No se pudo completar la acción." + "ActualizaDetalleFactura." + " Por favor notificar al administrador.";
            }

        }

        //Insertar cabecera NC Financiera
        public string InsertarCabezeraNotaCredito(modelocabecerafactura cabezeraFactura)
        {
            try
            {
                string respuesta = factura.InsertarCabeceraNCFinan(cabezeraFactura);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cabezeraFactura.cod_emp, metodo, "InsertarCabezeraNotaCredito", e.ToString(), DateTime.Today, cabezeraFactura.usuario_mod);
                return "No se pudo completar la acción." + "InsertarCabezeraNotaCredito." + " Por favor notificar al administrador.";
            }
        }
        //Insertar cabecera de la factura
        public string InsertarCabezeraFactura(modelocabecerafactura cabezeraFactura)
        {
            try
            {
                string respuesta = factura.InsertarCabecera(cabezeraFactura);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cabezeraFactura.cod_emp, metodo, "InsertarCabezeraFactura", e.ToString(), DateTime.Today, cabezeraFactura.usuario_mod);
                return "No se pudo completar la acción." + "InsertarCabezeraFactura." + " Por favor notificar al administrador.";
            }
        }

        //Actualizar estado factura
        public string ActualizarEstadoFactura(string nro_trans, string estado)
        {
            try
            {
                string respuesta = factura.ActualizarEstadoFactura(nro_trans, estado);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ActualizarEstadoFactura", e.ToString(), DateTime.Today,"UDP");
                return "No se pudo completar la acción." + "ActualizarEstadoFactura." + " Por favor notificar al administrador.";
            }
        }

        public string EliminarCabDetFactura(string nro_trans)
        {
            try
            {
                string respuesta = factura.EliminarCabDetFactura(nro_trans);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "EliminarCabDetFactura", e.ToString(), DateTime.Today, "DLT");
                return "No se pudo completar la acción." + "EliminarCabDetFactura." + " Por favor notificar al administrador.";
            }
        }
    }
}