using CapaDatos.Modelos;
using CapaDatos.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
    public class ConsultaMediosPago
    {
        MediosPago consultaMediosPago = new MediosPago();
        FPagosPos guardarPago = new FPagosPos();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "ConsultaMediosPago.cs";
        //Buscar todo los medios de pago
        public List<modeloMediosPago> BuscarMediosPago(string cod_emp)
        {
            try
            {
                List<modeloMediosPago> lista = new List<modeloMediosPago>();
                lista = consultaMediosPago.ListaMediosPago(cod_emp);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "BuscarMediosPago", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

        //Buscar cod_tit 
        public List<ModelosPagosTitular> BuscartitularPagos(string usuario, string cod_emp, string nro_trans)
        {
            try
            {
                List<ModelosPagosTitular> lista = new List<ModelosPagosTitular>();
                lista = consultaMediosPago.TitularPago(usuario, cod_emp, nro_trans);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "BuscartitularPagos", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
        //Recupera datos de medio de pago para insertar en tabla wmt_facturas_pgs
        public List<ModeloTipoPagoTem> BuscarMediosPagoTemporal(string usuario,string cod_emp, string nro_trans)
        {
            try
            {
                List<ModeloTipoPagoTem> lista = new List<ModeloTipoPagoTem>();
                lista = consultaMediosPago.BuscarPagosTemporal(usuario, cod_emp, nro_trans);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "BuscarMediosPagoTemporal", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
        //Insertar Pagos de la factura  Insertar pagos en wmt_facturas_pgs
        public string InsertarPagosFactura(modeloFacturasPagos facturasPagos)
        {
            try
            {
                string respuesta = guardarPago.InsertarFacturaPagos(facturasPagos);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(facturasPagos.cod_emp, metodo, "InsertarPagosFactura", e.ToString(), DateTime.Today, "INS");
                return "No se pudo completar la acción." + "InsertarPagosFactura." + " Por favor notificar al administrador.";
            }

        }

        //Insertar en tabla temporal el wmt_facturas_pgstmp cada codigo de pago
        public string InsertarTipoPago(modeloFacturasPagos TipoPagos)
        {
            try
            {
                string respuesta = guardarPago.InsertarTiposPagos(TipoPagos);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(TipoPagos.cod_emp, metodo, "InsertarTipoPago", e.ToString(), DateTime.Today, "INS");
                return "No se pudo completar la acción." + "InsertarTipoPagos." + " Por favor notificar al administrador.";
            }
        }

        //Eliminar datos antes de insrrtar nuevamente la lista de medios de pago
        public string EliminarPagosFactura(string nro_trans)
        {
            try
            {
                string respuesta = guardarPago.EliminarDetallePagosFactura(nro_trans);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "EliminarPagosFactura", e.ToString(), DateTime.Today, "DLT");
                return "No se pudo completar la acción." + "EliminarPagosFactura." + " Por favor notificar al administrador.";
            }
        }
        //Eliminar datos
        public string EliminarPagosSaldos(string nro_trans, string cod_fpago, string nro_docum)
        {
            try
            {
                string respuesta = guardarPago.EliminarDetallePagosLinea(nro_trans, cod_fpago, nro_docum);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "EliminarPagosSaldos", e.ToString(), DateTime.Today, "DLT");
                return "No se pudo completar la acción." + "EliminarPagosSaldos." + " Por favor notificar al administrador.";
            }
        }
        //Eliminar datos antes de insrrtar nuevamente la lista de medios de pago
        public string EliminarTemporal(string nro_trans, string cod_emp, string cod_fpago)
        {
            try
            {
                string respuesta = guardarPago.EliminarTemporal(nro_trans, cod_emp, cod_fpago);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "EliminarTemporal", e.ToString(), DateTime.Today, "DLT");
                return "No se pudo completar la acción." + "EliminarTemporal." + " Por favor notificar al administrador.";
            }
        }
        //Lista diferencia de saldos luego de pagar

        public List<ModeloDiferenciaPagos> BuscarDiferenciaSaldos(string usuario, string cod_emp, string nro_trans)
        {
            try
            {
                List<ModeloDiferenciaPagos> lista = new List<ModeloDiferenciaPagos>();
                lista = consultaMediosPago.Diferencia(usuario, cod_emp, nro_trans);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "BuscarDiferenciaSaldos", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }

        //vuelto de pgs
        public List<modeloFacturasPagos> ObtenerVueltoPgs(string nro_trans)
        {
            try
            {
                List<modeloFacturasPagos> lista = new List<modeloFacturasPagos>();
                lista = guardarPago.BuscarVueltoPgs(nro_trans);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ObtenerVueltoPgs", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

        //Trae todos las formas de pagos guardadas x transaccion
        public List<modeloFacturasPagos> ConsultaTablaPgs(string usuario, string cod_emp, string nro_trans)
        {
            try
            {
                List<modeloFacturasPagos> lista = new List<modeloFacturasPagos>();
                lista = consultaMediosPago.ConsultaTablaPgs(usuario, cod_emp, nro_trans);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaTablaPgs", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
    }
}
