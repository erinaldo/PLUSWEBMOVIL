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
        public string InsertarSucursalEmpresa(modeloSucuralempresa ModelosucEmpresa)
        {
            string respuesta = guardarSucursal.InsertarSucursalEmpresa(ModelosucEmpresa);
            return respuesta;
        }

        //Actualizar sucursal empresa 
        SucursalEmpresa updateSucursal = new SucursalEmpresa();
        modeloSucuralempresa ModelosucursalUPDATE = new modeloSucuralempresa();
        public string ActualizarSucursalEmpresa(modeloSucuralempresa ModelosucEmpresa)
        {
            string respuesta = updateSucursal.ActualizarSucursalEmpresa(ModelosucEmpresa);
            return respuesta;
        }
        //Eliminarr sucursal empresa 
        SucursalEmpresa deleteSucursal = new SucursalEmpresa();
        modeloSucuralempresa ModelosucursalDelete = new modeloSucuralempresa();
        public string EliminarSucursalEmpresa(modeloSucuralempresa ModelosucEmpresa)
        {
            string respuesta = deleteSucursal.EliminarSucursalEmpresa(ModelosucEmpresa);
            return respuesta;
        }



    }
}
