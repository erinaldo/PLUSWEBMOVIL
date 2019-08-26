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
