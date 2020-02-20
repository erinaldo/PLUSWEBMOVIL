using System;
using CapaProceso.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace CapaDatos.Sql
{
    public class FacturaDetalle
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "FacturaDetalle.cs";
        //RECUPERAR CON NRO_TRANS Y LINEA
        public SqlDataReader ConsultaDetalleFacturaLinea(string nro_trans, string linea)
        {
            try
            {
                cn = conexion.genearConexion();
                string consulta = "SELECT * FROM wmt_facturas_det WHERE nro_trans =@nro_trans and linea =@linea";
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("nro_trans", SqlDbType.VarChar).Value = nro_trans;
                conmand.Parameters.Add("linea", SqlDbType.VarChar).Value = linea;
                SqlDataReader dr = conmand.ExecuteReader();

                return dr;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ConsultaDetalleFacturaLinea", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }
        //ENCONTRAR ELULTIMO NUMERO DE LINE AINSERTADO
        public string UltimaLinea(string nro_trans, string cod_emp, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {

                    string linea =null;
                    string insert = "SELECT TOP 1 linea FROM wmt_facturas_det WHERE nro_trans =@nro_trans ORDER BY linea DESC";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;

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

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "UltimaLinea", e.ToString(), DateTime.Now, usuario);
                return "No se pudo completar la acción." + "UltimaLinea." + " Por favor notificar al administrador.";
            }

        }

        public string EliminarDetalle(string nro_trans, string linea, string cod_emp, string usuario)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = " DELETE FROM wmt_facturas_det WHERE nro_trans =@nro_trans and linea=@linea";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                conmand.Parameters.Add("@linea", SqlDbType.VarChar).Value = linea;
              
                int dr = conmand.ExecuteNonQuery();
                cn.Close();
                return "Factura eliminada correctamente";
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "EliminarDetalle", e.ToString(), DateTime.Now, usuario);
                return "No se pudo completar la acción." + "EliminarDetalle." + " Por favor notificar al administrador.";
            }

        }
        public string InsertarDetalle(ModeloDetalleFactura detalleFactura)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "INSERT INTO  wmt_facturas_det (nom_articulo, nom_articulo2, cantidad, precio_unit, base_imp, porc_iva, nro_trans, linea, cod_emp, cod_articulo, cod_concepret, porc_descto, valor_descto, cod_cta_vtas, cod_cta_cos, cod_cta_inve, usuario_mod, nro_audit, fecha_mod, tasa_iva, cod_ccostos) VALUES (@nom_articulo, @nom_articulo2, @cantidad, @precio_unit, @base_imp, @porc_iva, @nro_trans, @linea, @cod_emp, @cod_articulo, @cod_concepret, @porc_descto, @valor_descto, @cod_cta_vtas, @cod_cta_cos, @cod_cta_inve, @usuario_mod, @nro_audit, @fecha_mod, @tasa_iva, @cod_ccostos)";
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
                cn.Close();
                return "Factura salvada correctamente";
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(detalleFactura.cod_emp, metodo, "InsertarDetalle", e.ToString(), DateTime.Now, detalleFactura.usuario_mod);
                return "No se pudo completar la acción." + "InsertarDetalle." + " Por favor notificar al administrador.";
            }

        }

        //insertra detalle sin lista InsertarDetalleNCSL
        public string InsertarDetalleNCSL(string cod_doca, string nro_doca, string serie_doca,string nom_articulo, string nom_articulo2, decimal cantidad, decimal precio_unit, decimal base_imp, decimal porc_iva, string nro_trans, int linea, string cod_emp, string cod_articulo, string cod_concepret, decimal porc_descto, decimal valor_descto, string cod_cta_vtas, string cod_cta_cos, string cod_cta_inve, string usuario_mod, string nro_audit, DateTime fecha_mod, string tasa_iva, string cod_ccostos)
        {
            try
            {
                cn = conexion.genearConexion();
                string insert = "INSERT INTO  wmt_facturas_det (cod_doca, nro_doca, serie_doca, nom_articulo, nom_articulo2, cantidad, precio_unit, base_imp, porc_iva, nro_trans, linea, cod_emp, cod_articulo, cod_concepret, porc_descto, valor_descto, cod_cta_vtas, cod_cta_cos, cod_cta_inve, usuario_mod, nro_audit, fecha_mod, tasa_iva, cod_ccostos) VALUES (@cod_doca, @nro_doca, @serie_doca,@nom_articulo, @nom_articulo2, @cantidad, @precio_unit, @base_imp, @porc_iva, @nro_trans, @linea, @cod_emp, @cod_articulo, @cod_concepret, @porc_descto, @valor_descto, @cod_cta_vtas, @cod_cta_cos, @cod_cta_inve, @usuario_mod, @nro_audit, @fecha_mod, @tasa_iva, @cod_ccostos)";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@cod_doca", SqlDbType.VarChar).Value = cod_doca;
                conmand.Parameters.Add("@nro_doca", SqlDbType.VarChar).Value = nro_doca;
                conmand.Parameters.Add("@serie_doca", SqlDbType.VarChar).Value = serie_doca;
                conmand.Parameters.Add("@nom_articulo", SqlDbType.VarChar).Value = nom_articulo;
                conmand.Parameters.Add("@nom_articulo2", SqlDbType.VarChar).Value = nom_articulo2;
                conmand.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = cantidad;
                conmand.Parameters.Add("@precio_unit", SqlDbType.Decimal).Value = precio_unit;
                conmand.Parameters.Add("@base_imp", SqlDbType.Decimal).Value = base_imp;
                conmand.Parameters.Add("@porc_iva", SqlDbType.Decimal).Value = porc_iva;
                conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                conmand.Parameters.Add("@linea", SqlDbType.Int).Value = linea;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                conmand.Parameters.Add("@cod_articulo", SqlDbType.VarChar).Value = cod_articulo;
                conmand.Parameters.Add("@cod_concepret", SqlDbType.VarChar).Value = cod_concepret;
                conmand.Parameters.Add("@porc_descto", SqlDbType.Decimal).Value = porc_descto;
                conmand.Parameters.Add("@valor_descto", SqlDbType.Decimal).Value = valor_descto;
                conmand.Parameters.Add("@cod_cta_vtas", SqlDbType.VarChar).Value = cod_cta_vtas;
                conmand.Parameters.Add("@cod_cta_cos", SqlDbType.VarChar).Value = cod_cta_cos;
                conmand.Parameters.Add("@cod_cta_inve", SqlDbType.VarChar).Value = cod_cta_inve;
                conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = usuario_mod;
                conmand.Parameters.Add("@nro_audit", SqlDbType.VarChar).Value = nro_audit;
                conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = fecha_mod;
                conmand.Parameters.Add("@tasa_iva", SqlDbType.VarChar).Value = tasa_iva;
                conmand.Parameters.Add("@cod_ccostos", SqlDbType.VarChar).Value = cod_ccostos;
                int dr = conmand.ExecuteNonQuery();
                cn.Close();
                return "Factura salvada correctamente";
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "InsertarDetalleNCSL", e.ToString(), DateTime.Now, usuario_mod);
                return "No se pudo completar la acción." + "InsertarDetalleNCSL." + " Por favor notificar al administrador.";
            }

        }

        //insertra detalle sin lista
        public string InsertarDetalleSL(string nom_articulo, string nom_articulo2,decimal cantidad, decimal precio_unit, decimal base_imp, decimal porc_iva, string nro_trans, int linea, string cod_emp, string cod_articulo,string cod_concepret,decimal porc_descto, decimal valor_descto, string cod_cta_vtas,string  cod_cta_cos,string  cod_cta_inve,string usuario_mod,string nro_audit,DateTime fecha_mod,string tasa_iva,string cod_ccostos)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "INSERT INTO  wmt_facturas_det (nom_articulo, nom_articulo2, cantidad, precio_unit, base_imp, porc_iva, nro_trans, linea, cod_emp, cod_articulo, cod_concepret, porc_descto, valor_descto, cod_cta_vtas, cod_cta_cos, cod_cta_inve, usuario_mod, nro_audit, fecha_mod, tasa_iva, cod_ccostos) VALUES (@nom_articulo, @nom_articulo2, @cantidad, @precio_unit, @base_imp, @porc_iva, @nro_trans, @linea, @cod_emp, @cod_articulo, @cod_concepret, @porc_descto, @valor_descto, @cod_cta_vtas, @cod_cta_cos, @cod_cta_inve, @usuario_mod, @nro_audit, @fecha_mod, @tasa_iva, @cod_ccostos)";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@nom_articulo", SqlDbType.VarChar).Value = nom_articulo;
                conmand.Parameters.Add("@nom_articulo2", SqlDbType.VarChar).Value = nom_articulo2;
                conmand.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = cantidad;
                conmand.Parameters.Add("@precio_unit", SqlDbType.Decimal).Value = precio_unit;
                conmand.Parameters.Add("@base_imp", SqlDbType.Decimal).Value = base_imp;
                conmand.Parameters.Add("@porc_iva", SqlDbType.Decimal).Value = porc_iva;
                conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                conmand.Parameters.Add("@linea", SqlDbType.Int).Value = linea;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                conmand.Parameters.Add("@cod_articulo", SqlDbType.VarChar).Value = cod_articulo;
                conmand.Parameters.Add("@cod_concepret", SqlDbType.VarChar).Value = cod_concepret;
                conmand.Parameters.Add("@porc_descto", SqlDbType.Decimal).Value = porc_descto;
                conmand.Parameters.Add("@valor_descto", SqlDbType.Decimal).Value = valor_descto;
                conmand.Parameters.Add("@cod_cta_vtas", SqlDbType.VarChar).Value = cod_cta_vtas;
                conmand.Parameters.Add("@cod_cta_cos", SqlDbType.VarChar).Value = cod_cta_cos;
                conmand.Parameters.Add("@cod_cta_inve", SqlDbType.VarChar).Value = cod_cta_inve;
                conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = usuario_mod;
                conmand.Parameters.Add("@nro_audit", SqlDbType.VarChar).Value = nro_audit;
                conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = fecha_mod;
                conmand.Parameters.Add("@tasa_iva", SqlDbType.VarChar).Value = tasa_iva;
                conmand.Parameters.Add("@cod_ccostos", SqlDbType.VarChar).Value = cod_ccostos;
                int dr = conmand.ExecuteNonQuery();
                cn.Close();
                return "Factura salvada correctamente";
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "InsertarDetalle", e.ToString(), DateTime.Now, usuario_mod);
                return "No se pudo completar la acción." + "InsertarDetalle." + " Por favor notificar al administrador.";
            }

        }

        //ACTUALIZAR DETALLE NOTA CREDITO SINLISTA
        public string ActualizarDetalleNCSL(string nom_articulo2, decimal cantidad, decimal precio_unit, string nro_trans, int linea, string cod_emp, decimal porc_descto, string usuario_mod, string cod_ccostos)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "UPDATE wmt_facturas_det  SET nom_articulo2 = @nom_articulo2, cantidad = @cantidad, precio_unit = @precio_unit,porc_descto = @porc_descto, cod_ccostos = @cod_ccostos WHERE nro_trans = @nro_trans and linea = @linea";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@nom_articulo2", SqlDbType.VarChar).Value = nom_articulo2;
                conmand.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = cantidad;
                conmand.Parameters.Add("@precio_unit", SqlDbType.Decimal).Value = precio_unit;
                conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                conmand.Parameters.Add("@linea", SqlDbType.Int).Value = linea;
                conmand.Parameters.Add("@porc_descto", SqlDbType.Decimal).Value = porc_descto;
                conmand.Parameters.Add("@cod_ccostos", SqlDbType.VarChar).Value = cod_ccostos;
                int dr = conmand.ExecuteNonQuery();
                cn.Close();
                return "Factura salvada correctamente";
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ActualizarDetalleSL", e.ToString(), DateTime.Now, usuario_mod);
                return "No se pudo completar la acción." + "ActualizarDetalleSL." + " Por favor notificar al administrador.";
            }

        }

        //ACTUALIZAR DETALLE SIN LISTAS
        public string ActualizarDetalleSL( string nom_articulo2, decimal cantidad, decimal precio_unit,  string nro_trans, int linea, string cod_emp, decimal porc_descto,  string usuario_mod, string cod_ccostos)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "UPDATE wmt_facturas_det  SET nom_articulo2 = @nom_articulo2, cantidad = @cantidad, precio_unit = @precio_unit,porc_descto = @porc_descto, cod_ccostos = @cod_ccostos WHERE nro_trans = @nro_trans and linea = @linea";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@nom_articulo2", SqlDbType.VarChar).Value = nom_articulo2;
                conmand.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = cantidad;
                conmand.Parameters.Add("@precio_unit", SqlDbType.Decimal).Value = precio_unit;
                conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                conmand.Parameters.Add("@linea", SqlDbType.Int).Value = linea;
                conmand.Parameters.Add("@porc_descto", SqlDbType.Decimal).Value = porc_descto;
                conmand.Parameters.Add("@cod_ccostos", SqlDbType.VarChar).Value = cod_ccostos;
                int dr = conmand.ExecuteNonQuery();
                cn.Close();
                return "Factura salvada correctamente";
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ActualizarDetalleSL", e.ToString(), DateTime.Now, usuario_mod);
                return "No se pudo completar la acción." + "ActualizarDetalleSL." + " Por favor notificar al administrador.";
            }

        }
        /*Insertar detalle de NOTA DE CREDITO FINANCIERA*/
        public string InsertarDetalleNCFinanciera(ModeloDetalleFactura detalleFactura)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "INSERT INTO  wmt_facturas_det (cod_doca, nro_doca, serie_doca, nom_articulo, nom_articulo2, cantidad, precio_unit, base_imp, porc_iva, nro_trans, linea, cod_emp, cod_articulo, cod_concepret, porc_descto, valor_descto, cod_cta_vtas, cod_cta_cos, cod_cta_inve, usuario_mod, nro_audit, fecha_mod, tasa_iva, cod_ccostos) VALUES (@cod_doca, @nro_doca, @serie_doca,@nom_articulo, @nom_articulo2, @cantidad, @precio_unit, @base_imp, @porc_iva, @nro_trans, @linea, @cod_emp, @cod_articulo, @cod_concepret, @porc_descto, @valor_descto, @cod_cta_vtas, @cod_cta_cos, @cod_cta_inve, @usuario_mod, @nro_audit, @fecha_mod, @tasa_iva, @cod_ccostos)";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@cod_doca", SqlDbType.VarChar).Value = detalleFactura.cod_doca;
                conmand.Parameters.Add("@nro_doca", SqlDbType.VarChar).Value = detalleFactura.nro_doca;
                conmand.Parameters.Add("@serie_doca", SqlDbType.VarChar).Value = detalleFactura.serie_doca;
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
                cn.Close();
                return "Factura salvada correctamente";
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(detalleFactura.cod_emp, metodo, "InsertarDetalleNCFinanciera", e.ToString(), DateTime.Today, detalleFactura.usuario_mod);
                return "No se pudo completar la acción." + "InsertarDetalleNCFinanciera." + " Por favor notificar al administrador.";
            }
        }
        public SqlDataReader ConsultaDetalleFactura(string nro_trans)
        {
            try
            {
                cn = conexion.genearConexion();
                string consulta = "SELECT * FROM wmt_facturas_det WHERE nro_trans =@nro_trans ORDER BY linea ASC";
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("nro_trans", SqlDbType.VarChar).Value = nro_trans;
                SqlDataReader dr = conmand.ExecuteReader();

                return dr;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ConsultaDetalleFactura", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }
        //Consulta detalle Factura para NC por devolucion 
        public SqlDataReader ConsultaDetalleFacNCDev(string nro_trans, string articulo)
        {
            try
            {
                cn = conexion.genearConexion();
                string consulta = "SELECT * FROM wmt_facturas_det WHERE nro_trans =@nro_trans AND  cod_articulo like @articulo or nro_trans =@nro_trans AND nom_articulo like @articulo";
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("nro_trans", SqlDbType.VarChar).Value = nro_trans;
                conmand.Parameters.Add("articulo", SqlDbType.VarChar).Value = articulo;

                SqlDataReader dr = conmand.ExecuteReader();

                return dr;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "ConsultaDetalleFacNCDev", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

        //Consulta detalle global de todas las notas de credito disponibles y saber el dato exacto de las entregadas 
        public SqlDataReader ConsultaDetCantNCDev(string cod_emp, string nro_doca, string serie_doca, string cod_articulo)
        {
            try
            {
                cn = conexion.genearConexion();
                string consulta = "SELECT Sum(wmt_facturas_det.cantidad) AS cantidad,wmt_facturas_det.cod_articulo,wmt_facturas_det.serie_doca,wmt_facturas_det.nro_doca,wmt_facturas_det.cod_emp FROM wmt_facturas_det INNER JOIN wmt_facturas_cab ON wmt_facturas_cab.nro_trans = wmt_facturas_det.nro_trans WHERE wmt_facturas_det.cod_emp = @cod_emp AND wmt_facturas_det.nro_doca = @nro_doca AND wmt_facturas_det.serie_doca = @serie_doca AND wmt_facturas_det.cod_articulo = @cod_articulo AND wmt_facturas_cab.tipo IN ('NCVE' ,'NCV', 'NCME', 'NCM') AND wmt_facturas_cab.estado  IN('F' ,'C')  GROUP BY wmt_facturas_det.cod_emp,wmt_facturas_det.cod_doca,wmt_facturas_det.nro_doca,wmt_facturas_det.serie_doca,wmt_facturas_det.cod_articulo";
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
                conmand.Parameters.Add("nro_doca", SqlDbType.VarChar).Value = nro_doca;
                conmand.Parameters.Add("serie_doca", SqlDbType.VarChar).Value = serie_doca;
                conmand.Parameters.Add("cod_articulo", SqlDbType.VarChar).Value = cod_articulo;

                SqlDataReader dr = conmand.ExecuteReader();

                return dr;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaDetCantNCDev", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
    }
}
