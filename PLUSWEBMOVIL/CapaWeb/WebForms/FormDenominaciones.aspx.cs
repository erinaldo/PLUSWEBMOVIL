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
    public partial class FormDenominaciones : System.Web.UI.Page
    {
        public modeloSucuralempresa ModelosucursalEmpresa = new modeloSucuralempresa();
        public List<modeloSucuralempresa> ListaModeloSucursalEmpresa = new List<modeloSucuralempresa>();
        public ConsultaSucursalempresa ConsultaSucEmpresa = new ConsultaSucursalempresa();
        public Consultawmsucempresa ConsultaSucursal = new Consultawmsucempresa();

        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();

        Consultawmspcmonedas ConsultaCMonedas = new Consultawmspcmonedas();
        List<modelowmspcmonedas> listaMonedas = null;
        List<modeloDenominacionesMoneda> listaDenominacion = null;
        modeloDenominacionesMoneda ModeloDenominacion = new modeloDenominacionesMoneda();
        modelowmspcmonedas DecimalesMoneda = new modelowmspcmonedas();

        public string MonB__moneda = "0";
        public string ComPwm;
        public string AmUsrLog;
        public string cod_sucursal = null;
        public string cod_proceso = "AEMPSUC";
        public string numerador = "auditoria";
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

                //Recibir opciones
                switch (qs["TRN"].Substring(0, 3))
                {

                    case "INS":
                        cargarListaDesplegables();
 
                        break;

                    case "UDP":
                        Int64 id = Int64.Parse(qs["Id"].ToString());
                        //Session["valor_asignado"] = id.ToString();

                        cargarListaDesplegables();
                        LlenarFormulario(id.ToString());

                        break;

                    case "VER":
                        Int64 ide = Int64.Parse(qs["Id"].ToString());
                        cargarListaDesplegables();
                        LlenarFormulario(ide.ToString());
                        BloquearFormulario();
                        break;
                    case "DLT":
                        Int64 ides = Int64.Parse(qs["Id"].ToString());
                        cargarListaDesplegables();
                        LlenarFormulario(ides.ToString());
                        BloquearFormulario();
                        mensaje.Text = "Confirme datos para la eliminación";
                        break;
                }

            }
        }
        public void BloquearFormulario()
        {
            cbx_cod_moneda.Enabled = false;
            cbx_nombrere.Enabled = false;
            txt_valor.Enabled = false;
        }
        public void LlenarFormulario(string  id)
        {
            listaDenominacion = ConsultaCMonedas.ConsultaDenominacionesUDP(id);
            foreach (var item in listaDenominacion)
            {
                ModeloDenominacion = item;
               
                break;
            }
            cbx_cod_moneda.SelectedValue = ModeloDenominacion.cod_moneda.Trim();
            cbx_nombrere.SelectedValue = ModeloDenominacion.nombre.Trim();
            txt_valor.Text = ModeloDenominacion.valor.ToString();


        }
        public void cargarListaDesplegables()
        {
           

            //lissta moneedaa
            listaMonedas = ConsultaCMonedas.ConsultaCMonedas(AmUsrLog, ComPwm, MonB__moneda);
            cbx_cod_moneda.DataSource = listaMonedas;
            cbx_cod_moneda.DataTextField = "descripcion";
            cbx_cod_moneda.DataValueField = "cod_moneda";
            cbx_cod_moneda.DataBind();

        }
        public QueryString ulrDesencriptada()
        {
            //1- guardo el Querystring encriptado que viene desde el request en mi objeto
            QueryString qs = new QueryString(Request.QueryString);

            ////2- Descencripto y de esta manera obtengo un array Clave/Valor normal
            qs = Encryption.DecryptQueryString(qs);
            return qs;
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

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            //GUARDAR DENOMINACION
            QueryString qs = ulrDesencriptada();
            string error = "";


            switch (qs["TRN"].Substring(0, 3)) //ultilizo la variable para la opcion
            {
                case "INS":
                    //verificar si es unico
                    listaDenominacion = ConsultaCMonedas.ConsultaUnicoDenominacion(cbx_cod_moneda.SelectedValue.Trim(), cbx_nombrere.SelectedValue.Trim(), txt_valor.Text.Trim());
                    if (listaDenominacion.Count > 0)
                    {
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('Denominación ya existe')+ error;</script>");
                    }

                    else
                    {
                       
                        DateTime hoy = DateTime.Today;
                        ModeloDenominacion.cod_moneda = cbx_cod_moneda.SelectedValue;
                        ModeloDenominacion.nombre = cbx_nombrere.SelectedValue;
                        ModeloDenominacion.valor = Convert.ToDecimal(txt_valor.Text);
                        ModeloDenominacion.usuario_mod = AmUsrLog;
                        ModeloDenominacion.fecha_mod = hoy.ToString();

                        error = ConsultaCMonedas.InsertarDenominacion(ModeloDenominacion);

                        if (string.IsNullOrEmpty(error))
                        {

                        }
                        else
                        {

                            this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                            Response.Redirect("BuscarDenominaciones.aspx");
                        }
                    }
                    break;
                case "UDP":
                    string ide = (qs["Id"].ToString());
                    string usuario = ide.ToString();
                    DateTime hoy1 = DateTime.Today;
                    ModeloDenominacion.id = usuario;
                    ModeloDenominacion.cod_moneda = cbx_cod_moneda.SelectedValue;
                    ModeloDenominacion.nombre = cbx_nombrere.SelectedValue;
                    ModeloDenominacion.valor = Convert.ToDecimal(txt_valor.Text);
                    ModeloDenominacion.usuario_mod = AmUsrLog;
                    ModeloDenominacion.fecha_mod = hoy1.ToString();

                    error = ConsultaCMonedas.ActualizarDenominacion(ModeloDenominacion);

                    if (string.IsNullOrEmpty(error))
                    {

                    }
                    else
                    {

                        this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                        Response.Redirect("BuscarDenominaciones.aspx");
                    }
                    break;
                case "DLT":
                    string ide1 = (qs["Id"].ToString());
                    string usuario1 = ide1.ToString();
                    ModeloDenominacion.id = usuario1;

                    error = ConsultaCMonedas.EliminarDenominacion(ModeloDenominacion);
                    if (string.IsNullOrEmpty(error))
                    {

                    }
                    else
                    {
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "');</script>");
                        Response.Redirect("BuscarDenominaciones.aspx");
                    }

                    break;

            }
        }

        protected void btn_cancela_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarDenominaciones.aspx");
        }
    }
}