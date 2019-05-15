using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.Modelos
{
   public  class ModeloDetalleFactura
    { 

        public string cod_articulo { get; set; }
        public string nom_articulo { get; set; }
        public decimal porc_impuesto { get; set; }
        public decimal precio { get; set; }
        public int valor_impu { get; set; }
        public decimal precio_total { get; set; }
        public decimal porcdescto { get; set; }
        public decimal poriva { get; set; }

        
    }
}
