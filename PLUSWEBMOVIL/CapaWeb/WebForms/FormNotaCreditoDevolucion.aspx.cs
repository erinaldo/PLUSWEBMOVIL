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
    public partial class FormNotaCreditoDevolucion : System.Web.UI.Page
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
        modelowmtfacturascab conscabceraTipo = new modelowmtfacturascab();

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
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        ConsultaValidarParametrosFactura consultaValidarFactura = new ConsultaValidarParametrosFactura();

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
        public string ArtB__tipo = "0";
        public string ArtB__compras = "0";
        public string ArtB__ventas = "S";
        public string Ccf_tipo1 = "C";
        public string Ccf_tipo2 = "NCVE";
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
                    Session.Remove("listaClienteFac");
                    Session.Remove("listaFacturas");
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
                            try
                            {
                                cargarListaDesplegables();
                                Session.Remove("listaCliente");
                                Session.Remove("listaArticulos");
                                Session.Remove("articulo");
                                Session.Remove("ListaFacturas");
                                Session.Remove("valor_asignado");

                                Session["Tipo"] = "Anular";
                                DateTime hoy1 = DateTime.Today;
                                fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");

                                ConsultarTasaCambioCanorus();

                                break;
                            }
                            catch (Exception ex)
                            {
                                GuardarExcepciones("Page_Load, AFA", ex.ToString());
                            }
                            break;

                        case "INS":
                            try
                            {
                                Session.Remove("listaCliente");
                                Session.Remove("valor_asignado");
                                Session.Remove("Tipo");
                                Session.Remove("articulo");
                                Session.Remove("ListaFacturas");
                                Session.Remove("valor_asignado");
                                cargarListaDesplegables();
                                DateTime hoy = DateTime.Today;
                                fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                                //Consultar tasa de cambio
                                ConsultarTasaCambioCanorus();
                                SetearCampos();

                                /* ModeloRolMod = BuscarRolModificar( AmUsrLog, ComPwm, "VTA", "NA", "N");
                                 if (ModeloRolMod.control_uso == "readonly=\"readonly\"")
                                 {
                                     precio.Enabled = false;
                                 }*/
                                break;
                            }
                            catch (Exception ex)
                            {
                                GuardarExcepciones("Page_Load, INS", ex.ToString());
                            }
                            break;

                        case "UDP":
                            try
                            {
                                Session.Remove("Tipo");
                                Int64 id = Int64.Parse(qs["Id"].ToString());
                                Session["valor_asignado"] = id.ToString();
                                txt_nro_trans_padre.Text = id.ToString();
                                cargarListaDesplegables();
                                LlenarFactura();

                                break;
                            }
                            catch (Exception ex)
                            {
                                GuardarExcepciones("Page_Load, UDP", ex.ToString());
                            }
                            break;

                        case "VER":
                            try
                            {
                                Int64 ide = Int64.Parse(qs["Id"].ToString());
                                Session["valor_asignado"] = ide.ToString();

                                cargarListaDesplegables();
                                LlenarFactura();
                                BloquearNCVer();
                                break;
                            }
                            catch (Exception ex)
                            {
                                GuardarExcepciones("Page_Load, VER", ex.ToString());
                            }
                            break;
                    }

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
                    //Consultamos cuantos descimales se van a usar redondeo
                    DecimalesMoneda = null;
                    DecimalesMoneda = BuscarDecimales();
                    // recupera la variable de secion con el objetoarticulo
                    consdetalle = (ModeloDetalleFactura)Session["articulo"];

                    decimal CantFac = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(consdetalle.cantidad));
                    txt_Cantidad.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, CantFac);
                    txt_cantidad_pro.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, CantFac);
                    txt_Codigo.Text = consdetalle.cod_articulo.Trim();
                    txt_Descripcion.Text = consdetalle.nom_articulo;
                    decimal PrecioFac = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo_pu, Convert.ToDecimal(consdetalle.precio_unit));
                    //Redondear el numero a precios_uni
                    decimal precio_unitario = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo_pu, Convert.ToDecimal(consdetalle.precio_unit));
                    txt_Precio.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo_pu, precio_unitario);
                    decimal IvaFac = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(consdetalle.porc_iva));
                    txt_Iva.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, IvaFac);
                    decimal DescFac = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(consdetalle.porc_descto));
                    txt_Desc.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, DescFac);


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
                    cmbCod_moneda.Enabled = true;
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


                ConsultarTasaCambioCanorus();
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());
            }


        }
        public void GuardarExcepciones(string metodo, string error)
        {
            
            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "FormNotaCreditoDevolucion.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;
            
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción" + metodo + "." + " Por favor notificar al administrador.";

        }

        protected void SetearCampos()
        {
            /*Campos para insertar detalle de la nc*/
            /*Campos para insertar detalle de la nc*/
            txt_nro_factura.Text = null;
            txt_cod_docum.Text = null;
            txt_serie_docum.Text = null;
            txt_nro_docum.Text = null;
            txt_nro_trans_padre.Text = null;
            txt_subtotal_factura.Text = null;
            txt_total_factura.Text = null;
            txt_iva_factura.Text = null;
            txt_descuento_factura.Text = null;
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
            try
            {
                lbl_error.Text = "";
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
            catch (Exception ex)
            {
                GuardarExcepciones("dniCliente_TextChanged", ex.ToString());

            }
        }
        public modelowmspctctrxCotizacion BuscarCotizacion(string Ccf_usuario, string Ccf_cod_emp, string dia, string mes, string anio, string moneda)
        {
            try
            {
                lbl_error.Text = "";
                ListaModelocotizacion = consultaMoneda.TasaCambioActual(Ccf_usuario, Ccf_cod_emp, dia, mes, anio, moneda);

                foreach (var item in ListaModelocotizacion)
                {
                    ModeloCotizacion = item;

                    break;
                }

                return ModeloCotizacion;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarCotizacion", ex.ToString());
                return null;
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
        protected void ConsultarTasaCambioCanorus()
        {
            try
            {
                lbl_error.Text = "";
                DateTime hoy = DateTime.Today;
                fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                string dia = string.Format("{0:00}", hoy.Day);
                string mes = string.Format("{0:00}", hoy.Month);
                string anio = hoy.Year.ToString();
                ModeloCotizacion = BuscarCotizacion(AmUsrLog, ComPwm, dia, mes, anio, "USD");
                if (ModeloCotizacion.tc_mov == null)
                {
                    lbl_trx.Text = " No existe Tipo de Cambio registrado para la fecha de la nota de crédito. Por favor registrar la tasa del dia y actualizar la pagina";
                    lbl_trx.Visible = true;
                    BloquearCabeceraNC();
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("ConsultarTasaCambioCanorus", ex.ToString());


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


        protected void gv_Producto_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                lbl_error.Text = "";

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
            catch (Exception ex)
            {
                GuardarExcepciones("gv_Producto_ItemCommand", ex.ToString());

            }

        }
        public void cargarListaDesplegables()
        {
            try
            {

                lbl_error.Text = "";

            //LIsta Resolucion facturas
            listaRes = ConsultaResolucion.ConsultaResolusiones(AmUsrLog, ComPwm, ResF_estado, ResF_serie, ResF_tipo);
                resolucion = null;
                foreach (modelowmspcresfact item in listaRes)
                {
                    resolucion = item;

                }
                serie_docum.DataSource = listaRes;
            serie_docum.DataTextField = "serie_docum";
            serie_docum.DataValueField = "serie_docum";
            serie_docum.DataBind();
                //Aqui se va a traer que tipo de facturacion es
                if (resolucion.tipo_fac == "S")
                {
                    Session["Ccf_tipo2"] = "NCVE";
                }
                else { Session["Ccf_tipo2"] = "NCV"; }


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
            catch (Exception ex)
            {
                GuardarExcepciones("cargarListaDesplegables", ex.ToString());

            }
        }
        protected void LlenarFactura()
        {
            try
            {

                lbl_error.Text = "";
                //llenar formulario para la actualizacion de datos
                string Ccf_nro_trans = Session["valor_asignado"].ToString();
                conscabceraTipo = buscarTipoFac(Ccf_nro_trans);
                Session["Ccf_tipo2"] = conscabceraTipo.tipo_nce.Trim();
                listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Session["Ccf_tipo2"].ToString(), Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
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
                //Consultamos cuantos descimales se van a usar redondeo
                decimal SubTotal = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.subtotal);
                txtSumaSubTo.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), SubTotal);
                decimal Total = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.total);
                txtSumaTotal.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), Total);
                decimal SumIva = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.iva);
                txtSumaIva.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), SumIva);
                decimal SumDesc = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.descuento);
                txtSumaDesc.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), SumDesc);

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
                decimal BaseIva19 = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), baseiva19);
                txtBaseIva19.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), BaseIva19);
                decimal Base15 = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), baseiva15);
                txtBase15.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), Base15);
                decimal Iva19 = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), iva19);
                txtIva19.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), Iva19);
                decimal Iva15 = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), iva15);
                txtIva15.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), Iva15);

                //Llenar variables de seccion de bae e ivas

                Session["sumaBase19"] = baseiva19;
                Session["sumaBase15"] = baseiva15;
                Session["sumaIva19"] = iva19;
                Session["sumaIva15"] = iva15;
                gv_Producto.DataSource = listaConsDetalle;
                gv_Producto.DataBind();
                gv_Producto.Height = 100;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("LlenarFactura", ex.ToString());

            }

        }

        public modeloCodProcesoFactura BuscarCodProceso(string cod_proceso)
        {
            try
            {
                lbl_error.Text = "";


                ListaModeloCodProceso = ConsultaCodProceso.DatosCodProceso(cod_proceso);
    
                ModeloCodProceso = null;
                foreach (modeloCodProcesoFactura item in ListaModeloCodProceso)
                {
                    ModeloCodProceso = item;

                }
                return ModeloCodProceso;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarCodProceso", ex.ToString());
                return null;
            }
        }

        public modeloRolModificarPrecio BuscarRolModificar(string usuario, string cod_emp, string tipo, string campo, string accion)
        {
            try
            {
                lbl_error.Text = "";
                ListaRolMod = ConsultaRolMod.BuscartaRolModificar(usuario, cod_emp, tipo, campo, accion);
                ModeloRolMod = null;
                foreach (modeloRolModificarPrecio item in ListaRolMod)
                {
                      ModeloRolMod = item;

                }

                return ModeloRolMod;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarRolModificar", ex.ToString());
                return null;
            }
        }

        public modelowmspcarticulos BuscarProducto(string ArtB__articulo)
        {
            try
            {
                lbl_error.Text = "";

                listaArticulos = ConsultaArticulo.ConsultaArticulos(AmUsrLog, ComPwm, ArtB__articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);

                articulo = null;
                foreach (modelowmspcarticulos item in listaArticulos)
                {

                    articulo = item;
                    break;

                }

                return articulo;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarProducto", ex.ToString());
                return null;
            }
        }
        //Consulta con cod_articulo el detalle de la factura y agrega conestado P
        public void AgregarDetalleNotaCredito()
        {
            try
            {
                lbl_error.Text = "";

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
                       
                            /* sumo los numebos valores agregados al producto*/
                            itemSuma.cantidad += Convert.ToDecimal(txt_Cantidad.Text);
                            itemSuma.precio_unit = Convert.ToDecimal(txt_Precio.Text);
                            itemSuma.porc_iva =  Convert.ToDecimal(txt_Iva.Text);
                            itemSuma.porc_descto = Convert.ToDecimal(txt_Iva.Text);
                           
                           
                          
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
                       
                        item.precio_unit = Convert.ToDecimal(txt_Precio.Text);
                        item.porc_iva = Convert.ToDecimal(txt_Iva.Text);
                        item.porc_descto = Convert.ToDecimal(txt_Desc.Text);
                        item.cod_cta_cos = articulo.cod_cta_cos;
                        item.cod_cta_inve = articulo.cod_cta_inve;
                        item.cod_cta_vtas = articulo.cod_cta_vtas;
                        item.base_imp = Convert.ToDecimal(articulo.porc_aiu); 
                        item.tasa_iva = articulo.cod_tasa_impu;
                        item.cod_concepret = articulo.cod_concepret;

                        ModeloDetalleFactura.Add(item);
                    }


                    Session["detalle"] = ModeloDetalleFactura;

                    txt_Codigo.Text = "";
                    txt_Descripcion.Text = "";
                    txt_Precio.Text = "0";
                    txt_Iva.Text = "0";
                    txt_Desc.Text = "0";
                    txt_Cantidad.Text = "1";
                    item = null;

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("AgregarDetalleNotaCredito", ex.ToString());

            }
        }

        public void TraeDetalleFactura()
        {

            listaConsCab = null;
            listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Session["Ccf_tipo2"].ToString(), valor_asignado, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);

            conscabcera = null;
            foreach (modelowmtfacturascab item in listaConsCab)
            {
                conscabcera = item;

            }

            decimal SubTotal = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.subtotal);
            txtSumaSubTo.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), SubTotal);
            decimal Total = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.total);
            txtSumaTotal.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), Total);
            decimal SumIva = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.iva);
            txtSumaIva.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), SumIva);
            decimal SumDesc = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.descuento);
            txtSumaDesc.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), SumDesc);

            Session["sumaSubtotal"] = Convert.ToString(conscabcera.subtotal);
            Session["sumaDescuento"] = Convert.ToString(conscabcera.descuento);
            Session["sumaIva"] = Convert.ToString(conscabcera.iva);
            Session["sumaTotal"] = Convert.ToString(conscabcera.total);
            //Despues de guardar
            listaConsDetalle = null;
            listaConsDetalle = ConsultaDeta.ConsultaDetalleFacura(valor_asignado);


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
            decimal BaseIva19 = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), baseiva19);
            txtBaseIva19.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), BaseIva19);
            decimal Base15 = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), baseiva15);
            txtBase15.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), Base15);
            decimal Iva19 = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), iva19);
            txtIva19.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), Iva19);
            decimal Iva15 = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), iva15);
            txtIva15.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), Iva15);

            //Llenar variables de seccion de bae e ivas

            Session["sumaBase19"] = baseiva19;
            Session["sumaBase15"] = baseiva15;
            Session["sumaIva19"] = iva19;
            Session["sumaIva15"] = iva15;
            gv_Producto.DataSource = listaConsDetalle;
            gv_Producto.DataBind();
            gv_Producto.Height = 100;

        }
        //validar parametrizacion de nc para poder 
        public void ValidarParametrosFactura()
        {
            try
            {
                lbl_error.Text = "";
                string perido_contable = "";
                perido_contable = consultaValidarFactura.ConsultaValidarPeriodoContable(ComPwm, AmUsrLog, fecha.Text);
                if (perido_contable == "")
                {
                    lbl_validacion.Text = "El Periodo Contable correspondiente a la fecha del documento se encuentra cerrado o no existe. Por favor registrar Periodo Contable y actualizar la página";
                    lbl_validacion.Visible = true;
                    AgregarNC.Enabled = false;
                }
                else
                {
                    Boolean empresa = false;
                    empresa = consultaValidarFactura.ConsultaValidarMonCiudEmpresaERP(ComPwm, AmUsrLog);
                    if (empresa == false)
                    {
                        lbl_validacion.Text = " No existe moneda o ciudad de la empresa registrado para la factura. Por favor registrar información y actualizar la página";
                        lbl_validacion.Visible = true;
                        AgregarNC.Enabled = false;
                    }
                    else
                    {
                        Boolean resolucion = false;
                        resolucion = consultaValidarFactura.ConsultaValidarResolucionERP(ComPwm, AmUsrLog, "V", serie_docum.SelectedValue.Trim(), fecha.Text, Modelowmspclogo.cod_emp_erp.Trim());
                        if (resolucion == false)
                        {
                            lbl_validacion.Text = " No existe resolución de factura. Por favor registrar información y actualizar la página";
                            lbl_validacion.Visible = true;
                            AgregarNC.Enabled = false;
                        }
                        else
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
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("ValidarParametrosFactura", ex.ToString());

            }

        }
        protected void AgregarNC_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                /*
                 ---Comparar cantidades antes de agregar
                 decimal cant_act = Convert.ToDecimal(txt_Cantidad.Text); Cantidad colocada en el monento
                 decimal cant_ant = Convert.ToDecimal(txt_cantidad_pro.Text); Cant qu trae del detalle de la factura
                 */
                listaCantNCTotales = ConsultaDeta.ConsultaCantidadesNCDev(ComPwm, txt_nro_docum.Text, txt_serie_docum.Text, txt_Codigo.Text);
                foreach (ModeloDetalleFactura item in listaCantNCTotales)
                {

                    consCantNC = item;

                }
                decimal cant_act = Convert.ToDecimal(txt_Cantidad.Text);
                decimal cant_ant = Convert.ToDecimal(txt_cantidad_pro.Text);
                if (listaCantNCTotales.Count == 0)
                {

                    if (cant_act > cant_ant)
                    {
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('La cantidad de devolución, no puede ser mayor que la cantidad de compra de producto ')+ error;</script>");
                    }
                    else
                    {
                        //Buscar Datos de parametrizacion------periodo contable
                        ValidarParametrosFactura();
                        //Mostrar grilla y guardar con estado P
                        AgregarDetalleNotaCredito(); //Calcula totales y agrega a grilla
                        GuardarDetalle(); //Guarda cabecera y detalle con estado P
                        BloquearCabeceraNC();//Bloquear cabecera NC
                        TraeDetalleFactura();
                    }
                }

                else
                {
                    //Comparar cantidades  Cantidad vendida - Cantidad devuelta 
                    decimal CompararValores = cant_ant - consCantNC.cantidad;
                    if (cant_act > CompararValores || cant_ant == consCantNC.cantidad)
                    {
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('La cantidad de devolución, no puede ser mayor que la cantidad de compra de producto ')+ error;</script>");
                    }
                    else
                    {
                        //Buscar Datos de parametrizacion------periodo contable
                        ValidarParametrosFactura();
                        //Mostrar grilla y guardar con estado P
                        AgregarDetalleNotaCredito(); //Calcula totales y agrega a grilla
                        GuardarDetalle(); //Guarda cabecera y detalle con estado P

                        BloquearCabeceraNC();//Bloquear cabecera NC
                        TraeDetalleFactura();

                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("AgregarNC_Click", ex.ToString());

            }
        }
        public void AgregarCabeceraDetalle()
        {
            try
            {
                lbl_error.Text = "";

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
                             
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("AgregarCabeceraDetalle", ex.ToString());

            }

        }
        public void InsertarCabecera()
        {
            try
            {
                lbl_error.Text = "";
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
                cabecerafactura.tipo = Session["Ccf_tipo2"].ToString(); //"NCVE";
                cabecerafactura.porc_descto = Convert.ToDecimal("0.00");
                cabecerafactura.descuento = Convert.ToDecimal("0.00");
                cabecerafactura.diar = "0";
                cabecerafactura.mesr = "0";
                cabecerafactura.anior = "0";
                cabecerafactura.cod_proc_aud = "RCOMNCRED";
                cabecerafactura.cod_sucursal = ModeloUsuSucursal.cod_sucursal;
                cabecerafactura.nro_pedido = nro_pedido.Text;
                cabecerafactura.nro_trans_padre = txt_nro_trans_padre.Text;
                //cabecerafactura.tipo_nce = "NCDE";
                cabecerafactura.mot_nce = "1"; //Motivo NC para DS 1 por devolucion


                error = GuardarCabezera.InsertarCabezeraNotaCredito(cabecerafactura);
                if (string.IsNullOrEmpty(error))
                {

                }
                else
                {

                    Session["cabecera"] = cabecerafactura;

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("InsertarCabecera", ex.ToString());

            }


        }
        public modelowmtfacturascab BuscarCabecera()
        {
            try
            {
                lbl_error.Text = "";

                //Busca el nro de auditoria para poder insertar el detalle factura
                //consulta nro_auditoria de la cabecera
                string Ccf_nro_trans = valor_asignado;
                listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Session["Ccf_tipo2"].ToString(), Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
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
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarCabecera", ex.ToString());

                return null;
            }
        }
        public modelowmtfacturascab GuardarDetalle()
        {
            try
            {
                lbl_error.Text = "";
                string error;
                //Busca en gv_producto todos los items añadidos que estan en la variable de session detalle
                ModeloDetalleFactura = new List<ModeloDetalleFactura>();
                ModeloDetalleFactura = (Session["detalle"] as List<ModeloDetalleFactura>);

                //Insertar primero la cabecera
                InsertarCabecera();
                /*
                 * Si no existe detalle debria guardar solo cabecera*/
                if (ModeloDetalleFactura == null)
                {
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Factura salvada correctamente')+ error;</script>");
                }
                else
                {
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
            catch (Exception ex)
            {
                GuardarExcepciones("GuardarDetalle", ex.ToString());
                return null;
            }
        }




        protected void btn_Fac_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
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
                string tipo_fac = Session["Ccf_tipo2"].ToString();
                if (tipo_fac.Trim() == "NCV")
                {

                    ListaSaldoFacturas = consultaSaldoFactura.ConsultaFacturasVTASaldos(AmUsrLog, ComPwm, cliente.cod_tit, "C");
                }

                else

                {

                    ListaSaldoFacturas = consultaSaldoFactura.BuscartaFacturaSaldos(AmUsrLog, ComPwm, cliente.cod_tit, "C");
                }
                if (ListaSaldoFacturas.Count == 0)
                {
                    mensaje.Text = "El cliente no tiene facturas disponibles";
                }
                else
                {
                    if (Session["listaFacturas"] == null)
                    {
                        Session["listaClienteFac"] = ListaSaldoFacturas;
                        Session["Tipo"] = tipo_fac.Trim();
                        this.Page.Response.Write("<script language='JavaScript'>window.open('./BuscarFacturasNC.aspx', 'Buscar Facturas', 'top=100,width=800 ,height=400, left=400');</script>");

                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_Fac_Click", ex.ToString());

            }


        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                Session.Remove("articulo");
                Session.Remove("ListaFacturas");
                Response.Redirect("FormBuscarNotaCredito.aspx");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Cancelar_Click", ex.ToString());

            }
        }

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
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
                                //cOSNULTA BUSCAR TIPO DE FACTURA
                                conscabceraTipo = null;
                                conscabceraTipo = buscarTipoFac(conscabcera.nro_trans.Trim());
                                if (conscabceraTipo.tipo_nce.Trim() == "NCVE")
                                {
                                    if (respuestaConfirmacionNC == "")
                                {
                                        //AVERIGUAR LA VERSION DE NC QUE USA
                                        string respuesta = "";
                                        if (Modelowmspclogo.version_fe == "1")
                                        {
                                            ConsumoRestNCFin consumoRest = new ConsumoRestNCFin();
                                            respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", "NC", conscabcera.nro_trans, txt_nro_trans_padre.Text);
                                        }
                                        else
                                        {
                                            ConsumoRestNCFinV2 consumoRest = new ConsumoRestNCFinV2();
                                            respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", "NC", conscabcera.nro_trans, txt_nro_trans_padre.Text);
                                        }

                                 
                                   
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
                                else
                                {
                                    Session.Remove("listaFacturas");
                                    Response.Redirect("FormBuscarNotaCredito.aspx");
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Confirmar_Click", ex.ToString());

            }
        }

        public modelowmtfacturascab buscarTipoFac(string nro_trans)
        {
            try
            {
                lbl_error.Text = "";

                listaConsCab = ConsultaCabe.ConsultaTipoFactura(nro_trans);
                int count = 0;
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                    count++;
                    conscabcera = item;

                }
                return conscabcera;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("buscarTipoFac", ex.ToString());
                return null;
            }
        }

        protected void btnImpuestos_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                lbl_error.Text = "";
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
            catch (Exception ex)
            {
                GuardarExcepciones("btnImpuestos_Click", ex.ToString());

            }
        }

        //Buscar cantidad de decimales q se va ausar x tipo de moneda
        public modelowmspcmonedas BuscarDecimales()
        {
            try
            {
                lbl_error.Text = "";
                listaMonedas = ConsultaCMonedas.ConsultaCMonedas(AmUsrLog, ComPwm, cmbCod_moneda.SelectedValue);

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
        protected void txt_Codigo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                if (txt_nro_trans_padre.Text == null || txt_nro_trans_padre.Text == "")
                {
                    lbl_trx.Text = "Seleccione Factura para realizar la Nota de Crédito";
                    lbl_trx.Visible = true;
                }
                else
                {
                    //Bloquear combo de monedas
                    cmbCod_moneda.Enabled = false;
                    //Consultamos cuantos descimales se van a usar
                    DecimalesMoneda = null;
                    DecimalesMoneda = BuscarDecimales();

                    int count = 0;
                    consdetalle = null;
                    if (Session["articulo"] == null)
                    {
                        //Buscar detalle de factura
                        string like = '%' + txt_Codigo.Text + '%';
                        listaConsDetalle = ConsultaDeta.ConsultaDetFacNCDev(txt_nro_trans_padre.Text, like);

                        foreach (ModeloDetalleFactura item in listaConsDetalle)
                        {
                            count++;
                            consdetalle = item;

                        }
                    }
                    else
                    {
                        consdetalle = (ModeloDetalleFactura)Session["articulo"];
                    }

                    if (count > 1)
                    {
                        Session["listaProducto"] = listaConsDetalle;
                        this.Page.Response.Write("<script language='JavaScript'>window.open('./BuscarArticuloNCDevolucion.aspx', 'Buscar Articulo', 'top=100,width=800 ,height=600, left=400');</script>");

                    }
                    else
                    {

                        if (consdetalle == null)
                        {
                            txt_Codigo.Text = "No existe el producto/ servicio";
                            txt_Cantidad.Text = "1";
                            txt_Descripcion.Text = "";
                            txt_Precio.Text = "0";
                            txt_Iva.Text = "";
                            txt_Desc.Text = "0";
                        }
                        else
                        {
                            //Trae los datos desde la base
                            decimal CantFac = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(consdetalle.cantidad));
                            txt_Cantidad.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, CantFac);
                            txt_cantidad_pro.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, CantFac);
                            txt_Codigo.Text = consdetalle.cod_articulo;
                            txt_Descripcion.Text = consdetalle.nom_articulo;
                            decimal PrecioFac = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo_pu, Convert.ToDecimal(consdetalle.precio_unit));
                            //Redondear el numero a precios_uni
                            decimal precio_unitario = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo_pu, Convert.ToDecimal(consdetalle.precio_unit));
                            txt_Precio.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo_pu, precio_unitario);
                            decimal IvaFac = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(consdetalle.porc_iva));
                            txt_Iva.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, IvaFac);
                            decimal DescFac = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(consdetalle.porc_descto));
                            txt_Desc.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, DescFac);
                            Session.Remove("articulo");


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("txt_Codigo_TextChanged", ex.ToString());

            }
        }
        
        
    }
}