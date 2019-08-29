using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public class EfectivoCaja
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;

        //Insertar cierre en tabla wmt_cierre_resumencaja
        public string InsertarEfectivoCaja(modeloEfectivoCaja Efectivocaja)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO  wmt_efectivoCaja (denominacionMBId,  valor,cantidad,total, usuario_mod, fecha_mod,fecha_efe) VALUES (@denominacionMBId,  @valor,@cantidad,@total, @usuario_mod, @fecha_mod,@fecha_efe)";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@denominacionMBId", SqlDbType.VarChar).Value = Efectivocaja.denominacionMId;
                    conmand.Parameters.Add("@valor", SqlDbType.VarChar).Value = Efectivocaja.valor;
                    conmand.Parameters.Add("@cantidad", SqlDbType.VarChar).Value = Efectivocaja.cantidad;
                    conmand.Parameters.Add("@total", SqlDbType.Decimal).Value = Efectivocaja.total;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = Efectivocaja.usuario_mod;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = Efectivocaja.fecha_mod;
                    conmand.Parameters.Add("@fecha_efe", SqlDbType.VarChar).Value = Efectivocaja.fecha_efe;

                    int dr = conmand.ExecuteNonQuery();
                    return "Efectivo Caja guardada correctamente";
                }

            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }
        //Actualizar cierre en tabla wmt_cierre_resumencaja
        public string ActualizarEfectivoCaja(modeloEfectivoCaja Efectivocaja)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "UPDATE  wmt_efectivoCaja SET denominacionMBId =@denominacionMBId,  valor =@valor,cantidad =@cantidad,total =@total, usuario_mod =@usuario_mod , fecha_mod = @fecha_mod WHERE id= @id";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@denominacionMBId", SqlDbType.VarChar).Value = Efectivocaja.denominacionMId;
                    conmand.Parameters.Add("@valor", SqlDbType.VarChar).Value = Efectivocaja.valor;
                    conmand.Parameters.Add("@cantidad", SqlDbType.VarChar).Value = Efectivocaja.cantidad;
                    conmand.Parameters.Add("@total", SqlDbType.Decimal).Value = Efectivocaja.total;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = Efectivocaja.usuario_mod;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = Efectivocaja.fecha_mod;
                    conmand.Parameters.Add("@fecha_efe", SqlDbType.VarChar).Value = Efectivocaja.fecha_efe;
                    conmand.Parameters.Add("@id", SqlDbType.VarChar).Value = Efectivocaja.id;

                    int dr = conmand.ExecuteNonQuery();
                    return "Efectivo Caja guardada correctamente";
                }

            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }

        //Eliminar cierre en tabla wmt_cierre_resumencaja
        public string EliminarEfectivoCaja(modeloEfectivoCaja Efectivocaja)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "DELETE  wmt_efectivoCaja  WHERE id= @id";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@id", SqlDbType.VarChar).Value = Efectivocaja.id;

                    int dr = conmand.ExecuteNonQuery();
                    return "Efectivo  Caja eliminado correctamente";
                }

            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }

        //Trae total de pagos en efectivo por facturas pos, pose
        public List<modeloTotalPgsFacturas> ListaEfectivoCF(string fecha)
        {

            using (cn = conexion.genearConexion())
            {
                List<modeloTotalPgsFacturas> lista = new List<modeloTotalPgsFacturas>();
                string consulta = (" SELECT SUM(wmt_facturas_pgs.valor) AS total, SUM (wmt_facturas_pgs.recibido) as recibido, SUM(wmt_facturas_pgs.diferencia) AS vueltos FROM wmm_fpagoPOS, wmt_facturas_pgs, wmt_facturas_cab WHERE wmm_fpagoPOS.vuelto = 's' AND wmt_facturas_pgs.cod_fpago = wmm_fpagoPOS.cod_fpago AND wmt_facturas_cab.fec_doc = @fecha and wmt_facturas_cab.nro_trans = wmt_facturas_pgs.nro_trans AND wmt_facturas_cab.tipo IN ('POS','POSE')");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("fecha", SqlDbType.VarChar).Value = fecha;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {

                    modeloTotalPgsFacturas item = new modeloTotalPgsFacturas();
                    item.total = Convert.ToString(dr["total"]);

                    item.recibido = Convert.ToString(dr["recibido"]);
                    item.vueltos = Convert.ToString(dr["vueltos"]);
                    lista.Add(item);

                }

                return lista;
            }

        }

        //Trae total de NOTAS DE VENTA TIPO NVTA
        public List<modeloTotalPgsFacturas> ListaTotalNVTA(string fecha)
        {

            using (cn = conexion.genearConexion())
            {
                List<modeloTotalPgsFacturas> lista = new List<modeloTotalPgsFacturas>();
                string consulta = (" SELECT SUM(wmt_facturas_pgs.valor) AS total, SUM (wmt_facturas_pgs.recibido) as recibido, SUM(wmt_facturas_pgs.diferencia) AS vueltos FROM wmm_fpagoPOS, wmt_facturas_pgs, wmt_facturas_cab WHERE wmm_fpagoPOS.vuelto = 's' AND wmt_facturas_pgs.cod_fpago = wmm_fpagoPOS.cod_fpago AND wmt_facturas_cab.fec_doc = @fecha and wmt_facturas_cab.nro_trans = wmt_facturas_pgs.nro_trans AND wmt_facturas_cab.tipo ='NVTA'");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("fecha", SqlDbType.VarChar).Value = fecha;

                SqlDataReader dr = conmand.ExecuteReader();
                while (dr.Read())
                {

                    modeloTotalPgsFacturas item = new modeloTotalPgsFacturas();
                    item.total = Convert.ToString(dr["total"]);

                    item.recibido = Convert.ToString(dr["recibido"]);
                    item.vueltos = Convert.ToString(dr["vueltos"]);
               

                    lista.Add(item);

                }

                return lista;
            }

        }


    }
}
