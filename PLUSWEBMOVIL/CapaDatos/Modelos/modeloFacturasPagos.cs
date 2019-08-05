using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
    public class modeloFacturasPagos
    {
       
       
        public string nro_trans { get; set; }
        public int linea { get; set; }
        public string cod_emp { get; set; }
        public string cod_fpago { get; set; }
        public string cod_tit { get; set; }
        public string cod_docum { get; set; }
        public string nro_docum { get; set; }
        public string cod_cta { get; set; }
        
        public decimal recibido { get; set; }
        public decimal valor { get; set; }
        public decimal diferencia { get; set; }
        public decimal sumaTotalPago { get; set; }
        public decimal sumaDiferencia { get; set; }
    }
}
