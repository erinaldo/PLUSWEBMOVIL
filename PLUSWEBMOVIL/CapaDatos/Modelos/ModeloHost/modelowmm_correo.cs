using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos.ModeloHost
{
    public class modelowmm_correo
    {
        public string cod_emp { get; set; }
        public string cod_proceso { get; set; }
        public string cod_mail { get; set; }
        public string nom_mail { get; set; }
        public string observaciones { get; set; }
        public string perfil_mail { get; set; }
        public string automatico { get; set; }
        public string sp { get; set; }
        public string titulo { get; set; }
        public string texto { get; set; }
        public string firma { get; set; }
        public string usuario_mod { get; set; }
        public string fecha_mod { get; set; }
        public string nro_audit { get; set; }

        public string job_name { get; set; }
        public string step_id { get; set; }
        public string schedule_id { get; set; }
        public string cod_proc_aud { get; set; }
        public string repeticiones { get; set; }
  
    }
}
