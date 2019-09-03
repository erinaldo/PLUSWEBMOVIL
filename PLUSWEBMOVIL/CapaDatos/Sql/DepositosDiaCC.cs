using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class DepositosDiaCC
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        //Prueba depositos del dia lupa
        public List<modeloDepositosDia> ListaCierreCF(string fecha, Int64 secuencial, string codigo, string cod_emp)
        {

            using (cn = conexion.genearConexion())
            {
                List<modeloDepositosDia> lista = new List<modeloDepositosDia>();
                string consulta = ("select * from wmt_cierre_resumencaja WHERE fecha_cie =@fecha_cie and secuencial = @secuencial and codigo= @codigo and cod_emp= @cod_emp");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("fecha_cie", SqlDbType.VarChar).Value = fecha;
                conmand.Parameters.Add("secuencial", SqlDbType.BigInt).Value = secuencial;
                conmand.Parameters.Add("codigo", SqlDbType.VarChar).Value = codigo;
                conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {

                    modeloDepositosDia item = new modeloDepositosDia();
                    item.id = Convert.ToString(dr["id"]);
                    item.secuencial = Convert.ToInt64(dr["secuencial"]);
                    item.signo = Convert.ToString(dr["signo"]);
                    item.codigo = Convert.ToString(dr["codigo"]);
                    item.nombre = Convert.ToString(dr["nombre"]);
                    item.valor = Convert.ToDecimal(dr["valor"]);
                    item.valor1 = String.Format("{0:N2}", item.valor).ToString();
                    item.fecha_cie = Convert.ToString(dr["fecha_cie"]);
                    item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                    item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                    item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                    item.nro_audit = Convert.ToString(dr["nro_audit"]);
                    item.cod_emp = Convert.ToString(dr["cod_emp"]);

                    lista.Add(item);

                }

                return lista;
            }

        }
    }
}
