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
        public string generarPdf( )
        {
            
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


            PdfPTable table = new PdfPTable(3);//cantidad de columnas que va tener la tabla
            table.WidthPercentage = 100;
            PdfPCell cell = new PdfPCell();

            cell = cabezera("FACTURA VENTA");

            cell.Colspan = 3;
           
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right            

            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Col 1 Row 1"));

            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 1;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 0;


            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Col 1 Row 1"));
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