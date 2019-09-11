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
    public class ConsultaDetalleRemision
    {
        DetalleProformaFac consultaProformasDetalle = new DetalleProformaFac();
        DetalleRemision consRemFac = new DetalleRemision();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<modeloDetalleRemision> BuscarRemisionDetalle(string nro_trans)
        {
            try
            {
                List<modeloDetalleRemision> lista = new List<modeloDetalleRemision>();
                lista = consRemFac.ListaRemisionDetalle(nro_trans);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, "ConsultaDetalleRemision.cs", "BuscarRemisionDetalle", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

    }
}
