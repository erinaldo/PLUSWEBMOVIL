using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
public class Numeradores
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        
        /*Consultamos el nro_trans de la tabla numeradores para la factura*/
        public modelonumerador ConsultaNroTransaccion(string numerador)
        {
            using (cn = conexion.genearConexion())
            {
                modelonumerador Mnumerador = new modelonumerador();

                string insert = "UPDATE n SET n.valor_asignado = (SELECT SUM (valor_asignado + incremento)AS TotAcum FROM wm_numeradores  WHERE numerador = @numerador) FROM wm_numeradores n WHERE n.numerador = @numerador";

                SqlCommand conmand = new SqlCommand(insert, cn);

                conmand.Parameters.Add("@numerador", SqlDbType.VarChar).Value = numerador;

                conmand.ExecuteNonQuery();


                string consulta = "SELECT TOP 1 *  FROM wm_numeradores WHERE numerador = @numerador";
                conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("@numerador", SqlDbType.VarChar).Value = numerador;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {


                    Mnumerador.numerador = Convert.ToString(dr["numerador"]);
                    Mnumerador.nombre = Convert.ToString(dr["nombre"]);
                    Mnumerador.valor_asignado = Convert.ToString(dr["valor_asignado"]);
                    Mnumerador.incremento = Convert.ToString(dr["incremento"]);
                    Mnumerador.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                    Mnumerador.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                    Mnumerador.nro_audit = Convert.ToString(dr["nro_audit"]);
                    Mnumerador.cod_pro_aud = Convert.ToString(dr["cod_proc_aud"]);


                }

                return Mnumerador;
            }
        }
        /*Consultamos el nro_audit de la tabla numeradores para sucursal empresa y sucursal usuario*/
        public modelonumerador ConsultaNroAuditoria(string numerador)
        {
            using (cn = conexion.genearConexion())
            {
                modelonumerador Mnumerador = new modelonumerador();

                string insert = "UPDATE n SET n.valor_asignado = (SELECT SUM (valor_asignado + incremento)AS TotAcum FROM wm_numeradores  WHERE numerador = @numerador) FROM wm_numeradores n WHERE n.numerador = @numerador";

                SqlCommand conmand = new SqlCommand(insert, cn);

                conmand.Parameters.Add("@numerador", SqlDbType.VarChar).Value = numerador;

                conmand.ExecuteNonQuery();


                string consulta = "SELECT TOP 1 *  FROM wm_numeradores WHERE numerador = @numerador";
                conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("@numerador", SqlDbType.VarChar).Value = numerador;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {


                    Mnumerador.numerador = Convert.ToString(dr["numerador"]);
                    Mnumerador.nombre = Convert.ToString(dr["nombre"]);
                    Mnumerador.valor_asignado = Convert.ToString(dr["valor_asignado"]);
                    Mnumerador.incremento = Convert.ToString(dr["incremento"]);
                    Mnumerador.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                    Mnumerador.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                    Mnumerador.nro_audit = Convert.ToString(dr["nro_audit"]);
                    Mnumerador.cod_pro_aud = Convert.ToString(dr["cod_proc_aud"]);


                }

                return Mnumerador;
            }
        }
    }
}
