using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class Empresa
    {
            
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;

        public SqlDataReader ConsultaEmpresa(string cod_emp, string tipo)
        {
            cn = conexion.genearConexion();

            string consulta = "SELECT TOP 1  * FROM wmt_facturas_cab WHERE cod_emp = @cod_emp AND tipo = @tipo AND cod_docum = 'FV' AND estado = 'F' AND cod_docum = 'FV' AND serie_docum = 'S' AND nro_docum = '3948'";
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
            conmand.Parameters.Add("tipo", SqlDbType.VarChar).Value = tipo;


            SqlDataReader dr = conmand.ExecuteReader();

            return dr;

        }

        public SqlDataReader InsertarCabecera(string cod_cliente, string dia, string mes, string anio, string serie_docum, string cod_ccostos, string cod_vendedor, string cod_fpago, string observaciones, string nro_trans, string cod_emp, string cod_docum, string nro_docum, decimal subtotal,decimal iva,decimal monto_imponible, decimal total,string estado,string usuario_mod,string nro_audit,string ocompra,string cod_moneda,string tipo,decimal porc_descto,decimal descuento,string diar, string mesr, string anior,string cod_proc_aud)
        {
            cn = conexion.genearConexion();

            string consulta = "INSERT INTO  wmt_facturas_cab  (cod_cliente, dia, mes, anio, serie_docum, cod_ccostos, cod_vendedor, cod_fpago, observaciones, nro_trans, cod_emp, cod_docum, nro_docum, subtotal, iva, monto_imponible, total, estado, usuario_mod, nro_audit, ocompra, cod_moneda, tipo, porc_descto, descuento, diar, mesr, anior, cod_proc_aud) VALUES( @cod_cliente, @dia, @mes, @anio, @serie_docum, @cod_ccostos, @cod_vendedor, @cod_fpago, @observaciones, @nro_trans, @cod_emp, @cod_docum, @nro_docum, @subtotal, @iva, @monto_imponible, @total, @estado, @usuario_mod, @nro_audit, @ocompra, @cod_moneda, @tipo, @porc_descto, @descuento, @diar, @mesr, @anior, @cod_proc_aud)";

            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = cod_cliente;
            conmand.Parameters.Add("@dia", SqlDbType.VarChar).Value = dia;
            conmand.Parameters.Add("@mes", SqlDbType.VarChar).Value = mes;
            conmand.Parameters.Add("@anio", SqlDbType.VarChar).Value = anio;
            conmand.Parameters.Add("@serie_docum", SqlDbType.VarChar).Value = serie_docum;
            conmand.Parameters.Add("@cod_ccostos", SqlDbType.VarChar).Value = cod_ccostos;
            conmand.Parameters.Add("@cod_vendedor", SqlDbType.VarChar).Value = cod_vendedor;
            conmand.Parameters.Add("@cod_fpago", SqlDbType.VarChar).Value = cod_fpago;
            conmand.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = observaciones;
            conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
            conmand.Parameters.Add("@serie_docum", SqlDbType.VarChar).Value = serie_docum;
            conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
            conmand.Parameters.Add("@cod_docum", SqlDbType.VarChar).Value = cod_docum;
            conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = nro_docum;
            conmand.Parameters.Add("@subtotal", SqlDbType.VarChar).Value = subtotal;
            conmand.Parameters.Add("@iva", SqlDbType.VarChar).Value = iva;
            conmand.Parameters.Add("@monto_imponible", SqlDbType.VarChar).Value = monto_imponible;
            conmand.Parameters.Add("@total", SqlDbType.VarChar).Value = total;
            conmand.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;
            conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = usuario_mod;
            conmand.Parameters.Add("@nro_audit", SqlDbType.VarChar).Value = nro_audit;
            conmand.Parameters.Add("@ocompra", SqlDbType.VarChar).Value = ocompra;
            conmand.Parameters.Add("@cod_moneda", SqlDbType.VarChar).Value = cod_moneda;
            conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
            conmand.Parameters.Add("@porc_descto", SqlDbType.VarChar).Value = porc_descto;
            conmand.Parameters.Add("@descuento", SqlDbType.VarChar).Value = descuento;
            conmand.Parameters.Add("@diar", SqlDbType.VarChar).Value = diar;
            conmand.Parameters.Add("@mesr", SqlDbType.VarChar).Value =mesr;
            conmand.Parameters.Add("@anior", SqlDbType.VarChar).Value = anior;
            conmand.Parameters.Add("@cod_proc_aud", SqlDbType.VarChar).Value = cod_proc_aud;

            SqlDataReader dr = conmand.ExecuteReader();

            return dr;

        }
    }
}
