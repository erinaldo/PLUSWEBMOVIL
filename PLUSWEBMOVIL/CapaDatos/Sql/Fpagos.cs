using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class Fpagos
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;

        public List<modelowmspcfpago> ListaBuscaFPago(string FP__usuario, string FP__cod_emp, string FP__cod_fpago)
        {

            using (cn = conexion.genearConexion())
            {
                List<modelowmspcfpago> lista = new List<modelowmspcfpago>();

                string consulta = ("wmspc_formaspag");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.CommandType = CommandType.StoredProcedure;
                conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = FP__usuario;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = FP__cod_emp;
                conmand.Parameters.Add("@cod_fpago", SqlDbType.VarChar).Value = FP__cod_fpago;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {

                    modelowmspcfpago item = new modelowmspcfpago();
                    item.descripcion = Convert.ToString(dr["cod_fpago"]) + " - " + Convert.ToString(dr["nom_fpago"]);
                    item.cod_fpago = Convert.ToString(dr["cod_fpago"]).Trim();
                    item.nom_fpago = Convert.ToString(dr["nom_fpago"]);
                    item.plazo_libre = Convert.ToString(dr["plazo_libre"]);
                    item.cant_cuotas = Convert.ToString(dr["cant_cuotas"]);
                    item.plazo_cuotas = Convert.ToString(dr["plazo_cuotas"]);
                    item.cod_docum = Convert.ToString(dr["cod_docum"]);

                    lista.Add(item);

                }

                return lista;
            }
            
        }
    }
}
