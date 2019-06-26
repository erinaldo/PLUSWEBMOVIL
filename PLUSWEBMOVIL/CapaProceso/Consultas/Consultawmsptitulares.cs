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
    public class Consultawmsptitulares
    {
        Documento documento = new Documento();
        modelowmspctitulares modelotitulares = new modelowmspctitulares();

        public List<modelowmspctitulares> ConsultaTitulares(string Ven__usuario, string Ven__cod_emp, string Ven__cod_tipotit, string Ven__cod_tit, string Ven__cod_dgi, string Ven__fono)
        {
            List<modelowmspctitulares> lista = new List<modelowmspctitulares>();
            lista = documento.ListaBuscaTitulares(Ven__usuario, Ven__cod_emp, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi, Ven__fono);            
            return lista;
        }

    
    }
}
