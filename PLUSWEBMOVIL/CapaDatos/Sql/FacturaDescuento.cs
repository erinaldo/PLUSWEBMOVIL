using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public  class FacturaDescuento
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "FacturaDescuento.cs";
        //Buscar descuento y recargo por linea
        public ModeloDescCargoFac BuscarDescCargTransLinea(string Ccf_cod_emp, string Ccf_usuario, string nro_trans, string linea)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    ModeloDescCargoFac item = new ModeloDescCargoFac();

                    string consulta = ("SELECT*FROM wmt_facturas_descto where cod_emp =@cod_emp and nro_trans=@nro_trans and linea=@linea ORDER BY linea ASC");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = Ccf_cod_emp;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.Parameters.Add("linea", SqlDbType.VarChar).Value = linea;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                      //  ModeloDescCargoFac item = new ModeloDescCargoFac();
                        item.linea = Convert.ToString(dr["linea"]);
                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_concepto = Convert.ToString(dr["cod_concepto"]);
                        item.nom_concepto = Convert.ToString(dr["nom_concepto"]);
                        item.signo = Convert.ToString(dr["signo"]);
                        item.nomcod = item.cod_concepto + "-" + item.nom_concepto;
                        item.cod_ccostos = Convert.ToString(dr["cod_ccostos"]);
                        item.cod_cta = Convert.ToString(dr["cod_cta"]);
                        item.valor_descto = Convert.ToDecimal(dr["valor_descto"]);
                        item.valor_descuento = String.Format("{0:N2}", item.valor_descto);
                        item.porc_descto = Convert.ToDecimal(dr["porc_descto"]);
                        item.porcen_desc = String.Format("{0:N2}", item.porc_descto);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        if (item.signo == "D")
                        {
                            item.detalle = "DESCUENTO";
                        }
                        else
                        {
                            item.detalle = "CARGO";
                        }
                        item.total = Convert.ToDecimal(dr["total"]);
                        item.total_for = String.Format("{0:N2}", item.total);
                        // lista.Add(item);

                    }

                    return item;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarDescCargTransLinea", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }
        //Actualizar campo dessc_rcgos en factura cabcera
        //Numero de lineas por nro_trans
        public string ActualizarDescCargFac(string Ccf_cod_emp, string Ccf_usuario, string nro_trans, string desctos_rcgos)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string nro_linea = null;

                    string consulta = ("Update wmt_facturas_cab set desctos_rcgos=@desctos_rcgos where cod_emp =@cod_emp and nro_trans=@nro_trans");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = Ccf_cod_emp;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.Parameters.Add("@desctos_rcgos", SqlDbType.VarChar).Value = desctos_rcgos;


                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "Actualizacion guardado correctamente";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ActualizarDescCargFac", e.ToString(), DateTime.Now, Ccf_usuario);
                return "No se pudo completar la acción." + "ActualizarDescCargFac." + " Por favor notificar al administrador.";
            }


        }
        //Numero de lineas por nro_trans
        public string ConsultaDescCargNro(string Ccf_cod_emp, string Ccf_usuario, string nro_trans)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string nro_linea = null;

                    string consulta = ("SELECT TOP 1 * from wmt_facturas_descto where cod_emp =@cod_emp and nro_trans=@nro_trans ORDER BY linea DESC");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = Ccf_cod_emp;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;


                    SqlDataReader dr = conmand.ExecuteReader();


                    while (dr.Read())
                    {

                       nro_linea = Convert.ToString(dr["linea"]);
                    }

                    return nro_linea;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaDescCargNro", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }


        }
        //Lista de descuentos y cargo por nro_trans
        public List<ModeloDescCargoFac> ConsultaDescCargTrans(string Ccf_cod_emp, string Ccf_usuario, string nro_trans)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<ModeloDescCargoFac> lista = new List<ModeloDescCargoFac>();

                    string consulta = ("SELECT D.nro_trans,D.cod_emp,D.linea,D.cod_concepto,D.signo,D.nom_concepto,D.porc_descto,D.valor_descto,D.cod_cta,D.cod_ccostos,D.usuario_mod,D.fecha_mod,D.total,D.base_imponible,C.cod_concepto_fis FROM dbo.wmt_facturas_descto AS D ,dbo.wmm_facturas_descto AS C WHERE D.cod_concepto = C.cod_concepto AND D.cod_emp = C.cod_emp AND D.cod_emp =@cod_emp and D.nro_trans=@nro_trans ORDER BY linea ASC");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = Ccf_cod_emp;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                  

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        ModeloDescCargoFac item = new ModeloDescCargoFac();
                        item.linea = Convert.ToString(dr["linea"]);
                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_concepto = Convert.ToString(dr["cod_concepto"]);
                        item.cod_concepto_fis = Convert.ToString(dr["cod_concepto_fis"]);
                        item.nom_concepto = Convert.ToString(dr["nom_concepto"]);
                        item.signo = Convert.ToString(dr["signo"]);
                        item.nomcod = item.cod_concepto +"-"+ item.nom_concepto;
                        item.cod_ccostos = Convert.ToString(dr["cod_ccostos"]);
                        item.cod_cta = Convert.ToString(dr["cod_cta"]);
                        item.valor_descto = Convert.ToDecimal(dr["valor_descto"]);
                        item.valor_descuento = String.Format("{0:N2}", item.valor_descto);
                        item.porc_descto = Convert.ToDecimal(dr["porc_descto"]);
                        item.total = Convert.ToDecimal(dr["total"]);
                        item.total_for = String.Format("{0:N2}", item.total);
                        item.porcen_desc = String.Format("{0:N2}", item.porc_descto);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        if(item.signo =="D")
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaDescCargTrans", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }


        }
        //Guardar descuentos y recargos
        public string InsertarDescCargTrans(ModeloDescCargoFac modeloDes)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "INSERT INTO  wmt_facturas_descto (nro_trans,cod_emp,linea,cod_concepto,signo,nom_concepto,porc_descto,valor_descto,cod_cta,cod_ccostos,usuario_mod,fecha_mod, total, base_imponible) VALUES (@nro_trans,@cod_emp,@linea,@cod_concepto,@signo,@nom_concepto,@porc_descto,@valor_descto,@cod_cta,@cod_ccostos,@usuario_mod,@fecha_mod, @total, @monto_imponible)";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = modeloDes.nro_trans;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = modeloDes.cod_emp;
                conmand.Parameters.Add("@linea", SqlDbType.VarChar).Value = modeloDes.linea;
                conmand.Parameters.Add("@cod_concepto", SqlDbType.VarChar).Value = modeloDes.cod_concepto;
                conmand.Parameters.Add("@signo", SqlDbType.VarChar).Value = modeloDes.signo;
                conmand.Parameters.Add("@nom_concepto", SqlDbType.VarChar).Value = modeloDes.nom_concepto;
                conmand.Parameters.Add("@porc_descto", SqlDbType.VarChar).Value = modeloDes.porc_descto;
                conmand.Parameters.Add("@valor_descto", SqlDbType.VarChar).Value = modeloDes.valor_descto;
                conmand.Parameters.Add("@cod_cta", SqlDbType.VarChar).Value = modeloDes.cod_cta;
                conmand.Parameters.Add("@cod_ccostos", SqlDbType.VarChar).Value = modeloDes.cod_ccostos;
                conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = modeloDes.usuario_mod;
                conmand.Parameters.Add("@fecha_mod", SqlDbType.VarChar).Value = modeloDes.fecha_mod;
                conmand.Parameters.Add("@total", SqlDbType.VarChar).Value = modeloDes.total;
                conmand.Parameters.Add("@monto_imponible", SqlDbType.VarChar).Value = modeloDes.monto_imponible;

                int dr = conmand.ExecuteNonQuery();
                cn.Close();
                return "";
            }

            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(modeloDes.cod_emp, metodo, "InsertarDescCargTrans", e.ToString(), DateTime.Now, modeloDes.usuario_mod);
                return "No se pudo completar la acción." + "InsertarDescCargTrans." + " Por favor notificar al administrador.";
            }
        }

        //Actualizar descuentos y recargos
        public string ActualizarDescCargTrans(ModeloDescCargoFac modeloDes)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "UPDATE  wmt_facturas_descto SET cod_concepto =@cod_concepto, signo =@signo, nom_concepto =@nom_concepto, porc_descto =@porc_descto, valor_descto=@valor_descto ,cod_cta =@cod_cta ,cod_ccostos=@cod_ccostos , usuario_mod =@usuario_mod, fecha_mod=@fecha_mod, total=@total, base_imponible=@monto_imponible WHERE nro_trans=@nro_trans AND cod_emp=@cod_emp AND linea=@linea";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = modeloDes.nro_trans;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = modeloDes.cod_emp;
                conmand.Parameters.Add("@linea", SqlDbType.VarChar).Value = modeloDes.linea;
                conmand.Parameters.Add("@cod_concepto", SqlDbType.VarChar).Value = modeloDes.cod_concepto;
                conmand.Parameters.Add("@signo", SqlDbType.VarChar).Value = modeloDes.signo;
                conmand.Parameters.Add("@nom_concepto", SqlDbType.VarChar).Value = modeloDes.nom_concepto;
                conmand.Parameters.Add("@porc_descto", SqlDbType.VarChar).Value = modeloDes.porc_descto;
                conmand.Parameters.Add("@valor_descto", SqlDbType.VarChar).Value = modeloDes.valor_descto;
                conmand.Parameters.Add("@cod_cta", SqlDbType.VarChar).Value = modeloDes.cod_cta;
                conmand.Parameters.Add("@cod_ccostos", SqlDbType.VarChar).Value = modeloDes.cod_ccostos;
                conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = modeloDes.usuario_mod;
                conmand.Parameters.Add("@fecha_mod", SqlDbType.VarChar).Value = modeloDes.fecha_mod;
                conmand.Parameters.Add("@total", SqlDbType.VarChar).Value = modeloDes.total;
                conmand.Parameters.Add("@monto_imponible", SqlDbType.VarChar).Value = modeloDes.monto_imponible;

                int dr = conmand.ExecuteNonQuery();
                cn.Close();
                return "Descuento actualizado correctamente";
            }

            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(modeloDes.cod_emp, metodo, "ActualizarDescCargTrans", e.ToString(), DateTime.Now, modeloDes.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarDescCargTrans." + " Por favor notificar al administrador.";
            }

        }

        //Eliminar descuentos y recargos
        public string EliminarDescCargTrans(ModeloDescCargoFac modeloDes)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "DELETE FROM  wmt_facturas_descto  WHERE nro_trans=@nro_trans AND cod_emp=@cod_emp AND linea=@linea";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = modeloDes.nro_trans;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = modeloDes.cod_emp;
                conmand.Parameters.Add("@linea", SqlDbType.VarChar).Value = modeloDes.linea;

                int dr = conmand.ExecuteNonQuery();
                cn.Close();
                return "Descuento eliminado correctamente";
            }

            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(modeloDes.cod_emp, metodo, "EliminarDescCargTrans", e.ToString(), DateTime.Now, modeloDes.usuario_mod);
                return "No se pudo completar la acción." + "EliminarDescCargTrans." + " Por favor notificar al administrador.";
            }
        }
    }
}
