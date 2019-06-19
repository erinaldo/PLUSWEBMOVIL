using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
    public class modeloCodProcesoFactura
    {
        //proceso factura
        public string cod_proceso { get; set; }
        public string nom_proceso { get; set; }
        public string observaciones { get; set; }
        public string email { get; set; }
        public string pagina_audit { get; set; }


        public string usuario_mod { get; set; }
        public DateTime fecha_mod { get; set; }
        public string nro_audit { get; set; }

        public string cod_proc_aud { get; set; }
        public string auditable { get; set; }
        public string imagen { get; set; }

        public string modulo { get; set; }
        public string pagina { get; set; }
        public string tamano { get; set; }
        public string vinculo { get; set; }
        public string menu { get; set; }
        public string vinculo2 { get; set; }
        public string orden { get; set; }
    }
}
