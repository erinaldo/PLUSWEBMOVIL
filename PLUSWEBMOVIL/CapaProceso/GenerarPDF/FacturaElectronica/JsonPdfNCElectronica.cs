using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.RestClientePdf
{
   
    public class EncabezadoNCR
    {
        public int emisor { get; set; }
        public int idsuc { get; set; }
        public int numero { get; set; }
        public string prefijo { get; set; }
        public string contenidopdf { get; set; }
    }

    public class DocumentoNCR
    {
        public EncabezadoNCR encabezado { get; set; }
    }

    public class JsonPdfNCElectronica
    {
        public DocumentoNCR documento { get; set; }
    }

}
