using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;

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
        public string ComPwm;
        public string AmUsrLog;
        public string nro_trans = null;
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
                string Tipo_fac = null;
                if (conscabcera.tipo_nce.ToString() == "VTAE")
                {
                    Tipo_fac = "VTAE";
                }
                else
                {

                    Tipo_fac = "POSE";
                }

                string respuesta = "";

                if (Modelowmspclogo.version_fe == "1")
                {

                    ConsumoRest consumoRest = new ConsumoRest();
                    respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", Tipo_fac, lbl_nro_trans.Text);
                }
                else
                {
                    ConsumoRestFEV2 consumoRest = new ConsumoRestFEV2();                    
                    respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", Tipo_fac, lbl_nro_trans.Text);
                }
               
                
                if (respuesta == "")
                {
                    mensaje.Text = "Su factura fue enviada exitosamente";
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
                string Tipo_fac = null;
                if (conscabcera.tipo_nce.ToString() == "VTAE")
                {
                    Tipo_fac = "VTAE";
                }
                else
                {

                    Tipo_fac = "POSE";
                }
                
                string respuesta = "";
                if (Modelowmspclogo.version_fe == "1")
                {

                    ConsumoRest consumoRest = new ConsumoRest();
               
                    respuesta = consumoRest.enviarPDF(ComPwm, AmUsrLog, "C", Tipo_fac, lbl_nro_trans.Text);
                }
                else
                {
                    ConsumoRestFEV2 consumoRest = new ConsumoRestFEV2();
                    respuesta = consumoRest.enviarPDF(ComPwm, AmUsrLog, "C", Tipo_fac, lbl_nro_trans.Text);
                }
               
                if (respuesta == "")
                {
                    mensaje.Text = "Su factura fue enviada exitosamente"; ;
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