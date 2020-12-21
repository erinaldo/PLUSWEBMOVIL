using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.EstadoDocEle
{
    public class DocumentoConsulta
    {
        public EncabezadoConsulta encabezado { get; set; }
    }
    public class EncabezadoConsulta
    {
        public int emisor { get; set; }
        public int idsuc { get; set; }
        public long numero { get; set; }
        public string prefijo { get; set; }
        
    }

   public  class ComprobanteDocEle
    {
    
            public DocumentoConsulta documento { get; set; }
    }
}
