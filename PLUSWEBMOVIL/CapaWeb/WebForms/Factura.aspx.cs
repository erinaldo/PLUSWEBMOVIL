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
        modelowmspctitulares cliente = new modelowmspctitulares();
        modelowmspcresfact resolucion = new modelowmspcresfact();

        List<modelowmspcresfact> listaRes = null;
        List<modelowmspcccostos> listaCostos = null;
        List<modelowmspctitulares> lista = null;
        List<modelowmspctitulares> listaB = null;
        List<modelowmspcmonedas> listaMonedas = null;
        List<modelovendedores> listaVendedores = null;
        List<modelowmspcfpago> listaPagos = null;
        List<modelowmspctitulares> listaTodos = null;
        List<modelowmspcarticulos> listaArticulos = null;

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



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cliente"] != null)
            {
                // recupera la variable de secion con el objeto persona
                cliente = (modelowmspctitulares)Session["cliente"];
                nombreCliente.Text = cliente.nom_tit;
                dniCliente.Text = cliente.nro_dgi1;

            }

            if (!IsPostBack)
            {
                CargarGrilla();
                Session.Remove("cliente");       
               
               

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
       

        public void CargarProducto()
        {
            
            listaArticulos = ConsultaArticulo.ConsultaArticulos(ArtB__usuario, ArtB__cod_emp, ArtB__articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);

            

            Grid3.DataSource = listaArticulos;
            Grid3.DataBind();
            Grid3.Height = 100;

        }

        public void Buscar()
        {
            //listar todos los articulos
            listaArticulos = ConsultaArticulo.ConsultaArticulos(ArtB__usuario, ArtB__cod_emp, ArtB__articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);

            Grid3.DataSource = listaArticulos;
            Grid3.DataBind();
            Grid3.Height = 100;

        }
       

        protected void Grid3_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            // paginar la grilla asegurarse que la obcion que la propiedad AllowPaging sea True.
            Grid3.CurrentPageIndex = 0;
            Grid3.CurrentPageIndex = e.NewPageIndex;
            Buscar();
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

        

        protected void BuscarP_Click(object sender, EventArgs e)
        {

            string ArtB_articulo = BuscarP.Text;
            listaArticulos = ConsultaArticulo.ConsultaArticulos(ArtB__usuario, ArtB__cod_emp, ArtB__articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);

            Grid3.DataSource = listaArticulos;
            Grid3.DataBind();
            Grid3.Height = 100;
        }
        protected void BuscarP_TextChanged(object sender, EventArgs e)
        {
            string ArtB_articulo = BuscarP.Text;
            listaArticulos = ConsultaArticulo.ConsultaArticulos(ArtB__usuario, ArtB__cod_emp, ArtB__articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);

            Grid3.DataSource = listaArticulos;
            Grid3.DataBind();
            Grid3.Height = 100;
        }

        protected void Grid3_ItemCommand(object source, DataGridCommandEventArgs e)
        {
           
            int Id;

            switch (e.CommandName) //ultilizo la variable para la opcion
            {

                case "Seleccionar": //ejecuta el codigo si el usuario ingresa el numero 1
                    Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("cod_articulo")).Text);

                  

                    Response.Redirect("Factura.aspx" +Id.ToString());
                    break;//termina la ejecucion del programa despues de ejecutar el codigo

               
            }
        }

        

        protected void GuardarCabecera_Click(object sender, EventArgs e)
        {
           
        }
    }
}
