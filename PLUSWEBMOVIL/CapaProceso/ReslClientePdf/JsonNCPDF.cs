using CapaDatos.Modelos;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using CapaProceso.RestCliente;
using CapaProceso.RestClientePdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.ReslClientePdf
{
    public class JsonNCPDF
    {
        public List<modelowmspcempresas> ListaModeloempresa = new List<modelowmspcempresas>();
        public ConsultaEmpresa consultaEmpresa = new ConsultaEmpresa();
        public modelowmspcempresas Modeloempresa = new modelowmspcempresas();

        public modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        public List<modelowmtfacturascab> listaConsCab = null;
        public Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

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
        public JsonPdfNCElectronica RespuestaJSONPdf(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string pdfbase64)
        {
            JsonPdfNCElectronica jsonPdf = new JsonPdfNCElectronica();
            EncabezadoNCR encabezado = new EncabezadoNCR();
            DocumentoNCR documento = new DocumentoNCR();
            /* Datos de encabezado de la factura */
            encabezado = LlenarEnacabezadoPdfJSON(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, pdfbase64);
            documento.encabezado = encabezado;
            jsonPdf.documento = documento;



            return jsonPdf;
        }

        public EncabezadoNCR LlenarEnacabezadoPdfJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string pdfbase64)
        {
            EncabezadoNCR encabezado = new EncabezadoNCR();

            conscabcera = null;
            conscabcera = buscarCabezeraFactura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);

            Modeloempresa = null;
            Modeloempresa = BuscarCabEmpresa(Ccf_usuario, Ccf_cod_emp);

           
           encabezado.emisor = Convert.ToInt32(Modeloempresa.nro_dgi2);
            encabezado.idsuc = 1;
            encabezado.numero = Convert.ToInt32(conscabcera.nro_docum);
            encabezado.prefijo = Convert.ToString(conscabcera.serie_docum.Trim());
            encabezado.contenidopdf = pdfbase64;

            return encabezado;
        }
        public modelowmtfacturascab buscarCabezeraFactura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
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
        public modelowmspcempresas BuscarCabEmpresa(string Ccf_usuario, string Ccf_cod_emp)
        {
            ListaModeloempresa = consultaEmpresa.BuscartaEmpresa(Ccf_usuario, Ccf_cod_emp);
            foreach (var item in ListaModeloempresa)
            {
                Modeloempresa = item;
                break;
            }

            return Modeloempresa;
        }


    }
}
