using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
   public class modeloMediosPago
    {
        public string cod_emp { get; set; }
        public string cod_fpago { get; set; }
        
        public string nom_fpago { get; set; }
        public string cod_docum { get; set; }
        public string cod_cta { get; set; }
        public string plazo { get; set; }
        public string cuotas { get; set; }
        public string dias_cuotas { get; set; }
        public string maneja_ter { get; set; }
        public string maneja_doc { get; set; }
        public string usuario_mod { get; set; }
      
        public DateTime fecha_mod { get; set; }
      
        public string nro_audit { get; set; }
        public string cod_pro_aud { get; set; }
        public string abierto { get; set; }
        public string numero_propio { get; set; }
        public string observacion { get; set; }

    }
}
