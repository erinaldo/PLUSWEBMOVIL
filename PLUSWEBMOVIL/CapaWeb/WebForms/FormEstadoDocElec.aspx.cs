using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaDatos.Modelos;

namespace CapaWeb.WebForms
{
    public partial class FormEstadoDocElec : System.Web.UI.Page
    {
        modelocabecerafactura cabecerafactura = new modelocabecerafactura();
        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

        List<ModeloDetalleFactura> ModeloDetalleFactura = new List<ModeloDetalleFactura>();
        Consultawmtfacturasdet ConsultaDeta = new Consultawmtfacturasdet();
        ModeloDetalleFactura detallefactura = new ModeloDetalleFactura();

        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        ModeloDetalleFactura consdetalle = new ModeloDetalleFactura();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        public List<JsonRespuestaDE> ListaModelorespuestaDs = null;
        public JsonRespuestaDE ModeloResQr = new JsonRespuestaDE();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();
        JsonEstadoDocElec modeloestado = new JsonEstadoDocElec();

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        public string numerador = "trans";

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

                    //Recibir opciones
                    switch (qs["TRN"].Substring(0, 3))
                    {
                        case "VER":
                            try
                            {
                                Int64 ide = Int64.Parse(qs["Id"].ToString());
                                Int64 lin = Int64.Parse(qs["linea"].ToString());

                                string nro_trans = ide.ToString();
                                mensaje.Text = nro_trans;
                                string linea = lin.ToString();
                                CargarFormularioRespuestaDS(nro_trans, linea);

                                break;
                            }

                            catch (Exception ex)
                            {
                                GuardarExcepciones("Page_Load", ex.ToString());

                            }
                            break;
                    }

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
            ModeloExcepcion.proceso = "FormEstadoDocElec.aspx";
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

        private void CargarFormularioRespuestaDS(string nro_trans, string linea)
        {
            try
            {
                lbl_error.Text = "";

                modeloestado = consultaRespuestaDS.EstadosDocs(nro_trans, linea);

                txt_nro_trans.Text = modeloestado.nro_trans;
                txt_linea.Text = Convert.ToString(modeloestado.linea);
                txt_email.Text = modeloestado.emailfe;
                txt_estado.Text = modeloestado.cargopdf;
                txt_operacion.Text = modeloestado.foperacion;
                txt_id.Text = modeloestado.id;
                txt_qrdata.Text = modeloestado.qrdata;
                txt_xml.Text = modeloestado.xml;
                txt_cufe.Text = modeloestado.cufe;
                txt_error.Text = modeloestado.error;
                txt_json.Text = modeloestado.json;
                txt_result.Text = modeloestado.jsonrRespuesta;
                FormularioRes.Visible = true;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("CargarFormularioRespuestaDS", ex.ToString());

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
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                QueryString qs = new QueryString();

                //2 voy a agregando los valores que deseo
                qs.Add("TRN", "MTR");
                qs.Add("Id", mensaje.Text);
                Response.Redirect("PortalFacturas.aspx" + Encryption.EncryptQueryString(qs).ToString());
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Cancelar_Click", ex.ToString());

            }
        }
    }
}