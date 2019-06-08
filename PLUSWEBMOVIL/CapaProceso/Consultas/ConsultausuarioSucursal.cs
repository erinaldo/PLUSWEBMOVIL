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
    }
}
