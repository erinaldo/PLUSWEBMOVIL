using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace CapaProceso.Consultas
{
    public class Consultawmspcformaspag
    {
        Fpagos fpagos = new Fpagos();
        modelowmspcfpago modelofpago = new modelowmspcfpago();
        
        public List<modelowmspcfpago> ConsultaFpagos(string FP__usuario, string FP__cod_emp, string FP__cod_fpago)
        {
            List<modelowmspcfpago> lista = new List<modelowmspcfpago>();
            SqlDataReader dr = fpagos.ListaBuscaFPago(FP__usuario,  FP__cod_emp, FP__cod_fpago);

            while (dr.Read())
            {

                modelowmspcfpago item = new modelowmspcfpago();
                item.descripcion = Convert.ToString(dr["cod_fpago"]) + " - " + Convert.ToString(dr["nom_fpago"]);
                item.cod_fpago = Convert.ToString(dr["cod_fpago"]);
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
