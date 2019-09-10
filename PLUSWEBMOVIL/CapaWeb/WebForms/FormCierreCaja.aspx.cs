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
    public partial class FormCierreCaja : System.Web.UI.Page
    {
        public modeloSucuralempresa ModelosucursalEmpresa = new modeloSucuralempresa();
        public List<modeloSucuralempresa> ListaModeloSucursalEmpresa = new List<modeloSucuralempresa>();
        public Consultawmsucempresa ConsultaSucEmpresa = new Consultawmsucempresa();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();


      
        ConsultaEfectivoCaja ConsultaECaja = new ConsultaEfectivoCaja();
        modeloTotalPgsFacturas modeloTPFacturas = new modeloTotalPgsFacturas();
        List<modeloTotalPgsFacturas> listaTPFacturas = null;

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
        modeloDenominacionesMoneda Denominaciones = new modeloDenominacionesMoneda();
        List<modeloDenominacionesMoneda> listaDenominacion = null;
        ConsultaEmpresa consultaEmpresa = new ConsultaEmpresa();
        List<modelowmspcempresas> listaEmpresa = null;
        modelowmspcempresas modeloEmpresa = new modelowmspcempresas();

        Consultawmsptitulares UsuarioDatos = new Consultawmsptitulares();

        ConsultaIngresoFacturas consultaIngFaturas = new ConsultaIngresoFacturas();
        modeloIngresoFacturas modeloFaturasPgs = new modeloIngresoFacturas();
        List<modeloIngresoFacturas> listaIngresosFac = null;

        
        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();

        public string ComPwm;
        public string AmUsrLog;
        public string nro_trans = null;
        public string cod_proceso;
        public string numerador = "trans";
        public string valor_asignado = null;
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
                Session.Remove("valor_asignado");
                if (!IsPostBack)
                {
                    Session.Remove("valor_asignado");
                    DecimalesMoneda = null;
                    DecimalesMoneda = BuscarDecimales();
                    lbl_fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                    lbl_dia.Text = DateTime.Today.ToString("dddd", new CultureInfo("es-ES")).ToUpper();
                    CargarGrilla();
                    llenarCampos(lbl_fecha.Text);
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());

            }
        }
        public void GuardarExcepciones(string metodo, string error)
        {
            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "FormCierreCaja.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Today;
            ModeloExcepcion.usuario_mod = AmUsrLog;
            
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }
        public void llenarCampos(string fecha)
        {
            try
            {
                lbl_error.Text = "";


                //tOTAL FACTURAS DEL DIA
                listaTPFacturas = ConsultaECaja.ConsultaCCajaFecha(fecha);
                int count = 0;
                modeloTPFacturas = null;
                foreach (modeloTotalPgsFacturas item in listaTPFacturas)
                {
                    count++;
                    modeloTPFacturas = item;

                }
                if (modeloTPFacturas.total == "")
                {
                    txt_ingreso_facturas.Text = "0.00";
                }
                else
                {
                    decimal ipfac = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), Convert.ToDecimal(modeloTPFacturas.total));
                    txt_ingreso_facturas.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), ipfac);

                }


                //TOTAL NOTAS DE VENTA DEL DIA
                listaTPFacturas = null;
                listaTPFacturas = ConsultaECaja.ConsultaTotalNVTA(fecha);
                int count1 = 0;
                modeloTPFacturas = null;
                foreach (modeloTotalPgsFacturas item in listaTPFacturas)
                {
                    count1++;
                    modeloTPFacturas = item;

                }
                if (modeloTPFacturas.total == "")
                {
                    txt_ingreso_nventas.Text = "0.00";
                }
                else
                {
                    decimal inv = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), Convert.ToDecimal(modeloTPFacturas.total));

                    txt_ingreso_nventas.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), inv);

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("llenarCampos", ex.ToString());

            }

        }
        private void CargarGrilla()
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
                listaDenominacion = ConsultaCMonedas.ConsultaDenominacionesEmpresa(modeloEmpresa.mone_mn.Trim());
                Grid.DataSource = listaDenominacion;
                Grid.DataBind();
                Grid.Height = 100;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("CargarGrilla", ex.ToString());
                
            }
        }
        

        protected void Grid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                //1 primero creo un objeto Clave/Valor de QueryString 
                QueryString qs = new QueryString();
                //Escoger opcion

                string Id;

                switch (e.CommandName) //ultilizo la variable para la opcion
                {

                    case "Editar": //ejecuta el codigo si el usuario ingresa el numero 1
                        try
                        {
                            Id = Convert.ToString(((Label)e.Item.Cells[1].FindControl("id")).Text);

                            //2 voy a agregando los valores que deseo
                            qs.Add("TRN", "UDP");
                            qs.Add("Id", Id.ToString());

                            Response.Redirect("FormDenominaciones.aspx" + Encryption.EncryptQueryString(qs).ToString());
                            break;//termina la ejecucion del programa despues de ejecutar el codigo     
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("Grid_ItemCommand, Editar", ex.ToString());

                        }
                        break;



                    case "Eliminar": //ejecuta el codigo si el usuario ingresa el numero 3
                        try
                        {
                            Id = Convert.ToString(((Label)e.Item.Cells[1].FindControl("id")).Text);

                            qs.Add("TRN", "DLT");
                            qs.Add("Id", Id.ToString());

                            Response.Redirect("FormDenominaciones.aspx" + Encryption.EncryptQueryString(qs).ToString());
                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("Grid_ItemCommand, eliminar", ex.ToString());

                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Grid_ItemCommand", ex.ToString());

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

        protected void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                decimal acumulador = 0;

                foreach (GridViewRow item in Grid.Rows)
                {
                    decimal valor1 = 0;
                    Label valor = item.FindControl("valor") as Label;
                    TextBox cantidad = item.FindControl("cantidad") as TextBox;
                    Decimal.TryParse(valor.Text, out valor1);
                    acumulador = Convert.ToDecimal(cantidad.Text) * valor1;
                    item.Cells[4].Text = acumulador.ToString();

                }
                txt_saldo_caja.Text = acumulador.ToString();
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_imprimir_Click", ex.ToString());

            }
        }

        protected void InsertarTotales()
        {
            try
            {
                lbl_error.Text = "";

                //Buscar nro_trans
                if (Session["valor_asignado"] == null)
                {

                    //obtener numero de transaccion
                    nrotrans = ConsultaNroTran.ConsultaNumeradores(numerador);
                    valor_asignado = nrotrans.valor_asignado;
                    //Guardar N° transaccion 
                    Session["valor_asignado"] = valor_asignado;
                }
                Int64 secuencialCierreResumenCaja = ConsultaCCaja.BuscarCCajaFechaSecuencial(lbl_fecha.Text, ComPwm.Trim());
                //Recuperar si ya existe cierre del dia

                //wmt_cierre_resumenaja

                //Guardar linea x linea VALOR EN CAJA INICIO DEL DIA
                guardarCCcaja.signo = "+";
                guardarCCcaja.secuencial = secuencialCierreResumenCaja;
                guardarCCcaja.codigo = "VIDA";
                guardarCCcaja.nombre = lbl_idc.Text;
                guardarCCcaja.valor = Convert.ToDecimal(txt_valor_id.Text);
                guardarCCcaja.usuario_mod = AmUsrLog;
                guardarCCcaja.fecha_cie = lbl_fecha.Text;
                guardarCCcaja.fecha_mod = DateTime.Today;
                guardarCCcaja.cod_emp = ComPwm;
                guardarCCcaja.nro_trans = valor_asignado;
                ConsultaCCaja.InsertarCierreCaja(guardarCCcaja);
                //Guardar linea x linea ingresos facturas
                guardarCCcaja.signo = "+";
                guardarCCcaja.secuencial = secuencialCierreResumenCaja;
                guardarCCcaja.codigo = "INFA";
                guardarCCcaja.nombre = lbl_2.Text;
                guardarCCcaja.valor = Convert.ToDecimal(txt_ingreso_facturas.Text);
                guardarCCcaja.usuario_mod = AmUsrLog;
                guardarCCcaja.fecha_cie = lbl_fecha.Text;
                guardarCCcaja.fecha_mod = DateTime.Today;
                guardarCCcaja.cod_emp = ComPwm;
                guardarCCcaja.nro_trans = valor_asignado;
                ConsultaCCaja.InsertarCierreCaja(guardarCCcaja);
                //Guardar linea x linea ingresos NOTAS VENTA
                guardarCCcaja.signo = "+";
                guardarCCcaja.secuencial = secuencialCierreResumenCaja;
                guardarCCcaja.codigo = "INVT";
                guardarCCcaja.nombre = lbl_3.Text;
                guardarCCcaja.valor = Convert.ToDecimal(txt_ingreso_nventas.Text);
                guardarCCcaja.usuario_mod = AmUsrLog;
                guardarCCcaja.fecha_cie = lbl_fecha.Text;
                guardarCCcaja.fecha_mod = DateTime.Today;
                guardarCCcaja.cod_emp = ComPwm;
                guardarCCcaja.nro_trans = valor_asignado;
                ConsultaCCaja.InsertarCierreCaja(guardarCCcaja);
                //Guardar linea x linea PAGOS EN FECTIVO FACTURAS
                guardarCCcaja.signo = "-";
                guardarCCcaja.secuencial = secuencialCierreResumenCaja;
                guardarCCcaja.codigo = "PEFA";
                guardarCCcaja.nombre = lbl_4.Text;
                guardarCCcaja.valor = Convert.ToDecimal(txt_pefectivo_facturas.Text);
                guardarCCcaja.usuario_mod = AmUsrLog;
                guardarCCcaja.fecha_cie = lbl_fecha.Text;
                guardarCCcaja.fecha_mod = DateTime.Today;
                guardarCCcaja.cod_emp = ComPwm;
                guardarCCcaja.nro_trans = valor_asignado;
                ConsultaCCaja.InsertarCierreCaja(guardarCCcaja);
                //Guardar linea x linea PAGOS EN FECTIVO OTROS
                guardarCCcaja.signo = "-";
                guardarCCcaja.secuencial = secuencialCierreResumenCaja;
                guardarCCcaja.codigo = "PEOT";
                guardarCCcaja.nombre = lbl_5.Text;
                guardarCCcaja.valor = Convert.ToDecimal(txt_pefectivo_otros.Text);
                guardarCCcaja.usuario_mod = AmUsrLog;
                guardarCCcaja.fecha_cie = lbl_fecha.Text;
                guardarCCcaja.fecha_mod = DateTime.Today;
                guardarCCcaja.cod_emp = ComPwm;
                guardarCCcaja.nro_trans = valor_asignado;
                ConsultaCCaja.InsertarCierreCaja(guardarCCcaja);
                //Guardar linea x linea DEPOSITOS DEL DIA
                guardarCCcaja.signo = "-";
                guardarCCcaja.secuencial = secuencialCierreResumenCaja;
                guardarCCcaja.codigo = "DEPD";
                guardarCCcaja.nombre = lbl_6.Text;
                guardarCCcaja.valor = Convert.ToDecimal(txt_depositos.Text);
                guardarCCcaja.usuario_mod = AmUsrLog;
                guardarCCcaja.fecha_cie = lbl_fecha.Text;
                guardarCCcaja.fecha_mod = DateTime.Today;
                guardarCCcaja.cod_emp = ComPwm;
                guardarCCcaja.nro_trans = valor_asignado;
                ConsultaCCaja.InsertarCierreCaja(guardarCCcaja);

                DecimalesMoneda = null;
                DecimalesMoneda = BuscarDecimales();
                //Guardar linea x linea DEPOSITOS DEL DIA
                guardarCCcaja.signo = "+";
                guardarCCcaja.secuencial = secuencialCierreResumenCaja;
                guardarCCcaja.codigo = "EFPC";
                guardarCCcaja.nombre = lbl_7.Text;
                guardarCCcaja.valor = Convert.ToDecimal(txt_efectivo_caja.Text);
                guardarCCcaja.usuario_mod = AmUsrLog;
                guardarCCcaja.fecha_cie = lbl_fecha.Text;
                guardarCCcaja.fecha_mod = DateTime.Today;
                guardarCCcaja.cod_emp = ComPwm;
                guardarCCcaja.nro_trans = valor_asignado;
                ConsultaCCaja.InsertarCierreCaja(guardarCCcaja);

                DecimalesMoneda = null;
                DecimalesMoneda = BuscarDecimales();
                //wmt_efectivoCaja
                Int64 secuencialEfectivoC = ConsultaEfectivoC.BuscarEfectivoSecuencial(lbl_fecha.Text, ComPwm);
                //Calcula datos de la grilla
                decimal acumulador = 0;
                decimal totalDenominacion = 0;
                string Total = "";
                foreach (GridViewRow item in Grid.Rows)
                {
                    decimal valor1 = 0;
                    Label valor = item.FindControl("valor") as Label;
                    TextBox cantidad = item.FindControl("cantidad") as TextBox;
                    Decimal.TryParse(valor.Text, out valor1);
                    acumulador = Convert.ToDecimal(cantidad.Text) * valor1;
                    totalDenominacion += acumulador;
                    Total = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, acumulador);
                    item.Cells[4].Text = Total;
                    string idDen = item.Cells[0].Text;
                    guardarEfectivoC.denominacionMId = Convert.ToDecimal(idDen);
                    guardarEfectivoC.valor = Convert.ToDecimal(valor.Text);
                    guardarEfectivoC.cantidad = Convert.ToDecimal(cantidad.Text);
                    guardarEfectivoC.total = Convert.ToDecimal(acumulador);
                    guardarEfectivoC.usuario_mod = AmUsrLog;
                    guardarEfectivoC.fecha_mod = DateTime.Today;
                    guardarEfectivoC.fecha_efe = lbl_fecha.Text;
                    guardarEfectivoC.secuencial = secuencialEfectivoC;
                    guardarEfectivoC.cod_emp = ComPwm;
                    guardarEfectivoC.nro_trans = valor_asignado;
                    ConsultaEfectivoC.InsertarECaja(guardarEfectivoC);

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("InsertarTotales", ex.ToString());

            }

        }

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
                Session["redondeo"] = DecimalesMoneda.redondeo;
                Session["redondeo_pu"] = DecimalesMoneda.redondeo_pu;
                return DecimalesMoneda;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarDecimales", ex.ToString());
                return null;

            }
        }
        protected void CalcularTotal()
        {

            try
            {
                lbl_error.Text = "";

                DecimalesMoneda = null;
                DecimalesMoneda = BuscarDecimales();

                //Calcula datos de la grilla
                decimal acumulador = 0;
                decimal totalDenominacion = 0;
                string Total = "";
                foreach (GridViewRow item in Grid.Rows)
                {

                    decimal valor1 = 0;
                    Label valor = item.FindControl("valor") as Label;
                    TextBox cantidad = item.FindControl("cantidad") as TextBox;
                    Decimal.TryParse(valor.Text, out valor1);
                    acumulador = Convert.ToDecimal(cantidad.Text) * valor1;
                    totalDenominacion += acumulador;
                    Total = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, acumulador);

                    item.Cells[4].Text = Total;

                }



                decimal TotaValor = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, totalDenominacion);
                txt_valor_caja.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, TotaValor);
                //Calcula datos de los txt

                decimal Total_saldo = Convert.ToDecimal(txt_ingreso_facturas.Text) + Convert.ToDecimal(txt_ingreso_nventas.Text) + Convert.ToDecimal(txt_valor_id.Text) + Convert.ToDecimal(txt_efectivo_caja.Text);
                decimal saldos_neg = Convert.ToDecimal(txt_pefectivo_facturas.Text) + Convert.ToDecimal(txt_pefectivo_otros.Text) + Convert.ToDecimal(txt_depositos.Text);
                decimal total_SC = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (Total_saldo - saldos_neg));
                txt_saldo_caja.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, total_SC);
                decimal Diferencia = Convert.ToDecimal(txt_valor_caja.Text) - Convert.ToDecimal(txt_saldo_caja.Text);
                decimal to_difere = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Diferencia);

                txt_diferencia.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, to_difere);
            }
            catch (Exception ex)
            {
                GuardarExcepciones("CalcularTotal", ex.ToString());

            }
        }


        protected void Btn_Calcular_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                CalcularTotal();
               
                Lbl_Usuario.Text = UsuarioDatos.BuscarNombreUsuario(AmUsrLog.Trim());
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Btn_Calcular_Click", ex.ToString());

            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                Response.Redirect("BuscarCierreCaja.aspx");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_cancelar_Click", ex.ToString());

            }
        }


        protected void txt_valor_id_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                lbl_mensaje.Text = "";
               
                if (ValidarNumero(txt_valor_id.Text))
                {
                    decimal valor = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), Convert.ToDecimal(txt_valor_id.Text));
                    txt_valor_id.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), valor);
                }
                else
                {
                    txt_valor_id.Text = "";
                    lbl_mensaje.Text = "Números con formato incorrecto.";
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("txt_valor_id_TextChanged", ex.ToString());
                lbl_mensaje.Text = "Números con formato incorrecto.";
                lbl_error.Text = "";
            }
            
           
        }

        public bool ValidarNumero(string texto)
        {
            try
            {
                lbl_error.Text = "";

                decimal valor = Convert.ToDecimal(texto);
                if(valor<0 )
                {
                    return false;
                }
               
                    return true;
                
                
            }
            catch (Exception e)
            {
                GuardarExcepciones("ValidarNumero", e.ToString());
                lbl_error.Text = "";
                return false ;
            }
        }

        protected void txt_ingreso_facturas_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                lbl_mensaje.Text = "";

                if (ValidarNumero(txt_ingreso_facturas.Text))
                {
                    decimal valor = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), Convert.ToDecimal(txt_ingreso_facturas.Text));
                    txt_ingreso_facturas.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), valor);
                }
                else
                {
                    txt_ingreso_facturas.Text = "";
                    lbl_mensaje.Text = "Números con formato incorrecto.";
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("txt_ingreso_facturas_TextChanged", ex.ToString());
                lbl_mensaje.Text = "Números con formato incorrecto.";
                lbl_error.Text = "";
            }
           
        }

        protected void txt_ingreso_nventas_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_mensaje.Text = "";
                lbl_error.Text = "";

                if (ValidarNumero(txt_ingreso_nventas.Text))
                {
                    decimal valor = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), Convert.ToDecimal(txt_ingreso_nventas.Text));
                    txt_ingreso_nventas.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), valor);
                }
                else
                {
                    txt_ingreso_nventas.Text = "";
                    lbl_mensaje.Text = "Números con formato incorrecto.";
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("txt_ingreso_nventas_TextChanged", ex.ToString());

                lbl_mensaje.Text = "Números con formato incorrecto.";
                lbl_error.Text = "";
            }
            
        }

        protected void txt_pefectivo_facturas_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_mensaje.Text = "";
                lbl_error.Text = "";

                if (ValidarNumero(txt_pefectivo_facturas.Text))
                {
                    decimal valor = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), Convert.ToDecimal(txt_pefectivo_facturas.Text));
                    txt_pefectivo_facturas.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), valor);
                }
                else
                {
                    txt_pefectivo_facturas.Text = "";
                    lbl_mensaje.Text = "Números con formato incorrecto.";
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("txt_pefectivo_facturas_TextChanged", ex.ToString());
                lbl_mensaje.Text = "Números con formato incorrecto.";
                lbl_error.Text = "";
            }
            

        }

        protected void txt_pefectivo_otros_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_mensaje.Text = "";
                lbl_error.Text = "";
                if (ValidarNumero(txt_pefectivo_otros.Text))
                {
                    decimal valor = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), Convert.ToDecimal(txt_pefectivo_otros.Text));
                    txt_pefectivo_otros.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), valor);
                }
                else
                {
                    txt_pefectivo_otros.Text = "";
                    lbl_mensaje.Text = "Números con formato incorrecto.";
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("txt_pefectivo_otros_TextChanged", ex.ToString());

                lbl_mensaje.Text = "Números con formato incorrecto.";
                lbl_error.Text = "";
            }
           
        }

        protected void txt_depositos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                lbl_mensaje.Text = "";

                if (ValidarNumero(txt_depositos.Text))
                {
                    decimal valor = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), Convert.ToDecimal(txt_depositos.Text));
                    txt_depositos.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), valor);
                }
                else
                {
                    txt_depositos.Text = "";
                    lbl_mensaje.Text = "Números con formato incorrecto.";
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("txt_depositos_TextChanged", ex.ToString());

                lbl_mensaje.Text = "Números con formato incorrecto.";
                lbl_error.Text = "";
            }   
            
        }

        protected void txt_efectivo_caja_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_mensaje.Text = "";
                lbl_error.Text = "";
                if (ValidarNumero(txt_efectivo_caja.Text))
                {
                    decimal valor = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), Convert.ToDecimal(txt_efectivo_caja.Text));
                    txt_efectivo_caja.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), valor);
                }
                else
                {
                    txt_efectivo_caja.Text = "";
                    lbl_mensaje.Text = "Números con formato incorrecto.";
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("txt_depositos_TextChanged", ex.ToString());

                lbl_mensaje.Text = "Números con formato incorrecto.";
                lbl_error.Text = "";
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

        protected void btn_confirmar_Click(object sender, EventArgs e)
        {
            //Mostrar campo imprimir y bloquear el formulario despues de guardar
            try
            {
                lbl_error.Text = "";

                CalcularTotal();
                InsertarTotales();
                Lbl_Usuario.Text = UsuarioDatos.BuscarNombreUsuario(AmUsrLog.Trim());
                txt_valor_id.Enabled = false;
                txt_ingreso_facturas.Enabled = false;

                txt_ingreso_nventas.Enabled = false;
                txt_pefectivo_facturas.Enabled = false;
                txt_pefectivo_otros.Enabled = false;
                txt_depositos.Enabled = false;
                txt_diferencia.Enabled =false;
                txt_efectivo_caja.Enabled = false;
                Btn_Calcular.Visible = false;
                btn_confirmar.Visible = false;
                Grid.Enabled = false;
                txt_saldo_caja.Enabled = false;
                txt_valor_caja.Enabled = false;
                

            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_confirmar_Click", ex.ToString());

            }
        }
    }
}