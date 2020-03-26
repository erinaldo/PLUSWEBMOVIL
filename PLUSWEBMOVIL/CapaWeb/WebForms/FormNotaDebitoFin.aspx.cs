using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;
using CapaDatos.Modelos.ModelosNC;
using System.IO;
using CapaProceso.GenerarPDF.FacturaElectronica;

namespace CapaWeb.WebForms
{
    public partial class FormNotaDebitoFin : System.Web.UI.Page
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

        public List<JsonRespuestaDE> ListaModelorespuestaDs = null;
        public JsonRespuestaDE ModeloResQr = new JsonRespuestaDE();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();
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
        public string ArtB__ventas = "0";
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
        public int contador = 0;
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
                    Session.Remove("saldoFacturas");
                    Session.Remove("listaProducto");
                    Session.Remove("articulo");
                    Session.Remove("sumaSubtotal");
                    Session.Remove("sumaTotal");
                    Session.Remove("sumaIva");
                    Session.Remove("sumaDescuento");
                    Session.Remove("cliente");
                    Session.Remove("detalle");
                    Session.Remove("primer_item");

                    QueryString qs = ulrDesencriptada();

                    //Recibir opciones
                    switch (qs["TRN"].Substring(0, 3))
                    {
                        case "INS":
                            try
                            {
                                //TRX
                                lbl_trans.Text = ConsultaNroTran.NroTrans(numerador);
                                lbl_error.Text = "";
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
                                GuardarExcepciones("Page_Load, INS", ex.ToString());
                            }
                            break;

                        case "UDP":
                            try
                            {
                                Session.Remove("Tipo");
                                Int64 id = Int64.Parse(qs["Id"].ToString());
                                Session["valor_asignado"] = id.ToString();
                                lbl_trans.Text = id.ToString();
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
                                lbl_trans.Text = ide.ToString();
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
                    suc_cliente.Text = cliente.cod_sucursal;
                    sucursal_lbl.Text = cliente.codnom_suc;
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
                    lbl_tipo_fac.Text = conscabcera.tipo_nce;
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
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());
            }
        }
        public void GuardarExcepciones(string metodo, string error)
        {
            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "FormNotaDebitoFin.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción" + metodo + "." + " Por favor notificar al administrador.";

        }

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

        protected void BloquearDatosFactura()
        {
            //Visible Datos Factura
            lbl_trx_padre.Visible = true;
            txt_nro_trans_padre.Visible = true;
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
            // btnImpuestos.Enabled = false;
            btnGuardarDetalle.Visible = false;
            btn_Fac.Enabled = false;
            //detalle producto
            txt_Codigo.Enabled = false;
            txt_Cantidad.Enabled = false;
            txt_Descripcion.Enabled = false;
            txt_Precio.Enabled = false;
            txt_Desc.Enabled = false;
            txt_Iva.Enabled = false;
            txt_Descripcion2.Enabled = false;
        }
        protected void dniCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {

                lbl_error.Text = "";
                string Ven__cod_tit = dniCliente.Text;


                if (suc_cliente.Text == "" || suc_cliente.Text == null)
                {
                    lista = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi, null);
                }
                else
                {
                    lista = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi, suc_cliente.Text);
                }
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
                        suc_cliente.Text = "";
                        sucursal_lbl.Text = "";
                        // this.Page.Response.Write("<script language='JavaScript'>window.open('./CrearCliente.aspx','Crear Cliente', 'top=100,width=580 ,height=400, left=400');</script>");

                    }
                    else
                    {

                        Session.Remove("cliente");

                        nombreCliente.Text = cliente.nom_tit;
                        fonoCliente.Text = cliente.tel_tit;
                        dniCliente.Text = cliente.nro_dgi2;
                        txtcorreo.Text = cliente.email_tit;
                        suc_cliente.Text = cliente.cod_sucursal;
                        sucursal_lbl.Text = cliente.codnom_suc;

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
                    BloquearFactura();
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
                //consultar con nro_trans, linea
                txt_linea.Text = Convert.ToString(((Label)e.Item.Cells[0].FindControl("linea")).Text);
                listaConsDetalle = ConsultaDeta.ConsultaDetalleFacuraLinea(lbl_trans.Text, txt_linea.Text);
                detallefactura = null;
                foreach (ModeloDetalleFactura item in listaConsDetalle)
                {
                    detallefactura = item;

                }

                switch (e.CommandName) //ultilizo la variable para la opcion            
                {
                    case "Editar":// lleno las cajas de texto con los datos para la edicon del item seleccionado
                        txt_Codigo.Text = detallefactura.cod_articulo;
                        txt_Descripcion.Text = detallefactura.nom_articulo;
                        txt_Descripcion2.Text = detallefactura.nom_articulo2;
                        txt_Cantidad.Text = String.Format("{0:N}", Math.Round(Convert.ToDecimal(detallefactura.cantidad), 0)).ToString();
                        txt_Desc.Text = String.Format("{0:N}", Math.Round(Convert.ToDecimal(detallefactura.porc_descto), 2)).ToString();
                        txt_Precio.Text = detallefactura.precio_unit.ToString();
                        txt_Iva.Text = String.Format("{0:N}", Math.Round(Convert.ToDecimal(detallefactura.porc_iva), 2)).ToString();

                        break;

                    case "Eliminar":
                        GuardarDetalles.EliminarDetalleFactura(lbl_trans.Text.Trim(), txt_linea.Text, ComPwm, AmUsrLog);
                        TraeDetalleFactura();
                        txt_linea.Text = "";
                        break;
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
                    Session["Ccf_tipo2"] = "NCME";
                }
                else { Session["Ccf_tipo2"] = "NCM"; }

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
        public void CargarCamposFactura(string trx_factura)
        {
            DecimalesMoneda = null;
            DecimalesMoneda = BuscarDecimales();
            conscabceraTipo = null;
            conscabceraTipo = Trans_Padre(trx_factura);

            listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, "0", trx_factura, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
            int count = 0;
            conscabcera = null;
            foreach (modelowmtfacturascab item in listaConsCab)
            {
                count++;
                conscabcera = item;

            }
            /*Campos para insertar detalle de la nc*/
            txt_nro_factura.Text = conscabcera.observacion;
            txt_cod_docum.Text = conscabcera.cod_docum;
            txt_serie_docum.Text = conscabcera.serie_docum;
            txt_nro_docum.Text = conscabcera.nro_docum;
            txt_nro_trans_padre.Text = conscabcera.nro_trans;
            lbl_tipo_fac.Text = conscabceraTipo.tipo_nce;
            //Formato totales
            //saldo factura
            if (Session["Ccf_tipo2"].ToString() == "NCM")
            {

                ListaSaldoFacturas = consultaSaldoFactura.ConsultaFacturasVTASaldos(AmUsrLog, ComPwm, conscabcera.cod_cliente, "C", "N");
            }

            else

            {

                ListaSaldoFacturas = consultaSaldoFactura.BuscartaFacturaSaldos(AmUsrLog, ComPwm, conscabcera.cod_cliente, "C", "N");
            }
            foreach (var item in ListaSaldoFacturas)
            {
                if (item.nro_trans == txt_nro_trans_padre.Text)
                {
                    txt_saldo_factura.Text = Convert.ToString(item.saldo);
                }
            }

            txt_subtotal_factura.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, conscabcera.subtotal);
            txt_total_factura.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, conscabcera.total);
            txt_iva_factura.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, conscabcera.iva);
            txt_descuento_factura.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, conscabcera.descuento);
            BloquearDatosFactura();
        }

        public modelowmtfacturascab Trans_Padre(string nro_trans)
        {
            try
            {
                lbl_error.Text = "";

                listaConsCab = ConsultaCabe.ConsultaNCTransPadre(nro_trans);
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
                GuardarExcepciones("Trans_Padre", ex.ToString());
                return null;
            }
        }
        protected void LlenarFactura()
        {
            //llenar formulario para la actualizacion de datos
            try
            {
                lbl_error.Text = "";
                DecimalesMoneda = null;
                DecimalesMoneda = BuscarDecimales();

                string Ccf_nro_trans = lbl_trans.Text;
                conscabceraTipo = Trans_Padre(Ccf_nro_trans);
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
                suc_cliente.Text = conscabcera.cod_suc_cli;
                sucursal_lbl.Text = conscabcera.codnom_suc;
                //Formato totales
                //Consultamos cuantos descimales se van a usar redondeo

                //Formato totales
                decimal SubTotal = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.subtotal);
                txtSumaSubTo.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), SubTotal);
                decimal Total = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.total);
                txtSumaTotal.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), Total);
                decimal SumIva = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.iva);
                txtSumaIva.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), SumIva);
                decimal SumDesc = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.descuento);
                txtSumaDesc.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), SumDesc);

                decimal BaseIva19 = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.monto_imponible);
                txtBaseIva19.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), BaseIva19);
                decimal Iva19 = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.iva);
                txtIva19.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), Iva19);

                Session["sumaSubtotal"] = Convert.ToString(conscabcera.subtotal);
                Session["sumaDescuento"] = Convert.ToString(conscabcera.descuento);
                Session["sumaIva"] = Convert.ToString(conscabcera.iva);
                Session["sumaTotal"] = Convert.ToString(conscabcera.total);

                CargarCamposFactura(conscabceraTipo.nro_trans_padre);
                //Carga detalle factura
                string nro_trans = Ccf_nro_trans;

                listaConsDetalle = ConsultaDeta.ConsultaDetalleFacura(nro_trans);
                Session["detalle"] = listaConsDetalle;

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

                int count = 0;
                ModeloCodProceso = null;
                foreach (modeloCodProcesoFactura item in ListaModeloCodProceso)
                {
                    count++;
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

                int count = 0;
                ModeloRolMod = null;
                foreach (modeloRolModificarPrecio item in ListaRolMod)
                {
                    count++;
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
                    lbl_trx.Text = " No existe Tipo de Cambio registrado para la fecha de la nota de crédito. Por favor registrar la tasa del dia y actualizar la pagina";
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
                            itemSuma.porc_iva = Convert.ToDecimal(txt_Iva.Text);
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
                        /*SE REALIZA SOLO PARA LA PRIMERA INSERCION DE UN CONCEPTO DE NC*/
                        if (ModeloDetalleFactura.Count == 0)
                        {
                            Session["primer_item"] = item.cantidad * item.precio_unit;
                        }
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

            decimal BaseIva19 = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.monto_imponible);
            txtBaseIva19.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), BaseIva19);
            decimal Iva19 = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.iva);
            txtIva19.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), Iva19);

            Session["sumaSubtotal"] = Convert.ToString(conscabcera.subtotal);
            Session["sumaDescuento"] = Convert.ToString(conscabcera.descuento);
            Session["sumaIva"] = Convert.ToString(conscabcera.iva);
            Session["sumaTotal"] = Convert.ToString(conscabcera.total);
            //Despues de guardar
            listaConsDetalle = null;
            listaConsDetalle = ConsultaDeta.ConsultaDetalleFacura(lbl_trans.Text.Trim());
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
        //Prueba cabcera sinn lista
        public void InsertarCabeceraSL()
        {
            try
            {

                lbl_error.Text = "";
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

                lista = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi, suc_cliente.Text);

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
                ModeloActualizarEmail.sucursal = suc_cliente.Text;
                //Envio de datos para actualizar email en RP  
                ConsultaDatosTitular.ActualizarDatosTitulares(ModeloActualizarEmail);

                //Consultar si ya existe la cabecera con lbl_trans
                Boolean Cabecera = false;
                Cabecera = GuardarCabezera.ConsultaSNCabFactura(lbl_trans.Text, ComPwm, AmUsrLog);

                if (Cabecera == true) //Actulizar
                {
                    valor_asignado = lbl_trans.Text.Trim();
                    //----------------------------------ACTUALIZA CABECERA-------------------------//
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
                    cabecerafactura.usuario_mod = AmUsrLog;
                    cabecerafactura.ocompra = ocompra.Text;
                    cabecerafactura.cod_moneda = cmbCod_moneda.SelectedValue;
                    cabecerafactura.diar = "0";
                    cabecerafactura.mesr = "0";
                    cabecerafactura.anior = "0";
                    cabecerafactura.cod_sucursal = ModeloUsuSucursal.cod_sucursal;
                    cabecerafactura.nro_pedido = nro_pedido.Text;
                    cabecerafactura.nro_trans_padre = txt_nro_trans_padre.Text;
                    cabecerafactura.mot_nce = cbx_motivo_nc.SelectedValue;
                    cabecerafactura.cod_suc_cli = suc_cliente.Text;
                    error = GuardarCabezera.ActualizarCabeceraNC(cabecerafactura);
                    if (string.IsNullOrEmpty(error))
                    {

                    }
                    else
                    {
                        Session["cabecera"] = cabecerafactura;
                    }
                }
                else
                { //Insertar
                    //obtener numero de transaccion
                    valor_asignado = lbl_trans.Text.Trim();
                    //Guardar N° transaccion 
                    Session["valor_asignado"] = valor_asignado;
                    //------------------------INSERTAR CABCERA--------------------//
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
                    cabecerafactura.nro_trans = lbl_trans.Text;
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
                    cabecerafactura.tipo = Session["Ccf_tipo2"].ToString();//"NCME";
                    cabecerafactura.porc_descto = Convert.ToDecimal("0.00");
                    cabecerafactura.descuento = Convert.ToDecimal("0.00");
                    cabecerafactura.diar = "0";
                    cabecerafactura.mesr = "0";
                    cabecerafactura.anior = "0";
                    cabecerafactura.cod_proc_aud = "RCOMNCRED";
                    cabecerafactura.cod_sucursal = ModeloUsuSucursal.cod_sucursal;
                    cabecerafactura.nro_pedido = nro_pedido.Text;
                    cabecerafactura.nro_trans_padre = txt_nro_trans_padre.Text;
                    cabecerafactura.mot_nce = cbx_motivo_nc.SelectedValue;
                    cabecerafactura.cod_suc_cli = suc_cliente.Text;
                    error = GuardarCabezera.InsertarCabezeraNotaCredito(cabecerafactura);
                    if (string.IsNullOrEmpty(error))
                    {

                    }
                    else
                    {
                        Session["cabecera"] = cabecerafactura;
                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("InsertarCabeceraSL", ex.ToString());

            }
        }

        public void InsertarDetalleSL()
        {
            try
            {
                lbl_error.Text = "";

                articulo = null;
                articulo = BuscarProducto(txt_Codigo.Text);


                string linea_nueva = null; //ultimalinea
                                           //CONSULTAR Y VERIFICAR SI EXISTE O NO EL DETALLE
                                           //verificar si es insert, update
                if (txt_linea.Text == null || txt_linea.Text == "")
                {

                    linea_nueva = GuardarDetalles.UltimaLinea(lbl_trans.Text.Trim(), ComPwm, AmUsrLog);
                    if (linea_nueva == null)//Primera insercion
                    {
                        int linea_detalle = Convert.ToInt32(linea_nueva) + 1;
                        GuardarDetalles.InsertarDetalleNCSL(txt_cod_docum.Text, txt_nro_docum.Text, txt_serie_docum.Text, txt_Descripcion.Text, txt_Descripcion2.Text, Convert.ToDecimal(txt_Cantidad.Text), Convert.ToDecimal(txt_Precio.Text), Convert.ToDecimal(articulo.porc_aiu), Convert.ToDecimal(txt_Iva.Text), lbl_trans.Text.Trim(), linea_detalle, ComPwm, txt_Codigo.Text, articulo.cod_concepret, Convert.ToDecimal(txt_Desc.Text), 0, articulo.cod_cta_vtas,
                        articulo.cod_cta_cos, articulo.cod_cta_inve, AmUsrLog, "0", DateTime.Now, articulo.cod_tasa_impu, cod_costos.SelectedValue);
                    }
                    else
                    { //si ya existen registros
                        int linea_detalle = Convert.ToInt32(linea_nueva) + 1;
                        GuardarDetalles.InsertarDetalleNCSL(txt_cod_docum.Text, txt_nro_docum.Text, txt_serie_docum.Text, txt_Descripcion.Text, txt_Descripcion2.Text, Convert.ToDecimal(txt_Cantidad.Text), Convert.ToDecimal(txt_Precio.Text), Convert.ToDecimal(articulo.porc_aiu), Convert.ToDecimal(txt_Iva.Text), lbl_trans.Text.Trim(), linea_detalle, ComPwm, txt_Codigo.Text, articulo.cod_concepret, Convert.ToDecimal(txt_Desc.Text), 0, articulo.cod_cta_vtas,
                        articulo.cod_cta_cos, articulo.cod_cta_inve, AmUsrLog, "0", DateTime.Now, articulo.cod_tasa_impu, cod_costos.SelectedValue);

                    }
                }
                else
                {
                    //Actualizacion de producto
                    GuardarDetalles.ActualizarDetalleFacturaNCSL(txt_Descripcion2.Text, Convert.ToDecimal(txt_Cantidad.Text), Convert.ToDecimal(txt_Precio.Text), lbl_trans.Text.Trim(), Convert.ToInt32(txt_linea.Text), ComPwm, Convert.ToDecimal(txt_Desc.Text), AmUsrLog, cod_costos.SelectedValue);

                }
                txt_linea.Text = "";
                txt_Codigo.Text = "";
                txt_Descripcion.Text = "";
                txt_Descripcion2.Text = "";
                txt_Precio.Text = "0";
                txt_Iva.Text = "0";
                txt_Desc.Text = "0";
                txt_Cantidad.Text = "1";
            }
            catch (Exception ex)
            {
                GuardarExcepciones("InsertarDetalleSL", ex.ToString());
                //return null;
            }
        }
        protected void AgregarNC_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                lbl_validacion.Text = "";
                lbl_validacion.Visible = false;
                ValidarParametrosFactura();

                articulo = null;
                articulo = BuscarProducto(txt_Codigo.Text);
                if (Convert.ToDecimal(txt_Precio.Text) < 0)
                {
                    if (articulo.negativo == "S")
                    {

                        InsertarCabeceraSL(); //Calcula totales y agrega a grilla
                        InsertarDetalleSL();
                        BloquearCabeceraNC();
                        TraeDetalleFactura();

                    }
                    else
                    {
                        lbl_validacion.Text = "No se puede ingresar valores negativos";
                        lbl_validacion.Visible = true;
                    }
                }
                else
                {
                    InsertarCabeceraSL(); //Calcula totales y agrega a grilla
                    InsertarDetalleSL();
                    BloquearCabeceraNC();
                    TraeDetalleFactura();
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

                lista = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi, suc_cliente.Text);

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
                cabecerafactura.tipo = Session["Ccf_tipo2"].ToString();//"NCME";
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
                string Ccf_nro_trans = lbl_trans.Text;
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
                    mensaje.Text = "Nota de crédito no encontrada";
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

                /*Validar si el saldo de la factura */
                decimal valorSaldo = Convert.ToDecimal(txt_saldo_factura.Text);
                if (txtSumaTotal.Text == "")
                {
                    //cant* precio

                    txtSumaTotal.Text = Session["primer_item"].ToString();
                }
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
                else
                {
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
                            this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");

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

                lista = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi, suc_cliente.Text);

                cliente = null;
                foreach (modelowmspctitulares item in lista)
                {
                    cliente = item;
                    break;
                }
                if (Session["Ccf_tipo2"].ToString() == "NCM")
                {

                    ListaSaldoFacturas = consultaSaldoFactura.ConsultaFacturasVTASaldos(AmUsrLog, ComPwm, cliente.cod_tit, "C", "N");
                }

                else

                {

                    ListaSaldoFacturas = consultaSaldoFactura.BuscartaFacturaSaldos(AmUsrLog, ComPwm, cliente.cod_tit, "C", "N");
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
                        Session["Tipo"] = Session["Ccf_tipo2"].ToString();
                        this.Page.Response.Write("<script language='JavaScript'>window.open('./BuscarFacturasNCFin.aspx', 'Buscar Facturas', 'top=100,width=800 ,height=400, left=400');</script>");

                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_Fac_Click", ex.ToString());

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
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                Session.Remove("articulo");
                Session.Remove("ListaFacturas");
                Response.Redirect("BuscarNotaDebito.aspx");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Cancelar_Click", ex.ToString());

            }
        }
        public void FinalizarNotaDebito()
        {
            try
            {

                Confirmar.Visible = false;
                Confirmar.Enabled = false;


                string respuestaConfirmacionNC = "";
                //Boton Coonfirmar hace lo mismo que el salvar solo aumenta la insercion a la tabla wmt_facturas_ins
                InsertarCabeceraSL();
                conscabcera = null;
                conscabcera = BuscarCabecera();

                confirmarinsertar.nro_trans = conscabcera.nro_trans;
                confirmarinsertar.cod_emp = conscabcera.cod_emp;
                confirmarinsertar.usuario_mod = AmUsrLog;
                confirmarinsertar.fecha_mod = DateTime.Now;
                confirmarinsertar.nro_audit = conscabcera.nro_audit;

                respuestaConfirmacionNC = ConfirmarFactura.ConfirmarFactura(confirmarinsertar);
                //cOSNULTA BUSCAR TIPO DE FACTURA
                conscabceraTipo = null;
                conscabceraTipo = buscarTipoFac(conscabcera.nro_trans.Trim());
                if (conscabceraTipo.tipo_nce.Trim() == "NCME")
                {
                    if (respuestaConfirmacionNC == "")
                    {
                        //AVERIGUAR LA VERSION DE NC QUE USA
                        string respuesta = "";
                        if (Modelowmspclogo.version_fe == "2")
                        {
                            ConsumoRestNDFinV2 consumoRest = new ConsumoRestNDFinV2();
                            respuesta = consumoRest.EnviarNotaDebito(ComPwm, AmUsrLog, "C", "NC", conscabcera.nro_trans, txt_nro_trans_padre.Text);
                        }

                        if (respuesta == "")
                        {
                            mensaje.Text = "Su nota de débito fue procesada exitosamente";
                            Confirmar.Enabled = false;
                           // GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "F");
                            EnviarCorreoRemitente(conscabcera.nro_trans, conscabceraTipo.tipo_nce.Trim());
                            Session.Remove("listaFacturas");

                            Response.Redirect("BuscarNotaDebito.aspx");

                        }
                        else
                        {
                            GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "C");
                            mensaje.Text = respuesta;
                            Session.Remove("listaFacturas");
                            Response.Redirect("BuscarNotaDebito.aspx");

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
                    Response.Redirect("BuscarNotaDebito.aspx");
                }
            }

            catch (Exception ex)
            {
                GuardarExcepciones("FinalizarNotaDebito", ex.ToString());

            }
        }

        public void EnviarCorreoRemitente(string nro_trans, string tipo)
        {
            try
            {

                Ccf_tipo2 = tipo;
                Ccf_nro_trans = nro_trans;
                //Buscar el xml TRAE TODAS LAS RESPUESTAS
                ListaModelorespuestaDs = consultaRespuestaDS.ConsultaRespuestaQr(nro_trans);
                foreach (var item in ListaModelorespuestaDs)
                {
                    if (item.xml != "")
                    {
                        ModeloResQr = item;
                    }

                }
                Enviarcorreocliente enviarcorreocliente = new Enviarcorreocliente();
                string pathPdf = "";
                string StringXml = ModeloResQr.xml;
                string pathTemporal = Modelowmspclogo.pathtmpfac;
                string nombreXml = ModeloResQr.cufe.Trim() + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".xml";
                string pathXml = pathTemporal + nombreXml;
                File.WriteAllText(pathXml, StringXml);
                //-------------OBTENER EL XML Y PDF PARA EL ENVIO-------------------//
                if (Modelowmspclogo.pdf_nc.Trim() == "DEFECTO2")
                {

                    PdfNCEleV2Default2 pdf1 = new PdfNCEleV2Default2();
                    pathPdf = pdf1.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                }
                else
                {
                    PdfNotaCreditoElectronica pdf = new PdfNotaCreditoElectronica();
                    pathPdf = pdf.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans); ;

                }
                Boolean error = enviarcorreocliente.EnviarCorreoRemitente(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, pathPdf, pathXml);
            }
            catch (Exception ex)
            {
                GuardarExcepciones("EnviarCorreoRemitente", ex.ToString());

            }
        }
        protected void Confirmar_Click(object sender, EventArgs e)
        {
            try
            {


                lbl_error.Text = "";
                //Confirmar.Visible = false;
                //Consultar si el vendedor tiene asignada una sucursal

                ListaModeloUsuarioSucursal = ConsultaUsuxSuc.ConsultaUsuarioSucursal(ComPwm, AmUsrLog);
                int count = 0;
                foreach (var item in ListaModeloUsuarioSucursal)
                {
                    ModelousuarioSucursal = item;
                    count++;
                    break;
                }
                /*Validar  el saldo de la factura SI ES POSE/ VTAE*/
                decimal valorSaldo = Convert.ToDecimal(txt_saldo_factura.Text);
                decimal valorFactura = Convert.ToDecimal(txt_total_factura.Text);
                decimal valorTotal = Convert.ToDecimal(txtSumaTotal.Text); //TOTAL NOTA CREDITO
                                                                           //-----POSE O VTAE-------------

                if (count == 0)
                {
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Usuario no tiene asignada sucursal, por favor asignar para continuar con el proceso ')+ error;</script>");
                }
                else
                {

                    //Preguntar si existe detalle antes de confirmar
                    if (txtSumaTotal.Text == "")
                    {
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('No existen productos para la nota de débito')+ error;</script>");
                    }
                    else
                    {
                        if (txtSumaTotal.Text == "0.00")
                        {
                            this.Page.Response.Write("<script language='JavaScript'>window.alert('No existen productos para la nota de débito')+ error;</script>");
                        }
                        else
                        {
                            //No se puede hacer validaciones de totales
                            FinalizarNotaDebito();
                        }
                    }

                }//ultima validacion

            }
            catch (Exception ex)
            {
                GuardarExcepciones("Confirmar_Click", ex.ToString());

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

        protected void txt_Codigo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";

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
            catch (Exception ex)
            {
                GuardarExcepciones("txt_Codigo_TextChanged", ex.ToString());

            }
        }

        protected void area_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                Boolean Cabecera = false;
                Cabecera = GuardarCabezera.ConsultaSNCabFactura(lbl_trans.Text, ComPwm, AmUsrLog);
                //Insertar cabecera unicamente si existe 
                if (Cabecera == true)
                {
                    GuardarCabezera.ActualizarObserFactura(lbl_trans.Text, area.Text);
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("area_TextChanged", ex.ToString());

            }
        }
    }
}