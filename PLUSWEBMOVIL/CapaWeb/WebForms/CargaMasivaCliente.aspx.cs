﻿using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;
using CapaProceso.FacturaMasiva;
using System.IO;

namespace CapaWeb.WebForms
{
    public partial class CargaMasivaCliente : System.Web.UI.Page
    {
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();
        CargaFacturaMasiva carga = new CargaFacturaMasiva();
        List<modeloFacturaEMasiva> lista = new List<modeloFacturaEMasiva>();
        modeloFacturaEMasiva modeloFacturas = new modeloFacturaEMasiva();

        public string ComPwm;
        public string socio;
        public string AmUsrLog;
        public string cod_proceso;
        public string sesion;
        public string AmComCod;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //lbl_error.Text = "";
                RecuperarCokie();
                ListaModelowmspclogo = consultaLogo.BuscartaLogo(ComPwm, AmUsrLog);
                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());
            }
        }
        public void RecuperarCokie()
        {
            try
            {
                // lbl_error.Text = "";

                if (Request.Cookies["ComPwm"] != null)
                {
                    ComPwm = Request.Cookies["ComPwm"].Value;
                }
                else
                {
                    Response.Redirect("../Inicio.asp");
                }

                if (Request.Cookies["AmScNCod"] != null)
                {
                    socio = Request.Cookies["AmScNCod"].Value;
                }
                if (Request.Cookies["AmSesId"] != null)
                {
                    sesion = Request.Cookies["AmSesId"].Value;
                }

                if (Request.Cookies["AmComCod"] != null)
                {
                    AmComCod = Request.Cookies["AmComCod"].Value;
                }
                if (Request.Cookies["AmUsrLog"] != null)
                {
                    AmUsrLog = Request.Cookies["AmUsrLog"].Value;

                }
                if (Request.Cookies["ProcAud"] != null)
                {
                    cod_proceso = Request.Cookies["ProcAud"].Value;
                }
                else
                {
                    cod_proceso = Convert.ToString(Request.QueryString["cod_proceso"]);
                    if (cod_proceso != null)
                    {
                        //Crear cookie de cod_proceso
                        Response.Cookies["ProcAud"].Value = cod_proceso;
                    }
                }
                //Buscar tipo de archivo que va a cargar(excel-01, 02(EValle 24-03-21))
                string formato = consultaLogo.BuscarFormatoCargaMasiva(ComPwm, AmComCod);
                //Codigo empresa
                string empresa_codigo = ComPwm;
                string empresa_canorus = AmComCod;
                Response.Cookies["empresa_codigo"].Value = empresa_codigo;
                Response.Cookies["empresa_canorus"].Value = empresa_canorus;
                Response.Cookies["socio_codigo"].Value = socio;
                Response.Cookies["usuario"].Value = AmUsrLog;
                Response.Cookies["sesion"].Value = sesion;
                Response.Cookies["formato"].Value = formato.Trim();
            }
            catch (Exception ex)
            {
                GuardarExcepciones("RecuperarCokie", ex.ToString());

            }

        }
        public void GuardarExcepciones(string metodo, string error)
        {

            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "CargaMasivaCliente.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;

            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            // lbl_error.Text = "No se pudo completar la acción" + metodo + "." + " Por favor notificar al administrador.";

        }

    }
}