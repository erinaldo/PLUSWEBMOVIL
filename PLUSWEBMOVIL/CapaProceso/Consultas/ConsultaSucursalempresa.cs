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
    public class ConsultaSucursalempresa
    {
        //Insertar sucursal empresa
        SucursalEmpresa guardarSucursal = new SucursalEmpresa();
        modeloSucuralempresa Modelosucursal = new modeloSucuralempresa();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "ConsultaSucursalempresa.cs";
        public string InsertarSucursalEmpresa(modeloSucuralempresa ModelosucEmpresa)
        {
            try
            {
                string respuesta = guardarSucursal.InsertarSucursalEmpresa(ModelosucEmpresa);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ModelosucEmpresa.cod_emp, metodo, "InsertarSucursalEmpresa", e.ToString(), DateTime.Now, ModelosucEmpresa.usuario_mod);
                return "No se pudo completar la acción." + "InsertarSucursalEmpresa." + " Por favor notificar al administrador.";
            }
        }

        //Actualizar sucursal empresa 
        SucursalEmpresa updateSucursal = new SucursalEmpresa();
        modeloSucuralempresa ModelosucursalUPDATE = new modeloSucuralempresa();
        public string ActualizarSucursalEmpresa(modeloSucuralempresa ModelosucEmpresa)
        {
            try
            {
                string respuesta = updateSucursal.ActualizarSucursalEmpresa(ModelosucEmpresa);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ModelosucEmpresa.cod_emp, metodo, "ActualizarSucursalEmpresa", e.ToString(), DateTime.Now, ModelosucEmpresa.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarSucursalEmpresa." + " Por favor notificar al administrador.";
            }
        }
        //Eliminarr sucursal empresa 
        SucursalEmpresa deleteSucursal = new SucursalEmpresa();
        modeloSucuralempresa ModelosucursalDelete = new modeloSucuralempresa();
        public string EliminarSucursalEmpresa(modeloSucuralempresa ModelosucEmpresa)
        {
            try
            {
                string respuesta = deleteSucursal.EliminarSucursalEmpresa(ModelosucEmpresa);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ModelosucEmpresa.cod_emp, metodo, "EliminarSucursalEmpresa", e.ToString(), DateTime.Now, ModelosucEmpresa.usuario_mod);
                return "No se pudo completar la acción." + "EliminarSucursalEmpresa." + " Por favor notificar al administrador.";
            }
        }
        public string UsuariosSucursal(string cod_emp,string cod_sucursal, string usuario)
        {
            try
            {
                string respuesta = deleteSucursal.ConsultaUsuarioSucursal(cod_emp, cod_sucursal, usuario);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "UsuariosSucursal", e.ToString(), DateTime.Now, usuario);
                return "No se pudo completar la acción." + "EliminarSucursalEmpresa." + " Por favor notificar al administrador.";
            }
        }


    }
}
