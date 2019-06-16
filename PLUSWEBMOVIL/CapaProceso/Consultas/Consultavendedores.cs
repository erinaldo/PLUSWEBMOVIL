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
    public class Consultavendedores
    {
        Vendedores vendedores = new Vendedores();
        modelovendedores modevendedores = new modelovendedores();
        
        public List<modelovendedores> ConsultaVendedores(string Vend__usuario, string Vend__cod_emp, string Vend__cod_tipotit, string Vend__cod_tit)
        {
            List<modelovendedores> lista = new List<modelovendedores>();
            lista = vendedores.ListaBuscaVendedores(Vend__usuario, Vend__cod_emp, Vend__cod_tipotit, Vend__cod_tit);

            
            return lista;
        }
    }
}
