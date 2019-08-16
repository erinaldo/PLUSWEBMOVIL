using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
   public  class modelowmspcmonedas
    {

        public string cod_moneda { get; set; }
        public string nom_moneda { get; set; }
        public string descripcion { get; set; }
        public string simbolo_moneda { get; set; }
        public string redondeo { get; set; } //para cantidades gloables
        public string redondeo_pu { get; set; } //para valores unitarios como precios
    }
}
