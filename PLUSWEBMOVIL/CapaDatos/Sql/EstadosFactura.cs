using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public class EstadosFactura
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<modeloestadosfactura> ListaEstadosFactura(string EstF_proceso)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloestadosfactura> lista = new List<modeloestadosfactura>();
                    string consulta = ("SELECT * FROM wmm_procesos_est WHERE cod_proceso = @proceso ORDER BY nom_estado ASC");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@proceso", SqlDbType.VarChar).Value = EstF_proceso;

                    SqlDataReader dr = conmand.ExecuteReader();

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
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "EstadosFactura.cs", "ListaEstadosFactura", e.ToString(), DateTime.Today, "consulta");
                return null;
            }


        }
    }
}

