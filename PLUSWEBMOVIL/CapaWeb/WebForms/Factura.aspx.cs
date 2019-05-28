using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;

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
        Consultaconfirmarfactura ConfirmarFactura = new Consultaconfirmarfactura();
        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();
        Consultawmtfacturasdet ConsultaDeta = new Consultawmtfacturasdet();

        modelowmspctitulares cliente = new modelowmspctitulares();
        modelowmspcresfact resolucion = new modelowmspcresfact();
        modelowmspcarticulos articulo = new modelowmspcarticulos();
        modelocabecerafactura cabecerafactura = new modelocabecerafactura();
        modelonumerador nrotrans = new modelonumerador();
        modeloinsertarconfirmar confirmarinsertar = new modeloinsertarconfirmar();
        ModeloDetalleFactura detallefactura = new ModeloDetalleFactura();
        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        ModeloDetalleFactura consdetalle = new ModeloDetalleFactura();


        List<modelowmspcresfact> listaRes = null;
        List<modelowmspcccostos> listaCostos = null;
        List<modelowmspctitulares> lista = null;
        List<modelowmspcmonedas> listaMonedas = null;
        List<modelovendedores> listaVendedores = null;
        List<modelowmspcfpago> listaPagos = null;
        List<modelowmspcarticulos> listaArticulos = null;
        List<modelowmtfacturascab> listaConsCab = null;
        List<ModeloDetalleFactura> listaConsDetalle = null;
        List<ModeloDetalleFactura> ModeloDetalleFactura = new List<ModeloDetalleFactura>();
        List<modeloinsertarconfirmar> modeloinsertarconfirmar = new List<modeloinsertarconfirmar>();

        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        public string ComPwm;
        public string AmUsrLog;
        public string valor_asignado = null;
        public string Ven__cod_tipotit = "cliente";
        public string ResF_estado = "S";
        public string ResF_serie = "0";
        public string ResF_tipo = "F";
        public string CC__cod_dpto = "0";
        public string MonB__moneda = "0";
        public string Vend__cod_tipotit = "vendedores";
        public string Vend__cod_tit = "0";
        public string FP__cod_fpago = "0";
        public string ArtB__articulo = "tubo";
        public string ArtB__tipo = "0";
        public string ArtB__compras = "0";
        public string ArtB__ventas = "S";
        public string Ccf_tipo1 = "C";
        public string Ccf_tipo2 = "VTA";
        public string Ccf_nro_trans = "0";
        public string Ccf_estado = null;
        public string Ccf_cliente = null;
        public string Ccf_cod_docum = null;
        public string Ccf_serie_docum = null;
        public string Ccf_nro_docum = null;
        public string Ccf_diai = null;
        public string Ccf_mesi = null;
        public string Ccf_anioi = null;
        public string Ccf_diaf = null;
        public string Ccf_mesf = null;
        public string Ccf_aniof = null;
        public string numerador = "trans";
        public decimal sumaTotal = 0;
        public decimal sumaIva = 0;
        public decimal sumaDescuento = 0;
        public decimal sumaSubtotal = 0;
        public string auditoria = null;
        public string nro_trans = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            RecuperarCokie();
            ListaModelowmspclogo = consultaLogo.BuscartaLogo(ComPwm, AmUsrLog);
            foreach (var item in ListaModelowmspclogo)
            {
                Modelowmspclogo = item;
                break;
            }


            if (Session["cliente"] != null)
            {
                // recupera la variable de secion con el objeto persona
                cliente = (modelowmspctitulares)Session["cliente"];
                nombreCliente.Text = cliente.nom_tit;
                dniCliente.Text = cliente.nro_dgi1;
                fonoCliente.Text = cliente.tel_tit;
                txtcorreo.Text = cliente.email_tit;

            }

            if (Session["articulo"] != null)
            {
                // recupera la variable de secion con el objetoarticulo
                articulo = (modelowmspcarticulos)Session["articulo"];
                articulos.Text = articulo.nom_articulo;
                precio.Text = articulo.precio_total;
                BuscarArticulo.Text = articulo.cod_articulo;
                iva.Text = (articulo.porc_impuesto);
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




                QueryString qs = ulrDesencriptada();


                //Recibir opciones
                switch (qs["TRN"].Substring(0, 3))
                {

                    case "INS":
                        cargarListaDesplegables();
                        Session.Remove("listaCliente");
                        Session.Remove("valor_asignado");
                        DateTime hoy = DateTime.Today;
                        fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                        break;

                    case "UDP":
                        Int64 id = Int64.Parse(qs["Id"].ToString());
                        Session["valor_asignado"] = id.ToString();

                        cargarListaDesplegables();
                        LlenarFactura();

                        break;

                    case "VER":
                        Int64 ide = Int64.Parse(qs["Id"].ToString());
                        Session["valor_asignado"] = ide.ToString();

                        cargarListaDesplegables();
                        LlenarFactura();
                        BloquearFactura();
                        break;
                }




            }
        }

        protected void BloquearFactura()
        {
            //inhabilitar cajas de texto cabecera factura
            dniCliente.Enabled = false;
            nombreCliente.Enabled = false;
            fonoCliente.Enabled = false;
            txtcorreo.Enabled = false;
            fecha.Enabled = false;
            cod_fpago.Enabled = false;
            nro_pedido.Enabled = false;
            cod_costos.Enabled = false;
            serie_docum.Enabled = false;
            ocompra.Enabled = false;
            area.Enabled = false;
            porc_descto.Enabled = false;
            cmbCod_moneda.Enabled = false;
            cod_vendedor.Enabled = false;
            txtSumaSubTo.Enabled = false;
            txtSumaTotal.Enabled = false;
            txtSumaIva.Enabled = false;
            txtSumaDesc.Enabled = false;
            gv_Producto.Enabled = false;
            //botones
            AgregarProducto.Enabled = false;
            Confirmar.Visible = false;
            btnGuardarDetalle.Visible = false;
            //detalle producto
            BuscarArticulo.Enabled = false;
            articulos.Enabled = false;
            cantidad.Enabled = false;
            precio.Enabled = false;
            porcdescto.Enabled = false;
            iva.Enabled = false;
        }
        protected void LlenarFactura()
        {
            //llenar formulario para la actualizacion de datos


            string Ccf_nro_trans = Session["valor_asignado"].ToString();

            listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
            int count = 0;
            conscabcera = null;
            foreach (modelowmtfacturascab item in listaConsCab)
            {
                count++;
                conscabcera = item;

            }


            if (count > 1)
            {

                mensaje.Text = "No existe factura";


            }
            else
            {

                auditoria = conscabcera.nro_audit;
                dniCliente.Text = conscabcera.nro_dgi2;
                nombreCliente.Text = conscabcera.nom_tit;
                fonoCliente.Text = conscabcera.tel_tit;
                //txtcorreo.Text = conscabcera.e
                DateTime dtfec_doc = Convert.ToDateTime(conscabcera.fec_doc);
                fecha.Text = dtfec_doc.ToString("yyyy-MM-dd");
                cod_fpago.SelectedValue = conscabcera.cod_fpago;
                // nro_pedido.Text = conscabcera.pe
                area.Text = conscabcera.observaciones;
                ocompra.Text = conscabcera.ocompra;
                porc_descto.Text = Convert.ToString(conscabcera.porc_descto);
                cod_costos.SelectedValue = conscabcera.cod_ccostos;
                cmbCod_moneda.SelectedValue = conscabcera.cod_moneda;
                cod_vendedor.SelectedValue = conscabcera.cod_vendedor;
                txtSumaSubTo.Text = Convert.ToString(conscabcera.subtotal);
                txtSumaTotal.Text = Convert.ToString(conscabcera.total);
                txtSumaIva.Text = Convert.ToString(conscabcera.iva);
                txtSumaDesc.Text = Convert.ToString(conscabcera.descuento);

                Session["sumaSubtotal"] = Convert.ToString(conscabcera.subtotal);
                Session["sumaDescuento"] = Convert.ToString(conscabcera.descuento);
                Session["sumaIva"] = Convert.ToString(conscabcera.iva);
                Session["sumaTotal"] = Convert.ToString(conscabcera.total);
            }

            //Carga detalle factura
            string nro_trans = Ccf_nro_trans;

            listaConsDetalle = ConsultaDeta.ConsultaDetalleFacura(nro_trans);
            Session["detalle"] = listaConsDetalle;

            gv_Producto.DataSource = listaConsDetalle;
            gv_Producto.DataBind();
            gv_Producto.Height = 100;


        }


        public QueryString ulrDesencriptada()
        {
            //1- guardo el Querystring encriptado que viene desde el request en mi objeto
            QueryString qs = new QueryString(Request.QueryString);

            ////2- Descencripto y de esta manera obtengo un array Clave/Valor normal
            qs = Encryption.DecryptQueryString(qs);
            return qs;
        }
        public void cargarListaDesplegables()
        {

            //LIsta Resolucion facturas
            listaRes = ConsultaResolucion.ConsultaResolusiones(AmUsrLog, ComPwm, ResF_estado, ResF_serie, ResF_tipo);
            serie_docum.DataSource = listaRes;
            serie_docum.DataTextField = "serie_docum";
            serie_docum.DataValueField = "serie_docum";
            serie_docum.DataBind();

            //lista ccostos
            listaCostos = ConsultaCCostos.ConsultaCCostos(AmUsrLog, ComPwm, CC__cod_dpto);
            cod_costos.DataSource = listaCostos;
            cod_costos.DataTextField = "descripcion";
            cod_costos.DataValueField = "cod_dpto";
            cod_costos.DataBind();


            //lissta moneedaa
            listaMonedas = ConsultaCMonedas.ConsultaCMonedas(AmUsrLog, ComPwm, MonB__moneda);
            cmbCod_moneda.DataSource = listaMonedas;
            cmbCod_moneda.DataTextField = "descripcion";
            cmbCod_moneda.DataValueField = "cod_moneda";
            cmbCod_moneda.DataBind();

            //lissta vendedores
            listaVendedores = ConsultaVendedores.ConsultaVendedores(AmUsrLog, ComPwm, Vend__cod_tipotit, Vend__cod_tit);
            cod_vendedor.DataSource = listaVendedores;
            cod_vendedor.DataTextField = "nom_tit";
            cod_vendedor.DataValueField = "cod_tit";
            cod_vendedor.DataBind();

            //lissta fpago
            listaPagos = ConsultaFPagos.ConsultaFpagos(AmUsrLog, ComPwm, FP__cod_fpago);
            cod_fpago.DataSource = listaPagos;
            cod_fpago.DataTextField = "descripcion";
            cod_fpago.DataValueField = "cod_fpago";
            cod_fpago.DataBind();
        }



        public void InsertarDetalle()
        {
            ModeloDetalleFactura item = new ModeloDetalleFactura();
            articulo = null;
            articulo = BuscarProducto(BuscarArticulo.Text);


            if (Session["detalle"] == null)
            {
                ModeloDetalleFactura = new List<ModeloDetalleFactura>();
            }
            else
            {
                ModeloDetalleFactura = (Session["detalle"] as List<ModeloDetalleFactura>);
            }

            Boolean existe = false;
            foreach (ModeloDetalleFactura itemSuma in ModeloDetalleFactura)
            {
                if (itemSuma.cod_articulo == articulo.cod_articulo)
                {
                    existe = true;
                    /*Suma detalle*/
                    /*Recupero varibales de secion*/
                    if (Session["sumaSubtotal"] != null)
                    {
                        sumaSubtotal = Convert.ToDecimal(Session["sumaSubtotal"]);
                    }

                    if (Session["sumaDescuento"] != null)
                    {
                        sumaDescuento = Convert.ToDecimal(Session["sumaDescuento"]);
                    }

                    if (Session["sumaIva"] != null)
                    {
                        sumaIva = Convert.ToDecimal(Session["sumaIva"]);
                    }

                    if (Session["sumaTotal"] != null)
                    {
                        sumaTotal = Convert.ToDecimal(Session["sumaTotal"]);
                    }
                    /* Resto los totales antes de agregar un nuevo por que puede haber variado el precio*/
                    sumaSubtotal -= itemSuma.subtotal;
                    sumaDescuento -= itemSuma.detadescuento;
                    sumaIva -= itemSuma.detaiva;
                    sumaTotal -= itemSuma.total;

                    /* sumo los numebos valores agregados al producto*/
                    itemSuma.cantidad += Convert.ToDecimal(cantidad.Text);
                    itemSuma.precio_unit = Math.Round(Convert.ToDecimal(precio.Text), 2);


                    itemSuma.porc_iva = Math.Round(Convert.ToDecimal(iva.Text), 0);
                    itemSuma.porc_descto = Math.Round(Convert.ToDecimal(porcdescto.Text), 0);
                    itemSuma.subtotal = Math.Round((itemSuma.precio_unit * itemSuma.cantidad), 2);
                    itemSuma.poriva = itemSuma.porc_iva / 100;



                    sumaSubtotal += itemSuma.subtotal;
                    Session["sumaSubtotal"] = sumaSubtotal.ToString();
                    txtSumaSubTo.Text = sumaSubtotal.ToString();

                    if (itemSuma.porc_descto == 0)
                    {
                        itemSuma.descuento = 0;
                        itemSuma.detadescuento = 0;
                        itemSuma.detaiva = Math.Round((itemSuma.subtotal * itemSuma.poriva), 0);
                        itemSuma.subdos = itemSuma.subtotal;
                        itemSuma.total = itemSuma.subdos + itemSuma.detaiva; //Suma total
                    }
                    else
                    {
                        itemSuma.descuento = itemSuma.porc_descto / 100;
                        itemSuma.detadescuento = Math.Round((itemSuma.subtotal - itemSuma.descuento), 2);
                        itemSuma.detaiva = Math.Round((itemSuma.detadescuento * itemSuma.poriva), 0);
                        itemSuma.subdos = Math.Round((itemSuma.subtotal - itemSuma.descuento), 2);
                        itemSuma.total = itemSuma.subdos + itemSuma.detaiva; //Suma total
                    }

                    sumaDescuento += itemSuma.detadescuento;
                    Session["sumaDescuento"] = sumaDescuento.ToString();
                    txtSumaDesc.Text = sumaDescuento.ToString();

                    sumaIva += itemSuma.detaiva;
                    Session["sumaIva"] = sumaIva.ToString();
                    txtSumaIva.Text = sumaIva.ToString();

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
                    item.detaiva = Math.Round(item.subtotal * item.poriva, 0);
                    item.subdos = item.subtotal;
                    item.total = Math.Round(item.subdos + item.detaiva, 2); //Suma total
                }
                else
                {
                    item.descuento = item.porc_descto / 100;
                    item.detadescuento = Math.Round(item.subtotal - item.descuento, 0);
                    item.detaiva = Math.Round(item.detadescuento * item.poriva, 2);
                    item.subdos = Math.Round(item.subtotal - item.descuento, 2);
                    item.total = Math.Round(item.subdos + item.detaiva, 2); //Suma total
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

                ModeloDetalleFactura.Add(item);
            }

            Session["detalle"] = ModeloDetalleFactura;

            ModeloDetalleFactura = (Session["detalle"] as List<ModeloDetalleFactura>);
            gv_Producto.DataSource = ModeloDetalleFactura;
            gv_Producto.DataBind();

            BuscarArticulo.Text = "";
            articulos.Text = "";
            precio.Text = "0";
            iva.Text = "0";
            porcdescto.Text = "0";
            cantidad.Text = "1";
            item = null;

        }

        public modelowmtfacturascab BuscarCabecera()
        {
            //Busca el nro de auditoria para poder insertar el detalle factura
            //consulta nro_auditoria de la cabecera
            string Ccf_nro_trans = valor_asignado;
            listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
            int count = 0;
            conscabcera = null;
            foreach (modelowmtfacturascab item in listaConsCab)
            {
                count++;
                conscabcera = item;
            }

            if (count > 1)
            {
                mensaje.Text = "Factura no encontrada";
            }
            return conscabcera;
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

            lista = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit);


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
            cabecerafactura.cod_emp = ComPwm;
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
            cabecerafactura.cod_moneda = cmbCod_moneda.SelectedValue;
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

        public modelowmtfacturascab GuardarDetalle()
        {
            string error;
            //Busca en gv_producto todos los items añadidos que estan en la variable de session detalle
            ModeloDetalleFactura = new List<ModeloDetalleFactura>();

            ModeloDetalleFactura = (Session["detalle"] as List<ModeloDetalleFactura>);

            //Insertar primero la cabecera
            InsertarCabecera();
            //Busca el nro de auditoria
            conscabcera = null;
            conscabcera = BuscarCabecera();

            //Va añadiendo linea por linea al modelo insertar detalle factura
            int contarLinea = 0;
            foreach (var item in ModeloDetalleFactura)
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
                detallefactura.cod_emp = ComPwm;
                detallefactura.cod_articulo = item.cod_articulo;
                detallefactura.cod_concepret = item.cod_concepret;
                detallefactura.porc_descto = item.porc_descto;
                detallefactura.valor_descto = item.detadescuento;
                detallefactura.cod_cta_vtas = item.cod_cta_vtas;
                detallefactura.cod_cta_cos = item.cod_cta_cos;
                detallefactura.cod_cta_inve = item.cod_cta_inve;
                detallefactura.usuario_mod = AmUsrLog;
                detallefactura.nro_audit = conscabcera.nro_audit;
                detallefactura.fecha_mod = DateTime.Today;
                detallefactura.tasa_iva = item.tasa_iva;
                detallefactura.cod_ccostos = item.cod_ccostos;

                error = GuardarDetalles.InsertarDetalleFactura(detallefactura);
                if (string.IsNullOrEmpty(error))
                {

                }
                else
                {
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");

                }

            }
            return conscabcera;
        }


        protected void dniCliente_TextChanged(object sender, EventArgs e)
        {
            string Ven__cod_tit = dniCliente.Text;

            lista = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit);

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
                    txtcorreo.Text = cliente.email_tit;
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

            listaArticulos = ConsultaArticulo.ConsultaArticulos(AmUsrLog, ComPwm, ArtB__articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);

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
            //Agrega el producto a la grilla gv_Producto  
            InsertarDetalle();

        }



        protected void GuardarDetalle_Click(object sender, EventArgs e)
        {
            //Boton Salvar
            GuardarDetalle();

        }

        public modelowmspcarticulos BuscarProducto(string ArtB__articulo)
        {


            listaArticulos = ConsultaArticulo.ConsultaArticulos(AmUsrLog, ComPwm, ArtB__articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);


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

        protected void Confirmar_Click(object sender, EventArgs e)
        {

            //Boton Coonfirmar hace lo mismo que el salvar solo aumenta la insercion a la tabla wmt_facturas_ins
            conscabcera = null;
            conscabcera = GuardarDetalle();

            confirmarinsertar.nro_trans = conscabcera.nro_trans;
            confirmarinsertar.cod_emp = conscabcera.cod_emp;
            confirmarinsertar.usuario_mod = AmUsrLog;
            confirmarinsertar.fecha_mod = DateTime.Now;
            confirmarinsertar.nro_audit = conscabcera.nro_audit;

            ConfirmarFactura.ConfirmarFactura(confirmarinsertar);



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
        }




        protected void gv_Producto_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            ModeloDetalleFactura detalle = new ModeloDetalleFactura();
            ModeloDetalleFactura = (Session["detalle"] as List<ModeloDetalleFactura>);// tomo la variable de secion 
            foreach (var item in ModeloDetalleFactura)
            {
                if (item.cod_articulo == Convert.ToString(((Label)e.Item.Cells[2].FindControl("cod_articulo")).Text))// comparo si la lista el cosigo de producto es igual al selecionado
                {
                    detalle = item; // saco el item seleccionado
                    break;
                }
            }

            switch (e.CommandName) //ultilizo la variable para la opcion            
            {
                case "Editar":// lleno las cajas de texto con los datos para la edicon del item seleccionado
                    BuscarArticulo.Text = detalle.cod_articulo;
                    articulos.Text = detalle.nom_articulo;
                    cantidad.Text = Convert.ToString(detalle.cantidad);
                    porcdescto.Text = Convert.ToString(detalle.porc_descto);
                    precio.Text = Convert.ToString(detalle.precio_unit);
                    iva.Text = detalle.porc_iva.ToString();

                    break;

                case "Eliminar":
                    /*Eliminar item de la grilla*/

                    //Eliminar Total
                    if (Session["sumaTotal"] != null)
                    {
                        sumaTotal = Convert.ToDecimal(Session["sumaTotal"]);
                    }

                    sumaTotal -= Convert.ToDecimal(detalle.total);
                    Session["sumaTotal"] = sumaTotal.ToString();
                    txtSumaTotal.Text = sumaTotal.ToString();

                    //Eliminar Subtotal
                    if (Session["sumaSubtotal"] != null)
                    {
                        sumaSubtotal = Convert.ToDecimal(Session["sumaSubtotal"]);
                    }

                    sumaSubtotal -= Convert.ToDecimal(detalle.subtotal);
                    Session["sumaSubtotal"] = sumaSubtotal.ToString();
                    txtSumaSubTo.Text = sumaSubtotal.ToString();
                    //Eliminar Descuento
                    if (Session["sumaDescuento"] != null)
                    {
                        sumaDescuento = Convert.ToDecimal(Session["sumaDescuento"]);
                    }
                    sumaDescuento -= Convert.ToDecimal(detalle.detadescuento);
                    Session["sumaDescuento"] = sumaDescuento.ToString();
                    txtSumaDesc.Text = sumaDescuento.ToString();
                    //Eliminar Iva
                    if (Session["sumaIva"] != null)
                    {
                        sumaIva = Convert.ToDecimal(Session["sumaIva"]);
                    }
                    sumaIva -= Convert.ToDecimal(detalle.detaiva);
                    Session["sumaIva"] = sumaIva.ToString();
                    txtSumaIva.Text = sumaIva.ToString();



                    ModeloDetalleFactura.RemoveAt(e.Item.ItemIndex);
                    Session["detalle"] = ModeloDetalleFactura;
                    ModeloDetalleFactura = (Session["detalle"] as List<ModeloDetalleFactura>);
                    gv_Producto.DataSource = ModeloDetalleFactura;
                    gv_Producto.DataBind();
                    break;
            }


        }
    }
}

