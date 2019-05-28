using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
   public  class ConsultaEmpresa
    {
        Empresa consultaEmpresa = new Empresa();
        public List<modelowmspcempresas> BuscartaEmpresa(string usuario, string cod_emp)
        {
            List<modelowmspcempresas> lista = new List<modelowmspcempresas>();
            SqlDataReader dr = consultaEmpresa.BuscarEmpresa(usuario, cod_emp);

            while (dr.Read())
            {

                modelowmspcempresas item = new modelowmspcempresas();
                item.cod_emp = Convert.ToString(dr["cod_emp"]);
                item.nom_emp = Convert.ToString(dr["nom_emp"]);
                item.nro_dgi = Convert.ToString(dr["nro_dgi"]);
                item.nro_dgi1 = Convert.ToString(dr["nro_dgi1"]);
                item.nro_dgi2 = Convert.ToString(dr["nro_dgi2"]);
                item.dir_tit = Convert.ToString(dr["dir_tit"]);
                item.tel_tit = Convert.ToString(dr["tel_tit"]);
                item.fax_tit = Convert.ToString(dr["fax_tit"]);
                item.cod_pais = Convert.ToString(dr["cod_pais"]);
                item.nom_pais = Convert.ToString(dr["nom_pais"]);
                item.cod_provincia = Convert.ToString(dr["cod_provincia"]);
                item.nom_provincia = Convert.ToString(dr["nom_provincia"]);
                item.ciudad_tit = Convert.ToString(dr["ciudad_tit"]);
                item.nom_ciudad = Convert.ToString(dr["nom_ciudad"]);
                item.email_tit = Convert.ToString(dr["email_tit"]);
                item.dir_web = Convert.ToString(dr["dir_web"]);
                item.cod_tipo_emp_gan = Convert.ToString(dr["cod_tipo_emp_gan"]);
                item.nom_tipo_emp_gan = Convert.ToString(dr["nom_tipo_emp_gan"]);
                item.cod_tipo_emp_iva = Convert.ToString(dr["cod_tipo_emp_iva"]);
                item.nom_tipo_emp_iva = Convert.ToString(dr["nom_tipo_emp_iva"]);

                lista.Add(item);


            }
            return lista;
        }

    }
}
