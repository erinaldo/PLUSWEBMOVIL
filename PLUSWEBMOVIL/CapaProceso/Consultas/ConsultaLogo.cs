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
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<modelowmspclogo> BuscartaLogo(string cod_emp, string usuario)
        {
            try
            {
                List<modelowmspclogo> lista = new List<modelowmspclogo>();
                lista = consultaLogoSql.ConsultaLogo(cod_emp, usuario);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "ConsultaLogo.cs", "BuscartaLogo", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }

        public List<modelowmusuario> BuscarUsuario(string usuario)
        {
            try
            {
                List<modelowmusuario> lista = new List<modelowmusuario>();
                lista = consultaLogoSql.CosnualtaUsuario(usuario);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "ConsultaLogo.cs", "BuscarUsuario", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
    }
}
