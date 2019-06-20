using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos.ModelosNC
{
  public  class modeloSaldosFacturas
    {
        //Consultar saldos de factura para NC
        public string observacion { get; set; }
        public string nro_trans { get; set; }
        public string nro_trans_ndm { get; set; }
        public string cod_docum { get; set; }
        public string nro_docum { get; set; }
        public string serie_docum { get; set; }
        public DateTime fec_doc { get; set; }
        public DateTime fec_venc { get; set; }
        public string cod_cliente { get; set; }
        public string documento { get; set; }
        public string observaciones { get; set; }
        public decimal total { get; set; }
        public decimal saldo { get; set; }
        public string sim { get; set; }
        public string fec_doc_str { get; set; }
    }
}
