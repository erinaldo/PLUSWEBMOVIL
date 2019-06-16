using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
    public class modeloSucuralempresa
    {
        //tabla wmm_sucuremp
        public string cod_emp { get; set; }
        public string cod_sucursal  { get; set; }
        public string nom_sucursal { get; set; }
        public string dir_sucursal { get; set; }
        public string tel_sucursal { get; set; }
        public string email_sucursal { get; set; }
        public string usuario_mod { get; set; }
        public DateTime fecha_mod { get; set; }
        public string nro_audit { get; set; }
        public string cod_proc_aud { get; set; }
        public string sucursales { get; set; }
    }
}
