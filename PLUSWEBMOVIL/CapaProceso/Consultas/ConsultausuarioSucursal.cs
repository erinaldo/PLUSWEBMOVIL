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
        modeloUsuariosucursal ModeloUsuario = new modeloUsuariosucursal();

        public string InsertarUsuarioSucursal(modeloUsuariosucursal ModeloUsuSucursal)
        {
            string respuesta = guardarSucursal.InsertarUsuarioSucursal(ModeloUsuSucursal);
            return respuesta;
        }

        //Actualizar usuario
        UsuarioSucursal updateSucursal = new UsuarioSucursal();
        modeloUsuariosucursal ModeloUsuarioActualizar = new modeloUsuariosucursal();

        public string ActualizarUsuarioSucursal(modeloUsuariosucursal ActualizarUsuSucursal)
        {
            string respuesta = updateSucursal.ActualizarUsuarioSucursal(ActualizarUsuSucursal);
            return respuesta;
        }
        //Eliminar usuario
        UsuarioSucursal deleteSucursal = new UsuarioSucursal();
        modeloUsuariosucursal ModeloUsuarioDelete = new modeloUsuariosucursal();

        public string EliminarrUsuarioSucursal(modeloUsuariosucursal EliminarUsuSucursal)
        {
            string respuesta = deleteSucursal.EliminarUsuarioSucursal(EliminarUsuSucursal);
            return respuesta;
        }
    }
}
