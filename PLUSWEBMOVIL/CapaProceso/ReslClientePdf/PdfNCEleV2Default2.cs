using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace CapaProceso.GenerarPDF.FacturaElectronica
{
    public class PdfNCEleV2Default2
    {
        public modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        public modelowmtfacturascab conscabceraTipo = new modelowmtfacturascab();
        public modelowmtfacturascab conscabceraNC = new modelowmtfacturascab();
        public modelowmtfacturascab conscabceraNCMot = new modelowmtfacturascab();
        public List<modelowmtfacturascab> listaConsCabNC = null;
        public List<modelowmtfacturascab> listaConsCabNCMot = null;
        public Consultawmtfacturascab ConsultaCabeNC = new Consultawmtfacturascab();
        public List<modelowmtfacturascab> listaConsCab = null;
        public List<modelowmtfacturascab> listaConsCabTipo = null;
        public Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

       
        public ModeloDetalleFactura consdetalle = new ModeloDetalleFactura();
    
        public List<ModeloDetalleFactura> listaConsDet = null;
      
        public Consultawmtfacturasdet ConsultaDeta = new Consultawmtfacturasdet();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public ConsultawmspctctrxCotizacion consultaMoneda = new ConsultawmspctctrxCotizacion();
        public ConsultaBancos consultabanco = new ConsultaBancos();
        public Consultaparamcomercial consultaComercial = new Consultaparamcomercial();
        public ConsultaEmpresa consultaEmpresa = new ConsultaEmpresa();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();
        public List<modelowmspctctrxCotizacion> ListaModelocotizacion = new List<modelowmspctctrxCotizacion>();
        public List<modelobancos> ListaModelobancos = new List<modelobancos>();
        public List<modelowmspcempresas> ListaModeloempresa = new List<modelowmspcempresas>();
        public List<modeloparametrocomercial> ListaModelocomercial = new List<modeloparametrocomercial>();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public modelowmspcempresas Modeloempresa = new modelowmspcempresas();
        public modeloparametrocomercial Modelocomercial = new modeloparametrocomercial();
        public modelobancos ModeloBancos = new modelobancos();
        public modelowmspctctrxCotizacion ModeloCotizacion = new modelowmspctctrxCotizacion();

        modelowmspcmonedas DecimalesMoneda = new modelowmspcmonedas();
        Consultawmspcmonedas ConsultaCMonedas = new Consultawmspcmonedas();
        List<modelowmspcmonedas> listaMonedas = null;

        public List<JsonRespuestaDSFEV2> ListaModelorespuestaDs = new List<JsonRespuestaDSFEV2>();
        public JsonRespuestaDSFEV2 ModeloResQr = new JsonRespuestaDSFEV2();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();

        Consultawmspcresfact ConsultaResolucion = new Consultawmspcresfact();
        modelowmspcresfact resolucion = new modelowmspcresfact();
        List<modelowmspcresfact> listaRes = null;

        public List<modelowmspcfacturasWMimpuRest> ListaModeloimpuesto = new List<modelowmspcfacturasWMimpuRest>();
        public modelowmspcfacturasWMimpuRest ModeloImpuesto = new modelowmspcfacturasWMimpuRest();
        public ConsultawmspcfacturasWMimpuRest consultaImpuesto = new ConsultawmspcfacturasWMimpuRest();

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
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        Articulos consulta_uni = new Articulos();
        string metodo = "PdfNCEleV2Default2.cs";
        //Buscar cantidad de decimales q se va ausar x tipo de moneda
        public modelowmspcmonedas BuscarDecimales(string usuario, string empresa, string cod_moneda)
        {
            try
            {
                listaMonedas = ConsultaCMonedas.ConsultaCMonedas(usuario, empresa, cod_moneda);

                DecimalesMoneda = null;
                foreach (modelowmspcmonedas item in listaMonedas)
                {

                    DecimalesMoneda = item;
                    break;

                }

                return DecimalesMoneda;
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "BuscarDecimales", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
        public JsonRespuestaDSFEV2 BuscarRespuestaDS(string nro_trans)
        {
            try
            {
                ListaModelorespuestaDs = consultaRespuestaDS.ConsultaResQrDS(nro_trans);

                foreach (var item in ListaModelorespuestaDs)
                {
                    if (item.qrdata != " ")
                    {
                        ModeloResQr = item;
                        break;
                    }

                }

                return ModeloResQr;
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "BuscarRespuestaDS", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }
        public ModeloDetalleFactura buscarDetalleFactura(string nro_trans)
        {
            try
            {
                listaConsDet = ConsultaDeta.ConsultaDetalleFacura(nro_trans);
                int count = 0;
                consdetalle = null;
                foreach (ModeloDetalleFactura item in listaConsDet)
                {
                    count++;
                    consdetalle = item;

                }
                return consdetalle;
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "buscarDetalleFactura", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }

        public modelowmtfacturascab buscarCabezeraFactura( string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
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
                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "buscarCabezeraFactura", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        //Bucar el motivo de anulacion de NC

        public modelowmtfacturascab buscarMotNC(string Ccf_nro_trans)
        {
            try
            {
                listaConsCabNCMot = ConsultaCabeNC.ConsultaNCTransPadre(Ccf_nro_trans);
                int count = 0;
                conscabceraNCMot = null;
                foreach (modelowmtfacturascab item in listaConsCabNCMot)
                {
                    count++;
                    conscabceraNCMot = item;

                }
                return conscabceraNCMot;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "buscarMotNC", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }

        //Consulta DATOS FACTURA
        public modelowmtfacturascab buscarCabezeraNC(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                listaConsCabNC = ConsultaCabeNC.ConsultaCabFacura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                int count = 0;
                conscabceraNC = null;
                foreach (modelowmtfacturascab item in listaConsCabNC)
                {
                    count++;
                    conscabceraNC = item;

                }
                return conscabceraNC;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "buscarCabezeraNC", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }
        public string generarPdf(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                string Tipo = null;
                //Buscar cab NC
                conscabcera = null;
                conscabcera = buscarCabezeraFactura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                //Obtener nro factura
                consdetalle = null;
                consdetalle = buscarDetalleFactura(Ccf_nro_trans);

                //motivo de NC
                conscabceraNCMot = null;
                conscabceraNCMot = buscarMotNC(Ccf_nro_trans);

                //Cantidad de decimales
                DecimalesMoneda = null;
                DecimalesMoneda = BuscarDecimales(Ccf_usuario, Ccf_cod_emp, conscabcera.cod_moneda.Trim());

                //Buscar datos de factura
                //Primero buscar q tipo pos, o vate
                listaConsCabTipo = ConsultaCabe.ConsultaTipoFactura(conscabceraNCMot.nro_trans_padre.Trim());
                conscabceraTipo = null;
                foreach (modelowmtfacturascab item in listaConsCabTipo)
                {

                    conscabceraTipo = item;

                }
                if (conscabceraTipo.tipo_nce.Trim() == "POSE")
                {
                    Tipo = "POSE";
                }
                if (conscabceraTipo.tipo_nce.Trim() == "VTAE")
                {
                    Tipo = "VTAE";

                }

                //CABECERA NC
                conscabceraNC = null;
                conscabceraNC = buscarCabezeraNC(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Tipo, conscabceraNCMot.nro_trans_padre.Trim());

                decimal baseiva19 = 0;
                decimal iva19 = 0;
                decimal baseiva5 = 0;
                decimal iva5 = 0;
                //Obtener totales y base de ivas 19 y 15
                foreach (ModeloDetalleFactura item in listaConsDet)
                {
                    if (item.porc_iva == 19)
                    {
                        baseiva19 += item.base_iva;
                        iva19 += item.valor_iva;
                    }
                    if (item.porc_iva == 15)
                    {
                        baseiva5 += item.base_iva;
                        iva5 += item.valor_iva;
                    }
                }

                Modelowmspclogo = null;
                Modelowmspclogo = BuscarEmpresa(Ccf_cod_emp, Ccf_usuario);

                Modeloempresa = null;
                Modeloempresa = BuscarCabEmpresa(Ccf_usuario, Ccf_cod_emp);

                Modelocomercial = null;
                Modelocomercial = BuscarParametro(Ccf_cod_emp);

                ModeloBancos = null;

                ModeloBancos = BuscarBancos(Ccf_usuario, Ccf_cod_emp, "0", "0", "0", "s");

                ModeloCotizacion = null;
                ModeloCotizacion = BuscarCotizacion(Ccf_usuario, Ccf_cod_emp, Ccf_nro_trans);

                //LIsta Resolucion facturas
                listaRes = ConsultaResolucion.ConsultaResolusiones(Ccf_usuario, Ccf_cod_emp, "0", conscabcera.serie_docum , "C");
                resolucion = null;
                foreach (modelowmspcresfact item in listaRes)
                {
                    resolucion = item;

                }
                //Impuestos
                ListaModeloimpuesto = consultaImpuesto.ImpuestosSinRetencion(Ccf_usuario, Ccf_cod_emp, Ccf_nro_trans, "0","N");


                string pathtmpfac = Modelowmspclogo.pathtmpfac;  //Traemos el path, la ruta 
                string qrPath = pathtmpfac + Ccf_cod_emp.Trim() + Ccf_nro_trans.Trim() + "qrcode.png";
                string bpathPdfGenrado = pathtmpfac + Ccf_cod_emp.Trim() + Ccf_nro_trans.Trim() + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "factura.pdf";
                string qr = ImagenQR(qrPath, Ccf_nro_trans);



                FileStream fs = new FileStream(bpathPdfGenrado, FileMode.Create);
                Document document = new Document(PageSize.A4, 30, 30, 30, 30);
                PdfWriter pw = PdfWriter.GetInstance(document, fs);
             //   pw.PageEvent = new HeaderFooter();



                document.Open();
                /*Tipo de letra y tamaño del documento pdf*/
                var path = HttpContext.Current.Server.MapPath("~/Tema/fonts/VerdanaVf.ttf");
                BaseFont bf = BaseFont.CreateFont(path, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font fontText = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font fontText1 = new iTextSharp.text.Font(bf, 8, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font fontText2 = new iTextSharp.text.Font(bf, 6, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font fontText3 = new iTextSharp.text.Font(bf, 7, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font titulo = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font titulo1 = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font titulo2 = new iTextSharp.text.Font(bf,8, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font tipo1 = new iTextSharp.text.Font(bf, 14, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font tipo2 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font tipo2_n = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font tipo3 = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

                PdfPCell cell = new PdfPCell();//creo variable de celda

                PdfPTable tablaLogo = new PdfPTable(3);//cantidad de columnas que va tener la tabla
                tablaLogo.WidthPercentage = 100;
                tablaLogo.SpacingAfter = 10;
                float[] value23 = new float[3];
                value23[0] = 80;
                value23[1] = 150;
                value23[2] = 120;
                tablaLogo.SetWidths(value23);

                float[] tablaLogo1 = { 0.55f };
                cell = new PdfPCell();
                // Creamos la imagen y le ajustamos el tamaño
                var pathLogo = "";
                pathLogo = HttpContext.Current.Server.MapPath("~/Logo/" + Modelowmspclogo.logo);

                iTextSharp.text.Image imagen1 = iTextSharp.text.Image.GetInstance(pathLogo);
                imagen1.BorderWidth = 0;
                imagen1.Alignment = Element.ALIGN_LEFT;
                float percentage = 0.0f;
                percentage = 110 / imagen1.Width;
                imagen1.ScalePercent(percentage * 100);

                cell = new PdfPCell(imagen1);
                cell.Border = 0;
                tablaLogo.AddCell(cell);

                PdfPTable tabladetaEmpresa = new PdfPTable(1);
                tabladetaEmpresa.WidthPercentage = 100;

                cell = new PdfPCell(new Phrase(Modeloempresa.nom_emp, tipo1));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tabladetaEmpresa.AddCell(cell);

                cell = new PdfPCell(new Phrase("NIT: " + Modeloempresa.nro_dgi2 + "-" + Modeloempresa.nro_dgi1, tipo2));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tabladetaEmpresa.AddCell(cell);

                cell = new PdfPCell(new Phrase(Modeloempresa.dir_tit, tipo3));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tabladetaEmpresa.AddCell(cell);

                cell = new PdfPCell(new Phrase(Modeloempresa.nom_ciudad, tipo3));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tabladetaEmpresa.AddCell(cell);


                cell = new PdfPCell(new Phrase(Modeloempresa.tel_tit + "-" + Modeloempresa.fax_tit, tipo3));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tabladetaEmpresa.AddCell(cell);


                cell = new PdfPCell(new Phrase(Modeloempresa.email_tit, tipo3));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tabladetaEmpresa.AddCell(cell);
                cell = new PdfPCell(new Phrase("Resolucion Nota Credito Electronica N°." + resolucion.cod_atrib1, fontText3)); //7 tamaño
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tabladetaEmpresa.AddCell(cell);

                cell = new PdfPCell(new Phrase("Vigencia "+resolucion.meses+ " meses desde " + resolucion.fec_emision + " hasta " + resolucion.fec_caducidad, fontText3)); //7 tamaño
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tabladetaEmpresa.AddCell(cell);

                cell = new PdfPCell(new Phrase("Habilita el prefijo " + resolucion.prefijo + " desde " + resolucion.nro_docum + " hasta " + resolucion.nro_docum_ref, fontText3)); //7 tamaño
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tabladetaEmpresa.AddCell(cell);

                cell = new PdfPCell(tabladetaEmpresa);//this line made the difference
                cell.HorizontalAlignment = 1;
                cell.Border = 0;
                tablaLogo.AddCell(cell);

                PdfPTable tabladetaEmpresa1 = new PdfPTable(1);
                tabladetaEmpresa1.WidthPercentage = 100;

                cell = new PdfPCell(new Phrase("NOTA CRÉDITO ELECTRÓNICA ", tipo1));
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 1;
                tabladetaEmpresa1.AddCell(cell);

                cell = new PdfPCell(new Phrase(" "));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 1;
                tabladetaEmpresa1.AddCell(cell);

                cell = new PdfPCell(new Phrase("Nro. " + conscabcera.serie_docum + " - " + conscabcera.nro_docum, tipo1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 1;
                tabladetaEmpresa1.AddCell(cell);

                cell = new PdfPCell(new Phrase("Fecha Emision: " + conscabcera.fec_doc_str, tipo2_n));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 1;
                cell.HorizontalAlignment = 1;
                tabladetaEmpresa1.AddCell(cell);

                cell = new PdfPCell(new Paragraph("ESTADO DIAN: APROBADO", fontText1)); //LETRA 8
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right  
                tabladetaEmpresa1.AddCell(cell);

                cell = new PdfPCell(new Phrase(" "));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right  
                tabladetaEmpresa1.AddCell(cell);

                cell = new PdfPCell(new Paragraph("FECHA ESTADO: " + conscabcera.fec_doc_str, fontText1)); //LETRA 8
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 1;
                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right  
                tabladetaEmpresa1.AddCell(cell);

                cell = new PdfPCell(tabladetaEmpresa1);//this line made the difference
                cell.HorizontalAlignment = 1;
                cell.Border = 0;
                tablaLogo.AddCell(cell);
                document.Add(tablaLogo);

                //Llenar cabecera con clase celdas
                PdfPTable tablaCab = new PdfPTable(5);
                tablaCab.WidthPercentage = 100;
                tablaCab.SpacingAfter = 10;
                cell = new PdfPCell();

                float[] value = new float[5];
                value[0] = 25;
                value[1] = 100;
                value[2] = 20;
                value[3] = 60;
                value[4] = 90;
                tablaCab.SetWidths(value);

                float[] tablaCab4 = { 0.55f };
                cell = new PdfPCell();


                PdfPTable tablaCab1 = new PdfPTable(1);
                tablaCab1.WidthPercentage = 100;
                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph("Cliente:", fontText1));
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                tablaCab1.AddCell(cell);

                cell = new PdfPCell(new Paragraph("NIT/CC:", fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaCab1.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Direccion:", fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                tablaCab1.AddCell(cell);
                
                cell = new PdfPCell(new Paragraph("Telefono:", fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                tablaCab1.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Ciudad:", fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaCab1.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Email:", fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                tablaCab1.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Sucursal:", fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 1;
                cell.HorizontalAlignment = 0;
                tablaCab1.AddCell(cell);
                //FIN PRIMERA TABLA


                cell = new PdfPCell(tablaCab1);
                cell.HorizontalAlignment = 1;
                cell.Border = 0;
                tablaCab.AddCell(cell); //añadir a tabla prinipal

                //Tablas dos
                PdfPTable tablaCab3 = new PdfPTable(1);
                tablaCab3.WidthPercentage = 100;
                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph(conscabcera.nom_tit, fontText1));
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                tablaCab3.AddCell(cell);

                cell = new PdfPCell(new Paragraph(conscabcera.nro_dgi2 + "-" + conscabcera.nro_dgi1, fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                tablaCab3.AddCell(cell);

                cell = new PdfPCell(new Paragraph(conscabcera.dir_tit, fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                tablaCab3.AddCell(cell);
                if (conscabcera.tel_tit == "")
                {
                    cell = new PdfPCell(new Paragraph(" ", fontText1));
                    cell.BorderWidthTop = 0;
                    cell.BorderWidthRight = 0;
                    cell.BorderWidthLeft = 0;
                    cell.BorderWidthBottom = 0;
                    cell.HorizontalAlignment = 0;
                    tablaCab3.AddCell(cell);
                }
                else {
                    cell = new PdfPCell(new Paragraph(conscabcera.tel_tit, fontText1));
                    cell.BorderWidthTop = 0;
                    cell.BorderWidthRight = 0;
                    cell.BorderWidthLeft = 0;
                    cell.BorderWidthBottom = 0;
                    cell.HorizontalAlignment = 0;
                    tablaCab3.AddCell(cell);
                }
             

                cell = new PdfPCell(new Paragraph(conscabcera.nom_ciudad, fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaCab3.AddCell(cell);

                cell = new PdfPCell(new Paragraph(conscabcera.email_tit, fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                tablaCab3.AddCell(cell);

                cell = new PdfPCell(new Paragraph(conscabcera.codnom_suc, fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 1;
                cell.HorizontalAlignment = 0;
                tablaCab3.AddCell(cell);

                //FIN PRIMERA TABLA

                cell = new PdfPCell(tablaCab3);
                cell.HorizontalAlignment = 1;
                cell.Border = 0;
                tablaCab.AddCell(cell);
                //-------------------fin tablal dos
                cell = new PdfPCell();
                cell.HorizontalAlignment = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 1;
                tablaCab.AddCell(cell);

                PdfPTable tablaCab2 = new PdfPTable(1); //tablas 3
                tablaCab2.WidthPercentage = 100;
                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph("Fecha Factura a aplicar:", fontText1));
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                tablaCab2.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Factura a aplicar:", fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                tablaCab2.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Forma Pago:", fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                tablaCab2.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Fecha Vto:", fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                tablaCab2.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Moneda:", fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                tablaCab2.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Vendedor:", fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 1;
                cell.HorizontalAlignment = 0;
                tablaCab2.AddCell(cell);

                cell = new PdfPCell(tablaCab2);
                cell.HorizontalAlignment = 0;
                cell.Border = 0;
                tablaCab.AddCell(cell); //añadir a tabla prinipal

                PdfPTable tablaCab5 = new PdfPTable(1); //tablas 4
                tablaCab5.WidthPercentage = 100;
                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph(conscabceraNC.fec_doc_str, fontText1));
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                tablaCab5.AddCell(cell);

                cell = new PdfPCell(new Paragraph(conscabceraNC.observacion, fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                tablaCab5.AddCell(cell);

                cell = new PdfPCell(new Paragraph(conscabcera.nom_fpago, fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                tablaCab5.AddCell(cell);

                cell = new PdfPCell(new Paragraph(conscabcera.fec_venc_str, fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                tablaCab5.AddCell(cell);

                cell = new PdfPCell(new Paragraph(conscabcera.cod_moneda, fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                tablaCab5.AddCell(cell);

                cell = new PdfPCell(new Paragraph(conscabcera.nom_vendedor, fontText1));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthBottom = 1;
                cell.HorizontalAlignment = 0;
                tablaCab5.AddCell(cell);

                cell = new PdfPCell(tablaCab5);
                cell.HorizontalAlignment = 0;
                cell.Border = 0;
                tablaCab.AddCell(cell); //añadir a tabla prinipal

                document.Add(tablaCab);



                //opcion detalle cabcera
                PdfPTable detacab = new PdfPTable(7);//cantidad de columnas que va tener la tabla
                detacab.WidthPercentage = 100;
               
               // detacab.DefaultCell.BackgroundColor(193, 185, 172);
                // detacab.SpacingBefore = 5;
                float[] values = new float[7];
                values[0] = 90;
                values[1] = 300;
                values[2] = 60;
                values[3] = 70;
                values[4] = 110;
                values[5] = 70;
                values[6] = 110;
               // values[6] = 110;
                detacab.SetWidths(values);

                float[] detacabs = { 0.55f };
                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph("CÓDIGO", titulo2));
               
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                cell.BackgroundColor = new BaseColor(220, 217, 211);
                detacab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("DESCRIPCION", titulo2));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                cell.BackgroundColor = new BaseColor(220, 217, 211);
                detacab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("UM", titulo2));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                cell.BackgroundColor = new BaseColor(220, 217, 211);
                detacab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("CANT", titulo2));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                cell.BackgroundColor = new BaseColor(220, 217, 211);
                detacab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("P.UNIT", titulo2));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                cell.BackgroundColor = new BaseColor(220, 217, 211);
                detacab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("%IVA", titulo2));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                cell.BackgroundColor = new BaseColor(220, 217, 211);
                detacab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("SUBTOTAL", titulo2));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                cell.BackgroundColor = new BaseColor(220, 217, 211);
                detacab.AddCell(cell);

                document.Add(detacab);



                //Cargar Detalle factura
                PdfPTable detalle = new PdfPTable(7);//cantidad de columnas que va tener la tabla
                detalle.WidthPercentage = 100f;
                float[] alto = { 150f, 150f, 150f };
                
                // detalle.SpacingAfter = 10;
                //detalle.DefaultCell.Border = 0;
                detalle.DefaultCell.BorderWidthBottom = 0;
                detalle.DefaultCell.BorderWidthLeft = 1;
                detalle.DefaultCell.BorderWidthTop = 0;
                detalle.DefaultCell.BorderWidthRight = 1;
               
                values = new float[7];
              
                values[0] = 90;
                values[1] = 300;
                values[2] = 60;
                values[3] = 70;
                values[4] = 110;
                values[5] = 70;
                values[6] = 110;
                // values[6] = 110;

                detalle.HorizontalAlignment = 2;
                detalle.SetWidths(values);
                int contadorEspacio = 0;

                foreach (ModeloDetalleFactura item in listaConsDet)
                {
                    contadorEspacio ++;
                    if (item.cod_articulo2 == null || item.cod_articulo2 == "")
                    { detalle.DefaultCell.HorizontalAlignment = 0; detalle.AddCell(new Paragraph(item.cod_articulo, fontText3)); }
                    else
                    {
                        detalle.DefaultCell.HorizontalAlignment = 0; detalle.AddCell(new Paragraph(item.cod_articulo2, fontText3));
                    }
                    detalle.DefaultCell.HorizontalAlignment = 0; detalle.AddCell(new Paragraph(item.nom_articulo+ " "+ item.nom_articulo2.Trim(), fontText3));
                    string unidad = consulta_uni.UnidadMedida(Ccf_cod_emp, Ccf_usuario, item.cod_articulo.Trim());
                    detalle.DefaultCell.HorizontalAlignment = 1; detalle.AddCell(new Paragraph(unidad, fontText3));
                   // decimal cantidadP = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, item.cantidad);
                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(ConsultaCMonedas.FormatorNumero(Modelowmspclogo.cantidad_decimal.ToString(), item.cantidad), fontText3));
                  //  decimal precio_un1 = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo_pu, item.precio_unit);
                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(ConsultaCMonedas.FormatorNumero(Modelowmspclogo.pvp_decimal.ToString(), item.precio_unit), fontText3));

                    decimal porc_des = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, item.porc_iva);
                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(porc_des.ToString(), fontText3));

                    decimal precio_un = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo_pu, item.subtotal);
                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, precio_un), fontText3));

                }
                for (int i = 0; i <18-contadorEspacio; i++)
                {
                    detalle.DefaultCell.HorizontalAlignment = 0; detalle.AddCell(new Paragraph(" ", fontText3));
                    detalle.DefaultCell.HorizontalAlignment = 0; detalle.AddCell(new Paragraph(" ", fontText3));
                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(" ", fontText3));
                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(" ", fontText3));
                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(" ", fontText3));
                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(" ", fontText3));
                }
                detalle.DefaultCell.BorderWidthTop = 1;
                document.Add(detalle);

                PdfPTable total11 = new PdfPTable(4);//cantidad de columnas que va tener la tabla
                total11.WidthPercentage = 100;
                total11.SpacingAfter = 10;
                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph(""));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 0;
                cell.Colspan = 4;
                total11.AddCell(cell);
                document.Add(total11);
                //TABLA DE IMPUESTO PTINCIPAL CN TRES COLUMNAS
                PdfPTable detaimp = new PdfPTable(3);//cantidad de columnas que va tener la tabla
                detaimp.WidthPercentage = 100;
                detaimp.SpacingAfter = 10;
                float[] valor = new float[3];
                valor[0] = 120;
                valor[1] = 10;
                valor[2] = 70;
                detaimp.SetWidths(valor);

                float[] detaimps = { 0.55f };
                cell = new PdfPCell();

                //tabla totales tabla principal
                PdfPTable total1 = new PdfPTable(4);//cantidad de columnas que va tener la tabla
                total1.WidthPercentage = 100;
               // total1.SpacingAfter = 10;
                cell = new PdfPCell();

                float[] val = new float[4];
                val[0] = 100;
                val[1] = 30;
                val[2] = 60;
                val[3] = 70;
                total1.SetWidths(val);

                float[] total1s = { 0.55f };
                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph("IMPUESTOS, RETENCIONES Y DESCUENTOS", titulo2));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                cell.BackgroundColor = new BaseColor(220, 217, 211);
                cell.Colspan = 4;
                total1.AddCell(cell);

                cell = new PdfPCell(new Paragraph("DESCRIPCION", titulo2));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.BackgroundColor = new BaseColor(220, 217, 211);
                cell.HorizontalAlignment = 1;
                total1.AddCell(cell);

                cell = new PdfPCell(new Paragraph("%", titulo2));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.BackgroundColor = new BaseColor(220, 217, 211);
                cell.HorizontalAlignment = 1;
                total1.AddCell(cell);

                cell = new PdfPCell(new Paragraph("BASE", titulo2));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.BackgroundColor = new BaseColor(220, 217, 211);
                cell.HorizontalAlignment = 1;
                total1.AddCell(cell);

                cell = new PdfPCell(new Paragraph("VALOR", titulo2));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.BackgroundColor = new BaseColor(220, 217, 211);
                cell.HorizontalAlignment = 1;
                total1.AddCell(cell);

                foreach (modelowmspcfacturasWMimpuRest item in ListaModeloimpuesto)
                {

                    total1.DefaultCell.HorizontalAlignment = 0; total1.AddCell(new Paragraph(item.nom_impuesto, fontText3));
                    total1.DefaultCell.HorizontalAlignment = 2; total1.AddCell(new Paragraph(item.porc_impu1, fontText3));
                    total1.DefaultCell.HorizontalAlignment = 2; total1.AddCell(new Paragraph(item.base_impu1, fontText3));
                    total1.DefaultCell.HorizontalAlignment = 2; total1.AddCell(new Paragraph(item.valor_impu1, fontText3));

                }

                cell = new PdfPCell(total1);
                cell.Border = 0;
                detaimp.AddCell(cell);

                cell = new PdfPCell();
                cell.Border = 0;
                detaimp.AddCell(cell);

                PdfPTable detatot = new PdfPTable(2);//cantidad de columnas que va tener la tabla
                detatot.WidthPercentage = 100;
                cell = new PdfPCell();

                float[] val_tot = new float[2];
                val_tot[0] = 40;
                val_tot[1] = 60;
                total1.SetWidths(val);

                float[] deta_tot1 = { 0.55f };
                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph("TOTALES ", titulo2));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                cell.BackgroundColor = new BaseColor(220, 217, 211);
                cell.Colspan = 2;
                detatot.AddCell(cell);

                cell = new PdfPCell(new Paragraph("SUBTOTAL: ", fontText1));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 0;
                detatot.AddCell(cell);

                decimal subtotal1 = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, conscabcera.subtotal);
                cell = new PdfPCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, subtotal1), fontText1));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 2;
                detatot.AddCell(cell);

                cell = new PdfPCell(new Paragraph("DESCUENTOS: ", fontText1));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 0;
                detatot.AddCell(cell);

                decimal descuento = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, conscabcera.descuento);
                cell = new PdfPCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, descuento), fontText1));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 2;
                detatot.AddCell(cell);


                cell = new PdfPCell(new Paragraph("IVA: ", fontText1));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 0;
                detatot.AddCell(cell);

                decimal tiva19 = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, conscabcera.iva);
                cell = new PdfPCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, tiva19), fontText1));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 2;
                detatot.AddCell(cell);



                cell = new PdfPCell(new Paragraph("TOTAL FACTURA:", titulo2));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 0;
                detatot.AddCell(cell);

                decimal Total = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, conscabcera.total);
                cell = new PdfPCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, Total), titulo2));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 2;
                detatot.AddCell(cell);

                cell = new PdfPCell(new Paragraph("RETENCIONES: ", fontText1));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 0;
                detatot.AddCell(cell);

                decimal base19 = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, conscabcera.impuesto5);
                cell = new PdfPCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, base19), fontText1));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 2;
                detatot.AddCell(cell);

                cell = new PdfPCell(new Paragraph("NETO A PAGAR: ", titulo2));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 0;
                detatot.AddCell(cell);


                decimal base5 = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, conscabcera.Saldo);
                cell = new PdfPCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, base5), titulo2));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 2;
                detatot.AddCell(cell);

                cell = new PdfPCell(detatot);//this line made the difference
                detaimp.AddCell(cell);
                document.Add(detaimp);

                //VALOR EN LETRAS
                PdfPTable pago_letras = new PdfPTable(1);//cantidad de columnas que va tener la tabla
                pago_letras.WidthPercentage = 100;
                pago_letras.SpacingAfter = 10;
                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph(conscabcera.vlr_letras, fontText3));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 0;
                pago_letras.AddCell(cell);
                document.Add(pago_letras);



                PdfPTable detainfotri2 = new PdfPTable(1);//cantidad de columnas que va tener la tabla
                detainfotri2.WidthPercentage = 100;
                //detainfotri2.SpacingAfter = 10;
                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph("INFORMACION ADICIONAL", titulo2));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                cell.BackgroundColor = new BaseColor(220, 217, 211);
                detainfotri2.AddCell(cell);
                document.Add(detainfotri2);

                PdfPTable deta_infotri2 = new PdfPTable(1);//cantidad de columnas que va tener la tabla
                deta_infotri2.WidthPercentage = 100;
                deta_infotri2.SpacingAfter = 10;
                cell = new PdfPCell();
                //vuentas de banco
                
                foreach (modelobancos item in ListaModelobancos)
                {

                    deta_infotri2.DefaultCell.BorderWidthBottom = 0; deta_infotri2.DefaultCell.BorderWidthTop = 0; deta_infotri2.AddCell(new Paragraph((item.nomtcta_banco) + (" " + "Nro " + (item.nrocta_banco)) + " " + "de " + " " + (item.nom_tit.ToString()), fontText1));
                }

                cell = new PdfPCell(new Paragraph(Modelocomercial.letra_cambio4, fontText2));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 1;
                cell.HorizontalAlignment = 0;
                deta_infotri2.AddCell(cell);

               /* cell = new PdfPCell(new Paragraph(Modelocomercial.letra_cambio2, fontText2));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                deta_infotri2.AddCell(cell);

                cell = new PdfPCell(new Paragraph(Modelocomercial.letra_cambio3, fontText2));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 1;
                cell.HorizontalAlignment = 0;
                deta_infotri2.AddCell(cell);*/
                document.Add(deta_infotri2);
                //observaciones
                PdfPTable obser = new PdfPTable(1);//cantidad de columnas que va tener la tabla
                obser.WidthPercentage = 100;
                obser.SpacingAfter = 10;
                cell = new PdfPCell();
                cell.Border = 0;

                cell = new PdfPCell(new Paragraph("Observaciones: ", fontText3));
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = 0;
                obser.AddCell(cell);

                cell = new PdfPCell(new Paragraph(conscabcera.observaciones, fontText3));
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthBottom = 1;
                cell.HorizontalAlignment = 0;
                obser.AddCell(cell);
   
                document.Add(obser);
                //informacion tributaria
                PdfPTable infotri = new PdfPTable(2);//cantidad de columnas que va tener la tabla
                infotri.WidthPercentage = 100;
                infotri.SpacingAfter = 10;
                cell = new PdfPCell();

                float[] val_info = new float[2];
                val_info[0] = 20;
                val_info[1] = 100;
                infotri.SetWidths(val_info);

                float[] deta_tot2 = { 0.55f };
                cell = new PdfPCell();

                iTextSharp.text.Image imagenp = iTextSharp.text.Image.GetInstance(qr);
                imagenp.Border = 0;
                imagenp.Alignment = Element.ALIGN_RIGHT;
                imagenp.ScaleAbsolute(50f, 50f);

                cell = new PdfPCell(imagenp);
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                infotri.AddCell(cell);

                PdfPTable infotri1 = new PdfPTable(1);//cantidad de columnas que va tener la tabla
                infotri1.WidthPercentage = 100;
                cell = new PdfPCell();
                cell.Border = 0;
 
                cell = new PdfPCell(new Paragraph(Modelocomercial.info_trib1, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                infotri1.AddCell(cell);

                cell = new PdfPCell(new Paragraph("CUFE: " + ModeloResQr.cufe, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                infotri1.AddCell(cell);

                DateTime prueba = DateTime.Now;
                cell = new PdfPCell(new Paragraph("Fecha hora expedición: " + prueba.ToString(), fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                infotri1.AddCell(cell);

                cell = new PdfPCell(infotri1);
                cell.Border = 0;
                infotri.AddCell(cell);
                document.Add(infotri); //imprime la tablas

               
      

                document.Close();

                return bpathPdfGenrado;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "generarPdf", e.ToString(), DateTime.Today, Ccf_usuario);
                return "No se pudo completar la acción." + "generarPdf." + " Por favor notificar al administrador.";
            }
        }

    public  class HeaderFooter: PdfPageEventHelper
        {
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                // base.OnEndPage(writer, document);
                //Cabcera 
                var path = HttpContext.Current.Server.MapPath("~/Tema/fonts/VerdanaVf.ttf");
                BaseFont bf = BaseFont.CreateFont(path, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font fontText = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font fontText1 = new iTextSharp.text.Font(bf, 8, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font fontText2 = new iTextSharp.text.Font(bf, 6, iTextSharp.text.Font.NORMAL);

                PdfPTable tbHeader = new PdfPTable(3);
                tbHeader.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                tbHeader.DefaultCell.Border = 0;
                tbHeader.AddCell(new Paragraph());
                tbHeader.AddCell(new Paragraph());
                PdfPCell cell = new PdfPCell(new Paragraph("Página "+ writer.CurrentPageNumber, fontText2));
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.Border = 0;
                tbHeader.AddCell(cell);
                tbHeader.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetTop(document.TopMargin), writer.DirectContent);


            }
        }

        public string ImagenQR(string qrPath, string Ccf_nro_trans)
        {
            try
            {
                ModeloResQr = null;  //Traemos el QR respuesta
                ModeloResQr = BuscarRespuestaDS(Ccf_nro_trans);
                string texto = "";
                if (ModeloResQr != null)
                {
                    texto = ModeloResQr.qrdata;
                }
                else
                {
                    texto = "No existe datos";
                }

                var qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                var qrCode = qrEncoder.Encode(texto);

                var renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);
                using (var stream = new FileStream(qrPath, FileMode.Create))
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);
                return qrPath;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ImagenQR", e.ToString(), DateTime.Today, "consulta");
                return "No se pudo completar la acción." + "ImagenQR." + " Por favor notificar al administrador.";
            }
        }

        public PdfPCell cabezera(string mensaje)
        {
            Paragraph contenido = new Paragraph();
            contenido.Font = FontFactory.GetFont(FontFactory.TIMES, 14f, BaseColor.BLACK);

            contenido.Add(mensaje);
            contenido.Alignment = Element.ALIGN_CENTER;

            PdfPCell cell = new PdfPCell(contenido);

            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 0;

            return cell;
        }

        public PdfPCell celdas(string mensaje)
        {
            Paragraph contenido = new Paragraph();
            contenido.Font = FontFactory.GetFont(FontFactory.TIMES, 10f, BaseColor.BLACK);

            contenido.Add(mensaje);
            contenido.Alignment = Element.ALIGN_CENTER;

            PdfPCell cell = new PdfPCell(contenido);

            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;

            return cell;
        }

        public PdfPCell total(string mensaje)
        {
            Paragraph contenido = new Paragraph();
            contenido.Font = FontFactory.GetFont(FontFactory.TIMES, 11f, BaseColor.BLACK);

            contenido.Add(mensaje);
            contenido.Alignment = Element.ALIGN_RIGHT;

            PdfPCell cell = new PdfPCell(contenido);

            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;

            return cell;
        }
        public PdfPCell celdasD(string mensaje)
        {
            Paragraph contenido = new Paragraph();
            contenido.Font = FontFactory.GetFont(FontFactory.TIMES, 10f, BaseColor.BLACK);

            contenido.Add(mensaje);
            contenido.Alignment = Element.ALIGN_LEFT;

            PdfPCell cell = new PdfPCell(contenido);

            cell.BorderWidthBottom = 1;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthTop = 1;
            cell.BorderWidthRight = 1;

            return cell;
        }

        public modelowmspclogo BuscarEmpresa(string empresa, string usuario)
        {
            try
            {
                ListaModelowmspclogo = consultaLogo.BuscartaLogo(empresa, usuario);
                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }

                return Modelowmspclogo;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "BuscarEmpresa", e.ToString(), DateTime.Today,usuario);
                return null;
            }
        }
        public modelowmspctctrxCotizacion BuscarCotizacion(string usuario, string empresa,string nro_trans)
        {
            try
            {
                ListaModelocotizacion = consultaMoneda.BuscartatrmCotizacion(usuario, empresa, nro_trans);
                foreach (var item in ListaModelocotizacion)
                {
                    ModeloCotizacion = item;
                    break;
                }

                return ModeloCotizacion;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "BuscarCotizacion", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }

        public modelobancos BuscarBancos(string empresa, string usuario,  string banco, string tipo, string cuenta, string imprime)
        {
            try
            {
                ListaModelobancos = consultabanco.BuscartaBancos(empresa, usuario, banco, tipo, cuenta, imprime);
                foreach (var item in ListaModelobancos)
                {
                    ModeloBancos = item;
                    break;
                }

                return ModeloBancos;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "BuscarBancos", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
        public modeloparametrocomercial BuscarParametro(string empresa)
        {
            try
            {
                ListaModelocomercial = consultaComercial.BuscartaComercial(empresa);
                foreach (var item in ListaModelocomercial)
                {
                    Modelocomercial = item;
                    break;
                }

                return Modelocomercial;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "BuscarParametro", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
        public modelowmspcempresas BuscarCabEmpresa(string usuario, string empresa)
        {
            try
            {
                ListaModeloempresa = consultaEmpresa.BuscartaEmpresa(usuario, empresa);
                foreach (var item in ListaModeloempresa)
                {
                    Modeloempresa = item;
                    break;
                }

                return Modeloempresa;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "BuscarCabEmpresa", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
        
    }
}