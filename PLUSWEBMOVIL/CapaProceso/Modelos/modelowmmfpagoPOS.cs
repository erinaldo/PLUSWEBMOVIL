using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.Modelos
{
    public class modelowmmfpagoPOS
    {
        public string cod_emp { get; set; }
        public string cod_fpago { get; set; }
        public string nom_fpago { get; set; }
        public string cod_docum { get; set; }

        public string cod_cta { get; set; }
        public int plazo { get; set; }
        public int cuotas { get; set; }

        public int dias_cuotas { get; set; }
        public string maneja_ter { get; set; }
        public string maneja_doc { get; set; }
        public string usuario_mod { get; set; }
        public DateTime fecha_mod { get; set; }
        public int nro_audit { get; set; }
        public string cod_proc_aud { get; set; }
        public string abierto { get; set; }
        public string numero_propio { get; set; }

        public modelowmmfpagoPOS()
        {
        }
        public modelowmmfpagoPOS(string cod_emp, string cod_fpago, string nom_fpago, string cod_docum, string cod_cta, int plazo, int cuotas, int dias_cuotas, string maneja_ter,string maneja_doc, string usuario_mod, DateTime fecha_mod, int nro_audit, string cod_proc_aud, string abierto, string numero_propio)
        {

            this.cod_emp = cod_emp;
            this.cod_fpago = cod_fpago;
            this.nom_fpago = nom_fpago;
            this.cod_docum = cod_docum;
            this.cod_cta = cod_cta;
            this.plazo = plazo;
            this.cuotas = cuotas;
            this.dias_cuotas = dias_cuotas;
            this.maneja_ter = maneja_ter;
            this.maneja_doc = maneja_doc;
            this.usuario_mod = usuario_mod;
            this.fecha_mod = fecha_mod;
            this.nro_audit = nro_audit;
            this.cod_proc_aud = cod_proc_aud;
            this.abierto = abierto;
            this.numero_propio = numero_propio;


        }
    }
}
