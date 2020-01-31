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
    public class PdfFacEleV2Default
    {
       public modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        public ModeloDetalleFactura consdetalle = new ModeloDetalleFactura();
        public List<modelowmtfacturascab> listaConsCab = null;
        public List<ModeloDetalleFactura> listaConsDet = null;
        public Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();
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
        string metodo = "PdfFacturaElectronica.cs";
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
                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "BuscarRespuestaDS", e.ToString(), DateTime.Today, "consulta");
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
                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "buscarDetalleFactura", e.ToString(), DateTime.Today, "consulta");
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
                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "buscarCabezeraFactura", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }
        public string generarPdf(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                conscabcera = null;
                conscabcera = buscarCabezeraFactura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);

                consdetalle = null;
                consdetalle = buscarDetalleFactura(Ccf_nro_trans);

                //Cantidad de decimales
                DecimalesMoneda = null;
                DecimalesMoneda = BuscarDecimales(Ccf_usuario, Ccf_cod_emp, conscabcera.cod_moneda.Trim());

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
                listaRes = ConsultaResolucion.ConsultaResolusiones(Ccf_usuario, Ccf_cod_emp, "S", "0", "F");
                resolucion = null;
                foreach (modelowmspcresfact item in listaRes)
                {
                    resolucion = item;

                }



                string pathtmpfac = Modelowmspclogo.pathtmpfac;  //Traemos el path, la ruta 
                string qrPath = pathtmpfac + Ccf_cod_emp.Trim() + Ccf_nro_trans.Trim() + "qrcode.png";
                string bpathPdfGenrado = pathtmpfac + Ccf_cod_emp.Trim() + Ccf_nro_trans.Trim() + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "factura.pdf";
                string qr = ImagenQR(qrPath, Ccf_nro_trans);



                FileStream fs = new FileStream(bpathPdfGenrado, FileMode.Create);
                Document document = new Document(PageSize.A4, 30, 30, 30, 30);
                PdfWriter pw = PdfWriter.GetInstance(document, fs);
                pw.PageEvent = new HeaderFooter();



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

                PdfPCell cell = new PdfPCell();//creo variable de celda

                PdfPTable tablaLogo = new PdfPTable(4);//cantidad de columnas que va tener la tabla
                tablaLogo.WidthPercentage = 100;
                // Creamos la imagen y le ajustamos el tamaño
                var pathLogo = "";
                pathLogo = HttpContext.Current.Server.MapPath("~/Logo/" + Modelowmspclogo.logo);

                iTextSharp.text.Image imagen1 = iTextSharp.text.Image.GetInstance(pathLogo);
                imagen1.BorderWidth = 0;
                imagen1.Alignment = Element.ALIGN_RIGHT;
                float percentage = 0.0f;
                percentage = 150 / imagen1.Width;
                imagen1.ScalePercent(percentage * 100);

                cell = new PdfPCell(imagen1);
                cell.Border = 0;
                tablaLogo.AddCell(cell);

                PdfPTable tabladetaEmpresa = new PdfPTable(1);
                tabladetaEmpresa.WidthPercentage = 100;

                cell = new PdfPCell(new Phrase(""));
                cell.Border = 0;
                cell.HorizontalAlignment = 1;
                tabladetaEmpresa.AddCell(cell);

                cell = new PdfPCell(new Phrase(Modeloempresa.nom_emp, titulo));
                cell.Border = 0;
                cell.HorizontalAlignment = 1;
                tabladetaEmpresa.AddCell(cell);

                cell = new PdfPCell(new Phrase(""));
                cell.Border = 0;
                cell.HorizontalAlignment = 1;
                tabladetaEmpresa.AddCell(cell);

                cell = new PdfPCell(new Phrase(Modeloempresa.dir_tit + " " + "PBX: " + Modeloempresa.tel_tit + "-" + Modeloempresa.fax_tit, fontText));
                cell.Border = 0;
                cell.HorizontalAlignment = 1;
                tabladetaEmpresa.AddCell(cell);

                cell = new PdfPCell(new Phrase("NIT " + Modeloempresa.nro_dgi2 + "-" + Modeloempresa.nro_dgi1 + "   " + Modelocomercial.info_trib1, fontText));
                cell.Border = 0;
                cell.HorizontalAlignment = 1;
                tabladetaEmpresa.AddCell(cell);

                cell = new PdfPCell(new Phrase("Documentos oficial de autorización de numeración de facturación electrónica N°. " + conscabcera.cod_atrib1.Trim() + " Vigencia 24 meses desde " + resolucion.fec_emision + " hasta " + resolucion.fec_caducidad + " que habilita el prefijo " + resolucion.serie_docum.Trim() + " desde " + resolucion.nro_docum + " hasta " + resolucion.nro_docum_ref, fontText));
                cell.HorizontalAlignment = 1;
                cell.Border = 0;

                tabladetaEmpresa.AddCell(cell);

                cell = new PdfPCell(new Phrase("Impreso " + conscabcera.ntipo, fontText));
                cell.HorizontalAlignment = 1;
                cell.Border = 0;
                tabladetaEmpresa.AddCell(cell);


                cell = new PdfPCell(tabladetaEmpresa);//this line made the difference
                cell.HorizontalAlignment = 1;
                cell.Border = 0;
                cell.Colspan = 2;
                tablaLogo.AddCell(cell);
                // Insertamos la imagen en el documento
                // Creamos la imagen QR y le ajustamos el tamaño
                iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(pathLogo);
                imagen.BorderWidth = 0;
                imagen.Alignment = Element.ALIGN_RIGHT;
                float percentages = 0.0f;
                percentage = 150 / imagen1.Width;
                imagen.ScalePercent(percentage * 100);

                 cell = new PdfPCell(imagen);
                cell.HorizontalAlignment = 2;
                cell.Border = 0;

                tablaLogo.AddCell(cell);

                document.Add(tablaLogo);

                PdfPTable table = new PdfPTable(1);//cantidad de columnas que va tener la tabla
                table.WidthPercentage = 100;
                table.SpacingAfter = 10;
                cell = new PdfPCell();
                cell = new PdfPCell(new Paragraph("FACTURA ELECTRÓNICA DE VENTA N° " + conscabcera.serie_docum + " - " + conscabcera.nro_docum, titulo));
                cell.Colspan = 3;
                cell.Border = 0;
                cell.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right  
                table.AddCell(cell);
                document.Add(table);

                //Llenar cabecera con clase celdas
                PdfPTable tablaCab = new PdfPTable(3);
                tablaCab.WidthPercentage = 100;
                cell = new PdfPCell();
                cell = new PdfPCell(new Paragraph("CLIENTE:  "+ conscabcera.nom_tit, fontText));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaCab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("ORDEN DE COMPRA: " + conscabcera.ocompra, fontText));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaCab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("REMISIÓN N°: " + conscabcera.nro_pedido, fontText));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaCab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("NIT/CC:  "+conscabcera.nro_dgi, fontText));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaCab.AddCell(cell);

                cell = new PdfPCell(new Paragraph(""));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaCab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", fontText));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaCab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("DIRECCION: " + conscabcera.dir_tit, fontText));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaCab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", fontText));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaCab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", fontText));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaCab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("TELEFONO: " + conscabcera.tel_tit, fontText));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaCab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("", fontText));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaCab.AddCell(cell);


                cell = new PdfPCell(new Paragraph("", fontText));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaCab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("CIUDAD:   " + conscabcera.nom_ciudad, fontText));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaCab.AddCell(cell);


                cell = new PdfPCell(new Paragraph("", fontText));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaCab.AddCell(cell);


                cell = new PdfPCell(new Paragraph("", fontText));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaCab.AddCell(cell);
                document.Add(tablaCab);

                //NUEVA TABLA SOLO PARA DETALLE DE CABECERAV
                PdfPTable tablaCab1 = new PdfPTable(4);
                tablaCab1.WidthPercentage = 100;
                tablaCab1.SpacingAfter = 10;
                cell = new PdfPCell(new Paragraph("FECHA FACTURA ", titulo1));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 1;
                tablaCab1.AddCell(cell);

                cell = new PdfPCell(new Paragraph("FECHA VENCIMIENTO", titulo1));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 1;
                tablaCab1.AddCell(cell);

                cell = new PdfPCell(new Paragraph("FORMA DE PAGO ", titulo1));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 1;
                tablaCab1.AddCell(cell);

                cell = new PdfPCell(new Paragraph("VENDEDOR", titulo1));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 1;
                tablaCab1.AddCell(cell);

                cell = new PdfPCell(new Paragraph(conscabcera.fec_doc_str, fontText));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 1;
                tablaCab1.AddCell(cell);

                cell = new PdfPCell(new Paragraph(conscabcera.fec_venc_str, fontText));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 1;
                tablaCab1.AddCell(cell);

                cell = new PdfPCell(new Paragraph(conscabcera.nom_fpago, fontText));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 1;
                tablaCab1.AddCell(cell);

                cell = new PdfPCell(new Paragraph(conscabcera.cod_vendedor, fontText));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 1;
                tablaCab1.AddCell(cell);
                document.Add(tablaCab1);
                //Fin llenar con clase celdas

                //opcion detalle cabcera
                PdfPTable detacab = new PdfPTable(7);//cantidad de columnas que va tener la tabla
                detacab.WidthPercentage = 100;
                //detacab.SpacingAfter = 10;
                float[] values = new float[7];
                values[0] = 90;
                values[1] = 300;
                values[2] = 60;
                values[3] = 70;
                values[4] = 70;
                values[5] = 150;
                values[6] = 110;
                detacab.SetWidths(values);

                float[] detacabs = { 0.55f };
                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph("CÓDIGO", fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                detacab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("DESCRIPCION", fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                detacab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("UNI", fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                detacab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("CANT", fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                detacab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("IVA", fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                detacab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("VALOR UNITARIO", fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                detacab.AddCell(cell);

                cell = new PdfPCell(new Paragraph("TOTAL", fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
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
                values[4] = 70;
                values[5] = 150;
                values[6] = 110;

                detalle.HorizontalAlignment = 2;
                detalle.SetWidths(values);
                int contadorEspacio = 0;

                foreach (ModeloDetalleFactura item in listaConsDet)
                {
                    contadorEspacio ++;
                    detalle.DefaultCell.HorizontalAlignment = 0; detalle.AddCell(new Paragraph(item.cod_articulo, fontText1));
                    detalle.DefaultCell.HorizontalAlignment = 0; detalle.AddCell(new Paragraph(item.nom_articulo+ " "+ item.nom_articulo2.Trim(), fontText1));
                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(" ", fontText1));
                    decimal cantidadP = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, item.cantidad);
                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, cantidadP), fontText1));

                    decimal porc_des = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, item.porc_iva);
                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(porc_des.ToString(), fontText1));

                    decimal precio_un = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo_pu, item.precio_unit);
                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo_pu, precio_un), fontText1));

                        decimal total = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, item.total);
                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, total), fontText1));


                }
                for (int i = 0; i <18-contadorEspacio; i++)
                {
                    detalle.DefaultCell.HorizontalAlignment = 0; detalle.AddCell(new Paragraph(" ", fontText1));
                    detalle.DefaultCell.HorizontalAlignment = 0; detalle.AddCell(new Paragraph(" ", fontText1));
                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(" ", fontText1));

                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(" ", fontText1));

                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(" ", fontText1));

                   
                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(" ", fontText1));

                    
                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(" ", fontText1));

                }
                detalle.DefaultCell.BorderWidthTop = 1;
                document.Add(detalle);


                //tabla totales tabla principal
                PdfPTable total1 = new PdfPTable(4);//cantidad de columnas que va tener la tabla
                total1.WidthPercentage = 100;
                total1.SpacingAfter = 20;
                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph(""));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 0;
                cell.Colspan = 4;
                total1.AddCell(cell);
                document.Add(total1);
                //NUEVO ESQUEMA PROGRAMAR
                PdfPTable nuevaP = new PdfPTable(6);//cantidad de columnas que va tener la tabla
                nuevaP.WidthPercentage = 100;
               // nuevaP.SpacingAfter = 10;
                cell = new PdfPCell();


                PdfPTable detainfotri2 = new PdfPTable(1);//cantidad de columnas que va tener la tabla
                detainfotri2.WidthPercentage = 100;
                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph(Modelocomercial.letra_cambio1, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                detainfotri2.AddCell(cell);

                cell = new PdfPCell(new Paragraph(Modelocomercial.letra_cambio2, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                detainfotri2.AddCell(cell);

                cell = new PdfPCell(new Paragraph(Modelocomercial.letra_cambio3, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                detainfotri2.AddCell(cell);

                cell = new PdfPCell(new Paragraph("Fecha y hora de generación: " + conscabcera.fres_ini_str, fontText1));
                cell.Border = 0;
                cell.HorizontalAlignment = 1;
                cell.Colspan = 2;
                detainfotri2.AddCell(cell);

                iTextSharp.text.Image imagenp = iTextSharp.text.Image.GetInstance(qr);
                imagenp.Border = 0;
                imagenp.Alignment = Element.ALIGN_RIGHT;
                imagenp.ScaleAbsolute(50f, 50f);

                cell = new PdfPCell(imagenp);
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                detainfotri2.AddCell(cell);

                cell = new PdfPCell(detainfotri2);
                cell.Border = 0;
                cell.Colspan = 4;

                nuevaP.AddCell(cell);

                PdfPTable detatot = new PdfPTable(1);//cantidad de columnas que va tener la tabla
                detatot.WidthPercentage = 100;


                cell = new PdfPCell(new Paragraph("SUBTOTAL ", fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.HorizontalAlignment = 0;
                detatot.AddCell(cell);

                cell = new PdfPCell(new Paragraph("DESCUENTO ", fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.HorizontalAlignment = 0;
                detatot.AddCell(cell);


                cell = new PdfPCell(new Paragraph("IVA ", fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.HorizontalAlignment = 0;
                detatot.AddCell(cell);

                cell = new PdfPCell(new Paragraph("RETEFUENTE ", fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.HorizontalAlignment = 0;
                detatot.AddCell(cell);

                cell = new PdfPCell(new Paragraph("RETEIVA ", fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.HorizontalAlignment = 0;
                detatot.AddCell(cell);

                cell = new PdfPCell(new Paragraph("RETEICA ", fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.HorizontalAlignment = 0;
                detatot.AddCell(cell);

                cell = new PdfPCell(new Paragraph("TOTAL FACTURA ", titulo1));
                cell.BorderWidthBottom = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.HorizontalAlignment = 0;
                detatot.AddCell(cell);

                cell = new PdfPCell(detatot);//this line made the difference
                nuevaP.AddCell(cell);

                PdfPTable numtot = new PdfPTable(1);//cantidad de columnas que va tener la tabla
                numtot.WidthPercentage = 100;

                decimal subtotal1 = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, conscabcera.subtotal);
                cell = new PdfPCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, subtotal1), fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 2;
                numtot.AddCell(cell);

                decimal descuento = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, conscabcera.descuento);
                cell = new PdfPCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, descuento), fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 2;
                numtot.AddCell(cell);

                decimal base19 = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, conscabcera.iva);
                cell = new PdfPCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, base19), fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 2;
                numtot.AddCell(cell);

                decimal base5 = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, baseiva5);
                cell = new PdfPCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, base5), fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 2;
                numtot.AddCell(cell);

                decimal tiva19 = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, iva19);
                cell = new PdfPCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, tiva19), fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 2;
                numtot.AddCell(cell);

                decimal tiva5 = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, iva5);
                cell = new PdfPCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, tiva5), fontText));
                cell.BorderWidthBottom = 1;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 2;
                numtot.AddCell(cell);

                decimal Total = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, conscabcera.total);
                cell = new PdfPCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, Total), titulo1));
                cell.BorderWidthBottom = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 2;
                numtot.AddCell(cell);

                cell = new PdfPCell(numtot);//this line made the difference
                nuevaP.AddCell(cell);

                document.Add(nuevaP);
                //tabla principal de resoluciones
                //informacion tributaria
                PdfPTable infotri = new PdfPTable(3);//cantidad de columnas que va tener la tabla
                infotri.WidthPercentage = 100;
                infotri.SpacingAfter = 10;
                cell = new PdfPCell();
                cell.Border = 0;

                cell = new PdfPCell(new Paragraph("Link Documentos Relacionados ", titulo2));
                cell.Border = 0;
                cell.HorizontalAlignment = 2;
                infotri.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", titulo2));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                infotri.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", titulo2));
                cell.Border = 0;
                cell.HorizontalAlignment = 2;
                infotri.AddCell(cell);
                document.Add(infotri); //imprime la tablas

                PdfPTable totalL = new PdfPTable(1);//cantidad de columnas que va tener la tabla
                totalL.WidthPercentage = 100;
                totalL.SpacingAfter = 10;
                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph(conscabcera.vlr_letras, titulo2));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                totalL.AddCell(cell);
                document.Add(totalL);


                PdfPTable total20 = new PdfPTable(1);//cantidad de columnas que va tener la tabla
                total20.WidthPercentage = 100;
               // total20.SpacingAfter = 10;
                cell = new PdfPCell();

                foreach (modelobancos item in ListaModelobancos)
                {
                    total20.DefaultCell.BorderWidthBottom = 0;
                    total20.DefaultCell.BorderWidthLeft = 0;
                    total20.DefaultCell.BorderWidthTop = 0;
                    total20.DefaultCell.BorderWidthRight = 0;

                    total20.AddCell(new Paragraph((item.nomtcta_banco) + (" " + "Nro " + (item.nrocta_banco)) + " " + "de " + " " + (item.nom_tit.ToString()), titulo1));
                }


                total20.AddCell(cell);
                total20.DefaultCell.Border = 0;
         
                document.Add(total20);

                PdfPTable total21 = new PdfPTable(1);//cantidad de columnas que va tener la tabla
                total21.WidthPercentage = 100;
                total21.SpacingAfter = 10;
                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph(""));
                cell.BorderWidthBottom = 0;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 0;
               // cell.Colspan = 4;
                total21.AddCell(cell);
                document.Add(total21);

               

                //tabla pie de pagina principal
                PdfPTable pie = new PdfPTable(3);//cantidad de columnas que va tener la tabla
                pie.WidthPercentage = 100;
                pie.SpacingAfter = 10;
                cell = new PdfPCell();

                //tabla scundaria 1
                PdfPTable pie1 = new PdfPTable(1);//cantidad de columnas que va tener la tabla
                pie1.WidthPercentage = 100;
                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph("Recibido por", fontText));
                cell.BorderWidthBottom = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                pie1.AddCell(cell);

                cell = new PdfPCell(new Paragraph(" ", fontText));
                cell.BorderWidthBottom = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 0;
                pie1.AddCell(cell);

                cell = total(" ");
                cell.HorizontalAlignment = 1;
                pie1.AddCell(cell);

                cell = new PdfPCell(pie1);//this line made the difference
                pie.AddCell(cell);
                //tabla scundaria2
                PdfPTable pie2 = new PdfPTable(1);//cantidad de columnas que va tener la tabla
                pie2.WidthPercentage = 100;
  
                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph("Firma Responsable:", fontText));
                cell.BorderWidthBottom = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                pie2.AddCell(cell);

                cell = total(" ");
                cell.HorizontalAlignment = 1;
                pie2.AddCell(cell);

                cell = total(" ");
                cell.HorizontalAlignment = 1;
                pie2.AddCell(cell);
      

                cell = new PdfPCell(pie2);//this line made the difference
                pie.AddCell(cell);
                //tabla scundaria3
                PdfPTable pie3 = new PdfPTable(1);//cantidad de columnas que va tener la tabla
                pie3.WidthPercentage = 100;

                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph("V°B°:", fontText));
                cell.BorderWidthBottom = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                pie3.AddCell(cell);

       

                cell = new PdfPCell(new Paragraph(" ", fontText));
                cell.BorderWidthBottom = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 1;
                cell.HorizontalAlignment = 1;
                pie3.AddCell(cell);
                cell = new PdfPCell(pie3);//this line made the difference
                pie.AddCell(cell);

                document.Add(pie);

                PdfPTable fin1 = new PdfPTable(4);//cantidad de columnas que va tener la tabla
                fin1.WidthPercentage = 100;
                fin1.SpacingAfter = 10;
                cell = new PdfPCell();

                cell = new PdfPCell(new Paragraph("CUFE: "+ModeloResQr.cufe, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                cell.Colspan = 3;
                fin1.AddCell(cell);

                DateTime prueba = DateTime.Now;
                cell = new PdfPCell(new Paragraph("Fecha hora expedición: "+prueba.ToString(), fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 2;
                cell.Colspan = 2;
                fin1.AddCell(cell);

                //fin1.WriteSelectedRows(0, -1, document.LeftMargin, pw.PageSize.GetBottom(document.BottomMargin) - 5, pw.DirectContent);
                document.Add(fin1);
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