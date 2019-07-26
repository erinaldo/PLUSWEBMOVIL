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
        //Lista de host mail
        public List<modeloHostmail> ListaHostMail(string cod_emp)
        {

            using (cn = conexion.genearConexion())
            {
                List<modeloHostmail> lista = new List<modeloHostmail>();

                string consulta = ("SELECT * FROM wmm_host_mail where cod_emp = @cod_emp");
                SqlCommand conmand = new SqlCommand(consulta, cn);

             
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value =cod_emp;
    
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

                return e.ToString();
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

                return e.ToString();
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

                return e.ToString();
            }

        }
    }
}
