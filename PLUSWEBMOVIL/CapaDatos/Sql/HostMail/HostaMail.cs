using CapaDatos.Modelos.ModeloHost;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql.HostMail
{
   public  class HostaMail
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
       modeloHostmail modelohostMail = new modeloHostmail();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "HostMail.cs";

        //Lista de wmm_correos
        public List<modelowmm_correo> ListaFormatoCorreo(string cod_emp, string cod_proceso, string cod_mail, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelowmm_correo> lista = new List<modelowmm_correo>();

                    string consulta = ("SELECT * FROM wmm_correos where cod_emp = @cod_emp and cod_proceso=@cod_proceso and cod_mail=@cod_mail");
                    SqlCommand conmand = new SqlCommand(consulta, cn);


                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@cod_proceso", SqlDbType.VarChar).Value = cod_proceso;
                    conmand.Parameters.Add("@cod_mail", SqlDbType.VarChar).Value = cod_mail;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modelowmm_correo item = new modelowmm_correo();
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_proceso = Convert.ToString(dr["cod_proceso"]);
                        item.cod_mail = Convert.ToString(dr["cod_mail"]);
                        item.nom_mail = Convert.ToString(dr["nom_mail"]);
                        item.observaciones = Convert.ToString(dr["observaciones"]);
                        item.perfil_mail = Convert.ToString(dr["perfil_mail"]);
                        item.automatico = Convert.ToString(dr["automatico"]);
                        item.sp = Convert.ToString(dr["sp"]);
                        item.titulo = Convert.ToString(dr["titulo"]);
                        item.texto = Convert.ToString(dr["texto"]);
                        item.firma = Convert.ToString(dr["firma"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.job_name = Convert.ToString(dr["job_name"]);
                        item.step_id = Convert.ToString(dr["step_id"]);
                        item.schedule_id = Convert.ToString(dr["schedule_id"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        item.repeticiones= Convert.ToString(dr["repeticiones"]);

                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaFormatoCorreo", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }

        //Lista de wmm_correos_receptor
        public List<modelowmm_correo_receptor> ListaCorreoReceptor(string cod_emp, string cod_proceso, string cod_mail, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelowmm_correo_receptor> lista = new List<modelowmm_correo_receptor>();

                    string consulta = ("SELECT * FROM wmm_correos_receptor where cod_emp = @cod_emp and cod_proceso=@cod_proceso and cod_mail=@cod_mail");
                    SqlCommand conmand = new SqlCommand(consulta, cn);


                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@cod_proceso", SqlDbType.VarChar).Value = cod_proceso;
                    conmand.Parameters.Add("@cod_mail", SqlDbType.VarChar).Value = cod_mail;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                       modelowmm_correo_receptor item = new modelowmm_correo_receptor();
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.cod_proceso = Convert.ToString(dr["cod_proceso"]);
                        item.cod_mail = Convert.ToString(dr["cod_mail"]);
                        item.usuario = Convert.ToString(dr["usuario"]);
                        item.email = Convert.ToString(dr["email"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
            
                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaCorreoReceptor", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        //Lista de host mail
        public List<modeloHostmail> ListaHostMail(string cod_emp)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloHostmail> lista = new List<modeloHostmail>();

                    string consulta = ("SELECT * FROM wmm_host_mail where cod_emp = @cod_emp");
                    SqlCommand conmand = new SqlCommand(consulta, cn);


                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloHostmail item = new modeloHostmail();
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.nom_empresa = Convert.ToString(dr["nom_empresa"]);
                        item.remitente = Convert.ToString(dr["remitente"]);
                        item.correo = Convert.ToString(dr["correo"]);
                        item.contrasenia = Convert.ToString(dr["contrasenia"]);
                        item.puerto = Convert.ToInt32(dr["puerto"]);
                        item.smtp = Convert.ToString(dr["smtp"]);
                        item.autentificacion = Convert.ToInt32(dr["autentificacion"]);
                        item.secure = Convert.ToInt32(dr["secure"]);
                        item.subject = Convert.ToString(dr["subject"]);
                        item.html_text = Convert.ToString(dr["html_text"]);
                        item.firma = Convert.ToString(dr["firma"]);

                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaHostMail", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }

        //Eliminar host maiil
        public string EliminarHostMail(modeloHostmail hostMail)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "DELETE FROM wmm_host_mail WHERE  cod_emp = @cod_emp";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = hostMail.cod_emp;
                    int dr = conmand.ExecuteNonQuery();
                    return "Host Mail eliminado correctamente";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(hostMail.cod_emp, metodo, "EliminarHostMail", e.ToString(), DateTime.Now,"DLT");
                return "No se pudo completar la acción." + "EliminarHostMail." + " Por favor notificar al administrador.";
            }

        }
        public string ActualizarHostMail(modeloHostmail hostMail)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "UPDATE wmm_host_mail SET  remitente = @remitente, correo = @correo, contrasenia =@contrasenia, puerto =@puerto, smtp =@smtp, autentificacion = @autentificacion, secure =@secure, subject= @subject, html_text =@html_text, firma =@firma WHERE cod_emp = @cod_emp";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = hostMail.cod_emp;
                    conmand.Parameters.Add("@remitente", SqlDbType.VarChar).Value = hostMail.remitente.Trim();
                    conmand.Parameters.Add("@correo", SqlDbType.VarChar).Value = hostMail.correo;
                    conmand.Parameters.Add("@contrasenia", SqlDbType.VarChar).Value = hostMail.contrasenia;
                    conmand.Parameters.Add("@puerto", SqlDbType.VarChar).Value = hostMail.puerto;
                    conmand.Parameters.Add("@smtp", SqlDbType.VarChar).Value = hostMail.smtp;
                    conmand.Parameters.Add("@autentificacion", SqlDbType.VarChar).Value = hostMail.autentificacion;
                    conmand.Parameters.Add("@secure", SqlDbType.VarChar).Value = hostMail.secure;
                    conmand.Parameters.Add("@subject", SqlDbType.VarChar).Value = hostMail.subject;
                    conmand.Parameters.Add("@html_text", SqlDbType.VarChar).Value = hostMail.html_text;
                    conmand.Parameters.Add("@firma", SqlDbType.VarChar).Value = hostMail.firma;

                     
                    int dr = conmand.ExecuteNonQuery();
                    return "Host mail guardado correctamente";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(hostMail.cod_emp, metodo, "ActualizarHostMail", e.ToString(), DateTime.Now, "UDP");
                return "No se pudo completar la acción." + "ActualizarHostMail." + " Por favor notificar al administrador.";
            }


        }
        public string InsertarHostmaila(modeloHostmail hostMail)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "INSERT INTO wmm_host_mail (cod_emp, nom_empresa, remitente, correo, contrasenia, puerto, smtp, autentificacion, secure, subject, html_text, firma) VALUES(@cod_emp, @nom_empresa, @remitente, @correo, @contrasenia, @puerto, @smtp, @autentificacion, @secure, @subject, @html_text, @firma)";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = hostMail.cod_emp;
                conmand.Parameters.Add("@nom_empresa", SqlDbType.VarChar).Value = hostMail.nom_empresa;
                conmand.Parameters.Add("@remitente", SqlDbType.VarChar).Value = hostMail.remitente.Trim();
                conmand.Parameters.Add("@correo", SqlDbType.VarChar).Value = hostMail.correo;
                conmand.Parameters.Add("@contrasenia", SqlDbType.VarChar).Value = hostMail.contrasenia;
                conmand.Parameters.Add("@puerto", SqlDbType.VarChar).Value = hostMail.puerto;
                conmand.Parameters.Add("@smtp", SqlDbType.VarChar).Value = hostMail.smtp;
                conmand.Parameters.Add("@autentificacion", SqlDbType.VarChar).Value = hostMail.autentificacion;
                conmand.Parameters.Add("@secure", SqlDbType.VarChar).Value = hostMail.secure;
                conmand.Parameters.Add("@subject", SqlDbType.VarChar).Value = hostMail.subject;
                conmand.Parameters.Add("@html_text", SqlDbType.VarChar).Value = hostMail.html_text;
                conmand.Parameters.Add("@firma", SqlDbType.VarChar).Value = hostMail.firma;
                int dr = conmand.ExecuteNonQuery();
                return "Host Mail guardada correctamente";
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(hostMail.cod_emp, metodo, "InsertarHostmaila", e.ToString(), DateTime.Now, "INS");
                return "No se pudo completar la acción." + "InsertarHostmaila." + " Por favor notificar al administrador.";
            }

        }
    }
}
