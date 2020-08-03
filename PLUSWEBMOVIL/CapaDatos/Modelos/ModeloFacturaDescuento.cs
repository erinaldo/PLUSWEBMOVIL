using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
   public  class ModeloFacturaDescuento
    {
        public string nomcod { get; set; }
        public string descuento { get; set; }
      public string   cod_emp { get; set; }
      public string cod_concepto { get; set; }
        public string nom_concepto { get; set; }
        public string cod_concepto_fis { get; set; }
        public decimal porc_descto { get; set; }
        public string cod_cta { get; set; }
        public string  cod_ccostos { get; set; }
        public string usuario_mod { get; set; }
        public string fecha_mod { get; set; }
        public string nro_audit { get; set; }
        public string cod_proc_aud { get; set; }
        public string detalle { get; set; }
        public string signo { get; set; }
}
}
