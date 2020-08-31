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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "UnicoSucursalEmpresa", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }
        public string PrefijoSEFacturaN(string cod_emp, string serie_factura, string usuario)
        {
            try
            {

                string serie_fac = null;
                serie_fac = SucursalEmpresaUnico.PrefijosSucEmpFacturaNormal(cod_emp, serie_factura, usuario);
                return serie_fac;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijoSEFacturaN", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        public string PrefijoSEFactura(string cod_emp,  string serie_factura, string usuario)
        {
            try
            {

                string serie_fac = null;
                serie_fac = SucursalEmpresaUnico.PrefijosSucEmpFactura(cod_emp,  serie_factura, usuario);
                return serie_fac;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijoSEFactura", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        public string PrefijoSENC(string cod_emp, string serie_factura, string usuario)
        {
            try
            {

                string serie_fac = null;
                serie_fac = SucursalEmpresaUnico.PrefijosSucEmpNC(cod_emp, serie_factura, usuario);
                return serie_fac;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijoSEFactura", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        public string PrefijoSENCN(string cod_emp, string serie_factura, string usuario)
        {
            try
            {

                string serie_fac = null;
                serie_fac = SucursalEmpresaUnico.PrefijosSucEmpNCN(cod_emp, serie_factura, usuario);
                return serie_fac;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijoSENCN", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }

        public string PrefijoSEND(string cod_emp, string serie_factura, string usuario)
        {
            try
            {

                string serie_fac = null;
                serie_fac = SucursalEmpresaUnico.PrefijosSucEmpND(cod_emp, serie_factura, usuario);
                return serie_fac;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijoSEND", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        public string PrefijoSENDN(string cod_emp, string serie_factura, string usuario)
        {
            try
            {

                string serie_fac = null;
                serie_fac = SucursalEmpresaUnico.PrefijosSucEmpNDN(cod_emp, serie_factura, usuario);
                return serie_fac;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "PrefijoSENDN", e.ToString(), DateTime.Now, usuario);
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaSucursalEmpresa", e.ToString(), DateTime.Now, "consulta");
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaSucursalUnico", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }

        //sucursal-ciudad
        public List<modeloSucuralempresa> ConsultaSucursalCiudad(string Ccf_cod_emp, string cod_sucursal, string CC__usuario)
        {
            try
            {
                CodigosPaiPrvCiu ciudad_modelo = new CodigosPaiPrvCiu();
                modelociudades modelo_ciudad = new modelociudades();
                List<modeloSucuralempresa> lista = new List<modeloSucuralempresa>();
                List<modeloSucuralempresa> listaAux = new List<modeloSucuralempresa>();
                lista = consultaSucursalUnico.ConsultaSucursal(Ccf_cod_emp, cod_sucursal);

                foreach(var item in lista)
                {
                    modelo_ciudad= ciudad_modelo.Ciudades(CC__usuario, Ccf_cod_emp, item.cod_pais.Trim(), "0", item.cod_ciudad);
                    if(modelo_ciudad.nom_ciudad ==null)
                    {
                        
                    }
                    else
                    {
                        item.nom_ciudad = modelo_ciudad.nom_ciudad;
                        listaAux.Add(item);
                    }
                }
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaSucursalUnico", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }
    }
}
