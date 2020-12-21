using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos
{   
    public class JsonDocumentosPWMItem
    {
        public string XcCxCSer { get; set; }
        public string XcCxCNum { get; set; }
        public string XmTDcCod { get; set; }
        public string AmComComPwm { get; set; }
        public string AmUsrLog { get; set; }
    }

    public class JsonDocumentosPWM
    {
        public List<JsonDocumentosPWMItem> jsonDocumentosPWMItem { get; set; }
    }
}
