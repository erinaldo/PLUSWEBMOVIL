using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
   public class modelocabecerafactura
    {
        
        public string cod_cliente { get; set; }
        public string dia { get; set; }
        public string mes { get; set; }
        public string anio { get; set; }
        public string fec_doc { get; set; }
        

        public string serie_docum { get; set; }
        public string cod_ccostos { get; set; }
        public string cod_vendedor { get; set; }

        public string cod_fpago { get; set; }
        public string observaciones { get; set; }
        public string nro_trans { get; set; }
       
            
        public string cod_emp { get; set; }
        public string cod_docum { get; set; }
        public string nro_docum { get; set; }
        public decimal subtotal { get; set; }
        public decimal iva { get; set; }
        public decimal monto_imponible { get; set; }
        public decimal total { get; set; }
        public string estado { get; set; }
        public string usuario_mod { get; set; }
        public string nro_audit { get; set; }
        public string ocompra { get; set; }
        public string cod_moneda { get; set; }
        public string tipo { get; set; }

        public decimal porc_descto { get; set; }
        public decimal descuento { get; set; }
        public string diar { get; set; }
        public string mesr { get; set; }
        public string anior { get; set; }
        public string cod_proc_aud { get; set; }
        public string cod_sucursal { get; set; }
        public string nro_pedido { get; set; }
        public string nro_trans_padre { get; set; }
        public string tipo_nce { get; set; }
        public string mot_nce { get; set; }

    }
}
