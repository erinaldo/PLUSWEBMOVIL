using CapaDatos.Sql;
using CapaProceso.GenerarPDF.FacturaElectronica;
using CapaProceso.ReslClientePdf;
using CapaProceso.RestCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.FacturaMasiva
{
    public class GenerarPDFDocumentos
    {
        ConsultaLogoSql modelo_documento = new ConsultaLogoSql();
        public string GenerarPDFNotaDebitoElectronica(string Ccf_cod_emp, string cod_proceso, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            string pathPdf = null;
            string tipo_doc = null;

            tipo_doc = modelo_documento.TipoDocImprimir(Ccf_cod_emp, cod_proceso, Ccf_usuario);
            switch (tipo_doc.Trim())
            {
                case "DEFECTO3":
                    PdfNDEleV3Default3 pdf2 = new PdfNDEleV3Default3();
                    pathPdf = pdf2.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO4":
                    PdfNDEleV3Default4 pdf = new PdfNDEleV3Default4();
                    pathPdf = pdf.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
            }
            return pathPdf;
        }

        public string GenerarPDFNotaDebitoNormal(string Ccf_cod_emp, string cod_proceso, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            string pathPdf = null;
            string tipo_doc = null;

            tipo_doc = modelo_documento.TipoDocImprimir(Ccf_cod_emp, cod_proceso, Ccf_usuario);
            switch (tipo_doc.Trim())
            {
                case "DEFECTO3":
                    PdfNDV3Default3 pdf2 = new PdfNDV3Default3();
                    pathPdf = pdf2.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO4":
                    PdfNDV3Default4 pdf = new PdfNDV3Default4();
                    pathPdf = pdf.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
            }
            return pathPdf;
        }

        public string GenerarPDFNotaCreditoElectronica(string Ccf_cod_emp, string cod_proceso, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            string pathPdf = null;
            string tipo_doc = null;

            tipo_doc = modelo_documento.TipoDocImprimir(Ccf_cod_emp, cod_proceso, Ccf_usuario);
            switch (tipo_doc.Trim())
            {
                case "DEFECTO2":
                    PdfNCEleV2Default2 pdf1 = new PdfNCEleV2Default2();
                    pathPdf = pdf1.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO4":
                    PdfNCEleV3Default4 pdf = new PdfNCEleV3Default4();
                    pathPdf = pdf.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO3":
                    PdfNCEleV3Default3 pdf2 = new PdfNCEleV3Default3();
                    pathPdf = pdf2.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
            }
            return pathPdf;
        }

        public string GenerarPDFNotaCreditoNormal(string Ccf_cod_emp, string cod_proceso, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            string pathPdf = null;
            string tipo_doc = null;

            tipo_doc = modelo_documento.TipoDocImprimir(Ccf_cod_emp, cod_proceso, Ccf_usuario);
            switch (tipo_doc.Trim())
            {
                case "DEFECTO2":
                    PdfNCV2Default2 pdf1 = new PdfNCV2Default2();
                    pathPdf = pdf1.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO3":
                    PdfNCV3Default3 pdf2 = new PdfNCV3Default3();
                    pathPdf = pdf2.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO4":
                    PdfNCV3Default4 pdf = new PdfNCV3Default4();
                    pathPdf = pdf.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;

            }
            return pathPdf;
        }

        public string GenerarPDFFacturaElectronica(string Ccf_cod_emp, string cod_proceso, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            string pathPdf = null;
            string tipo_doc = null;

            tipo_doc = modelo_documento.TipoDocImprimir(Ccf_cod_emp, cod_proceso, Ccf_usuario);//busca  version o tipo de pdf para la dian o para imprimir
            switch (tipo_doc.Trim())
            {
                case "DEFECTO2":
                    PdfFacEleV2Default2 pdf = new PdfFacEleV2Default2();
                    pathPdf = pdf.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;

                case "DEFECTO3":
                    PdfFacEleV3Default3 pdf2 = new PdfFacEleV3Default3();
                    pathPdf = pdf2.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO4":
                    PdfFacEleV3Default4 pdf1 = new PdfFacEleV3Default4();
                    pathPdf = pdf1.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO5":
                    PdfFacEleV3Default5 pdf3 = new PdfFacEleV3Default5();
                    pathPdf = pdf3.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO6":
                    PdfFacEleV3Default6 pdf4 = new PdfFacEleV3Default6();
                    pathPdf = pdf4.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO7":
                    PdfFacEleV3Default7 pdf5 = new PdfFacEleV3Default7();
                    pathPdf = pdf5.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO8":
                    PdfFacEleV3Default8 pdf6 = new PdfFacEleV3Default8();
                    pathPdf = pdf6.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO9": //Utilizado unicamente para EValle 23-03-21
                    GenerarPdfValle pdf7 = new GenerarPdfValle();
                    pathPdf = pdf7.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
            }
            return pathPdf;
        }

        public string GenerarPDFFacturaNormal(string Ccf_cod_emp, string cod_proceso, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            string pathPdf = null;
            string tipo_doc = null;

            tipo_doc = modelo_documento.TipoDocImprimir(Ccf_cod_emp, cod_proceso, Ccf_usuario);//busca  version o tipo de pdf para la dian o para imprimir
            switch (tipo_doc.Trim())
            {
                case "DEFECTO2":
                    PdfFacVTAV2 pdf = new PdfFacVTAV2();
                    pathPdf = pdf.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO3":
                    PdfFacVTAV3 pdf3 = new PdfFacVTAV3();
                    pathPdf = pdf3.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO4":
                    PdfFacVTAV4 pdf2 = new PdfFacVTAV4();
                    pathPdf = pdf2.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO5":
                    PdfFacVTAV5 pdf1 = new PdfFacVTAV5();
                    pathPdf = pdf1.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO6":
                    PdfFacVTAV6 pdf4 = new PdfFacVTAV6();
                    pathPdf = pdf4.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO7":
                    PdfFacVTAV7 pdf5 = new PdfFacVTAV7();
                    pathPdf = pdf5.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO8":
                    PdfFacVTAV8 pdf6 = new PdfFacVTAV8();
                    pathPdf = pdf6.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
                case "DEFECTO9": //Utilizado unicamente para EValle 23-03-21
                    GenerarPdfVTAValle pdf7 = new GenerarPdfVTAValle();
                    pathPdf = pdf7.generarPdf(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    break;
            }
            return pathPdf;
        }

    }
}
