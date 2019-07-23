using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos.ModelosNC
{
    public class modeloFacturasElecSaldos
    {
        //Consultar saldos de factura para NC por sql
        public string cod_emp { get; set; }
        public string nro_trans { get; set; }
       
        public string cufe{ get; set; }
        public string nro_docum { get; set; }
        public string serie_docum { get; set; }
    }
}
