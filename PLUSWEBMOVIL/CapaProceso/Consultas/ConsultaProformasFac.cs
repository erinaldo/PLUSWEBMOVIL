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
   public  class ConsultaProformasFac
    {
        ConsultaProformas consultaProformas = new ConsultaProformas();


        //Consultar unica cabecera
        public List<modelowmtproformascab> BuscarProformasCab(string nro_trans)
        {
            List<modelowmtproformascab> lista = new List<modelowmtproformascab>();
            lista = consultaProformas.ConsultaProformasFactura(nro_trans);            
            return lista;
        }
        public List<modelowmtproformascab> BuscarProformas(string cod_cliente, string estado, string tipo)
        {
            List<modelowmtproformascab> lista = new List<modelowmtproformascab>();
            lista = consultaProformas.ListaProformasFactura( cod_cliente, estado, tipo);
           
            return lista;
        }
    }
}
