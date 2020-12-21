using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PwmServicesAPI.APIS
{

    [ServiceContract]
    public interface APIPWM
    {
        [OperationContract]
        string enviarEmail(string asunto, string email, string cuerpo);
    }
}
