using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.EstadoDocEle
{
  public   class JsonEstadoDE
    {
        public modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        public List<modelowmtfacturascab> listaConsCab = null;
        public Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

        public List<modelowmspcempresas> ListaModeloempresa = new List<modelowmspcempresas>();
        public ConsultaEmpresa consultaEmpresa = new ConsultaEmpresa();
        public modelowmspcempresas Modeloempresa = new modelowmspcempresas();

        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public string Ccf_estado = null;
        public string Ccf_cliente = null;
        public string Ccf_cod_docum = null;
        public string Ccf_serie_docum = null;
        public string Ccf_nro_docum = null;
        public string Ccf_diai = null;
        public string Ccf_mesi = null;
        public string Ccf_anioi = null;
        public string Ccf_diaf = null;
        public string Ccf_mesf = null;
        public string Ccf_aniof = null;
        string metodo = "JsonEstadoDE.cs";
        public ComprobanteDocEle LlenarJSONconsulta(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                ComprobanteDocEle comprobanteConJSON = new ComprobanteDocEle();
                DocumentoConsulta documento = new DocumentoConsulta();
                /* Datos de encabezado de la factura */

                documento.encabezado = LlenarEnacabezadoJSON(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);

                comprobanteConJSON.documento = documento;
                return comprobanteConJSON;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarJSONconsulta", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }
        public EncabezadoConsulta LlenarEnacabezadoJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                EncabezadoConsulta encabezado = new EncabezadoConsulta();

                conscabcera = null;
                conscabcera = buscarCabezeraFactura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);

                Modeloempresa = null;
                Modeloempresa = BuscarCabEmpresa(Ccf_usuario, Ccf_cod_emp);

                encabezado.emisor = Convert.ToInt32(Modeloempresa.nro_dgi2);
                encabezado.idsuc = 1;
                encabezado.numero = Convert.ToInt32(conscabcera.nro_docum);
                encabezado.prefijo = Convert.ToString(conscabcera.serie_docum.Trim());
                return encabezado;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarEnacabezadoJSON", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        public modelowmspcempresas BuscarCabEmpresa(string Ccf_usuario, string Ccf_cod_emp)
        {
            try
            {
                ListaModeloempresa = consultaEmpresa.BuscartaEmpresa(Ccf_usuario, Ccf_cod_emp);
                foreach (var item in ListaModeloempresa)
                {
                    Modeloempresa = item;
                    break;
                }

                return Modeloempresa;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarCabEmpresa", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }
        public modelowmtfacturascab buscarCabezeraFactura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                listaConsCab = ConsultaCabe.ConsultaCabFacura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                    conscabcera = item;

                }
                return conscabcera;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "buscarCabezeraFactura", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }
    }
}
