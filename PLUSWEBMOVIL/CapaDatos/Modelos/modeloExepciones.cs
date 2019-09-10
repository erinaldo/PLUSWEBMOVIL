using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
   public  class modeloExepciones
    {
        public string nro_trans { get; set; }
        public string cod_emp { get; set; }
        public string proceso { get; set; }
        public string metodo { get; set; }
        public string error { get; set; }
        public DateTime fecha_hora { get; set; }
        public string usuario_mod { get; set; }
        public DateTime fecha_mod { get; set; }
        public string nro_audit { get; set; }

        public string cod_proc_aud { get; set; }
        
    }
}
