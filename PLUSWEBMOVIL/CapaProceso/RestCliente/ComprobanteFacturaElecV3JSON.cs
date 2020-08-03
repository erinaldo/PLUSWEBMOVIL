using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.RestCliente
{

    public class DetalleFEV3
    {
        public string adicional { get; set; }
        public int cantidad { get; set; }
        public string idproducto { get; set; }
        public string idunidad { get; set; }
        public decimal iva { get; set; }
        public decimal ivausd { get; set; }
        public string nombreproducto { get; set; }
        public string operacion { get; set; }
        public int porcdcto { get; set; }
        public int porciva { get; set; }
        public int pos { get; set; }
        public decimal precio { get; set; }
        public decimal preciousd { get; set; }
        public string subpartidaarancelaria { get; set; }
        public decimal subtotal { get; set; }
        public decimal subtotalusd { get; set; }
        public string esexcluido { get; set; }
    }

    public class EncabezadoFEV3
    {
        public decimal baseimpuesto { get; set; }
        public string codmoneda { get; set; }
        public string comentarios { get; set; }
        public int emisor { get; set; }
        public decimal factortrm { get; set; }
        public string fecha { get; set; }
        public string fvence { get; set; }
        public int idsuc { get; set; }
        public int idvendedor { get; set; }
        public decimal iva { get; set; }
        public string mediopago { get; set; }
        
        public int metodopago { get; set; }
        
        public long nit { get; set; }
        public int numero { get; set; }
        public string ordencompra { get; set; }
        public string prefijo { get; set; }
        public decimal subtotal { get; set; }
        public int sucursal { get; set; }
        public string terminospago { get; set; }
        public decimal total { get; set; }
        public decimal otrosconceptos { get; set; }
        public int totalDet { get; set; }
        public int totalImp { get; set; }
        public int totalCon { get; set; }
        public string usuario { get; set; }
        public string versionfe { get; set; }
       
    }

    public class ImpuestoFEV3
    {
        public Decimal base_calculo { get; set; }
        public Decimal porciva { get; set; }
        public Decimal valor { get; set; }
    }

    public class SucursalFEV3    {
        public string ciudad { get; set; }
        public string codcliente { get; set; }
        public string codpostal { get; set; }
        public string contacto1 { get; set; }
        public string ctoemail1 { get; set; }
        public string departamento { get; set; }
        public string direccion1 { get; set; }
        public string dpto { get; set; }
        public string email { get; set; }
        public string emailfe { get; set; }
        public int idsuc { get; set; }
        public Int64 idvendedor { get; set; }
        public string movil { get; set; }
        public string mun { get; set; }
        public string paisreceptor { get; set; }
        public string razonsocial { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
    }

    public class TerceroFEV3
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
        public string obligacionfiscal { get; set; }
        public string razonsocial { get; set; }
        public string regimentributacion { get; set; }
        public int tdoc { get; set; }
        public string tipopersona { get; set; }
        public string tributoreceptor { get; set; }
    }

    public class Concepto
    {
        public string naturaleza { get; set; }
        public string transaccion { get; set; }
		public string coddescuento { get; set; }
        public decimal valor { get; set; }
    }
    public class DocumentoFEV3
    {
        public List<DetalleFEV3> detalle { get; set; }
        public EncabezadoFEV3 encabezado { get; set; }
        public List<Concepto> concepto { get; set; }
        public List<ImpuestoFEV3> impuesto { get; set; }
        public SucursalFEV3 sucursal { get; set; }
        public TerceroFEV3 tercero { get; set; }
    }

    public class ComprobanteFacturaElecV3JSON
    {
        public DocumentoFEV3 documento { get; set; }
    }
}
