﻿using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
  public  class ConsultaValidarParametrosFactura
    {
        ValidarParametrizacionFactura factura = new ValidarParametrizacionFactura();
       
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "ConsultaValidarParametrosFactura.cs";

        //Insertar cabecera NC Financiera
        public string ConsultaValidarPeriodoContable(string cod_emp, string usuario, string fecha)
        {
            try
            {
                string respuesta = factura.ValidarPeriodoContable(cod_emp, usuario, fecha);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaValidarPeriodoContable", e.ToString(), DateTime.Today, usuario);
                return "No se pudo completar la acción." + "ConsultaValidarPeriodoContable." + " Por favor notificar al administrador.";
            }
        }

        //COd ciudad y cod_mneda erp
        public Boolean ConsultaValidarMonCiudEmpresaERP(string cod_emp, string usuario)
        {
            try
            {
                Boolean lista =false;
                lista = factura.ValidarMonCiudEmpresaERP(cod_emp, usuario);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaValidarMonCiudEmpresaERP", e.ToString(), DateTime.Today, usuario);
                return false;
            }
        }

        //COd ciudad y cod_mneda erp
        public Boolean ConsultaValidarResolucionERP(string cod_emp, string usuario, string estado, string serie, string fecha)
        {
            try
            {
                Boolean lista = false;
                lista = factura.ValidarResolucionERP(cod_emp, usuario,  estado,  serie, fecha);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaValidarResolucionERP", e.ToString(), DateTime.Today, usuario);
                return false;
            }
        }
    }
}
