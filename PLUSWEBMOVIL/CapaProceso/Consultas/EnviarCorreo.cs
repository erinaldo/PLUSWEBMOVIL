using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Net.Http;

using System.Data;
using CapaDatos.Modelos.ModeloHost;
using CapaProceso.Consultas.ConsultaHost;
using CapaDatos.Sql;

namespace CapaProceso.Consultas
{
    public class EnviarCorreo
    {
        MailMessage email = new MailMessage();
        SmtpClient smtp = new SmtpClient();
        public ConsultaHostmail Consultahost = new ConsultaHostmail();
        public modeloHostmail ModeloHost = new modeloHostmail();
        public List<modeloHostmail> ListaModeloHost = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public modeloHostmail buscarDatosHostEmpresa(string cod_emp)
        {
            try
            {

                ListaModeloHost = Consultahost.BuscarHostmail(cod_emp);
                int count = 0;
                ModeloHost = null;
                foreach (modeloHostmail item in ListaModeloHost)
                {
                    count++;
                    ModeloHost = item;

                }
                return ModeloHost;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "EnviarCorreo.cs", "buscarDatosHostEmpresa", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }

        public bool enviarcorreo(string asunto, string mensaje, string correo , List<string> adjunto, string cod_emp)
        {

            try
            {
                ModeloHost = null;
                ModeloHost = buscarDatosHostEmpresa(cod_emp);
                /*Datos desde la base de pw*/
                string Usuario = ModeloHost.correo;
                string Contrasenia = ModeloHost.contrasenia;
                string smtpHost = ModeloHost.smtp;
                int puerto = ModeloHost.puerto;
                bool ssl;
                if (ModeloHost.secure ==1)
                { 
                 ssl = true;
                }
                else { ssl = false; }

                // recuperar de base de tabla HostMail 
                /*   string Usuario = "prueba@cepes.ec";
                   string Contrasenia = "Plus2019*";
                   string smtpHost = "mail.cepes.ec";
                   int puerto = 587;
                   bool ssl = false;*/
                /* recuperar de base de tabla HostMail */

                email.From = new MailAddress(Usuario);
                email.To.Add(new MailAddress(correo));
                email.Subject = asunto;
                email.Body = mensaje;

                if (adjunto.Equals("") == false)
                {
                    foreach (var item in adjunto)
                    {
                        if (item.Equals("") == false)
                        {
                            Attachment archivo = new Attachment(item);
                            email.Attachments.Add(archivo);
                        }
                        
                    }
                    

                }

                email.IsBodyHtml = true;
               // SmtpClient smtp = new SmtpClient("mail@pluscolombia.com", 587);
                smtp.Host = smtpHost;
                smtp.Port = puerto;
                smtp.EnableSsl = ssl;
              //  smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(Usuario, Contrasenia);            
                smtp.Send(email);

                return true;
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "EnviarCorreo.cs", " enviarcorreo", e.ToString(), DateTime.Now, "consulta");
                
                return false;
            }

        }

    }

}

