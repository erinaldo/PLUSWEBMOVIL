using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;



namespace CapaProceso.Consultas
{
   public  class Consultawmtfacturascab
    {
        FacturACab consulta = new FacturACab();
        modelowmtfacturascab modelocons = new modelowmtfacturascab();
      
        public List<modelowmtfacturascab> ConsultaCabFacura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string Ccf_estado, string Ccf_cliente, string Ccf_cod_docum, string Ccf_serie_docum, string Ccf_nro_docum, string Ccf_diai, string Ccf_mesi, string Ccf_anioi, string Ccf_diaf, string Ccf_mesf, string Ccf_aniof)
        {
            List<modelowmtfacturascab> lista = new List<modelowmtfacturascab>();
            lista = consulta.ConsultaFacturaNroTran(Ccf_cod_emp,  Ccf_usuario,  Ccf_tipo1, Ccf_tipo2,  Ccf_nro_trans,  Ccf_estado,  Ccf_cliente, Ccf_cod_docum,  Ccf_serie_docum,  Ccf_nro_docum,  Ccf_diai,  Ccf_mesi,  Ccf_anioi,  Ccf_diaf, Ccf_mesf, Ccf_aniof);

            return lista;
        }
    }
}
