using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Consultas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaWeb.APIS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioPWM" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioPWM.svc o ServicioPWM.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioPWM : IServicioPWM
    {
        EnviarCorreo enviar = new EnviarCorreo();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "ServicioPWM.cs";
        public string enviarEmail(string asunto, string email, string cuerpo, string adjuntoBase64, string cod_emp, string usuario, string socio)
        {
            try
            {
                /* aqui programar desconposicion de json, envio de email y retornar respuesta tipo string */
                ListaModelowmspclogo = consultaLogo.BuscartaLogo(cod_emp, usuario);
                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }
                string archivoTemporal = Modelowmspclogo.pathtmpfac;//obtener dinamicamnente de la base de datos el pat temporal que este configurado para ese ambiente
                string nombreArchivoTemporal = socio+ DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString()+ "pago.pdf"; //generar un nombre unico para cada archivo pude ser pasado por pararametro desde genexus uniendo el codigo de socio de negocios +tipo de documento + numero de documento + fechahora en fometo militar
                string archivoFisicoAdjunto = archivoTemporal + nombreArchivoTemporal;
                byte[] bytes = Convert.FromBase64String(adjuntoBase64);
                File.WriteAllBytes(archivoFisicoAdjunto, bytes);

                List<string> Adjunto = new List<string>();
                Adjunto.Add(archivoFisicoAdjunto);
                enviar.enviarcorreo(asunto, cuerpo, email, Adjunto, cod_emp);
                return "enviado";
            }
            catch (Exception e)
            {
               
                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "enviarEmail", e.ToString(), DateTime.Now, usuario);
                return e.ToString();
            }
           
        }
    }
}
