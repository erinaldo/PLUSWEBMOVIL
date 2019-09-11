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
    public class ConusltaDetalleCajaEfectivo
    {
        EfectivoCaja fcaja = new EfectivoCaja();
        modeloEfectivoCaja modeloFCaja = new modeloEfectivoCaja();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo ="ConusltaDetalleCajaEfectivo.cs";


        //Insertar ciereCaja en wmt_cierre_resumencaja
        public string InsertarEfectivoCaja(modeloEfectivoCaja EfectivoCaja)
        {
            try
            {
                string respuesta = fcaja.InsertarEfectivoCaja(EfectivoCaja);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(EfectivoCaja.cod_emp, metodo, "InsertarEfectivoCaja", e.ToString(), DateTime.Today, EfectivoCaja.usuario_mod);
                return "No se pudo completar la acción." + "InsertarEfectivoCajaActualizarDatTitular." + " Por favor notificar al administrador.";
            }
        }

        //Actualizar ciereCaja en wmt_cierre_resumencaja
        public string ActualizarEfectivoCaja(modeloEfectivoCaja EfectivoCaja)
        {
            try
            {
                string respuesta = fcaja.ActualizarEfectivoCaja(EfectivoCaja);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(EfectivoCaja.cod_emp, metodo, "ActualizarEfectivoCaja", e.ToString(), DateTime.Today, EfectivoCaja.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarEfectivoCaja." + " Por favor notificar al administrador.";
            }
        }

        //Eliminar ciereCaja en wmt_cierre_resumencaja
        public string EliminarEfectivoCaja(modeloEfectivoCaja EfectivoCaja)
        {
            try
            {
                string respuesta = fcaja.EliminarEfectivoCaja(EfectivoCaja);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(EfectivoCaja.cod_emp, metodo, "ActualizarEfectivoCaja", e.ToString(), DateTime.Today, EfectivoCaja.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarEfectivoCaja." + " Por favor notificar al administrador.";
            }
        }
    }
}
