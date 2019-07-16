using CapaDatos.Modelos.ModelosNC;
using CapaDatos.Sql.SqlNC;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
   public class ConsultaSaldosFacturas
    {
        
        SaldosFacturas consultaSaldoa = new SaldosFacturas();
        public List<modeloSaldosFacturas> BuscartaFacturaSaldos( string Ccf_usuario, string Ccf_cod_emp, string Ccf_tipo1, string Ccf_tipo2)
        {
            List<modeloSaldosFacturas> lista = new List<modeloSaldosFacturas>();
            lista = consultaSaldoa.ConsultaFacturasSaldos(Ccf_usuario, Ccf_cod_emp, Ccf_tipo1, Ccf_tipo2);
            return lista;
        }
    }
}
