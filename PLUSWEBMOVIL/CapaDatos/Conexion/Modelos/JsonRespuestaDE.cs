﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.Modelos
{
   public  class JsonRespuestaDE
    {
        public string qrdata { get; set; }
        public string xml { get; set; }
        public string id { get; set; }
        public string cufe { get; set; }
        public string error { get; set; }
        public string json { get; set; }
        public string nro_trans { get; set; }
        public int linea { get; set; }
    }
}
