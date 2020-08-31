using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
    public class modelowmspcresfact
    {
        public string cod_atrib1 { get; set; }
        public string serie_docum { get; set; }
        public string nro_docum { get; set; }
        public string nro_docum_ref { get; set; }

        public string activo { get; set; }
        public string numerador { get; set; }
        public DateTime fec_valor { get; set; }
        public string fec_emision { get; set; }
        public string fec_caducidad { get; set; }
        public DateTime fec_venc { get; set; }
        public string tipo { get; set; }
        public string tipo_fac { get; set; }
        public string meses { get; set; }
        public string prefijo { get; set; }
        public string cod_sucursal { get; set; }
        public string nom_sucursal { get; set; }


    }
}
