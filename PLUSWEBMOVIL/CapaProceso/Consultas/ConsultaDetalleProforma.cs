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
   public  class ConsultaDetalleProforma
    {
        DetalleProformaFac consultaProformasDetalle = new DetalleProformaFac();
        public List<modeloDetalleProforma> BuscarProformasDetalle(string nro_trans)
        {
            List<modeloDetalleProforma> lista = new List<modeloDetalleProforma>();
            lista = consultaProformasDetalle.ListaProformasDetalle(nro_trans);           
            return lista;
        }
    }
}
