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
   public  class Consultawmspcmonedas
    {
        CMonedas cmonedas = new CMonedas();
        FormatoCantidades formatoCant = new FormatoCantidades();
        modelowmspcmonedas modelomonedas = new modelowmspcmonedas();
        modeloDenominacionesMoneda modeloDenominaciones = new modeloDenominacionesMoneda();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "Consultawmspcmonedas";
        public List<modelowmspcmonedas> ConsultaCMonedas(string MonB__usuario, string MonB__cod_emp, string MonB__moneda)
        {
            try
            {
                List<modelowmspcmonedas> lista = new List<modelowmspcmonedas>();
                lista = cmonedas.ListaBuscaCMonedas(MonB__usuario, MonB__cod_emp, MonB__moneda);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(MonB__cod_emp, metodo, "ListaBuscaCMonedas", e.ToString(), DateTime.Today, MonB__usuario);
                return null;
            }
        }
        //Consulta lista de denominaciones por cod_moneda  wmm_denominacionM x empresa
        public List<modeloDenominacionesMoneda> ConsultaDenominacionesEmpresa(string cod_moneda)
        {
            try
            {
                List<modeloDenominacionesMoneda> lista = new List<modeloDenominacionesMoneda>();
                lista = cmonedas.ListaDenominacionEmpresa(cod_moneda);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "ConsultaDenominacionesEmpresa", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

        //Consulta lista de denominaciones por cod_moneda  wmm_denominacionM
        public List<modeloDenominacionesMoneda> ConsultaDenominacionesMonedas()
        {
            try
            {
                List<modeloDenominacionesMoneda> lista = new List<modeloDenominacionesMoneda>();
                lista = cmonedas.ListaDenominacionMoneda();
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "ConsultaDenominacionesMonedas", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

        //Consulta lista de denominaciones por cod_moneda  wmm_denominacionM para actualizar
        public List<modeloDenominacionesMoneda> ConsultaDenominacionesUDP(string id)
        {
            try
            {
                List<modeloDenominacionesMoneda> lista = new List<modeloDenominacionesMoneda>();
                lista = cmonedas.ListaDenominacionUDP(id);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "ConsultaDenominacionesUDP", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
        //Consulta unico denominaciones en  wmm_denominacionM
        public List<modeloDenominacionesMoneda> ConsultaUnicoDenominacion(string cod_moneda, string nombre, string valor)
        {
            try
            {
                List<modeloDenominacionesMoneda> lista = new List<modeloDenominacionesMoneda>();
                lista = cmonedas.UnicoDenominacion(cod_moneda, nombre, valor);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "ConsultaUnicoDenominacion", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
        //Insertar denominaciones en wmm_denominacionM
        public string InsertarDenominacion(modeloDenominacionesMoneda ModeloDenominacion)
        {
            try
            {
                string respuesta = cmonedas.InsertarDenominacion(ModeloDenominacion);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "InsertarDenominacion", e.ToString(), DateTime.Today, ModeloDenominacion.usuario_mod);
                return "No se pudo completar la acción." + "InsertarDenominacion." + " Por favor notificar al administrador.";
            }
        }

        //Actualizar denominaciones en wmm_denominacionM
        public string ActualizarDenominacion(modeloDenominacionesMoneda ModeloDenominacion)
        {
            try
            {
                string respuesta = cmonedas.ActualizarDenominacion(ModeloDenominacion);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "ActualizarDenominacion", e.ToString(), DateTime.Today, ModeloDenominacion.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarDenominacion." + " Por favor notificar al administrador.";
            }
        }

        //eliminar denominaciones en wmm_denominacionM
        public string EliminarDenominacion(modeloDenominacionesMoneda ModeloDenominacion)
        {
            try
            {
                string respuesta = cmonedas.EliminarDenominacion(ModeloDenominacion);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "EliminarDenominacion", e.ToString(), DateTime.Today, ModeloDenominacion.usuario_mod);
                return "No se pudo completar la acción." + "EliminarDenominacion." + " Por favor notificar al administrador.";
            }
        }
        //Redondear numeros necesariamente debe ir numero a cambiar en decimal
        public decimal RedondearNumero(string nro_decimales, decimal numero)
        {
            decimal respuesta = formatoCant.RedondearNumero(nro_decimales, numero);
            return respuesta;
        }

        //Formato 
        public string FormatorNumero(string nro_decimales, decimal numero)
        {
            string respuesta = formatoCant.FormatoNumero(nro_decimales, numero);
            return respuesta;
        }
    }
}
