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
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "FPagosPos.cs";
        //Medios de pagos
        public SqlDataReader consultaFormaPag()
        {
            try
            {
                cn = conexion.genearConexion();

                string consulta = "SELECT  * FROM wmm_fpagoPOS";
                SqlCommand conmand = new SqlCommand(consulta, cn);
                SqlDataReader dr = conmand.ExecuteReader();

                return dr;
            }

            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "consultaFormaPag", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
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

                guardarExcepcion.ClaseInsertarExcepcion(cabezeraFactura.cod_emp, metodo, "InsertarFacturaPagos", e.ToString(), DateTime.Today, "INS");
                return "No se pudo completar la acción." + "InsertarFacturaPagos." + " Por favor notificar al administrador.";
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

                guardarExcepcion.ClaseInsertarExcepcion(cabezeraFactura.cod_emp, metodo, "InsertarTiposPagos", e.ToString(), DateTime.Today, "INS");
                return "No se pudo completar la acción." + "InsertarTiposPagos." + " Por favor notificar al administrador.";
            }


        }

        /*Eliminar datos de la tabala wmtfacturas_pgs x linea para totales y saldos*/
        public string EliminarDetallePagosLinea(string nro_trans, string cod_fpago, string nro_docum)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {

                    string mensaje = "Eliminacion correctamente";
                    string delete = "delete from wmt_facturas_pgs where nro_trans =  @nro_trans and cod_fpago =@cod_fpago and nro_docum = nro_docum";
                    SqlCommand conmand = new SqlCommand(delete, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;

                   
                    conmand.Parameters.Add("@cod_fpago", SqlDbType.VarChar).Value = cod_fpago;
                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = nro_docum;
                    conmand.ExecuteNonQuery();


                    return mensaje;
                }


            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "EliminarDetallePagosLinea", e.ToString(), DateTime.Today, "DLT");
                return "No se pudo completar la acción." + "EliminarDetallePagosLinea." + " Por favor notificar al administrador.";
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

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "EliminarDetallePagosFactura", e.ToString(), DateTime.Today, "DLT");
                return "No se pudo completar la acción." + "EliminarDetallePagosFactura." + " Por favor notificar al administrador.";
            }

        }

        /*Eliminar datos de la tabala wmtfacturas_pgs*/
        public string EliminarTemporal(string nro_trans, string cod_emp, string cod_fpago)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {

                    string mensaje = "Eliminacion correctamente";
                    string delete = "delete from wmt_facturas_pgstmp where nro_trans =  @nro_trans and cod_fpago = @cod_fpago and cod_emp = @cod_emp ";
                    SqlCommand conmand = new SqlCommand(delete, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@cod_fpago", SqlDbType.VarChar).Value = cod_fpago;


                    conmand.ExecuteNonQuery();


                    return mensaje;
                }


            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "EliminarTemporal", e.ToString(), DateTime.Today, "DLT");
                return "No se pudo completar la acción." + "EliminarTemporal." + " Por favor notificar al administrador.";
            }

        }

        //Recuperar si es efectivo el vuelto en caso de q cancele mas
        public List<modeloFacturasPagos> BuscarVueltoPgs( string nro_trans)
        {

            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloFacturasPagos> lista = new List<modeloFacturasPagos>();

                    string consulta = ("select*from wmt_facturas_pgs where nro_trans = @nro_trans  ORDER BY linea DESC");
                    SqlCommand conmand = new SqlCommand(consulta, cn);


                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloFacturasPagos item = new modeloFacturasPagos();

                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.linea = Convert.ToInt16(dr["linea"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_fpago = Convert.ToString(dr["cod_fpago"]);

                        item.cod_tit = Convert.ToString(dr["cod_tit"]);
                        item.cod_docum = Convert.ToString(dr["cod_docum"]);
                        item.nro_docum = Convert.ToString(dr["nro_docum"]);
                        item.cod_cta = Convert.ToString(dr["cod_cta"]);
                        item.recibido = Convert.ToDecimal(dr["recibido"]);
                        item.valor = Convert.ToDecimal(dr["valor"]);
                        item.diferencia = Convert.ToDecimal(dr["diferencia"]);


                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "BuscarVueltoPgs", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

        
    }
}
