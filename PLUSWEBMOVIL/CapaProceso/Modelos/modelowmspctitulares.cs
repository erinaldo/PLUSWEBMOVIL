using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.Modelos
{
   public  class modelowmspctitulares
    {


        public string cod_tit { get; set; }
        public string nom_tit { get; set; }
        public string cod_dgi { get; set; }
        public string nro_dgi { get; set; }

        public string nro_dgi2 { get; set; }
        public string nro_dgi1 { get; set; }
        public string dir_tit { get; set; }
     
        public string tel_tit { get; set; }
        public string fax_tit { get; set; }
        public string email_tit { get; set; }
        public string dir_web { get; set; }
        public string cod_pais { get; set; }
        public string nom_pais { get; set; }
        public string cod_provincia { get; set; }
        public string nom_provincia { get; set; }
        public string ciudad_tit { get; set; }
        public string nom_ciudad { get; set; }
        public string cod_tipo_emp_gan { get; set; }
        public string nom_tipo_emp_gan { get; set; }
        public string cod_tipo_emp_iva { get; set; }
        public string nom_aux { get; set; }
        public string nom_aux2 { get; set; }
        public string nom_aux3{ get; set; }
        public string nom_aux4 { get; set; }
        public string razon_social { get; set; }
        public string control_tit { get; set; }
        public string control_uso { get; set; }
        public string control_uso2 { get; set; }
        public string cod_sop { get; set; }

        public  modelowmspctitulares()
        {

        }

          public  modelowmspctitulares(string cod_tit, string nom_tit, string cod_dgi, string nro_dgi, string nro_dgi1, string nro_dgi2, string dir_tit, string tel_tit, string fax_tit, string email_tit, string dir_web, string cod_pais, string nom_pais, string cod_provincia, string nom_provincia, string ciudad_tit, string nom_ciudad, string cod_tipo_emp_gan, string nom_tipo_emp_gan, string cod_tipo_emp_iva, string nom_aux, string nom_aux2, string nom_aux3, string nom_aux4, string razon_social, string control_tit, string control_uso, string control_uso2, string cod_sop)
        {
            this.cod_tit = cod_tit;
            this.nom_tit = nom_tit;
            this.cod_dgi = cod_dgi;
            this.nro_dgi = nro_dgi;
            this.nro_dgi2= nro_dgi2;
            this.nro_dgi1 = nro_dgi1;
            this.dir_tit = dir_tit;
            this.tel_tit = tel_tit;
            this.fax_tit = fax_tit;
            this.email_tit = email_tit;
            this.dir_web = dir_web;
            this.cod_pais = cod_pais;
            this.nom_pais = nom_pais;
            this.cod_provincia = cod_provincia;
            this.nom_provincia = nom_provincia;
            this.ciudad_tit = ciudad_tit;
            this.nom_ciudad = nom_ciudad;
            this.cod_tipo_emp_gan = cod_tipo_emp_gan;
            this.nom_tipo_emp_gan = nom_tipo_emp_gan;
            this.cod_tipo_emp_iva = cod_tipo_emp_iva;
            this.nom_aux = nom_aux;
            this.nom_aux2 = nom_aux2;
            this.nom_aux3 = nom_aux3;
            this.nom_aux4 = nom_aux4;
            this.razon_social = razon_social;
            this.control_tit = control_tit;
            this.control_uso = control_uso;
            this.control_uso2 = control_uso2;
            this.cod_sop = cod_sop;
        }
        }
}
