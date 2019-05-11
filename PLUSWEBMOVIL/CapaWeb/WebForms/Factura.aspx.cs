using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaProceso.Consultas;
using CapaProceso.Modelos;

namespace CapaWeb.WebForms
{
    public partial class Factura : System.Web.UI.Page
    {
        Consultawmspcresfact ConsultaResolucion = new Consultawmspcresfact();
        Consultawmsptitulares ConsultaTitulares = new Consultawmsptitulares();
        Consultawmspccostos ConsultaCCostos = new Consultawmspccostos();
        Consultawmspcmonedas ConsultaCMonedas = new Consultawmspcmonedas();
        Consultavendedores ConsultaVendedores = new Consultavendedores();
        Consultawmspcformaspag ConsultaFPagos = new Consultawmspcformaspag();
        Cosnsultawmspcarticulos ConsultaArticulo = new Cosnsultawmspcarticulos();
        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        CabezeraFactura GuardarCabezera = new CabezeraFactura();

        modelowmspctitulares cliente = new modelowmspctitulares();
        modelowmspcresfact resolucion = new modelowmspcresfact();
        modelowmspcarticulos articulo = new modelowmspcarticulos();
        modelocabecerafactura cabecerafactura = new modelocabecerafactura();
        modelonumerador nrotrans = new modelonumerador();
        

        List<modelowmspcresfact> listaRes = null;
        List<modelowmspcccostos> listaCostos = null;
        List<modelowmspctitulares> lista = null;
        List<modelowmspctitulares> listaB = null;
        List<modelowmspcmonedas> listaMonedas = null;
        List<modelovendedores> listaVendedores = null;
        List<modelowmspcfpago> listaPagos = null;
        List<modelowmspctitulares> listaTodos = null;
        List<modelowmspcarticulos> listaArticulos = null;
        List<modelonumerador> listaNumerador = null;

        public string Ven__usuario = "desarrollo";
        public string Ven__cod_emp = "04";
        public string Ven__cod_tipotit = "cliente";
        public string ResF_usuario = "desarrollo";
        public string ResF_cod_emp = "04";
        public string ResF_estado = "S";
        public string ResF_serie = "0";
        public string ResF_tipo = "F";
        public string CC__usuario = "desarrollo";
        public string CC__cod_emp = "04";
        public string CC__cod_dpto = "0";
        public string MonB__usuario = "desarrollo";
        public string MonB__cod_emp = "04";
        public string MonB__moneda = "0";
        public string Vend__usuario = "desarrollo";
        public string Vend__cod_emp = "04";
        public string Vend__cod_tipotit = "vendedores";
        public string Vend__cod_tit = "0";
        public string FP__usuario = "desarrollo";
        public string FP__cod_emp = "04";
        public string FP__cod_fpago = "0";
        public string ArtB__usuario = "desarrollo";
        public string ArtB__cod_emp = "04";
        public string ArtB__articulo = "tubo";
        public string ArtB__tipo = "0";
        public string ArtB__compras = "0";
        public string ArtB__ventas = "S";
        public string numerador = "trans";



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cliente"] != null)
            {
                // recupera la variable de secion con el objeto persona
                cliente = (modelowmspctitulares)Session["cliente"];
                nombreCliente.Text = cliente.nom_tit;
                dniCliente.Text = cliente.nro_dgi1;

            }

            if (Session["articulo"] != null)
            {
                // recupera la variable de secion con el objetoarticulo
                articulo = (modelowmspcarticulos)Session["articulo"];
                articulos.Text = articulo.nom_articulo;
                precio.Text = articulo.precio_total;


            }
            if (!IsPostBack)
            {
                CargarGrilla();
                Session.Remove("cliente");
                DateTime hoy = DateTime.Today;
                fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");

                if (Request.Cookies["ComPwm"] != null)
                {
                    string ComPwm = Request.Cookies["ComPwm"].Value;

                }

               
            }
        }

        public void CargarGrilla()
        {

            //LIsta Resolucion facturas
            listaRes = ConsultaResolucion.ConsultaResolusiones(ResF_usuario, ResF_cod_emp, ResF_estado, ResF_serie, ResF_tipo);
            serie_docum.DataSource = listaRes;
            serie_docum.DataTextField = "serie_docum";
            serie_docum.DataValueField = "serie_docum";
            serie_docum.DataBind();

            //lista ccostos
            listaCostos = ConsultaCCostos.ConsultaCCostos(CC__usuario, CC__cod_emp, CC__cod_dpto);
            cod_costos.DataSource = listaCostos;
            cod_costos.DataTextField = "nom_dpto";
            cod_costos.DataValueField = "cod_dpto";
            cod_costos.DataBind();

            //lissta moneedaa
            listaMonedas = ConsultaCMonedas.ConsultaCMonedas(MonB__usuario, MonB__cod_emp, MonB__moneda);
            cod_moneda.DataSource = listaMonedas;
            cod_moneda.DataTextField = "simbolo_moneda";
            cod_moneda.DataValueField = "cod_moneda";
            cod_moneda.DataBind();
            //lissta vendedores
            listaVendedores = ConsultaVendedores.ConsultaVendedores(Vend__usuario, Vend__cod_emp, Vend__cod_tipotit, Vend__cod_tit);
            cod_vendedor.DataSource = listaVendedores;
            cod_vendedor.DataTextField = "nom_tit";
            cod_vendedor.DataValueField = "cod_tit";
            cod_vendedor.DataBind();

            //lissta fpago
            listaPagos = ConsultaFPagos.ConsultaFpagos(FP__usuario, FP__cod_emp, FP__cod_fpago);
            cod_fpago.DataSource = listaPagos;
            cod_fpago.DataTextField = "nom_fpago";
            cod_fpago.DataValueField = "cod_fpago";
            cod_fpago.DataBind();



        }

        private void inhabilitarCajasC()
        {
            Button3.Enabled = false;
            cod_fpago.Enabled = false;
            cod_vendedor.Enabled = false;
            cod_moneda.Enabled = false;
            cod_costos.Enabled = false;
            serie_docum.Enabled = false;
            fecha.Enabled = false;
            dniCliente.Enabled = false;
            nombreCliente.Enabled = false;
            ocompra.Enabled = false;
            porc_descto.Enabled = false;
            area.Enabled = false;
            GuardarCabecera.Visible = false;
            //detalle habilitar
            Button4.Visible = true;
            BuscarArticulo.Visible = true;
            Producto.Visible = true;
            pvp.Visible = true;
            articulos.Visible = true;
            precio.Visible = true;
            
        }

      


       
        protected void dniCliente_TextChanged(object sender, EventArgs e)
        {
            string Ven__cod_tit = dniCliente.Text;

            lista = ConsultaTitulares.ConsultaTitulares(Ven__usuario, Ven__cod_emp, Ven__cod_tipotit, Ven__cod_tit);


            cliente = null;
            foreach (modelowmspctitulares item in lista)
            {
                cliente = item;
                break;
            }

            if (cliente == null)
            {
                nombreCliente.Text = "No existe el cliente";
            }
            else
            {


                Session["cliente"] = cliente;
                nombreCliente.Text = cliente.nom_tit;
            }

        }


        public void Validar()
        {

            DateTime hoy = DateTime.Today;
           
        }
        protected void GuardarCabecera_Click(object sender, EventArgs e)
        {
            //obtener numero de transaccion
            nrotrans = ConsultaNroTran.ConsultaNumeradores(numerador);
            string valor_asignado = nrotrans.valor_asignado;
            DateTime Fecha = Convert.ToDateTime(fecha.Text);

                string error = "";
            if (Session["cliente"] != null)
            {
                // recupera la variable de secion con el objeto persona
                cliente = (modelowmspctitulares)Session["cliente"];
               

            }


             cabecerafactura.cod_cliente = cliente.cod_tit;
            cabecerafactura.dia = string.Format("{0:00}", Fecha.Day);
            cabecerafactura.mes = string.Format("{0:00}", Fecha.Month);
            cabecerafactura.anio = Fecha.Year.ToString();
            cabecerafactura.fec_doc = fecha.Text;
            cabecerafactura.serie_docum = serie_docum.SelectedValue;
            cabecerafactura.cod_ccostos = cod_costos.SelectedValue;
            cabecerafactura.cod_vendedor = cod_vendedor.SelectedValue;
            cabecerafactura.cod_fpago = cod_fpago.SelectedValue;
            cabecerafactura.observaciones = area.Text;
            cabecerafactura.nro_trans = valor_asignado;
            cabecerafactura.cod_emp = ResF_cod_emp;
            cabecerafactura.cod_docum = "0";
            cabecerafactura.nro_docum = "0";
            cabecerafactura.subtotal = Convert.ToDecimal("0.00");
            cabecerafactura.iva = Convert.ToDecimal("0.00");
            cabecerafactura.monto_imponible = Convert.ToDecimal("0.00");
            cabecerafactura.total = Convert.ToDecimal("0.00");
            cabecerafactura.estado = "P";
            cabecerafactura.usuario_mod = "04";
            cabecerafactura.nro_audit = "0"; // por defecto va cero s disapra triger
            cabecerafactura.ocompra = ocompra.Text;
            cabecerafactura.cod_moneda = cod_moneda.SelectedValue;
            cabecerafactura.tipo = "VTA";
            cabecerafactura.porc_descto = Convert.ToDecimal("0.00");
            cabecerafactura.descuento = Convert.ToDecimal("0.00");
            cabecerafactura.diar = "10";
            cabecerafactura.mesr = "05";
            cabecerafactura.anior = "2019";
            cabecerafactura.cod_proc_aud = "RCOMFACT";

          error =  GuardarCabezera.InsertarCabezeraFactura(cabecerafactura);
            if (string.IsNullOrEmpty(error))
            {
               
            }
            else
            {
                 //mensaje.Text = error;
                inhabilitarCajasC();
                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                Session["cabecera"] = cabecerafactura;

            }



        }

        protected void BuscarArticulo_TextChanged(object sender, EventArgs e)
        {
            string ArtB__articulo = BuscarArticulo.Text;

            listaArticulos = ConsultaArticulo.ConsultaArticulos(ArtB__usuario, ArtB__cod_emp, ArtB__articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);


            articulo = null;
            foreach (modelowmspcarticulos item in listaArticulos)
            {
                articulo = item;
                break;
            }

            if (articulo == null)
            {
                BuscarArticulo.Text = "No existe el cliente";
            }
            else
            {


                Session["articulo"] = articulo;
                articulos.Text = articulo.nom_articulo;
                precio.Text = articulo.precio; 

                
            }
        }
    }
}
