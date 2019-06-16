using System;
using CapaProceso.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using CapaDatos.Modelos;

namespace CapaDatos.Sql
{
    public class CuentasBanco
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        public List<modelobancos> ConsultaBancos(string usuario, string cod_emp)
        {
            using (cn = conexion.genearConexion())
            {
                List<modelobancos> lista = new List<modelobancos>();

                string consulta = ("wmspc_ctasbco");
                SqlCommand conmand = new SqlCommand(consulta, cn);
                conmand.CommandType = CommandType.StoredProcedure;
                conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;


                SqlDataReader dr = conmand.ExecuteReader();


                while (dr.Read())
                {

                    modelobancos item = new modelobancos();

                    item.cod_tit = Convert.ToString(dr["cod_tit"]);
                    item.nom_tit = Convert.ToString(dr["nom_tit"]);
                    item.tipocta_banco = Convert.ToString(dr["tipocta_banco"]);
                    item.nomtcta_banco = Convert.ToString(dr["nomtcta_banco"]);
                    item.nrocta_banco = Convert.ToString(dr["nrocta_banco"]);
                    item.cod_cta = Convert.ToString(dr["cod_cta"]);
                    item.cod_moneda = Convert.ToString(dr["cod_moneda"]);

                    lista.Add(item);
                }
                return lista;
            }
        }
    }
}
