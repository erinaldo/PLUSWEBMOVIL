using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Consultas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.EstadoDocEle
{
    public class ConsultaEstadoDE
    {
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();
        public GuardarrespuestaDS guardarResJson = new GuardarrespuestaDS();
        public JsonEstadoDE consultaResJson = new JsonEstadoDE();
        public ProcesoRestEstado procesoRest = new ProcesoRestEstado();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "ConsultaEstadoDE.cs";

        public string ConsultaEstadoDocumento(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                //Consultar usuario y contraseña
                Modelowmspclogo = null;
                Modelowmspclogo = BuscarUsuarioLogo(Ccf_cod_emp, Ccf_usuario);

                string username = Modelowmspclogo.username;
                string password = Modelowmspclogo.password;
                string linkemidocuelec = Modelowmspclogo.linkestadodoc;

                string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{username}:{password}"));

                //Consultar datos para enviar el json arma la consulta y la estructura de json factura
                string jsonRes = "";
                string jsonrRespuesta = "";
                jsonRes = JsonConvert.SerializeObject(consultaResJson.LlenarJSONconsulta(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans), Formatting.Indented);

                JsonEstadoDocElec jsonRespuestaDE = new JsonEstadoDocElec();
                //Envia el json armado para y obtiene la respuesta
                jsonRespuestaDE = procesoRest.EnviarJSONDS(linkemidocuelec, credentials, jsonRes);
                jsonrRespuesta = JsonConvert.SerializeObject(jsonRespuestaDE);
                jsonRespuestaDE.json = jsonRes;
                jsonRespuestaDE.jsonrRespuesta= jsonrRespuesta;
                jsonRespuestaDE.nro_trans = Ccf_nro_trans;
                jsonRespuestaDE.cod_emp = Ccf_cod_emp;
                jsonRespuestaDE.usuario_mod = Ccf_usuario;
                jsonRespuestaDE.fecha_mod = DateTime.Now;
                guardarResJson.InsertarEstadoDocumento(jsonRespuestaDE);//Inserta la respuesta obtenida del servicio rest en la tabla
                return "";
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaEstadoDocumento", e.ToString(), DateTime.Now, Ccf_usuario);
                return "Se produjo un error al enviar " + e.ToString();
            }
        }

        public modelowmspclogo BuscarUsuarioLogo(string Ccf_cod_emp, string Ccf_usuario)
        {
            try
            {
                ListaModelowmspclogo = consultaLogo.BuscartaLogo(Ccf_cod_emp, Ccf_usuario);

                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }

                return Modelowmspclogo;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarUsuarioLogo", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }
    }
}

