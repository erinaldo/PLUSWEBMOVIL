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
        public List<modeloSaldosFacturas> ConsultaFacturasSaldos(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string Ccf_estado, string Ccf_cliente, string Ccf_cod_docum, string Ccf_serie_docum, string Ccf_nro_docum, string Ccf_diai, string Ccf_mesi, string Ccf_anioi, string Ccf_diaf, string Ccf_mesf, string Ccf_aniof)
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
                    conmand.Parameters.Add("@tipo1", SqlDbType.VarChar).Value = Ccf_tipo1;
                    conmand.Parameters.Add("@tipo2", SqlDbType.VarChar).Value = Ccf_tipo2;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = Ccf_nro_trans;
                    conmand.Parameters.Add("@estado", SqlDbType.VarChar).Value = Ccf_estado;
                    conmand.Parameters.Add("@cliente", SqlDbType.VarChar).Value = Ccf_cliente;
                    conmand.Parameters.Add("@cod_docum", SqlDbType.VarChar).Value = Ccf_cod_docum;
                    conmand.Parameters.Add("@serie_docum", SqlDbType.VarChar).Value = Ccf_serie_docum;
                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = Ccf_nro_docum;
                    conmand.Parameters.Add("@diai", SqlDbType.VarChar).Value = Ccf_diai;
                    conmand.Parameters.Add("@mesi", SqlDbType.VarChar).Value = Ccf_mesi;
                    conmand.Parameters.Add("@anioi", SqlDbType.VarChar).Value = Ccf_anioi;
                    conmand.Parameters.Add("@diaf", SqlDbType.VarChar).Value = Ccf_diaf;
                    conmand.Parameters.Add("@mesf", SqlDbType.VarChar).Value = Ccf_mesf;
                    conmand.Parameters.Add("@aniof", SqlDbType.VarChar).Value = Ccf_aniof;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloSaldosFacturas item = new modeloSaldosFacturas();
                        item.observacion = Convert.ToString(dr["nro_trans"]) + " - " + Convert.ToString(dr["documento"]);
                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.nro_trans = Convert.ToString(dr["nro_trans_ndm"]);
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

    }
}
