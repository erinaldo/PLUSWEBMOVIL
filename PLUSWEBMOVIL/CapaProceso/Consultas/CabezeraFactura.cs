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

        //Insertar cabecera NC Financiera
        public string InsertarCabezeraNotaCredito(modelocabecerafactura cabezeraFactura)
        {
            string respuesta = factura.InsertarCabeceraNCFinan(cabezeraFactura);
            return respuesta;
        }
        //Insertar cabecera de la factura
        public string InsertarCabezeraFactura(modelocabecerafactura cabezeraFactura)
        {
            string respuesta = factura.InsertarCabecera(cabezeraFactura);
            return respuesta;
        }

        //Actualizar estado factura
        public string ActualizarEstadoFactura(string nro_trans, string estado)
        {
            string respuesta = factura.ActualizarEstadoFactura(nro_trans, estado);
            return respuesta;
        }

        public string EliminarCabDetFactura(string nro_trans)
        {
            string respuesta = factura.EliminarCabDetFactura(nro_trans);
            return respuesta;
        }
    }
}