using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
  public   class modeloClientesproforma
    {
        public string nro_trans { get; set; }
 
        public string cod_emp { get; set; }

        public string cod_cliente { get; set; }
        public string cod_suc_cli { get; set; }
        public DateTime fecha_mod { get; set; }
        public string estado { get; set; }
        public string nro_trans_ndm { get; set; }
        public string usuario { get; set; }
    }
}
