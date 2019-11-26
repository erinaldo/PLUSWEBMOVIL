using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.RestClientePdf
{
   
    public class EncabezadoNCRV2
    {
        public int emisor { get; set; }
        public int idsuc { get; set; }
        public int numero { get; set; }
        public string prefijo { get; set; }
        public string contenidopdf { get; set; }
    }

    public class DocumentoNCRV2
    {
        public EncabezadoNCRV2 encabezado { get; set; }
    }

    public class JsonPdfNCV2
    {
        public DocumentoNCRV2 documento { get; set; }
    }

}
