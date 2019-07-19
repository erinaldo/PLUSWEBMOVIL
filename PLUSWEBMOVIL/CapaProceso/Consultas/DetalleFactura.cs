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
       

        public string InsertarDetalleFactura(ModeloDetalleFactura detalleFactura)
        {
            string respuesta = detalleFacturas.InsertarDetalle(detalleFactura);
            return respuesta;
        }
        /*Detalle NC por anulacion afectacion total*/
        public string InsertarDetallNCFina(ModeloDetalleFactura detalleFactura)
        {
            string respuesta = detalleFacturas.InsertarDetalleNCFinanciera(detalleFactura);
            return respuesta;
        }
    }
}
