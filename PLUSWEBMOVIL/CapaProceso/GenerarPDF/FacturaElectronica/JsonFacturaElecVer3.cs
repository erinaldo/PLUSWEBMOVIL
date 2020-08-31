using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.ReslClientePdf
{

    public class EncabezadoFEV3
    {
        public int emisor { get; set; }
        public int idsuc { get; set; }
        public int numero { get; set; }
        public string prefijo { get; set; }
        public string contenidopdf { get; set; }
        public string adjuntocontenido { get; set; }
        public string adjuntonombre { get; set; }
    }

    public class DocumentoFEV3
    {
        public EncabezadoFEV3 encabezado { get; set; }
    }



    public class JsonFacturaElecVer3
    {
        public DocumentoFEV3 documento { get; set; }
    }
}
