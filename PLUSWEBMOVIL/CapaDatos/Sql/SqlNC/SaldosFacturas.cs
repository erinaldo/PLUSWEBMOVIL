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

    }
}
