using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
   public  class modeloDepositosDia
    {
        //Cierre de caja Depositos del dia
        public string id { get; set; }
        public Int64 secuencial { get; set; }
        public string cod_emp { get; set; }
        public string signo { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public decimal valor { get; set; }
        public string valor1 { get; set; }
        public string fecha_cie { get; set; }

        public string usuario_mod { get; set; }
        public DateTime fecha_mod { get; set; }
        public string nro_audit { get; set; }

        public string cod_proc_aud { get; set; }
        public string nro_trans { get; set; }
    }
}
