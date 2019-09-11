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
   public  class ConsultaEmpresa
    {
        Empresa consultaEmpresa = new Empresa();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<modelowmspcempresas> BuscartaEmpresa(string usuario, string cod_emp)
        {
            try
            {
                List<modelowmspcempresas> lista = new List<modelowmspcempresas>();
                lista = consultaEmpresa.BuscarEmpresa(usuario, cod_emp);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "ConsultaEmpresa.cs", "BuscarEmpresa", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }

    }
}
