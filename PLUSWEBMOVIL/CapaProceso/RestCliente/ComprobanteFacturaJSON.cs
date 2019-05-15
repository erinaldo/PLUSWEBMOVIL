using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.RestCliente
{
    
    public class Detalle
    {
        public int cantidad { get; set; }
        public string codimp { get; set; }
        public int costo { get; set; }
        public int dcto_fam { get; set; }
        public int dcto_vol { get; set; }
        public int descuento { get; set; }
        public int factor { get; set; }
        public string idbodega { get; set; }
        public string idproducto { get; set; }
        public string idunidad { get; set; }
        public int iva { get; set; }
        public int neto { get; set; }
        public string operacion { get; set; }
        public int porcdcto { get; set; }
        public int porciva { get; set; }
        public int pos { get; set; }
        public int precio { get; set; }
        public int subtotal { get; set; }
        public int unidades { get; set; }
        public int valorbruto { get; set; }
        public int vdescuento { get; set; }
        public string adicional { get; set; }
    }

    public class Encabezado
    {
        public Int64 emisor { get; set; }
        //public string codmoneda { get; set; }
        public string anulado { get; set; }
        public string comentarios { get; set; }
              
        public Decimal descuento { get; set; }
        public string fecha { get; set; }
        public int idsuc { get; set; }
        public int idvendedor { get; set; }
        public Decimal iva { get; set; }
        public int nit { get; set; }
        public int numero { get; set; }
        public string ordencompra { get; set; }
        public string prefijo { get; set; }
        public int retefuente { get; set; }
        public int reteica { get; set; }
        public int reteiva { get; set; }
        public int subtotal { get; set; }
        public int sucursal { get; set; }
        public int total { get; set; }
        public string usuario { get; set; }
        public int totalDet { get; set; }
        public int totalImp { get; set; }
        public int totalPag { get; set; }
    }

    public class Impuesto
    {
        public int base_calculo { get; set; }
        public string codimp { get; set; }
        public string liquida { get; set; }
        public int valor { get; set; }
    }

    public class Pago
    {
        public int idformapago { get; set; }
        public string fvence { get; set; }
        public int valor { get; set; }
        public int plazo { get; set; }
        public string ref_doc { get; set; }
    }

    public class Sucursal
    {
        public string cargo1 { get; set; }
        public string ciudad { get; set; }
        public string codcliente { get; set; }
        public string departamento { get; set; }
        public string direccion1 { get; set; }
        public string dpto { get; set; }
        public string email { get; set; }
        public string fax { get; set; }
        public int idbarrio { get; set; }
        public int idformapago { get; set; }
        public int idsuc { get; set; }
        public int idvendedor { get; set; }
        public int idzona { get; set; }
        public string movil { get; set; }
        public string mun { get; set; }
        public string razonsocial { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public int dctofinanciero { get; set; }
    }

    public class Tercero
    {
        public string apl2 { get; set; }
        public string apli1 { get; set; }
        public string cliente_credito { get; set; }
        public string comentarios { get; set; }
        public string dv { get; set; }
        public string escliente { get; set; }
        public DateTime fechacreacion { get; set; }
        public DateTime frevision { get; set; }
        public int identificacion { get; set; }
        public int idtipoempresa { get; set; }
        public int nit { get; set; }
        public string nit2 { get; set; }
        public string nom1 { get; set; }
        public string nom2 { get; set; }
        public string razonsocial { get; set; }
        public int tdoc { get; set; }
        public string tipopersona { get; set; }
        public string usuario { get; set; }
    }

    public class ComprobanteFacturaJSON
    {
        public List<Detalle> detalle { get; set; }
        public Encabezado encabezado { get; set; }
        public List<Impuesto> impuesto { get; set; }
        public List<Pago> pago { get; set; }
        public Sucursal sucursal { get; set; }
        public Tercero tercero { get; set; }
    }
}
