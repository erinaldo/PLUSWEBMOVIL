using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
   public  class modeloCargosDscGlobalesF
    {

        public string nro_trans_dsc { get; set; }
        public string nro_docum_dsc { get; set; }
        public string dni_cliente_dsc { get; set; }
        public Int64 linea_dsc { get; set; }
        public string cod_concepto { get; set; }
        public decimal valor_dsc { get; set; }
        public string estado_dsc { get; set; }
        public DateTime fecha_dsc { get; set; }
        public string usuario_mod { get; set; }
        public Int64 socio_negocio { get; set; }
    }
}
