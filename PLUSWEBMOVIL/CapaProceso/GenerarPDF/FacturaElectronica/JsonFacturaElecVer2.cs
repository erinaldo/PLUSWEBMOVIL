using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.ReslClientePdf
{
  
    public class EncabezadoFEV2
    {
        public int emisor { get; set; }
        public int idsuc { get; set; }
        public int numero { get; set; }
        public string prefijo { get; set; }
        public string contenidopdf { get; set; }
    }

    public class DocumentoFEV2
    {
        public EncabezadoFEV2 encabezado { get; set; }
    }

   

    public class JsonFacturaElecVer2
    {
        public DocumentoFEV2 documento { get; set; }
    }
}
