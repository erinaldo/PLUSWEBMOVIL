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
        

      
    }
}
