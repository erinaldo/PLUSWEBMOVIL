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
    public class ConsultaParComerciales
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        modeloFormato modeloformato = new modeloFormato();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        ValidarParametrizacionFactura conexion_erp = new ValidarParametrizacionFactura();
        string metodo = "ConsultaParComerciales.cs";
        //Formato factura de venta
        public List<modeloFormato> ListaFormatoFacturaVenta(string ArtB__usuario, string ArtB__cod_emp)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {
                    List<modeloFormato> lista = new List<modeloFormato>();

                    string consulta = ("SELECT * FROM wmm_formatos WHERE cod_proceso IN ('RCOMFACT','RCOMFELECT') ORDER BY cod_formato");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloFormato item = new modeloFormato();
                        item.cod_formato = Convert.ToString(dr["cod_formato"]);
                        item.nom_formato = Convert.ToString(dr["nom_formato"]);
                        item.pagina = Convert.ToString(dr["pagina"]);
                        item.cod_proceso = Convert.ToString(dr["cod_proceso"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ListaFormatoFacturaVenta", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }
        //Formato factura de pos
        public List<modeloFormato> ListaFormatoFacturaPOS(string ArtB__usuario, string ArtB__cod_emp)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {
                    List<modeloFormato> lista = new List<modeloFormato>();

                    string consulta = ("SELECT * FROM wmm_formatos WHERE cod_proceso in ('RCOMFACPOS','RCOMFPOSEL') ORDER BY cod_formato");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloFormato item = new modeloFormato();
                        item.cod_formato = Convert.ToString(dr["cod_formato"]);
                        item.nom_formato = Convert.ToString(dr["nom_formato"]);
                        item.pagina = Convert.ToString(dr["pagina"]);
                        item.cod_proceso = Convert.ToString(dr["cod_proceso"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ListaFormatoFacturaPOS", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }
        //Formato pedido
        public List<modeloFormato> ListaFormatoPedido(string ArtB__usuario, string ArtB__cod_emp)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {
                    List<modeloFormato> lista = new List<modeloFormato>();

                    string consulta = ("SELECT * FROM wmm_formatos WHERE cod_proceso='RCOMPEDVTA' ORDER BY cod_formato");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloFormato item = new modeloFormato();
                        item.cod_formato = Convert.ToString(dr["cod_formato"]);
                        item.nom_formato = Convert.ToString(dr["nom_formato"]);
                        item.pagina = Convert.ToString(dr["pagina"]);
                        item.cod_proceso = Convert.ToString(dr["cod_proceso"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        lista.Add(item);
                    }

                    return lista;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ListaFormatoPedido", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }

        //Formato proforma
        public List<modeloFormato> ListaFormatoProforma(string ArtB__usuario, string ArtB__cod_emp)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {
                    List<modeloFormato> lista = new List<modeloFormato>();

                    string consulta = ("SELECT * FROM wmm_formatos WHERE cod_proceso='RCOMPRVTA' ORDER BY cod_formato");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloFormato item = new modeloFormato();
                        item.cod_formato = Convert.ToString(dr["cod_formato"]);
                        item.nom_formato = Convert.ToString(dr["nom_formato"]);
                        item.pagina = Convert.ToString(dr["pagina"]);
                        item.cod_proceso = Convert.ToString(dr["cod_proceso"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        lista.Add(item);
                    }

                    return lista;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ListaFormatoProforma", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }

        //Formato remision
        public List<modeloFormato> ListaFormatoRemision(string ArtB__usuario, string ArtB__cod_emp)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {
                    List<modeloFormato> lista = new List<modeloFormato>();

                    string consulta = ("SELECT * FROM wmm_formatos WHERE cod_proceso='RCOMGRVTA' ORDER BY cod_formato");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloFormato item = new modeloFormato();
                        item.cod_formato = Convert.ToString(dr["cod_formato"]);
                        item.nom_formato = Convert.ToString(dr["nom_formato"]);
                        item.pagina = Convert.ToString(dr["pagina"]);
                        item.cod_proceso = Convert.ToString(dr["cod_proceso"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        lista.Add(item);
                    }

                    return lista;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ListaFormatoRemision", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }

        //Formato nota credito
        public List<modeloFormato> ListaFormatoNotaCredito(string ArtB__usuario, string ArtB__cod_emp)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {
                    List<modeloFormato> lista = new List<modeloFormato>();

                    string consulta = ("SELECT * FROM wmm_formatos WHERE cod_proceso in ('RCOMNCRED','RCOMNCREDM','RCOMNCELEC') ORDER BY cod_formato");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloFormato item = new modeloFormato();
                        item.cod_formato = Convert.ToString(dr["cod_formato"]);
                        item.nom_formato = Convert.ToString(dr["nom_formato"]);
                        item.pagina = Convert.ToString(dr["pagina"]);
                        item.cod_proceso = Convert.ToString(dr["cod_proceso"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        lista.Add(item);
                    }

                    return lista;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ListaFormatoNotaCredito", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }

        //Formato nota debito
        public List<modeloFormato> ListaFormatoNotaDebito(string ArtB__usuario, string ArtB__cod_emp)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {
                    List<modeloFormato> lista = new List<modeloFormato>();

                    string consulta = ("SELECT * FROM wmm_formatos WHERE cod_proceso in ('RCOMNDEB') ORDER BY cod_formato");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloFormato item = new modeloFormato();
                        item.cod_formato = Convert.ToString(dr["cod_formato"]);
                        item.nom_formato = Convert.ToString(dr["nom_formato"]);
                        item.pagina = Convert.ToString(dr["pagina"]);
                        item.cod_proceso = Convert.ToString(dr["cod_proceso"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        lista.Add(item);
                    }

                    return lista;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ListaFormatoNotaDebito", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }

        //Formato nota interfaz contable
        public List<modeloFormato> ListaFormatoInterfazContable(string ArtB__usuario, string ArtB__cod_emp)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloFormato> lista = new List<modeloFormato>();
                    string consulta = ("SELECT * FROM wmm_formatos WHERE cod_proceso in ('RCOMASIINT') ORDER BY cod_formato");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {
                        modeloFormato item = new modeloFormato();
                        item.cod_formato = Convert.ToString(dr["cod_formato"]);
                        item.nom_formato = Convert.ToString(dr["nom_formato"]);
                        item.pagina = Convert.ToString(dr["pagina"]);
                        item.cod_proceso = Convert.ToString(dr["cod_proceso"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ListaFormatoInterfazContable", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }
        //buscar parametros comerciales por empresa
        public modeloParametrosComerciales FormatosImpresionPC(string ArtB__usuario, string ArtB__cod_emp)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    modeloParametrosComerciales item = new modeloParametrosComerciales();
                    string consulta = ("SELECT cod_emp, impresion_factura, impresion_proforma, impresion_pedcom, impresion_remision, impresion_nc, impresion_ndeb, impresion_interfaz, impresion_pos, meses_historia, maneja_recurso, RTRIM(info_trib1) info_trib1, RTRIM(info_trib2) info_trib2, RTRIM(info_trib3) info_trib3, RTRIM(info_trib4) info_trib4, RTRIM(info_trib5) info_trib5, RTRIM(letra_cambio1) letra_cambio1, RTRIM(letra_cambio2) letra_cambio2, RTRIM(letra_cambio3) letra_cambio3, RTRIM(cod_formula) cod_formula, RTRIM(cod_bodega) cod_bodega, RTRIM(cod_estado) cod_estado, RTRIM(cod_estado_rem) cod_estado_rem, stock_rem FROM wmm_param_comercial WHERE cod_emp = @cod_emp");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = ArtB__cod_emp;
                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.impresion_factura = Convert.ToString(dr["impresion_factura"]);
                        item.impresion_proforma = Convert.ToString(dr["impresion_proforma"]);
                        item.impresion_pedcom = Convert.ToString(dr["impresion_pedcom"]);
                        item.impresion_remision = Convert.ToString(dr["impresion_remision"]);
                        item.impresion_nc = Convert.ToString(dr["impresion_nc"]);
                        item.impresion_ndeb = Convert.ToString(dr["impresion_ndeb"]);
                        item.impresion_interfaz = Convert.ToString(dr["impresion_interfaz"]);
                        item.impresion_pos = Convert.ToString(dr["impresion_pos"]);
                        item.meses_historia = Convert.ToInt16(dr["meses_historia"]);
                        item.maneja_recurso = Convert.ToString(dr["maneja_recurso"]);
                        item.info_trib1 = Convert.ToString(dr["info_trib1"]);
                        item.info_trib2 = Convert.ToString(dr["info_trib2"]);
                        item.info_trib3 = Convert.ToString(dr["info_trib3"]);
                        item.info_trib4 = Convert.ToString(dr["info_trib4"]);
                        item.info_trib5 = Convert.ToString(dr["info_trib5"]);
                        item.letra_cambio1 = Convert.ToString(dr["letra_cambio1"]);
                        item.letra_cambio2 = Convert.ToString(dr["letra_cambio2"]);
                        item.letra_cambio3 = Convert.ToString(dr["letra_cambio3"]);
                        item.cod_formula = Convert.ToString(dr["cod_formula"]);
                        item.cod_bodega = Convert.ToString(dr["cod_bodega"]);
                        item.cod_estado = Convert.ToString(dr["cod_estado"]);
                        item.cod_estado_rem = Convert.ToString(dr["cod_estado_rem"]);
                        item.stock_rem = Convert.ToString(dr["stock_rem"]);

                    }
                    return item;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "FormatosImpresionPC", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }

        //Buscar datos de facturacion electronica
        public List<modeloParFacElec> ListaParametrosFacturacion(string ArtB__usuario, string ArtB__cod_emp)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloParFacElec> lista = new List<modeloParFacElec>();
                    string consulta = ("SELECT * FROM wmv_param_factelec WHERE cod_emp = @cod_emp AND estado<>'P' ORDER BY linea DESC");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = ArtB__cod_emp;
                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {
                        modeloParFacElec item = new modeloParFacElec();
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.linea = Convert.ToString(dr["linea"]);
                        item.tipo_contrato = Convert.ToString(dr["tipo_contrato"]);
                        item.tipo_documento = Convert.ToString(dr["tipo_documento"]);
                        item.registro = Convert.ToString(dr["registro"]);
                        item.detalle = Convert.ToString(dr["detalle"]);
                        item.tipo_con = Convert.ToString(dr["tipo_con"]);
                        item.tipo_doc = Convert.ToString(dr["tipo_doc"]);
                        item.cantidad = Convert.ToString(dr["cantidad"]);
                        item.nro_docum_ini = Convert.ToString(dr["nro_docum_ini"]);
                        item.nro_docum_fin = Convert.ToString(dr["nro_docum_fin"]);
                        item.fecha_ini = Convert.ToString(dr["fecha_ini"]);
                        item.fecha_fin = Convert.ToString(dr["fecha_fin"]);
                        item.estado = Convert.ToString(dr["estado"]);
                        item.tolerancia_num = Convert.ToString(dr["tolerancia_num"]);
                        item.tolerancia_dias = Convert.ToString(dr["tolerancia_dias"]);
                        item.valor = Convert.ToString(dr["valor"]);
                        item.tolerancia = Convert.ToString(dr["tolerancia"]);
                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ListaParametrosFacturacion", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }

        //Actualizar formatos de impresion
        public string ActualizarFormatosImpresion(modeloParametrosComerciales modelo)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {

                    string consulta = ("UPDATE wmm_param_comercial SET impresion_factura = @impresion_factura, impresion_pos = @impresion_pos, impresion_pedcom = @impresion_pedcom, impresion_proforma = @impresion_proforma, impresion_remision = @impresion_remision, impresion_nc = @impresion_nc, impresion_ndeb = @impresion_ndeb, impresion_interfaz = @impresion_interfaz, maneja_recurso = @maneja_recurso, meses_historia = @meses_historia WHERE cod_emp = @cod_emp");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = modelo.cod_emp;
                    conmand.Parameters.Add("@impresion_factura", SqlDbType.VarChar).Value = modelo.impresion_factura;
                    conmand.Parameters.Add("@impresion_pos", SqlDbType.VarChar).Value = modelo.impresion_pos;
                    conmand.Parameters.Add("@impresion_pedcom", SqlDbType.VarChar).Value = modelo.impresion_pedcom;
                    conmand.Parameters.Add("@impresion_proforma", SqlDbType.VarChar).Value = modelo.impresion_proforma;
                    conmand.Parameters.Add("@impresion_remision", SqlDbType.VarChar).Value = modelo.impresion_remision;
                    conmand.Parameters.Add("@impresion_nc", SqlDbType.VarChar).Value = modelo.impresion_nc;
                    conmand.Parameters.Add("@impresion_ndeb", SqlDbType.VarChar).Value = modelo.impresion_ndeb;
                    conmand.Parameters.Add("@impresion_interfaz", SqlDbType.VarChar).Value = modelo.impresion_interfaz;
                    conmand.Parameters.Add("@maneja_recurso", SqlDbType.VarChar).Value = modelo.maneja_recurso;
                    conmand.Parameters.Add("@meses_historia", SqlDbType.VarChar).Value = modelo.meses_historia;

                    int dr = conmand.ExecuteNonQuery();

                    return "";
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(modelo.cod_emp, metodo, "ActualizarFormatosImpresion", e.ToString(), DateTime.Now, modelo.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarFormatosImpresion." + " Por favor notificar al administrador.";
            }
        }

        //Acualizar contenido factura-informacon ltributaria
        public string ActualizarContenidoFactura(modeloParametrosComerciales modelo)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {

                    string consulta = ("UPDATE wmm_param_comercial SET info_trib1 = @info_trib1, info_trib2 = @info_trib2, info_trib3 = @info_trib3, info_trib4 = @info_trib4, info_trib5 = @info_trib5, letra_cambio1 = @letra_cambio1, letra_cambio2 = @letra_cambio2, letra_cambio3 = @letra_cambio3  WHERE cod_emp = @cod_emp");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = modelo.cod_emp;
                    conmand.Parameters.Add("@info_trib1", SqlDbType.VarChar).Value = modelo.info_trib1;
                    conmand.Parameters.Add("@info_trib2", SqlDbType.VarChar).Value = modelo.info_trib2;
                    conmand.Parameters.Add("@info_trib3", SqlDbType.VarChar).Value = modelo.info_trib3;
                    conmand.Parameters.Add("@info_trib4", SqlDbType.VarChar).Value = modelo.info_trib4;
                    conmand.Parameters.Add("@info_trib5", SqlDbType.VarChar).Value = modelo.info_trib5;
                    conmand.Parameters.Add("@letra_cambio1", SqlDbType.VarChar).Value = modelo.letra_cambio1;
                    conmand.Parameters.Add("@letra_cambio2", SqlDbType.VarChar).Value = modelo.letra_cambio2;
                    conmand.Parameters.Add("@letra_cambio3", SqlDbType.VarChar).Value = modelo.letra_cambio3;
                    int dr = conmand.ExecuteNonQuery();
                    return "";
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(modelo.cod_emp, metodo, "ActualizarContenidoFactura", e.ToString(), DateTime.Now, modelo.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarContenidoFactura." + " Por favor notificar al administrador.";
            }
        }

        //INSERTAR DATOS CONTRATOS FACTURAS
        public string InsertarContratoFactura(modeloParFacElec modelo)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {

                    string consulta = ("INSERT INTO wmm_param_factelec (detalle, tipo_contrato, tipo_documento, cod_emp, linea, cantidad, nro_docum_ini, nro_docum_fin, diai, mesi, anioi, diaf, mesf, aniof, estado, tolerancia_num, tolerancia_dias, usuario_mod, fecha_mod, diar, mesr, anior) VALUES (@detalle,@tipo_contrato,  @tipo_documento, @cod_emp, @linea, @cantidad, @nro_docum_ini, @nro_docum_fin, @diai, @mesi, @anioi, @diaf, @mesf, @aniof, @estado, @tolerancia_num, @tolerancia_dias, @usuario_mod, @fecha_mod, @diar, @mesr, @anior)");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = modelo.cod_emp;
                    conmand.Parameters.Add("@detalle", SqlDbType.VarChar).Value = modelo.detalle;
                    conmand.Parameters.Add("@tipo_contrato", SqlDbType.VarChar).Value = modelo.tipo_contrato;
                    conmand.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = modelo.tipo_documento;
                    conmand.Parameters.Add("@linea", SqlDbType.VarChar).Value = modelo.linea;
                    conmand.Parameters.Add("@cantidad", SqlDbType.VarChar).Value = modelo.cantidad;
                    conmand.Parameters.Add("@nro_docum_ini", SqlDbType.VarChar).Value = modelo.nro_docum_ini;
                    conmand.Parameters.Add("@nro_docum_fin", SqlDbType.VarChar).Value = modelo.nro_docum_fin;
                    conmand.Parameters.Add("@diai", SqlDbType.VarChar).Value = modelo.fec_ini1;
                    conmand.Parameters.Add("@mesi", SqlDbType.VarChar).Value = modelo.fec_ini2;
                    conmand.Parameters.Add("@anioi", SqlDbType.VarChar).Value = modelo.fec_ini3;
                    conmand.Parameters.Add("@diaf", SqlDbType.VarChar).Value = modelo.fec_fin1;
                    conmand.Parameters.Add("@mesf", SqlDbType.VarChar).Value = modelo.fec_fin2;
                    conmand.Parameters.Add("@aniof", SqlDbType.VarChar).Value = modelo.fec_fin3;
                    conmand.Parameters.Add("@estado", SqlDbType.VarChar).Value = modelo.estado;
                    conmand.Parameters.Add("@tolerancia_num", SqlDbType.VarChar).Value = modelo.tolerancia_num;
                    conmand.Parameters.Add("@tolerancia_dias", SqlDbType.VarChar).Value = modelo.tolerancia_dias;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = modelo.usuario_mod;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = modelo.fecha_mod;
                    conmand.Parameters.Add("@diar", SqlDbType.VarChar).Value = modelo.fec_r1;
                    conmand.Parameters.Add("@mesr", SqlDbType.VarChar).Value = modelo.fec_r2;
                    conmand.Parameters.Add("@anior", SqlDbType.VarChar).Value = modelo.fec_r3;
                    int dr = conmand.ExecuteNonQuery();
                    return "";
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(modelo.cod_emp, metodo, "InsertarContratoFactura", e.ToString(), DateTime.Now, modelo.usuario_mod);
                return "No se pudo completar la acción." + "InsertarContratoFactura." + " Por favor notificar al administrador.";
            }
        }
        public string LineaDatosContratosFacturas(string cod_emp, string usuario_mod)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string linea = "";

                    string consulta = ("SELECT * FROM wmv_param_factelec_lin WHERE cod_emp = @cod_emp");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        linea = Convert.ToString(dr["linea"]);
                    }
                    return linea;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "LineaDatosContratosFacturas", e.ToString(), DateTime.Now, usuario_mod);
                return null;
            }
        }

        //Eliminar linea de parametro de facturas
        public string EliminarLineaDatosContratosFacturas(string cod_emp, string usuario_mod, string linea)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {

                    string consulta = ("DELETE FROM wmm_param_factelec WHERE cod_emp = @cod_emp AND linea =@linea");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@linea", SqlDbType.VarChar).Value = linea;

                    int dr = conmand.ExecuteNonQuery();
                    return "";
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "EliminarLineaDatosContratosFacturas", e.ToString(), DateTime.Now, usuario_mod);
                return "No se pudo completar la acción." + "EliminarLineaDatosContratosFacturas." + " Por favor notificar al administrador."; ;
            }
        }

        //Buscar envio automatico de correos de contratos
        public string EnvioCorreosContratosFacturas(string cod_emp, string usuario_mod)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string correo = "";
                    string consulta = ("SELECT cod_mail FROM wmm_correos WHERE cod_emp = @cod_emp AND cod_proceso = 'RCOMPARAM' AND automatico='S' AND cod_mail = 'FECONTRATO'");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        correo = Convert.ToString(dr["cod_mail"]);
                    }
                    return correo;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "EnvioCorreosContratosFacturas", e.ToString(), DateTime.Now, usuario_mod);
                return null;
            }
        }

        //Consulta mensajes de parametros de contrado de fe
        public string MensajesContratosFacturas(string cod_emp, string usuario_mod)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string correo = "";
                    string consulta = ("wmspc_param_factelec");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario_mod;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        correo = Convert.ToString(dr["mensaje"]);
                    }
                    return correo;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "MensajesContratosFacturas", e.ToString(), DateTime.Now, usuario_mod);
                return null;
            }
        }


        //mensaje control de usuaris
        public string ControlUsuarioContratosFacturas(string cod_emp, string usuario_mod)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string correo = "";
                    string consulta = ("SELECT cod_emp FROM wmm_param_factelec_job WHERE cod_emp = @cod_emp");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        correo = Convert.ToString(dr["cod_emp"]);
                    }
                    return correo;
                }
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ControlUsuarioContratosFacturas", e.ToString(), DateTime.Now, usuario_mod);
                return null;
            }
        }
    }
}
