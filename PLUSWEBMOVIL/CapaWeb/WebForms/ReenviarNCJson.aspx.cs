﻿using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;

namespace CapaWeb.WebForms
{
    public partial class ReenviarNCJson : System.Web.UI.Page
    {
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();
        List<modelowmtfacturascab> listaConsCab = null;
        modelowmtfacturascab conscabcera = new modelowmtfacturascab();

        public CabezeraFactura ActualizarEstadoFact = new CabezeraFactura();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        public string ComPwm;
        public string AmUsrLog;
        public string nro_trans = null;
        public string Ccf_estado = null;
        public string Ccf_cliente = null;
        public string Ccf_cod_docum = null;
        public string Ccf_serie_docum = null;
        public string Ccf_nro_docum = null;
        public string Ccf_diai = null;
        public string Ccf_mesi = null;
        public string Ccf_anioi = null;
        public string Ccf_diaf = null;
        public string Ccf_mesf = null;
        public string Ccf_aniof = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";

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
                    lbl_nro_trans.Text = ide.ToString();


                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());

            }
        }

        public void GuardarExcepciones(string metodo, string error)
        {
            //obtener numero de transaccion

            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "ReenviarNCJson.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Today;
            ModeloExcepcion.usuario_mod = AmUsrLog;

            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }
        public void RecuperarCokie()
        {
            try
            {
                lbl_error.Text = "";

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
            catch (Exception ex)
            {
                GuardarExcepciones("RecuperarCokie", ex.ToString());

            }
        }

        public QueryString ulrDesencriptada()
        {
            try
            {
                lbl_error.Text = "";


                //1- guardo el Querystring encriptado que viene desde el request en mi objeto
                QueryString qs = new QueryString(Request.QueryString);

                ////2- Descencripto y de esta manera obtengo un array Clave/Valor normal
                qs = Encryption.DecryptQueryString(qs);
                return qs;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("ulrDesencriptada", ex.ToString());
                return null;
            }
        }

        protected void btn_reenviar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                //Consulta nro_trans factura 
                listaConsCab = ConsultaCabe.ConsultaNCTransPadre(lbl_nro_trans.Text);
                
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                     conscabcera = item;

                }
                lbl_nro_factura.Text = conscabcera.nro_trans_padre;



                //AVERIGUAR LA VERSION DE NC QUE USA
                string respuesta = "";
                if (Modelowmspclogo.version_fe == "1")
                {
                    ConsumoRestNCFin consumoRest = new ConsumoRestNCFin();
                    respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", "NC", lbl_nro_trans.Text, conscabcera.nro_trans_padre);
                }
                else
                {
                    ConsumoRestNCFinV2 consumoRest = new ConsumoRestNCFinV2();
                    respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", "NC", lbl_nro_trans.Text, conscabcera.nro_trans_padre);
                }
               
               
                if (respuesta == "")
                {
                    mensaje.Text = "La Nota Crédito fue enviada exitosamente";
                    btn_reenviar.Enabled = false;
                    ActualizarEstadoFact.ActualizarEstadoFactura(lbl_nro_trans.Text, "F");


                }
                else
                {
                    mensaje.Text = respuesta;

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_reenviar_Click", ex.ToString());

            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                Response.Redirect("FormBuscarNotaCredito.aspx");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_cancelar_Click", ex.ToString());

            }
        }

        protected void btn_reenviarpdf_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                //Consulta nro_trans factura 
                listaConsCab = ConsultaCabe.ConsultaNCTransPadre(lbl_nro_trans.Text);
                int count = 0;
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                    count++;
                    conscabcera = item;

                }
                lbl_nro_factura.Text = conscabcera.nro_trans_padre;


                //AVERIGUAR LA VERSION DE NC QUE USA
                string respuesta = "";
                if (Modelowmspclogo.version_fe == "1")
                {
                    ConsumoRestNCFin consumoRest = new ConsumoRestNCFin();
                    respuesta = consumoRest.enviarPDF(ComPwm, AmUsrLog, "C", "NC", lbl_nro_trans.Text);
                }
                else
                {
                    ConsumoRestNCFinV2 consumoRest = new ConsumoRestNCFinV2();
                    respuesta = consumoRest.enviarPDF(ComPwm, AmUsrLog, "C", "NC", lbl_nro_trans.Text);
                }

             
               
                if (respuesta == "")
                {
                    mensaje.Text = "La Nota Crédito fue enviada exitosamente";
                    btn_reenviar.Enabled = false;
                    ActualizarEstadoFact.ActualizarEstadoFactura(lbl_nro_trans.Text, "F");


                }
                else
                {
                    mensaje.Text = respuesta;

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_reenviarpdf_Click", ex.ToString());

            }

        }
    }
}