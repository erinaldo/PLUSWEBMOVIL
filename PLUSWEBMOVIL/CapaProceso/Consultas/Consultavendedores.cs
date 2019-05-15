using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
    public class Consultavendedores
    {
        Vendedores vendedores = new Vendedores();
        modelovendedores modevendedores = new modelovendedores();
        
        public List<modelovendedores> ConsultaVendedores(string Vend__usuario, string Vend__cod_emp, string Vend__cod_tipotit, string Vend__cod_tit)
        {
            List<modelovendedores> lista = new List<modelovendedores>();
            SqlDataReader dr = vendedores.ListaBuscaVendedores(Vend__usuario, Vend__cod_emp, Vend__cod_tipotit, Vend__cod_tit);

            while (dr.Read())
            {

                modelovendedores item = new modelovendedores();
                item.cod_tit = Convert.ToString(dr["cod_tit"]);
                item.nom_tit = Convert.ToString(dr["nom_tit"]);
                item.cod_dgi = Convert.ToString(dr["cod_dgi"]);
                item.nro_dgi = Convert.ToString(dr["nro_dgi"]);
                item.nro_dgi2 = Convert.ToString(dr["nro_dgi2"]);
                item.nro_dgi1 = Convert.ToString(dr["nro_dgi1"]);
                item.dir_tit = Convert.ToString(dr["dir_tit"]);
                item.tel_tit = Convert.ToString(dr["tel_tit"]);
                item.fax_tit = Convert.ToString(dr["fax_tit"]);
                item.email_tit = Convert.ToString(dr["email_tit"]);
                item.dir_web = Convert.ToString(dr["dir_web"]);
                item.cod_pais = Convert.ToString(dr["cod_pais"]);
                item.nom_pais = Convert.ToString(dr["nom_pais"]);
                item.cod_provincia = Convert.ToString(dr["cod_provincia"]);
                item.nom_provincia = Convert.ToString(dr["nom_provincia"]);
                item.ciudad_tit = Convert.ToString(dr["ciudad_tit"]);
                item.nom_ciudad = Convert.ToString(dr["nom_ciudad"]);
                item.cod_tipo_emp_gan = Convert.ToString(dr["cod_tipo_emp_gan"]);
                item.nom_tipo_emp_gan = Convert.ToString(dr["nom_tipo_emp_gan"]);
                item.cod_tipo_emp_iva = Convert.ToString(dr["cod_tipo_emp_iva"]);
                item.nom_aux = Convert.ToString(dr["nom_aux"]);
                item.nom_aux2 = Convert.ToString(dr["nom_aux2"]);
                item.nom_aux3 = Convert.ToString(dr["nom_aux3"]);
                item.nom_aux4 = Convert.ToString(dr["nom_aux4"]);
                item.razon_social = Convert.ToString(dr["razon_social"]);
                 item.control_tit = Convert.ToString(dr["control_tit"]);
                item.control_uso = Convert.ToString(dr["control_uso"]);
                item.control_uso2 = Convert.ToString(dr["control_uso2"]);
                item.cod_sop = Convert.ToString(dr["cod_sop"]);

                lista.Add(item);

            }
            return lista;
        }
    }
}
