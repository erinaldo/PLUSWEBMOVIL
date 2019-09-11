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
    public class Consultaparamcomercial
    {
        ParametroComercial consultaComercial = new ParametroComercial();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<modeloparametrocomercial> BuscartaComercial(string cod_emp)
        {
            try
            {
                List<modeloparametrocomercial> lista = new List<modeloparametrocomercial>();
                lista = consultaComercial.ConsultaComercial(cod_emp);

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "Consultaparametrocomercial.cs", " BuscartaComercial", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
    }
}