using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
    public class modeloEfectivoCaja
    {
        //Modelo efectivo caja tabla wmt_efectivoCaja

        public string id { get; set; }
        public string cod_emp { get; set; }
        public decimal denominacionMId { get; set; }
        public decimal valor { get; set; }
        public decimal cantidad { get; set; }
        public string canti { get; set; }
        public decimal total { get; set; }
        public Int64 secuencial { get; set; }
        public string Observaciones { get; set; }
        public string fecha_efe { get; set; }
        public string cbx_secuencias { get; set; }
        public string usuario_mod { get; set; }
        public DateTime fecha_mod { get; set; }
        public string nro_audit { get; set; }

        public string cod_proc_aud { get; set; }

    }
}
