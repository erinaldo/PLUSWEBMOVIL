using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public class ExepcionesPW
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        public string InsertarExcepcion(modeloExepciones Exepciones)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO  wmc_excepcion (cod_emp,proceso,metodo,error,fecha_hora, usuario_mod) VALUES (@cod_emp,@proceso,@metodo,@error,@fecha_hora, @usuario_mod)";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                  
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = Exepciones.cod_emp;
                    conmand.Parameters.Add("@proceso", SqlDbType.VarChar).Value = Exepciones.proceso;
                    conmand.Parameters.Add("@metodo", SqlDbType.VarChar).Value = Exepciones.metodo;
                    conmand.Parameters.Add("@error", SqlDbType.VarChar).Value =Exepciones.error;
                    conmand.Parameters.Add("@fecha_hora", SqlDbType.VarChar).Value = Exepciones.fecha_hora;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = Exepciones.usuario_mod;
                  
                  
                    
                    
                    
                    int dr = conmand.ExecuteNonQuery();
                    return "Excepcion guardada correctamente";
                }

            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }
    }
}
