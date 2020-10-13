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
    public class ConsultaProformasFac
    {
        ConsultaProformas consultaProformas = new ConsultaProformas();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "ConsultaProformasFac.cs";

        //Consultar unica cabecera
        public List<modelowmtproformascab> BuscarProformasCab(string nro_trans)
        {
            try
            {
                List<modelowmtproformascab> lista = new List<modelowmtproformascab>();
                lista = consultaProformas.ConsultaProformasFactura(nro_trans);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "BuscarProformasCab", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }
        public List<modelowmtproformascab> BuscarProformas(string cod_cliente, string estado, string tipo)
        {
            try
            {
                List<modelowmtproformascab> lista = new List<modelowmtproformascab>();
                lista = consultaProformas.ListaProformasFactura(cod_cliente, estado, tipo);

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "ConsultaProformasFac.cs", "BuscarProformas", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }

        //Lista Proformas masivas
        public List<modelowmtproformascab> ListaProformasMasivas(string usuario, string cod_emp, string tipo, string nro_trans, string estado)
        {
            try
            {
                List<modelowmtproformascab> lista = new List<modelowmtproformascab>();
                lista = consultaProformas.ListaProformasMasivasE(usuario, cod_emp, tipo, nro_trans, estado);

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaProformasMasivas", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }

        //Toatal de cliente a factuarar total facturas 
        public List<modeloClientesproforma> TotalProformasAFacturar(string usuario, string cod_emp, string nro_trans)
        {
            try
            {
                List<modeloClientesproforma> lista = new List<modeloClientesproforma>();
                lista = consultaProformas.TotalProformasAFacturar(usuario, cod_emp, nro_trans);

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "TotalProformasAFacturar", e.ToString(), DateTime.Now, usuario);
                return null;
            }

        }
        //Cliente  FACTURAR POR PROFORMA
        public modelowmspctitulares ClienteProformasAFacturar(string usuario, string cod_emp, string nro_trans)
        {
            try
            {
                modelowmspctitulares lista = new modelowmspctitulares();
               lista = consultaProformas.ClienteProformasAFacturar(usuario, cod_emp, nro_trans);

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ClienteProformasAFacturar", e.ToString(), DateTime.Now, usuario);
                return null;
            }

        }
        //Insertar lista de clientes de proforma

        public string InsertarClienteProformasAFacturar(modeloClientesproforma modelo)
        {
            try
            {

                string lista = consultaProformas.InsertarClientesProforma(modelo);

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(modelo.cod_emp, metodo, "InsertarClienteProformasAFacturar", e.ToString(), DateTime.Now, modelo.usuario);
                return null;
            }

        }
    }
}
