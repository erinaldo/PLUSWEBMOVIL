using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
   public class modeloFPagosF
    {
        public string nro_trans_pgs { get; set; }
        public string nro_docum_pgs { get; set; }
        public string dni_cliente_pgs { get; set; }
        public Int64 linea_pgs { get; set; }
        public string cod_fpag { get; set; }
        public string nro_doc_pag { get; set; }
        public string estado_pgs { get; set; }
        public string cod_tercero { get; set; }
        public decimal valor_pgs { get; set; }
        public DateTime fecha_pgs { get; set; }
        public string usuario_mod { get; set; }
        public Int64 socio_negocio { get; set; }
    }
}
