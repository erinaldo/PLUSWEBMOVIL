using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
  public   class modeloCierreCaja
    {
        //Modelo cierre de caja tabla wmt_cierre_resumencaja
        
        public string id { get; set; }
        public string signo { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public decimal valor { get; set; }
        public string fecha_cie { get; set; }

        public string usuario_mod { get; set; }
        public string fecha_mod { get; set; }
        public string nro_audit { get; set; }

        public string cod_proc_aud { get; set; }
        

    }
}
