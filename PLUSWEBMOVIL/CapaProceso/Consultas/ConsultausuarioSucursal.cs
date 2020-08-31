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
   public class ConsultausuarioSucursal
    {
        
        UsuarioSucursal guardarSucursal = new UsuarioSucursal();
     
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo ="ConsultausuarioSucursal";

        public string InsertarUsuarioSucursal(modeloUsuariosucursal ModeloUsuSucursal)
        {
            try
            {
                string respuesta = guardarSucursal.InsertarUsuarioSucursal(ModeloUsuSucursal);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ModeloUsuSucursal.cod_emp, metodo, "InsertarUsuarioSucursal", e.ToString(), DateTime.Now, ModeloUsuSucursal.usuario_mod);
                return "No se pudo completar la acción." + "InsertarUsuarioSucursal." + " Por favor notificar al administrador.";
            }

        }

        //Actualizar usuario
        UsuarioSucursal updateSucursal = new UsuarioSucursal();
       

        public string ActualizarUsuarioSucursal(modeloUsuariosucursal ActualizarUsuSucursal)
        {
            try
            {
                string respuesta = updateSucursal.ActualizarUsuarioSucursal(ActualizarUsuSucursal);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ActualizarUsuSucursal.cod_emp, metodo, "ActualizarUsuarioSucursal", e.ToString(), DateTime.Today, ActualizarUsuSucursal.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarUsuarioSucursal." + " Por favor notificar al administrador.";
            }
        }
        //Eliminar usuario
        UsuarioSucursal deleteSucursal = new UsuarioSucursal();
        

        public string EliminarrUsuarioSucursal(modeloUsuariosucursal EliminarUsuSucursal)
        {
            try
            {
                string respuesta = deleteSucursal.EliminarUsuarioSucursal(EliminarUsuSucursal);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(EliminarUsuSucursal.cod_emp, metodo, "EliminarUsuarioSucursal", e.ToString(), DateTime.Today, EliminarUsuSucursal.usuario_mod);
                return "No se pudo completar la acción." + "EliminarUsuarioSucursal." + " Por favor notificar al administrador.";
            }
        }
    }
}
