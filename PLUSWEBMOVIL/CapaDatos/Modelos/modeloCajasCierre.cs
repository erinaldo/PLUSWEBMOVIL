using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
   public  class modeloCajasCierre
    {
        public string cod_tit { get; set; }
        public string nom_tit { get; set; }
        public string tipocta_banco { get; set; }
        public string nomtcta_banco { get; set; }
        public string nrocta_banco { get; set; }
        public string cod_cta { get; set; }
        public string cod_moneda { get; set; }
        public string tipo_cuenta { get; set; }
    }
}
