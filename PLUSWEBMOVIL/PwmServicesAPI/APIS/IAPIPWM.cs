using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwmServicesAPI.APIS
{
    public class IAPIPWM : APIPWM
    {
        public string enviarEmail(string asunto, string email, string cuerpo)
        {
            /* aqui programar desconposicion de json, envio de email y retornar respuesta tipo string */
            return "Email enviado" + asunto + email + cuerpo;
        }
    }
}
