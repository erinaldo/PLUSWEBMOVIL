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
  public  class ConsultawmspcfacturasWMimpuRest
    {

        ImpuestosRest consultaImpuesto = new ImpuestosRest();
        public List<modelowmspcfacturasWMimpuRest> BuscarImpuestoRest(string usuario, string cod_emp, string nro_trans, string  impuesto)
        {
            List<modelowmspcfacturasWMimpuRest> lista = new List<modelowmspcfacturasWMimpuRest> ();
            lista = consultaImpuesto.ListaImpuestosRest(usuario, cod_emp, nro_trans, impuesto);           
            return lista;
        }
    }
}
