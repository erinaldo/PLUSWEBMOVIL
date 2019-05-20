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

        

        public SqlDataReader ConsultaCabezaraFactura(string cod_emp, string tipo)
        {
            cn = conexion.genearConexion();

            string consulta = "SELECT TOP 1  * FROM wmt_facturas_cab WHERE cod_emp = @cod_emp AND tipo = @tipo AND cod_docum = 'FV' AND estado = 'F' AND cod_docum = 'FV' AND serie_docum = 'S' AND nro_docum = '3948'";
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;
            conmand.Parameters.Add("tipo", SqlDbType.VarChar).Value = tipo;


            SqlDataReader dr = conmand.ExecuteReader();

            return dr;

        }
        public SqlDataReader ConsultaFacturaNroTran(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            cn = conexion.genearConexion();

            string consulta = ("wmspc_facturasWM_cab");
            SqlCommand conmand = new SqlCommand(consulta, cn);
            conmand.CommandType = CommandType.StoredProcedure;
            conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = Ccf_usuario;
            conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = Ccf_cod_emp;
            conmand.Parameters.Add("@tipo1", SqlDbType.VarChar).Value = Ccf_tipo1;
            conmand.Parameters.Add("@tipo2", SqlDbType.VarChar).Value = Ccf_tipo2;
            conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = Ccf_nro_trans;
            SqlDataReader dr = conmand.ExecuteReader();

            return dr;

        }

        public string InsertarCabecera(modelocabecerafactura cabezeraFactura)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "INSERT INTO  wmt_facturas_cab  (cod_cliente, fec_doc, dia, mes, anio, serie_docum, cod_ccostos, cod_vendedor, cod_fpago, observaciones, nro_trans, cod_emp, cod_docum, nro_docum, subtotal, iva, monto_imponible, total, estado, usuario_mod, nro_audit, ocompra, cod_moneda, tipo, porc_descto, descuento, diar, mesr, anior, cod_proc_aud) VALUES( @cod_cliente, @fec_doc, @dia, @mes, @anio, @serie_docum, @cod_ccostos, @cod_vendedor, @cod_fpago, @observaciones, @nro_trans, @cod_emp, @cod_docum, @nro_docum, @subtotal, @iva, @monto_imponible, @total, @estado, @usuario_mod, @nro_audit, @ocompra, @cod_moneda, @tipo, @porc_descto, @descuento, @diar, @mesr, @anior, @cod_proc_aud)";

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

                int dr = conmand.ExecuteNonQuery();
                return "Cabezera de factura guardada correctamente";
           }
            catch (Exception e)
            {

                return e.ToString();
            }
            

           

        }
    }
}
