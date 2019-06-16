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
   public  class Consultawmsucempresa
    {
        //Buscar unico empresa cargar especifico
        SucursalEmpresa SucursalEmpresaUnico = new SucursalEmpresa();
        modeloSucuralempresa ModelosucursalEmpresaUnico = new modeloSucuralempresa();
        public List<modeloSucuralempresa> UnicoSucursalEmpresa(string Ccf_cod_emp, string cod_sucursal)
        {

            List<modeloSucuralempresa> lista = new List<modeloSucuralempresa>();
            lista = SucursalEmpresaUnico.UnicoSucursalEmpresa(Ccf_cod_emp, cod_sucursal);            
            return lista;
        }
        //Buscar sucursal empresa cargar todos
        SucursalEmpresa consultaSucursal = new SucursalEmpresa();
        modeloSucuralempresa ModelosucursalEmpresa = new modeloSucuralempresa();
        public List<modeloSucuralempresa> ConsultaSucursalEmpresa(string Ccf_cod_emp)
        {            
            List<modeloSucuralempresa> lista = new List<modeloSucuralempresa>();
            lista = consultaSucursal.ConsultaSucursalEmpresa(Ccf_cod_emp);           
            return lista;
        }

        //Buscar sucursal empresa cargar especifico
        SucursalEmpresa consultaSucursalUnico = new SucursalEmpresa();
        modeloSucuralempresa Modelosucursal = new modeloSucuralempresa();
        public List<modeloSucuralempresa> ConsultaSucursalUnico(string Ccf_cod_emp, string cod_sucursal)
        {

            List<modeloSucuralempresa> lista = new List<modeloSucuralempresa>();
            lista = consultaSucursalUnico.ConsultaSucursal(Ccf_cod_emp, cod_sucursal);            
            return lista;
        }
    }
}
