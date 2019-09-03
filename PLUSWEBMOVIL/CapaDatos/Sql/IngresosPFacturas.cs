using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public class IngresosPFacturas
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;


        //FACTURAS POS, POSE ESTA F OC POR FECHA PARA CIERRE CAJA
        public List<modeloIngresoFacturas> ListaPgsFacEfectivo( string cod_emp, string fec_doc)
        {

            using (cn = conexion.genearConexion())
            {
                List<modeloIngresoFacturas> lista = new List<modeloIngresoFacturas>();
                string consulta = ("SELECT  wmt_facturas_pgs.nro_trans,wmt_facturas_pgs.linea,wmt_facturas_pgs.cod_emp,wmt_facturas_pgs.cod_fpago,wmm_fpagoPOS.nom_fpago,wmt_facturas_pgs.cod_tit,wmt_facturas_pgs.recibido,wmt_facturas_pgs.valor,wmt_facturas_pgs.diferencia,wmt_facturas_pgs.cod_cta,wmt_facturas_cab.fec_doc,wmt_facturas_cab.cod_docum,wmt_facturas_cab.serie_docum,wmt_facturas_pgs.nro_docum,wmt_facturas_cab.tipo FROM wmt_facturas_pgs ,wmt_facturas_cab ,wmm_fpagoPOS WHERE wmt_facturas_pgs.nro_trans = wmt_facturas_cab.nro_trans AND wmt_facturas_pgs.cod_emp = @cod_emp AND wmt_facturas_cab.fec_doc = @fec_doc AND wmt_facturas_cab.tipo IN ('pos', 'pose') AND wmt_facturas_cab.estado in('C', 'F') AND wmm_fpagoPOS.nom_fpago = 'EFECTIVO' ");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                conmand.Parameters.Add("@fec_doc", SqlDbType.VarChar).Value = fec_doc;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {

                    modeloIngresoFacturas item = new modeloIngresoFacturas();
                    item.nro_trans= Convert.ToString(dr["nro_trans"]);
                    DateTime fec_doc_str = Convert.ToDateTime(dr["fec_doc"]);
                   
                    item.fec_doc = fec_doc_str.ToString("yyyy-MM-dd"); 
                    item.cod_tit = Convert.ToString(dr["cod_tit"]);
                    item.cod_docum = Convert.ToString(dr["cod_docum"]);
                    item.serie_docum = Convert.ToString(dr["serie_docum"]);
                    item.nro_docum = Convert.ToString(dr["nro_docum"]);
                    item.documento = item.serie_docum +  "-" + item.nro_docum;
                    item.diferencia = Convert.ToDecimal(dr["diferencia"]);
                    item.recibido = Convert.ToDecimal(dr["recibido"]);
                    item.total = Convert.ToDecimal(dr["valor"]);
                    item.efectivo =  item.recibido + item.diferencia;

                    lista.Add(item);

                }

                return lista;
            }

        }

        //NOTAS DE VENTA ESTADO F O C POR FECHA PARA CIERRE CAJA
        public List<modeloIngresoFacturas> ListaNotasVenta(string cod_emp, string fec_doc)
        {

            using (cn = conexion.genearConexion())
            {
                List<modeloIngresoFacturas> lista = new List<modeloIngresoFacturas>();
                string consulta = ("SELECT  wmt_facturas_pgs.nro_trans,wmt_facturas_pgs.linea,wmt_facturas_pgs.cod_emp,wmt_facturas_pgs.cod_fpago,wmm_fpagoPOS.nom_fpago,wmt_facturas_pgs.cod_tit,wmt_facturas_pgs.recibido,wmt_facturas_pgs.valor,wmt_facturas_pgs.diferencia,wmt_facturas_pgs.cod_cta,wmt_facturas_cab.fec_doc,wmt_facturas_cab.cod_docum,wmt_facturas_cab.serie_docum,wmt_facturas_pgs.nro_docum,wmt_facturas_cab.tipo FROM wmt_facturas_pgs ,wmt_facturas_cab ,wmm_fpagoPOS WHERE wmt_facturas_pgs.nro_trans = wmt_facturas_cab.nro_trans AND wmt_facturas_pgs.cod_emp = @cod_emp AND wmt_facturas_cab.fec_doc = @fec_doc AND wmt_facturas_cab.tipo ='NVTA' AND wmm_fpagoPOS.nom_fpago = 'EFECTIVO' ");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                conmand.Parameters.Add("@fec_doc", SqlDbType.VarChar).Value = fec_doc;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {

                    modeloIngresoFacturas item = new modeloIngresoFacturas();
                    item.nro_trans = Convert.ToString(dr["nro_trans"]);
                    DateTime fec_doc_str = Convert.ToDateTime(dr["fec_doc"]);

                    item.fec_doc = fec_doc_str.ToString("yyyy-MM-dd");
                    item.cod_tit = Convert.ToString(dr["cod_tit"]);
                    item.serie_docum = Convert.ToString(dr["serie_docum"]);
                    item.nro_docum = Convert.ToString(dr["nro_docum"]);
                    item.documento = item.serie_docum + "-" + item.nro_docum;
                    item.recibido = Convert.ToDecimal(dr["recibido"]);
                    item.total = Convert.ToDecimal(dr["valor"]);
                    item.efectivo = item.recibido - Convert.ToDecimal(dr["diferencia"]);

                    lista.Add(item);

                }

                return lista;
            }

        }
    }
}
