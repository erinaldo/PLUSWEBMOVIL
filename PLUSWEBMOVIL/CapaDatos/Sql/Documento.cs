using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class Documento
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;

        public List<modelowmspctitulares> ListaBuscaTitulares(string Ven__usuario, string Ven__cod_emp, string Ven__cod_tipotit, string Ven__cod_tit)
        {

            using (cn = conexion.genearConexion())
            {
                List<modelowmspctitulares> lista = new List<modelowmspctitulares>();
                string consulta = ("wmspc_titulares");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.CommandType = CommandType.StoredProcedure;
                conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = Ven__usuario;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = Ven__cod_emp;
                conmand.Parameters.Add("@cod_tipotit", SqlDbType.VarChar).Value = Ven__cod_tipotit;
                conmand.Parameters.Add("@cod_tit", SqlDbType.VarChar).Value = Ven__cod_tit;


                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {

                    modelowmspctitulares item = new modelowmspctitulares(Convert.ToString(dr["cod_tit"]), Convert.ToString(dr["nom_tit"]), Convert.ToString(dr["cod_dgi"]), Convert.ToString(dr["nro_dgi"]), Convert.ToString(dr["nro_dgi1"]), Convert.ToString(dr["nro_dgi2"]), Convert.ToString(dr["dir_tit"]), Convert.ToString(dr["tel_tit"]), Convert.ToString(dr["fax_tit"]), Convert.ToString(dr["email_tit"]), Convert.ToString(dr["dir_web"]), Convert.ToString(dr["cod_pais"]), Convert.ToString(dr["nom_pais"]), Convert.ToString(dr["cod_provincia"]), Convert.ToString(dr["nom_provincia"]), Convert.ToString(dr["ciudad_tit"]), Convert.ToString(dr["nom_ciudad"]), Convert.ToString(dr["cod_tipo_emp_gan"]), Convert.ToString(dr["nom_tipo_emp_gan"]), Convert.ToString(dr["cod_tipo_emp_iva"]), Convert.ToString(dr["nom_aux"]), Convert.ToString(dr["nom_aux2"]), Convert.ToString(dr["nom_aux3"]), Convert.ToString(dr["nom_aux4"]), Convert.ToString(dr["razon_social"]), Convert.ToString(dr["control_tit"]), Convert.ToString(dr["control_uso"]), Convert.ToString(dr["control_uso2"]), Convert.ToString(dr["cod_sop"]));

                    lista.Add(item);

                }

                return lista;
            }         
            

        }
    }
}
