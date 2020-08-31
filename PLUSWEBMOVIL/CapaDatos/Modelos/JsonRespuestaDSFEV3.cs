using System.Collections.Generic;

namespace CapaDatos.Modelos
{

    public class Respuesta3
    {
        public string descripcion { get; set; }
        public string secuencia { get; set; }
    }


    public class DIAN3
    {
        public string nro_trans { get; set; }
        public string secuencia { get; set; }
        public int linea { get; set; }
        public string Mensaje { get; set; }
        public string Xml { get; set; }
        public string Valido { get; set; }
        public string Descripcion { get; set; }
        public string StatusCode { get; set; }
        public List<Respuesta3> Respuesta { get; set; }
    }
    public class JsonRespuestaDSFEV3
    {
        public string qrdata { get; set; }
        public List<DIAN3> DIAN { get; set; }
        public string xml { get; set; }
        public string id { get; set; }
        public string cufe { get; set; }
        public string error { get; set; }
        public string json { get; set; }
        public string jsonrRespuesta { get; set; }
        public string nro_trans { get; set; }
        public int linea { get; set; }
        public string result { get; set; }
        public string adjunto { get; set; }
        public bool respuestaerror { get; set; }
    }

}





