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
   public  class ParametrosPW
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
       
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo="ParametrosPW.cs";
        //Buscar lista de Efectivo Caja
        public List<modeloParametrosPWM> ListaParametrosPWM(string cod_emp, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloParametrosPWM> lista = new List<modeloParametrosPWM>();
                    string consulta = ("SELECT * FROM wmm_parametros where cod_emp =@cod_emp");

                    SqlCommand conmand = new SqlCommand(consulta, cn);

                      conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloParametrosPWM item = new modeloParametrosPWM();
                    
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.conexion_erp = Convert.ToString(dr["conexion_erp"]);
                        lista.Add(item);

                    }

                    return lista;
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaParamtrosPWM", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

        //Insertar conexion tabla wmm_parametros
        public string InsertarParametros(string cod_emp, string usuario, string conexion_erp)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO wmm_parametros (cod_emp,conexion_erp) VALUES (@cod_emp,@conexion) ";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@conexion", SqlDbType.VarChar).Value = conexion_erp;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;


                    int dr = conmand.ExecuteNonQuery();
                    return "Insertado correctamente";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "InsertarParametros", e.ToString(), DateTime.Today, usuario);
                return "No se pudo completar la acción." + "InsertarParametros." + " Por favor notificar al administrador.";
            }

        }

        //Actualizar conexion tabla wmm_parametros
        public string ActualizarParametros(string cod_emp, string usuario, string conexion_erp)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "UPDATE wmm_parametros SET conexion_erp =@conexion WHERE cod_emp= @cod_emp ";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@conexion", SqlDbType.VarChar).Value = conexion_erp;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
               

                    int dr = conmand.ExecuteNonQuery();
                    return "Actualizado correctamente";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ActualizarParametros", e.ToString(), DateTime.Today, usuario);
                return "No se pudo completar la acción." + "ActualizarParametros." + " Por favor notificar al administrador.";
            }

        }

        //Buscar unico
        public string BuscarUnico(string cod_emp, string usuario)
        {
            try
            {
                string stringConexionERP = "";

                using (cn = conexion.genearConexion())
                {
                    string consulta = ("SELECT conexion_erp FROM wmm_parametros where cod_emp =@cod_emp");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        stringConexionERP = Convert.ToString(dr["conexion_erp"]);
                    }
                    return stringConexionERP;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "BuscarUnico", e.ToString(), DateTime.Today, usuario);
                return "No se pudo completar la acción." + "BuscarUnico." + " Por favor notificar al administrador.";
            }
        }
    }
}
