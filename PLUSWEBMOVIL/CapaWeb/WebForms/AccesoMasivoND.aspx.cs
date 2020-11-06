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
    public partial class AccesoMasivoND : System.Web.UI.Page
    {

        Consultaestadosfactura Consultaestados = new Consultaestadosfactura();
        List<modeloestadosfactura> Listaestados = null;

        public ConsultaRolesFactura ConsultaRoles = new ConsultaRolesFactura();
        public modeloRolesFacturacion ModeloRoles = new modeloRolesFacturacion();
        public List<modeloRolesFacturacion> ListaModelosRoles = null;

        public ConsultaCodProceso ConsultaCodProceso = new ConsultaCodProceso();
        public modeloCodProcesoFactura ModeloCodProceso = new modeloCodProcesoFactura();
        public List<modeloCodProcesoFactura> ListaModeloCodProceso = null;

        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        List<modelowmtfacturascab> listaConsCab = null;
        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

        ConsumoRest consumoRest = new ConsumoRest();

        Consultawmsptitulares ConsultaTitulares = new Consultawmsptitulares();
        public List<modelowmspctitulares> lista = null;
        modelowmspctitulares cliente = new modelowmspctitulares();

        public List<modelowmspcfacturasWMimpuRest> ListaModeloimpuesto = new List<modelowmspcfacturasWMimpuRest>();
        public modelowmspcfacturasWMimpuRest ModeloImpuesto = new modelowmspcfacturasWMimpuRest();
        public ConsultawmspcfacturasWMimpuRest consultaImpuesto = new ConsultawmspcfacturasWMimpuRest();

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();

        Consultawmspcresfact ConsultaResolucion = new Consultawmspcresfact();
        modelowmspcresfact resolucion = new modelowmspcresfact();
        List<modelowmspcresfact> listaRes = null;

        public modeloUsuariosucursal ModelousuarioSucursal = new modeloUsuariosucursal();
        public List<modeloUsuariosucursal> ListaModeloUsuarioSucursal = new List<modeloUsuariosucursal>();
        public ConsultawmusuarioSucursal ConsultaUsuxSuc = new ConsultawmusuarioSucursal();
        public ConsultausuarioSucursal consultaUsuarioSucursal = new ConsultausuarioSucursal();
        public string numerador = "trans";
        public string ComPwm;
        public string AmUsrLog;
        public string Ccf_tipo1 = "C";
        public string Ccf_tipo2 = "NC";
        public string Ccf_nro_trans = "0";
        public string Ccf_estado = "0";
        public string Ccf_cliente = "0";
        public string Ccf_cod_docum = "0";
        public string Ccf_serie_docum = "xxx";
        public string Ccf_nro_docum = "0";
        public string Ccf_diai = "";
        public string Ccf_mesi = "";
        public string Ccf_anioi = "";
        public string Ccf_diaf = "";
        public string Ccf_mesf = "";
        public string Ccf_aniof = "";
        public string Ven__cod_tipotit = "clientes";
        public string Ven__cod_tit = " ";
        public string cod_proceso;
        public string ResF_estado = "S";
        public string ResF_serie = "0";
        public string ResF_tipo = "D";
        public string EstF_proceso = "RCOMNCRED";
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
                    CargarRolesUsuario();
                    cargarListaDesplegables();

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());
            }
        }
        public void cargarListaDesplegables()
        {
            try
            {
                lbl_error.Text = "";
                lbl_mensaje.Text = "";
                //Cargar la sucursal del usuario logeado
                ListaModeloUsuarioSucursal = ConsultaUsuxSuc.UnicoUsuarioSucursal(ComPwm, AmUsrLog, ""); //Solo se envia empresa y usuario
                if (ListaModeloUsuarioSucursal.Count == 0)
                {
                    lbl_mensaje.Text = "Usuario no tiene sucursal asignada, por favor asignar sucursarl para continuar.";
                }
                else
                {
                    foreach (var item in ListaModeloUsuarioSucursal)
                    {
                        ModelousuarioSucursal = item;
                        break;
                    }
                    lbl_cod_suc.Text = ModelousuarioSucursal.cod_sucursal.Trim();
                    lbl_sucursal.Text = "-" + ModelousuarioSucursal.nom_sucursal.Trim();
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("cargarListaDesplegables", ex.ToString());
            }

        }
        public void GuardarExcepciones(string metodo, string error)
        {

            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "AccesoMasivoND.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            lbl_error.Text = "No se pudo completar la acción. Por favor notificar al administrador.";

        }

        private void CargarRolesUsuario()
        {
            try
            {
                lbl_error.Text = "";
                //Rol crear factura nueva
                ListaModelosRoles = ConsultaRoles.BuscarRolNuevo(AmUsrLog);
                int count1 = 0;
                foreach (var item in ListaModelosRoles)
                {
                    count1++;

                }

                if (count1 > 0)
                {
                   
                    btn_financiera.Visible = true;
                    btn_anulacion.Visible = true;
                }
                //Rol acceso a la pantalla de Buscar facturas
                ListaModelosRoles = ConsultaRoles.BuscarAccesoFactura(AmUsrLog);
                int count2 = 0;
                foreach (var item in ListaModelosRoles)
                {
                    count2++;
                }

                if (count2 == 0)
                {
                    txtAcceso.Visible = true;
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("CargarRolesUsuario", ex.ToString());
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

        public modelowmtfacturascab buscarCabezeraFactura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {

            try
            {
                lbl_error.Text = "";
                listaConsCab = ConsultaCabe.ConsultaCabFacura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);

                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {

                    conscabcera = item;

                }
                return conscabcera;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("buscarCabezeraFactura", ex.ToString());
                return null;

            }
        }


        protected void notaCreditoFinan_Click(object sender, EventArgs e)
        {
            

        }


        public modeloRolesFacturacion BuscarCargarTablero(string usuario)
        {
            try
            {
                lbl_error.Text = "";
                ListaModelosRoles = ConsultaRoles.BuscarCargarTablero(usuario);

                ModeloRoles = null;
                foreach (modeloRolesFacturacion item in ListaModelosRoles)
                {

                    ModeloRoles = item;

                }
                return ModeloRoles;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarCargarTablero", ex.ToString());
                return null;

            }
        }

        protected void btn_financiera_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                lbl_mensaje.Text = "";
                btn_financiera.Enabled = true;
                //vALIDAR QUE SOLO EXISTA UNA RESOLUCION ACTIVA-
                listaRes = null;
                listaRes = ConsultaResolucion.ConsultaResolusionXSucursalND(AmUsrLog, ComPwm, ResF_estado, ResF_serie, ResF_tipo, lbl_cod_suc.Text.Trim());
                resolucion = null;
                foreach (modelowmspcresfact item in listaRes)
                {
                    resolucion = item;
                }
                if (listaRes.Count == 0)
                {
                    btn_financiera.Enabled = false;
                    lbl_mensaje.Text = "No existe una resolución activa para emitir Nota de Débito.";
                }
                else
                {
                    if (listaRes.Count == 1)
                    {
                        QueryString qs = new QueryString();
                        qs.Add("TRN", "AFA");
                        qs.Add("Id", "");
                        Response.Redirect("FormMasivoNDFinanciera.aspx" + Encryption.EncryptQueryString(qs).ToString());
                    }
                    else
                    {
                        if (listaRes.Count > 1)
                        {
                            btn_financiera.Enabled = false;
                            lbl_mensaje.Text = "Existe más de una resolución activa, para emitir Nota de Débito habilite una solamente.";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_financiera_Click", ex.ToString());

            }
        }

        protected void btn_anulacion_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                lbl_mensaje.Text = "";
                btn_anulacion.Enabled = true;
                //vALIDAR QUE SOLO EXISTA UNA RESOLUCION ACTIVA-
                listaRes = null;
                listaRes = ConsultaResolucion.ConsultaResolusionXSucursalND(AmUsrLog, ComPwm, ResF_estado, ResF_serie, ResF_tipo, lbl_cod_suc.Text.Trim());
                resolucion = null;
                foreach (modelowmspcresfact item in listaRes)
                {
                    resolucion = item;
                }
                if (listaRes.Count == 0)
                {
                    btn_anulacion.Enabled = false;
                    lbl_mensaje.Text = "No existe una resolución activa para emitir Nota de Débito.";
                }
                else
                {
                    if (listaRes.Count == 1)
                    {
                        //Anular Factura
                        QueryString qs = new QueryString();

                        //2 voy a agregando los valores que deseo
                        qs.Add("TRN", "AFA");
                        qs.Add("Id", "");
                        Response.Redirect("FormMasivoNDAnulacion.aspx" + Encryption.EncryptQueryString(qs).ToString());
                    }
                    else
                    {
                        if (listaRes.Count > 1)
                        {
                            btn_anulacion.Enabled = false;
                            lbl_mensaje.Text = "Existe más de una resolución activa, para emitir Nota de Débito habilite una solamente.";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_anulacion_Click", ex.ToString());

            }
        }
    }
}