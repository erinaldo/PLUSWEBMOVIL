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
        //Consulta de cajas para cierre , erp, y pwm lista
        public List<modeloCajasCierre> ConsultaCajasCierre(string usuario, string cod_emp, string banco, string tipo)
        {
            try
            {
                List<modeloCajasCierre> lista = new List<modeloCajasCierre>();
                string tipo_cuenta;
                tipo_cuenta = ccaja.ConsultaTipoCuenta(usuario, cod_emp);
                lista = ccaja.ConsultaCajasCierre(usuario, cod_emp,"", tipo_cuenta);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaCajasCierre", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }

        //consultar nombre de la caja en erp
        public List<modeloCajasCierre> ConsultadatosCaja(string usuario, string cod_emp, string banco, string tipo, string nro_caja)
        {
            try
            {
                List<modeloCajasCierre> lista = new List<modeloCajasCierre>();
                string tipo_cuenta;
                tipo_cuenta = ccaja.ConsultaTipoCuenta(usuario, cod_emp);
                lista = ccaja.ConsultaDatosCaja(usuario, cod_emp,banco, tipo_cuenta, nro_caja);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultadatosCaja", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }

        //Consulta lista de cierre caja por fecha en wmt_cierre_resumencaja, fv, nv
        public List<modeloPagoProveedores> ListaFacturasNV(string usuario, string cod_emp, string dia, string mes, string anio, string tipo1, string tipo2)
        {
            try
            {
                List<modeloPagoProveedores> lista = new List<modeloPagoProveedores>();
                lista = ccaja.ListaFcturasNV(usuario, cod_emp, dia, mes, anio, tipo1, tipo2);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaFacturasNV", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }

        public List<modeloPagoProveedores> TotalPagoProveedores(string usuario, string cod_emp, string dia, string mes, string anio, string tipo1, string tipo2)
        {
            try
            {
                List<modeloPagoProveedores> lista = new List<modeloPagoProveedores>();
                lista = ccaja.TotalPagoProveedores(usuario, cod_emp, dia, mes, anio, tipo1, tipo2);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "TotalPagoProveedores", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }

        //Consulta lista de cierre caja por fecha en wmt_cierre_resumencaja
        public List<modeloPagoProveedores> ListaPagoProveedores(string usuario, string cod_emp, string dia, string mes, string anio, string tipo1, string tipo2)
        {
            try
            {
                List<modeloPagoProveedores> lista = new List<modeloPagoProveedores>();
                lista = ccaja.ListaPagoProveedores(usuario,  cod_emp,  dia,  mes, anio,tipo1,  tipo2);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaPagoProveedores", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }



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
        public List<modeloCierreCaja> ConsultaCCajaFecha(string fecha, Int64 secuencial, string codigo, string cod_emp, string nro_caja)
        {
            try
            {
                List<modeloCierreCaja> lista = new List<modeloCierreCaja>();
                lista = ccaja.ListaCierreCF(fecha, secuencial, codigo, cod_emp, nro_caja);
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
