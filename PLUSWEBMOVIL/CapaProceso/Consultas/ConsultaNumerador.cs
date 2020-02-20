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
   public  class ConsultaNumerador
    {
        Numeradores numeradores = new Numeradores();
        modelonumerador modelonum = new modelonumerador();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public string SPNumeradores(string numerador)
        {
            try
            {
                string Mnumerador ="";

                Mnumerador = numeradores.SPNumerador(numerador);

                return Mnumerador;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "ConsultaNumerador.cs", "SPNumeradores", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }
        //
        public modelonumerador  ConsultaNumeradores(string numerador)
        {
            try
            {
                modelonumerador Mnumerador =new modelonumerador();

                Mnumerador = numeradores.ConsultaNroTransaccion(numerador);

                return Mnumerador;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "ConsultaNumerador.cs", "ConsultaNumeradores", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
        public string NroTrans(string numerador)
        {
            try
            {
                string Mnumerador =null;

                Mnumerador = numeradores.NroTransaccion(numerador);

                return Mnumerador;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "ConsultaNumerador.cs", "NroTrans", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
    }
}
