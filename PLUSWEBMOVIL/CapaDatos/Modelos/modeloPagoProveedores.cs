using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
   public  class modeloPagoProveedores
    {
        public string cod_docum { get; set; }
        public string nro_docum { get; set; }
        public string serie_docum { get; set; }
        public string documento { get; set; }
        public string cod_tit { get; set; }
        public string nom_tit { get; set; }
        public string fec_doc { get; set; }
        public string fec_st { get; set; }
        
        public string observaciones { get; set; }
        public string total { get; set; }
        public string total_st { get; set; }
        public string estado { get; set; }
        public decimal valor { get; set; }
    }
}
