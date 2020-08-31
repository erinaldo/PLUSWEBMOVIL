using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using CapaProceso.RestClientePdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO;
using Ionic.Zip;

namespace CapaProceso.ReslClientePdf
{
    public class JsonFacElecVer3PDF
    {
        public List<modelowmspcempresas> ListaModeloempresa = new List<modelowmspcempresas>();
        public ConsultaEmpresa consultaEmpresa = new ConsultaEmpresa();
        public modelowmspcempresas Modeloempresa = new modelowmspcempresas();

        public modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        public List<modelowmtfacturascab> listaConsCab = null;
        public Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

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
        public string nro_trans = null;
        public string Ven__cod_tipotit = "cliente";
        public string Ven__cod_tit = " ";
        public string impuesto_rest = "0";
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "JsonFacElecVer3PDF.cs";
        public JsonFacturaElecVer3 RespuestaJSONPdf(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string pdfbase64)
        {
            try
            {
                JsonFacturaElecVer3 jsonPdf = new JsonFacturaElecVer3();
                EncabezadoFEV3 encabezado = new EncabezadoFEV3();
                DocumentoFEV3 documento = new DocumentoFEV3();
                /* Datos de encabezado de la factura */
                encabezado = LlenarEnacabezadoPdfJSON(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, pdfbase64);
                documento.encabezado = encabezado;
                jsonPdf.documento = documento;



                return jsonPdf;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "RespuestaJSONPdf", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        public EncabezadoFEV3 LlenarEnacabezadoPdfJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string pdfbase64)
        {
            try
            {
                EncabezadoFEV3 encabezado = new EncabezadoFEV3();


                conscabcera = null;
                conscabcera = buscarCabezeraFactura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                ListaModelowmspclogo = consultaLogo.BuscartaLogo(Ccf_cod_emp, Ccf_usuario);
                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }
                string pathtmpfac = Modelowmspclogo.path_adjunto;  //Traemos el path, la ruta 
                string pathDocGenerado = Ccf_cod_emp.Trim() + Ccf_nro_trans.Trim() + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "Adjunto.zip";
                string nombre_pathDocGenerado = pathtmpfac + pathDocGenerado;
                string doc_adjunto = conscabcera.doc_adjunto;
                string path_zip = nombre_pathDocGenerado;


                using (ZipFile zip = new ZipFile())
                {
                    zip.AddFile(doc_adjunto, "files");

                    zip.Save(nombre_pathDocGenerado);
                }

                byte[] DocBytes = File.ReadAllBytes(path_zip);
                string DocBase64 = Convert.ToBase64String(DocBytes);//Convierto el pdf en base 64

                Modeloempresa = null;
                Modeloempresa = BuscarCabEmpresa(Ccf_usuario, Ccf_cod_emp);


                encabezado.emisor = Convert.ToInt32(Modeloempresa.nro_dgi2);
                encabezado.idsuc = 1;
                encabezado.numero = Convert.ToInt32(conscabcera.nro_docum);
                encabezado.prefijo = Convert.ToString(conscabcera.serie_docum.Trim());
                encabezado.contenidopdf = pdfbase64;
                encabezado.adjuntocontenido = DocBase64;
                encabezado.adjuntonombre = pathDocGenerado;

                return encabezado;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarEnacabezadoPdfJSON", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }
        public modelowmtfacturascab buscarCabezeraFactura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                listaConsCab = ConsultaCabe.ConsultaCabFacura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                int count = 0;
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                    count++;
                    conscabcera = item;

                }
                return conscabcera;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "buscarCabezeraFactura", e.ToString(), DateTime.Today, Ccf_usuario);
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



    }
}
