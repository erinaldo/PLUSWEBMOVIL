﻿using CapaDatos.Modelos;
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
        //Rol Reactivar factura vta, vtae
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

        //Rol Reactivar factura pos, pose
        public List<modeloRolesFacturacion> BuscarRolReactivarPOS(string usuario)
        {
            try
            {
                List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                lista = consultaRolesFacturacion.RespuestaRolReactivarPOS(usuario);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "BuscarRolReactivarPOS", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        //.............nota debito
        //Rol nuevo
        public List<modeloRolesFacturacion> BuscarRolNuevoND(string usuario)
        {
            try
            {
                List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                lista = consultaRolesFacturacion.NDebitoRolNuevo(usuario);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "BuscarRolNuevoND", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        //Rol editar
        public List<modeloRolesFacturacion> BuscarRolEditarND(string usuario)
        {
            try
            {
                List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                lista = consultaRolesFacturacion.NDebitoRolEditar(usuario);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "BuscarRolEditarND", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        //Rol Acceso
        public List<modeloRolesFacturacion> BuscarRolAccesoND(string usuario)
        {
            try
            {
                List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                lista = consultaRolesFacturacion.NDebitoAcceso(usuario);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "BuscarRolPrint", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
        //Rol eliminar
        public List<modeloRolesFacturacion> BuscarRolEliminarND(string usuario)
        {
            try
            {
                List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
                lista = consultaRolesFacturacion.NDebitoRolEliminar(usuario);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "BuscarRolEliminar", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
    }
}
