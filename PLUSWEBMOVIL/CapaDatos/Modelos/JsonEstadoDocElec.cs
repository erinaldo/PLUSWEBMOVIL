using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{
    public class RespuestaDE
    {
        public string descripcion { get; set; }
        public string secuencia { get; set; }
    }


    public class DIANED
    {
        public string nro_trans { get; set; }
        public string secuencia { get; set; }
        public int linea { get; set; }
        public string Mensaje { get; set; }
        public string Xml { get; set; }
        public string Valido { get; set; }
        public string Descripcion { get; set; }
        public string StatusCode { get; set; }
        public List<RespuestaDE> Respuesta { get; set; }
    }
    public class Documento
    {
        public string prefijodian { get; set; }
        public string resolucion { get; set; }
    }
    public class Docpdf
    {
        public string Resultado { get; set; }
        public string pdfbase64 { get; set; }
    }
    public  class JsonEstadoDocElec
    {
        public string qrdata { get; set; }
        public string DIAN { get; set; }
        public string xml { get; set; }
        public string id { get; set; }
        public string cufe { get; set; }
        public string error { get; set; }
        public string documento { get; set; }
        public string cargopdf { get; set; }
        public string docpdf { get; set; }
        public string foperacion { get; set; }
        public string emailfe { get; set; }
        public string json { get; set; }
        public string jsonrRespuesta { get; set; }
        public string nro_trans { get; set; }
        public int linea { get; set; }
        public DateTime fecha_mod { get; set; }
        public string usuario_mod { get; set; }
        public string cod_emp { get; set; }
    }
}
