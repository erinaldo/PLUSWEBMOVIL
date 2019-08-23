using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
  public   class modeloDenominacionesMoneda
    {
        //proceso Denominacion monedas
        public string id { get; set; }
        public string cod_moneda { get; set; }
        public string nombre { get; set; }
        public decimal valor { get; set; }
        public string observaciones { get; set; }

        public string usuario_mod { get; set; }
        public string fecha_mod { get; set; }
        public string nro_audit { get; set; }

        public string cod_proc_aud { get; set; }
    }
}
