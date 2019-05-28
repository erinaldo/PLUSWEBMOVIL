using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
    public class ConsultaBancos
    {
        CuentasBanco consultaBanco = new CuentasBanco();
        public List<modelobancos> BuscartaBancos(string usuario, string cod_emp)
        {
            List<modelobancos> lista = new List<modelobancos>();
            SqlDataReader dr = consultaBanco.ConsultaBancos(usuario,cod_emp);

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
