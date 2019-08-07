using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
  public class ModeloDiferenciaPagos
    {
        public string nro_trans { get; set; }
        public string total { get; set; }
        public string pagado { get; set; }
        public string diferencia { get; set; }
        public string color { get; set; }
    }
}
