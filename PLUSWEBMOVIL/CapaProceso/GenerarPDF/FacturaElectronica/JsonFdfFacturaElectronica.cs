using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.RestClientePdf
{
   
    public class Encabezado
    {
        public int emisor { get; set; }
        public int idsuc { get; set; }
        public int numero { get; set; }
        public string prefijo { get; set; }
        public string contenidopdf { get; set; }
    }

    public class Documento
    {
        public Encabezado encabezado { get; set; }
    }

    public class JsonFdfFacturaElectronica
    {
        public Documento documento { get; set; }
    }

}
