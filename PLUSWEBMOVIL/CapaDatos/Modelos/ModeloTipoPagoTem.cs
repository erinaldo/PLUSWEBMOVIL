using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
   public  class ModeloTipoPagoTem
    {
        public string nro_trans { get; set; }
        public string cod_emp { get; set; }
        public string cod_fpago { get; set; }

        public string nom_fpago { get; set; }
        public string cod_docum { get; set; }
        public string cod_cta { get; set; }
        
       
        public string modif_ter { get; set; }
        public string cod_ter { get; set; }
        public string ter_campo { get; set; }
        public string modif_doc { get; set; }
        public string nro_doc { get; set; }
        public string doc_campo { get; set; }
        public string vuelto { get; set; }


    }
}
