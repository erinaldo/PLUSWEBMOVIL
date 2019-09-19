﻿using CapaDatos.Modelos;
using CapaDatos.Modelos.ModelosNC;
using CapaDatos.Sql;
using CapaDatos.Sql.SqlNC;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;



namespace CapaProceso.Consultas
{
   public  class Consultawmtfacturascab
    {
        FacturACab consulta = new FacturACab();
        modelowmtfacturascab modelocons = new modelowmtfacturascab();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "Consultawmtfacturascab.cs";

      
        //NC SOLO TRANS_PADRE
        public List<modelowmtfacturascab> ConsultaNCTransPadre(string nro_trans)
        {
            try
            {
                List<modelowmtfacturascab> lista = new List<modelowmtfacturascab>();
                lista = consulta.ConsultaDatosNCPadre(nro_trans);

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ConsultaNCTransPadre", e.ToString(), DateTime.Today, "consulta");
                return null;
            }

        }
        public List<modelowmtfacturascab> ConsultaCabFacura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string Ccf_estado, string Ccf_cliente, string Ccf_cod_docum, string Ccf_serie_docum, string Ccf_nro_docum, string Ccf_diai, string Ccf_mesi, string Ccf_anioi, string Ccf_diaf, string Ccf_mesf, string Ccf_aniof)
        {
            try
            {
                List<modelowmtfacturascab> lista = new List<modelowmtfacturascab>();
                lista = consulta.ConsultaFacturaNroTran(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaCabFacura", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }

        public List<modelowmtfacturascab> ConsultaTipoFactura(string nro_trans)
        {
            try
            {
                List<modelowmtfacturascab> lista = new List<modelowmtfacturascab>();
                lista = consulta.ConsultaTipoFC(nro_trans);

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ConsultaTipoFactura", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

        /*CONSULTA DOCUMENTOS ELECTRONICOS*/
        SaldosFacturas consultaSaldoa = new SaldosFacturas();
        public List<modelowmtfacturascab> ConsultaDocElectronicos(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string Ccf_estado, string Ccf_cliente, string Ccf_cod_docum, string Ccf_serie_docum, string Ccf_nro_docum, string Ccf_diai, string Ccf_mesi, string Ccf_anioi, string Ccf_diaf, string Ccf_mesf, string Ccf_aniof)
        {
            modeloFacturasElecSaldos ModeloDocElec = new modeloFacturasElecSaldos();
            List<modelowmtfacturascab> lista = new List<modelowmtfacturascab>();
            List<modelowmtfacturascab> listaAux = new List<modelowmtfacturascab>();
            lista = consulta.ConsultaFacturaNroTran(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
            foreach (var item in lista)
            {
                ModeloDocElec = BuscartaDocElelectronicos(Ccf_cod_emp, item.nro_trans);
                if (ModeloDocElec != null)
                {
                    listaAux.Add(item);
                }

            }

            return listaAux;
            
        }

        //lista cufe pra doc ele
       
        public modeloFacturasElecSaldos BuscartaDocElelectronicos( string cod_emp, string nro_trans)
        {
            try
            {
                modeloFacturasElecSaldos item = new modeloFacturasElecSaldos();
                item = consultaSaldoa.ConsultaDocumEletronicos(cod_emp, nro_trans);
                return item;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "BuscartaDocElelectronicos", e.ToString(), DateTime.Today, "consulta");
                return null;
            }

        }
    }
}
