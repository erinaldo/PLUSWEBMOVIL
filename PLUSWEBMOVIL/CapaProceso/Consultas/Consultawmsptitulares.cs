using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace CapaProceso.Consultas
{
    public class Consultawmsptitulares
    {
        Documento documento = new Documento();
        modelowmspctitulares modelotitulares = new modelowmspctitulares();

        public List<modelowmspctitulares> ConsultaTitulares(string Ven__usuario, string Ven__cod_emp, string Ven__cod_tipotit, string Ven__cod_tit)
        {
            List<modelowmspctitulares> lista = new List<modelowmspctitulares>();
            SqlDataReader dr = documento.ListaBuscaTitulares(Ven__usuario, Ven__cod_emp, Ven__cod_tipotit, Ven__cod_tit);

            while (dr.Read())
            {

                modelowmspctitulares item = new modelowmspctitulares(Convert.ToString(dr["cod_tit"]), Convert.ToString(dr["nom_tit"]), Convert.ToString(dr["cod_dgi"]), Convert.ToString(dr["nro_dgi"]), Convert.ToString(dr["nro_dgi1"]), Convert.ToString(dr["nro_dgi2"]), Convert.ToString(dr["dir_tit"]), Convert.ToString(dr["tel_tit"]), Convert.ToString(dr["fax_tit"]), Convert.ToString(dr["email_tit"]),Convert.ToString(dr["dir_web"]), Convert.ToString(dr["cod_pais"]), Convert.ToString(dr["nom_pais"]), Convert.ToString(dr["cod_provincia"]), Convert.ToString(dr["nom_provincia"]),Convert.ToString(dr["ciudad_tit"]), Convert.ToString(dr["nom_ciudad"]), Convert.ToString(dr["cod_tipo_emp_gan"]), Convert.ToString(dr["nom_tipo_emp_gan"]), Convert.ToString(dr["cod_tipo_emp_iva"]),Convert.ToString(dr["nom_aux"]), Convert.ToString(dr["nom_aux2"]), Convert.ToString(dr["nom_aux3"]), Convert.ToString(dr["nom_aux4"]), Convert.ToString(dr["razon_social"]),Convert.ToString(dr["control_tit"]), Convert.ToString(dr["control_uso"]), Convert.ToString(dr["control_uso2"]), Convert.ToString(dr["cod_sop"]));

                lista.Add(item);

            }
            return lista;
        }

    
    }
}
