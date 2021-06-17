using System;
using CapaProceso.Modelos;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CapaDatos.Modelos;

namespace CapaDatos.Sql
{
    public class ConsultaProformas
    {
        //Cargar proformas para la factura cabecera
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW(); 
        string metodo = "ConsultaProformas.cs";
        //insertar en la tabla cabecera_in
        public string InsertarProformaIns(modelowmtproformascab proformaCab)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO  wmt_proformas_ins (nro_trans, nro_docum, cod_emp, cod_cliente, usuario_mod, nro_audit, cod_proceso) VALUES (@nro_trans, @nro_docum, @cod_emp, @cod_cliente, @usuario_mod, @nro_audit, @cod_proceso)";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = proformaCab.nro_trans;
                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = proformaCab.nro_docum;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = proformaCab.cod_emp;
                    conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = proformaCab.cod_cliente;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = proformaCab.usuario_mod;
                    conmand.Parameters.Add("@nro_audit", SqlDbType.VarChar).Value = proformaCab.nro_audit;
                    conmand.Parameters.Add("@cod_proceso", SqlDbType.VarChar).Value = proformaCab.cod_proceso;

                    int dr = conmand.ExecuteNonQuery();
                    return "Proforma";
                }
                
                
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(proformaCab.cod_emp, "ConsultaProformas.cs", "InsertarProformaIns", e.ToString(), DateTime.Today, proformaCab.usuario_mod);
                return "No se pudo completar la acción." + "InsertarProformaIns." + " Por favor notificar al administrador.";
            }

        }

        //BUSCAR X CABECERA UNICA
        public List<modelowmtproformascab> ConsultaProformasFactura(string nro_trans)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelowmtproformascab> lista = new List<modelowmtproformascab>();
                    string consulta = ("SELECT * FROM wmt_proformas_cab WHERE nro_trans = @nro_trans");
                    SqlCommand conmand = new SqlCommand(consulta, cn);


                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        modelowmtproformascab item = new modelowmtproformascab();

                        item.nro_trans_ndm = Convert.ToString(dr["nro_trans_ndm"]);

                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.fec_doc = Convert.ToDateTime(dr["fec_doc"]);
                        DateTime fec_doc_str = Convert.ToDateTime(dr["fec_doc"]);
                        item.fec_doc_str = fec_doc_str.ToString("yyyy-MM-dd");
                        item.proformas = Convert.ToString(dr["nro_docum"]) + " - " + item.fec_doc_str;
                        item.cod_docum = Convert.ToString(dr["cod_docum"]);
                        item.serie_docum = Convert.ToString(dr["serie_docum"]);
                        item.nro_docum = Convert.ToString(dr["nro_docum"]);
                        item.cod_cliente = Convert.ToString(dr["cod_cliente"]);
                        item.cod_ccostos = Convert.ToString(dr["cod_ccostos"]);
                        item.cod_fpago = Convert.ToString(dr["cod_fpago"]);
                        item.observaciones = Convert.ToString(dr["observaciones"]);
                        item.cod_vendedor = Convert.ToString(dr["cod_vendedor"]);
                        item.estado = Convert.ToString(dr["estado"]);
                        item.subtotal = Convert.ToDecimal(dr["subtotal"]);
                        item.iva = Convert.ToDecimal(dr["iva"]);
                        item.total = Convert.ToDecimal(dr["total"]);
                        item.monto_imponible = Convert.ToDecimal(dr["monto_imponible"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_moneda = Convert.ToString(dr["cod_moneda"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, "ConsultaProformas.cs", "ConsultaProformasFactura", e.ToString(), DateTime.Today, "consulta");
                return null;
            }


        }
        public List<modelowmtproformascab> ListaProformasFactura(string cod_cliente, string estado, string tipo)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelowmtproformascab> lista = new List<modelowmtproformascab>();
                    string consulta = ("SELECT * FROM wmt_proformas_cab WHERE cod_cliente = @cod_cliente AND estado = @estado AND tipo = @tipo");
                    SqlCommand conmand = new SqlCommand(consulta, cn);


                    conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = cod_cliente;
                    conmand.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        modelowmtproformascab item = new modelowmtproformascab();

                        item.nro_trans_ndm = Convert.ToString(dr["nro_trans_ndm"]);

                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.fec_doc = Convert.ToDateTime(dr["fec_doc"]);
                        DateTime fec_doc_str = Convert.ToDateTime(dr["fec_doc"]);
                        item.fec_doc_str = fec_doc_str.ToString("yyyy-MM-dd");
                        item.proformas = Convert.ToString(dr["nro_docum"]) + " - " + item.fec_doc_str;
                        item.cod_docum = Convert.ToString(dr["cod_docum"]);
                        item.serie_docum = Convert.ToString(dr["serie_docum"]);
                        item.nro_docum = Convert.ToString(dr["nro_docum"]);
                        item.cod_cliente = Convert.ToString(dr["cod_cliente"]);
                        item.cod_ccostos = Convert.ToString(dr["cod_ccostos"]);
                        item.cod_fpago = Convert.ToString(dr["cod_fpago"]);
                        item.observaciones = Convert.ToString(dr["observaciones"]);
                        item.cod_vendedor = Convert.ToString(dr["cod_vendedor"]);
                        item.estado = Convert.ToString(dr["estado"]);
                        item.subtotal = Convert.ToDecimal(dr["subtotal"]);
                        item.iva = Convert.ToDecimal(dr["iva"]);
                        item.total = Convert.ToDecimal(dr["total"]);
                        item.monto_imponible = Convert.ToDecimal(dr["monto_imponible"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_moneda = Convert.ToString(dr["cod_moneda"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "ConsultaProformas.cs", "ListaProformasFactura", e.ToString(), DateTime.Today, "consulta");
                return null;
            }


        }

        //Proformas masivas sp wmspc_proformasWM_cab
        public List<modelowmtproformascab> ListaProformasMasivasE(string usuario, string cod_emp, string tipo, string nro_trans,string estado)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelowmtproformascab> lista = new List<modelowmtproformascab>();
                    string consulta = ("wmspc_proformasWM_cab");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;
                   

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        modelowmtproformascab item = new modelowmtproformascab();

                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.fec_doc = Convert.ToDateTime(dr["fec_doc"]);
                        DateTime fec_doc_str = Convert.ToDateTime(dr["fec_doc"]);
                        item.fec_doc_str = fec_doc_str.ToString("yyyy-MM-dd");
                        item.tipo = Convert.ToString(dr["tipo"]);
                        item.proformas = Convert.ToString(dr["serie_docum"]) + " - " + Convert.ToString(dr["nro_docum"]);
                        item.cod_docum = Convert.ToString(dr["cod_docum"]);
                        item.serie_docum = Convert.ToString(dr["serie_docum"]);
                        item.nro_docum = Convert.ToString(dr["nro_docum"]);
                        item.cod_cliente = Convert.ToString(dr["cod_cliente"]);
                        item.nom_tit = Convert.ToString(dr["nom_tit"]);
                        item.dir_tit = Convert.ToString(dr["dir_tit"]);
                        item.tel_tit = Convert.ToString(dr["tel_tit"]);
                        item.nro_dgi = Convert.ToString(dr["nro_dgi"]);
                        item.nro_dgi2 = Convert.ToString(dr["nro_dgi2"]);
                        item.nro_dgi1 = Convert.ToString(dr["nro_dgi1"]);
                        item.cod_fpago = Convert.ToString(dr["cod_fpago"]);
                        item.nom_fpago = Convert.ToString(dr["nom_fpago"]);
                        item.plazo_libre = Convert.ToString(dr["plazo_libre"]);
                        item.observaciones = Convert.ToString(dr["observaciones"]);
                        item.fec_venc = Convert.ToString(dr["fec_venc"]);
                        item.cod_vendedor = Convert.ToString(dr["cod_vendedor"]);
                        item.nom_vend = Convert.ToString(dr["nom_vend"]);
                        item.estado = Convert.ToString(dr["estado"]);
                        item.subtotal = Convert.ToDecimal(dr["subtotal"]);
                        item.iva = Convert.ToDecimal(dr["iva"]);
                        item.total = Convert.ToDecimal(dr["total"]);
                        item.monto_imponible = Convert.ToDecimal(dr["monto_imponible"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.nom_ciudad = Convert.ToString(dr["nom_ciudad"]);
                        item.vlr_letras = Convert.ToString(dr["vlr_letras"]);
                        item.pagina_edicion = Convert.ToString(dr["pagina_edicion"]);
                        item.nom_edicion = Convert.ToString(dr["nom_edicion"]);
                        item.pagina_elimina = Convert.ToString(dr["pagina_elimina"]);
                        item.nom_elimina = Convert.ToString(dr["nom_elimina"]);
                        item.nom_corto = Convert.ToString(dr["nom_corto"]);
                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaProformasMasivaE", e.ToString(), DateTime.Now, usuario);
                return null;
            }


        }
        //Total de clientes a facturar una proforma

        public List<modeloClientesproforma> TotalProformasAFacturar(string usuario, string cod_emp, string nro_trans)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloClientesproforma> lista = new List<modeloClientesproforma>();
                    string consulta = ("select* from wmt_proformas_tit WHERE nro_trans = @nro_trans and estado= 'A' and cod_emp =@cod_emp");
                    SqlCommand conmand = new SqlCommand(consulta, cn);


                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        modeloClientesproforma item = new modeloClientesproforma();

                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_cliente = Convert.ToString(dr["cod_cliente"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.estado = Convert.ToString(dr["estado"]);
                        item.nro_trans_ndm = Convert.ToString(dr["nro_trans_ndm"]);

                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(usuario, metodo, "TotalProformasAFacturar", e.ToString(), DateTime.Now, cod_emp);
                return null;
            }
        }
        //INSERTRA CLIENTE DE PROFORMA MASIVA
        public string InsertarClientesProforma(modeloClientesproforma detalleFactura)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "INSERT INTO  wmt_proformas_tit (nro_trans, cod_emp, cod_cliente, fecha_mod, estado, cod_suc_cli) VALUES (@nro_trans, @cod_emp,@cod_cliente, @fecha_mod,@estado, @cod_suc_cli)";
                SqlCommand conmand = new SqlCommand(insert, cn);
                
                conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = detalleFactura.nro_trans;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = detalleFactura.cod_emp;
                conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = detalleFactura.cod_cliente;
                conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = detalleFactura.fecha_mod;
                conmand.Parameters.Add("@estado", SqlDbType.VarChar).Value = detalleFactura.estado;
                conmand.Parameters.Add("@cod_suc_cli", SqlDbType.VarChar).Value = detalleFactura.cod_suc_cli;

                int dr = conmand.ExecuteNonQuery();
                cn.Close();
                return "";
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(detalleFactura.cod_emp, metodo, "InsertarClientesProforma", e.ToString(), DateTime.Now, detalleFactura.usuario);
                return "No se pudo completar la acción." + "InsertarClientesProforma." + " Por favor notificar al administrador.";
            }

        }

        //INSERTRA CLIENTE DE PROFORMA MASIVA
        public string EliminarClientesProforma(string cod_emp, string usuario, string nro_trans)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "Update  wmt_proformas_tit set estado ='E'  where nro_trans =@nro_trans and cod_emp =@cod_emp and estado = 'A'";
                SqlCommand conmand = new SqlCommand(insert, cn);

                conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                int dr = conmand.ExecuteNonQuery();
                cn.Close();
                return "";
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "EliminarClientesProforma", e.ToString(), DateTime.Now, usuario);
                return "No se pudo completar la acción." + "EliminarClientesProforma." + " Por favor notificar al administrador.";
            }

        }

        //Trae cliente sucursal activo para facturar proforma
        public modelowmspctitulares ClienteProformasAFacturar(string usuario, string cod_emp, string nro_trans)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    modelowmspctitulares clientes_suc = new modelowmspctitulares();
                    string consulta = ("select TOP 1 cod_cliente,cod_suc_cli,nro_id from wmt_proformas_tit where estado= 'A' and nro_trans =@nro_trans");
                    SqlCommand conmand = new SqlCommand(consulta, cn);


                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {
                       
                        clientes_suc.cod_tit = Convert.ToString(dr["cod_cliente"]); 
                        clientes_suc.cod_sucursal = Convert.ToString(dr["cod_suc_cli"]);
                        clientes_suc.nro_id = Convert.ToString(dr["nro_id"]);
                    }
                    return clientes_suc;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(usuario, metodo, "ClienteProformasAFacturar", e.ToString(), DateTime.Now, cod_emp);
                return null;
            }
        }

        //BUSCAR PROFORMA POR NUMERO sp wmspc_proformasWM_cab cabecera 
        public modelowmtproformascab ProformasMasivasE(string usuario, string cod_emp, string tipo, string nro_trans, string estado)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    modelowmtproformascab item = new modelowmtproformascab();
                    string consulta = ("wmspc_proformasWM_cab");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;


                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        

                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.fec_doc = Convert.ToDateTime(dr["fec_doc"]);
                        DateTime fec_doc_str = Convert.ToDateTime(dr["fec_doc"]);
                        item.fec_doc_str = fec_doc_str.ToString("yyyy-MM-dd");
                        item.tipo = Convert.ToString(dr["tipo"]);
                        item.proformas = Convert.ToString(dr["serie_docum"]) + " - " + Convert.ToString(dr["nro_docum"]);
                        item.cod_docum = Convert.ToString(dr["cod_docum"]);
                        item.serie_docum = Convert.ToString(dr["serie_docum"]);
                        item.nro_docum = Convert.ToString(dr["nro_docum"]);
                        item.cod_cliente = Convert.ToString(dr["cod_cliente"]);
                        item.nom_tit = Convert.ToString(dr["nom_tit"]);
                        item.dir_tit = Convert.ToString(dr["dir_tit"]);
                        item.tel_tit = Convert.ToString(dr["tel_tit"]);
                        item.nro_dgi = Convert.ToString(dr["nro_dgi"]);
                        item.nro_dgi2 = Convert.ToString(dr["nro_dgi2"]);
                        item.nro_dgi1 = Convert.ToString(dr["nro_dgi1"]);
                        item.cod_fpago = Convert.ToString(dr["cod_fpago"]);
                        item.nom_fpago = Convert.ToString(dr["nom_fpago"]);
                        item.plazo_libre = Convert.ToString(dr["plazo_libre"]);
                        item.observaciones = Convert.ToString(dr["observaciones"]);
                        item.fec_venc = Convert.ToString(dr["fec_venc"]);
                        item.cod_vendedor = Convert.ToString(dr["cod_vendedor"]);
                        item.nom_vend = Convert.ToString(dr["nom_vend"]);
                        item.estado = Convert.ToString(dr["estado"]);
                        item.subtotal = Convert.ToDecimal(dr["subtotal"]);
                        item.iva = Convert.ToDecimal(dr["iva"]);
                        item.total = Convert.ToDecimal(dr["total"]);
                        item.monto_imponible = Convert.ToDecimal(dr["monto_imponible"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.nom_ciudad = Convert.ToString(dr["nom_ciudad"]);
                        item.vlr_letras = Convert.ToString(dr["vlr_letras"]);
                        item.pagina_edicion = Convert.ToString(dr["pagina_edicion"]);
                        item.nom_edicion = Convert.ToString(dr["nom_edicion"]);
                        item.pagina_elimina = Convert.ToString(dr["pagina_elimina"]);
                        item.nom_elimina = Convert.ToString(dr["nom_elimina"]);
                        item.nom_corto = Convert.ToString(dr["nom_corto"]);
                       
                    }
                    return item;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ProformasMasivaE", e.ToString(), DateTime.Now, usuario);
                return null;
            }


        }

        //BUSCAR PROFORMA POR NUMERO sp wmspc_proformasWM_cab cabecera 
        public List<modeloproformadetalle> DetalleProformasMasiva(string usuario, string cod_emp, string nro_trans)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloproformadetalle> lista = new List<modeloproformadetalle>();
                    string consulta = ("SELECT * FROM wmt_proformas_det WHERE cod_emp = @cod_emp AND nro_trans = @nro_trans");
                    SqlCommand conmand = new SqlCommand(consulta, cn);


                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
    

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                       modeloproformadetalle item = new modeloproformadetalle();

                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.linea = Convert.ToInt32(dr["linea"]);
                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_articulo = Convert.ToString(dr["cod_articulo"]);
                        item.nom_articulo = Convert.ToString(dr["nom_articulo"]);
                        item.nom_articulo2 = Convert.ToString(dr["nom_articulo2"]);
                        item.cantidad = Convert.ToDecimal(dr["cantidad"]);
                        item.precio_unit = Convert.ToDecimal(dr["precio_unit"]);
                        item.base_imp = Convert.ToDecimal(dr["base_imp"]);
                        item.subtotal = Convert.ToDecimal(dr["subtotal"]);
                        item.tasa_iva = Convert.ToString(dr["tasa_iva"]);
                        item.porc_iva = Convert.ToDecimal(dr["porc_iva"]);
                        item.valor_iva = Convert.ToDecimal(dr["valor_iva"]);
                        item.total = Convert.ToDecimal(dr["total"]);
                        item.porc_descto = Convert.ToDecimal(dr["porc_descto"]);
                        item.valor_descto = Convert.ToDecimal(dr["valor_descto"]);
                        item.cod_concepret= Convert.ToString(dr["cod_concepret"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_cta_vtas = Convert.ToString(dr["cod_cta_vtas"]);
                        item.cod_cta_cos = Convert.ToString(dr["cod_cta_cos"]);
                        item.cod_cta_inve = Convert.ToString(dr["cod_cta_inve"]);
                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaProformasFactura", e.ToString(), DateTime.Now, usuario);
                return null;
            }


        }


    }
}
