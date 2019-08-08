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
        //Buscar todo los medios de pago
        public List<modeloMediosPago> BuscarMediosPago(string cod_emp)
        {
            List<modeloMediosPago> lista = new List<modeloMediosPago>();
            lista = consultaMediosPago.ListaMediosPago(cod_emp);
            return lista;
        }

        //Buscar cod_tit 
        public List<ModelosPagosTitular> BuscartitularPagos(string usuario, string cod_emp, string nro_trans)
        {
            List<ModelosPagosTitular> lista = new List<ModelosPagosTitular>();
            lista = consultaMediosPago.TitularPago(usuario, cod_emp, nro_trans);
            return lista;
        }
        //Recupera datos de medio de pago para insertar en tabla wmt_facturas_pgs
        public List<ModeloTipoPagoTem> BuscarMediosPagoTemporal(string usuario,string cod_emp, string nro_trans)
        {
            List<ModeloTipoPagoTem> lista = new List<ModeloTipoPagoTem>();
            lista = consultaMediosPago.BuscarPagosTemporal(usuario,cod_emp,nro_trans);
            return lista;
        }
        //Insertar Pagos de la factura  Insertar pagos en wmt_facturas_pgs
        public string InsertarPagosFactura(modeloFacturasPagos facturasPagos)
        {
            string respuesta = guardarPago.InsertarFacturaPagos(facturasPagos);
            return respuesta;
        }

        //Insertar en tabla temporal el wmt_facturas_pgstmp cada codigo de pago
        public string InsertarTipoPago(modeloFacturasPagos TipoPagos)
        {
            string respuesta = guardarPago.InsertarTiposPagos(TipoPagos);
            return respuesta;
        }

        //Eliminar datos antes de insrrtar nuevamente la lista de medios de pago
        public string EliminarPagosFactura(string nro_trans)
        {
            string respuesta = guardarPago.EliminarDetallePagosFactura(nro_trans);
            return respuesta;
        }
        //Eliminar datos
        public string EliminarPagosSaldos(string nro_trans, string cod_fpago, string nro_docum)
        {
            string respuesta = guardarPago.EliminarDetallePagosLinea(nro_trans,  cod_fpago, nro_docum);
            return respuesta;
        }
        //Eliminar datos antes de insrrtar nuevamente la lista de medios de pago
        public string EliminarTemporal(string nro_trans, string cod_emp, string cod_fpago)
        {
            string respuesta = guardarPago.EliminarTemporal(nro_trans, cod_emp, cod_fpago);
            return respuesta;
        }
        //Lista diferencia de saldos luego de pagar

        public List<ModeloDiferenciaPagos> BuscarDiferenciaSaldos(string usuario, string cod_emp, string nro_trans)
        {
            List<ModeloDiferenciaPagos> lista = new List<ModeloDiferenciaPagos>();
            lista = consultaMediosPago.Diferencia(usuario, cod_emp, nro_trans);
            return lista;
        }

        //vuelto de pgs
        public List<modeloFacturasPagos> ObtenerVueltoPgs(string nro_trans)
        {
            List<modeloFacturasPagos> lista = new List<modeloFacturasPagos>();
            lista = guardarPago.BuscarVueltoPgs(nro_trans);
            return lista;
        }

        //Trae todos las formas de pagos guardadas x transaccion
        public List<modeloFacturasPagos> ConsultaTablaPgs(string usuario, string cod_emp, string nro_trans)
        {
            List<modeloFacturasPagos> lista = new List<modeloFacturasPagos>();
            lista = consultaMediosPago.ConsultaTablaPgs(usuario, cod_emp, nro_trans);
            return lista;
        }
    }
}
