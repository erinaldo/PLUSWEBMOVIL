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
    public class Consultawmspcformaspag
    {
        Fpagos fpagos = new Fpagos();
        modelowmspcfpago modelofpago = new modelowmspcfpago();
        
        public List<modelowmspcfpago> ConsultaFpagos(string FP__usuario, string FP__cod_emp, string FP__cod_fpago)
        {
            List<modelowmspcfpago> lista = new List<modelowmspcfpago>();
            lista = fpagos.ListaBuscaFPago(FP__usuario,  FP__cod_emp, FP__cod_fpago);            
            return lista;
        }
    }
}
