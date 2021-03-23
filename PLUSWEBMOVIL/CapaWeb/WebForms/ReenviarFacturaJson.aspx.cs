using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;
using CapaProceso.GenerarPDF.FacturaElectronica;
using System.IO;
using CapaDatos.Sql;
using CapaProceso.FacturaMasiva;

namespace CapaWeb.WebForms
{
    public partial class ReenviarFacturaJson : System.Web.UI.Page
    {

      
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        public CabezeraFactura ActualizarEstadoFact = new CabezeraFactura();


        modelocabecerafactura cabecerafactura = new modelocabecerafactura();
        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

        List<ModeloDetalleFactura> ModeloDetalleFactura = new List<ModeloDetalleFactura>();
        Consultawmtfacturasdet ConsultaDeta = new Consultawmtfacturasdet();
        ModeloDetalleFactura detallefactura = new ModeloDetalleFactura();

        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        ModeloDetalleFactura consdetalle = new ModeloDetalleFactura();
        List<modelowmtfacturascab> listaConsCab = null;
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        public List<JsonRespuestaDE> ListaModelorespuestaDs = null;
        public JsonRespuestaDE ModeloResQr = new JsonRespuestaDE();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();

        GenerarPDFDocumentos generer_pdfElectronico = new GenerarPDFDocumentos();
        Enviarcorreocliente enviarcorreocliente = new Enviarcorreocliente();

        public string ComPwm;
        public string AmUsrLog;
        public string nro_trans = null;
        public string Ccf_tipo1 = "C";
        public string Ccf_tipo2 = "POSE";
        public string Ccf_nro_trans = "0";
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
            ModeloExcepcion.proceso = "ReenviarFacturaJson.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
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

        public modelowmtfacturascab buscarTipoFac(string nro_trans)
        {
            try
            {
                lbl_error.Text = "";

                listaConsCab = ConsultaCabe.ConsultaTipoFactura(nro_trans);
                int count = 0;
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                    count++;
                    conscabcera = item;

                }
                return conscabcera;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("buscarTipoFac", ex.ToString());
                return null;
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

                conscabcera = null;
                conscabcera = buscarTipoFac(lbl_nro_trans.Text);
              

                string respuesta = "";

                switch (Modelowmspclogo.version_fe.Trim())  //AVERIGUAR QUE VERSION  DE FACTURACION USA
                {
                    case "2":

                        if (conscabcera.doc_adjunto == null || conscabcera.doc_adjunto == "")
                        {
                            ConsumoRestFEV3 consumoRest1 = new ConsumoRestFEV3();

                            respuesta = consumoRest1.EnviarFactura(ComPwm, AmUsrLog, "C", conscabcera.tipo_nce, lbl_nro_trans.Text);
                        }
                        else
                        {
                            ConsumoRestFEV3_PDF consumoRest1 = new ConsumoRestFEV3_PDF();
                            respuesta = consumoRest1.EnviarFactura(ComPwm, AmUsrLog, "C", conscabcera.tipo_nce, lbl_nro_trans.Text);
                        }
                        break;
                    case "1":
                        ConsumoRestFEV2 consumoRest = new ConsumoRestFEV2();
                        respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", conscabcera.tipo_nce, lbl_nro_trans.Text);
                        break;
                }


                if (respuesta == "")
                {
                    mensaje.Text = "Su factura fue enviada exitosamente";
                    btn_reenviar.Enabled = false;
                    ActualizarEstadoFact.ActualizarEstadoFactura(lbl_nro_trans.Text, "F");
                    EnviarCorreoRemitente(lbl_nro_trans.Text, conscabcera.tipo_nce);

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

        public void EnviarCorreoRemitente(string nro_trans, string tipo)
        {
            try
            {
                
                Ccf_tipo2 = tipo;
                Ccf_nro_trans = nro_trans;
                //Buscar el xml TRAE TODAS LAS RESPUESTAS
                ListaModelorespuestaDs = consultaRespuestaDS.ConsultaRespuestaQr(nro_trans);
                foreach (var item in ListaModelorespuestaDs)
                {
                    if (!string.IsNullOrEmpty(item.xml.Trim()))
                    {
                        ModeloResQr = item;
                        break;
                    }

                }
                
                
                string StringXml = ModeloResQr.xml;
                string pathTemporal = Modelowmspclogo.pathtmpfac;
                string nombreXml = ModeloResQr.cufe.Trim() + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".xml";
                string pathXml = pathTemporal + nombreXml;
                File.WriteAllText(pathXml, StringXml);
                //-------------OBTENER EL XML Y PDF PARA EL ENVIO-------------------//
                string cod_proceso = "RCOMFELECT";
                string pathPdf = generer_pdfElectronico.GenerarPDFFacturaElectronica(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                Boolean error = enviarcorreocliente.EnviarCorreoRemitente(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, pathPdf, pathXml);
            }
            catch (Exception ex)
            {
                GuardarExcepciones("EnviarCorreoRemitente", ex.ToString());

            }
        }
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                conscabcera = null;
                conscabcera = buscarTipoFac(lbl_nro_trans.Text);

                if (conscabcera.tipo_nce.ToString() == "VTAE")
                {
                    Response.Redirect("BuscarFacturas.aspx");
                }
                else
                {

                    Response.Redirect("BuscarFacturaPOS.aspx");
                }
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
                conscabcera = null;
                conscabcera = buscarTipoFac(lbl_nro_trans.Text);
                
                string respuesta = "";
                switch (Modelowmspclogo.version_fe.Trim())  //AVERIGUAR QUE VERSION  DE FACTURACION USA
                {
                    case "2":

                        if (conscabcera.doc_adjunto == null || conscabcera.doc_adjunto == "")
                        {
                            ConsumoRestFEV3 consumoRest1 = new ConsumoRestFEV3();

                            respuesta = consumoRest1.enviarPDF(ComPwm, AmUsrLog, "C", conscabcera.tipo_nce, lbl_nro_trans.Text);
                        }
                        else
                        {
                            ConsumoRestFEV3_PDF consumoRest1 = new ConsumoRestFEV3_PDF();
                            respuesta = consumoRest1.enviarPDF(ComPwm, AmUsrLog, "C", conscabcera.tipo_nce, lbl_nro_trans.Text);
                        }
                        break;
                    case "1":
                        ConsumoRestFEV2 consumoRest = new ConsumoRestFEV2();
                        respuesta = consumoRest.enviarPDF(ComPwm, AmUsrLog, "C", conscabcera.tipo_nce, lbl_nro_trans.Text);
                        break;
                }
                
                if (respuesta == "")
                {
                    mensaje.Text = "Su factura fue enviada exitosamente"; ;
                    btn_reenviar.Enabled = false;
                    ActualizarEstadoFact.ActualizarEstadoFactura(lbl_nro_trans.Text, "F");
                    EnviarCorreoRemitente(lbl_nro_trans.Text, conscabcera.tipo_nce);

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