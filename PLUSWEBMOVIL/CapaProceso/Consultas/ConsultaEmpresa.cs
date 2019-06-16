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
        public List<modelowmspcempresas> BuscartaEmpresa(string usuario, string cod_emp)
        {
            List<modelowmspcempresas> lista = new List<modelowmspcempresas>();
            lista = consultaEmpresa.BuscarEmpresa(usuario, cod_emp);            
            return lista;
        }

    }
}
