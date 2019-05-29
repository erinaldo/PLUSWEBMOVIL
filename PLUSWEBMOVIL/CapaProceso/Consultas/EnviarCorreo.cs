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


namespace CapaProceso.Consultas
{
    public class EnviarCorreo
    {
        MailMessage email = new MailMessage();
        SmtpClient smtp = new SmtpClient();


        public bool enviarcorreo(string asunto, string mensaje, string correo , List<string> adjunto)
        {

            try
            {
               
                /* recuperar de base de tabla HostMail */
                string Usuario = "prueba@cepes.ec";
                string Contrasenia = "Plus2019*";
                string smtpHost = "mail.cepes.ec";
                int puerto = 587;
                bool ssl = false;
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
                smtp.Host = smtpHost;
                smtp.Port = puerto;                
                smtp.Credentials = new NetworkCredential(Usuario, Contrasenia);
                smtp.EnableSsl = ssl;
                smtp.Send(email);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }

}

