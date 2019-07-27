using CapaDatos.Modelos;
using CapaDatos.Modelos.ModelosNC;
using CapaDatos.Sql;
using CapaDatos.Sql.SqlNC;
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

        //NC SOLO TRANS_PADRE
        public List<modelowmtfacturascab> ConsultaNCTransPadre(string nro_trans)
        {
            List<modelowmtfacturascab> lista = new List<modelowmtfacturascab>();
            lista = consulta.ConsultaDatosNCPadre(nro_trans);

            return lista;
        }
        public List<modelowmtfacturascab> ConsultaCabFacura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string Ccf_estado, string Ccf_cliente, string Ccf_cod_docum, string Ccf_serie_docum, string Ccf_nro_docum, string Ccf_diai, string Ccf_mesi, string Ccf_anioi, string Ccf_diaf, string Ccf_mesf, string Ccf_aniof)
        {
            List<modelowmtfacturascab> lista = new List<modelowmtfacturascab>();
            lista = consulta.ConsultaFacturaNroTran(Ccf_cod_emp,  Ccf_usuario,  Ccf_tipo1, Ccf_tipo2,  Ccf_nro_trans,  Ccf_estado,  Ccf_cliente, Ccf_cod_docum,  Ccf_serie_docum,  Ccf_nro_docum,  Ccf_diai,  Ccf_mesi,  Ccf_anioi,  Ccf_diaf, Ccf_mesf, Ccf_aniof);

            return lista;
        }

        /*CONSULTA DOCUMENTOS ELECTRONICOS*/
        SaldosFacturas consultaSaldoa = new SaldosFacturas();
        public List<modelowmtfacturascab> ConsultaDocElectronicos(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string Ccf_estado, string Ccf_cliente, string Ccf_cod_docum, string Ccf_serie_docum, string Ccf_nro_docum, string Ccf_diai, string Ccf_mesi, string Ccf_anioi, string Ccf_diaf, string Ccf_mesf, string Ccf_aniof)
        {
            modeloFacturasElecSaldos ModeloDocElec = new modeloFacturasElecSaldos();
            List<modelowmtfacturascab> lista = new List<modelowmtfacturascab>();
            List<modelowmtfacturascab> listaAux = new List<modelowmtfacturascab>();
            lista = consulta.ConsultaFacturaNroTran(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
            foreach (var item in lista)
            {
                ModeloDocElec = BuscartaDocElelectronicos(Ccf_cod_emp, item.nro_trans);
                if (ModeloDocElec != null)
                {
                    listaAux.Add(item);
                }

            }

            return listaAux;
            
        }

        //lista cufe pra doc ele
       
        public modeloFacturasElecSaldos BuscartaDocElelectronicos( string cod_emp, string nro_trans)
        {
            modeloFacturasElecSaldos item = new modeloFacturasElecSaldos();
            item = consultaSaldoa.ConsultaDocumEletronicos(cod_emp, nro_trans);
            return item;
        }
    }
}
