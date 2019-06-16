using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
    public class modelowmspcarticulos
    {

        public string cod_articulo { get; set; }
        public string nom_articulo { get; set; }
        public string nom_det_art { get; set; }
        public string cod_grpunidad { get; set; }

        public string activo_stk { get; set; }
        public string activo_com { get; set; }
        public string cod_tipoart { get; set; }

        public Decimal volumen_art { get; set; }
        public string activo_cmp { get; set; }
        public string cod_concepret { get; set; }
        public string cod_cta_vtas { get; set; }
        public string cod_cta_inve { get; set; }
        public string cod_cta_cos { get; set; }
        public string cod_tipo_impu { get; set; }
        public string cod_tasa_impu { get; set; }
        public string porc_impuesto { get; set; }
        public string nom_impuesto { get; set; }
        public string precio { get; set; }
        public string valor_impu { get; set; }
        public string precio_total { get; set; }
        
    }
}
