using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class CMonedas
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;

     
        public List<modelowmspcmonedas> ListaBuscaCMonedas(string MonB__usuario, string MonB__cod_emp, string MonB__moneda)
        {

            using (cn = conexion.genearConexion())
            {
                List<modelowmspcmonedas> lista = new List<modelowmspcmonedas>();
                string consulta = ("wmspc_monedas");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.CommandType = CommandType.StoredProcedure;
                conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = MonB__usuario;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = MonB__cod_emp;
                conmand.Parameters.Add("@moneda", SqlDbType.VarChar).Value = MonB__moneda;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {

                    modelowmspcmonedas item = new modelowmspcmonedas();
                    item.descripcion = Convert.ToString(dr["cod_moneda"]) + " - " + Convert.ToString(dr["simbolo_moneda"]);
                    item.cod_moneda = Convert.ToString(dr["cod_moneda"]);
                    item.nom_moneda = Convert.ToString(dr["nom_moneda"]);
                    item.simbolo_moneda = Convert.ToString(dr["simbolo_moneda"]);
                    item.redondeo = Convert.ToString(dr["redondeo"]);
                    item.redondeo_pu = Convert.ToString(dr["redondeo_pu"]);

                    lista.Add(item);

                }

                return lista;
            }
            
        }


    }
}
