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
    public class ConsultaRolesFactura
    {
        
        RolesUserFacturacion consultaRolesFacturacion = new RolesUserFacturacion();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "ConsultaRolesFactura";
        //Rol consulta cargar opciones administracion
        public List<modeloRolesFacturacion> BuscarCargarAdmin(string usuario)
        {
            try
            {
                List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                lista = consultaRolesFacturacion.RespuestaRolAdministracion(usuario);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "BuscarCargarAdmin", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }

        //Rol consulta cargar opciones tablero
        public List<modeloRolesFacturacion> BuscarCargarTablero(string usuario)
        {
            try
            {
                List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                lista = consultaRolesFacturacion.RespuestaRolTablero(usuario);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "BuscarCargarTablero", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
        //Rol consulta opcion facturacion general
        public List<modeloRolesFacturacion> BuscarAccesoFactura(string usuario)
        {
            try
            {
                List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                lista = consultaRolesFacturacion.RespuestaAccesoFacturacion(usuario);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "BuscarAccesoFactura", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }

        //Rol nuevo
        public List<modeloRolesFacturacion> BuscarRolNuevo(string usuario)
        {
            try
            {
                List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                lista = consultaRolesFacturacion.RespuestaRolNuevo(usuario);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "BuscarRolNuevo", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
        //Rol editar
        public List<modeloRolesFacturacion> BuscarRolEditar(string usuario)
        {
            try
            {
                List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                lista = consultaRolesFacturacion.RespuestaRolEditar(usuario);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "BuscarRolEditar", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
        //Rol imprimir
        public List<modeloRolesFacturacion> BuscarRolPrint(string usuario)
        {
            try
            {
                List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                lista = consultaRolesFacturacion.RespuestaRolPrint(usuario);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "BuscarRolPrint", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
        //Rol eliminar
        public List<modeloRolesFacturacion> BuscarRolEliminar(string usuario)
        {
            try
            {
                List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                lista = consultaRolesFacturacion.RespuestaRolEliminar(usuario);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "BuscarRolEliminar", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
        //Rol Reactivar
        public List<modeloRolesFacturacion> BuscarRolReactivar(string usuario)
        {
            try
            {
                List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                lista = consultaRolesFacturacion.RespuestaRolReactivar(usuario);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "BuscarRolReactivar", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
    }
}
