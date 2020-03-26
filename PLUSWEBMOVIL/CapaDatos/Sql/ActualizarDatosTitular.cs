using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CapaProceso.Modelos;
using CapaDatos.Modelos;

namespace CapaDatos.Sql
{
   public  class ActualizarDatosTitular
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        modeloActualizarDatosTitular modeloActualizarTitular = new modeloActualizarDatosTitular();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public string ActualizarDatTitular(modeloActualizarDatosTitular ActualizarDatos)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string consulta = ("wmspr_acttitular");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = ActualizarDatos.usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = ActualizarDatos.empresa;
                    conmand.Parameters.Add("@cod_tit", SqlDbType.VarChar).Value = ActualizarDatos.cod_tit.Trim();
                    conmand.Parameters.Add("@cod_sucursal", SqlDbType.VarChar).Value = ActualizarDatos.sucursal;
                    conmand.Parameters.Add("@parametro", SqlDbType.VarChar).Value = ActualizarDatos.parametro.Trim();
                    conmand.Parameters.Add("@valor", SqlDbType.VarChar).Value = ActualizarDatos.valor.Trim();
                
                    int dr = conmand.ExecuteNonQuery();
                    return "Datoa actualizados correctamente";
                }

            }
            catch (Exception e)
            {
                
                guardarExcepcion.ClaseInsertarExcepcion(ActualizarDatos.empresa, "ActualizarDatosTitular.cs", "ActualizarDatTitular", e.ToString(), DateTime.Now, ActualizarDatos.usuario);
                return "No se pudo completar la acción." + "ActualizarDatTitular." + " Por favor notificar al administrador."; 
            }

        }
    }
}
