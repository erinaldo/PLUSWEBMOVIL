using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;
using CapaDatos.Modelos.ModelosNC;

namespace CapaWeb.WebForms
{
    public partial class FormNotaCreditoFinanciera : System.Web.UI.Page
    {
        public ConsultaCodProceso ConsultaCodProceso = new ConsultaCodProceso();
        public modeloCodProcesoFactura ModeloCodProceso = new modeloCodProcesoFactura();
        public List<modeloCodProcesoFactura> ListaModeloCodProceso = null;

        public ConsultaRolModPrecio ConsultaRolMod = new ConsultaRolModPrecio();
        public modeloRolModificarPrecio ModeloRolMod = new modeloRolModificarPrecio();
        public List<modeloRolModificarPrecio> ListaRolMod = null;

        public List<modelowmspcfacturasWMimpuRest> ListaModeloimpuesto = new List<modelowmspcfacturasWMimpuRest>();
        public modelowmspcfacturasWMimpuRest ModeloImpuesto = new modelowmspcfacturasWMimpuRest();
        public ConsultawmspcfacturasWMimpuRest consultaImpuesto = new ConsultawmspcfacturasWMimpuRest();


        Consultawmspccostos ConsultaCCostos = new Consultawmspccostos();
        List<modelowmspcccostos> listaCostos = null;

        Consultawmspcmonedas ConsultaCMonedas = new Consultawmspcmonedas();
        List<modelowmspcmonedas> listaMonedas = null;
        modelowmspcmonedas DecimalesMoneda = new modelowmspcmonedas();

        Consultavendedores ConsultaVendedores = new Consultavendedores();
        List<modelovendedores> listaVendedores = null;

        Consultawmspcformaspag ConsultaFPagos = new Consultawmspcformaspag();
        List<modelowmspcfpago> listaPagos = null;

        Cosnsultawmspcarticulos ConsultaArticulo = new Cosnsultawmspcarticulos();
        List<modelowmspcarticulos> listaArticulos = null;
        modelowmspcarticulos articulo = new modelowmspcarticulos();


        Consultawmsptitulares ConsultaTitulares = new Consultawmsptitulares();
        modelowmspctitulares cliente = new modelowmspctitulares();
        List<modelowmspctitulares> lista = null;

        Consultawmspcresfact ConsultaResolucion = new Consultawmspcresfact();
        modelowmspcresfact resolucion = new modelowmspcresfact();
        List<modelowmspcresfact> listaRes = null;


        ConsultawmusuarioSucursal consultaUsuarioSucursal = new ConsultawmusuarioSucursal();
        modeloUsuariosucursal ModeloUsuSucursal = new modeloUsuariosucursal();
        List<modeloUsuariosucursal> ListaUsuSucursal = null;

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();

        CabezeraFactura GuardarCabezera = new CabezeraFactura();
        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();
        List<modelowmtfacturascab> listaConsCab = null;
        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        modelocabecerafactura cabecerafactura = new modelocabecerafactura();

        Consultawmtfacturasdet ConsultaDeta = new Consultawmtfacturasdet();
        ModeloDetalleFactura consdetalle = new ModeloDetalleFactura();
        ModeloDetalleFactura consCantNC = new ModeloDetalleFactura();
        List<ModeloDetalleFactura> listaConsDetalle = null;
        List<ModeloDetalleFactura> listaCantNCTotales = null;
        List<ModeloDetalleFactura> ModeloDetalleFactura = new List<ModeloDetalleFactura>();
        ModeloDetalleFactura detallefactura = new ModeloDetalleFactura();
        DetalleFactura GuardarDetalles = new DetalleFactura();

        modeloinsertarconfirmar confirmarinsertar = new modeloinsertarconfirmar();
        Consultaconfirmarfactura ConfirmarFactura = new Consultaconfirmarfactura();
        List<modeloinsertarconfirmar> modeloinsertarconfirmar = new List<modeloinsertarconfirmar>();

        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        public List<modelowmspctctrxCotizacion> ListaModelocotizacion = new List<modelowmspctctrxCotizacion>();
        public modelowmspctctrxCotizacion ModeloCotizacion = new modelowmspctctrxCotizacion();
        public ConsultawmspctctrxCotizacion consultaMoneda = new ConsultawmspctctrxCotizacion();

        public List<modeloSaldosFacturas> ListaSaldoFacturas = null;
        public modeloSaldosFacturas ModeloSaldoFactura = new modeloSaldosFacturas();
        public ConsultaSaldosFacturas consultaSaldoFactura = new ConsultaSaldosFacturas();

        public List<modeloUsuariosucursal> ListaModeloUsuarioSucursal = new List<modeloUsuariosucursal>();
        public ConsultawmusuarioSucursal ConsultaUsuxSuc = new ConsultawmusuarioSucursal();
        public modeloUsuariosucursal ModelousuarioSucursal = new modeloUsuariosucursal();

        public modeloActualizarDatosTitular ModeloActualizarEmail = new modeloActualizarDatosTitular();
        public ConsultaActualizarTitular ConsultaDatosTitular = new ConsultaActualizarTitular();
        public string ComPwm;
        public string AmUsrLog;
        public string valor_asignado = null;
        public string Ven__cod_tipotit = "clientes";
        public string ResF_estado = "v";
        public string ResF_serie = "0";
        public string ResF_tipo = "C";
        public string CC__cod_dpto = "0";
        public string MonB__moneda = "0";
        public string Vend__cod_tipotit = "vendedores";
        public string Vend__cod_tit = "0";
        public string FP__cod_fpago = "0";
        public string ArtB__articulo = "tubo";
        public string ArtB__tipo = "NCRED";
        public string ArtB__compras = "0";
        public string ArtB__ventas = "S";
        public string Ccf_tipo1 = "C";
        public string Ccf_tipo2 = "NCME";
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
        public decimal sumaBase19 = 0;
        public decimal sumaBase15 = 0;
        public decimal sumaIva19 = 0;
        public decimal sumaIva15 = 0;
        public string auditoria = null;
        public string nro_trans = null;
        public string Ven__cod_dgi = "0";
        public string Ven__fono = "0";
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


            if (Session["cliente"] != null)
            {
                // recupera la variable de secion con el objeto persona
                cliente = (modelowmspctitulares)Session["cliente"];
                nombreCliente.Text = cliente.nom_tit;
                dniCliente.Text = cliente.nro_dgi2;
                fonoCliente.Text = cliente.tel_tit;
                txtcorreo.Text = cliente.email_tit;

            }
            if (Session["articulo"] != null)
            {
                // recupera la variable de secion con el objetoarticulo
  
                articulo = (modelowmspcarticulos)Session["articulo"];
                txt_Descripcion.Text = articulo.nom_articulo;
                txt_Precio.Text = articulo.precio_total;
                txt_Codigo.Text = articulo.cod_articulo;
                txt_Iva.Text = (articulo.porc_impuesto);
                txt_Desc.Text = "0";


            }
            //Variable de listaClienteFac busqueda de facturas
            if (Session["listaFacturas"] != null)
            {
                conscabcera = (modelowmtfacturascab)Session["listaFacturas"];

                cod_fpago.SelectedValue = conscabcera.cod_fpago.Trim();
                nro_pedido.Text = conscabcera.nro_pedido;
                //area.Text = conscabcera.observaciones;
                ocompra.Text = conscabcera.ocompra;
                porc_descto.Text = Convert.ToString(conscabcera.porc_descto);
                cod_costos.SelectedValue = conscabcera.cod_ccostos;
                cmbCod_moneda.SelectedValue = conscabcera.cod_moneda.Trim();
                cod_vendedor.SelectedValue = conscabcera.cod_vendedor;

                // serie_docum.SelectedValue = conscabcera.serie_docum.Trim();
                //Agregarbcampos de factura para NC
                //Consultamos cuantos descimales se van a usar redondeo
                DecimalesMoneda = null;
                DecimalesMoneda = BuscarDecimales();
                /*Campos para insertar detalle de la nc*/
                txt_nro_factura.Text = conscabcera.observacion;
                txt_cod_docum.Text = conscabcera.cod_docum;
                txt_serie_docum.Text = conscabcera.serie_docum;
                txt_nro_docum.Text = conscabcera.nro_docum;
                txt_nro_trans_padre.Text = conscabcera.nro_trans;
                //Formato totales

                txt_subtotal_factura.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, conscabcera.subtotal);
                txt_total_factura.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, conscabcera.total);
                txt_iva_factura.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, conscabcera.iva);
                txt_descuento_factura.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, conscabcera.descuento);


                BloquearDatosFactura();
                //Carga detalle factura
                string nro_trans = conscabcera.nro_trans;
                lbl_trx.Text = null;
                lbl_trx.Visible = false;

            }
            if (Session["saldoFacturas"] != null)
            {
                txt_saldo_factura.Text = Session["saldoFacturas"].ToString();
            }


            ConsultarTasaCambioCanorus();

            if (!IsPostBack)
            {
                Session.Remove("listaClienteFac");
                Session.Remove("listaFacturas");
                Session.Remove("saldoFacturas");
                Session.Remove("listaProducto");
                Session.Remove("articulo");
                Session.Remove("sumaSubtotal");
                Session.Remove("sumaTotal");
                Session.Remove("sumaIva");
                Session.Remove("sumaDescuento");
                Session.Remove("cliente");
                Session.Remove("detalle");
                Session.Remove("sumaBase19");
                Session.Remove("sumaBase15");
                Session.Remove("sumaIva19");
                Session.Remove("sumaIva15");


                QueryString qs = ulrDesencriptada();

                //Recibir opciones
                switch (qs["TRN"].Substring(0, 3))
                {
                    case "AFA":
                        cargarListaDesplegables();
                        Session.Remove("listaCliente");
                        Session.Remove("listaArticulos");

                        Session.Remove("valor_asignado");
                        Session["Tipo"] = "Anular";
                        DateTime hoy1 = DateTime.Today;
                        fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");

                        ConsultarTasaCambioCanorus();

                        break;

                    case "INS":

                        Session.Remove("listaCliente");
                        Session.Remove("valor_asignado");
                        Session.Remove("Tipo");
                        cargarListaDesplegables();
                        DateTime hoy = DateTime.Today;
                        fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                        //Consultar tasa de cambio
                        ConsultarTasaCambioCanorus();
                        /* ModeloRolMod = BuscarRolModificar( AmUsrLog, ComPwm, "VTA", "NA", "N");
                         if (ModeloRolMod.control_uso == "readonly=\"readonly\"")
                         {
                             precio.Enabled = false;
                         }*/
                        break;

                    case "UDP":
                        Session.Remove("Tipo");
                        Int64 id = Int64.Parse(qs["Id"].ToString());
                        Session["valor_asignado"] = id.ToString();
                        txt_nro_trans_padre.Text = id.ToString();
                        cargarListaDesplegables();
                        LlenarFactura();

                        break;

                    case "VER":
                        Int64 ide = Int64.Parse(qs["Id"].ToString());
                        Session["valor_asignado"] = ide.ToString();

                        cargarListaDesplegables();
                        LlenarFactura();
                        BloquearNCVer();
                        break;
                }

            }
        }

        //Buscar cantidad de decimales q se va ausar x tipo de moneda
        public modelowmspcmonedas BuscarDecimales()
        {

            listaMonedas = ConsultaCMonedas.ConsultaCMonedas(AmUsrLog, ComPwm, cmbCod_moneda.SelectedValue);

            DecimalesMoneda = null;
            foreach (modelowmspcmonedas item in listaMonedas)
            {

                DecimalesMoneda = item;
                break;

            }

            return DecimalesMoneda;
        }
        protected void BloquearDatosFactura()
        {
            //Visible Datos Factura
            lbl_nro_factura.Visible = true;
            txt_nro_factura.Visible = true;
            lbl_subtotal_factura.Visible = true;
            lbl_total_factura.Visible = true;
            lbl_descuento_factura.Visible = true;
            lbl_iva_factura.Visible = true;
            txt_subtotal_factura.Visible = true;
            txt_total_factura.Visible = true;
            txt_descuento_factura.Visible = true;
            txt_iva_factura.Visible = true;
            lbl_motivo_nc.Visible = true;
            cbx_motivo_nc.Visible = true;

        }
        protected void BloquearCabeceraNC()
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
            //area.Enabled = false;

            porc_descto.Enabled = false;
            cmbCod_moneda.Enabled = false;
            cod_vendedor.Enabled = false;
            txtSumaSubTo.Enabled = false;
            txtSumaTotal.Enabled = false;
            txtSumaIva.Enabled = false;
            txtSumaDesc.Enabled = false;

            txtBase15.Enabled = false;
            txtBaseIva19.Enabled = false;
            txtIva15.Enabled = false;
            txtIva19.Enabled = false;
            //botones

            btn_Fac.Enabled = false;


        }
        void BloquearFactura()
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
            //area.Enabled = false;

            porc_descto.Enabled = false;
            cmbCod_moneda.Enabled = false;
            cod_vendedor.Enabled = false;
            txtSumaSubTo.Enabled = false;
            txtSumaTotal.Enabled = false;
            txtSumaIva.Enabled = false;
            txtSumaDesc.Enabled = false;
            gv_Producto.Enabled = false;
            txtBase15.Enabled = false;
            txtBaseIva19.Enabled = false;
            txtIva15.Enabled = false;
            txtIva19.Enabled = false;
            //botones
            AgregarNC.Enabled = false;
            Confirmar.Visible = true;
            btnGuardarDetalle.Visible = false;
            btn_Fac.Enabled = false;
            //detalle producto
            txt_Codigo.Enabled = false;
            txt_Cantidad.Enabled = false;
            txt_Descripcion.Enabled = false;
            txt_Precio.Enabled = false;
            txt_Desc.Enabled = false;
            txt_Iva.Enabled = false;
        }
        protected void BloquearNCVer()
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
            txtBase15.Enabled = false;
            txtBaseIva19.Enabled = false;
            txtIva15.Enabled = false;
            txtIva19.Enabled = false;
            //botones
            AgregarNC.Enabled = false;
            Confirmar.Visible = false;
            btnImpuestos.Enabled = false;
            btnGuardarDetalle.Visible = false;
            btn_Fac.Enabled = false;
            //detalle producto
            txt_Codigo.Enabled = false;
            txt_Cantidad.Enabled = false;
            txt_Descripcion.Enabled = false;
            txt_Precio.Enabled = false;
            txt_Desc.Enabled = false;
            txt_Iva.Enabled = false;
        }
        protected void dniCliente_TextChanged(object sender, EventArgs e)
        {
            string Ven__cod_tit = dniCliente.Text;

            lista = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi);

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
                    nombreCliente.Text = "";
                    fonoCliente.Text = "";
                    dniCliente.Text = "";
                    txtcorreo.Text = "";
                    // this.Page.Response.Write("<script language='JavaScript'>window.open('./CrearCliente.aspx','Crear Cliente', 'top=100,width=580 ,height=400, left=400');</script>");

                }
                else
                {

                    Session.Remove("cliente");

                    nombreCliente.Text = cliente.nom_tit;
                    fonoCliente.Text = cliente.tel_tit;
                    dniCliente.Text = cliente.nro_dgi2;
                    txtcorreo.Text = cliente.email_tit;



                }
            }
        }
        public modelowmspctctrxCotizacion BuscarCotizacion(string Ccf_usuario, string Ccf_cod_emp, string dia, string mes, string anio, string moneda)
        {
            ListaModelocotizacion = consultaMoneda.TasaCambioActual(Ccf_usuario, Ccf_cod_emp, dia, mes, anio, moneda);

            foreach (var item in ListaModelocotizacion)
            {
                ModeloCotizacion = item;

                break;
            }

            return ModeloCotizacion;

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
        protected void ConsultarTasaCambioCanorus()
        {
            DateTime hoy = DateTime.Today;
            fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
            string dia = string.Format("{0:00}", hoy.Day);
            string mes = string.Format("{0:00}", hoy.Month);
            string anio = hoy.Year.ToString();
            ModeloCotizacion = BuscarCotizacion(AmUsrLog, ComPwm, dia, mes, anio, "USD");
            if (ModeloCotizacion.tc_mov == null)
            {
                lbl_trx.Text = " No existe Tipo de Cambio registrado para la fecha de la factura. Por favor registrar la tasa del dia y actualizar la pagina";
                lbl_trx.Visible = true;
                BloquearFactura();
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


        protected void gv_Producto_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (Session["detalle"] != null)
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
                //Consultamos cuantos descimales se van a usar redondeo
                DecimalesMoneda = null;
                DecimalesMoneda = BuscarDecimales();

                switch (e.CommandName) //ultilizo la variable para la opcion            
                {
                    case "Editar":// lleno las cajas de texto con los datos para la edicon del item seleccionado
                        txt_Codigo.Text = detalle.cod_articulo;
                        txt_Descripcion.Text = detalle.nom_articulo;
                        txt_Cantidad.Text = Convert.ToString(detalle.cantidad);
                        txt_Desc.Text = Convert.ToString(detalle.porc_descto);
                        txt_Precio.Text = Convert.ToString(detalle.precio_unit);
                        txt_Iva.Text = detalle.porc_iva.ToString();

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
                        txtSumaTotal.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaTotal);
                        //base iva 19 totales

                        if (Session["sumaBase19"] != null)
                        {
                            sumaBase19 = Convert.ToDecimal(Session["sumaBase19"]);
                        }
                        if (Math.Round(detalle.porc_iva, 0).ToString() == "19")
                        {
                            sumaBase19 -= detalle.subtotal;
                            Session["sumaBase19"] = sumaBase19.ToString();
                            txtBaseIva19.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaBase19);
                        }
                        //base iva 15 totales

                        if (Session["sumaBase15"] != null)
                        {
                            sumaBase15 = Convert.ToDecimal(Session["sumaBase15"]);
                        }
                        if (Math.Round(detalle.porc_iva, 0).ToString() == "5")
                        {
                            sumaBase15 -= detalle.subtotal;
                            Session["sumaBase15"] = sumaBase15.ToString();
                            txtBase15.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaBase15);
                        }
                        //iva 19% totales

                        if (Session["sumaIva19"] != null)
                        {
                            sumaIva19 = Convert.ToDecimal(Session["sumaIva19"]);
                        }
                        if (Math.Round(detalle.porc_iva, 0).ToString() == "19")
                        {
                            sumaIva19 -= detalle.detaiva;
                            Session["sumaIva19"] = sumaIva19.ToString();
                            txtIva19.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaIva19);
                        }
                        //iva 15% totales

                        if (Session["sumaIva15"] != null)
                        {
                            sumaIva15 = Convert.ToDecimal(Session["sumaIva15"]);
                        }
                        if (Math.Round(detalle.porc_iva, 0).ToString() == "5")
                        {
                            sumaIva15 -= detalle.detaiva;
                            Session["sumaIva15"] = sumaIva15.ToString();
                            txtIva15.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaIva15);
                        }
                        //Eliminar Subtotal
                        if (Session["sumaSubtotal"] != null)
                        {
                            sumaSubtotal = Convert.ToDecimal(Session["sumaSubtotal"]);
                        }

                        sumaSubtotal -= Convert.ToDecimal(detalle.subtotal);
                        Session["sumaSubtotal"] = sumaSubtotal.ToString();
                        txtSumaSubTo.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaSubtotal);

                        //Eliminar Descuento
                        if (Session["sumaDescuento"] != null)
                        {
                            sumaDescuento = Convert.ToDecimal(Session["sumaDescuento"]);
                        }
                        sumaDescuento -= Convert.ToDecimal(detalle.detadescuento);
                        Session["sumaDescuento"] = sumaDescuento.ToString();
                        txtSumaDesc.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaDescuento);
                        //Eliminar Iva
                        if (Session["sumaIva"] != null)
                        {
                            sumaIva = Convert.ToDecimal(Session["sumaIva"]);
                        }
                        sumaIva -= Convert.ToDecimal(detalle.detaiva);
                        Session["sumaIva"] = sumaIva.ToString();
                        txtSumaIva.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaIva);
                        //Eliminar base 19 y 15

                        ModeloDetalleFactura.RemoveAt(e.Item.ItemIndex);
                        Session["detalle"] = ModeloDetalleFactura;
                        ModeloDetalleFactura = (Session["detalle"] as List<ModeloDetalleFactura>);
                        gv_Producto.DataSource = ModeloDetalleFactura;
                        gv_Producto.DataBind();
                        break;
                }
            }



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
            listaVendedores = ConsultaVendedores.ConsultaVendedores(AmUsrLog, ComPwm, Vend__cod_tipotit, Vend__cod_tit, Ven__cod_dgi);
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


            auditoria = conscabcera.nro_audit;
            dniCliente.Text = conscabcera.nro_dgi2;
            nombreCliente.Text = conscabcera.nom_tit;
            fonoCliente.Text = conscabcera.tel_tit;
            txtcorreo.Text = conscabcera.email_tit;
            DateTime dtfec_doc = Convert.ToDateTime(conscabcera.fec_doc);
            fecha.Text = dtfec_doc.ToString("yyyy-MM-dd");
            cod_fpago.SelectedValue = conscabcera.cod_fpago;
            nro_pedido.Text = conscabcera.nro_pedido;
            area.Text = conscabcera.observaciones;
            ocompra.Text = conscabcera.ocompra;
            porc_descto.Text = Convert.ToString(conscabcera.porc_descto);
            cod_costos.SelectedValue = conscabcera.cod_ccostos;
            cmbCod_moneda.SelectedValue = conscabcera.cod_moneda;
            cod_vendedor.SelectedValue = conscabcera.cod_vendedor;
            //Formato totales
            //Consultamos cuantos descimales se van a usar redondeo
            DecimalesMoneda = null;
            DecimalesMoneda = BuscarDecimales();
            //Formato totales
            txtSumaSubTo.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, conscabcera.subtotal);
            txtSumaTotal.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, conscabcera.total);
            txtSumaIva.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, conscabcera.iva);
            txtSumaDesc.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, conscabcera.descuento);

            Session["sumaSubtotal"] = Convert.ToString(conscabcera.subtotal);
            Session["sumaDescuento"] = Convert.ToString(conscabcera.descuento);
            Session["sumaIva"] = Convert.ToString(conscabcera.iva);
            Session["sumaTotal"] = Convert.ToString(conscabcera.total);


            //Carga detalle factura
            string nro_trans = Ccf_nro_trans;

            listaConsDetalle = ConsultaDeta.ConsultaDetalleFacura(nro_trans);
            Session["detalle"] = listaConsDetalle;

            //Consulta de bases e ivas
            decimal baseiva19 = 0;
            decimal iva19 = 0;
            decimal baseiva15 = 0;
            decimal iva15 = 0;
            foreach (ModeloDetalleFactura item in listaConsDetalle)
            {
                if (item.porc_iva == 19)
                {
                    baseiva19 += item.base_iva;
                    iva19 += item.valor_iva;
                }
                if (item.porc_iva == 5)
                {
                    baseiva15 += item.base_iva;
                    iva15 += item.valor_iva;
                }
            }
            txtBaseIva19.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, baseiva19);
            txtBase15.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, baseiva15);
            txtIva19.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, iva19);
            txtIva15.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, iva15);

            //Llenar variables de seccion de bae e ivas

            Session["sumaBase19"] = baseiva19;
            Session["sumaBase15"] = baseiva15;
            Session["sumaIva19"] = iva19;
            Session["sumaIva15"] = iva15;
            gv_Producto.DataSource = listaConsDetalle;
            gv_Producto.DataBind();
            gv_Producto.Height = 100;

        }

        public modeloCodProcesoFactura BuscarCodProceso(string cod_proceso)
        {
            ListaModeloCodProceso = ConsultaCodProceso.DatosCodProceso(cod_proceso);

            int count = 0;
            ModeloCodProceso = null;
            foreach (modeloCodProcesoFactura item in ListaModeloCodProceso)
            {
                count++;
                ModeloCodProceso = item;

            }
            return ModeloCodProceso;
        }

        public modeloRolModificarPrecio BuscarRolModificar(string usuario, string cod_emp, string tipo, string campo, string accion)
        {
            ListaRolMod = ConsultaRolMod.BuscartaRolModificar(usuario, cod_emp, tipo, campo, accion);

            int count = 0;
            ModeloRolMod = null;
            foreach (modeloRolModificarPrecio item in ListaRolMod)
            {
                count++;
                ModeloRolMod = item;

            }

            return ModeloRolMod;
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
        //Consulta con cod_articulo el detalle de la factura y agrega conestado P
        public void AgregarDetalleNotaCredito()
        {
            cmbCod_moneda.Enabled = false;
            // Guardar en el detalle de la NC
            //Insertar producto en la grilla calcular totales
            DateTime hoy = DateTime.Today;
            fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
            //Consultar tasa de cambio
            string dia = string.Format("{0:00}", hoy.Day);
            string mes = string.Format("{0:00}", hoy.Month);
            string anio = hoy.Year.ToString();
            ModeloCotizacion = BuscarCotizacion(AmUsrLog, ComPwm, dia, mes, anio, cmbCod_moneda.SelectedValue);

            if (ModeloCotizacion.tc_mov == null)
            {
                lbl_trx.Text = " No existe Tipo de Cambio registrado para la fecha de la factura. Por favor registrar la tasa del dia y actualizar la pagina";
                lbl_trx.Visible = true;
                AgregarNC.Enabled = false;
            }
            else
            {
                /*Agregar detalle productos a la grilla*/
                ModeloDetalleFactura item = new ModeloDetalleFactura();
                articulo = null;
                articulo = BuscarProducto(txt_Codigo.Text);

                //Consultamos cuantos descimales se van a usar redondeo
                DecimalesMoneda = null;
                DecimalesMoneda = BuscarDecimales();

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
                        //Base iva nuevos campos
                        if (Session["sumaBase19"] != null)
                        {
                            sumaBase19 = Convert.ToDecimal(Session["sumaBase19"]);
                        }
                        if (Session["sumaBase15"] != null)
                        {
                            sumaBase15 = Convert.ToDecimal(Session["sumaBase15"]);
                        }
                        if (Session["sumaIva19"] != null)
                        {
                            sumaIva19 = Convert.ToDecimal(Session["sumaIva19"]);
                        }
                        if (Session["sumaIva15"] != null)
                        {
                            sumaIva15 = Convert.ToDecimal(Session["sumaIva15"]);
                        }
                        //Fin nuevos campos totales
                        /* Resto los totales antes de agregar un nuevo por que puede haber variado el precio*/
                        sumaSubtotal -= itemSuma.subtotal;
                        sumaDescuento -= itemSuma.detadescuento;
                        sumaIva -= itemSuma.detaiva;
                        sumaTotal -= itemSuma.total;

                        if (itemSuma.detaiva.ToString() == "0.19")
                        {
                            sumaBase19 -= itemSuma.subtotal;
                        }
                        if (itemSuma.detaiva.ToString() == "0.05")
                        {
                            sumaBase15 -= itemSuma.subtotal;
                        }
                        if (itemSuma.detaiva.ToString() == "0.19")
                        {
                            sumaIva19 -= itemSuma.detaiva;
                        }
                        if (itemSuma.detaiva.ToString() == "0.05")
                        {
                            sumaIva15 -= itemSuma.detaiva;
                        }
                        /* sumo los numebos valores agregados al producto*/
                        itemSuma.cantidad += Convert.ToDecimal(txt_Cantidad.Text);
                        itemSuma.precio_unit = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo_pu, Convert.ToDecimal(txt_Precio.Text));
                        itemSuma.porc_iva = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(txt_Iva.Text));
                        itemSuma.porc_descto = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(txt_Iva.Text));
                        itemSuma.subtotal = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (itemSuma.precio_unit * itemSuma.cantidad));
                        itemSuma.poriva = itemSuma.porc_iva / 100;



                        sumaSubtotal = itemSuma.subtotal;
                        Session["sumaSubtotal"] = sumaSubtotal.ToString();
                        txtSumaSubTo.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo_pu, sumaSubtotal);

                        if (itemSuma.porc_descto == 0)
                        {
                            itemSuma.descuento = 0;
                            itemSuma.detadescuento = 0;
                            itemSuma.detaiva = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (itemSuma.subtotal * itemSuma.poriva));
                            itemSuma.subdos = itemSuma.subtotal;
                            itemSuma.total = itemSuma.subdos + itemSuma.detaiva; //Suma total
                        }
                        else
                        {
                            itemSuma.descuento = itemSuma.porc_descto / 100;
                            itemSuma.detadescuento = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (itemSuma.subtotal - itemSuma.descuento));
                            itemSuma.detaiva = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (itemSuma.detadescuento * itemSuma.poriva));
                            itemSuma.subdos = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (itemSuma.subtotal - itemSuma.descuento));
                            itemSuma.total = itemSuma.subdos + itemSuma.detaiva; //Suma total
                        }

                        sumaDescuento += itemSuma.detadescuento;
                        Session["sumaDescuento"] = sumaDescuento.ToString();
                        txtSumaDesc.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaDescuento);

                        sumaIva += itemSuma.detaiva;
                        Session["sumaIva"] = sumaIva.ToString();
                        txtSumaIva.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaIva);

                        sumaTotal += itemSuma.total;
                        Session["sumaTotal"] = sumaTotal.ToString();
                        txtSumaTotal.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaTotal);

                        //Suma base ivas
                        if (itemSuma.poriva.ToString() == "0.19")
                        {
                            sumaBase19 += itemSuma.subtotal;
                            Session["sumaBase19"] = sumaBase19.ToString();
                            txtBaseIva19.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaBase19);
                        }

                        if (itemSuma.poriva.ToString() == "0.05")
                        {
                            sumaBase15 += itemSuma.subtotal;
                            Session["sumaBase15"] = sumaBase15.ToString();
                            txtBase15.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaBase15);
                        }
                        //Ivas
                        if (itemSuma.poriva.ToString() == "0.19")
                        {
                            sumaIva19 += itemSuma.detaiva;
                            Session["sumaIva19"] = sumaIva19.ToString();
                            txtIva19.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaIva19);
                        }
                        if (itemSuma.poriva.ToString() == "0.05")
                        {
                            sumaIva15 += itemSuma.detaiva;
                            Session["sumaIva15"] = sumaIva15.ToString();
                            txtIva15.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaIva15);
                        }
                        /*Suma detalle*/

                        break;
                    }
                }

                if (!existe)
                {
                    item.cod_articulo = txt_Codigo.Text;
                    item.nom_articulo = txt_Descripcion.Text;
                    item.nom_articulo2 = txt_Descripcion.Text;
                    item.cod_ccostos = cod_costos.SelectedValue;
                    item.cantidad = Convert.ToDecimal(txt_Cantidad.Text);
                    decimal precio_unitario = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo_pu, Convert.ToDecimal(txt_Precio.Text));
                    item.precio_unit = precio_unitario;
                    decimal precio_iva = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(txt_Iva.Text));
                    item.porc_iva = precio_iva;
                    decimal precio_des = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(txt_Desc.Text));
                    item.porc_descto = precio_des;
                    decimal precio_sub = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(item.precio_unit * item.cantidad));
                    item.subtotal = precio_sub;
                    item.poriva = item.porc_iva / 100;

                    if (Session["sumaSubtotal"] != null)
                    {
                        sumaSubtotal = Convert.ToDecimal(Session["sumaSubtotal"]);
                    }

                    sumaSubtotal += item.subtotal;
                    Session["sumaSubtotal"] = sumaSubtotal.ToString();

                    txtSumaSubTo.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaSubtotal);

                    if (item.porc_descto == 0)
                    {
                        item.descuento = 0;
                        item.detadescuento = 0;
                        item.detaiva = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (item.subtotal * item.poriva));
                        item.subdos = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, item.subtotal);
                        item.total = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (item.subdos + item.detaiva)); //Suma total
                    }
                    else
                    {
                        item.descuento = item.porc_descto / 100;
                        item.detadescuento = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (item.subtotal - item.descuento));
                        item.detaiva = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (item.detadescuento * item.poriva));
                        item.subdos = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (item.subtotal - item.descuento));
                        item.total = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (item.subdos + item.detaiva)); //Suma total
                    }

                    if (Session["sumaIva"] != null)
                    {
                        sumaIva = Convert.ToDecimal(Session["sumaIva"]);
                    }
                    sumaIva += item.detaiva;
                    Session["sumaIva"] = sumaIva.ToString();

                    txtSumaIva.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaIva);

                    if (Session["sumaDescuento"] != null)
                    {
                        sumaDescuento = Convert.ToDecimal(Session["sumaDescuento"]);
                    }

                    sumaDescuento += item.detadescuento;
                    Session["sumaDescuento"] = sumaDescuento.ToString();
                    txtSumaDesc.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaDescuento);

                    if (Session["sumaTotal"] != null)
                    {
                        sumaTotal = Convert.ToDecimal(Session["sumaTotal"]);
                    }
                    sumaTotal += item.total;
                    Session["sumaTotal"] = sumaTotal.ToString();
                    txtSumaTotal.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaTotal);
                    //base iva 19 totales

                    if (Session["sumaBase19"] != null)
                    {
                        sumaBase19 = Convert.ToDecimal(Session["sumaBase19"]);
                    }
                    if (item.poriva.ToString() == "0.19")
                    {
                        sumaBase19 += item.subtotal;
                        Session["sumaBase19"] = sumaBase19.ToString();
                        txtBaseIva19.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaBase19);
                    }
                    //base iva 15 totales
                    if (Session["sumaBase15"] != null)
                    {
                        sumaBase15 = Convert.ToDecimal(Session["sumaBase15"]);
                    }
                    if (item.poriva.ToString() == "0.05")
                    {
                        sumaBase15 += item.subtotal;
                        Session["sumaBase15"] = sumaBase15.ToString();
                        txtBase15.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaBase15);
                    }
                    //Iva 19 totales

                    if (Session["sumaIva19"] != null)
                    {
                        sumaIva19 = Convert.ToDecimal(Session["sumaIva19"]);
                    }
                    if (item.poriva.ToString() == "0.19")
                    {
                        sumaIva19 += item.detaiva;
                        Session["sumaIva19"] = sumaIva19.ToString();
                        txtIva19.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaIva19);
                    }

                    //Iva 15 totales

                    if (Session["sumaIva15"] != null)
                    {
                        sumaIva15 = Convert.ToDecimal(Session["sumaIva15"]);
                    }
                    if (item.poriva.ToString() == "0.05")
                    {
                        sumaIva15 += item.detaiva;
                        Session["sumaIva15"] = sumaIva15.ToString();
                        txtIva15.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaIva15);
                    }
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

                    txt_Codigo.Text = "";
                    txt_Descripcion.Text = "";
                    txt_Precio.Text = "0";
                    txt_Iva.Text = "0";
                    txt_Desc.Text = "0";
                    txt_Cantidad.Text = "1";
                    item = null;
                
            }
        }
        protected void AgregarNC_Click(object sender, EventArgs e)
        {
            /*
             ---Comparar cantidades antes de agregar
             Va a guardar con estado P solo si es menor que el saldo
             sino solo se va a mostrar en la grilla sin afectar pwm
             */
             AgregarDetalleNotaCredito(); //Calcula totales y agrega a grilla
            GuardarDetalle();
            BloquearCabeceraNC(); 

            
        }
        public void AgregarCabeceraDetalle()
        {

            //Consultar si el vendedor tiene asignada una sucursal
            ListaModeloUsuarioSucursal = ConsultaUsuxSuc.ConsultaUsuarioSucursal(ComPwm, AmUsrLog);
            int count = 0;
            foreach (var item in ListaModeloUsuarioSucursal)
            {
                ModelousuarioSucursal = item;
                count++;
                break;
            }

            if (count == 0)
            {
                this.Page.Response.Write("<script language='JavaScript'>window.alert('Usuario no tiene asignada sucursal, por favor asignar para continuar con el proceso ')+ error;</script>");
            }
            else
            {
                //Preguntar si existe detalle antes de confirmar
                if (txtSumaTotal.Text == "")
                {
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('No existen productos para facturar')+ error;</script>");
                }
                else
                {
                    if (txtSumaTotal.Text == "0.00")
                    {
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('No existen productos para facturar')+ error;</script>");
                    }
                    else
                    {
                        if (Session["detalle"] == null)
                        {
                            this.Page.Response.Write("<script language='JavaScript'>window.alert('No existen productos para facturar')+ error;</script>");

                        }
                        else
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
                            //Response.Redirect("BuscarFacturas.aspx");

                            /*  ConsumoRest consumoRest = new ConsumoRest();
                              string respuesta = "";
                              respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", "VTA", conscabcera.nro_trans);
                              if (respuesta == "")
                              {
                                  mensaje.Text = "Su factura fue procesada exitosamente";
                                  Confirmar.Enabled = false;
                                  GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "F");
                                  Response.Redirect("BuscarFacturas.aspx");

                              }
                              else
                              {
                                  GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "C");
                                  mensaje.Text = respuesta;
                                  Response.Redirect("BuscarFacturas.aspx");

                              }*/
                        }
                    }
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
            //Obtener n° sucursal
            ListaUsuSucursal = consultaUsuarioSucursal.ConsultaUsuarioSucursal(ComPwm, AmUsrLog);
            ModeloUsuSucursal = null;
            foreach (modeloUsuariosucursal items in ListaUsuSucursal)
            {
                ModeloUsuSucursal = items;
                break;
            }

            //obtener cliente
            string error = "";
            string Ven__cod_tit = dniCliente.Text;

            lista = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi);

            cliente = null;
            foreach (modelowmspctitulares item in lista)
            {
                cliente = item;
                break;
            }

            //Procedimiento para actualizar email del titular
            ModeloActualizarEmail.usuario = AmUsrLog;
            ModeloActualizarEmail.empresa = ComPwm;
            ModeloActualizarEmail.cod_tit = cliente.cod_tit.Trim();
            ModeloActualizarEmail.parametro = "email";
            ModeloActualizarEmail.valor = txtcorreo.Text;
            //Envio de datos para actualizar email en RP  
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
            cabecerafactura.usuario_mod = AmUsrLog;
            cabecerafactura.nro_audit = "0"; // por defecto va cero s disapra triger
            cabecerafactura.ocompra = ocompra.Text;
            cabecerafactura.cod_moneda = cmbCod_moneda.SelectedValue;
            cabecerafactura.tipo = Ccf_tipo2;//"NCME";
            cabecerafactura.porc_descto = Convert.ToDecimal("0.00");
            cabecerafactura.descuento = Convert.ToDecimal("0.00");
            cabecerafactura.diar = "0";
            cabecerafactura.mesr = "0";
            cabecerafactura.anior = "0";
            cabecerafactura.cod_proc_aud = "RCOMNCRED";
            cabecerafactura.cod_sucursal = ModeloUsuSucursal.cod_sucursal;
            cabecerafactura.nro_pedido = nro_pedido.Text;
            cabecerafactura.nro_trans_padre = txt_nro_trans_padre.Text;
            //cabecerafactura.tipo_nce = "NCFE"; //NC Financiera
            cabecerafactura.mot_nce = cbx_motivo_nc.SelectedValue;


            error = GuardarCabezera.InsertarCabezeraNotaCredito(cabecerafactura);
            if (string.IsNullOrEmpty(error))
            {

            }
            else
            {

                Session["cabecera"] = cabecerafactura;

            }


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
        public modelowmtfacturascab GuardarDetalle()
        {
            string error;
            //Busca en gv_producto todos los items añadidos que estan en la variable de session detalle
            ModeloDetalleFactura = new List<ModeloDetalleFactura>();
            ModeloDetalleFactura = (Session["detalle"] as List<ModeloDetalleFactura>);

            /*Validar si el saldo de la factura */
            decimal valorSaldo = Convert.ToDecimal(txt_saldo_factura.Text);
            decimal valorTotal = Convert.ToDecimal(txtSumaTotal.Text);
            if (valorTotal > valorSaldo)
            {
                this.Page.Response.Write("<script language='JavaScript'>window.alert('La Nota de Crédito, no puede ser mayor que la Factura ')+ error;</script>");

            }
            else
                if (ModeloDetalleFactura == null)
            {
                this.Page.Response.Write("<script language='JavaScript'>window.alert('Nota de Crédito sin productos')+ error;</script>");
            }
            else {
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
                    detallefactura.cod_doca = txt_cod_docum.Text.Trim();
                    detallefactura.nro_doca = txt_nro_docum.Text.Trim();
                    detallefactura.serie_doca = txt_serie_docum.Text.Trim();
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


                    error = GuardarDetalles.InsertarDetallNCFina(detallefactura);
                    if (string.IsNullOrEmpty(error))
                    {

                    }
                    else
                    {
                        // this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");

                    }

                }
            }
            return conscabcera;
        }




        protected void btn_Fac_Click(object sender, EventArgs e)
        {
            mensaje.Text = null;
            /* SP wmspc_facturasWM_saldo TRAE SOLO FACTURAS CON SALDO DIFERENTE DE 0*/
            string Ven__cod_tit = dniCliente.Text;

            lista = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi);

            cliente = null;
            foreach (modelowmspctitulares item in lista)
            {
                cliente = item;
                break;
            }


            ListaSaldoFacturas = consultaSaldoFactura.BuscartaFacturaSaldos(AmUsrLog, ComPwm, cliente.cod_tit, "C");
            if (ListaSaldoFacturas.Count == 0)
            {
                mensaje.Text = "El cliente no tiene facturas disponibles";
            }
            else
            {
                if (Session["listaFacturas"] == null)
                {
                    Session["listaClienteFac"] = ListaSaldoFacturas;
                    this.Page.Response.Write("<script language='JavaScript'>window.open('./BuscarFacturasNCFin.aspx', 'Buscar Facturas', 'top=100,width=800 ,height=400, left=400');</script>");

                }
            }


        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Session.Remove("articulo");
            Session.Remove("ListaFacturas");
            Response.Redirect("FormBuscarNotaCredito.aspx");
        }

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            //Consultar si el vendedor tiene asignada una sucursal

            ListaModeloUsuarioSucursal = ConsultaUsuxSuc.ConsultaUsuarioSucursal(ComPwm, AmUsrLog);
            int count = 0;
            foreach (var item in ListaModeloUsuarioSucursal)
            {
                ModelousuarioSucursal = item;
                count++;
                break;
            }

            if (count == 0)
            {
                this.Page.Response.Write("<script language='JavaScript'>window.alert('Usuario no tiene asignada sucursal, por favor asignar para continuar con el proceso ')+ error;</script>");
            }
            else
            {
                //Preguntar si existe detalle antes de confirmar
                if (txtSumaTotal.Text == "")
                {
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('No existen productos para la nota de crédito')+ error;</script>");
                }
                else
                {
                    if (txtSumaTotal.Text == "0.00")
                    {
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('No existen productos para la nota de crédito')+ error;</script>");
                    }
                    else
                    {
                        if (Session["detalle"] == null)
                        {
                            this.Page.Response.Write("<script language='JavaScript'>window.alert('No existen productos para la nota de crédito')+ error;</script>");

                        }
                    
                        else
                        {
                            /*Validar si el saldo de la factura */
                            decimal valorSaldo = Convert.ToDecimal(txt_saldo_factura.Text);
                            decimal valorTotal = Convert.ToDecimal(txtSumaTotal.Text);
                            if (valorTotal > valorSaldo)
                            {
                                this.Page.Response.Write("<script language='JavaScript'>window.alert('La Nota de Crédito, no puede ser mayor que la Factura ')+ error;</script>");
                               
                            }
                        else
                        {
                            string respuestaConfirmacionNC = "";
                            //Boton Coonfirmar hace lo mismo que el salvar solo aumenta la insercion a la tabla wmt_facturas_ins
                            conscabcera = null;
                            conscabcera = GuardarDetalle();

                            confirmarinsertar.nro_trans = conscabcera.nro_trans;
                            confirmarinsertar.cod_emp = conscabcera.cod_emp;
                            confirmarinsertar.usuario_mod = AmUsrLog;
                            confirmarinsertar.fecha_mod = DateTime.Now;
                            confirmarinsertar.nro_audit = conscabcera.nro_audit;

                            respuestaConfirmacionNC = ConfirmarFactura.ConfirmarFactura(confirmarinsertar);

                            if (respuestaConfirmacionNC == "")
                            {

                                ConsumoRestNCFin consumoRest = new ConsumoRestNCFin();
                                string respuesta = "";
                                respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", "NC", conscabcera.nro_trans, txt_nro_trans_padre.Text);
                                if (respuesta == "")
                                {
                                    mensaje.Text = "Su nota de crédito fue procesada exitosamente";
                                    Confirmar.Enabled = false;
                                    GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "F");
                                    Session.Remove("listaFacturas");
                                    Response.Redirect("FormBuscarNotaCredito.aspx");

                                }
                                else
                                {
                                    GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "C");
                                    mensaje.Text = respuesta;
                                    Session.Remove("listaFacturas");
                                    Response.Redirect("FormBuscarNotaCredito.aspx");

                                }
                            }
                            else
                            {
                                lbl_trx.Visible = true;
                                lbl_trx.Text = respuestaConfirmacionNC;
                            }
                        }
                    }

                        }
                            

                    }
                }
            
        }

        protected void btnImpuestos_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            /*NC por Devolucion si se puede usar despues de agregar items a la lista*/
            if (Session["valor_asignado"] != null)
            {
                //Despues de confirmar puede usar el valor asignado
                string transa = Session["valor_asignado"].ToString();
                ListaModeloimpuesto = consultaImpuesto.BuscarImpuestoRest(AmUsrLog, ComPwm, transa, "0");
                Session["listaImpuestos"] = ListaModeloimpuesto;
                this.Page.Response.Write("<script language='JavaScript'>window.open('./FormDetalleImpuestos.aspx', 'Detalle Impuesto', 'top=100,width=800 ,height=400, left=400');</script>");
            }
        }

        protected void txt_Codigo_TextChanged(object sender, EventArgs e)
        {
            //Bloquear combo de monedas
            cmbCod_moneda.Enabled = false;
            //Consultamos cuantos descimales se van a usar
            DecimalesMoneda = null;
            DecimalesMoneda = BuscarDecimales();

            int count = 0;
            articulo = null;

            if (Session["articulo"] == null)
            {

                string ArtB__articulo = txt_Codigo.Text;

                listaArticulos = ConsultaArticulo.ConsultaArticulos(AmUsrLog, ComPwm, ArtB__articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);

                foreach (modelowmspcarticulos item in listaArticulos)
                {
                    count++;
                    articulo = item;

                }

            }
            else
            {
                articulo = (modelowmspcarticulos)Session["articulo"];
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
                    txt_Codigo.Text = "No existe el producto/ servicio";
                }
                else
                {
                                    
                    txt_Codigo.Text = articulo.cod_articulo;
                    txt_Descripcion.Text = articulo.nom_articulo;
                    decimal precio_unitario = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo_pu, Convert.ToDecimal(articulo.precio_total));
                    txt_Precio.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo_pu, precio_unitario);
                    decimal IvaFac = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(articulo.porc_impuesto));
                    txt_Iva.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, IvaFac);

                    txt_Desc.Text = "0";
                    Session.Remove("articulo");

                }
            }

        }
    }
}