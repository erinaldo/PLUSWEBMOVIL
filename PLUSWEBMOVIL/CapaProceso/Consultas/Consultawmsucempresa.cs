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
            SqlDataReader dr = SucursalEmpresaUnico.UnicoSucursalEmpresa(Ccf_cod_emp, cod_sucursal);

            while (dr.Read())
            {
                modeloSucuralempresa item = new modeloSucuralempresa();
                item.sucursales = Convert.ToString(dr["cod_sucursal"]) + " - " + Convert.ToString(dr["nom_sucursal"]);
                item.cod_emp = Convert.ToString(dr["cod_emp"]);
                item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                item.nom_sucursal = Convert.ToString(dr["nom_sucursal"]);
                item.dir_sucursal = Convert.ToString(dr["dir_sucursal"]);
                item.tel_sucursal = Convert.ToString(dr["tel_sucursal"]);
                item.email_sucursal = Convert.ToString(dr["email_sucursal"]);
                item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                item.nro_audit = Convert.ToString(dr["nro_audit"]);
                lista.Add(item);
            }
            return lista;
        }
        //Buscar sucursal empresa cargar todos
        SucursalEmpresa consultaSucursal = new SucursalEmpresa();
        modeloSucuralempresa ModelosucursalEmpresa = new modeloSucuralempresa();
        public List<modeloSucuralempresa> ConsultaSucursalEmpresa(string Ccf_cod_emp)
        {
            
            List<modeloSucuralempresa> lista = new List<modeloSucuralempresa>();
            SqlDataReader dr = consultaSucursal.ConsultaSucursalEmpresa(Ccf_cod_emp);

            while (dr.Read())
            {
                modeloSucuralempresa item = new modeloSucuralempresa();
                item.sucursales = Convert.ToString(dr["cod_sucursal"]) + " - " + Convert.ToString(dr["nom_sucursal"]);
                item.cod_emp = Convert.ToString(dr["cod_emp"]);
                item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                item.nom_sucursal = Convert.ToString(dr["nom_sucursal"]);
                item.dir_sucursal = Convert.ToString(dr["dir_sucursal"]);
                item.tel_sucursal = Convert.ToString(dr["tel_sucursal"]);
                item.email_sucursal = Convert.ToString(dr["email_sucursal"]);
                item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                item.nro_audit = Convert.ToString(dr["nro_audit"]);
                lista.Add(item);
            }
            return lista;
        }

        //Buscar sucursal empresa cargar especifico
        SucursalEmpresa consultaSucursalUnico = new SucursalEmpresa();
        modeloSucuralempresa Modelosucursal = new modeloSucuralempresa();
        public List<modeloSucuralempresa> ConsultaSucursalUnico(string Ccf_cod_emp, string cod_sucursal)
        {

            List<modeloSucuralempresa> lista = new List<modeloSucuralempresa>();
            SqlDataReader dr = consultaSucursalUnico.ConsultaSucursal(Ccf_cod_emp, cod_sucursal);

            while (dr.Read())
            {
                modeloSucuralempresa item = new modeloSucuralempresa();
                item.sucursales = Convert.ToString(dr["cod_sucursal"]) + " - " + Convert.ToString(dr["nom_sucursal"]);
                item.cod_emp = Convert.ToString(dr["cod_emp"]);
                item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                item.nom_sucursal = Convert.ToString(dr["nom_sucursal"]);
                item.dir_sucursal = Convert.ToString(dr["dir_sucursal"]);
                item.tel_sucursal = Convert.ToString(dr["tel_sucursal"]);
                item.email_sucursal = Convert.ToString(dr["email_sucursal"]);
                item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                item.nro_audit = Convert.ToString(dr["nro_audit"]);
                lista.Add(item);
            }
            return lista;
        }
    }
}
