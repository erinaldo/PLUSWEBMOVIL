using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.Modelos
{
  public   class modeloestadosfactura
    {
        public string cod_proceso { get; set; }
        public string estado { get; set; }
        public string nom_estado { get; set; }
        public string nom_corto { get; set; }
        public string pagina_edicion { get; set; }
        public string nom_edicion { get; set; }
        public string pagina_elimina { get; set; }
        public string nom_elimina { get; set; }
        public string usuario_mod { get; set; }
        public DateTime fecha_mod { get; set; }
        public int nro_audit { get; set; }
        public string cod_proc_aud { get; set; }
    }
}
