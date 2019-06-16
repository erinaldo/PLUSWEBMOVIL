using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
   public  class modeloinsertarconfirmar
    {
        public string nro_trans { get; set; }
        public string cod_emp { get; set; }
        public string usuario_mod { get; set; }
        public DateTime fecha_mod { get; set; }
        public string nro_audit { get; set; }
    }
}
