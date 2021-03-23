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
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo= "ConsultaDetalleProforma";

        public string BuscarProformasVendedor(string nro_trans, string empresa, string usuario)
        {
            try
            {
                
                string vendedor = consultaProformasDetalle.VendedorProforma(nro_trans, empresa, usuario);
                return vendedor;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "BuscarProformasVendedor", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        public List<modeloDetalleProforma> BuscarProformasDetalle(string nro_trans)
        {
            try
            {
                List<modeloDetalleProforma> lista = new List<modeloDetalleProforma>();
                lista = consultaProformasDetalle.ListaProformasDetalle(nro_trans);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "BuscarProformasDetalle", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }
    }
}
