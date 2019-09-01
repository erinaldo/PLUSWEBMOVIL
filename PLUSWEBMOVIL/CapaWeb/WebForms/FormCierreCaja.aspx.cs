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

        public string ComPwm;
        public string AmUsrLog;
        public string nro_trans = null;
        public string cod_proceso;
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
                DecimalesMoneda = null;
                DecimalesMoneda = BuscarDecimales();
                lbl_fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                lbl_dia.Text =  DateTime.Today.ToString("dddd", new CultureInfo("es-ES")).ToUpper();               
                CargarGrilla();
                llenarCampos(lbl_fecha.Text);
            }
        }
        public void llenarCampos(string fecha)
        {
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
                txt_ingreso_facturas.Text = modeloTPFacturas.total.ToString();

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
            }else
            {
                txt_ingreso_nventas.Text = modeloTPFacturas.total.ToString();

            }
            
        }
        private void CargarGrilla()
        {
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
        

        protected void Grid_ItemCommand(object source, DataGridCommandEventArgs e)
        {

            //1 primero creo un objeto Clave/Valor de QueryString 
            QueryString qs = new QueryString();
            //Escoger opcion

            string Id;

            switch (e.CommandName) //ultilizo la variable para la opcion
            {

                case "Editar": //ejecuta el codigo si el usuario ingresa el numero 1
                    Id = Convert.ToString(((Label)e.Item.Cells[1].FindControl("id")).Text);

                    //2 voy a agregando los valores que deseo
                    qs.Add("TRN", "UDP");
                    qs.Add("Id", Id.ToString());

                    Response.Redirect("FormDenominaciones.aspx" + Encryption.EncryptQueryString(qs).ToString());
                    break;//termina la ejecucion del programa despues de ejecutar el codigo                   



                case "Eliminar": //ejecuta el codigo si el usuario ingresa el numero 3
                    Id = Convert.ToString(((Label)e.Item.Cells[1].FindControl("id")).Text);

                    qs.Add("TRN", "DLT");
                    qs.Add("Id", Id.ToString());

                    Response.Redirect("FormDenominaciones.aspx" + Encryption.EncryptQueryString(qs).ToString());
                    break;
            }
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

        public QueryString ulrDesencriptada()
        {
            //1- guardo el Querystring encriptado que viene desde el request en mi objeto
            QueryString qs = new QueryString(Request.QueryString);

            ////2- Descencripto y de esta manera obtengo un array Clave/Valor normal
            qs = Encryption.DecryptQueryString(qs);
            return qs;
        }

        protected void btn_imprimir_Click(object sender, EventArgs e)
        {
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

        protected void InsertarTotales()
        {

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
                guardarEfectivoC.cod_emp =ComPwm;
                ConsultaEfectivoC.InsertarECaja(guardarEfectivoC);

            }
            
        }

        public modelowmspcmonedas BuscarDecimales()
        {
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
        protected void CalcularTotal()
        {
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
            
            decimal  Total_saldo = Convert.ToDecimal(txt_ingreso_facturas.Text) + Convert.ToDecimal(txt_ingreso_nventas.Text) + Convert.ToDecimal(txt_valor_id.Text) + Convert.ToDecimal(txt_efectivo_caja.Text);
            decimal saldos_neg = Convert.ToDecimal(txt_pefectivo_facturas.Text )+ Convert.ToDecimal(txt_pefectivo_otros.Text) + Convert.ToDecimal(txt_depositos.Text);
            decimal total_SC = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (Total_saldo - saldos_neg));
            txt_saldo_caja.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, total_SC);
            decimal Diferencia = Convert.ToDecimal(txt_valor_caja.Text) - Convert.ToDecimal(txt_saldo_caja.Text);
            decimal to_difere = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Diferencia);

            txt_diferencia.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, to_difere); 
        }


        protected void Btn_Calcular_Click(object sender, EventArgs e)
        {
            CalcularTotal();
            InsertarTotales();
            Lbl_Usuario.Text = UsuarioDatos.BuscarNombreUsuario(AmUsrLog.Trim());
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarCierreCaja.aspx");
        }


        protected void txt_valor_id_TextChanged(object sender, EventArgs e)
        {
            try
            {
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
            catch (Exception)
            {

                lbl_mensaje.Text = "Números con formato incorrecto.";
            }
            
           
        }

        public bool ValidarNumero(string texto)
        {
            try
            {

                decimal valor = Convert.ToDecimal(texto);
                if(valor<0 )
                {
                    return false;
                }
               
                    return true;
                
                
            }
            catch (Exception)
            {

               return false ;
            }
        }

        protected void txt_ingreso_facturas_TextChanged(object sender, EventArgs e)
        {
            try
            {
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
            catch (Exception)
            {

                lbl_mensaje.Text = "Números con formato incorrecto.";
            }
           
        }

        protected void txt_ingreso_nventas_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_mensaje.Text = "";

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
            catch (Exception)
            {

                lbl_mensaje.Text = "Números con formato incorrecto.";
            }
            
        }

        protected void txt_pefectivo_facturas_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_mensaje.Text = "";

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
            catch (Exception)
            {

                lbl_mensaje.Text = "Números con formato incorrecto.";
            }
            

        }

        protected void txt_pefectivo_otros_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_mensaje.Text = "";

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
            catch (Exception)
            {

                lbl_mensaje.Text = "Números con formato incorrecto.";
            }
           
        }

        protected void txt_depositos_TextChanged(object sender, EventArgs e)
        {
            try
            {
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
            catch (Exception)
            {

                lbl_mensaje.Text = "Números con formato incorrecto.";
            }   
            
        }

        protected void txt_efectivo_caja_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_mensaje.Text = "";

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
            catch (Exception)
            {

                lbl_mensaje.Text = "Números con formato incorrecto.";
            }

        }
    }
}