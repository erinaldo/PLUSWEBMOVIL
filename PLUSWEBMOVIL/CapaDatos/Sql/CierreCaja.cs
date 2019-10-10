using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public class CierreCaja
    {
        
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "CierreCaja.cs";
        string stringConexionERP = "";// Aqui va la consulta de la table de alfredo desia que va ir el string

        //Consulta wmm_parametros conexion_erp
        public string ConsultaConexionERP( string usuario, string cod_emp)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {
                    string consulta = ("SELECT conexion_erp FROM wmm_parametros where cod_emp =@cod_emp");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        stringConexionERP = Convert.ToString(dr["conexion_erp"]);
                    }
                    return stringConexionERP;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaConexionERP", e.ToString(), DateTime.Today, usuario);
                return "No se pudo completar la acción." + "ConsultaConexionERP." + " Por favor notificar al administrador.";
            }
        }

        //Consulta al ERP BpBan, datos de una caja especifica

        public List<modeloCajasCierre> ConsultaDatosCaja(string usuario, string cod_emp, string banco, string tipo, string nro_caja)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloCajasCierre> lista = new List<modeloCajasCierre>();

                    string consulta = ("wmspc_ctasbco");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@banco", SqlDbType.VarChar).Value = banco;
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                    SqlDataReader dr = conmand.ExecuteReader();


                    while (dr.Read())
                    {

                        modeloCajasCierre item = new modeloCajasCierre();

                        item.cod_tit = Convert.ToString(dr["cod_tit"]);
                        item.nom_tit = Convert.ToString(dr["nom_tit"]);
                        item.tipocta_banco = Convert.ToString(dr["tipocta_banco"]);
                        item.nomtcta_banco = Convert.ToString(dr["nomtcta_banco"]);
                        item.nrocta_banco = Convert.ToString(dr["nrocta_banco"]);
                        item.cod_cta = Convert.ToString(dr["cod_cta"]);
                        item.cod_moneda = Convert.ToString(dr["cod_moneda"]);

                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaDatosCaja", e.ToString(), DateTime.Today, usuario);
                return null;
            }

        }

        //Consulta al ERP BpBan

        public string ConsultaTipoCuenta(string cod_emp, string usuario)
        {
            try
            {
                stringConexionERP = ConsultaConexionERP(cod_emp, usuario);
                string tipo_cuenta = "";
                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    string consulta = ("SELECT TOP 1 BpBanCaja from BpBan");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        tipo_cuenta = Convert.ToString(dr["BpBanCaja"]);
                    }
                    return tipo_cuenta;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaTipoCuenta", e.ToString(), DateTime.Today, usuario);
                return "No se pudo completar la acción." + "ConsultaTipoCuenta." + " Por favor notificar al administrador.";
            }
        }


        //Cargar Cajas para buscar el cierre de cajas
        public List<modeloCajasCierre> ConsultaCajasCierre(string usuario, string cod_emp, string banco, string tipo)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloCajasCierre> lista = new List<modeloCajasCierre>();

                    string consulta = ("wmspc_ctasbco");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@banco", SqlDbType.VarChar).Value = banco;
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                    SqlDataReader dr = conmand.ExecuteReader();
                   

                    while (dr.Read())
                    {

                        modeloCajasCierre item = new modeloCajasCierre();

                        item.cod_tit = Convert.ToString(dr["cod_tit"]);
                        item.nom_tit = Convert.ToString(dr["nom_tit"]);
                        item.tipocta_banco = Convert.ToString(dr["tipocta_banco"]);
                        item.nomtcta_banco = Convert.ToString(dr["nomtcta_banco"]);
                        item.nrocta_banco = Convert.ToString(dr["nrocta_banco"]);
                        item.cod_cta = Convert.ToString(dr["cod_cta"]);
                        item.cod_moneda = Convert.ToString(dr["cod_moneda"]);
                        item.observacion = item.nomtcta_banco + '-'+ ' '+ item.nrocta_banco;

                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaCajasCierre", e.ToString(), DateTime.Today, usuario);
                return null;
            }

        }
        //Modelo cierre de caja tabla wmt_cierre_resumencaja PP PAGO PROVEEDORES
        public List<modeloPagoProveedores> ListaPagoProveedores(string usuario, string cod_emp, string dia, string mes, string anio, string tipo1, string tipo2)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloPagoProveedores> lista = new List<modeloPagoProveedores>();
                    string consulta = ("wmspc_cierrecaja");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@dia", SqlDbType.VarChar).Value = dia;
                    conmand.Parameters.Add("@mes", SqlDbType.VarChar).Value = mes;
                    conmand.Parameters.Add("@anio", SqlDbType.VarChar).Value = anio;
                    conmand.Parameters.Add("@tipo1", SqlDbType.VarChar).Value = tipo1;
                    conmand.Parameters.Add("@tipo2", SqlDbType.VarChar).Value = tipo2;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloPagoProveedores item = new modeloPagoProveedores();
                          item.cod_docum = Convert.ToString(dr["cod_docum"]);
                           item.serie_docum = Convert.ToString(dr["serie_docum"]);
                           item.nro_docum = Convert.ToString(dr["nro_docum"]);
                           item.cod_tit = Convert.ToString(dr["cod_tit"]);
                           item.nom_tit = Convert.ToString(dr["nom_tit"]);
                           item.observaciones = Convert.ToString(dr["observaciones"]);
                        item.documento = item.serie_docum +'-'+ item.nro_docum;

                        decimal formPrecio = Convert.ToDecimal(dr["total"]);
                        item.total_st = String.Format("{0:N2}", formPrecio).ToString();
                        item.total = Convert.ToString(dr["total"]);
                           item.fec_doc = Convert.ToString(dr["fec_doc"]);
                        DateTime fec_venc_str = Convert.ToDateTime(dr["fec_doc"]);
                        item.fec_st= fec_venc_str.ToString("yyyy-MM-dd");
                        item.estado= Convert.ToString(dr["estado"]);
                       // item.valor = Convert.ToDecimal(dr["valor"]);

                        lista.Add(item);

                    }

                    return lista;
                }
            }


            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaPagoProveedores", e.ToString(), DateTime.Today, "consulta");
                return null;
            }

        }

        //Modelo cierre de caja tabla wmt_cierre_resumencaja FV, NV
        public List<modeloPagoProveedores> ListaFcturasNV(string usuario, string cod_emp, string dia, string mes, string anio, string tipo1, string tipo2)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloPagoProveedores> lista = new List<modeloPagoProveedores>();
                    string consulta = ("wmspc_cierrecaja");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@dia", SqlDbType.VarChar).Value = dia;
                    conmand.Parameters.Add("@mes", SqlDbType.VarChar).Value = mes;
                    conmand.Parameters.Add("@anio", SqlDbType.VarChar).Value = anio;
                    conmand.Parameters.Add("@tipo1", SqlDbType.VarChar).Value = tipo1;
                    conmand.Parameters.Add("@tipo2", SqlDbType.VarChar).Value = tipo2;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloPagoProveedores item = new modeloPagoProveedores();
                        item.cod_docum = Convert.ToString(dr["cod_docum"]);
                        item.serie_docum = Convert.ToString(dr["serie_docum"]);
                        item.nro_docum = Convert.ToString(dr["nro_docum"]);
                        item.cod_tit = Convert.ToString(dr["cod_cliente"]);
                        item.nom_tit = Convert.ToString(dr["nom_tit"]);
                        item.observaciones = Convert.ToString(dr["observaciones"]);
                        item.documento = item.serie_docum + '-' + item.nro_docum;

                        decimal formPrecio = Convert.ToDecimal(dr["total"]);
                        item.total_st = String.Format("{0:N2}", formPrecio).ToString();
                        item.total = Convert.ToString(dr["total"]);
                        item.fec_doc = Convert.ToString(dr["fec_doc"]);
                        DateTime fec_venc_str = Convert.ToDateTime(dr["fec_doc"]);
                        item.fec_st = fec_venc_str.ToString("yyyy-MM-dd");
                        item.estado = Convert.ToString(dr["estado"]);
                        item.nro_trans= Convert.ToString(dr["nro_trans"]);

                        lista.Add(item);

                    }

                    return lista;
                }
            }


            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaFcturasNV", e.ToString(), DateTime.Today, "consulta");
                return null;
            }

        }

        //Resumen ListaPagoProveedores devuel solo valor
        public List<modeloPagoProveedores> TotalPagoProveedores(string usuario, string cod_emp, string dia, string mes, string anio, string tipo1, string tipo2)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloPagoProveedores> lista = new List<modeloPagoProveedores>();
                    string consulta = ("wmspc_cierrecaja");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@dia", SqlDbType.VarChar).Value = dia;
                    conmand.Parameters.Add("@mes", SqlDbType.VarChar).Value = mes;
                    conmand.Parameters.Add("@anio", SqlDbType.VarChar).Value = anio;
                    conmand.Parameters.Add("@tipo1", SqlDbType.VarChar).Value = tipo1;
                    conmand.Parameters.Add("@tipo2", SqlDbType.VarChar).Value = tipo2;
                    

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloPagoProveedores item = new modeloPagoProveedores();
                        /*  item.cod_docum = Convert.ToString(dr["cod_docum"]);
                           item.serie_docum = Convert.ToString(dr["serie_docum"]);
                           item.nro_docum = Convert.ToString(dr["nro_docum"]);
                           item.cod_tit = Convert.ToString(dr["od_tit"]);
                           item.nom_tit = Convert.ToString(dr["nom_tit"]);
                           item.observaciones = Convert.ToString(dr["observaciones"]);
                         
                           item.total = Convert.ToString(dr["total"]);
                           item.fec_doc = Convert.ToString(dr["fec_doc"]);
                           item.estado= Convert.ToString(dr["estado"]);*/
                        item.valor = Convert.ToDecimal(dr["valor"]);

                        lista.Add(item);

                    }

                    return lista;
                }
            }


            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, " TotalPagoProveedores", e.ToString(), DateTime.Today, "consulta");
                return null;
            }

        }



        //Buscar por fecha
        public Int64 BuscarCierreDiaSecuencial(string fecha_cie, string cod_emp)
        {
            try
            {
                Int64 secuencial = 0;

                using (cn = conexion.genearConexion())
                {
                    string insert = "SELECT TOP 1  secuencial FROM wmt_cierre_resumencaja where fecha_cie = @fecha_cie AND cod_emp =@cod_emp ORDER BY wmt_cierre_resumencaja.secuencial DESC ";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@fecha_cie", SqlDbType.VarChar).Value = fecha_cie;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        secuencial = Convert.ToInt64(dr["secuencial"]);


                    }

                    return secuencial + 1;
                }
            }

            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion( cod_emp, metodo, "BuscarCierreDiaSecuencial", e.ToString(), DateTime.Today, "consulta");
                return 0;
            }
        }

        //ultimo secuencial
        public Int64 UltimoCierreDiaSecuencial(string fecha_cie,string cod_emp)
        {
            try
            {

                Int64 secuencial = 0;

                using (cn = conexion.genearConexion())
                {
                    string insert = "SELECT TOP 1  secuencial FROM wmt_cierre_resumencaja where fecha_cie = @fecha_cie and cod_emp=@cod_emp ORDER BY dbo.wmt_cierre_resumencaja.secuencial DESC ";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@fecha_cie", SqlDbType.VarChar).Value = fecha_cie;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        secuencial = Convert.ToInt64(dr["secuencial"]);


                    }

                    return secuencial;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "UltimoCierreDiaSecuencial", e.ToString(), DateTime.Today, "consulta");
                return 0;
            }
        }
        //Resumen de ciere por fecha
        public List<modeloCierreCaja> ListaCierreCF(string nro_trans, Int64 secuencial, string codigo, string cod_emp, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloCierreCaja> lista = new List<modeloCierreCaja>();
                    string consulta = ("select * from wmt_cierre_resumencaja WHERE nro_trans=@nro_trans  and secuencial =@secuencial and codigo= @codigo and cod_emp=@cod_emp");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.Parameters.Add("secuencial", SqlDbType.BigInt).Value = secuencial;
                    conmand.Parameters.Add("codigo", SqlDbType.VarChar).Value = codigo;
                    conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloCierreCaja item = new modeloCierreCaja();
                        item.id = Convert.ToString(dr["id"]);
                        item.secuencial = Convert.ToInt64(dr["secuencial"]);
                        item.signo = Convert.ToString(dr["signo"]);
                        item.codigo = Convert.ToString(dr["codigo"]);
                        item.nombre = Convert.ToString(dr["nombre"]);
                        item.valor = Convert.ToDecimal(dr["valor"]);
                        item.valor1 = String.Format("{0:N2}", item.valor).ToString();
                        item.fecha_cie = Convert.ToString(dr["fecha_cie"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);

                        lista.Add(item);

                    }

                    return lista;
                }
            }


            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp,metodo, "ListaCierreCF", e.ToString(), DateTime.Today,usuario);
                return null;
            }

        }

        //Insertar cierre en tabla wmt_cierre_resumencaja
        public string InsertarCierreCaja(modeloCierreCaja Cierrecaja)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO  wmt_cierre_resumencaja (signo, codigo,nombre, valor, usuario_mod, fecha_mod,fecha_cie, secuencial, cod_emp, nro_trans, nro_caja, cod_proc_aud) VALUES (@signo, @codigo,@nombre, @valor, @usuario_mod, @fecha_mod,@fecha_cie, @secuencial, @cod_emp,@nro_trans, @nro_caja, @cod_proc_aud)";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@signo", SqlDbType.VarChar).Value = Cierrecaja.signo;
                    conmand.Parameters.Add("@codigo", SqlDbType.VarChar).Value = Cierrecaja.codigo;
                    conmand.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Cierrecaja.nombre;
                    conmand.Parameters.Add("@valor", SqlDbType.Decimal).Value = Cierrecaja.valor;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = Cierrecaja.usuario_mod;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = Cierrecaja.fecha_mod;
                    conmand.Parameters.Add("@fecha_cie", SqlDbType.VarChar).Value = Cierrecaja.fecha_cie;
                    conmand.Parameters.Add("@secuencial", SqlDbType.VarChar).Value = Cierrecaja.secuencial;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = Cierrecaja.cod_emp;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = Cierrecaja.nro_trans;
                    conmand.Parameters.Add("@nro_caja", SqlDbType.VarChar).Value = Cierrecaja.nro_caja;
                    conmand.Parameters.Add("@cod_proc_aud", SqlDbType.VarChar).Value = Cierrecaja.cod_proc_aud;
                    int dr = conmand.ExecuteNonQuery();
                    return "Cierre Caja guardada correctamente";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Cierrecaja.cod_emp, metodo, "InsertarCierreCaja", e.ToString(), DateTime.Today, Cierrecaja.usuario_mod);
                return "No se pudo completar la acción." + "InsertarCierreCaja." + " Por favor notificar al administrador.";
            }

        }
        //Actualizar cierre en tabla wmt_cierre_resumencaja
        public string ActualizarCierreCaja(modeloCierreCaja Cierrecaja)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "UPDATE  wmt_cierre_resumencaja SET signo =@signo, codigo =@codigo,nombre= @nombre, valor= @valor, usuario_mod = @usuario_mod, fecha_mod =@fecha_mod WHERE id= @id";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@signo", SqlDbType.VarChar).Value = Cierrecaja.signo;
                    conmand.Parameters.Add("@codigo", SqlDbType.VarChar).Value = Cierrecaja.codigo;
                    conmand.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Cierrecaja.nombre;
                    conmand.Parameters.Add("@valor", SqlDbType.Decimal).Value = Cierrecaja.valor;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = Cierrecaja.usuario_mod;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = Cierrecaja.fecha_mod;
                    conmand.Parameters.Add("@id", SqlDbType.VarChar).Value = Cierrecaja.id;

                    int dr = conmand.ExecuteNonQuery();
                    return "Cierre Caja guardada correctamente";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Cierrecaja.cod_emp, metodo, "ActualizarCierreCaja", e.ToString(), DateTime.Today, Cierrecaja.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarCierreCaja." + " Por favor notificar al administrador.";
            }

        }

        //Eliminar cierre en tabla wmt_cierre_resumencaja
        public string EliminarCierreCaja(modeloCierreCaja Cierrecaja)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "DELETE  wmt_cierre_resumencaja  WHERE id= @id";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@id", SqlDbType.VarChar).Value = Cierrecaja.id;

                    int dr = conmand.ExecuteNonQuery();
                    return "Cierre Caja eliminado correctamente";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Cierrecaja.cod_emp, metodo, "EliminarCierreCaja", e.ToString(), DateTime.Today, Cierrecaja.usuario_mod);
                return "No se pudo completar la acción." + "EliminarCierreCaja." + " Por favor notificar al administrador.";
            }

        }
    }
}
