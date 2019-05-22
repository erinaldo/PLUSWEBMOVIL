using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
    public class Consultaestadosfactura
    {
        EstadosFactura estados = new EstadosFactura();
        modeloestadosfactura modelestafactura = new modeloestadosfactura();

        public List<modeloestadosfactura> ConsultaEstadosFac(string EstF_proceso)
        {
            List<modeloestadosfactura> lista = new List<modeloestadosfactura>();
             SqlDataReader dr = estados.ListaEstadosFactura(EstF_proceso);

            while (dr.Read())
            {
                modeloestadosfactura item = new modeloestadosfactura();
                item.cod_proceso = Convert.ToString(dr["cod_proceso"]);
                item.estado = Convert.ToString(dr["estado"]);
                item.nom_estado = Convert.ToString(dr["nom_estado"]);
                item.nom_corto = Convert.ToString(dr["nom_corto"]);
                item.pagina_edicion = Convert.ToString(dr["pagina_edicion"]);
                item.nom_edicion = Convert.ToString(dr["nom_edicion"]);
                item.pagina_elimina = Convert.ToString(dr["pagina_elimina"]);
                item.nom_elimina = Convert.ToString(dr["nom_elimina"]);
                item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                item.nro_audit = Convert.ToInt16(dr["nro_audit"]);
                item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);

                lista.Add(item);
            }
            return lista;
        }
    }
}
