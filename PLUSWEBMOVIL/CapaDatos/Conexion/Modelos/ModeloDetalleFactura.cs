using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.Modelos
{
   public  class ModeloDetalleFactura
    {
          
        public string cod_articulo { get; set; }
        public string nom_articulo { get; set; }
        public string nom_articulo2 { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio_unit { get; set; }
        public decimal base_imp { get; set; }
        public decimal porc_iva { get; set; }
        public string nro_trans { get; set; }
        public int linea { get; set; }
        public string cod_emp { get; set; }
        public string cod_concepret { get; set; }
        public decimal porc_descto { get; set; }
        public decimal valor_descto { get; set; }
        public string cod_cta_vtas { get; set; }
        public string cod_cta_cos { get; set; }
        public string cod_cta_inve { get; set; }
        public string usuario_mod { get; set; }
        public string nro_audit { get; set; }
        public DateTime fecha_mod { get; set; }
        public string tasa_iva { get; set; }
        public string cod_ccostos { get; set; }
        public decimal total { get; set; }
        public decimal subtotal { get; set; }
        public decimal descuento { get; set; }
        public decimal detadescuento { get; set; }
        public decimal detaiva { get; set; }
        public decimal detasubtotal { get; set; }
        public decimal poriva { get; set; }
        public decimal subdos{ get; set; }

    }
}
