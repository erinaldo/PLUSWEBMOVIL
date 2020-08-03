using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Consultas;
using CapaWeb.Urlencriptacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaWeb.WebForms
{
    public partial class FormDatosFacturacion : System.Web.UI.Page
    {
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();


        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();

        ModeloConcFiscal modeloFiscal = new ModeloConcFiscal();
        List<ModeloConcFiscal> ListaFiscal = new List<ModeloConcFiscal>();
        Articulos concepto = new Articulos();

        ModeloFacturaDescuento ModeloDescuento = new ModeloFacturaDescuento();
        List<ModeloFacturaDescuento> ListaDescuento = new List<ModeloFacturaDescuento>();
        CabezeraFactura BuscarDescuento = new CabezeraFactura();

        Consultawmspccostos ConsultaCCostos = new Consultawmspccostos();
        List<modelowmspcccostos> listaCostos = null;
        List<ModeloCtasContables> listaCContable = null;

        public string numerador1 = "trans";

        public string numerador = "auditoria";
        public string ComPwm;
        public string AmUsrLog;
        public string usuario;
        public string cod_proceso = "RCOMCONDTO";
        public string CC__cod_dpto = "0";
        public string libro = "NIIF";
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

                        case "INS":
                            ListaDesplegable();
                            break;

                        case "UDP":
                            string ide = (qs["Id"].ToString());
                            string empresa = ide.ToString();
                            ListaDesplegable();
                            txt_codigo.Enabled = false;
                            CargarFormulario(ide);
                            break;

                        case "DLT":

                            string id = (qs["Id"].ToString());
                            usuario = id.ToString();
                            ListaDesplegable();
                            CargarFormulario(usuario);
                            BloquearFormulario();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());

            }

        }
        public void ListaDesplegable()
        {
            try
            {
                lbl_error.Text = "";

                //Cargar cbx_fiscal
               ListaFiscal = concepto.ListaConceptoFiscal(AmUsrLog, ComPwm);
   
                cbx_fiscal.DataSource = ListaFiscal;
                cbx_fiscal.DataTextField = "nomcon";
                cbx_fiscal.DataValueField = "cod_concepto_fis";
                cbx_fiscal.DataBind();
                cbx_fiscal.Items.Insert(0, new ListItem("Seleccione...", "0"));
                cbx_fiscal.SelectedIndex = 0;

                //lista ccostos
                listaCostos = ConsultaCCostos.ConsultaCCostos(AmUsrLog, ComPwm, CC__cod_dpto);
                cbx_costos.DataSource = listaCostos;
                cbx_costos.DataTextField = "descripcion";
                cbx_costos.DataValueField = "cod_dpto";
                cbx_costos.DataBind();
                //Lista cuenta contable
                listaCContable = ConsultaCCostos.ConsultaCContable(AmUsrLog, ComPwm, libro);
                cbx_cta_contable.DataSource = listaCContable;
                cbx_cta_contable.DataTextField = "cuenta";
                cbx_cta_contable.DataValueField = "cod_cta";
                cbx_cta_contable.DataBind();

            }
            catch (Exception ex)
            {
                GuardarExcepciones("ListaDesplegable", ex.ToString());
                
            }
        }
        public void GuardarExcepciones(string metodo, string error)
        {

            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "FormDatosFacturacion.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;

            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }
        private void BloquearFormulario()
        {

            txt_codigo.Enabled = false;
            txt_nombre.Enabled = false;
           cbx_fiscal.Enabled = false;
            cbx_cta_contable.Enabled = false;
           cbx_costos.Enabled = false;
            txt_desc.Enabled = false;
            mensaje.Text = "Confirme la eliminacion de datos";

        }
        private void CargarFormulario(string codigo)
        {
            try
            {

                lbl_error.Text = "";
                ListaDescuento = BuscarDescuento.ListaRecDesFacturaxconcepto(AmUsrLog, ComPwm, codigo);
                foreach (ModeloFacturaDescuento item in ListaDescuento)
                {
                    ModeloDescuento = item;

                }
                txt_codigo.Text = ModeloDescuento.cod_concepto;
                txt_nombre.Text = ModeloDescuento.nom_concepto;
                cbx_fiscal.SelectedValue = ModeloDescuento.cod_concepto_fis;
                txt_desc.Text = ModeloDescuento.descuento;
                cbx_costos.SelectedValue = ModeloDescuento.cod_ccostos;
                cbx_cta_contable.SelectedValue = ModeloDescuento.cod_cta;
                lbl_descuento.Text = ModeloDescuento.detalle;
    
            }
            catch (Exception ex)
            {
                GuardarExcepciones("CargarFormulario", ex.ToString());

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
            }
            catch (Exception ex)
            {
                GuardarExcepciones("RecuperarCokie", ex.ToString());

            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                //Guardar datos de host mail
                QueryString qs = ulrDesencriptada();
                string error = "";


                switch (qs["TRN"].Substring(0, 3)) //ultilizo la variable para la opcion
                {
                    case "INS":
                        try
                        {

                            //verificar si es unico
                           ListaDescuento = BuscarDescuento.ListaRecDesFacturaxconcepto(AmUsrLog, ComPwm, txt_codigo.Text);


                            if (ListaDescuento.Count>0)
                            {
                                this.Page.Response.Write("<script language='JavaScript'>window.alert('Concepto  ya existe')+ error;</script>");
                            }
                            else
                            {
                                //obtener numero de auditoria
                                nrotrans = ConsultaNroTran.ConsultaNumeradores(numerador);
                                string nro_audit = nrotrans.valor_asignado;
                                DateTime hoy = DateTime.Now;
                               // string fecha = hoy;
                                //buscar datos empresa
                                ModeloDescuento.cod_emp = ComPwm;
                                ModeloDescuento.cod_concepto = txt_codigo.Text;
                                ModeloDescuento.nom_concepto = txt_nombre.Text;
                                ModeloDescuento.cod_concepto_fis = cbx_fiscal.SelectedValue;
                                ModeloDescuento.cod_ccostos = cbx_costos.SelectedValue;
                                ModeloDescuento.cod_cta = cbx_cta_contable.SelectedValue;
                                ModeloDescuento.cod_proc_aud = "RCOMCONDTO";
                                ModeloDescuento.usuario_mod = AmUsrLog;
                                ModeloDescuento.porc_descto = Convert.ToDecimal(txt_desc.Text);
                                ModeloDescuento.nro_audit = nro_audit;

                                error = BuscarDescuento.InsertarRecDesFactura(ModeloDescuento);
                                if (string.IsNullOrEmpty(error))
                                {
                                    Response.Redirect("BuscarDatosFacturacion.aspx");
                                }
                                else
                                {

                                    this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                                    
                                }
                            }
                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("btn_guardar_Click, INS", ex.ToString());

                        }
                        break;
                    case "UDP":
                        try
                        {
                            string ide = (qs["Id"].ToString());
                            
                            ModeloDescuento.cod_emp = ComPwm;
                            ModeloDescuento.cod_concepto = txt_codigo.Text;
                            ModeloDescuento.nom_concepto = txt_nombre.Text;
                            ModeloDescuento.cod_concepto_fis = cbx_fiscal.SelectedValue;
                            ModeloDescuento.cod_ccostos = cbx_costos.SelectedValue;
                            ModeloDescuento.cod_cta = cbx_cta_contable.SelectedValue; 
                            ModeloDescuento.usuario_mod = AmUsrLog;
                            ModeloDescuento.porc_descto = Convert.ToDecimal(txt_desc.Text);

                            error = BuscarDescuento.ActualizarRecDesFactura(ModeloDescuento);

                            if (string.IsNullOrEmpty(error))
                            {
                                Response.Redirect("BuscarDatosFacturacion.aspx");
                            }
                            else
                            {

                                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                                
                            }
                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("btn_guardar_Click, UDP", ex.ToString());

                        }
                        break;
                    case "DLT":
                        try
                        {

                            ModeloDescuento.cod_emp = ComPwm;
                            ModeloDescuento.cod_concepto = txt_codigo.Text;
                            error = BuscarDescuento.EliminarRecDesFactura(ModeloDescuento);
                            if (string.IsNullOrEmpty(error))
                            {
                                Response.Redirect("BuscarDatosFacturacion.aspx");
                            }
                            else
                            {
                                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "');</script>");
                                
                            }

                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("btn_guardar_Click, DLT", ex.ToString());

                        }
                        break;

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_guardar_Click", ex.ToString());

            }
        }

        protected void btn_cancela_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                Response.Redirect("BuscarDatosFacturacion.aspx");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_cancela_Click", ex.ToString());

            }

        }

        protected void cbx_fiscal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                modeloFiscal = concepto.BuscarConceptoFiscal(AmUsrLog, ComPwm, cbx_fiscal.SelectedValue.Trim());
                lbl_descuento.Text = modeloFiscal.concepto;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("cbx_fiscal_SelectedIndexChanged", ex.ToString());

            }
        }
    }
}