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
   public  class ConsultaCierecaja
    {
        CierreCaja ccaja = new CierreCaja();
        modeloCierreCaja modeloCCaja = new modeloCierreCaja();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "ConsultaCierecaja";

        //Consulta cierre caja por fecha en wmt_cierre_resumencaja
        public Int64 BuscarCCajaFechaSecuencial(string fecha , string cod_emp)
        {          
            
            return ccaja.BuscarCierreDiaSecuencial(fecha, cod_emp);
        }
        //ultimo secuencial
        public Int64 UltimoCCajaFechaSecuencial(string fecha, string cod_emp)
        {

            return ccaja.UltimoCierreDiaSecuencial(fecha, cod_emp);
        }

        //Consulta lista de cierre caja por fecha en wmt_cierre_resumencaja
        public List<modeloCierreCaja> ConsultaCCajaFecha(string fecha, Int64 secuencial, string codigo, string cod_emp)
        {
            try
            {
                List<modeloCierreCaja> lista = new List<modeloCierreCaja>();
                lista = ccaja.ListaCierreCF(fecha, secuencial, codigo, cod_emp);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaRemisionDetalle", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

        //Insertar ciereCaja en wmt_cierre_resumencaja
        public string InsertarCierreCaja(modeloCierreCaja ModeloCCaja)
        {
            try
            {
                string respuesta = ccaja.InsertarCierreCaja(ModeloCCaja);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ModeloCCaja.cod_emp, metodo, "InsertarCierreCaja", e.ToString(), DateTime.Today, ModeloCCaja.usuario_mod);
                return "No se pudo completar la acción." + "InsertarCierreCaja." + " Por favor notificar al administrador.";
            }
        }

        //Actualizar ciereCaja en wmt_cierre_resumencaja
        public string ActualizarCierreCaja(modeloCierreCaja ModeloCCaja)
        {
            try
            {
                string respuesta = ccaja.ActualizarCierreCaja(ModeloCCaja);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ModeloCCaja.cod_emp, metodo, "ActualizarCierreCaja", e.ToString(), DateTime.Today, ModeloCCaja.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarCierreCaja." + " Por favor notificar al administrador.";
            }
        }

        //Eliminar ciereCaja en wmt_cierre_resumencaja
        public string EliminarCierreCaja(modeloCierreCaja ModeloCCaja)
        {
            try
            {
                string respuesta = ccaja.EliminarCierreCaja(ModeloCCaja);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ModeloCCaja.cod_emp, metodo, "EliminarCierreCajaa", e.ToString(), DateTime.Today, ModeloCCaja.usuario_mod);
                return "No se pudo completar la acción." + "EliminarCierreCaja." + " Por favor notificar al administrador.";
            }
        }
    }
}
