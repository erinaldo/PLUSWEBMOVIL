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
        public string generarPdf()
        {
            
            string bpathPdfGenrado = "F://PLUSCOLOMBIA/FACRURACIONLECTRONICA/PDF/factura.pdf";
            string qr = ImagenQR(bpathPdfGenrado);



            FileStream fs = new FileStream(bpathPdfGenrado, FileMode.Create);
            Document document = new Document(iTextSharp.text.PageSize.A4, 30, 30, 30, 30);
            PdfWriter pw = PdfWriter.GetInstance(document, fs);

           
            Paragraph title = new Paragraph();
            title.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLUE);
            title.Add("Hola Mundo!!");
            title.Alignment = Element.ALIGN_CENTER;
            document.Open();
            document.Add(title);
            document.Add(new Paragraph("Hola Mundo!!"));
            document.Add(new Paragraph("Parrafo 1"));
            document.Add(new Paragraph("Parrafo 2"));

            // Creamos la imagen y le ajustamos el tamaño
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(qr);
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_RIGHT;
            float percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage * 100);

            // Insertamos la imagen en el documento
            document.Add(imagen);

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
    }
}