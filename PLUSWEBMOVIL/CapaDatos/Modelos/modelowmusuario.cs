using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.Modelos
{
     public class modelowmusuario
    {
        public string usuario { get; set;}
        public string clave { get; set; }
        public string Nombre { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_actualizacion { get; set; }
        public string estado_usuario { get; set; }
        public string usuario_sistema { get; set; }
        public string pregunta { get; set; }
        public string respuesta { get; set; }
        public DateTime fecha_ult_login { get; set; }
        public Int64 nro_login { get; set; }
        public Int64 nro_audit { get; set; }
        public string usuario_mod { get; set; }
        public DateTime fecha_mod { get; set; }
        public string email { get; set; }
        public string cod_proc_aud { get; set; }
        public string usuario_erp { get; set; }

       
    }
}
