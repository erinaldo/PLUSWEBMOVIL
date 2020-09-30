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
        string metodo = "ConsultaSaldosFacturas";
        //Consulta NC NORMALES PARA NOTAS DÉBITO POR ANULACION 
        public List<modeloSaldosFacturas> ConsultaNCNormalesSaldos(string Ccf_usuario, string Ccf_cod_emp, string Ccf_tipo1, string Ccf_tipo2, string solo_saldo, string cod_suc_emp, string fecha_ini, string fecha_fin, string nro_docum)
        {
            try
            {
                modeloFacturasElecSaldos modeloFacturasElecSaldos = new modeloFacturasElecSaldos();
                List<modeloSaldosFacturas> lista = new List<modeloSaldosFacturas>();
                List<modeloSaldosFacturas> listaAux = new List<modeloSaldosFacturas>();
                lista = consultaSaldoa.ConsultaFacturasSaldos(Ccf_usuario, Ccf_cod_emp, Ccf_tipo1, Ccf_tipo2, solo_saldo, fecha_ini, fecha_fin, nro_docum);

                foreach (var item in lista)
                {
                    modeloFacturasElecSaldos = consultaSaldoa.ConsultaNCNormalesSaldos(item.cod_cliente, Ccf_cod_emp, item.nro_docum.Trim(), Ccf_usuario, item.serie_docum.Trim());
                    if (modeloFacturasElecSaldos.cufe == null && modeloFacturasElecSaldos.nro_trans != null && modeloFacturasElecSaldos.cod_suc_emp.Trim() == cod_suc_emp.Trim())
                    {
                        item.nro_trans = modeloFacturasElecSaldos.nro_trans;
                        listaAux.Add(item);
                    }

                }

                return listaAux;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaNCNormalesSaldos", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        //Consulta NC NORMALES PARA NOTAS DÉBITO POR ANULACION filtro por nro_docum
        public List<modeloSaldosFacturas> ConsultaNCNormalesSaldosXNroDoc(string Ccf_usuario, string Ccf_cod_emp, string Ccf_tipo1, string Ccf_tipo2, string solo_saldo, string cod_suc_emp, string nro_docum)
        {
            try
            {
                modeloFacturasElecSaldos modeloFacturasElecSaldos = new modeloFacturasElecSaldos();
                List<modeloSaldosFacturas> lista = new List<modeloSaldosFacturas>();
                List<modeloSaldosFacturas> listaAux = new List<modeloSaldosFacturas>();
                lista = consultaSaldoa.ConsultaFacturasSaldosXNroDocum(Ccf_usuario, Ccf_cod_emp, Ccf_tipo1, Ccf_tipo2, solo_saldo, nro_docum);

                foreach (var item in lista)
                {
                    modeloFacturasElecSaldos = consultaSaldoa.ConsultaNCNormalesSaldos(item.cod_cliente, Ccf_cod_emp, item.nro_docum.Trim(), Ccf_usuario, item.serie_docum.Trim());
                    if (modeloFacturasElecSaldos.cufe == null && modeloFacturasElecSaldos.nro_trans != null && modeloFacturasElecSaldos.cod_suc_emp.Trim() == cod_suc_emp.Trim())
                    {
                        item.nro_trans = modeloFacturasElecSaldos.nro_trans;
                        listaAux.Add(item);
                    }

                }

                return listaAux;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaNCNormalesSaldosXNroDoc", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }
        //Saldos FACTURAS NORMALES VTA-filtro nro_documento unicamente
        public List<modeloSaldosFacturas> ConsultaFacturasVTASaldosXNroDoc(string Ccf_usuario, string Ccf_cod_emp, string Ccf_tipo1, string Ccf_tipo2, string solo_saldo, string cod_suc_emp, string nro_docum)
        {
            try
            {
                modeloFacturasElecSaldos modeloFacturasElecSaldos = new modeloFacturasElecSaldos();
                List<modeloSaldosFacturas> lista = new List<modeloSaldosFacturas>();
                List<modeloSaldosFacturas> listaAux = new List<modeloSaldosFacturas>();
                lista = consultaSaldoa.ConsultaFacturasSaldosXNroDocum(Ccf_usuario, Ccf_cod_emp, Ccf_tipo1, Ccf_tipo2, solo_saldo, nro_docum);

                foreach (var item in lista)
                {
                    modeloFacturasElecSaldos = consultaSaldoa.ConsultaFacturasVTASaldos(item.cod_cliente.Trim(), Ccf_cod_emp, item.nro_docum.Trim(), item.serie_docum.Trim());
                    if (modeloFacturasElecSaldos.cufe == null && modeloFacturasElecSaldos.nro_trans != null && modeloFacturasElecSaldos.cod_suc_emp.Trim() == cod_suc_emp.Trim())
                    {
                        item.nro_trans = modeloFacturasElecSaldos.nro_trans;
                        listaAux.Add(item);
                    }

                }

                return listaAux;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaFacturasVTASaldosXNroDoc", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }
        //Saldos FACTURAS NORMALES VTA
        public List<modeloSaldosFacturas> ConsultaFacturasVTASaldos(string Ccf_usuario, string Ccf_cod_emp, string Ccf_tipo1, string Ccf_tipo2, string solo_saldo, string cod_suc_emp, string fecha_ini, string fecha_fin, string nro_docum)
        {
            try
            {
                modeloFacturasElecSaldos modeloFacturasElecSaldos = new modeloFacturasElecSaldos();
                List<modeloSaldosFacturas> lista = new List<modeloSaldosFacturas>();
                List<modeloSaldosFacturas> listaAux = new List<modeloSaldosFacturas>();
                lista = consultaSaldoa.ConsultaFacturasSaldos(Ccf_usuario, Ccf_cod_emp, Ccf_tipo1, Ccf_tipo2, solo_saldo, fecha_ini, fecha_fin, nro_docum);

                foreach (var item in lista)
                {
                    modeloFacturasElecSaldos = consultaSaldoa.ConsultaFacturasVTASaldos(item.cod_cliente.Trim(), Ccf_cod_emp,  item.nro_docum.Trim(), item.serie_docum.Trim());
                    if (modeloFacturasElecSaldos.cufe == null && modeloFacturasElecSaldos.nro_trans != null && modeloFacturasElecSaldos.cod_suc_emp.Trim() ==cod_suc_emp.Trim())
                    {
                        item.nro_trans = modeloFacturasElecSaldos.nro_trans;
                        listaAux.Add(item);
                    }

                }

                return listaAux;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, "ConsultaSaldosFacturas.cs", "ConsultaFacturasVTASaldos", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        //sql saldos de FE nuevo 
        public modeloFacturasElecSaldos BuscarFacturasVTAPOS(string cod_cliente, string cod_emp, string nro_docum, string serie_docum)
        {
            try
            {
                modeloFacturasElecSaldos item = new modeloFacturasElecSaldos();
                item = consultaSaldoa.ConsultaFacturasVTASaldos(cod_cliente, cod_emp, nro_docum, serie_docum);
                return item;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "ConsultaSaldosFacturas.cs", "BuscarFacturasVTAPOS", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }

        //SALDO DE NOTAS DE CREDITO ELECTRONICAS---filtro por nro_docum
        //Saldos sin restricciones
        public List<modeloSaldosFacturas> BuscarNCElecSaldosXNroDoc(string Ccf_usuario, string Ccf_cod_emp, string Ccf_tipo1, string Ccf_tipo2, string solo_saldo, string cod_suc_emp, string nro_docum)
        {
            try
            {
                modeloFacturasElecSaldos modeloFacturasElecSaldos = new modeloFacturasElecSaldos();
                List<modeloSaldosFacturas> lista = new List<modeloSaldosFacturas>();
                List<modeloSaldosFacturas> listaNroTrans = new List<modeloSaldosFacturas>();
                List<modeloSaldosFacturas> listaAux = new List<modeloSaldosFacturas>();
                lista = consultaSaldoa.ConsultaFacturasSaldosXNroDocum(Ccf_usuario, Ccf_cod_emp, Ccf_tipo1, Ccf_tipo2, solo_saldo, nro_docum);

                foreach (var item in lista)
                {
                    modeloFacturasElecSaldos = BuscaNCEleSaldos(Ccf_tipo1, Ccf_cod_emp, item.serie_docum.Trim(), item.nro_docum.Trim(), Ccf_usuario);
                    if (modeloFacturasElecSaldos.cufe != null && modeloFacturasElecSaldos.cod_suc_emp.Trim() == cod_suc_emp.Trim())
                    {
                        item.nro_trans = modeloFacturasElecSaldos.nro_trans;
                        listaAux.Add(item);
                    }

                }

                return listaAux;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarNCElecSaldosXNroDoc", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        //SALDO DE NOTAS DE CREDITO ELECTRONICAS
        //Saldos sin restricciones
        public List<modeloSaldosFacturas> BuscarNCElecSaldos(string Ccf_usuario, string Ccf_cod_emp, string Ccf_tipo1, string Ccf_tipo2, string solo_saldo, string cod_suc_emp, string fecha_ini, string fecha_fin, string nro_docum)
        {
            try
            {
                modeloFacturasElecSaldos modeloFacturasElecSaldos = new modeloFacturasElecSaldos();
                List<modeloSaldosFacturas> lista = new List<modeloSaldosFacturas>();
                List<modeloSaldosFacturas> listaNroTrans = new List<modeloSaldosFacturas>();
                List<modeloSaldosFacturas> listaAux = new List<modeloSaldosFacturas>();
                lista = consultaSaldoa.ConsultaFacturasSaldos(Ccf_usuario, Ccf_cod_emp, Ccf_tipo1, Ccf_tipo2, solo_saldo, fecha_ini, fecha_fin, nro_docum);

                foreach (var item in lista)
                {
                    modeloFacturasElecSaldos = BuscaNCEleSaldos(Ccf_tipo1, Ccf_cod_emp, item.serie_docum.Trim(), item.nro_docum.Trim(), Ccf_usuario);
                    if (modeloFacturasElecSaldos.cufe != null && modeloFacturasElecSaldos.cod_suc_emp.Trim() == cod_suc_emp.Trim())
                    {
                        item.nro_trans = modeloFacturasElecSaldos.nro_trans;
                        listaAux.Add(item);
                    }

                }

                return listaAux;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarNCElecSaldos", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }
        //Saldos sin restricciones filtro por nro_docum unicamente
        public List<modeloSaldosFacturas> BuscarFacturaSaldosXNroDocumento(string Ccf_usuario, string Ccf_cod_emp, string Ccf_tipo1, string Ccf_tipo2, string solo_saldo, string cod_suc_emp, string nro_docum)
        {
            try
            {
                modeloFacturasElecSaldos modeloFacturasElecSaldos = new modeloFacturasElecSaldos();
                List<modeloSaldosFacturas> lista = new List<modeloSaldosFacturas>();
                List<modeloSaldosFacturas> listaNroTrans = new List<modeloSaldosFacturas>();
                List<modeloSaldosFacturas> listaAux = new List<modeloSaldosFacturas>();
                lista = consultaSaldoa.ConsultaFacturasSaldosXNroDocum(Ccf_usuario, Ccf_cod_emp, Ccf_tipo1, Ccf_tipo2, solo_saldo, nro_docum);

                foreach (var item in lista)
                {
                    modeloFacturasElecSaldos = BuscartaFacEleSaldos(Ccf_tipo1, Ccf_cod_emp, item.serie_docum.Trim(), item.nro_docum.Trim());
                    if (modeloFacturasElecSaldos.cufe != null && modeloFacturasElecSaldos.cod_suc_emp.Trim() == cod_suc_emp.Trim())
                    {
                        item.nro_trans = modeloFacturasElecSaldos.nro_trans;
                        listaAux.Add(item);
                    }

                }

                return listaAux;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarFacturaSaldosXNroDocumento", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        //Saldos sin restricciones filtro fecha
        public List<modeloSaldosFacturas> BuscartaFacturaSaldos( string Ccf_usuario, string Ccf_cod_emp, string Ccf_tipo1, string Ccf_tipo2, string solo_saldo, string cod_suc_emp, string fecha_ini, string fecha_fin, string nro_docum)
        {
            try
            {
                modeloFacturasElecSaldos modeloFacturasElecSaldos = new modeloFacturasElecSaldos();
                List<modeloSaldosFacturas> lista = new List<modeloSaldosFacturas>();
                List<modeloSaldosFacturas> listaNroTrans = new List<modeloSaldosFacturas>();
                List<modeloSaldosFacturas> listaAux = new List<modeloSaldosFacturas>();
                lista = consultaSaldoa.ConsultaFacturasSaldos(Ccf_usuario, Ccf_cod_emp, Ccf_tipo1, Ccf_tipo2, solo_saldo, fecha_ini, fecha_fin, nro_docum);
                
                foreach (var item in lista)
                {
                    modeloFacturasElecSaldos = BuscartaFacEleSaldos(Ccf_tipo1, Ccf_cod_emp, item.serie_docum.Trim(), item.nro_docum.Trim());
                    if (modeloFacturasElecSaldos.cufe != null && modeloFacturasElecSaldos.cod_suc_emp.Trim() ==cod_suc_emp.Trim())
                    {
                        item.nro_trans = modeloFacturasElecSaldos.nro_trans;
                        listaAux.Add(item);
                    }

                }

                return listaAux;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscartaFacturaSaldos", e.ToString(), DateTime.Now, Ccf_usuario);
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

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "BuscartaFacEleSaldos", e.ToString(), DateTime.Now,"consulta");
                return null;
            }
        }

        //sql saldos de NC ELECTRONICA nuevo 
        public modeloFacturasElecSaldos BuscaNCEleSaldos(string cod_cliente, string cod_emp, string serie, string nro_docum, string usuario)
        {
            try
            {
                modeloFacturasElecSaldos item = new modeloFacturasElecSaldos();
                item = consultaSaldoa.ConsultaNCEleSaldos(cod_cliente, cod_emp, serie, nro_docum, usuario);
                return item;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "BuscaNCEleSaldos", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }


    }
}
