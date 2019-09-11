using System;
using CapaProceso.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using CapaDatos.Modelos;

namespace CapaDatos.Sql
{
   public  class CodProcesoFactura
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        modeloCodProcesoFactura modeloProceso = new modeloCodProcesoFactura();
        public List<modeloCodProcesoFactura> ConsultaProceso(string cod_proceso)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloCodProcesoFactura> lista = new List<modeloCodProcesoFactura>();
                    string consulta = "SELECT * FROM wmm_procesos WHERE cod_proceso = @cod_proceso";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("cod_proceso", SqlDbType.VarChar).Value = cod_proceso;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        modeloCodProcesoFactura item = new modeloCodProcesoFactura();
                        item.cod_proceso = Convert.ToString(dr["cod_proceso"]);
                        item.nom_proceso = Convert.ToString(dr["nom_proceso"]);
                        item.observaciones = Convert.ToString(dr["observaciones"]);
                        item.email = Convert.ToString(dr["email"]);
                        item.pagina_audit = Convert.ToString(dr["pagina_audit"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        item.auditable = Convert.ToString(dr["auditable"]);
                        item.imagen = Convert.ToString(dr["imagen"]);
                        item.modulo = Convert.ToString(dr["modulo"]);
                        item.pagina = Convert.ToString(dr["pagina"]);
                        item.tamano = Convert.ToString(dr["tamano"]);
                        item.vinculo = Convert.ToString(dr["vinculo"]);
                        item.menu = Convert.ToString(dr["menu"]);
                        item.vinculo2 = Convert.ToString(dr["vinculo2"]);
                        item.orden = Convert.ToString(dr["orden"]);
                        lista.Add(item);
                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "CodProcesoDactura.cs", "ConsultaProceso", e.ToString(), DateTime.Today, "consulta");
                return null;
            }


        }
    }
}
