using CapaDatos.Modelos;
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
    public class PdfFacturaElectronica
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


        public List<JsonRespuestaDE> ListaModelorespuestaDs = new List<JsonRespuestaDE>();
        public JsonRespuestaDE ModeloResQr = new JsonRespuestaDE();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();

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

        public JsonRespuestaDE BuscarRespuestaDS(string nro_trans)
        {
            ListaModelorespuestaDs = consultaRespuestaDS.ConsultaRespuestaQr(nro_trans);

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
        public ModeloDetalleFactura buscarDetalleFactura(string nro_trans)
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

        public modelowmtfacturascab buscarCabezeraFactura( string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
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
        public string generarPdf(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            conscabcera = null;
            conscabcera = buscarCabezeraFactura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);

            consdetalle = null;
            consdetalle = buscarDetalleFactura(Ccf_nro_trans);

            decimal baseiva19 = 0;
            decimal iva19 = 0;
            decimal baseiva5 = 0;
            decimal iva5 = 0;
            //Obtener totales y base de ivas 19 y 15
            foreach (ModeloDetalleFactura item in listaConsDet)
            {
                  if(item.porc_iva == 19)
                {
                    baseiva19 += item.base_iva;
                    iva19 += item.valor_iva;
                }
                  if(item.porc_iva == 15)
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
            ModeloBancos = BuscarBancos(Ccf_usuario, Ccf_cod_emp);

            ModeloCotizacion = null;
            ModeloCotizacion = BuscarCotizacion(Ccf_usuario, Ccf_cod_emp, Ccf_nro_trans);


            
            string pathtmpfac = Modelowmspclogo.pathtmpfac;  //Traemos el path, la ruta 
            string qrPath = pathtmpfac + Ccf_cod_emp.Trim() + Ccf_nro_trans.Trim() + "qrcode.png";
            string bpathPdfGenrado = pathtmpfac + Ccf_cod_emp.Trim() + Ccf_nro_trans.Trim() + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "factura.pdf" ;
            string qr = ImagenQR(qrPath, Ccf_nro_trans);



            FileStream fs = new FileStream(bpathPdfGenrado, FileMode.Create);
            Document document = new Document(PageSize.A4, 30, 30, 30, 30);
            PdfWriter pw = PdfWriter.GetInstance(document, fs);



            document.Open();
            /*Tipo de letra y tamaño del documento pdf*/
            var path = HttpContext.Current.Server.MapPath("~/Tema/fonts/VerdanaVf.ttf");
            BaseFont bf = BaseFont.CreateFont(path, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font fontText = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font fontText1 = new iTextSharp.text.Font(bf, 8, iTextSharp.text.Font.NORMAL);

            PdfPCell cell = new PdfPCell();//creo variable de celda

            PdfPTable tablaLogo = new PdfPTable(3);//cantidad de columnas que va tener la tabla
            tablaLogo.WidthPercentage = 100;
            // Creamos la imagen y le ajustamos el tamaño
            var pathLogo = "";
            if (Modelowmspclogo.sitio_app.Contains("http"))
            {

                 pathLogo = Modelowmspclogo.sitio_app + "/Logo/" + Modelowmspclogo.logo;

            }
            else
            {
                 pathLogo = HttpContext.Current.Server.MapPath("~/Logo/" + Modelowmspclogo.logo);
            }
            
            iTextSharp.text.Image imagen1 = iTextSharp.text.Image.GetInstance(pathLogo);
            imagen1.BorderWidth = 0;
            imagen1.Alignment = Element.ALIGN_RIGHT;
            float percentage = 0.0f;
            percentage = 150 / imagen1.Width;
            imagen1.ScalePercent(percentage * 100);

            cell = new PdfPCell(imagen1);
            cell.Border = 0;
            tablaLogo.AddCell(cell);

            // Creamos la imagen QR y le ajustamos el tamaño
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(qr);
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_RIGHT;
            imagen.ScaleAbsolute(80f, 80f);



            cell = new PdfPCell(imagen);
            cell.HorizontalAlignment = 2;
            cell.Border = 0;
            
            tablaLogo.AddCell(cell);


            PdfPTable tabladetaEmpresa = new PdfPTable(1);
            tabladetaEmpresa.WidthPercentage = 100;
            
            cell = new PdfPCell(new Phrase(""));
            cell.Border = 0;
            cell.HorizontalAlignment = 2;
            tabladetaEmpresa.AddCell(cell);

            cell = new PdfPCell(new Phrase("NIT " + Modeloempresa.nro_dgi2 + "-" + Modeloempresa.nro_dgi1,fontText));
            cell.Border = 0;
            cell.HorizontalAlignment = 2;
            tabladetaEmpresa.AddCell(cell);

            cell = new PdfPCell(new Phrase(Modeloempresa.dir_tit, fontText));
            cell.Border = 0;
            cell.HorizontalAlignment = 2;
            tabladetaEmpresa.AddCell(cell);

            
            cell = new PdfPCell(new Phrase("Teléfono: " + Modeloempresa.tel_tit + "-" + Modeloempresa.fax_tit, fontText));
            cell.HorizontalAlignment = 2;
            cell.Border = 0;
            
            tabladetaEmpresa.AddCell(cell);

            cell = new PdfPCell(new Phrase(Modeloempresa.email_tit + " " + Modeloempresa.dir_web, fontText));
            cell.HorizontalAlignment = 2;
            cell.Border = 0;
            tabladetaEmpresa.AddCell(cell);

            cell = new PdfPCell(tabladetaEmpresa);//this line made the difference
            cell.HorizontalAlignment = 2;
            cell.Border = 0;
            tablaLogo.AddCell(cell);
            // Insertamos la imagen en el documento

            document.Add(tablaLogo);

            PdfPTable table = new PdfPTable(1);//cantidad de columnas que va tener la tabla
            table.WidthPercentage = 100;
            table.SpacingAfter = 10;
            cell = new PdfPCell();
            cell = new PdfPCell(new Paragraph("FACTURA DE VENTA: " + conscabcera.serie_docum + " - " + conscabcera.nro_docum, fontText));
            cell.Colspan = 3;
            cell.Border = 0;
            cell.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right  
            table.AddCell(cell);

            //Llenar cabecera con clase celdas
            PdfPTable tablaCab = new PdfPTable(2);
            
            tablaCab.SpacingAfter = 10;
            cell = new PdfPCell();
            cell = new PdfPCell(new Paragraph("CLIENTE: " + conscabcera.nom_tit, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.Colspan = 1;

            cell.HorizontalAlignment = 0;
            tablaCab.AddCell(cell);

            cell = new PdfPCell(new Paragraph("FECHA FACTURA: " + conscabcera.fec_doc_str, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.Colspan = 1;
            cell.HorizontalAlignment = 0;
            tablaCab.AddCell(cell);

            cell = new PdfPCell(new Paragraph("NIT/CC: " + conscabcera.nro_dgi, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.Colspan = 1;
            cell.HorizontalAlignment = 0;
            tablaCab.AddCell(cell);

            cell = new PdfPCell(new Paragraph("VENCIMIENTO: " + conscabcera.fec_venc_str, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.Colspan = 1;
            cell.HorizontalAlignment = 0;
            tablaCab.AddCell(cell);

            cell = new PdfPCell(new Paragraph("TELEFONO: " + conscabcera.tel_tit, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.Colspan = 1;
            cell.HorizontalAlignment = 0;
            tablaCab.AddCell(cell);

            cell = new PdfPCell(new Paragraph("FORMA DE PAGO: " + conscabcera.nom_fpago, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.Colspan = 1;
            cell.HorizontalAlignment = 0;
            tablaCab.AddCell(cell);

            cell = new PdfPCell(new Paragraph("DIRECCION: " + conscabcera.dir_tit, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.Colspan = 1;
            cell.HorizontalAlignment = 0;
            tablaCab.AddCell(cell);

            cell = new PdfPCell(new Paragraph("VENDEDOR: " + conscabcera.nom_vendedor, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.Colspan = 1;
            cell.HorizontalAlignment = 0;
            tablaCab.AddCell(cell);

            cell = new PdfPCell(new Paragraph("CIUDAD: " + conscabcera.nom_ciudad, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.Colspan = 1;
            cell.HorizontalAlignment = 0;
            tablaCab.AddCell(cell);

            cell = new PdfPCell(new Paragraph("O.COMPRA/PEDIDO: " + conscabcera.ocompra, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.Colspan = 1;
            cell.HorizontalAlignment = 0;
            tablaCab.AddCell(cell);

            cell = new PdfPCell(tablaCab);//this line made the difference

            table.AddCell(cell);
            document.Add(table);
            //Fin llenar con clase celdas


           

            //opcion detalle cabcera
            PdfPTable detacab = new PdfPTable(7);//cantidad de columnas que va tener la tabla
            detacab.WidthPercentage = 100;
            detacab.SpacingAfter = 10;
            float[] values = new float[7];
            values[0] = 90;
            values[1] = 300;
            values[2] = 70;
            values[3] = 110;
            values[4] = 70;
            values[5] = 90;
            values[6] = 90;
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

            cell = new PdfPCell(new Paragraph("CANT", fontText));
            cell.BorderWidthBottom = 1;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthTop = 1;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 1;
            detacab.AddCell(cell);

            cell = new PdfPCell(new Paragraph("P.UNIT", fontText));
            cell.BorderWidthBottom = 1;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthTop = 1;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 1;
            detacab.AddCell(cell);

            cell = new PdfPCell(new Paragraph("% DCTO", fontText));
            cell.BorderWidthBottom = 1;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthTop = 1;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 1;
            detacab.AddCell(cell);

            cell = new PdfPCell(new Paragraph("NETO ", fontText));
            cell.BorderWidthBottom = 1;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthTop = 1;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 0;
            detacab.AddCell(cell);

            cell = new PdfPCell(new Paragraph("V/GRAV. ", fontText));
            cell.BorderWidthBottom = 1;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthTop = 1;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 0;

            detacab.AddCell(cell);

            document.Add(detacab);

            

            //Cargar Detalle factura
            PdfPTable detalle = new PdfPTable(7);//cantidad de columnas que va tener la tabla
            detalle.WidthPercentage = 100f;
            detalle.SpacingAfter = 10;
            

            values = new float[7];
            values[0] = 90;
           
            values[1] = 300;
            values[2] = 70;
            values[3] = 110;
            values[4] = 70;
            values[5] = 90;
            values[6] = 90;
            detalle.HorizontalAlignment  = 2;
            detalle.SetWidths(values);
            

            foreach (ModeloDetalleFactura item in listaConsDet)
            {
                
                detalle.AddCell(new Paragraph( item.cod_articulo, fontText1));
                detalle.AddCell(new Paragraph(item.nom_articulo, fontText1));
                detalle.AddCell(new Paragraph(String.Format("{0:N3}", item.cantidad).ToString(), fontText1));
                detalle.AddCell(new Paragraph(String.Format("{0:N5}", item.precio_unit).ToString(), fontText1));
                detalle.AddCell(new Paragraph(String.Format("{0:N}", (Math.Round( item.porc_descto, 2))).ToString(), fontText1));
                detalle.AddCell(new Paragraph(String.Format("{0:N2}", (Math.Round(item.subtotal, 2))).ToString(), fontText1));
                detalle.AddCell(new Paragraph(String.Format("{0:N2}",(Math.Round(item.total, 2))).ToString(), fontText1));

            }

            document.Add(detalle);


            //tabla totales tabla principal
            //opcion detalle cabcera
            PdfPTable totales = new PdfPTable(4);//cantidad de columnas que va tener la tabla
            totales.WidthPercentage = 100;
            totales.SpacingAfter = 10;
            cell = new PdfPCell();

            cell = new PdfPCell(new Paragraph(conscabcera.vlr_letras, fontText));
            cell.BorderWidthBottom = 1;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthTop = 1;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 0;
            cell.Colspan = 2;
            totales.AddCell(cell);



            PdfPTable detatot = new PdfPTable(1);//cantidad de columnas que va tener la tabla
            detatot.WidthPercentage = 100;

            cell = new PdfPCell(new Paragraph("SUMAN: ", fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 0;
            detatot.AddCell(cell);

            cell = new PdfPCell(new Paragraph("DESCUENTO: ", fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 0;
            detatot.AddCell(cell);

            cell = new PdfPCell(new Paragraph("SUBTOTAL: ", fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 0;
            detatot.AddCell(cell);

            cell = new PdfPCell(new Paragraph("BASE IVA 19%: ", fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 0;
            detatot.AddCell(cell);

            cell = new PdfPCell(new Paragraph("BASE IVA 5%: ", fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 0;
            detatot.AddCell(cell);

            cell = new PdfPCell(new Paragraph("IVA 19%: ", fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 0;
            detatot.AddCell(cell);

            cell = new PdfPCell(new Paragraph("IVA 5%: ", fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 0;
            detatot.AddCell(cell);

            cell = new PdfPCell(new Paragraph("TOTAL: ", fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 0;
            detatot.AddCell(cell);

            cell = new PdfPCell(detatot);//this line made the difference
            totales.AddCell(cell);

            PdfPTable numtot = new PdfPTable(1);//cantidad de columnas que va tener la tabla
            numtot.WidthPercentage = 100;

            cell = new PdfPCell(new Paragraph((String.Format("{0:N}",  conscabcera.suman).ToString()),fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 2;
            numtot.AddCell(cell);

            cell = new PdfPCell(new Paragraph((String.Format("{0:N}", conscabcera.descuento).ToString()), fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 2;
            numtot.AddCell(cell);

            cell = new PdfPCell(new Paragraph((String.Format("{0:N}", conscabcera.subtotal).ToString()), fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 2;
            numtot.AddCell(cell);

            cell = new PdfPCell(new Paragraph((String.Format("{0:N}", baseiva19).ToString()), fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 2;
            numtot.AddCell(cell);

            cell = new PdfPCell(new Paragraph((String.Format("{0:N}", baseiva5).ToString()), fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 2;
            numtot.AddCell(cell);

            cell = new PdfPCell(new Paragraph((String.Format("{0:N}", iva19).ToString()), fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 2;
            numtot.AddCell(cell);

            cell = new PdfPCell(new Paragraph((String.Format("{0:N}", iva5).ToString()),fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 2;
            numtot.AddCell(cell);

            /* cell = total((String.Format("{0:N}", conscabcera.monto_imponible).ToString()));
             cell.HorizontalAlignment = 2;
             numtot.AddCell(cell);

             cell = total((String.Format("{0:N}", conscabcera.iva).ToString()));
             cell.HorizontalAlignment = 2;
             numtot.AddCell(cell);*/

            cell = new PdfPCell(new Paragraph((String.Format("{0:N}", conscabcera.total).ToString()), fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 2;
            numtot.AddCell(cell);

            cell = new PdfPCell(numtot);//this line made the difference
            totales.AddCell(cell);
            document.Add(totales);
            //tabla principal de resoluciones
            //informacion tributaria
            PdfPTable infotri = new PdfPTable(2);//cantidad de columnas que va tener la tabla
            infotri.WidthPercentage = 100;
            infotri.SpacingAfter = 10;
            cell = new PdfPCell();

            PdfPTable detainfotri1 = new PdfPTable(1);//cantidad de columnas que va tener la tabla
            detainfotri1.WidthPercentage = 100;
            cell = new PdfPCell();

            cell = new PdfPCell(new Paragraph(Modelocomercial.info_trib1, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 0;
            detainfotri1.AddCell(cell);

            cell = new PdfPCell(new Paragraph(Modelocomercial.info_trib2, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 0;
            detainfotri1.AddCell(cell);

            cell = new PdfPCell(new Paragraph(Modelocomercial.info_trib3, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 0;
            detainfotri1.AddCell(cell);

            cell = new PdfPCell(new Paragraph(Modelocomercial.info_trib4, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 0;
            detainfotri1.AddCell(cell);

            cell = new PdfPCell(new Paragraph(Modelocomercial.info_trib5, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 0;
            detainfotri1.AddCell(cell);
            cell = new PdfPCell(detainfotri1);//agrega las nuevas celdas a la tabla principal

            infotri.AddCell(cell);
            //otra tablas
            PdfPTable detainfotri = new PdfPTable(1);//cantidad de columnas que va tener la tabla
            detainfotri.WidthPercentage = 100;
            cell = new PdfPCell();

            cell = new PdfPCell(new Paragraph("DIAN N° " + conscabcera.cod_atrib1, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 1;
            detainfotri.AddCell(cell);

            cell = new PdfPCell(new Paragraph("desde " + conscabcera.fres_ini_str + " " + "hasta " + conscabcera.fres_fin_str, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 1;
            detainfotri.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Prefijo " + conscabcera.mes_char + " " + "Factura " + conscabcera.ntipo, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 1;
            detainfotri.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Autoriza del " + conscabcera.ini + " " + "al " + conscabcera.fin, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 1;
            detainfotri.AddCell(cell);

            cell = new PdfPCell(detainfotri);//agrega las nuevas celdas a la tabla principal

            infotri.AddCell(cell);

            document.Add(infotri); //imprime la tablas

            //TABLA FORMAS DE PAGO principal

            PdfPTable pagos = new PdfPTable(2);//cantidad de columnas que va tener la tabla
            pagos.WidthPercentage = 100;
            pagos.SpacingAfter = 10;
            cell = new PdfPCell();

            //tabla secundaria1
            PdfPTable pagos1 = new PdfPTable(1);
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            pagos1.WidthPercentage = 100;
            cell = new PdfPCell();

            cell = new PdfPCell(new Paragraph(Modelocomercial.letra_cambio1, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 1;
            pagos1.AddCell(cell);

            cell = new PdfPCell(new Paragraph(Modelocomercial.letra_cambio2, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 1;
            pagos1.AddCell(cell);

            cell = new PdfPCell(new Paragraph(Modelocomercial.letra_cambio3, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 1;
            pagos1.AddCell(cell);

            cell = new PdfPCell(pagos1);//this line made the difference
            pagos.AddCell(cell);

            //tabla secundaria2
            PdfPTable pagos2 = new PdfPTable(1);
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            pagos2.WidthPercentage = 100;
            cell = new PdfPCell();

            cell = new PdfPCell(new Paragraph("Favor girar cheque cruzado a nombre de", fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 1;
            pagos2.AddCell(cell);

            cell = new PdfPCell(new Paragraph(Modeloempresa.nom_emp, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 1;
            pagos2.AddCell(cell);

            cell = new PdfPCell(new Paragraph("o consignar en", fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 1;
            pagos2.AddCell(cell);

            cell = new PdfPCell(new Paragraph(ModeloBancos.nomtcta_banco+" " + "Nro" +" "+ ModeloBancos.nrocta_banco+" "+ "de "+" "+ModeloBancos.nom_tit, fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 1;
            pagos2.AddCell(cell);

            /*  foreach (modelobancos item in ListaModelobancos)
              {

                  pagos2.AddCell(new Paragraph((item.nomtcta_banco)+ ("Nro " + (item.nrocta_banco))+ "de " +(item.nom_tit.ToString())));
                  /* pagos2.AddCell(new Paragraph("Nro " + (item.nrocta_banco), fontText));
                   pagos2.AddCell(new Paragraph("de " + item.nom_tit.ToString(), fontText));
                  break;
          }*/

            

            cell = new PdfPCell(pagos2);//agrega las nuevas celdas a la tabla principal

            pagos.AddCell(cell);

            document.Add(pagos);

            //tabla pie de pagina principal
            PdfPTable pie = new PdfPTable(3);//cantidad de columnas que va tener la tabla
            pie.WidthPercentage = 100;
            pie.SpacingAfter = 10;
            cell = new PdfPCell();

            //tabla scundaria 1
            PdfPTable pie1 = new PdfPTable(1);//cantidad de columnas que va tener la tabla
            pie1.WidthPercentage = 100;
            cell = new PdfPCell();

            cell = new PdfPCell(new Paragraph("Observaciones", fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 1;
            pie1.AddCell(cell);

            cell = new PdfPCell(new Paragraph(conscabcera.observaciones, fontText));
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

            cell = new PdfPCell(new Paragraph("Aprobado por:", fontText));
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

            cell = new PdfPCell(new Paragraph("Aceptada y Recibida por:", fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 1;
            pie3.AddCell(cell);

            cell = total(" ");
            cell.HorizontalAlignment = 1;
            pie3.AddCell(cell);

            cell = total(" ");
            cell.HorizontalAlignment = 1;
            pie3.AddCell(cell);
            cell = total(" ");
            cell.HorizontalAlignment = 1;
            pie3.AddCell(cell);

            cell = total(" ");
            cell.HorizontalAlignment = 1;
            pie3.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Firma y Sello / CC / NIT", fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 1;
            pie3.AddCell(cell);
            cell = new PdfPCell(pie3);//this line made the difference
            pie.AddCell(cell);

            document.Add(pie);

            //tabla pie de pagina principal
            PdfPTable fin = new PdfPTable(2);//cantidad de columnas que va tener la tabla
            fin.WidthPercentage = 100;
            fin.SpacingAfter = 10;
            cell = new PdfPCell();

            cell = new PdfPCell(new Paragraph("Original", fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 0;
            cell.Border = 0;
            fin.AddCell(cell);
            cell = new PdfPCell(new Paragraph("Plus WebMobile Version 6.0 Todos los derechos reservados - 2019", fontText));
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 1;
            cell.HorizontalAlignment = 2;
            cell.Border = 0;
            fin.AddCell(cell);

            document.Add(fin);
            document.Close();

            return bpathPdfGenrado;
        }

        public string ImagenQR(string qrPath, string Ccf_nro_trans)
        {
            ModeloResQr = null;  //Traemos el QR respuesta
            ModeloResQr = BuscarRespuestaDS(Ccf_nro_trans);
            string texto = "";
            if (ModeloResQr != null )
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
            ListaModelowmspclogo = consultaLogo.BuscartaLogo(empresa, usuario);
            foreach (var item in ListaModelowmspclogo)
            {
                Modelowmspclogo = item;
                break;
            }

            return Modelowmspclogo;
        }
        public modelowmspctctrxCotizacion BuscarCotizacion(string usuario, string empresa, string nro_trans)
        {
            ListaModelocotizacion = consultaMoneda.BuscartatrmCotizacion(usuario,empresa, nro_trans);
            foreach (var item in ListaModelocotizacion)
            {
                ModeloCotizacion = item;
                break;
            }

            return ModeloCotizacion;
        }

        public modelobancos BuscarBancos(string empresa, string usuario)
        {
            ListaModelobancos = consultabanco.BuscartaBancos(empresa, usuario);
            foreach (var item in ListaModelobancos)
            {
                ModeloBancos = item;
                break;
            }

            return ModeloBancos;
        }
        public modeloparametrocomercial BuscarParametro(string empresa)
        {
            ListaModelocomercial = consultaComercial.BuscartaComercial(empresa);
            foreach (var item in ListaModelocomercial)
            {
                Modelocomercial = item;
                break;
            }

            return Modelocomercial;
        }
        public modelowmspcempresas BuscarCabEmpresa(string usuario, string empresa)
        {
            ListaModeloempresa = consultaEmpresa.BuscartaEmpresa(usuario, empresa);
            foreach (var item in ListaModeloempresa)
            {
                Modeloempresa = item;
                break;
            }

            return Modeloempresa;
        }
        
    }
}