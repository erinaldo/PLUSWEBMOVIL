using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CapaProceso.Modelos;
using CapaDatos.Modelos;

namespace CapaDatos.Sql
{
   public  class ModificarPrecioFactura
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        modeloRolModificarPrecio modeloRol = new modeloRolModificarPrecio();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "ModificarPrecioFactura";
        //Buscar datos de concepto especifico por codigo por empresa
        public ModeloFacturaDescuento ConceptoUnicoEmp(string usuario, string cod_emp, string codigo)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    ModeloFacturaDescuento item = new ModeloFacturaDescuento();
                    string consulta = ("SELECT D.cod_concepto,D.cod_emp,D.nom_concepto,D.porc_descto,D.cod_cta,D.cod_ccostos,D.usuario_mod,D.fecha_mod,D.nro_audit,D.cod_proc_aud,F.cod_concepto_fis,F.signo,F.nom_concepto_fis FROM dbo.wmm_facturas_descto AS D ,dbo.wmm_conceptos_fiscal AS F WHERE D.cod_concepto = @codigo AND D.cod_emp=@cod_emp AND D.cod_concepto_fis = F.cod_concepto_fis");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_concepto = Convert.ToString(dr["cod_concepto"]);
                        item.nom_concepto = Convert.ToString(dr["nom_concepto"]);
                        item.cod_concepto_fis = Convert.ToString(dr["cod_concepto_fis"]);
                        item.porc_descto = Convert.ToDecimal(dr["porc_descto"]);
                        item.cod_cta = Convert.ToString(dr["cod_cta"]);
                        item.cod_ccostos = Convert.ToString(dr["cod_ccostos"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        item.descuento = String.Format("{0:N}", Math.Round(item.porc_descto, 2)).ToString();
                        item.signo = Convert.ToString(dr["signo"]);
                        if (item.signo == "D")
                        {
                            item.detalle = "DESCUENTO";
                        }
                        else
                        {
                            item.detalle = "CARGO";
                        }

                    }
                    return item;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConceptoUnicoEmp", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        //Buscar recargos/descuentos de factura por empresa
        public List<ModeloFacturaDescuento> ListaDesRecFacturaxEmp(string usuario, string cod_emp, string codigo)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<ModeloFacturaDescuento> lista = new List<ModeloFacturaDescuento>();
                    string consulta = ("SELECT D.cod_concepto,D.cod_emp,D.nom_concepto,D.porc_descto,D.cod_cta,D.cod_ccostos,D.usuario_mod,D.fecha_mod,D.nro_audit,D.cod_proc_aud,F.cod_concepto_fis,F.signo,F.nom_concepto_fis FROM dbo.wmm_facturas_descto AS D ,dbo.wmm_conceptos_fiscal AS F WHERE D.cod_concepto = @codigo AND D.cod_emp=@cod_emp AND D.cod_concepto_fis = F.cod_concepto_fis");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        ModeloFacturaDescuento item = new ModeloFacturaDescuento();
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_concepto = Convert.ToString(dr["cod_concepto"]);
                        item.nom_concepto = Convert.ToString(dr["nom_concepto"]);
                        item.cod_concepto_fis = Convert.ToString(dr["cod_concepto_fis"]);
                        item.porc_descto = Convert.ToDecimal(dr["porc_descto"]);
                        item.cod_cta = Convert.ToString(dr["cod_cta"]);
                        item.cod_ccostos = Convert.ToString(dr["cod_ccostos"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        item.descuento = String.Format("{0:N}", Math.Round(item.porc_descto, 2)).ToString();
                        item.signo = Convert.ToString(dr["signo"]);
                        if(item.signo =="D")
                        {
                            item.detalle = "DESCUENTO";
                        }else
                        {
                            item.detalle = "CARGO";
                        }

                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, " ListaDesRecFacturaxEmp", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        //Buscar recargos/descuentos de factura por empresa
        public List<ModeloFacturaDescuento> ListaDesRecFactura(string usuario, string cod_emp)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<ModeloFacturaDescuento> lista = new List<ModeloFacturaDescuento>();
                    string consulta = ("SELECT D.cod_emp,D.cod_concepto,D.nom_concepto,D.cod_concepto_fis,D.porc_descto,D.cod_cta,D.cod_ccostos,D.usuario_mod,D.fecha_mod,D.nro_audit,D.cod_proc_aud,C.signo FROM dbo.wmm_facturas_descto AS D ,dbo.wmm_conceptos_fiscal AS C WHERE D.cod_concepto_fis = C.cod_concepto_fis and cod_emp =@cod_emp");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        ModeloFacturaDescuento item = new ModeloFacturaDescuento();
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_concepto = Convert.ToString(dr["cod_concepto"]);
                        item.nom_concepto = Convert.ToString(dr["nom_concepto"]);
                        item.cod_concepto_fis = Convert.ToString(dr["cod_concepto_fis"]);
                        item.porc_descto = Convert.ToDecimal(dr["porc_descto"]);
                        item.cod_cta = Convert.ToString(dr["cod_cta"]);
                        item.cod_ccostos = Convert.ToString(dr["cod_ccostos"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        item.descuento = String.Format("{0:N}", Math.Round(item.porc_descto, 2)).ToString();
                        item.nomcod = item.cod_concepto + "-" + item.nom_concepto;
                        item.signo = Convert.ToString(dr["signo"]);
                        if (item.signo == "D")
                        {
                            item.detalle = "DESCUENTO";
                        }
                        else
                        {
                            item.detalle = "CARGO";
                        }

                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, " ListaDesRecFactura", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }

        //Insertar  recargos/descuentos de factura por empresa
        public string InsertarDescRecFactura(ModeloFacturaDescuento cabezeraFactura)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string update = "INSERT INTO wmm_facturas_descto (cod_emp,cod_concepto,nom_concepto,cod_concepto_fis,porc_descto,cod_cta,cod_ccostos,usuario_mod,fecha_mod,nro_audit,cod_proc_aud) values(@cod_emp,@cod_concepto,@nom_concepto,@cod_concepto_fis,@porc_descto,@cod_cta,@cod_ccostos,@usuario_mod,@fecha_mod,@nro_audit,@cod_proc_aud)";
                    SqlCommand conmand = new SqlCommand(update, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cabezeraFactura.cod_emp;
                    conmand.Parameters.Add("@cod_concepto", SqlDbType.VarChar).Value = cabezeraFactura.cod_concepto;
                    conmand.Parameters.Add("@nom_concepto", SqlDbType.VarChar).Value = cabezeraFactura.nom_concepto;
                    conmand.Parameters.Add("@cod_concepto_fis", SqlDbType.VarChar).Value = cabezeraFactura.cod_concepto_fis;
                    conmand.Parameters.Add("@porc_descto", SqlDbType.VarChar).Value = cabezeraFactura.porc_descto;
                    conmand.Parameters.Add("@cod_cta", SqlDbType.VarChar).Value = cabezeraFactura.cod_cta;
                    conmand.Parameters.Add("@cod_ccostos", SqlDbType.VarChar).Value = cabezeraFactura.cod_ccostos;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = cabezeraFactura.usuario_mod;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.VarChar).Value = DateTime.Now.ToString();
                    conmand.Parameters.Add("@nro_audit", SqlDbType.VarChar).Value = cabezeraFactura.nro_audit;
                    conmand.Parameters.Add("@cod_proc_aud", SqlDbType.VarChar).Value = cabezeraFactura.cod_proc_aud;
       

                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cabezeraFactura.cod_emp, metodo, "InsertarDescRecFactura", e.ToString(), DateTime.Now, cabezeraFactura.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarCabeceraFactura." + " Por favor notificar al administrador.";
            }

        }
        //Actualizar  recargos/descuentos de factura por empresa
        public string ActualizarDescRecFactura(ModeloFacturaDescuento cabezeraFactura)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string update = "UPDATE wmm_facturas_descto SET nom_concepto = @nom_concepto,cod_concepto_fis =@cod_concepto_fis,porc_descto =@porc_descto,cod_cta =@cod_cta,cod_ccostos =@cod_ccostos,usuario_mod =@usuario_mod,fecha_mod =@fecha_mod WHERE cod_emp =@cod_emp AND cod_concepto =@cod_concepto";
                    SqlCommand conmand = new SqlCommand(update, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cabezeraFactura.cod_emp;
                    conmand.Parameters.Add("@cod_concepto", SqlDbType.VarChar).Value = cabezeraFactura.cod_concepto;
                    conmand.Parameters.Add("@nom_concepto", SqlDbType.VarChar).Value = cabezeraFactura.nom_concepto;
                    conmand.Parameters.Add("@cod_concepto_fis", SqlDbType.VarChar).Value = cabezeraFactura.cod_concepto_fis;
                    conmand.Parameters.Add("@porc_descto", SqlDbType.VarChar).Value = cabezeraFactura.porc_descto;
                    conmand.Parameters.Add("@cod_cta", SqlDbType.VarChar).Value = cabezeraFactura.cod_cta;
                    conmand.Parameters.Add("@cod_ccostos", SqlDbType.VarChar).Value = cabezeraFactura.cod_ccostos;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = cabezeraFactura.usuario_mod;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.VarChar).Value = DateTime.Now.ToString();
                    ;

                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cabezeraFactura.cod_emp, metodo, "ActualizarDescRecFactura", e.ToString(), DateTime.Now, cabezeraFactura.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarCabeceraFactura." + " Por favor notificar al administrador.";
            }

        }
        //Actualizar  recargos/descuentos de factura por empresa
        public string EliminarDescRecFactura(ModeloFacturaDescuento cabezeraFactura)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string update = "DELETE FROM wmm_facturas_descto WHERE cod_emp =@cod_emp AND cod_concepto =@cod_concepto";
                    SqlCommand conmand = new SqlCommand(update, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cabezeraFactura.cod_emp;
                    conmand.Parameters.Add("@cod_concepto", SqlDbType.VarChar).Value = cabezeraFactura.cod_concepto;

                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cabezeraFactura.cod_emp, metodo, "EliminarDescRecFactura", e.ToString(), DateTime.Now, cabezeraFactura.usuario_mod);
                return "No se pudo completar la acción." + "EliminarDescRecFactura." + " Por favor notificar al administrador.";
            }

        }
        //Buscar permiso para modificar precio por usuario
        public List<modeloRolModificarPrecio> RespuestaRolModPrecio(string usuario, string cod_emp, string tipo, string campo, string accion)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloRolModificarPrecio> lista = new List<modeloRolModificarPrecio>();
                    string consulta = ("wmspc_rolfact");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                    conmand.Parameters.Add("@campo", SqlDbType.VarChar).Value = campo;
                    conmand.Parameters.Add("@accion", SqlDbType.VarChar).Value = accion;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloRolModificarPrecio item = new modeloRolModificarPrecio();
                        item.usuario = Convert.ToString(dr["usuario"]);

                        item.control_uso = Convert.ToString(dr["control_uso"]);

                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "RespuestaRolModPrecio", e.ToString(), DateTime.Now,usuario);
                return null;
            }
        }
    }
}
