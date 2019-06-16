using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class ImpuestosRest
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;

        public List<modelowmspcfacturasWMimpuRest> ListaImpuestosRest(string usuario, string cod_emp, string nro_trans, string linea)
        {
            //Buscar cotizacion moneda trm

            using (cn = conexion.genearConexion())
            {
                List<modelowmspcfacturasWMimpuRest> lista = new List<modelowmspcfacturasWMimpuRest>();

                string consulta = ("wmspc_facturasWM_impu");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.CommandType = CommandType.StoredProcedure;
                conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                conmand.Parameters.Add("@linea", SqlDbType.VarChar).Value = linea;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {

                    modelowmspcfacturasWMimpuRest item = new modelowmspcfacturasWMimpuRest();

                    item.linea_impu = Convert.ToString(dr["linea_impu"]);
                    item.nro_trans = Convert.ToString(dr["nro_trans"]);
                    item.linea = Convert.ToString(dr["linea"]);
                    item.cod_tipo_impu = Convert.ToString(dr["cod_tipo_impu"]);
                    item.nom_impuesto = Convert.ToString(dr["nom_impuesto"]);
                    item.cod_tasa_impu = Convert.ToString(dr["cod_tasa_impu"]);
                    item.nom_tasa = Convert.ToString(dr["nom_tasa"]);
                    item.porc_impu = Convert.ToString(dr["porc_impu"]);
                    item.base_impu = Convert.ToString(dr["base_impu"]);
                    item.valor_impu = Convert.ToString(dr["valor_impu"]);

                    lista.Add(item);
                }

                return lista;
            }
            
        }
    }
}
