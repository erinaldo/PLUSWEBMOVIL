using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
    public class modelowmspcresfact
    {
        public string cod_atrib1 { get; set; }
        public string serie_docum { get; set; }
        public string nro_docum { get; set; }
        public string nro_docum_ref { get; set; }

        public string activo { get; set; }
        public string numerador { get; set; }
        public DateTime fec_valor { get; set; }

        public DateTime fec_venc { get; set; }
        public string tipo { get; set; }


        public modelowmspcresfact()
        {
        }
        public modelowmspcresfact(string cod_atrib1, string serie_docum, string nro_docum, string nro_docum_ref, string activo, string numerador, DateTime fec_valor, DateTime fec_venc, string tipo)
        {
            this.cod_atrib1 = cod_atrib1;
            this.serie_docum = serie_docum;
            this.nro_docum = nro_docum;
            this.nro_docum_ref = nro_docum_ref;
            this.activo = activo;
            this.numerador = numerador;
            this.fec_valor = fec_valor;
            this.fec_venc = fec_venc;
            this.tipo = tipo;
        }
    }
}
