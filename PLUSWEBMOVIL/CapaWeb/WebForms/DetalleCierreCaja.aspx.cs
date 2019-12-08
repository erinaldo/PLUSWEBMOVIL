using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaDatos.Modelos;
using System.Globalization;

namespace CapaWeb.WebForms
{
    public partial class DetalleCierreCaja : System.Web.UI.Page
    {

        public modeloSucuralempresa ModelosucursalEmpresa = new modeloSucuralempresa();
        public List<modeloSucuralempresa> ListaModeloSucursalEmpresa = new List<modeloSucuralempresa>();
        public Consultawmsucempresa ConsultaSucEmpresa = new Consultawmsucempresa();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        ConsultaCierecaja ConsultaCCaja = new ConsultaCierecaja();
        modeloCierreCaja modeloCCcaja = new modeloCierreCaja();
        modeloCierreCaja guardarCCcaja = new modeloCierreCaja();
        List<modeloCierreCaja> listaCCaja = null;

        ConsultaEfectivoCaja ConsultaEfectivoC = new ConsultaEfectivoCaja();
        modeloEfectivoCaja modeloEfectivoC = new modeloEfectivoCaja();
        modeloEfectivoCaja guardarEfectivoC = new modeloEfectivoCaja();
        List<modeloEfectivoCaja> listaEfectivoC = new List<modeloEfectivoCaja>();

        Consultawmspcmonedas ConsultaCMonedas = new Consultawmspcmonedas();
        List<modelowmspcmonedas> listaMonedas = null;
        modelowmspcmonedas DecimalesMoneda = new modelowmspcmonedas();
        modeloDenominacionesMoneda denominacion = new modeloDenominacionesMoneda();

        ConsultaEmpresa consultaEmpresa = new ConsultaEmpresa();
        List<modelowmspcempresas> listaEmpresa = null;
        modelowmspcempresas modeloEmpresa = new modelowmspcempresas();

        Consultawmsptitulares UsuarioDatos = new Consultawmsptitulares();

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();

        modeloCajasCierre modeloCajasUsuario = new modeloCajasCierre();
        List<modeloCajasCierre> listaCajasUsuario = null;
        public string numerador = "trans";
        public string ComPwm;
        public string AmUsrLog;
        public string nro_trans = null;
        public string cod_proceso;
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

                    string caja = "";
                    string nro_trans = "";
                    string fecha = "";
                    Int64 secuencial = 0;
                    if (Session["Caja"] != null)
                    {

                        caja = Session["Caja"].ToString();
                    }
                    if (Session["Nro_trans"] != null)
                    {

                        nro_trans = Session["Nro_trans"].ToString();
                    }
                    if (Session["Secuencial"] != null)
                    {
                        secuencial = Convert.ToInt64(Session["Secuencial"].ToString());

                    }
                    if (Session["fecha_c"] != null)
                    {
                        fecha = Session["fecha_c"].ToString();

                    }
                    DateTime fecha_st = DateTime.Parse(fecha);
                    lbl_dia.Text = fecha_st.ToString("dddd", new CultureInfo("es-ES")).ToUpper();
                    lbl_fecha.Text = fecha;

                    Tabla.Visible = false;

                    Lbl_Usuario.Text = UsuarioDatos.BuscarNombreUsuario(AmUsrLog.Trim());
                    LlenarCierreCaja(nro_trans, secuencial, caja);


                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());
            }


        }
        protected void btn_ingreso_facturas_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                Session["Fecha"] = lbl_fecha.Text;
                this.Page.Response.Write("<script language='JavaScript'>window.open('./BuscarIngresoFacturasPgs.aspx', 'Ingreso Facturas', 'top=100,width=800 ,height=400, left=400');</script>");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_ingreso_facturas_Click", ex.ToString());

            }
        }

        protected void btn_ingreso_nventas_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                Session["Fecha"] = lbl_fecha.Text;
                this.Page.Response.Write("<script language='JavaScript'>window.open('./BuscarNotasVenta.aspx', 'Notas Venta', 'top=100,width=800 ,height=400, left=400');</script>");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_ingreso_nventas_Click", ex.ToString());

            }

        }

        protected void btn_pefectivo_facturas_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                Session["Fecha"] = lbl_fecha.Text;
                this.Page.Response.Write("<script language='JavaScript'>window.open('./BuscarPProveedores.aspx', 'Pago Proveedores', 'top=100,width=800 ,height=400, left=400');</script>");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_pefectivo_facturas_Click", ex.ToString());

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
        //Buscar cantidad de decimales q se va ausar x tipo de moneda
        public modelowmspcmonedas BuscarDecimales()
        {
            try
            {
                lbl_error.Text = "";
                listaEmpresa = consultaEmpresa.BuscartaEmpresa(AmUsrLog, ComPwm);
                modeloEmpresa = null;
                foreach (modelowmspcempresas item in listaEmpresa)
                {

                    modeloEmpresa = item;
                    break;

                }

                listaMonedas = ConsultaCMonedas.ConsultaCMonedas(AmUsrLog, ComPwm, modeloEmpresa.mone_mn.Trim());

                DecimalesMoneda = null;
                foreach (modelowmspcmonedas item in listaMonedas)
                {

                    DecimalesMoneda = item;
                    break;

                }

                return DecimalesMoneda;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarDecimales", ex.ToString());
                return null;

            }

        }
        public void LlenarCierreCaja(string nro_trans, Int64 secuencial, string caja)
        {
        //Consulta si existe o no Cierres pasados

              //Buscamos el ultimo secuancial
              DecimalesMoneda = null;
              DecimalesMoneda = BuscarDecimales();
              decimal totalCaja = 0;
              decimal SaldoCaja = 0;
              decimal SaldoN = 0;
            

              listaEfectivoC = ConsultaEfectivoC.ListaCCajaFecha(nro_trans, secuencial, ComPwm, AmUsrLog);
              Grid.DataSource = listaEfectivoC;
              Grid.DataBind();
              Grid.Height = 100;
              foreach (modeloEfectivoCaja item in listaEfectivoC)
              {
                  modeloEfectivoC = item;
                  totalCaja += modeloEfectivoC.total;
              }
              decimal valorCaja = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, totalCaja);
              txt_valor_caja.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, valorCaja);

              ///campo uno
              Int64 secCierre = Convert.ToInt64(secuencial);
              string codigo = "VIDA";
              listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(nro_trans, secCierre, codigo, ComPwm, AmUsrLog);
              modeloCCcaja = null;
              foreach (modeloCierreCaja item in listaCCaja)
              {
                  modeloCCcaja = item;
              }
              decimal valor_id = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
              txt_valor_id.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, valor_id);
              txt_valor_id.ReadOnly = true;
              SaldoCaja = modeloCCcaja.valor;
              //campo dos
              listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(nro_trans, secCierre, "INFA", ComPwm, AmUsrLog);
              modeloCCcaja = null;
              foreach (modeloCierreCaja item in listaCCaja)
              {
                  modeloCCcaja = item;
              }
              decimal ingreso_facturas = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
              txt_ingreso_facturas.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, ingreso_facturas);
              txt_ingreso_facturas.ReadOnly = true;
              SaldoCaja += modeloCCcaja.valor;
              //campo tres
              listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(nro_trans, secCierre, "INVT", ComPwm, AmUsrLog);
              modeloCCcaja = null;
              foreach (modeloCierreCaja item in listaCCaja)
              {
                  modeloCCcaja = item;
              }
              decimal ingreso_nventas = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
              txt_ingreso_nventas.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, ingreso_nventas);
              txt_ingreso_nventas.ReadOnly = true;
              SaldoCaja += modeloCCcaja.valor;
              //campo cuatro
              listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(nro_trans, secCierre, "PEFA", ComPwm, AmUsrLog);
              modeloCCcaja = null;
              foreach (modeloCierreCaja item in listaCCaja)
              {
                  modeloCCcaja = item;
              }
              decimal pefectivo_facturas = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
              txt_pefectivo_facturas.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, pefectivo_facturas);
              txt_pefectivo_facturas.ReadOnly = true;
              SaldoN = modeloCCcaja.valor;
              //campoCINCO
              listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(nro_trans, secCierre, "PEOT", ComPwm, AmUsrLog);
              modeloCCcaja = null;
              foreach (modeloCierreCaja item in listaCCaja)
              {
                  modeloCCcaja = item;
              }
              decimal pefectivo_otros = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
              txt_pefectivo_otros.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, pefectivo_otros);
              txt_pefectivo_otros.ReadOnly = true;
              SaldoN += modeloCCcaja.valor;
              //CAMPO SEIS           
              listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(nro_trans, secCierre, "DEPD", ComPwm, AmUsrLog);
              modeloCCcaja = null;
              foreach (modeloCierreCaja item in listaCCaja)
              {
                  modeloCCcaja = item;
              }
              decimal depositos = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
              txt_depositos.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, depositos);
              txt_depositos.ReadOnly = true;
              SaldoN += modeloCCcaja.valor;
              //CAMPO SIETE
              listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(nro_trans, secCierre, "EFPC", ComPwm, AmUsrLog);
              modeloCCcaja = null;
              foreach (modeloCierreCaja item in listaCCaja)
              {
                  modeloCCcaja = item;
              }
              decimal efectivoCaja = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
              txt_efectivo_caja.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, efectivoCaja);
              txt_efectivo_caja.ReadOnly = true;
              SaldoCaja += modeloCCcaja.valor;

              decimal totalS = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (SaldoCaja - SaldoN));

              txt_saldo_caja.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, totalS);
              decimal Diferencia = Convert.ToDecimal(txt_valor_caja.Text) - Convert.ToDecimal(txt_saldo_caja.Text);
              decimal dif = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Diferencia);

              txt_diferencia.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, dif);
              Tabla.Visible = true;
            

              listaCajasUsuario = null;
              listaCajasUsuario = ConsultaCCaja.ConsultadatosCaja(AmUsrLog, ComPwm, "", "", caja);
              modeloCajasUsuario = null;
              foreach (modeloCajasCierre item in listaCajasUsuario)
              {
                  modeloCajasUsuario = item;
              }
              lbl_caja_usuario.Text = modeloCajasUsuario.nomtcta_banco;

           }
        public void GuardarExcepciones(string metodo, string error)
        {

            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "BuscarCierreCaja.aspx";
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
    }
}