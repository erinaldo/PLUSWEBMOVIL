using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos.ModelosNC
{
   public  class JsonRespuestaNC
    {
        public string qrdata { get; set; }
        public string xml { get; set; }
        public string clavtec { get; set; }
        public string id { get; set; }
        public string cufe { get; set; }
        public string error { get; set; }
        public string json { get; set; }
        public string nro_trans { get; set; }
        public int linea { get; set; }
        public string result { get; set; }
    }
}
