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
   public  class Consultawmspcmonedas
    {
        CMonedas cmonedas = new CMonedas();
        modelowmspcmonedas modelomonedas = new modelowmspcmonedas();
        public List<modelowmspcmonedas> ConsultaCMonedas(string MonB__usuario, string MonB__cod_emp, string MonB__moneda)
        {
            List<modelowmspcmonedas> lista = new List<modelowmspcmonedas>();
            lista = cmonedas.ListaBuscaCMonedas(MonB__usuario, MonB__cod_emp, MonB__moneda);            
            return lista;
        }
    }
}
