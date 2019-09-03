using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
   public  class modeloIngresoFacturas
    {
        public string nro_trans { get; set; }
        public string cod_tit { get; set; }
        public string nom_tit { get; set; }
        
        public string fec_doc { get; set; }
        public string documento { get; set; }
        public decimal recibido{ get; set; }
        public decimal total { get; set; }
        public decimal diferencia { get; set; }
        public decimal efectivo { get; set; }
        public string cod_docum { get; set; }
        public string serie_docum { get; set; }
        public string nro_docum { get; set; }
        public string nom_fpago { get; set; }
        public string razon_social { get; set; }
}
}
