using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaDatos.Modelos;


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


        Consultawmspcmonedas ConsultaCMonedas = new Consultawmspcmonedas();
        List<modeloDenominacionesMoneda> listaMonedas = null;
        ConsultaEfectivoCaja ConsultaECaja = new ConsultaEfectivoCaja();
        modeloTotalPgsFacturas modeloTPFacturas = new modeloTotalPgsFacturas();
        List<modeloTotalPgsFacturas> listaTPFacturas = null;

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
                lbl_fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
               // txt_diaA.Text = DateTime.Today.DayOfWeek;
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
            txt_ingreso_facturas.Text = modeloTPFacturas.total.ToString();
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
            listaMonedas = ConsultaCMonedas.ConsultaDenominacionesEmpresa("COP");
            Grid.DataSource = listaMonedas;
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
            TextBox1.Text = acumulador.ToString();
        }

        
        protected void CalcularTotal()
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
        }


        protected void Btn_Calcular_Click(object sender, EventArgs e)
        {
            CalcularTotal();
        }
    }
}