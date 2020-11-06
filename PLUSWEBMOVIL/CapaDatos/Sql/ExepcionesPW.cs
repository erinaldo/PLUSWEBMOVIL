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
        //Clase para guardar
        public string ClaseInsertarExcepcion(string cod_emp, string proceso, string metodo, string error, DateTime fecha_hora, string usuario_mod)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO  wmc_excepcion (cod_emp,proceso,metodo,error,fecha_hora, usuario_mod) VALUES (@cod_emp,@proceso,@metodo,@error,@fecha_hora, @usuario_mod)";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value =cod_emp;
                    conmand.Parameters.Add("@proceso", SqlDbType.VarChar).Value = proceso;
                    conmand.Parameters.Add("@metodo", SqlDbType.VarChar).Value = metodo;
                    conmand.Parameters.Add("@error", SqlDbType.VarChar).Value = error;
                    conmand.Parameters.Add("@fecha_hora", SqlDbType.VarChar).Value = fecha_hora;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value =usuario_mod;

                    int dr = conmand.ExecuteNonQuery();
                    return "Excepcion guardada correctamente";
                }

            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }

        //Buscar por id de las excepciones
        public List<modeloExepciones> ListaExcepcionPorID(string cod_emp, string id, string usuario_mod)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloExepciones> lista = new List<modeloExepciones>();
                    string insert = "SELECT * FROM wmc_excepcion WHERE id=@id ORDER BY id DESC";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                   
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = usuario_mod;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloExepciones item = new modeloExepciones();
                        item.id = Convert.ToString(dr["id"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.proceso = Convert.ToString(dr["proceso"]);
                        item.metodo = Convert.ToString(dr["metodo"]);
                        item.error = Convert.ToString(dr["error"]);
                        DateTime fecha_formato = Convert.ToDateTime(dr["fecha_hora"]);
                        item.fecha_for = fecha_formato.ToString("yyyy-MM-dd");
                        item.fecha_hora = Convert.ToDateTime(dr["fecha_hora"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {



                return null;
            }
        }
        //Busca por usuario, proceso, metodo y fecha
        public List<modeloExepciones> ListaExcepcionPC(string cod_emp, string usuario,  string proceso, DateTime fecha_ini, DateTime fecha_fin, string usuario_mod,string metodo)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloExepciones> lista = new List<modeloExepciones>();
                    string insert = "SELECT * FROM wmc_excepcion WHERE wmc_excepcion.fecha_hora BETWEEN @fecha_ini AND @fecha_fin AND proceso = @proceso AND usuario_mod=@usuario AND metodo = @metodo and cod_emp =@cod_emp ORDER BY id DESC";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@proceso", SqlDbType.VarChar).Value = proceso;
                    conmand.Parameters.Add("@metodo", SqlDbType.VarChar).Value = metodo;
                    conmand.Parameters.Add("@fecha_ini", SqlDbType.VarChar).Value = fecha_ini;
                    conmand.Parameters.Add("@fecha_fin", SqlDbType.VarChar).Value = fecha_fin;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloExepciones item = new modeloExepciones();
                        item.id = Convert.ToString(dr["id"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.proceso = Convert.ToString(dr["proceso"]);
                        item.metodo = Convert.ToString(dr["metodo"]);
                        item.error = Convert.ToString(dr["error"]);
                        DateTime fecha_formato = Convert.ToDateTime(dr["fecha_hora"]);
                        item.fecha_for = fecha_formato.ToString("yyyy-MM-dd");
                        item.fecha_hora = Convert.ToDateTime(dr["fecha_hora"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {


                
                return null;
            }
        }

        //Busca por usuario, proceso,  fecha
        public List<modeloExepciones> ListaExcepcionProUsuFec(string cod_emp, string usuario, string proceso, DateTime fecha_ini, DateTime fecha_fin, string usuario_mod)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloExepciones> lista = new List<modeloExepciones>();
                    string insert = "SELECT * FROM wmc_excepcion WHERE wmc_excepcion.fecha_hora BETWEEN @fecha_ini AND @fecha_fin AND proceso = @proceso AND usuario_mod=@usuario and cod_emp =@cod_emp ORDER BY id DESC";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@proceso", SqlDbType.VarChar).Value = proceso;
                    conmand.Parameters.Add("@fecha_ini", SqlDbType.VarChar).Value = fecha_ini;
                    conmand.Parameters.Add("@fecha_fin", SqlDbType.VarChar).Value = fecha_fin;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloExepciones item = new modeloExepciones();
                        item.id = Convert.ToString(dr["id"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.proceso = Convert.ToString(dr["proceso"]);
                        item.metodo = Convert.ToString(dr["metodo"]);
                        item.error = Convert.ToString(dr["error"]);
                        DateTime fecha_formato = Convert.ToDateTime(dr["fecha_hora"]);
                        item.fecha_for = fecha_formato.ToString("yyyy-MM-dd");
                        item.fecha_hora = Convert.ToDateTime(dr["fecha_hora"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {



                return null;
            }
        }


        //Busca por usuario,  metodo y fecha
        public List<modeloExepciones> ListaExcepcionMetUsuFec(string cod_emp, string usuario,  DateTime fecha_ini, DateTime fecha_fin, string usuario_mod, string metodo)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloExepciones> lista = new List<modeloExepciones>();
                    string insert = "SELECT * FROM wmc_excepcion WHERE wmc_excepcion.fecha_hora BETWEEN @fecha_ini AND @fecha_fin  AND usuario_mod=@usuario AND metodo = @metodo and cod_emp =@cod_emp ORDER BY id DESC";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@metodo", SqlDbType.VarChar).Value = metodo;
                    conmand.Parameters.Add("@fecha_ini", SqlDbType.VarChar).Value = fecha_ini;
                    conmand.Parameters.Add("@fecha_fin", SqlDbType.VarChar).Value = fecha_fin;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloExepciones item = new modeloExepciones();
                        item.id = Convert.ToString(dr["id"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.proceso = Convert.ToString(dr["proceso"]);
                        item.metodo = Convert.ToString(dr["metodo"]);
                        item.error = Convert.ToString(dr["error"]);
                        DateTime fecha_formato = Convert.ToDateTime(dr["fecha_hora"]);
                        item.fecha_for = fecha_formato.ToString("yyyy-MM-dd");
                        item.fecha_hora = Convert.ToDateTime(dr["fecha_hora"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {



                return null;
            }
        }

        //Buscar solo por fechas todas las excepciones

        public List<modeloExepciones> ListaExcepcionPFecha(string cod_emp,  string fecha_ini, string fecha_fin, string usuario_mod)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloExepciones> lista = new List<modeloExepciones>();
                    string insert = "SELECT * FROM wmc_excepcion WHERE cod_emp =@cod_emp and FORMAT(fecha_hora, 'yyyy-MM-dd')  BETWEEN @fecha_ini AND @fecha_fin  ORDER BY id DESC ";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@fecha_ini", SqlDbType.VarChar).Value = fecha_ini;
                    conmand.Parameters.Add("@fecha_fin", SqlDbType.VarChar).Value = fecha_fin;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloExepciones item = new modeloExepciones();
                        item.id = Convert.ToString(dr["id"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.proceso = Convert.ToString(dr["proceso"]);
                        item.metodo = Convert.ToString(dr["metodo"]);
                        item.error = Convert.ToString(dr["error"]);
                        DateTime fecha_formato = Convert.ToDateTime(dr["fecha_hora"]);
                        item.fecha_for = fecha_formato.ToString("yyyy-MM-dd");
                        item.fecha_hora = Convert.ToDateTime(dr["fecha_hora"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {



                return null;
            }
        }

        //Busca pro metodo y fechas
        public List<modeloExepciones> ListaExcepcionMetodoFechas(string cod_emp,  DateTime fecha_ini, DateTime fecha_fin, string usuario_mod, string metodo)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloExepciones> lista = new List<modeloExepciones>();
                    string insert = "SELECT * FROM wmc_excepcion WHERE wmc_excepcion.fecha_hora BETWEEN @fecha_ini AND @fecha_fin AND metodo=@metodo AND cod_emp =@cod_emp ORDER BY id DESC";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@metodo", SqlDbType.VarChar).Value = metodo;
                    conmand.Parameters.Add("@fecha_ini", SqlDbType.VarChar).Value = fecha_ini;
                    conmand.Parameters.Add("@fecha_fin", SqlDbType.VarChar).Value = fecha_fin;
        
                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloExepciones item = new modeloExepciones();
                        item.id = Convert.ToString(dr["id"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.proceso = Convert.ToString(dr["proceso"]);
                        item.metodo = Convert.ToString(dr["metodo"]);
                        item.error = Convert.ToString(dr["error"]);
                        DateTime fecha_formato = Convert.ToDateTime(dr["fecha_hora"]);
                        item.fecha_for = fecha_formato.ToString("yyyy-MM-dd");
                        item.fecha_hora = Convert.ToDateTime(dr["fecha_hora"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                return null;
            }
        }


        //Busca pro proceso y fechas
        public List<modeloExepciones> ListaExcepcionProcesoFe(string cod_emp, string proceso, DateTime fecha_ini, DateTime fecha_fin, string usuario_mod)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloExepciones> lista = new List<modeloExepciones>();
                    string insert = "SELECT * FROM wmc_excepcion WHERE wmc_excepcion.fecha_hora BETWEEN @fecha_ini AND @fecha_fin AND proceso=@proceso AND cod_emp =@cod_emp ORDER BY id DESC";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@proceso", SqlDbType.VarChar).Value = proceso;
                    conmand.Parameters.Add("@fecha_ini", SqlDbType.VarChar).Value = fecha_ini;
                    conmand.Parameters.Add("@fecha_fin", SqlDbType.VarChar).Value = fecha_fin;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloExepciones item = new modeloExepciones();
                        item.id = Convert.ToString(dr["id"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.proceso = Convert.ToString(dr["proceso"]);
                        item.metodo = Convert.ToString(dr["metodo"]);
                        item.error = Convert.ToString(dr["error"]);
                        DateTime fecha_formato = Convert.ToDateTime(dr["fecha_hora"]);
                        item.fecha_for = fecha_formato.ToString("yyyy-MM-dd");
                        item.fecha_hora = Convert.ToDateTime(dr["fecha_hora"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {



                return null;
            }
        }

        //Busca por usuario y fechas
        public List<modeloExepciones> ListaExcepcionUsuarioFe(string cod_emp, string usuario, DateTime fecha_ini, DateTime fecha_fin, string usuario_mod)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloExepciones> lista = new List<modeloExepciones>();
                    string insert = "SELECT * FROM wmc_excepcion WHERE wmc_excepcion.fecha_hora BETWEEN @fecha_ini AND @fecha_fin AND usuario_mod=@usuario AND cod_emp =@cod_emp ORDER BY id DESC";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@fecha_ini", SqlDbType.VarChar).Value = fecha_ini;
                    conmand.Parameters.Add("@fecha_fin", SqlDbType.VarChar).Value = fecha_fin;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloExepciones item = new modeloExepciones();
                        item.id = Convert.ToString(dr["id"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.proceso = Convert.ToString(dr["proceso"]);
                        item.metodo = Convert.ToString(dr["metodo"]);
                        item.error = Convert.ToString(dr["error"]);
                        DateTime fecha_formato = Convert.ToDateTime(dr["fecha_hora"]);
                        item.fecha_for = fecha_formato.ToString("yyyy-MM-dd");
                        item.fecha_hora = Convert.ToDateTime(dr["fecha_hora"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {



                return null;
            }
        }
    }
}
