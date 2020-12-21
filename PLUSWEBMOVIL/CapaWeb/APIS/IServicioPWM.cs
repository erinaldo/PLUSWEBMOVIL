using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaWeb.APIS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioPWM" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioPWM
    {
        [OperationContract]
        string enviarEmail(string asunto, string email, string cuerpo, string adjunto, string cod_emp, string usuario, string socio);
    }
}
