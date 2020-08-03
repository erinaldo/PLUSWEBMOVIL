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
   public  class Articulos
    {
        
            Conexion conexion = new Conexion();
            public SqlConnection cn = null;            
            modelowmspcarticulos modeloarticulos = new modelowmspcarticulos();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        ValidarParametrizacionFactura conexion_erp = new ValidarParametrizacionFactura();
        string metodo = "Articulos.cs";
        //Concepto Fiscal
        public List<ModeloConcFiscal> ListaConceptoFiscal(string ArtB__usuario, string ArtB__cod_emp)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {
                    List<ModeloConcFiscal> lista = new List<ModeloConcFiscal>();

                    string consulta = ("SELECT *FROM wmm_conceptos_fiscal");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        ModeloConcFiscal item = new ModeloConcFiscal();
                        item.cod_concepto_fis = Convert.ToString(dr["cod_concepto_fis"]);
                        item.nom_concepto_fis = Convert.ToString(dr["nom_concepto_fis"]);
                        item.signo = Convert.ToString(dr["signo"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod= Convert.ToString(dr["fecha_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        if (item.signo == "D")
                        {
                            item.concepto = "DESCUENTO";
                            item.concepto_1 = item.signo + "-" + item.concepto;
                        }
                        else
                        {
                            item.concepto = "CARGO";
                            item.concepto_1 = item.signo + "-" + item.concepto;
                        }
                        item.nomcon = item.cod_concepto_fis + "-" + item.nom_concepto_fis;

                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ListaConceptoFiscal", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }
        //Buscar por codigo cod_concepto  a signo concepto fiscal
        //Buscar por codigo
        public ModeloConcFiscal BuscarConFisCon(string ArtB__usuario, string ArtB__cod_emp, string cod_concepto)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {
                    // ModeloConcFiscal lista = new ModeloConcFiscal();
                    ModeloConcFiscal item = new ModeloConcFiscal();
                    string consulta = ("SELECT c.cod_concepto_fis,c.nom_concepto_fis,c.signo,c.usuario_mod,c.fecha_mod,c.nro_audit,c.cod_proc_aud,D.cod_concepto FROM wmm_conceptos_fiscal AS c ,wmm_facturas_descto AS D WHERE c.cod_concepto_fis = D.cod_concepto_fis AND D.cod_concepto =@cod_concepto");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@cod_concepto", SqlDbType.VarChar).Value = cod_concepto;
                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {


                        item.cod_concepto_fis = Convert.ToString(dr["cod_concepto_fis"]);
                        item.nom_concepto_fis = Convert.ToString(dr["nom_concepto_fis"]);
                        item.signo = Convert.ToString(dr["signo"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        if (item.signo == "D")
                        {
                            item.concepto = "DESCUENTO";
                            item.concepto_1 = item.signo + "-" + item.concepto;
                        }
                        else
                        {
                            item.concepto = "CARGO";
                            item.concepto_1 = item.signo + "-" + item.concepto;
                        }

                    }

                    return item;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "BuscarConceptoFiscal", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }
        //Buscar por codigo
        public ModeloConcFiscal BuscarConceptoFiscal(string ArtB__usuario, string ArtB__cod_emp, string cod_concepto_fis)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {
                   // ModeloConcFiscal lista = new ModeloConcFiscal();
                    ModeloConcFiscal item = new ModeloConcFiscal();
                    string consulta = ("SELECT *FROM wmm_conceptos_fiscal where cod_concepto_fis = @cod_concepto_fis");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@cod_concepto_fis", SqlDbType.VarChar).Value = cod_concepto_fis;
                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                      
                        item.cod_concepto_fis = Convert.ToString(dr["cod_concepto_fis"]);
                        item.nom_concepto_fis = Convert.ToString(dr["nom_concepto_fis"]);
                        item.signo = Convert.ToString(dr["signo"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        if(item.signo =="D")
                        {
                            item.concepto = "DESCUENTO";
                            item.concepto_1 = item.signo + "-" + item.concepto;
                        }
                        else { item.concepto = "CARGO";
                            item.concepto_1 = item.signo + "-" + item.concepto;
                        }

                    }

                    return item;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "BuscarConceptoFiscal", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }
        //INSERTAR CONCEPTO FISCAL
        public string InsertConceptoFiscal(string usuario, string cod_emp, string codigo, string nombre, string signo, DateTime fecha_mod,string nro_audit, string cod_proc_aud)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {


                    string insert = "INSERT INTO wmm_conceptos_fiscal (cod_concepto_fis,nom_concepto_fis,signo,usuario_mod,fecha_mod,nro_audit,cod_proc_aud ) values(@codigo,@nombre,@signo,@usuario,@fecha_mod,@nro_audit,@cod_proc_aud)";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;
                    conmand.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                    conmand.Parameters.Add("@signo", SqlDbType.VarChar).Value = signo;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.VarChar).Value = fecha_mod;
                    conmand.Parameters.Add("@nro_audit", SqlDbType.VarChar).Value = nro_audit;
                    conmand.Parameters.Add("@cod_proc_aud", SqlDbType.VarChar).Value = cod_proc_aud;

                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "Concepto fiscal guadrdado correctamente";
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "InsertConceptoFiscal", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }

        //Actualizar concepto fiscal
        public string ActualizarConceptoFiscal(string usuario, string cod_emp, string codigo, string nombre, string signo, DateTime fecha_mod)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {


                    string insert = "UPDATE wmm_conceptos_fiscal SET nom_concepto_fis =@nombre,signo=@signo, fecha_mod=@fecha_mod where cod_concepto_fis =@codigo";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;
                    conmand.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                    conmand.Parameters.Add("@signo", SqlDbType.VarChar).Value = signo;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.VarChar).Value = fecha_mod;

                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "Concepto fiscal guadrdado correctamente";
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ActualizarConceptoFiscal", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        //Eliminar concepto fiscal
        public string EliminarConceptoFiscal(string usuario, string cod_emp, string codigo)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {


                    string insert = "DELETE FROM wmm_conceptos_fiscal  where cod_concepto_fis =@codigo";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;

                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "Concepto fiscal eliminado correctamente";
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ActualizarConceptoFiscal", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        //eliminar Articulos referencia cruzada
        public string EliminarArticuloTem(string usuario, string cod_emp, string nro_trans)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {
                    

                    string insert = " DELETE FROM wmt_facturas_art WHERE nro_trans =@nro_trans";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;

                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "Articulo eliminado correctamente";
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "Articulos.cs", "EliminarArticuloTem", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        //Lista Articulos referencia cruzada
        public string ReferenciaCArticulo(string usuario, string cod_emp, string nro_trans)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {
                    string cod_referencia = null;

                    string consulta = ("wmspc_facturasWM_art");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        cod_referencia = Convert.ToString(dr["cod_articulo2"]);
                    }
                    return cod_referencia;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "Articulos.cs", "ReferenciaCArticulo", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }

        public List<modelowmspcarticulos> ListaArticulos(string ArtB__usuario, string ArtB__cod_emp, string ArtB__articulo, string ArtB__tipo, string ArtB__compras, string ArtB__ventas)
        {
            try {

                using (cn = conexion.genearConexion())
                {
                    List<modelowmspcarticulos> lista = new List<modelowmspcarticulos>();

                    string consulta = ("wmspc_articulos");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = ArtB__usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = ArtB__cod_emp;
                    conmand.Parameters.Add("@articulo", SqlDbType.VarChar).Value = ArtB__articulo;
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = ArtB__tipo;
                    conmand.Parameters.Add("@compras", SqlDbType.VarChar).Value = ArtB__compras;
                    conmand.Parameters.Add("@ventas", SqlDbType.VarChar).Value = ArtB__ventas;



                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modelowmspcarticulos item = new modelowmspcarticulos();
                        item.cod_articulo = Convert.ToString(dr["cod_articulo"]);
                        item.nom_articulo = Convert.ToString(dr["nom_articulo"]);
                        item.nom_det_art = Convert.ToString(dr["nom_det_art"]);
                        item.cod_grpunidad = Convert.ToString(dr["cod_grpunidad"]);
                        item.activo_stk = Convert.ToString(dr["activo_stk"]);
                        item.activo_com = Convert.ToString(dr["activo_com"]);
                        item.cod_tipoart = Convert.ToString(dr["cod_tipoart"]);
                        item.volumen_art = Convert.ToDecimal(dr["volumen_art"]);
                        item.activo_cmp = Convert.ToString(dr["activo_cmp"]);
                        item.cod_concepret = Convert.ToString(dr["cod_concepret"]);
                        item.cod_cta_vtas = Convert.ToString(dr["cod_cta_vtas"]);
                        item.cod_cta_inve = Convert.ToString(dr["cod_cta_inve"]);
                        item.cod_cta_cos = Convert.ToString(dr["cod_cta_cos"]);
                        item.cod_tipo_impu = Convert.ToString(dr["cod_tipo_impu"]);
                        item.cod_tasa_impu = Convert.ToString(dr["cod_tasa_impu"]);
                        decimal fomImpu = Convert.ToDecimal(dr["porc_impuesto"]);
                        item.porc_impuesto = String.Format("{0:N2}", fomImpu).ToString();
                        decimal por_aui_str = Convert.ToDecimal(dr["porc_aiu"]);
                        item.porc_aiu = String.Format("{0:N2}", por_aui_str).ToString();
                        item.nom_impuesto = Convert.ToString(dr["nom_impuesto"]);
                        item.precio = Convert.ToString(dr["precio"]);

                        item.valor_impu = Convert.ToString(dr["valor_impu"]);
                        decimal formPrecio = Convert.ToDecimal(dr["precio_total"]);
                        item.precio_total = String.Format("{0:N2}", formPrecio).ToString();
                        item.negativo = Convert.ToString(dr["negativo"]);

                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, "Articulos.cs", "ListaArticulos", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }

        //Consulta ERP , periodo contable tabla(CmPrC)
        public string UnidadMedida(string cod_emp, string usuario, string articulo)
        {
            try
            {
                string ConexionERP = conexion_erp.ConsultaConexionERP(cod_emp, usuario);
                string unidad = "";
                using (cn = conexion.genearConexionERP(ConexionERP))
                {
                    string consulta = ("SELECT ImRecUndS FROM ImRec WHERE ImRecCod =@articulo");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@articulo", SqlDbType.VarChar).Value = articulo;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        unidad = Convert.ToString(dr["ImRecUndS"]);
                    }
                    return unidad;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "Articulos", "ValidarPeriodoContable", e.ToString(), DateTime.Now, usuario);
                return "No se pudo completar la acción." + "ValidarPeriodoContable." + " Por favor notificar al administrador.";
            }
        }

    }
}
