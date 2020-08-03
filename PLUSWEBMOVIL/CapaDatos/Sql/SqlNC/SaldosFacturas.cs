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
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "SaldosFacturas.cs";
        //saldos y totales de notas de crédito 
        //Saldos y totales de facturas en general sin restricciones
        public List<modeloSaldosFacturas> ConsultaFacturasSaldos(string Ccf_usuario, string Ccf_cod_emp, string Ccf_tipo1, string Ccf_tipo2, string solo_saldo)
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
                    conmand.Parameters.Add("@solo_saldo", SqlDbType.VarChar).Value = solo_saldo;
                   

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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, "SaldosFacturas.cs", "ConsultaFacturasSaldos", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }


        }

        //cONSULTA PARA FACTURAS ELECTRONICAS CON CUFE SE USA EN NC PARA SALDOS Y TOTALES
        public modeloFacturasElecSaldos ConsultaFacEleSaldos( string cod_cliente, string cod_emp, string serie, string nro_docum)
        {
            try
            {
                modeloFacturasElecSaldos items = new modeloFacturasElecSaldos();
                
                using (cn = conexion.genearConexion())
                {
                    

                    string consulta = ("SELECT	TOP 1 F.nro_trans,	F.cod_emp,	F.serie_docum,	F.nro_docum,	D.cufe FROM 	wmt_facturas_cab AS F INNER JOIN wmt_respuestaDS AS D ON F.nro_trans = D.nro_trans WHERE D.cufe <> '' AND F.tipo IN( 'VTAE', 'POSE') AND F.cod_cliente = @cod_cliente AND F.cod_emp = @cod_emp AND F.estado IN ('F') AND F.serie_docum = @serie AND F.nro_docum =@nro_docum GROUP BY 	F.nro_trans,	F.cod_emp,F.serie_docum,	F.nro_docum,	D.cufe");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = cod_cliente.Trim();
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = nro_docum.Trim();

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        items.nro_trans = Convert.ToString(dr["nro_trans"]);
                        items.cod_emp = Convert.ToString(dr["cod_emp"]);
                        items.cufe = Convert.ToString(dr["cufe"]);
                        items.serie_docum = Convert.ToString(dr["serie_docum"]);
                        items.nro_docum = Convert.ToString(dr["nro_docum"]);
                      
                    }

                    return items;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "SaldosFacturas.cs", "ConsultaFacEleSaldos", e.ToString(), DateTime.Now, "consulta");
                return null;
            }


        }
        //CONSULTA NC ELECTRONICAS  CON CUFE SE USA EN ND PARA SALDOS Y TOTALES
        public modeloFacturasElecSaldos ConsultaNCEleSaldos(string cod_cliente, string cod_emp, string serie, string nro_docum, string usuario)
        {
            try
            {
                modeloFacturasElecSaldos items = new modeloFacturasElecSaldos();

                using (cn = conexion.genearConexion())
                {

                    string consulta = ("SELECT	TOP 1 F.nro_trans,	F.cod_emp,	F.serie_docum,	F.nro_docum,	D.cufe FROM 	wmt_facturas_cab AS F INNER JOIN wmt_respuestaDS AS D ON F.nro_trans = D.nro_trans WHERE D.cufe <> '' AND F.tipo IN( 'NCVE', 'NCME') AND F.cod_cliente = @cod_cliente AND F.cod_emp = @cod_emp AND F.estado IN ('F') AND F.serie_docum = @serie AND F.nro_docum =@nro_docum GROUP BY 	F.nro_trans,	F.cod_emp,F.serie_docum,	F.nro_docum,	D.cufe");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = cod_cliente.Trim();
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = nro_docum.Trim();

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        items.nro_trans = Convert.ToString(dr["nro_trans"]);
                        items.cod_emp = Convert.ToString(dr["cod_emp"]);
                        items.cufe = Convert.ToString(dr["cufe"]);
                        items.serie_docum = Convert.ToString(dr["serie_docum"]);
                        items.nro_docum = Convert.ToString(dr["nro_docum"]);
                    }

                    return items;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaNCEleSaldos", e.ToString(), DateTime.Now, usuario);
                return null;
            }

        }
        //CONSULTA NC NORMALES 
        public modeloFacturasElecSaldos ConsultaNCNormalesSaldos(string cod_cliente, string cod_emp, string nro_trans, string usuario, string serie_docum)
        {
            try
            {
                modeloFacturasElecSaldos items = new modeloFacturasElecSaldos();

                using (cn = conexion.genearConexion())
                {


                    string consulta = ("SELECT * FROM wmt_facturas_cab WHERE estado IN ('C', 'F')  AND tipo IN ('NCV','NCM') AND nro_docum=@nro_trans and cod_emp = @cod_emp and cod_cliente= @cod_cliente and serie_docum = @serie_docum");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = cod_cliente;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.Parameters.Add("@serie_docum", SqlDbType.VarChar).Value = serie_docum;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        items.nro_trans = Convert.ToString(dr["nro_trans"]);
                        items.cod_emp = Convert.ToString(dr["cod_emp"]);
                        items.serie_docum = Convert.ToString(dr["serie_docum"]);
                        items.nro_docum = Convert.ToString(dr["nro_docum"]);

                    }

                    return items;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, " ConsultaNCNormalesSaldos", e.ToString(), DateTime.Now, usuario);
                return null;
            }


        }
        //cONSULTA PARA FACTURAS ELECTRONICAS CON CUFE SE USA EN NC PARA SALDOS Y TOTALES
        public modeloFacturasElecSaldos ConsultaFacturasVTASaldos(string cod_cliente, string cod_emp, string nro_trans)
        {
            try
            {
                modeloFacturasElecSaldos items = new modeloFacturasElecSaldos();

                using (cn = conexion.genearConexion())
                {


                    string consulta = ("SELECT * FROM wmt_facturas_cab WHERE estado IN ('C', 'F')  AND tipo IN ('VTA', 'POS') AND nro_docum=@nro_trans and cod_emp = @cod_emp and cod_cliente= @cod_cliente");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = cod_cliente;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        items.nro_trans = Convert.ToString(dr["nro_trans"]);
                        items.cod_emp = Convert.ToString(dr["cod_emp"]);
                        //items.cufe = Convert.ToString(dr["cufe"]);
                        items.serie_docum = Convert.ToString(dr["serie_docum"]);
                        items.nro_docum = Convert.ToString(dr["nro_docum"]);

                    }

                    return items;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "SaldosFacturas.cs", " ConsultaFacturasVTASaldos", e.ToString(), DateTime.Now, "consulta");
                return null;
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

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaDocumEletronicos", e.ToString(), DateTime.Now, "consulta");
                return null;
            }


        }
    }
}
