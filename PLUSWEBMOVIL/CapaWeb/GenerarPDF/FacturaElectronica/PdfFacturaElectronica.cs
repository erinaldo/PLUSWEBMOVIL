using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CapaWeb.GenerarPDF.FacturaElectronica
{
    public class PdfFacturaElectronica
    {
        public string generarPdf()
        {
            string bpathPdfGenrado = "";
            FileStream fs = new FileStream("F://PLUSCOLOMBIA/FACRURACIONLECTRONICA/PDF/factura.pdf", FileMode.Create);
            Document document = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
            //PdfWriter



            return bpathPdfGenrado;
        }
    }
}