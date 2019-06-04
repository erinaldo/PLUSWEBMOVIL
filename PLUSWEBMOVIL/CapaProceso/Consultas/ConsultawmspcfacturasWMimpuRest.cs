using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
  public  class ConsultawmspcfacturasWMimpuRest
    {

        ImpuestosRest consultaImpuesto = new ImpuestosRest();
        public List<modelowmspcfacturasWMimpuRest> BuscarImpuestoRest(string usuario, string cod_emp, string nro_trans, string  impuesto)
        {
            List<modelowmspcfacturasWMimpuRest> lista = new List<modelowmspcfacturasWMimpuRest> ();
            SqlDataReader dr = consultaImpuesto.ListaImpuestosRest(usuario, cod_emp, nro_trans, impuesto);

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
