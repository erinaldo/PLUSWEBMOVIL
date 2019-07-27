using CapaDatos.Modelos.ModelosNC;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql.SqlNC
{
   public  class SaldosFacturas
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        //Saldos y totales de facturas en general sin restricciones
        public List<modeloSaldosFacturas> ConsultaFacturasSaldos(string Ccf_usuario, string Ccf_cod_emp, string Ccf_tipo1, string Ccf_tipo2)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloSaldosFacturas> lista = new List<modeloSaldosFacturas>();
                    string consulta = ("wmspc_facturasWM_saldo");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = Ccf_usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = Ccf_cod_emp;
                    conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = Ccf_tipo1;
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = Ccf_tipo2;
         
                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloSaldosFacturas item = new modeloSaldosFacturas();
                        item.observacion = Convert.ToString(dr["serie_docum"]) + " - " + Convert.ToString(dr["nro_docum"]);
                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.nro_trans_ndm = Convert.ToString(dr["nro_trans_ndm"]);
                        item.fec_doc = Convert.ToDateTime(dr["fec_doc"]);
                        DateTime fec_doc_str = Convert.ToDateTime(dr["fec_doc"]);
                        item.fec_doc_str = fec_doc_str.ToString("yyyy-MM-dd");
                        item.documento = Convert.ToString(dr["documento"]);
                        item.cod_docum = Convert.ToString(dr["cod_docum"]);
                        item.serie_docum = Convert.ToString(dr["serie_docum"]);
                        item.nro_docum = Convert.ToString(dr["nro_docum"]);
                        item.cod_cliente = Convert.ToString(dr["cod_cliente"]);
                        item.observaciones = Convert.ToString(dr["observaciones"]);
                        item.fec_venc = Convert.ToDateTime(dr["fec_venc"]);
                        item.total = Convert.ToDecimal(dr["total"]);
                        item.saldo = Convert.ToDecimal(dr["saldo"]);
                        item.sim = Convert.ToString(dr["sim"]);
                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {
                List<modeloSaldosFacturas> lista = new List<modeloSaldosFacturas>();
                return lista;
            }


        }

        //cONSULTA PARA FACTURAS ELECTRONICAS CON CUFE SE USA EN NC PARA SALDOS Y TOTALES
        public modeloFacturasElecSaldos ConsultaFacEleSaldos( string cod_cliente, string cod_emp, string nro_trans)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    modeloFacturasElecSaldos item = new modeloFacturasElecSaldos();
                    item = null;

                    string consulta = ("SELECT	TOP 1 F.nro_trans,	F.cod_emp,	F.serie_docum,	F.nro_docum,	D.cufe FROM 	wmt_facturas_cab AS F INNER JOIN wmt_respuestaDS AS D ON F.nro_trans = D.nro_trans WHERE D.cufe <> '' AND F.tipo = 'VTA' AND F.cod_cliente = @cod_cliente AND F.cod_emp = @cod_emp AND F.estado IN ('F') AND F.nro_trans = @nro_trans GROUP BY 	F.nro_trans,	F.cod_emp,F.serie_docum,	F.nro_docum,	D.cufe");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = cod_cliente;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cufe = Convert.ToString(dr["cufe"]);
                        item.serie_docum = Convert.ToString(dr["serie_docum"]);
                        item.nro_docum = Convert.ToString(dr["nro_docum"]);
                      
                    }

                    return item;
                }
            }
            catch (Exception e)
            {
                modeloFacturasElecSaldos item = new modeloFacturasElecSaldos();
                return item;
            }


        }

        //CONSULTA DOC ELECTRONICOS 
        public modeloFacturasElecSaldos ConsultaDocumEletronicos(string cod_emp, string nro_trans)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    modeloFacturasElecSaldos item = new modeloFacturasElecSaldos();
                    item = null;

                    string consulta = ("SELECT	TOP 1 F.nro_trans,	F.cod_emp,	F.serie_docum,	F.nro_docum,	D.cufe FROM 	wmt_facturas_cab AS F INNER JOIN wmt_respuestaDS AS D ON F.nro_trans = D.nro_trans WHERE D.cufe <> '' AND F.tipo IN ('VTA','NC') AND F.nro_trans= @nro_trans AND F.cod_emp = @cod_emp AND F.estado IN ('F')  GROUP BY 	F.nro_trans,	F.cod_emp,F.serie_docum,	F.nro_docum,	D.cufe");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

              
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cufe = Convert.ToString(dr["cufe"]);
                        item.serie_docum = Convert.ToString(dr["serie_docum"]);
                        item.nro_docum = Convert.ToString(dr["nro_docum"]);

                    }

                    return item;
                }
            }
            catch (Exception e)
            {
                modeloFacturasElecSaldos item = new modeloFacturasElecSaldos();
                return item;
            }


        }
    }
}
