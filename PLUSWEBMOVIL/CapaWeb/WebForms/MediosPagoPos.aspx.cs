using CapaDatos.Modelos;
using CapaProceso.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaWeb.WebForms
{
    public partial class MediosPagoPos : System.Web.UI.Page
    {
       ConsultaMediosPago consultaMediosPago = new ConsultaMediosPago();
        public List<modeloMediosPago> listaMedios = null;
        modeloMediosPago modeloMedios = new modeloMediosPago();

        public string ComPwm;
        public string AmUsrLog;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            RecuperarCokie();

            if (!IsPostBack)
            {


              
                if (Request.Cookies["ComPwm"] != null)
                {
                    string ComPwm = Request.Cookies["ComPwm"].Value;

                }

                cargarListaDesplegables();
            }
        }

        public void cargarListaDesplegables()
        {
            

            //LIsta medios pago
            listaMedios = consultaMediosPago.BuscarMediosPago(ComPwm);
            cbx_medios.DataSource = listaMedios;
            cbx_medios.DataTextField = "observacion";
            cbx_medios.DataValueField = "cod_fpago";
            cbx_medios.DataBind();

           
        }

        public void RecuperarCokie()
        {
            if (Request.Cookies["ComPwm"] != null)
            {
                ComPwm = Request.Cookies["ComPwm"].Value;
            }
            else
            {
                Response.Redirect("../Inicio.asp");
            }


            if (Request.Cookies["AmUsrLog"] != null)
            {
                AmUsrLog = Request.Cookies["AmUsrLog"].Value;

            }
        }
    }
}