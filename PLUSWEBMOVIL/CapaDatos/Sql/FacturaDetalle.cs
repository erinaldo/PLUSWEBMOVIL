﻿using System;
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

                return e.ToString();
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

                return e.ToString();
            }

        }
        public SqlDataReader ConsultaDetalleFactura(string nro_trans)
        {
            cn = conexion.genearConexion();
            string consulta = "SELECT * FROM wmt_facturas_det WHERE nro_trans =@nro_trans ORDER BY linea ASC";
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.Parameters.Add("nro_trans", SqlDbType.VarChar).Value = nro_trans;



            SqlDataReader dr = conmand.ExecuteReader();

            return dr;
        }
        //Consulta detalle Factura para NC por devolucion 
        public SqlDataReader ConsultaDetalleFacNCDev(string nro_trans, string articulo)
        {
            cn = conexion.genearConexion();
            string consulta = "SELECT * FROM wmt_facturas_det WHERE nro_trans =@nro_trans AND  cod_articulo like @articulo or nro_trans =@nro_trans AND nom_articulo like @articulo";
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.Parameters.Add("nro_trans", SqlDbType.VarChar).Value = nro_trans;
            conmand.Parameters.Add("articulo", SqlDbType.VarChar).Value = articulo;

            SqlDataReader dr = conmand.ExecuteReader();

            return dr;
        }

        //Consulta detalle global de todas las notas de credito disponibles y saber el dato exacto de las entregadas 
        public SqlDataReader ConsultaDetCantNCDev(string cod_emp, string nro_doca, string serie_doca, string cod_articulo)
        {
            cn = conexion.genearConexion();
            string consulta = "SELECT Sum(dbo.wmt_facturas_det.cantidad) AS cantidad,wmt_facturas_det.cod_articulo,wmt_facturas_det.serie_doca,wmt_facturas_det.nro_doca,wmt_facturas_det.cod_emp FROM wmt_facturas_det INNER JOIN wmt_facturas_cab ON wmt_facturas_cab.nro_trans = wmt_facturas_det.nro_trans WHERE wmt_facturas_det.cod_emp = @cod_emp AND wmt_facturas_det.nro_doca = @nro_doca AND wmt_facturas_det.serie_doca = @serie_doca AND wmt_facturas_det.cod_articulo = @cod_articulo AND wmt_facturas_cab.tipo <> 'VTA' AND wmt_facturas_cab.estado  IN('F' ,'C')  GROUP BY wmt_facturas_det.cod_emp,wmt_facturas_det.cod_doca,wmt_facturas_det.nro_doca,wmt_facturas_det.serie_doca,wmt_facturas_det.cod_articulo";
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
            conmand.Parameters.Add("nro_doca", SqlDbType.VarChar).Value = nro_doca;
            conmand.Parameters.Add("serie_doca", SqlDbType.VarChar).Value = serie_doca;
            conmand.Parameters.Add("cod_articulo", SqlDbType.VarChar).Value = cod_articulo;

            SqlDataReader dr = conmand.ExecuteReader();

            return dr;
        }
    }
}
