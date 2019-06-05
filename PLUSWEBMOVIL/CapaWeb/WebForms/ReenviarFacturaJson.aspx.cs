﻿using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;

namespace CapaWeb.WebForms
{
    public partial class ReenviarFacturaJson : System.Web.UI.Page
    {

      
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

       
        public string ComPwm;
        public string AmUsrLog;
        public string nro_trans = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            RecuperarCokie();
            ListaModelowmspclogo = consultaLogo.BuscartaLogo(ComPwm, AmUsrLog);
            foreach (var item in ListaModelowmspclogo)
            {
                Modelowmspclogo = item;
                break;
            }
            if (!IsPostBack)
            {

                QueryString qs = ulrDesencriptada();
                Int64 ide = Int64.Parse(qs["Id"].ToString());
               mensaje.Text = ide.ToString();
               

            }
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

        public QueryString ulrDesencriptada()
        {
            //1- guardo el Querystring encriptado que viene desde el request en mi objeto
            QueryString qs = new QueryString(Request.QueryString);

            ////2- Descencripto y de esta manera obtengo un array Clave/Valor normal
            qs = Encryption.DecryptQueryString(qs);
            return qs;
        }

        protected void btn_reenviar_Click(object sender, EventArgs e)
        {
            ConsumoRest consumoRest = new ConsumoRest();
            bool respuesta = false;
            respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", "VTA", mensaje.Text);
            if (respuesta)
            {
                mensaje.Text = "Su factura fue enviada exitosamente";
                mensaje.Visible = true;
            }
            else
            {
                mensaje.Text = "Hubo un error al enviar, revice por favor el detalle de errores.";
                mensaje.Visible = true;
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarFacturas.aspx");
        }
    }
}