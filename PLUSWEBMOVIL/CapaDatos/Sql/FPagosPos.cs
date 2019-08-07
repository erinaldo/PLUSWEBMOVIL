using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public class FPagosPos
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        
        //Medios de pagos
            public SqlDataReader consultaFormaPag()
        {
            cn = conexion.genearConexion();

            string consulta = "SELECT  * FROM wmm_fpagoPOS";
            SqlCommand conmand = new SqlCommand(consulta, cn);
            SqlDataReader dr = conmand.ExecuteReader();
            
            return dr;
           
        }
        /*Insertar pagos en wmt_facturas_pgs*/

        public string InsertarFacturaPagos(modeloFacturasPagos cabezeraFactura)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO  wmt_facturas_pgs  (nro_trans,linea, cod_emp, cod_fpago,cod_tit,cod_docum, nro_docum,cod_cta, recibido) VALUES(@nro_trans,@linea, @cod_emp, @cod_fpago,@cod_tit,@cod_docum, @nro_docum, @cod_cta ,@recibido)";

                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = cabezeraFactura.nro_trans;
                    conmand.Parameters.Add("@linea", SqlDbType.Int).Value = cabezeraFactura.linea;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cabezeraFactura.cod_emp;
                    conmand.Parameters.Add("@cod_fpago", SqlDbType.VarChar).Value = cabezeraFactura.cod_fpago;
                    conmand.Parameters.Add("@cod_tit", SqlDbType.VarChar).Value = cabezeraFactura.cod_tit;
                    conmand.Parameters.Add("@cod_docum", SqlDbType.VarChar).Value = cabezeraFactura.cod_docum;
                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = cabezeraFactura.nro_docum;
                    conmand.Parameters.Add("@cod_cta", SqlDbType.VarChar).Value = cabezeraFactura.cod_cta;
                    conmand.Parameters.Add("@recibido", SqlDbType.Decimal).Value = cabezeraFactura.recibido;
              

                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "";
                }

            }
            catch (Exception e)
            {

                return e.ToString();
            }



        }

        /*Insertar en tabla temporal el wmt_facturas_pgstmp cada codigo de pago*/
        public string InsertarTiposPagos(modeloFacturasPagos cabezeraFactura)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO  wmt_facturas_pgstmp  (nro_trans, cod_fpago,cod_emp) VALUES(@nro_trans,@cod_fpago,@cod_emp)";

                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = cabezeraFactura.nro_trans;
                    conmand.Parameters.Add("@cod_fpago", SqlDbType.VarChar).Value = cabezeraFactura.cod_fpago;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cabezeraFactura.cod_emp;
                 
                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "";
                }

            }
            catch (Exception e)
            {

                return e.ToString();
            }



        }


        /*Eliminar datos de la tabala wmtfacturas_pgs*/
        public string EliminarDetallePagosFactura(string nro_trans)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {

                    string mensaje = "Eliminacion correctamente";
                    string delete = "delete from wmt_facturas_pgs where nro_trans =  @nro_trans ";
                    SqlCommand conmand = new SqlCommand(delete, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.ExecuteNonQuery();


                    return mensaje;
                }


            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }




    }
}
