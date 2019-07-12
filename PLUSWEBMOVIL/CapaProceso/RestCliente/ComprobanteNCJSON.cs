using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.RestCliente
{

    public class DetalleNC
    {
        public string adicional { get; set; }
        public int cantidad { get; set; }
        public string idproducto { get; set; }
        public string idunidad { get; set; }
        public int iva { get; set; }
        public Decimal ivausd { get; set; }
        public string nombreproducto { get; set; }
        public string operacion { get; set; }
        public int porcdcto { get; set; }
        public int porciva { get; set; }
        public int pos { get; set; }
        public int precio { get; set; }
        public Decimal preciousd { get; set; }
        public int subtotal { get; set; }
        public Decimal subtotalusd { get; set; }
    }

    public class EncabezadoNC
    {
        public string codmoneda { get; set; }
        public string comentarios { get; set; }
        public int emisor { get; set; }
        public Decimal factortrm { get; set; }
        public string fecha { get; set; }
        public string fvence { get; set; }
        public int idsuc { get; set; }
        public int idvendedor { get; set; }
        public decimal iva { get; set; }
        public long nit { get; set; }
        public int numero { get; set; }
        public string ordencompra { get; set; }
        public string prefijo { get; set; }
        public decimal subtotal { get; set; }
        public int sucursal { get; set; }
        public decimal total { get; set; }
        public string usuario { get; set; }
        public int totalDet { get; set; }
        public int totalImp { get; set; }
        public string ref_doc { get; set; }
        public long ref_num { get; set; }
        public string ref_fecha { get; set; }
        public string ref_cufe { get; set; }
        public int tlmotivodv { get; set; }
    }

    public class ImpuestoNC
    {
        public Decimal base_calculo { get; set; }
        public Decimal porciva { get; set; }
        public Decimal valor { get; set; }
    }

    public class SucursalNC
    {
        public string ciudad { get; set; }
        public string codcliente { get; set; }
        public string departamento { get; set; }
        public string direccion1 { get; set; }
        public string dpto { get; set; }
        public string email { get; set; }
        public string emailfe { get; set; }
        public int idsuc { get; set; }
        public Int64 idvendedor { get; set; }
        public string movil { get; set; }
        public string mun { get; set; }
        public string razonsocial { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
    }

    public class TerceroNC
    {
        public string apl2 { get; set; }
        public string apli1 { get; set; }
        public string comentarios { get; set; }
        public string dv { get; set; }
        public long identificacion { get; set; }
        public int idtipoempresa { get; set; }
        public long nit { get; set; }
        public string nom1 { get; set; }
        public string nom2 { get; set; }
        public string razonsocial { get; set; }
        public int tdoc { get; set; }
        public string tipopersona { get; set; }
    }

    public class DocumentoNC
    {
        public List<DetalleNC> detalle { get; set; }
        public EncabezadoNC encabezado { get; set; }
        public List<ImpuestoNC> impuesto { get; set; }
        public SucursalNC sucursal { get; set; }
        public TerceroNC tercero { get; set; }
    }

    public class ComprobanteNCJSON
    {
        public DocumentoNC documento { get; set; }
    }
}
