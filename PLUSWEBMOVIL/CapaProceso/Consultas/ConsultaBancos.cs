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
    public class ConsultaBancos
    {
        CuentasBanco consultaBanco = new CuentasBanco();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<modelobancos> BuscartaBancos(string usuario, string cod_emp, string banco, string tipo, string cuenta, string imprime)
        {
            try
            {
                List<modelobancos> lista = new List<modelobancos>();
                lista = consultaBanco.ConsultaBancos(usuario, cod_emp, banco, tipo, cuenta, imprime);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "ConsultaBancos.cs", "BuscartaBancos", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
    }
}
