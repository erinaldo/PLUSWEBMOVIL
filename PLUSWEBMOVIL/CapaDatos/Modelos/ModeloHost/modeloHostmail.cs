using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Modelos.ModeloHost
{
    public class modeloHostmail
    {
        public string cod_emp { get; set; }
        public string nom_empresa { get; set; }
        public string remitente { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }
        public int puerto { get; set; }
        public string smtp { get; set; }
        public int autentificacion { get; set; }
        public int secure { get; set; }
        public string subject { get; set; }
        public string html_text { get; set; }
        public string firma { get; set; }
    }
}
