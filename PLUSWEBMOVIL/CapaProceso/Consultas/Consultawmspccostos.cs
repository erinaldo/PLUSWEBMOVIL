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
   public  class Consultawmspccostos
    {
        CCostos ccostos = new CCostos();
        modelowmspcccostos moedlocostos = new modelowmspcccostos();
        public List<modelowmspcccostos> ConsultaCCostos(string CC__usuario, string CC__cod_emp, string CC__cod_dpto)
        {
            List<modelowmspcccostos> lista = new List<modelowmspcccostos>();
            lista = ccostos.ListaBuscaCCostos(CC__usuario,  CC__cod_emp, CC__cod_dpto);
            
            return lista;
        }
    }
}
