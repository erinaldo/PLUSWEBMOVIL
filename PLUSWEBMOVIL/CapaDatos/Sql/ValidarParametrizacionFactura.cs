using CapaDatos.Modelos;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class ValidarParametrizacionFactura
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo ="ValidarParametrizacionFactura.cs";
        string stringConexionERP = "";// Aqui va la consulta de la table de alfredo desia que va ir el string
        //Consulta ERP , periodo contable tabla(CmPrC)
        public string ValidarPeriodoContable(string cod_emp, string usuario, string fecha)
        {
            try
            {
                string nombre_periodo = "";
                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    string consulta = ("SELECT CmPrC.CmPrCNom as periodo FROM CmPrC WHERE @fecha BETWEEN CmPrC.CmPrCIni AND CmPrC.CmPrCFin");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@fecha", SqlDbType.VarChar).Value = fecha;
                  

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        nombre_periodo = Convert.ToString(dr["periodo"]);
                    }
                    return nombre_periodo;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp,metodo, "ValidarPeriodoContable", e.ToString(), DateTime.Today, usuario);
                return "No se pudo completar la acción." + "ValidarPeriodoContable." + " Por favor notificar al administrador.";
            }
        }
    }
}