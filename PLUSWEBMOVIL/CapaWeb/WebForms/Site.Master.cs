using CapaDatos.Modelos;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaWeb.WebForms
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public List<modelowmusuario> listamodelowmusuario = new List<modelowmusuario>();
        public modelowmusuario Modelowmusuario = new modelowmusuario();
        public string ComPwm;
        public string AmUsrLog;
        protected void Page_Load(object sender, EventArgs e)
        {
           
                RecuperarCokie();
                ListaModelowmspclogo = consultaLogo.BuscartaLogo(ComPwm, AmUsrLog);
                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }

                listamodelowmusuario = consultaLogo.BuscarUsuario(AmUsrLog);
                foreach (var item in listamodelowmusuario)
                {
                    Modelowmusuario = item;
                    break;
                }
           
            
        }

        public void RecuperarCokie()
        {
            if (Request.Cookies["ComPwm"] != null)
            {
                ComPwm = Request.Cookies["ComPwm"].Value;
            }

            if (Request.Cookies["ComPwm"] != null)
            {
                AmUsrLog = Request.Cookies["AmUsrLog"].Value;

            }
        }
        }
}
