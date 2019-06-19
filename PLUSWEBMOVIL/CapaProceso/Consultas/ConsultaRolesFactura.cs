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
        //Rol consulta cargar opciones administracion
        public List<modeloRolesFacturacion> BuscarCargarAdmin(string usuario)
        {
            List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
            lista = consultaRolesFacturacion.RespuestaRolAdministracion(usuario);
            return lista;
        }

        //Rol consulta cargar opciones tablero
        public List<modeloRolesFacturacion> BuscarCargarTablero(string usuario)
        {
            List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
            lista = consultaRolesFacturacion.RespuestaRolTablero(usuario);
            return lista;
        }
        //Rol consulta opcion facturacion general
        public List<modeloRolesFacturacion> BuscarAccesoFactura(string usuario)
        {
            List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
            lista = consultaRolesFacturacion.RespuestaAccesoFacturacion(usuario);
            return lista;
        }

        //Rol nuevo
        public List<modeloRolesFacturacion> BuscarRolNuevo(string usuario)
        {
            List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
            lista = consultaRolesFacturacion.RespuestaRolNuevo(usuario);
            return lista;
        }
        //Rol editar
        public List<modeloRolesFacturacion> BuscarRolEditar(string usuario)
        {
            List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
            lista = consultaRolesFacturacion.RespuestaRolEditar(usuario);
            return lista;
        }
        //Rol imprimir
        public List<modeloRolesFacturacion> BuscarRolPrint(string usuario)
        {
            List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
            lista = consultaRolesFacturacion.RespuestaRolPrint(usuario);
            return lista;
        }
        //Rol eliminar
        public List<modeloRolesFacturacion> BuscarRolEliminar(string usuario)
        {
            List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
            lista = consultaRolesFacturacion.RespuestaRolEliminar(usuario);
            return lista;
        }
        //Rol Reactivar
        public List<modeloRolesFacturacion> BuscarRolReactivar(string usuario)
        {
            List<modeloRolesFacturacion> lista = new List<modeloRolesFacturacion>();
            lista = consultaRolesFacturacion.RespuestaRolReactivar(usuario);
            return lista;
        }
    }
}
