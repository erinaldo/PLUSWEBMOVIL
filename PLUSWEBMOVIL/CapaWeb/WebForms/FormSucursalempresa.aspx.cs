using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaDatos.Modelos;
using CapaDatos.Sql;

namespace CapaWeb.WebForms
{
    public partial class FormSucursalempresa : System.Web.UI.Page
    {
        public modeloSucuralempresa ModelosucursalEmpresa = new modeloSucuralempresa();
        public modeloSucuralempresa PrefijosucursalEmpresa = new modeloSucuralempresa();
        public List<modeloSucuralempresa> ListaModeloSucursalEmpresa = new List<modeloSucuralempresa>();
        public ConsultaSucursalempresa ConsultaSucEmpresa = new ConsultaSucursalempresa();
        public Consultawmsucempresa ConsultaSucursal = new Consultawmsucempresa();

        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();

        Consultawmspcresfact ConsultaResolucion = new Consultawmspcresfact();
        modelowmspcresfact resolucion = new modelowmspcresfact();
        List<modelowmspcresfact> listaRes = null;

        CodigosPaiPrvCiu ConsultaPPC = new CodigosPaiPrvCiu();
        List<modelopaises> ListaPais = null;
        List<modeloprovincias> ListaProvincias = null;
        List<modelociudades> ListaCiudades = null;
        public string numerador1 = "trans";
        public string ResF_estado = "S";
        public string ResF_serie = "0";
        public string ResF_tipo = "F";
        public string ComPwm;
        public string AmUsrLog;
        public string cod_sucursal = null;
        public string cod_proceso = "AEMPSUC";
        public string numerador = "auditoria";
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
                            CargarListaDesplegable("INS");
                            break;

                        case "UDP":
                            try
                            {
                                string ide = (qs["Id"].ToString());
                                string cod_sucursal = ide.ToString();
                                CargarListaDesplegable("UDP");
                                CargarFormularioSucursal(cod_sucursal, "UDP");
                                break;
                            }
                            catch (Exception ex)
                            {
                                GuardarExcepciones("Page_Load, UDP", ex.ToString());

                            }
                            break;

                        case "DLT":
                            try
                            {
                                string id = (qs["Id"].ToString());
                                cod_sucursal = id.ToString();
                                CargarListaDesplegable("DLT");
                                CargarFormularioSucursal(cod_sucursal, "DLT");
                                break;
                            }
                            catch (Exception ex)
                            {
                                GuardarExcepciones("Page_Load, DLT", ex.ToString());

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

        public void CargarListaDesplegable(string tipo)
        {
            try
            {
                //LIsta Resolucion facturas
                listaRes = ConsultaResolucion.ConsultaResolusiones(AmUsrLog, ComPwm, ResF_estado, ResF_serie, ResF_tipo);
                resolucion = null;
                foreach (modelowmspcresfact item in listaRes)
                {
                    resolucion = item;

                }
                cbx_serie_factura.DataSource = listaRes;
                cbx_serie_factura.DataTextField = "serie_docum";
                cbx_serie_factura.DataValueField = "serie_docum";
                cbx_serie_factura.DataBind();
                cbx_serie_facn.DataSource = listaRes;
                cbx_serie_facn.DataTextField = "serie_docum";
                cbx_serie_facn.DataValueField = "serie_docum";
                cbx_serie_facn.DataBind();
                cbx_serie_facn.Items.Insert(0, new ListItem("Seleccione...", "serie..."));
                cbx_serie_facn.SelectedIndex = 0;
                if (listaRes.Count > 0)
                {
                    cbx_serie_factura.Items.Insert(0, new ListItem("Seleccione...", "serie..."));
                    cbx_serie_factura.SelectedIndex = 0;
                }
               
                //LIsta Resolucion nota crédito
                listaRes = null;
                listaRes = ConsultaResolucion.ConsultaResolusiones(AmUsrLog, ComPwm, ResF_estado, ResF_serie, "C");
                resolucion = null;
                foreach (modelowmspcresfact item in listaRes)
                {
                    resolucion = item;

                }
                cbx_serie_nc.DataSource = listaRes;
                cbx_serie_nc.DataTextField = "serie_docum";
                cbx_serie_nc.DataValueField = "serie_docum";
                cbx_serie_nc.DataBind();
               
                cbx_serie_ncn.DataSource = listaRes;
                cbx_serie_ncn.DataTextField = "serie_docum";
                cbx_serie_ncn.DataValueField = "serie_docum";
                cbx_serie_ncn.DataBind();
                cbx_serie_ncn.Items.Insert(0, new ListItem("Seleccione...", "serie..."));
                cbx_serie_ncn.SelectedIndex = 0;
                if (listaRes.Count > 0)
                {
                    cbx_serie_nc.Items.Insert(0, new ListItem("Seleccione...", "serie..."));
                    cbx_serie_nc.SelectedIndex = 0;
                }
                
                //LIsta Resolucion nota débito
                listaRes = null;
                listaRes = ConsultaResolucion.ConsultaResolusiones(AmUsrLog, ComPwm, ResF_estado, ResF_serie, "D");
                resolucion = null;
                foreach (modelowmspcresfact item in listaRes)
                {
                    resolucion = item;

                }
                cbx_serie_nd.DataSource = listaRes;
                cbx_serie_nd.DataTextField = "serie_docum";
                cbx_serie_nd.DataValueField = "serie_docum";
                cbx_serie_nd.DataBind();
              
                cbx_serie_ndn.DataSource = listaRes;
                cbx_serie_ndn.DataTextField = "serie_docum";
                cbx_serie_ndn.DataValueField = "serie_docum";
                cbx_serie_ndn.DataBind();
                cbx_serie_ndn.Items.Insert(0, new ListItem("Seleccione...", "serie..."));
                cbx_serie_ndn.SelectedIndex = 0;
                if (listaRes.Count > 0)
                {
                    cbx_serie_nd.Items.Insert(0, new ListItem("Seleccione...", "serie..."));
                    cbx_serie_nd.SelectedIndex = 0;
                }
                //LISTA DE PAISES-CIUDADES-PROVINCIAS
               
                ListaPais = ConsultaPPC.ListaPaises(AmUsrLog, ComPwm, "");
                cbx_pais.DataSource = ListaPais;
                cbx_pais.DataTextField = "nom_pais";
                cbx_pais.DataValueField = "cod_pais";
                cbx_pais.DataBind();
                cbx_pais.SelectedValue = Modelowmspclogo.cod_pais.Trim();
                if (tipo == "INS")
                {
                    ListaProvincias = ConsultaPPC.ListaProvincias(AmUsrLog, ComPwm, cbx_pais.SelectedValue.Trim(), "");
                    cbx_provincia.DataSource = ListaProvincias;
                    cbx_provincia.DataTextField = "nom_provincia";
                    cbx_provincia.DataValueField = "cod_provincia";
                    cbx_provincia.DataBind();
                    cbx_provincia.SelectedValue = Modelowmspclogo.cod_provincia.Trim();

                    ListaCiudades = ConsultaPPC.ListaCiudades(AmUsrLog, ComPwm, cbx_pais.SelectedValue.Trim(), cbx_provincia.SelectedValue.Trim(), "");
                    cbx_ciudad.DataSource = ListaCiudades;
                    cbx_ciudad.DataTextField = "nom_ciudad";
                    cbx_ciudad.DataValueField = "ciudad_tit";
                    cbx_ciudad.DataBind();
                    cbx_ciudad.SelectedValue = Modelowmspclogo.cod_ciudad.Trim();
                }
            }

            catch (Exception ex)
            {
                GuardarExcepciones("CargarListaDesplegable", ex.ToString());

            }
        }
        public void GuardarExcepciones(string metodo, string error)
        {
           
            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "FormSucursalempresa.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;
           
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }
        private void CargarFormularioSucursal(string cod_sucursal, string tipo)
        {
            try
            {
              
                ListaModeloSucursalEmpresa = ConsultaSucursal.ConsultaSucursalUnico(ComPwm, cod_sucursal);
                int count = 0;
                foreach (var item in ListaModeloSucursalEmpresa)
                {
                    ModelosucursalEmpresa = item;
                    count++;
                    break;
                }
                txt_cod_sucursal.Text = ModelosucursalEmpresa.cod_sucursal;
                txt_nom_sucursal.Text = ModelosucursalEmpresa.nom_sucursal;
                txt_dir_sucursal.Text = ModelosucursalEmpresa.dir_sucursal;
                txt_tel_sucursal.Text = ModelosucursalEmpresa.tel_sucursal;
                txt_email_sucursal.Text = ModelosucursalEmpresa.email_sucursal;
                txt_cod_sucursal.Enabled = false;
                cbx_serie_factura.SelectedValue = ModelosucursalEmpresa.serie_factura;
                cbx_serie_facn.SelectedValue = ModelosucursalEmpresa.serie_facn;
                cbx_serie_nc.SelectedValue = ModelosucursalEmpresa.serie_nc;
                cbx_serie_ncn.SelectedValue = ModelosucursalEmpresa.serie_ncn;
                cbx_serie_nd.SelectedValue = ModelosucursalEmpresa.serie_nd;
                cbx_serie_ndn.SelectedValue = ModelosucursalEmpresa.serie_ndn;
                cbx_pais.SelectedValue = ModelosucursalEmpresa.cod_pais.Trim();

                ListaProvincias = ConsultaPPC.ListaProvincias(AmUsrLog, ComPwm, cbx_pais.SelectedValue.Trim(), "");
                cbx_provincia.DataSource = ListaProvincias;
                cbx_provincia.DataTextField = "nom_provincia";
                cbx_provincia.DataValueField = "cod_provincia";
                cbx_provincia.DataBind();
                cbx_provincia.SelectedValue = ModelosucursalEmpresa.cod_provincia.Trim();


                ListaCiudades = ConsultaPPC.ListaCiudades(AmUsrLog, ComPwm, cbx_pais.SelectedValue.Trim(), cbx_provincia.SelectedValue.Trim(), "");
                cbx_ciudad.DataSource = ListaCiudades;
                cbx_ciudad.DataTextField = "nom_ciudad";
                cbx_ciudad.DataValueField = "ciudad_tit";
                cbx_ciudad.DataBind();
                cbx_ciudad.SelectedValue = ModelosucursalEmpresa.cod_ciudad.Trim();

                if (tipo == "DLT")
                {
                    mensaje.Text = "Confirme la eliminación de Datos";
                    txt_nom_sucursal.Enabled = false;
                    txt_dir_sucursal.Enabled = false;
                    txt_tel_sucursal.Enabled = false;
                    txt_email_sucursal.Enabled = false;
         
                    cbx_serie_factura.Enabled = false; 
                    cbx_serie_facn.Enabled = false;
                    cbx_serie_nc.Enabled = false;
                    cbx_serie_ncn.Enabled = false;
                    cbx_serie_nd.Enabled = false;
                    cbx_serie_ndn.Enabled = false;
                    cbx_ciudad.Enabled = false;
                    cbx_pais.Enabled = false;
                    cbx_provincia.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                GuardarExcepciones("CargarFormularioSucursal", ex.ToString());

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
                QueryString qs = ulrDesencriptada();
                string error = "";


                switch (qs["TRN"].Substring(0, 3)) //ultilizo la variable para la opcion
                {
                    case "INS":
                        try
                        {
                            lbl_error.Text = "";
                            bool ValidarRequeridos = ValidarCamposRequeridos();
                            if (ValidarRequeridos == false)
                            {
                                ListaModeloSucursalEmpresa = ConsultaSucursal.UnicoSucursalEmpresa(ComPwm, txt_cod_sucursal.Text);
                                int count = 0;
                                foreach (var item in ListaModeloSucursalEmpresa)
                                {
                                    ModelosucursalEmpresa = item;
                                    count++;
                                    break;
                                }
                                if (count > 0)
                                {
                                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Sucursal ya existe')+ error;</script>");
                                }
                                else
                                {
                                    string factura = ConsultaSucursal.PrefijoSEFactura(ComPwm, cbx_serie_factura.SelectedValue, AmUsrLog);
                                    if (factura != null)
                                    {
                                        this.Page.Response.Write("<script language='JavaScript'>window.alert('Prefijo Factura  ya existe para otra sucursal')+ error;</script>");
                                    }
                                    else
                                    {
                                        string nc1 = ConsultaSucursal.PrefijoSENC(ComPwm, cbx_serie_nc.SelectedValue, AmUsrLog);

                                        if (nc1 != null)
                                        {
                                            this.Page.Response.Write("<script language='JavaScript'>window.alert('Prefijo Nota Crédito  ya existe para otra sucursal')+ error;</script>");
                                        }
                                        else
                                        {
                                            string nc2 = null;
                                            if (cbx_serie_ncn.SelectedValue !="serie...")
                                            {
                                                nc2 = ConsultaSucursal.PrefijoSENCN(ComPwm, cbx_serie_ncn.SelectedValue, AmUsrLog);
                                            }
                                         
                                            if (nc2 != null)
                                            {
                                                this.Page.Response.Write("<script language='JavaScript'>window.alert('Prefijo Nota Crédito por computador  ya existe para otra sucursal')+ error;</script>");
                                            }
                                            else
                                            {
                                                string nd1 = ConsultaSucursal.PrefijoSEND(ComPwm, cbx_serie_nd.SelectedValue, AmUsrLog);
                                                if (nd1 != null)
                                                {
                                                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Prefijo Nota Débito  ya existe para otra sucursal')+ error;</script>");
                                                }
                                                else
                                                {
                                                    string nd2 = null;
                                                    if (cbx_serie_ndn.SelectedValue != "serie...")
                                                    { ConsultaSucursal.PrefijoSENDN(ComPwm, cbx_serie_ndn.SelectedValue, AmUsrLog); }
                                                    if (nd2 != null)
                                                    {
                                                        this.Page.Response.Write("<script language='JavaScript'>window.alert('Prefijo Nota Débito por compuatador  ya existe para otra sucursal')+ error;</script>");
                                                    }
                                                    else
                                                    {
                                                        string fac_normal = null;
                                                        if (cbx_serie_facn.SelectedValue != "serie...")
                                                        {
                                                          fac_normal= ConsultaSucursal.PrefijoSEFacturaN(ComPwm, cbx_serie_facn.SelectedValue, AmUsrLog);
                                                        }
                                                        if(fac_normal != null)
                                                        {
                                                            this.Page.Response.Write("<script language='JavaScript'>window.alert('Prefijo Factura por computador  ya existe para otra sucursal')+ error;</script>");
                                                        }
                                                        else
                                                        {
                                                            //obtener numero de transaccion
                                                            nrotrans = ConsultaNroTran.ConsultaNumeradores(numerador);
                                                            string nro_audit = nrotrans.valor_asignado;

                                                            ModelosucursalEmpresa.cod_emp = ComPwm;
                                                            ModelosucursalEmpresa.cod_sucursal = txt_cod_sucursal.Text;
                                                            ModelosucursalEmpresa.nom_sucursal = txt_nom_sucursal.Text;
                                                            ModelosucursalEmpresa.dir_sucursal = txt_dir_sucursal.Text;
                                                            ModelosucursalEmpresa.email_sucursal = txt_email_sucursal.Text;
                                                            ModelosucursalEmpresa.tel_sucursal = txt_tel_sucursal.Text;
                                                            ModelosucursalEmpresa.fecha_mod = DateTime.Now;
                                                            ModelosucursalEmpresa.usuario_mod = AmUsrLog;
                                                            ModelosucursalEmpresa.nro_audit = nro_audit;
                                                            ModelosucursalEmpresa.cod_proc_aud = "AEMPSUC";
                                                            ModelosucursalEmpresa.serie_factura = cbx_serie_factura.SelectedValue;
                                                            ModelosucursalEmpresa.serie_facn = cbx_serie_facn.SelectedValue;
                                                            ModelosucursalEmpresa.serie_nc = cbx_serie_nc.SelectedValue;
                                                            ModelosucursalEmpresa.serie_nd = cbx_serie_nd.SelectedValue;
                                                            ModelosucursalEmpresa.serie_ncn = cbx_serie_ncn.SelectedValue;
                                                            ModelosucursalEmpresa.serie_ndn = cbx_serie_ndn.SelectedValue;
                                                            ModelosucursalEmpresa.cod_ciudad = cbx_ciudad.SelectedValue;
                                                            ModelosucursalEmpresa.cod_provincia = cbx_provincia.SelectedValue;
                                                            ModelosucursalEmpresa.cod_pais = cbx_pais.SelectedValue;

                                                            error = ConsultaSucEmpresa.InsertarSucursalEmpresa(ModelosucursalEmpresa);

                                                            if (string.IsNullOrEmpty(error))
                                                            {

                                                            }
                                                            else
                                                            {

                                                                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                                                                Response.Redirect("FormListaSucursalEmpresa.aspx");
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                }
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("btn_guardar_Click, INS", ex.ToString());

                        }
                        break;
                    case "UDP":
                        try
                        {
                           
                            ModelosucursalEmpresa.cod_emp = ComPwm;
                            ModelosucursalEmpresa.cod_sucursal = txt_cod_sucursal.Text;
                            ModelosucursalEmpresa.nom_sucursal = txt_nom_sucursal.Text;
                            ModelosucursalEmpresa.dir_sucursal = txt_dir_sucursal.Text;
                            ModelosucursalEmpresa.email_sucursal = txt_email_sucursal.Text;
                            ModelosucursalEmpresa.tel_sucursal = txt_tel_sucursal.Text;
                            ModelosucursalEmpresa.fecha_mod = DateTime.Now;
                            ModelosucursalEmpresa.usuario_mod = AmUsrLog;
                            ModelosucursalEmpresa.serie_factura = cbx_serie_factura.SelectedValue;
                            ModelosucursalEmpresa.serie_facn = cbx_serie_facn.SelectedValue;
                            ModelosucursalEmpresa.serie_nc = cbx_serie_nc.SelectedValue;
                            ModelosucursalEmpresa.serie_nd = cbx_serie_nd.SelectedValue;
                            ModelosucursalEmpresa.serie_ncn = cbx_serie_ncn.SelectedValue;
                            ModelosucursalEmpresa.serie_ndn = cbx_serie_ndn.SelectedValue;
                            ModelosucursalEmpresa.cod_ciudad = cbx_ciudad.SelectedValue;
                            ModelosucursalEmpresa.cod_provincia = cbx_provincia.SelectedValue;
                            ModelosucursalEmpresa.cod_pais = cbx_pais.SelectedValue;
                            
                            error = ConsultaSucEmpresa.ActualizarSucursalEmpresa(ModelosucursalEmpresa);

                            if (string.IsNullOrEmpty(error))
                            {

                            }
                            else
                            {

                                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                                Response.Redirect("FormListaSucursalEmpresa.aspx");
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
                            //Para eliminar una susucarl se debeb verificar que no exista usuarios asociados a la sucursal
                            string sucursal_usuario = ConsultaSucEmpresa.UsuariosSucursal(ComPwm, txt_cod_sucursal.Text, AmUsrLog);
                            if(sucursal_usuario ==null)
                            {
                                ModelosucursalEmpresa.cod_sucursal = txt_cod_sucursal.Text;
                                ModelosucursalEmpresa.cod_emp = ComPwm;
                                ModelosucursalEmpresa.usuario_mod = AmUsrLog;
                                ConsultaSucEmpresa.EliminarSucursalEmpresa(ModelosucursalEmpresa);
                            }
                            else
                            {
                                error = "Existen datos relacionados con la sucursal no se puede eliminar.";
                            }
                           

                            if (string.IsNullOrEmpty(error))
                            {
                                Response.Redirect("FormListaSucursalEmpresa.aspx");
                            }
                            else
                            {

                                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                               
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


                Response.Redirect("FormListaSucursalEmpresa.aspx");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_cancela_Click", ex.ToString());

            }
        }

        public Boolean ValidarCamposRequeridos()
        {
            try
            {
                lbl_error.Text = "";
                bool Requerido = false;
                if (cbx_serie_factura.SelectedValue =="serie...")
                {
                    lbl_error.Text = "Prefijo Factura no puede estar vacía.";
                    Requerido = true;
                }
                if(cbx_serie_facn.SelectedValue == cbx_serie_factura.SelectedValue)
                {
                    lbl_error.Text = "Prefijo Factura y Prefijo Factura por computador no pueden ser iguales.";
                    Requerido = true;
                }
                if(cbx_serie_nc.SelectedValue == "serie...")
                {
                    lbl_error.Text = "Prefijo Nota Crédito no puede estar vacía.";
                    Requerido = true;
                }
                if (cbx_serie_nc.SelectedValue == cbx_serie_ncn.SelectedValue)
                {
                    lbl_error.Text = "Prefijo Nota Crédito y Prefijo Nota Crédito por computador no pueden ser iguales.";
                    Requerido = true;
                }
                if (cbx_serie_nd.SelectedValue == "serie...")
                {
                    lbl_error.Text = "Prefijo Nota Débito no puede estar vacía.";
                    Requerido = true;
                }
                if (cbx_serie_nd.SelectedValue == cbx_serie_ndn.SelectedValue)
                {
                    lbl_error.Text = "Prefijo Nota Débito y Prefijo Nota Débito por computador no pueden ser iguales.";
                    Requerido = true;
                }
                return Requerido;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_cancela_Click", ex.ToString());
                return false;
            }
        }

        protected void cbx_pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListaProvincias = null;
                ListaProvincias = ConsultaPPC.ListaProvincias(AmUsrLog, ComPwm, cbx_pais.SelectedValue.Trim(), "");
                cbx_provincia.DataSource = ListaProvincias;
                cbx_provincia.DataTextField = "nom_provincia";
                cbx_provincia.DataValueField = "cod_provincia";
                cbx_provincia.DataBind();

                ListaCiudades = null;
                ListaCiudades = ConsultaPPC.ListaCiudades(AmUsrLog, ComPwm, cbx_pais.SelectedValue.Trim(), cbx_provincia.SelectedValue.Trim(), "");
                cbx_ciudad.DataSource = ListaCiudades;
                cbx_ciudad.DataTextField = "nom_ciudad";
                cbx_ciudad.DataValueField = "ciudad_tit";
                cbx_ciudad.DataBind();


            }
            catch (Exception ex)
            {
                GuardarExcepciones("cbx_pais_SelectedIndexChanged", ex.ToString());
                
            }
        }

        protected void cbx_provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                

                ListaCiudades = null;
                ListaCiudades = ConsultaPPC.ListaCiudades(AmUsrLog, ComPwm, cbx_pais.SelectedValue.Trim(), cbx_provincia.SelectedValue.Trim(), "");
                cbx_ciudad.DataSource = ListaCiudades;
                cbx_ciudad.DataTextField = "nom_ciudad";
                cbx_ciudad.DataValueField = "ciudad_tit";
                cbx_ciudad.DataBind();

              }
            catch (Exception ex)
            {
                GuardarExcepciones("cbx_provincia_SelectedIndexChanged", ex.ToString());

            }
        }
    }
}