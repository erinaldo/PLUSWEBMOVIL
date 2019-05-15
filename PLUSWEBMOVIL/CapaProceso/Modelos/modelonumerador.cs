using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.Modelos
{
   public  class modelonumerador
    {
        public string numerador { get; set; }
        public string nombre { get; set; }
        public string valor_asignado { get; set; }
        public string incremento { get; set; }

        public string usuario_mod { get; set; }
        public DateTime fecha_mod { get; set; }
        public string nro_audit { get; set; }

        public string cod_pro_aud { get; set; }
    }
}
