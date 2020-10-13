using CapaDatos.Modelos;
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

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ConsultaNCTransPadre", e.ToString(), DateTime.Now, "consulta");
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaCabFacura", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        //Busqueda de facturas por sucursal
        public List<modelowmtfacturascab> ConsultaFacturaXSucursal(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string Ccf_estado, string Ccf_cliente, string Ccf_cod_docum, string Ccf_serie_docum, string Ccf_nro_docum, string Ccf_diai, string Ccf_mesi, string Ccf_anioi, string Ccf_diaf, string Ccf_mesf, string Ccf_aniof, string cod_sucursal)
        {
            try
            {
                List<modelowmtfacturascab> lista = new List<modelowmtfacturascab>();
                List<modelowmtfacturascab> listaAux = new List<modelowmtfacturascab>();
                modelowmtfacturascab ModeloFactura = new modelowmtfacturascab();
                //Traer todas las facturas con los filtros necesarios de esa empresa
                lista = consulta.ConsultaFacturaNroTran(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                foreach(var item in lista)
                {
                    if(item.cod_sucursal.Trim() == cod_sucursal.Trim())//Filtrar por sucursal.
                    {
                        listaAux.Add(item);
                    }
                }
                return listaAux;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaFacturaXSucursal", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }
        //BUSQUEDA DOCUMENTOS COMERCIALES ELECTRONICOS Y POR COMPUTADOR PARA DESCARGAR POR SUCURSAL
        //Busqueda de facturas por sucursal
        public List<modelowmtfacturascab> ConsultaDocsXSucursal(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string Ccf_estado, string Ccf_cliente, string Ccf_cod_docum, string Ccf_serie_docum, string Ccf_nro_docum, string Ccf_diai, string Ccf_mesi, string Ccf_anioi, string Ccf_diaf, string Ccf_mesf, string Ccf_aniof, string cod_sucursal, string tipo_doc)
        {
            try
            {
                ConsultaSaldosFacturas BuscarElec = new ConsultaSaldosFacturas();
                List<modelowmtfacturascab> lista = new List<modelowmtfacturascab>();
                List<modelowmtfacturascab> listaAux = new List<modelowmtfacturascab>();
                modeloFacturasElecSaldos modeloFacturasElecSaldos = new modeloFacturasElecSaldos();
                //Traer todas las facturas con los filtros necesarios de esa empresa
                lista = consulta.ConsultaFacturaNroTran(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                if (tipo_doc.Trim() == "ELE")
                {
                    foreach (var item in lista)
                    {

                        modeloFacturasElecSaldos = BuscarElec.BuscartaFacEleSaldos(item.cod_cliente, Ccf_cod_emp, item.serie_docum.Trim(), item.nro_docum.Trim());
                        if (modeloFacturasElecSaldos.cufe != null && modeloFacturasElecSaldos.cod_suc_emp.Trim() == cod_sucursal.Trim())
                        {
                                listaAux.Add(item);
                        }
                    }
                }
                else
                {
                    foreach (var item in lista)
                    {
                        if (item.cod_sucursal.Trim() == cod_sucursal.Trim() && item.estado=="F")//Filtrar por sucursal.
                        {
                            listaAux.Add(item);
                        }
                        if (item.cod_sucursal.Trim() == cod_sucursal.Trim() && item.estado == "c")//Filtrar por sucursal.
                        {
                            listaAux.Add(item);
                        }
                    }
                }
                
               
                return listaAux;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaDocsXSucursal", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        //Consulta documentos electronicos estado contabilizado para reenviar a la DIAN
        public List<modelowmtfacturascab> ConsultaDocsElectronicosXSucursal(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string Ccf_estado, string Ccf_cliente, string Ccf_cod_docum, string Ccf_serie_docum, string Ccf_nro_docum, string Ccf_diai, string Ccf_mesi, string Ccf_anioi, string Ccf_diaf, string Ccf_mesf, string Ccf_aniof, string cod_sucursal)
        {
            try
            {

                List<modelowmtfacturascab> lista = new List<modelowmtfacturascab>();
                List<modelowmtfacturascab> listaAux = new List<modelowmtfacturascab>();
                //Traer todas las facturas con los filtros necesarios de esa empresa
                lista = consulta.ConsultaFacturaNroTran(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                if (Ccf_tipo2.Trim() == "NC")
                {
                    foreach (var item in lista)
                    {
                        if(item.tipo =="NCVE" || item.tipo =="NCME")
                        {
                            if (item.cod_sucursal.Trim() == cod_sucursal.Trim())//Filtrar por sucursal.
                            {
                                listaAux.Add(item);
                            }
                            
                        }
                    }
                }
                else
                {
                    foreach (var item in lista)
                    {
                       
                        if (item.cod_sucursal.Trim() == cod_sucursal.Trim())//Filtrar por sucursal.
                        {
                            listaAux.Add(item);
                        }
                    }
                }

                return listaAux;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaDocsElectronicosXSucursa", e.ToString(), DateTime.Now, Ccf_usuario);
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

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ConsultaTipoFactura", e.ToString(), DateTime.Now, "consulta");
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
