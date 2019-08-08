using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
   public  class modeloFacturaPgs
    {
        //EXEC wmspc_fpagoPOS  'OANDAGOY','01','425','2' x todo o por linea
        public string nro_trans { get; set; }
        public string cod_emp { get; set; }
        public int linea { get; set; }
        
        public string cod_fpago { get; set; }

        public string nom_fpago { get; set; }
        public string cod_docum { get; set; }
        public string nom_docum { get; set; }
        public string nro_docum { get; set; }
        public string cod_cta { get; set; }
        public string nom_cta { get; set; }
        public string cod_tit { get; set; }
        public string nom_tit { get; set; }
        public decimal recibido { get; set; }
        public decimal valor { get; set; }
        public decimal diferencia { get; set; }
     
        public string mod_ter { get; set; }
        public string cod_ter { get; set; }
        public string ter_campo { get; set; }
        public string modif_doc { get; set; }
        public string nro_doc { get; set; }
        public string doc_campo { get; set; }
        public string forma_pago { get; set; }
        public string tercero { get; set; }


    }
}
