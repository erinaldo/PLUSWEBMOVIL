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
   public class ConsultaSaldosFacturas
    {
        
        SaldosFacturas consultaSaldoa = new SaldosFacturas();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        //Saldos FACTURAS NORMALES VTA
        public List<modeloSaldosFacturas> ConsultaFacturasVTASaldos(string Ccf_usuario, string Ccf_cod_emp, string Ccf_tipo1, string Ccf_tipo2, string solo_saldo)
        {
            try
            {
                modeloFacturasElecSaldos modeloFacturasElecSaldos = new modeloFacturasElecSaldos();
                List<modeloSaldosFacturas> lista = new List<modeloSaldosFacturas>();
                List<modeloSaldosFacturas> listaAux = new List<modeloSaldosFacturas>();
                lista = consultaSaldoa.ConsultaFacturasSaldos(Ccf_usuario, Ccf_cod_emp, Ccf_tipo1, Ccf_tipo2, solo_saldo);

                foreach (var item in lista)
                {
                    modeloFacturasElecSaldos = consultaSaldoa.ConsultaFacturasVTASaldos(item.cod_cliente, Ccf_cod_emp,  item.nro_docum);
                    if (modeloFacturasElecSaldos.cufe == null && modeloFacturasElecSaldos.nro_trans != null)
                    {
                        item.nro_trans = modeloFacturasElecSaldos.nro_trans;
                        listaAux.Add(item);
                    }

                }

                return listaAux;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, "ConsultaSaldosFacturas.cs", "ConsultaFacturasVTASaldos", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }

        //sql saldos de FE nuevo 
        public modeloFacturasElecSaldos BuscarFacturasVTAPOS(string cod_cliente, string cod_emp, string nro_trans)
        {
            try
            {
                modeloFacturasElecSaldos item = new modeloFacturasElecSaldos();
                item = consultaSaldoa.ConsultaFacturasVTASaldos(cod_cliente, cod_emp, nro_trans);
                return item;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "ConsultaSaldosFacturas.cs", "BuscarFacturasVTAPOS", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

     

        //Saldos sin restricciones
        public List<modeloSaldosFacturas> BuscartaFacturaSaldos( string Ccf_usuario, string Ccf_cod_emp, string Ccf_tipo1, string Ccf_tipo2, string solo_saldo)
        {
            try
            {
                modeloFacturasElecSaldos modeloFacturasElecSaldos = new modeloFacturasElecSaldos();
                List<modeloSaldosFacturas> lista = new List<modeloSaldosFacturas>();
                List<modeloSaldosFacturas> listaNroTrans = new List<modeloSaldosFacturas>();
                List<modeloSaldosFacturas> listaAux = new List<modeloSaldosFacturas>();
                lista = consultaSaldoa.ConsultaFacturasSaldos(Ccf_usuario, Ccf_cod_emp, Ccf_tipo1, Ccf_tipo2, solo_saldo);
                
                foreach (var item in lista)
                {
                    modeloFacturasElecSaldos = BuscartaFacEleSaldos(Ccf_tipo1, Ccf_cod_emp, item.serie_docum, item.nro_docum);
                    if (modeloFacturasElecSaldos.cufe != null)
                    {
                        item.nro_trans = modeloFacturasElecSaldos.nro_trans;
                        listaAux.Add(item);
                    }

                }

                return listaAux;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, "ConsultaSaldosFacturas.cs", "BuscartaFacturaSaldos", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }

        //sql saldos de FE nuevo 
        public modeloFacturasElecSaldos BuscartaFacEleSaldos(string cod_cliente, string cod_emp, string serie, string nro_docum)
        {
            try
            {
                modeloFacturasElecSaldos item = new modeloFacturasElecSaldos();
                item = consultaSaldoa.ConsultaFacEleSaldos(cod_cliente, cod_emp, serie,nro_docum);
                return item;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "ConsultaSaldosFacturas.cs", "BuscartaFacEleSaldos", e.ToString(), DateTime.Today,"consulta");
                return null;
            }
        }

        
    }
}
