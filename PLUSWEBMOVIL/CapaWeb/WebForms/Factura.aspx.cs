using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;

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
        DetalleFactura GuardarDetalles = new DetalleFactura();
        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

        modelowmspctitulares cliente = new modelowmspctitulares();
        modelowmspcresfact resolucion = new modelowmspcresfact();
        modelowmspcarticulos articulo = new modelowmspcarticulos();
        modelocabecerafactura cabecerafactura = new modelocabecerafactura();
        modelonumerador nrotrans = new modelonumerador();
        ModeloDetalleFactura detallefactura = new ModeloDetalleFactura();
        modelowmtfacturascab conscabcera = new modelowmtfacturascab();


        List<modelowmspcresfact> listaRes = null;
        List<modelowmspcccostos> listaCostos = null;
        List<modelowmspctitulares> lista = null;
        List<modelowmspcmonedas> listaMonedas = null;
        List<modelovendedores> listaVendedores = null;
        List<modelowmspcfpago> listaPagos = null;
        List<modelowmspcarticulos> listaArticulos = null;
        List<modelonumerador> listaNumerador = null;
        List<modelowmtfacturascab> listaConsCab = null;
        List<ModeloDetalleFactura> modeloDetalleFactura = new List<ModeloDetalleFactura>();

        public string valor_asignado = null;
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
        public string Ccf_cod_emp = "04";
        public string Ccf_usuario = "desarrollo";
        public string Ccf_tipo1 = "C";
        public string Ccf_tipo2 = "VTA";
        public string Ccf_nro_trans = "0";
        public string Ccf_estado = "";
        public string Ccf_cliente = "";
        public string Ccf_cod_docum = "";
        public string Ccf_serie_docum = "";
        public string Ccf_nro_docum = "";
        public string Ccf_diai = "";
        public string Ccf_mesi = "";
        public string Ccf_anioi = "";
        public string Ccf_diaf = "";
        public string Ccf_mesf = "";
        public string Ccf_aniof = "";
        public string numerador = "trans";
        public decimal sumaTotal = 0;
        public decimal sumaIva = 0;
        public decimal sumaDescuento = 0;
        public decimal sumaSubtotal = 0;
        public string auditoria = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cliente"] != null)
            {
                // recupera la variable de secion con el objeto persona
                cliente = (modelowmspctitulares)Session["cliente"];
                nombreCliente.Text = cliente.nom_tit;
                dniCliente.Text = cliente.nro_dgi1;
                fonoCliente.Text = cliente.tel_tit;

            }

            if (Session["articulo"] != null)
            {
                // recupera la variable de secion con el objetoarticulo
                articulo = (modelowmspcarticulos)Session["articulo"];
                articulos.Text = articulo.nom_articulo;
                precio.Text = articulo.precio_total;
                BuscarArticulo.Text = articulo.cod_articulo;
                iva.Text =(articulo.porc_impuesto);
                porcdescto.Text = "0";


            }
            if (!IsPostBack)
            {
                Session.Remove("listaProducto");
                Session.Remove("articulo");
                Session.Remove("sumaSubtotal");
                Session.Remove("sumaTotal");
                Session.Remove("sumaIva");
                Session.Remove("sumaDescuento");
                Session.Remove("cliente");
                Session.Remove("detalle");
                    
                DateTime hoy = DateTime.Today;
                fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");

                if (Request.Cookies["ComPwm"] != null)
                {
                    string ComPwm = Request.Cookies["ComPwm"].Value;

                }

                cargarListaDesplegables();
                
               
            }
        }

        public void cargarListaDesplegables()
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
            cod_costos.DataTextField = "descripcion";
            cod_costos.DataValueField = "cod_dpto";
            cod_costos.DataBind();
            

            //lissta moneedaa
            listaMonedas = ConsultaCMonedas.ConsultaCMonedas(MonB__usuario, MonB__cod_emp, MonB__moneda);
            cod_moneda.DataSource = listaMonedas;
            cod_moneda.DataTextField = "descripcion";
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
            cod_fpago.DataTextField = "descripcion";
            cod_fpago.DataValueField = "cod_fpago";
            cod_fpago.DataBind();
        }


        
        public void InsertarDetalle()
        {
            ModeloDetalleFactura item = new ModeloDetalleFactura();
            articulo = null;
            articulo =  BuscarProducto(BuscarArticulo.Text);


            if (Session["detalle"] == null)
            {               
               modeloDetalleFactura = new List<ModeloDetalleFactura>();             
            }
            else
            {
                modeloDetalleFactura = (Session["detalle"] as List<ModeloDetalleFactura>);
            }

            Boolean existe = false;
            foreach (ModeloDetalleFactura itemSuma in modeloDetalleFactura)
            {
                if (itemSuma.cod_articulo == articulo.cod_articulo)
                {
                    existe = true;
                    /*Suma detalle*/

                    itemSuma.cantidad += Convert.ToDecimal(cantidad.Text);
                    itemSuma.precio_unit = Math.Round(Convert.ToDecimal(precio.Text), 2);
                    itemSuma.porc_iva = Math.Round(Convert.ToDecimal(iva.Text), 0);
                    itemSuma.porc_descto = Math.Round(Convert.ToDecimal(porcdescto.Text), 0);
                    itemSuma.subtotal = Math.Round((itemSuma.precio_unit  * itemSuma.cantidad), 2);
                    itemSuma.poriva = itemSuma.porc_iva / 100;

                    if (Session["sumaSubtotal"] != null)
                    {
                        sumaSubtotal = Convert.ToDecimal(Session["sumaSubtotal"]);
                    }

                    sumaSubtotal += itemSuma.subtotal;
                    Session["sumaSubtotal"] = sumaSubtotal.ToString();
                    txtSumaSubTo.Text = sumaSubtotal.ToString();

                    if (itemSuma.porc_descto == 0)
                    {
                        itemSuma.descuento = 0;
                        itemSuma.detadescuento = 0;
                        itemSuma.detaiva =Math.Round(( itemSuma.subtotal * itemSuma.poriva), 0);
                        itemSuma.subdos = itemSuma.subtotal;
                        itemSuma.total = itemSuma.subdos + itemSuma.detaiva; //Suma total
                    }
                    else
                    {
                        itemSuma.descuento = itemSuma.porc_descto / 100;
                        itemSuma.detadescuento = Math.Round((itemSuma.subtotal - itemSuma.descuento), 2);
                        itemSuma.detaiva = Math.Round((itemSuma.detadescuento * itemSuma.poriva), 0);
                        itemSuma.subdos = Math.Round((itemSuma.subtotal - itemSuma.descuento),2);
                        itemSuma.total = itemSuma.subdos + itemSuma.detaiva; //Suma total
                    }

                    if (Session["sumaIva"] != null)
                    {
                        sumaIva = Convert.ToDecimal(Session["sumaIva"]);
                    }
                    sumaIva += itemSuma.detaiva;
                    Session["sumaIva"] = sumaIva.ToString();
                    txtSumaIva.Text = sumaIva.ToString();

                    if (Session["sumaDescuento"] != null)
                    {
                        sumaDescuento = Convert.ToDecimal(Session["sumaDescuento"]);
                    }

                    sumaDescuento += itemSuma.detadescuento;
                    Session["sumaDescuento"] = sumaDescuento.ToString();
                    txtSumaDesc.Text = sumaDescuento.ToString();



                    if (Session["sumaTotal"] != null)
                    {
                        sumaTotal = Convert.ToDecimal(Session["sumaTotal"]);
                    }
                    sumaTotal += itemSuma.total;
                    Session["sumaTotal"] = sumaTotal.ToString();
                    txtSumaTotal.Text = sumaTotal.ToString();                   

                    /*Suma detalle*/
                    break;
                }
            }

            if (!existe)
            {
                item.cod_articulo = BuscarArticulo.Text;
                item.nom_articulo = articulos.Text;
                item.nom_articulo2 = articulos.Text;
                item.cod_ccostos = cod_costos.SelectedValue;
                item.cantidad = Convert.ToDecimal(cantidad.Text);
                item.precio_unit = Math.Round(Convert.ToDecimal(precio.Text), 2);
                item.porc_iva = Math.Round(Convert.ToDecimal(iva.Text), 0);
                item.porc_descto = Math.Round(Convert.ToDecimal(porcdescto.Text), 0);
                item.subtotal = Math.Round(Convert.ToDecimal(precio.Text) * Convert.ToDecimal(cantidad.Text), 2);
                item.poriva = item.porc_iva / 100;

                if (Session["sumaSubtotal"] != null)
                {
                    sumaSubtotal = Convert.ToDecimal(Session["sumaSubtotal"]);
                }

                sumaSubtotal += item.subtotal;
                Session["sumaSubtotal"] = sumaSubtotal.ToString();
                txtSumaSubTo.Text = sumaSubtotal.ToString();

                if (item.porc_descto == 0)
                {
                    item.descuento = 0;
                    item.detadescuento = 0;
                    item.detaiva = Math.Round(item.subtotal * item.poriva , 0);
                    item.subdos = item.subtotal;
                    item.total = Math.Round(item.subdos + item.detaiva , 2); //Suma total
                }
                else
                {
                    item.descuento = item.porc_descto / 100;
                    item.detadescuento = Math.Round( item.subtotal - item.descuento , 0);
                    item.detaiva = Math.Round(item.detadescuento * item.poriva , 2);
                    item.subdos = Math.Round(item.subtotal - item.descuento, 2);
                    item.total = Math.Round(item.subdos + item.detaiva , 2); //Suma total
                }

                if (Session["sumaIva"] != null)
                {
                    sumaIva = Convert.ToDecimal(Session["sumaIva"]);
                }
                sumaIva += item.detaiva;
                Session["sumaIva"] = sumaIva.ToString();
                txtSumaIva.Text = sumaIva.ToString();

                if (Session["sumaDescuento"] != null)
                {
                    sumaDescuento = Convert.ToDecimal(Session["sumaDescuento"]);
                }

                sumaDescuento += item.detadescuento;
                Session["sumaDescuento"] = sumaDescuento.ToString();
                txtSumaDesc.Text = sumaDescuento.ToString();



                if (Session["sumaTotal"] != null)
                {
                    sumaTotal = Convert.ToDecimal(Session["sumaTotal"]);
                }
                sumaTotal += item.total;
                Session["sumaTotal"] = sumaTotal.ToString();
                txtSumaTotal.Text = sumaTotal.ToString();
                item.cod_cta_cos = articulo.cod_cta_cos;
                item.cod_cta_inve = articulo.cod_cta_inve;
                item.cod_cta_vtas = articulo.cod_cta_vtas;
                item.base_imp = articulo.volumen_art;
                item.tasa_iva = articulo.cod_tasa_impu;
                item.cod_concepret = articulo.cod_concepret;

                modeloDetalleFactura.Add(item);
            }            
            
            Session["detalle"] = modeloDetalleFactura;

            modeloDetalleFactura = (Session["detalle"] as List<ModeloDetalleFactura>);
            gvProducto.DataSource = modeloDetalleFactura;
            gvProducto.DataBind();

            BuscarArticulo.Text = "";
            articulos.Text = "";
            precio.Text = "0";
            iva.Text = "0";
            porcdescto.Text = "0";
            cantidad.Text = "1";
            item = null;
            
        }

        public void BuscarCabecera()
        {
           
            //consulta nro_auditoria de la cabecera
            string Ccf_nro_trans = valor_asignado;
            listaConsCab = ConsultaCabe.ConsultaCabFacura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof); 
            int count = 0;
            conscabcera = null;
            foreach (modelowmtfacturascab item in listaConsCab)
            {
                count++;
                conscabcera = item;

            }

            if (count > 1)
            {

                mensaje.Text = "inconsistencia";
                    

            }
            else
            {

                if (conscabcera == null)
                {
                    BuscarArticulo.Text = "No existe el producto";
                }
                else
                {

                    auditoria = conscabcera.nro_audit;

                }
            }

            
        }
        public void InsertarCabecera()
        {
            if (Session["valor_asignado"] != null)
            {
                 GuardarCabezera.EliminarCabDetFactura(Session["valor_asignado"].ToString());
                valor_asignado = Session["valor_asignado"].ToString();
            }
            else
            {
                //obtener numero de transaccion
                nrotrans = ConsultaNroTran.ConsultaNumeradores(numerador);
                valor_asignado = nrotrans.valor_asignado;
                //Guardar N° transaccion 
                Session["valor_asignado"] = valor_asignado;
            }

            DateTime Fecha = Convert.ToDateTime(fecha.Text);
            //obtener cliente
            string error = "";
            string Ven__cod_tit = dniCliente.Text;

            lista = ConsultaTitulares.ConsultaTitulares(Ven__usuario, Ven__cod_emp, Ven__cod_tipotit, Ven__cod_tit);


            cliente = null;
            foreach (modelowmspctitulares item in lista)
            {

                cliente = item;
                break;
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

            error = GuardarCabezera.InsertarCabezeraFactura(cabecerafactura);
            if (string.IsNullOrEmpty(error))
            {

            }
            else
            {
                //mensaje.Text = error;
              
                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                Session["cabecera"] = cabecerafactura;

            }

        }

        public void GuardarDetalle()
        {
            modeloDetalleFactura = new List<ModeloDetalleFactura>();

            modeloDetalleFactura = (Session["detalle"] as List<ModeloDetalleFactura>);
           
           
                InsertarCabecera();
                BuscarCabecera();
                int contarLinea = 0;
                foreach (var item in modeloDetalleFactura)
                {
                    contarLinea++;
                    detallefactura.nom_articulo = item.nom_articulo;
                    detallefactura.nom_articulo2 = item.nom_articulo2;
                    detallefactura.cantidad = item.cantidad;
                    detallefactura.precio_unit = item.precio_unit;
                    detallefactura.base_imp = item.base_imp;
                    detallefactura.porc_iva = item.porc_iva;
                    detallefactura.nro_trans = valor_asignado;
                    detallefactura.linea = contarLinea;
                    detallefactura.cod_emp = Vend__cod_emp;
                    detallefactura.cod_articulo = item.cod_articulo;
                    detallefactura.cod_concepret = item.cod_concepret;
                    detallefactura.porc_descto = item.porc_descto;
                    detallefactura.valor_descto = item.detadescuento;
                    detallefactura.cod_cta_vtas =item.cod_cta_vtas;
                    detallefactura.cod_cta_cos = item.cod_cta_cos;
                    detallefactura.cod_cta_inve = item.cod_cta_inve;
                    detallefactura.usuario_mod = Vend__usuario ;
                    detallefactura.nro_audit = auditoria;
                    detallefactura.fecha_mod = DateTime.Today;
                    detallefactura.tasa_iva = item.tasa_iva;
                    detallefactura.cod_ccostos = item.cod_ccostos;

                    GuardarDetalles.InsertarDetalleFactura(detallefactura);


                }
            

        }

   

      


       
        protected void dniCliente_TextChanged(object sender, EventArgs e)
        {
            string Ven__cod_tit = dniCliente.Text;

            lista = ConsultaTitulares.ConsultaTitulares(Ven__usuario, Ven__cod_emp, Ven__cod_tipotit, Ven__cod_tit);

            int contar = 0;
            cliente = null;
            foreach (modelowmspctitulares item in lista)
            {
                contar++;
                cliente = item;               
            }

            if (contar > 1)
            {
                Session["listaCliente"] = lista;
                this.Page.Response.Write("<script language='JavaScript'>window.open('./BuscarCliente.aspx', 'Buscar Cliente', 'top=100,width=800 ,height=600, left=400');</script>");

            }
            else
            {
                if (cliente == null)
                {
                    this.Page.Response.Write("<script language='JavaScript'>window.open('./CrearCliente.aspx','Crear Cliente', 'top=100,width=580 ,height=400, left=400');</script>");
                    
                }
                else 
                {

                    Session.Remove("cliente");
                   
                    nombreCliente.Text = cliente.nom_tit;
                    fonoCliente.Text = cliente.tel_tit;
                    dniCliente.Text = cliente.nro_dgi1;
                }
            }

            

        }


        public void Validar()
        {

            DateTime hoy = DateTime.Today;
           
        }
      

        protected void BuscarArticulo_TextChanged(object sender, EventArgs e)
        {
            
            string ArtB__articulo = BuscarArticulo.Text;

            listaArticulos = ConsultaArticulo.ConsultaArticulos(ArtB__usuario, ArtB__cod_emp, ArtB__articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);

            int count = 0;
            articulo = null;
            foreach (modelowmspcarticulos item in listaArticulos)
            {
                count++;
                articulo = item;
                
            }


            if (count > 1)
            {
                Session["listaProducto"] = listaArticulos;
                this.Page.Response.Write("<script language='JavaScript'>window.open('./BuscarArticulo.aspx', 'Buscar Articulo', 'top=100,width=800 ,height=600, left=400');</script>");

            }
            else
            {

                if (articulo == null)
                {
                    BuscarArticulo.Text = "No existe el cliente";
                }
                else
                {
                    lblCantidad.Visible = true;
                    cantidad.Visible = true;
                    Session.Remove("articulo");
                    BuscarArticulo.Text = articulo.cod_articulo;
                    articulos.Text = articulo.nom_articulo;
                    precio.Text = articulo.precio;
                    iva.Text = articulo.porc_impuesto;
                    porcdescto.Text = "0";


                }
            }
        }

        protected void AgregarProducto_Click(object sender, EventArgs e)
        {
           
          InsertarDetalle();
                    
        }


        protected void gvProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
           /*Eliminar item de la grilla*/
            GridViewRow row = gvProducto.SelectedRow;

            modeloDetalleFactura = (Session["detalle"] as List<ModeloDetalleFactura>);
            //Eliminar Total
            if (Session["sumaTotal"] != null)
            {
                sumaTotal = Convert.ToDecimal(Session["sumaTotal"]);
            }
            sumaTotal -= Convert.ToDecimal(row.Cells[7].Text);
            Session["sumaTotal"] = sumaTotal.ToString();
            txtSumaTotal.Text = sumaTotal.ToString();

            //Eliminar Subtotal
            if (Session["sumaSubtotal"] != null)
            {
                sumaSubtotal = Convert.ToDecimal(Session["sumaSubtotal"]);
            }

            sumaSubtotal -= Convert.ToDecimal(row.Cells[4].Text);
            Session["sumaSubtotal"] = sumaSubtotal.ToString();
            txtSumaSubTo.Text = sumaSubtotal.ToString();
            //Eliminar Descuento
            if (Session["sumaDescuento"] != null)
            {
                sumaDescuento = Convert.ToDecimal(Session["sumaDescuento"]);
            }
            sumaDescuento -= Convert.ToDecimal(row.Cells[5].Text);
            Session["sumaDescuento"] = sumaDescuento.ToString();
            txtSumaDesc.Text = sumaDescuento.ToString();
            //Eliminar Iva
            if (Session["sumaIva"] != null)
            {
                sumaIva = Convert.ToDecimal(Session["sumaIva"]);
            }
            sumaIva -= Convert.ToDecimal(row.Cells[6].Text);
            Session["sumaIva"] = sumaIva.ToString();
            txtSumaIva.Text = sumaIva.ToString();
            


            modeloDetalleFactura.RemoveAt(row.RowIndex);
            Session["detalle"] = modeloDetalleFactura;
            modeloDetalleFactura = (Session["detalle"] as List<ModeloDetalleFactura>);
            gvProducto.DataSource = modeloDetalleFactura;
            gvProducto.DataBind();

        }

        protected void GuardarDetalle_Click(object sender, EventArgs e)
        {
            //Salvar cabecera
            GuardarDetalle();
        }

        public modelowmspcarticulos BuscarProducto(string ArtB__articulo)
        {
            

            listaArticulos = ConsultaArticulo.ConsultaArticulos(ArtB__usuario, ArtB__cod_emp, ArtB__articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);

            
            articulo = null;
            foreach (modelowmspcarticulos item in listaArticulos)
            {
               
                articulo = item;
                break;

            }

            return articulo;
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarFacturas.aspx");
        }
    }
}

