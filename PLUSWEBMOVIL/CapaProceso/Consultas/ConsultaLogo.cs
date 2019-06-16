using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
    public class ConsultaLogo
    {
        ConsultaLogoSql consultaLogoSql = new ConsultaLogoSql();
        public List<modelowmspclogo> BuscartaLogo(string cod_emp, string usuario)
        {
            List<modelowmspclogo> lista = new List<modelowmspclogo>();
            lista = consultaLogoSql.ConsultaLogo(cod_emp, usuario);            
            return lista;
        }

        public List<modelowmusuario> BuscarUsuario(string usuario)
        {
            List<modelowmusuario> lista = new List<modelowmusuario>();
            lista = consultaLogoSql.CosnualtaUsuario(usuario);            
            return lista;
        }
    }
}
