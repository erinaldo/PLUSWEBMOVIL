using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
    public class ConsultafpagoPos
    {
        FPagosPos fPagosPos = new FPagosPos();
        modelowmmfpagoPOS modelofpagoPOS = new modelowmmfpagoPOS();

        public List<modelowmmfpagoPOS> ConsultaFormaPago()
        {
            List<modelowmmfpagoPOS> lista = new List<modelowmmfpagoPOS>();
            
            SqlDataReader dr = fPagosPos.consultaFormaPag();

            while (dr.Read())
            {

                //String cod_emp = Convert.ToString(dr["cod_emp"]);
               
          modelowmmfpagoPOS item = new modelowmmfpagoPOS(Convert.ToString(dr["cod_emp"]), Convert.ToString(dr["cod_fpago"]), Convert.ToString(dr["nom_fpago"]) , Convert.ToString(dr["cod_docum"]),Convert.ToString(dr["cod_cta"]), Convert.ToInt16(dr["plazo"]), Convert.ToInt16(dr["cuotas"]), Convert.ToInt16(dr["dias_cuotas"]), Convert.ToString(dr["maneja_ter"]), Convert.ToString(dr["maneja_doc"]), Convert.ToString(dr["usuario_mod"]), Convert.ToDateTime(dr["fecha_mod"]), Convert.ToInt16(dr["nro_audit"]),Convert.ToString(dr["cod_proc_aud"]), Convert.ToString(dr["abierto"]), Convert.ToString(dr["numero_propio"]));
          
           lista.Add(item);
         
            }
            return lista;
        }

    }
}
