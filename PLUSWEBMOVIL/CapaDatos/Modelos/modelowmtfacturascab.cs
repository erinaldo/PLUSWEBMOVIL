using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
   public  class modelowmtfacturascab
    {
        //consulta cabecera por nro_trans procedimiento wmtfacturascab
        public string observacion { get; set; }
        public string nro_trans { get; set; }
        public string cod_emp { get; set; }
        public DateTime fec_doc { get; set; }
        public string fec_doc_str { get; set; }        
        public string aniomes { get; set; }
        public string cod_docum { get; set; }
        public string serie_docum { get; set; }
        public string nro_docum { get; set; }
        public string cod_cliente { get; set; }
        public string nom_tit { get; set; }
        public string cod_ccostos { get; set; }
        public string nom_dpto { get; set; }
        public string dir_tit { get; set; }
        public string tel_tit { get; set; }
        public string nro_dgi { get; set; }
        public string nro_dgi2 { get; set; }
        public string nro_dgi1 { get; set; }
        public string cod_fpago { get; set; }
        public string nom_fpago { get; set; }
        public string plazo_libre { get; set; }
        public string observaciones { get; set; }
        public DateTime fec_venc { get; set; }
        public string fec_venc_str { get; set; }
        public string cod_vendedor { get; set; }
        public string nom_vendedor { get; set; }
        public string estado { get; set; }
        public decimal subtotal { get; set; }
        public decimal iva { get; set; }
        public decimal impuesto2 { get; set; }
        public decimal impuesto3 { get; set; }
        public decimal impuesto4 { get; set; }
        public decimal impuesto5 { get; set; }
        public decimal ret { get; set; }
        public decimal neto { get; set; }
        public decimal total { get; set; }
        public decimal monto_imponible { get; set; }
        public decimal porc_descto { get; set; }
        public decimal descuento { get; set; }
        public decimal suman { get; set; }
        public decimal signo { get; set; }
        public decimal Saldo { get; set; }
        public string nro_audit { get; set; }
        public string nom_ciudad { get; set; }
        public string vlr_letras { get; set; }
        public string cod_atrib1 { get; set; }
        public string ini { get; set; }
        public string fin { get; set; }
        public DateTime fres_ini { get; set; }
        public string fres_ini_str { get; set; }
        public DateTime fres_fin { get; set; }
        public string fres_fin_str { get; set; }
        public string mes_char { get; set; }
        public string pagina_edicion { get; set; }
        public string nom_edicion { get; set; }
        public string pagina_elimina { get; set; }
        public string nom_corto { get; set; }
        public string ntipo{ get; set; }
    
        public string ocompra { get; set; }
        public string cod_moneda { get; set; }
        public string sim { get; set; }
        public string nom_moneda { get; set; }
        public string nro_doc_inve { get; set; }
        public string cod_proc_aud { get; set; }
        public string cod_sucursal { get; set; }
        public string nro_pedido { get; set; }
        public string email_tit { get; set; }
        public string nro_trans_padre { get; set; }
        public string tipo_nce { get; set; }
        public string mot_nce { get; set; }
        //---datos sucursal
        public string cod_suc_cli { get; set; }
        public string nom_suc { get; set; }
        public string codnom_suc { get; set; }
        //recargos-descuento--tipo
        public string tipo { get; set; }
        public decimal desctos_rcgos { get; set; }
        public string des_rec_str { get; set; }

        //ICN
        public decimal icn{ get; set; }
        public string doc_adjunto { get; set; }
    }
}
