using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
   public class modeloproformadetalle
    {
        public string nro_trans { get; set; }
        public int linea { get; set; }
        public string cod_emp { get; set; }
        
        public string cod_articulo { get; set; }
        public string cod_articulo2 { get; set; }
        public string nom_articulo { get; set; }
        public string nom_articulo2 { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio_unit { get; set; }
        public decimal base_imp { get; set; }
        public string cod_concepret { get; set; }
        public decimal subtotal { get; set; }
        public string cod_impu1 { get; set; }
        public string tasa_iva { get; set; }
        public decimal porc_iva { get; set; }
        public decimal poriva { get; set; }
        public decimal descuento { get; set; }
        public decimal subdos { get; set; }
        public decimal base_iva { get; set; }
        public decimal valor_iva { get; set; }
        public string cod_impu2 { get; set; }
        public string tasa_impu2 { get; set; }
        public decimal porc_impu2 { get; set; }
        public decimal valor_impu2 { get; set; }

        public string cod_impu3 { get; set; }
        public string tasa_impu3 { get; set; }
        public decimal porc_impu3 { get; set; }
        public decimal valor_impu3 { get; set; }
        public string cod_impu4 { get; set; }
        public string tasa_impu4 { get; set; }
        public decimal porc_impu4 { get; set; }
        public decimal valor_impu4 { get; set; }
        public string cod_impu5 { get; set; }
        public string tasa_impu5 { get; set; }
        public decimal porc_impu5 { get; set; }
        public decimal valor_impu5 { get; set; }

        public decimal total { get; set; }

        public decimal porc_descto { get; set; }
        public decimal valor_descto { get; set; }
        public string cod_cta_vtas { get; set; }
        public string cod_cta_cos { get; set; }
        public string cod_cta_inve { get; set; }
        public string usuario_mod { get; set; }
        public string nro_audit { get; set; }
        public DateTime fecha_mod { get; set; }
        public string cod_ccostos { get; set; }
        public decimal detadescuento { get; set; }
        public decimal detaiva { get; set; }
        public decimal porc_aiu { get; set; }
        public string cod_doca { get; set; }
        public string nro_doca { get; set; }
        public string serie_doca { get; set; }


    }
}
