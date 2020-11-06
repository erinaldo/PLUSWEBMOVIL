using CapaDatos.Modelos;
using CapaDatos.Modelos.ModelosNC;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public class FacturACab
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "FacturaACab.cs";
        //CONSULTA SI EXISTE CABCERA DE FACTURA
        public Boolean ConsultaSNCabecera(string nro_trans, string cod_emp, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    Boolean existe = false;
                    string consulta = "SELECT * FROM wmt_facturas_cab WHERE nro_trans =@nro_trans and cod_emp=@cod_emp";

                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        existe = true;
                    }
                    return existe;
            
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaSNCabecera", e.ToString(), DateTime.Now, usuario);
                return false ;
            }


        }

        //ACTUALIZAR CABECERA DE FACTURA
        public string ActualizarCabeceraFactura(modelocabecerafactura cabezeraFactura)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string update = "UPDATE wmt_facturas_cab SET cod_cliente =@cod_cliente, fec_doc =@fec_doc, dia =@dia, mes =@mes, anio =@anio, serie_docum =@serie_docum, cod_ccostos =@cod_ccostos, cod_vendedor =@cod_vendedor, cod_fpago =@cod_fpago, observaciones =@observaciones,usuario_mod =@usuario_mod,ocompra = @ocompra, cod_moneda = @cod_moneda, diar =@diar , mesr = @mesr, anior = @anior, cod_sucursal =@cod_sucursal, nro_pedido =@nro_pedido , cod_suc_cli=@cod_suc_cli WHERE nro_trans =@nro_trans ";
                    SqlCommand conmand = new SqlCommand(update, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = cabezeraFactura.nro_trans;
                    conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = cabezeraFactura.cod_cliente;
                    conmand.Parameters.Add("@fec_doc", SqlDbType.Date).Value = cabezeraFactura.fec_doc;
                    conmand.Parameters.Add("@dia", SqlDbType.VarChar).Value = cabezeraFactura.dia;
                    conmand.Parameters.Add("@mes", SqlDbType.VarChar).Value = cabezeraFactura.mes;
                    conmand.Parameters.Add("@anio", SqlDbType.VarChar).Value = cabezeraFactura.anio;
                    conmand.Parameters.Add("@serie_docum", SqlDbType.VarChar).Value = cabezeraFactura.serie_docum;
                    conmand.Parameters.Add("@cod_ccostos", SqlDbType.VarChar).Value = cabezeraFactura.cod_ccostos;
                    conmand.Parameters.Add("@cod_vendedor", SqlDbType.VarChar).Value = cabezeraFactura.cod_vendedor;
                    conmand.Parameters.Add("@cod_fpago", SqlDbType.VarChar).Value = cabezeraFactura.cod_fpago;
                    conmand.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = cabezeraFactura.observaciones;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = cabezeraFactura.usuario_mod;
                    conmand.Parameters.Add("@ocompra", SqlDbType.VarChar).Value = cabezeraFactura.ocompra;
                    conmand.Parameters.Add("@cod_moneda", SqlDbType.VarChar).Value = cabezeraFactura.cod_moneda;
                    conmand.Parameters.Add("@diar", SqlDbType.VarChar).Value = cabezeraFactura.diar;
                    conmand.Parameters.Add("@mesr", SqlDbType.VarChar).Value = cabezeraFactura.mesr;
                    conmand.Parameters.Add("@anior", SqlDbType.VarChar).Value = cabezeraFactura.anior;
                    conmand.Parameters.Add("@cod_sucursal", SqlDbType.VarChar).Value = cabezeraFactura.cod_sucursal.Trim();
                    conmand.Parameters.Add("@nro_pedido", SqlDbType.VarChar).Value = cabezeraFactura.nro_pedido;
                    conmand.Parameters.Add("@cod_suc_cli", SqlDbType.VarChar).Value = cabezeraFactura.cod_suc_cli;

                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cabezeraFactura.cod_emp, metodo, "ActualizarCabeceraFactura", e.ToString(), DateTime.Now, cabezeraFactura.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarCabeceraFactura." + " Por favor notificar al administrador.";
            }


        }

        //ACTUALIXAR DATOSFACTURA
        public string ActualizarDetalleFactura(ModeloDetalleFactura detalleFactura)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "UPDATE  wmt_facturas_det SET  nom_articulo=@nom_articulo, nom_articulo2 =@nom_articulo2, cantidad =@cantidad, precio_unit =@precio_unit, base_imp =@base_imp, porc_iva =@porc_iva, cod_emp =@cod_emp, cod_articulo =@cod_articulo, cod_concepret =@cod_concepret, porc_descto =@porc_descto, valor_descto =@valor_descto, cod_cta_vtas =@cod_cta_vtas, cod_cta_cos =@cod_cta_cos, cod_cta_inve =@cod_cta_inve, usuario_mod =@usuario_mod, nro_audit =@nro_audit, fecha_mod =@fecha_mod, tasa_iva =@tasa_iva, cod_ccostos =@cod_ccostos WHERE nro_trans = @nro_trans AND linea=@linea";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@nom_articulo", SqlDbType.VarChar).Value = detalleFactura.nom_articulo;
                    conmand.Parameters.Add("@nom_articulo2", SqlDbType.VarChar).Value = detalleFactura.nom_articulo2;
                    conmand.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = detalleFactura.cantidad;
                    conmand.Parameters.Add("@precio_unit", SqlDbType.Decimal).Value = detalleFactura.precio_unit;
                    conmand.Parameters.Add("@base_imp", SqlDbType.Decimal).Value = detalleFactura.base_imp;
                    conmand.Parameters.Add("@porc_iva", SqlDbType.Decimal).Value = detalleFactura.porc_iva;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = detalleFactura.nro_trans;
                    conmand.Parameters.Add("@linea", SqlDbType.Int).Value = detalleFactura.linea;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = detalleFactura.cod_emp;
                    conmand.Parameters.Add("@cod_articulo", SqlDbType.VarChar).Value = detalleFactura.cod_articulo;
                    conmand.Parameters.Add("@cod_concepret", SqlDbType.VarChar).Value = detalleFactura.cod_concepret;
                    conmand.Parameters.Add("@porc_descto", SqlDbType.Decimal).Value = detalleFactura.porc_descto;
                    conmand.Parameters.Add("@valor_descto", SqlDbType.Decimal).Value = detalleFactura.valor_descto;
                    conmand.Parameters.Add("@cod_cta_vtas", SqlDbType.VarChar).Value = detalleFactura.cod_cta_vtas;
                    conmand.Parameters.Add("@cod_cta_cos", SqlDbType.VarChar).Value = detalleFactura.cod_cta_cos;
                    conmand.Parameters.Add("@cod_cta_inve", SqlDbType.VarChar).Value = detalleFactura.cod_cta_inve;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = detalleFactura.usuario_mod;
                    conmand.Parameters.Add("@nro_audit", SqlDbType.VarChar).Value = detalleFactura.nro_audit;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = detalleFactura.fecha_mod;
                    conmand.Parameters.Add("@tasa_iva", SqlDbType.VarChar).Value = detalleFactura.tasa_iva;
                    conmand.Parameters.Add("@cod_ccostos", SqlDbType.VarChar).Value = detalleFactura.cod_ccostos;

                    int dr = conmand.ExecuteNonQuery();

                    return "Factura guardada correctamente";
                }


            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(detalleFactura.nro_trans, metodo, "ActualizarDetalleFactura", e.ToString(), DateTime.Today, "UDP");
                return "No se pudo completar la acción." + "ActualizarDetalleFactura." + " Por favor notificar al administrador.";
            }

        }

        //ACTUALIXAR ESTADO FACTURA
        public string ActualizarEstadoFactura(string nro_trans, string estado)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "UPDATE wmt_facturas_cab SET  estado = @estado WHERE nro_trans = @nro_trans";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;

                    int dr = conmand.ExecuteNonQuery();
                   
                    return "Factura guardada correctamente";
                }

                
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ActualizarEstadoFactura", e.ToString(), DateTime.Today,"UDP");
                return "No se pudo completar la acción." + "ActualizarEstadoFactura." + " Por favor notificar al administrador.";
            }

        }

        // Guardar documento adjunto factura
        public string ActualizarAdjuntoFactura(string nro_trans, string adjunto, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "UPDATE wmt_facturas_cab SET  doc_adjunto = @doc_adjunto WHERE nro_trans = @nro_trans";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.Parameters.Add("@doc_adjunto", SqlDbType.VarChar).Value = adjunto;

                    int dr = conmand.ExecuteNonQuery();

                    return "Factura guardada correctamente";
                }


            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ActualizarAdjuntoFactura", e.ToString(), DateTime.Now, usuario);
                return "No se pudo completar la acción." + "ActualizarObsFactura." + " Por favor notificar al administrador.";
            }

        }
        public string ActualizarObsFactura(string nro_trans, string observaciones)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "UPDATE wmt_facturas_cab SET  observaciones = @observaciones WHERE nro_trans = @nro_trans";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = observaciones;

                    int dr = conmand.ExecuteNonQuery();

                    return "Factura guardada correctamente";
                }


            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ActualizarObsFactura", e.ToString(), DateTime.Now, "UDP");
                return "No se pudo completar la acción." + "ActualizarObsFactura." + " Por favor notificar al administrador.";
            }

        }

        public string EliminarCabDetFactura(string nro_trans)
        {
            try
            {             

                using (cn = conexion.genearConexion())
                {

                    string mensaje = "Eliminacion correctamente";
                    string delete = "DELETE FROM wmt_facturas_det WHERE nro_trans =  @nro_trans ";
                    SqlCommand conmand = new SqlCommand(delete, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.ExecuteNonQuery();


                    string delete1 = "DELETE FROM wmt_facturas_cab WHERE nro_trans = @nro_trans ";
                    conmand = new SqlCommand(delete1, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.ExecuteNonQuery();                   
                    return mensaje;
                }
                
            
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "EliminarCabDetFactura", e.ToString(), DateTime.Today, "DLT");
                return "No se pudo completar la acción." + "EliminarCabDetFactura." + " Por favor notificar al administrador.";
            }

        }

        //Consulta para saber que tipo es ncve, pose, vtae
        public List<modelowmtfacturascab> ConsultaTipoFC(string nro_trans)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelowmtfacturascab> lista = new List<modelowmtfacturascab>();
                    string consulta = ("select nro_trans, tipo, estado,ocompra, doc_adjunto from wmt_facturas_cab where nro_trans = @nro_trans");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modelowmtfacturascab item = new modelowmtfacturascab();

                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.tipo_nce = Convert.ToString(dr["tipo"]);
                        item.estado = Convert.ToString(dr["estado"]);
                        item.ocompra = Convert.ToString(dr["ocompra"]);
                        item.doc_adjunto = Convert.ToString(dr["doc_adjunto"]);

                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ConsultaTipoFC", e.ToString(), DateTime.Today, "consulta");
                return null;
            }


        }

        //Consultar datos solo de laNC PARA Q EN NULL no de error
        public List<modelowmtfacturascab> ConsultaDatosNCPadre(string nro_trans)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelowmtfacturascab> lista = new List<modelowmtfacturascab>();
                    string consulta = ("select nro_trans_padre, tipo, mot_nce from wmt_facturas_cab where nro_trans = @nro_trans");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modelowmtfacturascab item = new modelowmtfacturascab();
                        
                        item.nro_trans_padre = Convert.ToString(dr["nro_trans_padre"]);
                        item.tipo_nce = Convert.ToString(dr["tipo"]);
                        item.mot_nce = Convert.ToString(dr["mot_nce"]);

                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ConsultaDatosNCPadre", e.ToString(), DateTime.Today, "consulta");
                return null;
            }


        }
        public List<modelowmtfacturascab> ConsultaFacturaNroTran(  string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string Ccf_estado, string Ccf_cliente, string Ccf_cod_docum,string Ccf_serie_docum, string Ccf_nro_docum ,string Ccf_diai, string Ccf_mesi, string Ccf_anioi, string Ccf_diaf,string Ccf_mesf, string Ccf_aniof)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelowmtfacturascab> lista = new List<modelowmtfacturascab>();
                    string consulta = ("wmspc_facturasWM_cab");
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

                        modelowmtfacturascab item = new modelowmtfacturascab();
                        item.observacion = Convert.ToString(dr["serie_docum"]) + " - " + Convert.ToString(dr["nro_docum"]);
                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.fec_doc = Convert.ToDateTime(dr["fec_doc"]);
                        DateTime fec_doc_str = Convert.ToDateTime(dr["fec_doc"]);
                        item.fec_doc_str = fec_doc_str.ToString("yyyy-MM-dd");
                        item.aniomes = Convert.ToString(dr["aniomes"]);
                        item.cod_docum = Convert.ToString(dr["cod_docum"]);
                        item.serie_docum = Convert.ToString(dr["serie_docum"]);
                        item.nro_docum = Convert.ToString(dr["nro_docum"]);
                        item.cod_cliente = Convert.ToString(dr["cod_cliente"]);
                        item.nom_tit = Convert.ToString(dr["nom_tit"]);
                        item.cod_ccostos = Convert.ToString(dr["cod_ccostos"]);
                        item.nom_dpto = Convert.ToString(dr["nom_dpto"]);
                        item.dir_tit = Convert.ToString(dr["dir_tit"]);
                        item.tel_tit = Convert.ToString(dr["tel_tit"]);
                        item.nro_dgi = Convert.ToString(dr["nro_dgi"]);
                        item.nro_dgi2 = Convert.ToString(dr["nro_dgi2"]);
                        item.nro_dgi1 = Convert.ToString(dr["nro_dgi1"]);
                        item.cod_fpago = Convert.ToString(dr["cod_fpago"]).Trim();
                        item.nom_fpago = Convert.ToString(dr["nom_fpago"]);
                        item.plazo_libre = Convert.ToString(dr["plazo_libre"]);
                        item.observaciones = Convert.ToString(dr["observaciones"]);
                        item.fec_venc = Convert.ToDateTime(dr["fec_venc"]);
                        DateTime fec_venc_str = Convert.ToDateTime(dr["fec_venc"]);
                        item.fec_venc_str = fec_venc_str.ToString("yyyy-MM-dd");
                        item.cod_vendedor = Convert.ToString(dr["cod_vendedor"]);
                        item.nom_vendedor = Convert.ToString(dr["nom_vend"]);
                        item.estado = Convert.ToString(dr["estado"]);
                        item.subtotal = Convert.ToDecimal(dr["subtotal"]);
                        item.iva = Convert.ToDecimal(dr["iva"]);
                        item.impuesto2 = Convert.ToDecimal(dr["impuesto2"]);
                        item.impuesto3 = Convert.ToDecimal(dr["impuesto3"]);
                        item.impuesto4 = Convert.ToDecimal(dr["impuesto4"]);
                        item.impuesto5 = Convert.ToDecimal(dr["impuesto5"]);
                        item.ret = Convert.ToDecimal(dr["ret"]);
                        item.neto = Convert.ToDecimal(dr["neto"]);
                        item.total = Convert.ToDecimal(dr["total"]);
                        item.monto_imponible = Convert.ToDecimal(dr["monto_imponible"]);
                        item.porc_descto = Convert.ToDecimal(dr["porc_descto"]);
                        item.descuento = Convert.ToDecimal(dr["descuento"]);
                        item.suman = Convert.ToDecimal(dr["suman"]);
                        item.signo = Convert.ToDecimal(dr["signo"]);
                        item.Saldo = Convert.ToDecimal(dr["Saldo"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.nom_ciudad = Convert.ToString(dr["nom_ciudad"]);
                        item.vlr_letras = Convert.ToString(dr["vlr_letras"]);
                        item.cod_atrib1 = Convert.ToString(dr["cod_atrib1"]);
                        item.ini = Convert.ToString(dr["ini"]);
                        item.fin = Convert.ToString(dr["fin"]);
                        item.fres_ini = Convert.ToDateTime(dr["fres_ini"]);
                        DateTime fres_ini_str = Convert.ToDateTime(dr["fres_ini"]);
                        item.fres_ini_str = fres_ini_str.ToString("yyyy-MM-dd");
                        item.fres_fin = Convert.ToDateTime(dr["fres_fin"]);
                        DateTime fres_fin_str = Convert.ToDateTime(dr["fres_fin"]);
                        item.fres_fin_str = fres_fin_str.ToString("yyyy-MM-dd");
                        item.mes_char = Convert.ToString(dr["mes_char"]);
                        item.pagina_edicion = Convert.ToString(dr["pagina_edicion"]);
                        item.nom_edicion = Convert.ToString(dr["nom_edicion"]);
                        item.pagina_elimina = Convert.ToString(dr["pagina_elimina"]);
                        item.nom_corto = Convert.ToString(dr["nom_corto"]);
                        item.ntipo = Convert.ToString(dr["ntipo"]);
                        item.ocompra = Convert.ToString(dr["ocompra"]);
                        item.cod_moneda = Convert.ToString(dr["cod_moneda"]);
                        item.sim = Convert.ToString(dr["sim"]);
                        item.nom_moneda = Convert.ToString(dr["nom_moneda"]);
                        item.nro_doc_inve = Convert.ToString(dr["nro_doc_inve"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                        item.nro_pedido = Convert.ToString(dr["nro_pedido"]);
                        item.email_tit = Convert.ToString(dr["email_tit"]);
                        item.cod_suc_cli = Convert.ToString(dr["cod_suc"]);
                        item.nom_suc = Convert.ToString(dr["nom_suc"]);
                        item.codnom_suc = Convert.ToString(dr["sucurcli"]);
                        item.desctos_rcgos = Convert.ToDecimal(dr["desctos_rcgos"]);
                        item.tipo = Convert.ToString(dr["tipo"]);
                        item.icn = Convert.ToDecimal(dr["inc"]);
                        item.doc_adjunto = Convert.ToString(dr["doc_adjunto"]);
                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaFacturaNroTran", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }


        }
     

    public List<modelowmtfacturascab> ConsultaNCENroTran(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string Ccf_estado, string Ccf_cliente, string Ccf_cod_docum, string Ccf_serie_docum, string Ccf_nro_docum, string Ccf_diai, string Ccf_mesi, string Ccf_anioi, string Ccf_diaf, string Ccf_mesf, string Ccf_aniof)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelowmtfacturascab> lista = new List<modelowmtfacturascab>();
                    string consulta = ("wmspc_facturasWM_cab");
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

                        modelowmtfacturascab item = new modelowmtfacturascab();
                        item.observacion = Convert.ToString(dr["serie_docum"]) + " - " + Convert.ToString(dr["nro_docum"]);
                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.fec_doc = Convert.ToDateTime(dr["fec_doc"]);
                        DateTime fec_doc_str = Convert.ToDateTime(dr["fec_doc"]);
                        item.fec_doc_str = fec_doc_str.ToString("yyyy-MM-dd");
                        item.aniomes = Convert.ToString(dr["aniomes"]);
                        item.cod_docum = Convert.ToString(dr["cod_docum"]);
                        item.serie_docum = Convert.ToString(dr["serie_docum"]);
                        item.nro_docum = Convert.ToString(dr["nro_docum"]);
                        item.cod_cliente = Convert.ToString(dr["cod_cliente"]);
                        item.nom_tit = Convert.ToString(dr["nom_tit"]);
                        item.cod_ccostos = Convert.ToString(dr["cod_ccostos"]);
                        item.nom_dpto = Convert.ToString(dr["nom_dpto"]);
                        item.dir_tit = Convert.ToString(dr["dir_tit"]);
                        item.tel_tit = Convert.ToString(dr["tel_tit"]);
                        item.nro_dgi = Convert.ToString(dr["nro_dgi"]);
                        item.nro_dgi2 = Convert.ToString(dr["nro_dgi2"]);
                        item.nro_dgi1 = Convert.ToString(dr["nro_dgi1"]);
                        item.cod_fpago = Convert.ToString(dr["cod_fpago"]);
                        item.nom_fpago = Convert.ToString(dr["nom_fpago"]);
                        item.plazo_libre = Convert.ToString(dr["plazo_libre"]);
                        item.observaciones = Convert.ToString(dr["observaciones"]);
                        item.fec_venc = Convert.ToDateTime(dr["fec_venc"]);
                        DateTime fec_venc_str = Convert.ToDateTime(dr["fec_venc"]);
                        item.fec_venc_str = fec_venc_str.ToString("yyyy-MM-dd");
                        item.cod_vendedor = Convert.ToString(dr["cod_vendedor"]);
                        item.nom_vendedor = Convert.ToString(dr["nom_vend"]);
                        item.estado = Convert.ToString(dr["estado"]);
                        item.subtotal = Convert.ToDecimal(dr["subtotal"]);
                        item.iva = Convert.ToDecimal(dr["iva"]);
                        item.impuesto2 = Convert.ToDecimal(dr["impuesto2"]);
                        item.impuesto3 = Convert.ToDecimal(dr["impuesto3"]);
                        item.impuesto4 = Convert.ToDecimal(dr["impuesto4"]);
                        item.impuesto5 = Convert.ToDecimal(dr["impuesto5"]);
                        item.total = Convert.ToDecimal(dr["total"]);
                        item.monto_imponible = Convert.ToDecimal(dr["monto_imponible"]);
                        item.porc_descto = Convert.ToDecimal(dr["porc_descto"]);
                        item.descuento = Convert.ToDecimal(dr["descuento"]);
                        item.suman = Convert.ToDecimal(dr["suman"]);
                        item.signo = Convert.ToDecimal(dr["signo"]);
                        item.Saldo = Convert.ToDecimal(dr["Saldo"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.nom_ciudad = Convert.ToString(dr["nom_ciudad"]);
                        item.vlr_letras = Convert.ToString(dr["vlr_letras"]);
                        item.cod_atrib1 = Convert.ToString(dr["cod_atrib1"]);
                        item.ini = Convert.ToString(dr["ini"]);
                        item.fin = Convert.ToString(dr["fin"]);
                        item.fres_ini = Convert.ToDateTime(dr["fres_ini"]);
                        DateTime fres_ini_str = Convert.ToDateTime(dr["fres_ini"]);
                        item.fres_ini_str = fres_ini_str.ToString("yyyy-MM-dd");
                        item.fres_fin = Convert.ToDateTime(dr["fres_fin"]);
                        DateTime fres_fin_str = Convert.ToDateTime(dr["fres_fin"]);
                        item.fres_fin_str = fres_fin_str.ToString("yyyy-MM-dd");
                        item.mes_char = Convert.ToString(dr["mes_char"]);
                        item.pagina_edicion = Convert.ToString(dr["pagina_edicion"]);
                        item.nom_edicion = Convert.ToString(dr["nom_edicion"]);
                        item.pagina_elimina = Convert.ToString(dr["pagina_elimina"]);
                        item.nom_corto = Convert.ToString(dr["nom_corto"]);
                        item.ntipo = Convert.ToString(dr["ntipo"]);
                        item.ocompra = Convert.ToString(dr["ocompra"]);
                        item.cod_moneda = Convert.ToString(dr["cod_moneda"]);
                        item.sim = Convert.ToString(dr["sim"]);
                        item.nom_moneda = Convert.ToString(dr["nom_moneda"]);
                        item.nro_doc_inve = Convert.ToString(dr["nro_doc_inve"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                        item.nro_pedido = Convert.ToString(dr["nro_pedido"]);
                        item.email_tit = Convert.ToString(dr["email_tit"]);
                        item.tipo_nce = Convert.ToString(dr["email_tit"]);

                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaNCENroTran", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }


        }
        public string InsertarCabecera(modelocabecerafactura cabezeraFactura)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO  wmt_facturas_cab  (cod_cliente, fec_doc, dia, mes, anio, serie_docum, cod_ccostos, cod_vendedor, cod_fpago, observaciones, nro_trans, cod_emp, cod_docum, nro_docum, subtotal, iva, monto_imponible, total, estado, usuario_mod, nro_audit, ocompra, cod_moneda, tipo, porc_descto, descuento, diar, mesr, anior, cod_proc_aud, cod_sucursal, nro_pedido, cod_suc_cli,desctos_rcgos, impuesto6) VALUES( @cod_cliente, @fec_doc, @dia, @mes, @anio, @serie_docum, @cod_ccostos, @cod_vendedor, @cod_fpago, @observaciones, @nro_trans, @cod_emp, @cod_docum, @nro_docum, @subtotal, @iva, @monto_imponible, @total, @estado, @usuario_mod, @nro_audit, @ocompra, @cod_moneda, @tipo, @porc_descto, @descuento, @diar, @mesr, @anior, @cod_proc_aud, @cod_sucursal, @nro_pedido, @cod_suc_cli, @desctos_rcgos, @impuesto6)";

                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = cabezeraFactura.cod_cliente;
                    conmand.Parameters.Add("@fec_doc", SqlDbType.Date).Value = cabezeraFactura.fec_doc;
                    conmand.Parameters.Add("@dia", SqlDbType.VarChar).Value = cabezeraFactura.dia;
                    conmand.Parameters.Add("@mes", SqlDbType.VarChar).Value = cabezeraFactura.mes;
                    conmand.Parameters.Add("@anio", SqlDbType.VarChar).Value = cabezeraFactura.anio;
                    conmand.Parameters.Add("@serie_docum", SqlDbType.VarChar).Value = cabezeraFactura.serie_docum;
                    conmand.Parameters.Add("@cod_ccostos", SqlDbType.VarChar).Value = cabezeraFactura.cod_ccostos;
                    conmand.Parameters.Add("@cod_vendedor", SqlDbType.VarChar).Value = cabezeraFactura.cod_vendedor;
                    conmand.Parameters.Add("@cod_fpago", SqlDbType.VarChar).Value = cabezeraFactura.cod_fpago;
                    conmand.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = cabezeraFactura.observaciones;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = cabezeraFactura.nro_trans;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cabezeraFactura.cod_emp;
                    conmand.Parameters.Add("@cod_docum", SqlDbType.VarChar).Value = cabezeraFactura.cod_docum;
                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = cabezeraFactura.nro_docum;
                    conmand.Parameters.Add("@subtotal", SqlDbType.Decimal).Value = cabezeraFactura.subtotal;
                    conmand.Parameters.Add("@iva", SqlDbType.Decimal).Value = cabezeraFactura.iva;
                    conmand.Parameters.Add("@monto_imponible", SqlDbType.Decimal).Value = cabezeraFactura.monto_imponible;
                    conmand.Parameters.Add("@total", SqlDbType.Decimal).Value = cabezeraFactura.total;
                    conmand.Parameters.Add("@estado", SqlDbType.VarChar).Value = cabezeraFactura.estado;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = cabezeraFactura.usuario_mod;
                    conmand.Parameters.Add("@nro_audit", SqlDbType.VarChar).Value = cabezeraFactura.nro_audit;
                    conmand.Parameters.Add("@ocompra", SqlDbType.VarChar).Value = cabezeraFactura.ocompra;
                    conmand.Parameters.Add("@cod_moneda", SqlDbType.VarChar).Value = cabezeraFactura.cod_moneda;
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = cabezeraFactura.tipo;
                    conmand.Parameters.Add("@porc_descto", SqlDbType.Decimal).Value = cabezeraFactura.porc_descto;
                    conmand.Parameters.Add("@descuento", SqlDbType.Decimal).Value = cabezeraFactura.descuento;
                    conmand.Parameters.Add("@diar", SqlDbType.VarChar).Value = cabezeraFactura.diar;
                    conmand.Parameters.Add("@mesr", SqlDbType.VarChar).Value = cabezeraFactura.mesr;
                    conmand.Parameters.Add("@anior", SqlDbType.VarChar).Value = cabezeraFactura.anior;
                    conmand.Parameters.Add("@cod_proc_aud", SqlDbType.VarChar).Value = cabezeraFactura.cod_proc_aud;
                    conmand.Parameters.Add("@cod_sucursal", SqlDbType.VarChar).Value = cabezeraFactura.cod_sucursal.Trim();
                    conmand.Parameters.Add("@nro_pedido", SqlDbType.VarChar).Value = cabezeraFactura.nro_pedido;
                    conmand.Parameters.Add("@cod_suc_cli", SqlDbType.VarChar).Value = cabezeraFactura.cod_suc_cli;
                    conmand.Parameters.Add("@desctos_rcgos", SqlDbType.VarChar).Value = cabezeraFactura.desctos_rcgos;
                    conmand.Parameters.Add("@impuesto6", SqlDbType.VarChar).Value = cabezeraFactura.desctos_rcgos;

                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "";
                }
                
           }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cabezeraFactura.cod_emp, metodo, "InsertarCabcecera", e.ToString(), DateTime.Now, cabezeraFactura.usuario_mod);
                return "No se pudo completar la acción." + "InsertarCabcecera." + " Por favor notificar al administrador.";
            }


        }

        //Actualizar cabecera de NOTA CREDITO FINANCIERA/devolucion/anulacion
        public string ActualizarCabeceraNCFinan(modelocabecerafactura cabezeraFactura)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string update = "UPDATE wmt_facturas_cab SET cod_cliente =@cod_cliente, fec_doc =@fec_doc, dia =@dia, mes =@mes, anio =@anio, serie_docum =@serie_docum, cod_ccostos =@cod_ccostos, cod_vendedor =@cod_vendedor, cod_fpago =@cod_fpago, observaciones =@observaciones,usuario_mod =@usuario_mod,ocompra = @ocompra, cod_moneda = @cod_moneda, diar =@diar , mesr = @mesr, anior = @anior, cod_sucursal =@cod_sucursal, nro_pedido =@nro_pedido, nro_trans_padre =@nro_trans_padre, mot_nce =@mot_nce, cod_suc_cli=@cod_suc_cli WHERE nro_trans =@nro_trans ";
                    SqlCommand conmand = new SqlCommand(update, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = cabezeraFactura.nro_trans;
                    conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = cabezeraFactura.cod_cliente;
                    conmand.Parameters.Add("@fec_doc", SqlDbType.Date).Value = cabezeraFactura.fec_doc;
                    conmand.Parameters.Add("@dia", SqlDbType.VarChar).Value = cabezeraFactura.dia;
                    conmand.Parameters.Add("@mes", SqlDbType.VarChar).Value = cabezeraFactura.mes;
                    conmand.Parameters.Add("@anio", SqlDbType.VarChar).Value = cabezeraFactura.anio;
                    conmand.Parameters.Add("@serie_docum", SqlDbType.VarChar).Value = cabezeraFactura.serie_docum;
                    conmand.Parameters.Add("@cod_ccostos", SqlDbType.VarChar).Value = cabezeraFactura.cod_ccostos;
                    conmand.Parameters.Add("@cod_vendedor", SqlDbType.VarChar).Value = cabezeraFactura.cod_vendedor;
                    conmand.Parameters.Add("@cod_fpago", SqlDbType.VarChar).Value = cabezeraFactura.cod_fpago;
                    conmand.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = cabezeraFactura.observaciones;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = cabezeraFactura.usuario_mod;
                    conmand.Parameters.Add("@ocompra", SqlDbType.VarChar).Value = cabezeraFactura.ocompra;
                    conmand.Parameters.Add("@cod_moneda", SqlDbType.VarChar).Value = cabezeraFactura.cod_moneda;
                    conmand.Parameters.Add("@diar", SqlDbType.VarChar).Value = cabezeraFactura.diar;
                    conmand.Parameters.Add("@mesr", SqlDbType.VarChar).Value = cabezeraFactura.mesr;
                    conmand.Parameters.Add("@anior", SqlDbType.VarChar).Value = cabezeraFactura.anior;
                    conmand.Parameters.Add("@cod_sucursal", SqlDbType.VarChar).Value = cabezeraFactura.cod_sucursal.Trim();
                    conmand.Parameters.Add("@nro_pedido", SqlDbType.VarChar).Value = cabezeraFactura.nro_pedido;
                    conmand.Parameters.Add("@nro_trans_padre", SqlDbType.VarChar).Value = cabezeraFactura.nro_trans_padre;
                    conmand.Parameters.Add("@mot_nce", SqlDbType.VarChar).Value = cabezeraFactura.mot_nce.Trim();
                    conmand.Parameters.Add("@cod_suc_cli", SqlDbType.VarChar).Value = cabezeraFactura.cod_suc_cli;
                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cabezeraFactura.cod_emp, metodo, "ActualizarCabeceraNCFinan", e.ToString(), DateTime.Now, cabezeraFactura.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarCabeceraNCFinan." + " Por favor notificar al administrador.";
            }


        }

        //Insertar cabecera de NOTA CREDITO FINANCIERA/devolucion/anulacion
        public string InsertarCabeceraNCFinan(modelocabecerafactura cabezeraFactura)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO  wmt_facturas_cab  (cod_cliente, fec_doc, dia, mes, anio, serie_docum, cod_ccostos, cod_vendedor, cod_fpago, observaciones, nro_trans, cod_emp, cod_docum, nro_docum, subtotal, iva, monto_imponible, total, estado, usuario_mod, nro_audit, ocompra, cod_moneda, tipo, porc_descto, descuento, diar, mesr, anior, cod_proc_aud, cod_sucursal, nro_pedido, nro_trans_padre, mot_nce, cod_suc_cli, desctos_rcgos, impuesto6) VALUES( @cod_cliente, @fec_doc, @dia, @mes, @anio, @serie_docum, @cod_ccostos, @cod_vendedor, @cod_fpago, @observaciones, @nro_trans, @cod_emp, @cod_docum, @nro_docum, @subtotal, @iva, @monto_imponible, @total, @estado, @usuario_mod, @nro_audit, @ocompra, @cod_moneda, @tipo, @porc_descto, @descuento, @diar, @mesr, @anior, @cod_proc_aud, @cod_sucursal, @nro_pedido, @nro_trans_padre, @mot_nce, @cod_suc_cli,@desctos_rcgos, @impuesto6)";

                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = cabezeraFactura.cod_cliente;
                    conmand.Parameters.Add("@fec_doc", SqlDbType.Date).Value = cabezeraFactura.fec_doc;
                    conmand.Parameters.Add("@dia", SqlDbType.VarChar).Value = cabezeraFactura.dia;
                    conmand.Parameters.Add("@mes", SqlDbType.VarChar).Value = cabezeraFactura.mes;
                    conmand.Parameters.Add("@anio", SqlDbType.VarChar).Value = cabezeraFactura.anio;
                    conmand.Parameters.Add("@serie_docum", SqlDbType.VarChar).Value = cabezeraFactura.serie_docum;
                    conmand.Parameters.Add("@cod_ccostos", SqlDbType.VarChar).Value = cabezeraFactura.cod_ccostos;
                    conmand.Parameters.Add("@cod_vendedor", SqlDbType.VarChar).Value = cabezeraFactura.cod_vendedor;
                    conmand.Parameters.Add("@cod_fpago", SqlDbType.VarChar).Value = cabezeraFactura.cod_fpago;
                    conmand.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = cabezeraFactura.observaciones;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = cabezeraFactura.nro_trans;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cabezeraFactura.cod_emp;
                    conmand.Parameters.Add("@cod_docum", SqlDbType.VarChar).Value = cabezeraFactura.cod_docum;
                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = cabezeraFactura.nro_docum;
                    conmand.Parameters.Add("@subtotal", SqlDbType.Decimal).Value = cabezeraFactura.subtotal;
                    conmand.Parameters.Add("@iva", SqlDbType.Decimal).Value = cabezeraFactura.iva;
                    conmand.Parameters.Add("@monto_imponible", SqlDbType.Decimal).Value = cabezeraFactura.monto_imponible;
                    conmand.Parameters.Add("@total", SqlDbType.Decimal).Value = cabezeraFactura.total;
                    conmand.Parameters.Add("@estado", SqlDbType.VarChar).Value = cabezeraFactura.estado;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = cabezeraFactura.usuario_mod;
                    conmand.Parameters.Add("@nro_audit", SqlDbType.VarChar).Value = cabezeraFactura.nro_audit;
                    conmand.Parameters.Add("@ocompra", SqlDbType.VarChar).Value = cabezeraFactura.ocompra;
                    conmand.Parameters.Add("@cod_moneda", SqlDbType.VarChar).Value = cabezeraFactura.cod_moneda;
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = cabezeraFactura.tipo;
                    conmand.Parameters.Add("@porc_descto", SqlDbType.Decimal).Value = cabezeraFactura.porc_descto;
                    conmand.Parameters.Add("@descuento", SqlDbType.Decimal).Value = cabezeraFactura.descuento;
                    conmand.Parameters.Add("@diar", SqlDbType.VarChar).Value = cabezeraFactura.diar;
                    conmand.Parameters.Add("@mesr", SqlDbType.VarChar).Value = cabezeraFactura.mesr;
                    conmand.Parameters.Add("@anior", SqlDbType.VarChar).Value = cabezeraFactura.anior;
                    conmand.Parameters.Add("@cod_proc_aud", SqlDbType.VarChar).Value = cabezeraFactura.cod_proc_aud;
                    conmand.Parameters.Add("@cod_sucursal", SqlDbType.VarChar).Value = cabezeraFactura.cod_sucursal.Trim();
                    conmand.Parameters.Add("@nro_pedido", SqlDbType.VarChar).Value = cabezeraFactura.nro_pedido;
                    conmand.Parameters.Add("@nro_trans_padre", SqlDbType.VarChar).Value = cabezeraFactura.nro_trans_padre;
                    conmand.Parameters.Add("@mot_nce", SqlDbType.VarChar).Value = cabezeraFactura.mot_nce.Trim();
                    conmand.Parameters.Add("@cod_suc_cli", SqlDbType.VarChar).Value = cabezeraFactura.cod_suc_cli;
                    conmand.Parameters.Add("@desctos_rcgos", SqlDbType.VarChar).Value = cabezeraFactura.desctos_rcgos;
                    conmand.Parameters.Add("@impuesto6", SqlDbType.VarChar).Value = cabezeraFactura.desctos_rcgos;

                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cabezeraFactura.cod_emp, metodo, "InsertarCabeceraNCFinan", e.ToString(), DateTime.Today, cabezeraFactura.usuario_mod);
                return "No se pudo completar la acción." + "InsertarCabeceraNCFinan." + " Por favor notificar al administrador.";
            }


        }

        /*DOCUMENTOS ELECTRONICOS*/
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

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaDocumEletronicos", e.ToString(), DateTime.Today, "consulta");
                return null;
            }


        }
    }
}
