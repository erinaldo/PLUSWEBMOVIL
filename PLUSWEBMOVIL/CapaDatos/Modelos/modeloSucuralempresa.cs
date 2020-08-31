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
        public string serie_factura { get; set; }
        public string serie_facn { get; set; }
        public string serie_nc { get; set; }
        public string serie_nd { get; set; }
        public string serie_ncn { get; set; }
        public string serie_ndn { get; set; }
        public string cod_ciudad { get; set; }
        public string cod_provincia { get; set; }
        public string cod_pais { get; set; }
        public string nom_ciudad { get; set; }
    }
}
