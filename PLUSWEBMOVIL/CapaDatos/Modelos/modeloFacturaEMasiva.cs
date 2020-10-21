using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
   public  class modeloFacturaEMasiva
    {
        //consulta wmh_cargafacturas
        public string nro_trans { get; set; }
        public string tipo_docum { get; set; }
        public string serie_docum { get; set; }
        public string nro_docum { get; set; }
        public string dni_cliente { get; set; }
        public string cod_cliente { get; set; }
        public Int64 socio_negocio { get; set; }
        public string razon_social { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string terminos_pago { get; set; }
        public string cod_termino { get; set; }

        public DateTime fecha_emision { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public string vendedor { get; set; }
        public string moneda { get; set; }
        public string observaciones { get; set; }
        public Int64 linea_pro { get; set; }
        public string articulo { get; set; }
        public string cod_articulo { get; set; }
        public string descripcion1 { get; set; }
        public string descripcion2 { get; set; }
        public decimal cant_pro { get; set; }
        public decimal precio_unit { get; set; }
        public decimal porc_iva { get; set; }
        public decimal neto { get; set; }
        public decimal iva { get; set; }
        public decimal total_fac { get; set; }
        public decimal porc_desc { get; set; }
        public string estado_fac { get; set; }
        public DateTime fecha_carga { get; set; }
        public string usuario_mod { get; set; }
        public string cod_ciudad { get; set; }
        public string cod_moneda { get; set; }
        public string cod_vendedor { get; set; }
        public string cod_suc_cli { get; set; }
        public string motivo { get; set; }
        public string cod_emp { get; set; }
    }
}
