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
            SqlDataReader dr = consulta.ConsultaFacturaNroTran(Ccf_cod_emp,  Ccf_usuario,  Ccf_tipo1, Ccf_tipo2,  Ccf_nro_trans,  Ccf_estado,  Ccf_cliente, Ccf_cod_docum,  Ccf_serie_docum,  Ccf_nro_docum,  Ccf_diai,  Ccf_mesi,  Ccf_anioi,  Ccf_diaf, Ccf_mesf, Ccf_aniof);

            while (dr.Read())
            {

                modelowmtfacturascab item = new modelowmtfacturascab();
                item.observacion = Convert.ToString(dr["serie_docum"]) + " - " + Convert.ToString(dr["nro_docum"]);
                item.nro_trans = Convert.ToString(dr["nro_trans"]);
                item.cod_emp = Convert.ToString(dr["cod_emp"]);
                item.fec_doc = Convert.ToString(dr["fec_doc"]);
                item.aniomes = Convert.ToString(dr["aniomes"]);
                item.cod_docum = Convert.ToString(dr["cod_docum"]);
                item.serie_docum = Convert.ToString(dr["serie_docum"]);
                item.nro_docum = Convert.ToString(dr["nro_docum"]);
                item.cod_cliente = Convert.ToString(dr["cod_cliente"]);
                item.nom_tit = Convert.ToString(dr["nom_tit"]);
                item.cod_ccostos = Convert.ToString(dr["cod_ccostos"]);
                item.nom_dpto = Convert.ToString(dr["nom_dpto"]);
                item.dir_tit = Convert.ToString(dr["dir_tit"]);
                item.tel_tit = Convert.ToString(dr["tel_tit"]);
                item.nro_dgi = Convert.ToString(dr["nro_dgi"]);
                item.nro_dgi2 = Convert.ToString(dr["nro_dgi2"]);
                item.nro_dgi1 = Convert.ToString(dr["nro_dgi1"]);
                item.cod_fpago = Convert.ToString(dr["cod_fpago"]);
                item.nom_fpago = Convert.ToString(dr["nom_fpago"]);
                item.plazo_libre = Convert.ToString(dr["plazo_libre"]);
                item.observaciones = Convert.ToString(dr["observaciones"]);
                item.fec_venc = Convert.ToDateTime(dr["fec_venc"]);
                item.cod_vendedor = Convert.ToString(dr["cod_vendedor"]);
                item.nom_vendedor = Convert.ToString(dr["nom_vend"]);
                item.estado = Convert.ToString(dr["estado"]);
                item.subtotal = Convert.ToDecimal(dr["subtotal"]);
                item.iva = Convert.ToDecimal(dr["iva"]);
                item.impuesto2 = Convert.ToDecimal(dr["impuesto2"]);
                item.impuesto3 = Convert.ToDecimal(dr["impuesto3"]);
                item.impuesto4 = Convert.ToDecimal(dr["impuesto4"]);
                item.impuesto5 = Convert.ToDecimal(dr["impuesto5"]);
                item.total = Convert.ToDecimal(dr["total"]);
                item.monto_imponible = Convert.ToDecimal(dr["monto_imponible"]);
                item.porc_descto = Convert.ToDecimal(dr["porc_descto"]);
                item.descuento = Convert.ToDecimal(dr["descuento"]);
                item.suman = Convert.ToDecimal(dr["suman"]);
                item.signo = Convert.ToDecimal(dr["signo"]);
                item.Saldo = Convert.ToDecimal(dr["Saldo"]);
                item.nro_audit = Convert.ToString(dr["nro_audit"]);
                item.nom_ciudad = Convert.ToString(dr["nom_ciudad"]);
                item.vlr_letras = Convert.ToString(dr["vlr_letras"]);
                item.cod_atrib1 = Convert.ToString(dr["cod_atrib1"]);
                item.ini = Convert.ToString(dr["ini"]);
                item.fin = Convert.ToString(dr["fin"]);
                item.fres_ini = Convert.ToDateTime(dr["fres_ini"]);
                item.fres_fin = Convert.ToDateTime(dr["fres_fin"]);
                item.mes_char = Convert.ToString(dr["mes_char"]);
                item.pagina_edicion = Convert.ToString(dr["pagina_edicion"]);
                item.nom_edicion = Convert.ToString(dr["nom_edicion"]);
                item.pagina_elimina = Convert.ToString(dr["pagina_elimina"]);
                item.nom_corto = Convert.ToString(dr["nom_corto"]);
                item.ntipo = Convert.ToString(dr["ntipo"]);
                item.ocompra = Convert.ToString(dr["ocompra"]);
                item.cod_moneda = Convert.ToString(dr["cod_moneda"]);
                item.sim = Convert.ToString(dr["sim"]);
                item.nom_moneda = Convert.ToString(dr["nom_moneda"]);
                item.nro_doc_inve = Convert.ToString(dr["nro_doc_inve"]);
                item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                lista.Add(item);

            }
            return lista;
        }
    }
}
