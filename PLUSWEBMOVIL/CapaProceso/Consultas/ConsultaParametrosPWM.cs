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
    public class ConsultaParametrosPWM
    {
        ParametrosPW parametrosPWM = new ParametrosPW();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "ConsultaParametrosPWM.cs";

        public List<modeloParametrosPWM> ListaParametrosPWM(string cod_emp, string usuario)
        {
            try
            {
                List<modeloParametrosPWM> lista = new List<modeloParametrosPWM>();
                lista = parametrosPWM.ListaParametrosPWM(cod_emp, usuario);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaParamtrosPWM", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }


        //Insertar wmm_parametros
        public string InsertarParametro(string cod_emp, string usuario, string conexion_erp)
        {
            try
            {
                string respuesta = parametrosPWM.InsertarParametros(cod_emp, usuario, conexion_erp);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "InsertarParametro", e.ToString(), DateTime.Today, usuario);
                return "No se pudo completar la acción." + "InsertarParametro." + " Por favor notificar al administrador.";
            }
        }

        //Actualizar wmm_parametros
        public string ActualizarParametro(string cod_emp, string usuario, string conexion_erp)
        {
            try
            {
                string respuesta = parametrosPWM.ActualizarParametros(cod_emp, usuario, conexion_erp);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ActualizarParametro", e.ToString(), DateTime.Today, usuario);
                return "No se pudo completar la acción." + "ActualizarParametro." + " Por favor notificar al administrador.";
            }
        }
        //buscar unico
        public string BuscarUnico(string cod_emp, string usuario)
        {
            try
            {
                string respuesta = parametrosPWM.BuscarUnico(cod_emp, usuario);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "BuscarUnico", e.ToString(), DateTime.Today, usuario);
                return "No se pudo completar la acción." + "BuscarUnico." + " Por favor notificar al administrador.";
            }
        }

    }
}
