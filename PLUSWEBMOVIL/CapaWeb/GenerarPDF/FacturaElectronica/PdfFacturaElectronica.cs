using CapaProceso.Consultas;
using CapaProceso.Modelos;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;


namespace CapaWeb.GenerarPDF.FacturaElectronica
{
    public class PdfFacturaElectronica
    {
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

            string bpathPdfGenrado = "F://PLUSCOLOMBIA/FACRURACIONLECTRONICA/PDF/factura.pdf";
            string qr = ImagenQR(bpathPdfGenrado);



            FileStream fs = new FileStream(bpathPdfGenrado, FileMode.Create);
            Document document = new Document(iTextSharp.text.PageSize.A4, 30, 30, 30, 30);
            PdfWriter pw = PdfWriter.GetInstance(document, fs);

           
            
            document.Open();
            

            // Creamos la imagen y le ajustamos el tamaño
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(qr);
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_RIGHT;
            float percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage * 100);

            // Insertamos la imagen en el documento
            //document.Add(imagen);


            PdfPTable table = new PdfPTable(1);//cantidad de columnas que va tener la tabla
            table.WidthPercentage = 100;
            PdfPCell cell = new PdfPCell();

            cell = cabezera("FACTURA VENTA");

            cell.Colspan = 3;
           
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right            

            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(conscabcera.nom_tit));

            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 0;


            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(conscabcera.nro_dgi));
            cell.Border = 0;

            table.AddCell(cell);

            table.AddCell(imagen);

            table.AddCell("Col 1 Row 2");

            table.AddCell("Col 2 Row 2");

           

            

            PdfPTable testTable = new PdfPTable(2);
            PdfPCell c2;
            testTable.AddCell("aaaa");
            testTable.AddCell("bbbb");

            c2 = new PdfPCell(testTable);//this line made the difference

            table.AddCell(c2);

            document.Add(table);
            document.Close();

            return bpathPdfGenrado;
        }

        public string ImagenQR(string texto)
        {
            string qrPath = "F://PLUSCOLOMBIA/FACRURACIONLECTRONICA/PDF/qrcode.png";

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
            contenido.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLACK);

            contenido.Add(mensaje);
            contenido.Alignment = Element.ALIGN_CENTER;

            PdfPCell cell = new PdfPCell(contenido);

            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthTop = 1;
            cell.BorderWidthRight = 1;

            return cell;
        }
    }
}