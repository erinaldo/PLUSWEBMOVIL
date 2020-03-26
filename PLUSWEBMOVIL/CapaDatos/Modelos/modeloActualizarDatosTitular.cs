using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
   public class modeloActualizarDatosTitular
    {

        //wmspr_acttitular SP para actualizar datos del titular en el RP
        public string usuario { get; set; }
        public string empresa { get; set; }
        public string cod_tit { get; set; }
        
        public string parametro { get; set; }
        public string valor { get; set; }
        public string sucursal { get; set; }

    }
}
