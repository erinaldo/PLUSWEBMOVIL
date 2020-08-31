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
        ModificarPrecioFactura descuento = new ModificarPrecioFactura();
        modelocabecerafactura modelocabfactura = new modelocabecerafactura();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "CabezeaFactura.cs";
        //Buscar concepto especifico por codigo de concepto
        public ModeloFacturaDescuento ConceptoUnico(string usuario, string cod_emp, string codigo)
        {
            try
            {
                ModeloFacturaDescuento respuesta = new ModeloFacturaDescuento();
                respuesta = descuento.ConceptoUnicoEmp(usuario, cod_emp, codigo);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConceptoUnico", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        //Lista recargos/descuentos de factura por empresa
        public List<ModeloFacturaDescuento> ListaRecDesFacturaxconcepto(string usuario, string cod_emp, string codigo)
        {
            try
            {
                List<ModeloFacturaDescuento> respuesta = new List<ModeloFacturaDescuento>();
                respuesta = descuento.ListaDesRecFacturaxEmp(usuario, cod_emp, codigo);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaRecDesFacturaxconcepto", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        //Lista recargos/descuentos de factura por empresa
        public List<ModeloFacturaDescuento>ListaRecDesFactura(string usuario, string cod_emp)
        {
            try
            {
                List<ModeloFacturaDescuento> respuesta = new List<ModeloFacturaDescuento>();
                respuesta = descuento.ListaDesRecFactura(usuario, cod_emp);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaRecDesFactura", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        //eliminar  recargos/descuentos de factura por empresa
        public string EliminarRecDesFactura(ModeloFacturaDescuento descuentoFactura)
        {
            try
            {
                string respuesta = descuento.EliminarDescRecFactura(descuentoFactura);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(descuentoFactura.cod_emp, metodo, "EliminarRecDesFactura", e.ToString(), DateTime.Now, descuentoFactura.usuario_mod);
                return "No se pudo completar la acción." + "EliminarRecDesFactura." + " Por favor notificar al administrador.";
            }
        }
        //Actuaizar    recargos/descuentos de factura por empresa
        public string ActualizarRecDesFactura(ModeloFacturaDescuento descuentoFactura)
        {
            try
            {
                string respuesta = descuento.ActualizarDescRecFactura(descuentoFactura);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(descuentoFactura.cod_emp, metodo, "ActualizarRecDesFactura", e.ToString(), DateTime.Now, descuentoFactura.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarRecDesFactura." + " Por favor notificar al administrador.";
            }
        }
        //Insertar    recargos/descuentos de factura por empresa
        public string InsertarRecDesFactura(ModeloFacturaDescuento descuentoFactura)
        {
            try
            {
                string respuesta = descuento.InsertarDescRecFactura(descuentoFactura);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(descuentoFactura.cod_emp, metodo, "InsertarRecDesFactura", e.ToString(), DateTime.Now, descuentoFactura.usuario_mod);
                return "No se pudo completar la acción." + "InsertarRecDesFactura." + " Por favor notificar al administrador.";
            }
        }
        //Actualizar cabecera nota de crédito
        public string ActualizarCabeceraNC(modelocabecerafactura cabezeraFactura)
        {
            try
            {
                string respuesta = factura.ActualizarCabeceraNCFinan(cabezeraFactura);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cabezeraFactura.cod_emp, metodo, "ActualizarCabeceraNC", e.ToString(), DateTime.Now, cabezeraFactura.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarCabeceraNC." + " Por favor notificar al administrador.";
            }
        }
        //Actulizar cabcera factura
        public string ActualizarCabeceraFactura(modelocabecerafactura cabezeraFactura)
        {
            try
            {
                string respuesta = factura.ActualizarCabeceraFactura(cabezeraFactura);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cabezeraFactura.cod_emp, metodo, "ActualizarCabeceraFactur", e.ToString(), DateTime.Now, cabezeraFactura.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarCabeceraFactura." + " Por favor notificar al administrador.";
            }
        }
        public string ActualizaDetalleFactura(ModeloDetalleFactura detalleFactura)
        {
            try
            {
                string respuesta = factura.ActualizarDetalleFactura(detalleFactura);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(detalleFactura.cod_emp, metodo, "ActualizaDetalleFactura", e.ToString(), DateTime.Now, detalleFactura.usuario_mod);
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

                guardarExcepcion.ClaseInsertarExcepcion(cabezeraFactura.cod_emp, metodo, "InsertarCabezeraNotaCredito", e.ToString(), DateTime.Now, cabezeraFactura.usuario_mod);
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

                guardarExcepcion.ClaseInsertarExcepcion(cabezeraFactura.cod_emp, metodo, "InsertarCabezeraFactura", e.ToString(), DateTime.Now, cabezeraFactura.usuario_mod);
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

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ActualizarEstadoFactura", e.ToString(), DateTime.Now,"UDP");
                return "No se pudo completar la acción." + "ActualizarEstadoFactura." + " Por favor notificar al administrador.";
            }
        }
        //Actualizar guardar doc_adjunto factura cabeera
        public string ActualizarDocAdjuntoFactura(string nro_trans, string adjunto, string usuario)
        {
            try
            {
                string respuesta = factura.ActualizarAdjuntoFactura(nro_trans, adjunto, usuario);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ActualizarDocAdjuntoFactura", e.ToString(), DateTime.Now, usuario);
                return "No se pudo completar la acción." + "ActualizarObserFactur." + " Por favor notificar al administrador.";
            }
        }
        //Actualizar o guardar la observacion de la factura
        public string ActualizarObserFactura(string nro_trans,string observacion)
        {
            try
            {
                string respuesta = factura.ActualizarObsFactura(nro_trans,observacion);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ActualizarObserFactur", e.ToString(), DateTime.Now, "UDP");
                return "No se pudo completar la acción." + "ActualizarObserFactur." + " Por favor notificar al administrador.";
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

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "EliminarCabDetFactura", e.ToString(), DateTime.Now, "DLT");
                return "No se pudo completar la acción." + "EliminarCabDetFactura." + " Por favor notificar al administrador.";
            }
        }

        public Boolean ConsultaSNCabFactura(string nro_trans, string cod_emp, string usuario)
        {
            try
            {
                Boolean respuesta = factura.ConsultaSNCabecera(nro_trans, cod_emp, usuario);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaSNCabFactura", e.ToString(), DateTime.Now, usuario);
                return false;
            }
        }
    }
}