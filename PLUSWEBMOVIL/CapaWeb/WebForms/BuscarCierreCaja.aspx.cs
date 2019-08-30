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
    public partial class BuscarCierreCaja : System.Web.UI.Page
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
                

                //fechainicio.Text = DateTime.Today.ToString("yyyy-MM-dd");
                Tabla.Visible = false;
                imp.Visible = false;
                Buscar.Visible = false;
                cbx_lista_cierres.Visible = false;
                Lbl_Usuario.Text = UsuarioDatos.BuscarNombreUsuario(AmUsrLog.Trim());
            }

        }

        private void CargarGrilla()
        {
           /* listaMonedas = ConsultaCMonedas.ConsultaDenominacionesMonedas();
            // ListaModeloSucursalEmpresa = ConsultaSucEmpresa.ConsultaSucursalEmpresa(ComPwm);
            Grid.DataSource = listaMonedas;
            Grid.DataBind();
            Grid.Height = 100;*/
        }

        //Buscar cantidad de decimales q se va ausar x tipo de moneda
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

            return DecimalesMoneda;
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
        protected void NuevoCierre_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormCierreCaja.aspx");
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            //Consulta si existe o no Cierres pasados
           
            //Buscamos el ultimo secuancial
            DecimalesMoneda = null;
            DecimalesMoneda = BuscarDecimales();
            decimal totalCaja = 0;
            decimal SaldoCaja = 0;
            decimal SaldoN = 0;
            //Int64 secuEfe = ConsultaEfectivoC.UltimoEfectivoSecuencial(fechainicio.Text);
            Int64 secuEfe = Convert.ToInt64(cbx_lista_cierres.SelectedValue);
                
            listaEfectivoC = ConsultaEfectivoC.ListaCCajaFecha(fechainicio.Text, secuEfe);
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

            ///Int64 secCierre = ConsultaCCaja.UltimoCCajaFechaSecuencial(fechainicio.Text);
            Int64 secCierre = Convert.ToInt64(cbx_lista_cierres.SelectedValue);
            string codigo = "VIDA";
            listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(fechainicio.Text, secCierre, codigo);
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
            listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(fechainicio.Text, secCierre, "INFA");
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
            listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(fechainicio.Text, secCierre, "INVT");
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
            listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(fechainicio.Text, secCierre, "PEFA");
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
            listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(fechainicio.Text, secCierre, "PEOT");
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
            //campo dos
            listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(fechainicio.Text, secCierre, "DEPD");
            modeloCCcaja = null;
            foreach (modeloCierreCaja item in listaCCaja)
            {
                modeloCCcaja = item;
            }
            decimal depositos = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
            txt_depositos.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, depositos);
            txt_depositos.ReadOnly = true;
            SaldoN += modeloCCcaja.valor;
            decimal totalS = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (SaldoCaja - SaldoN));

            txt_saldo_caja.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, totalS);
            decimal Diferencia = Convert.ToDecimal(txt_valor_caja.Text) - Convert.ToDecimal(txt_saldo_caja.Text);
            decimal dif = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Diferencia);

            txt_diferencia.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, dif);
            Tabla.Visible = true;
            imp.Visible = true;
            cbx_lista_cierres.Items.Clear();
            fechainicio.Text = "";

        }

        protected void fechainicio_TextChanged(object sender, EventArgs e)
        {
            //cARGAR SECUENCAIL
            Int64 secuEfe = ConsultaEfectivoC.UltimoEfectivoSecuencial(fechainicio.Text);
            if (secuEfe == 0)
            {
                Buscar.Visible = false;
                cbx_lista_cierres.Visible = false;
                this.Page.Response.Write("<script language='JavaScript'>window.alert('No existe Cierre Caja del día indicado')+ error;</script>");
            }
            else
            {
                Buscar.Visible = true;
                cbx_lista_cierres.Visible = true;
                //Cargar datos segun cbx
                //Cargamos el combo de lista de cierres de caja del dia
                listaEfectivoC = ConsultaEfectivoC.ListaSecuencialFecha(fechainicio.Text);
                cbx_lista_cierres.DataSource = listaEfectivoC;
                cbx_lista_cierres.DataTextField = "cbx_secuencias";
                cbx_lista_cierres.DataValueField = "secuencial";
                cbx_lista_cierres.DataBind();

                DateTime fecha = DateTime.Parse(fechainicio.Text);
                lbl_dia.Text = fecha.ToString("dddd", new CultureInfo("es-ES")).ToUpper();
                lbl_fecha.Text = fechainicio.Text;
            }

            
        }
    }
}