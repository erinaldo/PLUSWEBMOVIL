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
       string metodo = "Consultawmsucempresa.cs";
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<modeloSucuralempresa> UnicoSucursalEmpresa(string Ccf_cod_emp, string cod_sucursal)
        {
            try
            {
                List<modeloSucuralempresa> lista = new List<modeloSucuralempresa>();
                lista = SucursalEmpresaUnico.UnicoSucursalEmpresa(Ccf_cod_emp, cod_sucursal);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "UnicoSucursalEmpresa", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
        //Buscar sucursal empresa cargar todos
        SucursalEmpresa consultaSucursal = new SucursalEmpresa();
      
        public List<modeloSucuralempresa> ConsultaSucursalEmpresa(string Ccf_cod_emp)
        {
            try
            {
                List<modeloSucuralempresa> lista = new List<modeloSucuralempresa>();
                lista = consultaSucursal.ConsultaSucursalEmpresa(Ccf_cod_emp);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaSucursalEmpresa", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

        //Buscar sucursal empresa cargar especifico
        SucursalEmpresa consultaSucursalUnico = new SucursalEmpresa();
        
        public List<modeloSucuralempresa> ConsultaSucursalUnico(string Ccf_cod_emp, string cod_sucursal)
        {
            try
            {
                List<modeloSucuralempresa> lista = new List<modeloSucuralempresa>();
                lista = consultaSucursalUnico.ConsultaSucursal(Ccf_cod_emp, cod_sucursal);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaSucursalUnico", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
    }
}
