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
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "Consultawmspccostos.cs";
        public List<modelowmspcccostos> ConsultaCCostos(string CC__usuario, string CC__cod_emp, string CC__cod_dpto)
        {
            try
            {
                List<modelowmspcccostos> lista = new List<modelowmspcccostos>();
                lista = ccostos.ListaBuscaCCostos(CC__usuario, CC__cod_emp, CC__cod_dpto);

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(CC__cod_emp,metodo , "ConsultaCCostos", e.ToString(), DateTime.Now, CC__usuario);
                return null;
            }
        }

        public List<ModeloCtasContables> ConsultaCContable(string CC__usuario, string CC__cod_emp, string libro)
        {
            try
            {
                List<ModeloCtasContables> lista = new List<ModeloCtasContables>();
                lista = ccostos.ListaBuscaCContable(CC__usuario, CC__cod_emp, libro);

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(CC__cod_emp, metodo, "ConsultaCContable", e.ToString(), DateTime.Now, CC__usuario);
                return null;
            }
        }
    }
}
