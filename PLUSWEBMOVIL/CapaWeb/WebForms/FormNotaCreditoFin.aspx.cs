using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;
using CapaDatos.Modelos.ModelosNC;
using CapaProceso.GenerarPDF.FacturaElectronica;
using System.IO;
using CapaProceso.ReslClientePdf;
using CapaDatos.Sql;
using CapaProceso.FacturaMasiva;

namespace CapaWeb.WebForms
{
    public partial class FormNotaCreditoFin : System.Web.UI.Page
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
        List<modelowmspcresfact> listaRes1 = null;


        ConsultawmusuarioSucursal consultaUsuarioSucursal = new ConsultawmusuarioSucursal();
        modeloUsuariosucursal ModeloUsuSucursal = new modeloUsuariosucursal();
        List<modeloUsuariosucursal> ListaUsuSucursal = null;
        UsuarioSucursal BuscarSucursal = new UsuarioSucursal();

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();

        CabezeraFactura GuardarCabezera = new CabezeraFactura();
        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();
        List<modelowmtfacturascab> listaConsCab = null;
        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        modelocabecerafactura cabecerafactura = new modelocabecerafactura();

        Consultawmtfacturasdet ConsultaDeta = new Consultawmtfacturasdet();
        ModeloDetalleFactura consdetalle = new ModeloDetalleFactura();
        List<ModeloDetalleFactura> listaConsDetalle = null;
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
        modelowmtfacturascab conscabceraTipo = new modelowmtfacturascab();

        public List<JsonRespuestaDE> ListaModelorespuestaDs = null;
        public JsonRespuestaDE ModeloResQr = new JsonRespuestaDE();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();
        
        FacturaDescuento consultaDesc = new FacturaDescuento();
        List<ModeloDescCargoFac> ListaDesc = new List<ModeloDescCargoFac>();
        ModeloDescCargoFac modelodescuento = new ModeloDescCargoFac();

        GenerarPDFDocumentos generer_pdfElectronico = new GenerarPDFDocumentos();
        Enviarcorreocliente enviarcorreocliente = new Enviarcorreocliente();
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
        public string FP__cod_fpago = "";
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
                    Session.Remove("cod_Cliente");
                    Session.Remove("detalle");
                    Session.Remove("sumaBase19");
                    Session.Remove("sumaBase15");
                    Session.Remove("sumaIva19");
                    Session.Remove("sumaIva15");
                    Session.Remove("Tipo");
                    Session.Remove("Ccf_tipo2_NCA");

                    QueryString qs = ulrDesencriptada();

                    //Recibir opciones
                    switch (qs["TRN"].Substring(0, 3))
                    {
                        case "AFA":
                            try
                            {
                                //TRX
                                lbl_trans.Text = ConsultaNroTran.NroTrans(numerador);
                                cargarListaDesplegables();
                                Session.Remove("listaCliente");
                                Session.Remove("listaFacturas");
                                Session.Remove("valor_asignado");
                                SetearCampos();
                                DesbloquearFactura();
                                Session["Tipo"] = "Anular";
                                ConsultarTasaCambioCanorus();
                                break;
                            }
                            catch (Exception ex)
                            {
                                GuardarExcepciones("Page_Load, AFA", ex.ToString());
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
                    dniCliente.Text = cliente.nro_dgi2.Trim();
                    fonoCliente.Text = cliente.tel_tit;
                    txtcorreo.Text = cliente.email_tit;
                    suc_cliente.Text = cliente.cod_sucursal;
                    sucursal_lbl.Text = cliente.codnom_suc;
                    txt_cod_socio.Text = cliente.cod_tit.Trim();
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
                    //Consultamos cuantos descimales se van a usar redondeo
                    DecimalesMoneda = null;
                    DecimalesMoneda = BuscarDecimales();
                    //Agregarbcampos de factura para NC
                    txt_nro_factura.Text = conscabcera.observacion;
                    txt_cod_docum.Text = conscabcera.cod_docum;
                    txt_serie_docum.Text = conscabcera.serie_docum;
                    txt_nro_docum.Text = conscabcera.nro_docum;
                    txt_nro_trans_padre.Text = conscabcera.nro_trans;
                    //Formato totales
                    decimal SubTotal = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.subtotal);
                    txtSumaSubTo.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), SubTotal);
                    txt_subtotal_factura.Text = txtSumaSubTo.Text;
                    decimal Total = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.total);
                    txtSumaTotal.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), Total);
                    txt_total_factura.Text = txtSumaTotal.Text;
                    decimal SumIva = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.iva);
                    txtSumaIva.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), SumIva);
                    txt_iva_factura.Text = txtSumaIva.Text;
                    decimal SumDesc = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.descuento);
                    txtSumaDesc.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), SumDesc);
                    txt_descuento_factura.Text = txtSumaDesc.Text;
                    decimal BaseIva19 = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.monto_imponible);
                    txtBaseIva19.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), BaseIva19);

                    Session["sumaSubtotal"] = Convert.ToString(conscabcera.subtotal);
                    Session["sumaDescuento"] = Convert.ToString(conscabcera.descuento);
                    Session["sumaIva"] = Convert.ToString(conscabcera.iva);
                    Session["sumaTotal"] = Convert.ToString(conscabcera.total);
                    BuscarTotales(txt_nro_trans_padre.Text);
                    BloquearDatosFactura();

                    lbl_trx.Text = null;
                    lbl_trx.Visible = false;

                    //Carga detalle factura
                    string nro_trans = conscabcera.nro_trans;

                    listaConsDetalle = ConsultaDeta.ConsultaDetalleFacura(nro_trans);
                    Session["detalle"] = listaConsDetalle;

                    gv_Producto.DataSource = listaConsDetalle;
                    gv_Producto.DataBind();
                    gv_Producto.Height = 100;
                    if (Session["Tipo"] != null)
                    {
                        BloquearFactura();
                    }
                }


                ConsultarTasaCambioCanorus();
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());
            }


        }
        protected void BuscarTotales(string nro_docum)
        {
            try
            {
                decimal cargo = 0;
                decimal descuento = 0;
                ListaDesc = consultaDesc.ConsultaDescCargTrans(ComPwm, AmUsrLog, nro_docum);
                if (ListaDesc.Count > 0)
                {
                    gv_descuentos.DataSource = ListaDesc;
                    gv_descuentos.DataBind();
                    gv_descuentos.Height = 100;
                    foreach (ModeloDescCargoFac item in ListaDesc)
                    {
                        if (item.signo.Trim() == "D")
                        {
                            descuento += item.total;

                        }
                        if (item.signo.Trim() == "C")
                        {
                            cargo += item.total;
                        }

                    }
                    txt_cargos.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), cargo);
                    txt_descuento_apli.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), descuento);
                }
            }

            catch (Exception ex)
            {
                GuardarExcepciones("BuscarTotales", ex.ToString());

            }
        }
        public void GuardarExcepciones(string metodo, string error)
        {
          
            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "FormNotaCreditoFin.aspx";
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

        protected void DesbloquearFactura()
        {
            //inhabilitar cajas de texto cabecera factura
            dniCliente.Enabled = true;
            nombreCliente.Enabled = true;
            fonoCliente.Enabled = true;
            txtcorreo.Enabled = true;
           // fecha.Enabled = true;
            cod_fpago.Enabled = true;
            nro_pedido.Enabled = true;
            cod_costos.Enabled = true;
            serie_docum.Enabled = true;
            ocompra.Enabled = true;
            //area.Enabled = true;

            porc_descto.Enabled = true;
            cmbCod_moneda.Enabled = true;
            cod_vendedor.Enabled = true;
            txtSumaSubTo.Enabled = true;
            txtSumaTotal.Enabled = true;
            txtSumaIva.Enabled = true;
            txtSumaDesc.Enabled = true;
            gv_Producto.Enabled = true;
            txtBaseIva19.Enabled = true;
            txt_cargos.Enabled = true;
            txt_descuento_apli.Enabled = true;
            //botones
            AgregarNC.Enabled = true;
            Confirmar.Visible = true;
            btnGuardarDetalle.Visible = false;
            btn_Fac.Enabled = true;
            btn_desc.Enabled = true;
            //detalle producto
            txt_Codigo.Enabled = true;
            txt_Cantidad.Enabled = true;
            txt_Descripcion.Enabled = true;
            txt_Precio.Enabled = true;
            txt_Desc.Enabled = true;
            txt_Iva.Enabled = true;
        }
        //Buscar cantidad de decimales q se va ausar x tipo de moneda
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
        protected void BloquearDatosFactura()
        {
            //Visible Datos Factura
            lbl_trx_fac.Visible = true;
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
            //area.Enabled = false;
            
            porc_descto.Enabled = false;
            cmbCod_moneda.Enabled = false;
            cod_vendedor.Enabled = false;
            txtSumaSubTo.Enabled = false;
            txtSumaTotal.Enabled = false;
            txtSumaIva.Enabled = false;
            txtSumaDesc.Enabled = false;
            gv_Producto.Enabled = false;
            txt_cargos.Enabled = false;
            txtBaseIva19.Enabled = false;
            txt_descuento_apli.Enabled = false;
            //botones
            AgregarNC.Enabled = false;
            Confirmar.Visible = true;
            btnGuardarDetalle.Visible = false;
            btn_Fac.Enabled = false;
            btn_desc.Enabled = true;
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
            txt_descuento_apli.Enabled = false;
            txtBaseIva19.Enabled = false;
            txt_cargos.Enabled = false;
            //botones
            AgregarNC.Enabled = false;
            Confirmar.Visible = false;
            //btnImpuestos.Enabled = false;
            btnGuardarDetalle.Visible = false;
            btn_Fac.Enabled = false;
            btn_desc.Enabled = false;
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
                        txt_cod_socio.Text= "";
                       

                    }
                    else
                    {

                        Session.Remove("cliente");

                        nombreCliente.Text = cliente.nom_tit;
                        fonoCliente.Text = cliente.tel_tit;
                        dniCliente.Text = cliente.nro_dgi2.Trim();
                        txtcorreo.Text = cliente.email_tit;
                        suc_cliente.Text = cliente.cod_sucursal;
                        sucursal_lbl.Text = cliente.codnom_suc;
                        txt_cod_socio.Text = cliente.cod_tit.Trim();
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
               
                DateTime hoy = Convert.ToDateTime(fecha.Text);
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
                            txtSumaTotal.Text = String.Format("{0:N}", sumaTotal.ToString());
                            //base iva 19 totales

                            if (Session["sumaBase19"] != null)
                            {
                                sumaBase19 = Convert.ToDecimal(Session["sumaBase19"]);
                            }
                            if (Math.Round(detalle.porc_iva, 0).ToString() == "19")
                            {
                                sumaBase19 -= detalle.subtotal;
                                Session["sumaBase19"] = sumaBase19.ToString();
                                txtBaseIva19.Text = String.Format("{0:N}", sumaBase19).ToString();
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
                            
                            }
                            //Eliminar Subtotal
                            if (Session["sumaSubtotal"] != null)
                            {
                                sumaSubtotal = Convert.ToDecimal(Session["sumaSubtotal"]);
                            }

                            sumaSubtotal -= Convert.ToDecimal(detalle.subtotal);
                            Session["sumaSubtotal"] = sumaSubtotal.ToString();
                            txtSumaSubTo.Text = String.Format("{0:N}", sumaSubtotal.ToString());

                            //Eliminar Descuento
                            if (Session["sumaDescuento"] != null)
                            {
                                sumaDescuento = Convert.ToDecimal(Session["sumaDescuento"]);
                            }
                            sumaDescuento -= Convert.ToDecimal(detalle.detadescuento);
                            Session["sumaDescuento"] = sumaDescuento.ToString();
                            txtSumaDesc.Text = String.Format("{0:N}", sumaDescuento.ToString());
                            //Eliminar Iva
                            if (Session["sumaIva"] != null)
                            {
                                sumaIva = Convert.ToDecimal(Session["sumaIva"]);
                            }
                            sumaIva -= Convert.ToDecimal(detalle.detaiva);
                            Session["sumaIva"] = sumaIva.ToString();
                            txtSumaIva.Text = String.Format("{0:N}", sumaIva.ToString());
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
                //LIsta Resolucion facturas por sucursal
                listaRes = ConsultaResolucion.ConsultaResolusionXSucursalNC(AmUsrLog, ComPwm, ResF_estado, ResF_serie, ResF_tipo, "0");
                serie_docum.DataSource = listaRes;
                serie_docum.DataTextField = "serie_docum";
                serie_docum.DataValueField = "serie_docum";
                serie_docum.DataBind();
                if (listaRes.Count > 1)
                {
                    serie_docum.Items.Insert(0, new ListItem("Seleccione...", "serie"));
                    serie_docum.SelectedIndex = 0;
                    fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                }
                else
                {
                    resolucion = null;
                    foreach (modelowmspcresfact item in listaRes)
                    {
                        resolucion = item;
                    }
                    //Aqui se va a traer que tipo de facturacion es
                    if (resolucion.tipo_fac == "S")
                    {
                        Session["Ccf_tipo2_NCA"] = "NCVE";
                        lbl_tiponc.Text = "NCVE";
                        fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                        lbl_cod_suc_emp.Text = resolucion.cod_sucursal.Trim();
                        lbl_suc_emp.Text = "-" + resolucion.nom_sucursal.Trim();
                    }
                    else
                    {
                        Session["Ccf_tipo2_NCA"] = "NCV";
                        lbl_tiponc.Text = "NCV";
                        fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                        lbl_cod_suc_emp.Text = resolucion.cod_sucursal.Trim();
                        lbl_suc_emp.Text = "-" + resolucion.nom_sucursal.Trim();
                    }
                }
       

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
        //validar parametrizacion de nc para poder 
        public void ValidarParametrosNC()
        {
            try
            {
                lbl_error.Text = "";
                Confirmar.Enabled = true;
                string perido_contable = "";
                perido_contable = consultaValidarFactura.ConsultaValidarPeriodoContable(ComPwm, AmUsrLog, fecha.Text);
                if (perido_contable == "")
                {
                    lbl_validacion.Text = "El Periodo Contable correspondiente a la fecha del documento se encuentra cerrado o no existe. Por favor registrar Periodo Contable y actualizar la página";
                    lbl_validacion.Visible = true;
                    Confirmar.Enabled = false;
                }
                else
                {
                    Boolean empresa = false;
                    empresa = consultaValidarFactura.ConsultaValidarMonCiudEmpresaERP(ComPwm, AmUsrLog);
                    if (empresa == false)
                    {
                        lbl_validacion.Text = " No existe moneda o ciudad de la empresa registrado para la nota de crédito. Por favor registrar información y actualizar la página";
                        lbl_validacion.Visible = true;
                        Confirmar.Enabled = false;
                    }
                    else
                    {
                        Boolean resolucion = false;
                        resolucion = consultaValidarFactura.ConsultaValidarResolucionERP(ComPwm, AmUsrLog, "V", serie_docum.SelectedValue.Trim(), fecha.Text, Modelowmspclogo.cod_emp_erp.Trim());
                        if (resolucion == false)
                        {
                            lbl_validacion.Text = " No existe resolución de la nota de crédito. Por favor registrar información y actualizar la página";
                            lbl_validacion.Visible = true;
                            Confirmar.Enabled = false;
                        }
                        else {
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
            try
            {
                lbl_error.Text = "";
                //llenar formulario para la actualizacion de datos

                string Ccf_nro_trans = lbl_trans.Text;
                conscabceraTipo = Trans_Padre(Ccf_nro_trans);
                Session["Ccf_tipo2_NCA"] = conscabceraTipo.tipo_nce.Trim();
                lbl_tiponc.Text = conscabceraTipo.tipo_nce.Trim();
                listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Session["Ccf_tipo2_NCA"].ToString(), Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
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
                //Consultamos cuantos descimales se van a usar redondeo
                DecimalesMoneda = null;
                DecimalesMoneda = BuscarDecimales();
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


                Session["sumaSubtotal"] = Convert.ToString(conscabcera.subtotal);
                Session["sumaDescuento"] = Convert.ToString(conscabcera.descuento);
                Session["sumaIva"] = Convert.ToString(conscabcera.iva);
                Session["sumaTotal"] = Convert.ToString(conscabcera.total);
                
                CargarCamposFactura(conscabceraTipo.nro_trans_padre);
                BuscarTotales(lbl_trans.Text);
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
           // lbl_tipo_fac.Text = conscabceraTipo.tipo_nce;
            //Formato totales

            txt_subtotal_factura.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, conscabcera.subtotal);
            txt_total_factura.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, conscabcera.total);
            txt_iva_factura.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, conscabcera.iva);
            txt_descuento_factura.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, conscabcera.descuento);
            BloquearDatosFactura();
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
        protected void AgregarNC_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
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
                    ModeloDetalleFactura item = new ModeloDetalleFactura();

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


                    item.cod_articulo = txt_Codigo.Text;
                    item.nom_articulo = txt_Descripcion.Text;
                    item.nom_articulo2 = txt_Descripcion.Text;
                    item.cod_ccostos = cod_costos.SelectedValue;
                    item.cantidad = Convert.ToDecimal(txt_Cantidad.Text);
                    item.precio_unit = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo_pu, Convert.ToDecimal(txt_Precio.Text));
                    item.porc_iva = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(txt_Iva.Text));
                    item.porc_descto = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(txt_Desc.Text));
                    item.subtotal = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(item.precio_unit * item.cantidad));
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
                txt_Cantidad.Text = "1";
                txt_Precio.Text = "0";
                txt_Iva.Text = "0";
                txt_Desc.Text = "0";
                txt_Descripcion.Text = "";

                GuardarDetalle();
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
              
                DateTime Fecha = Convert.ToDateTime(fecha.Text);
                 //obtener cliente
                string error = "";
                string Ven__cod_tit = dniCliente.Text;

                lista = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi,suc_cliente.Text);
                cliente = null;
                if (lista.Count>1)
                {
                    foreach (modelowmspctitulares item in lista)
                    {
                        if (item.cod_tit.Trim() == txt_cod_socio.Text.Trim())
                        {
                            cliente = item;
                            break;
                        }
                    }
                }
                else {
                    foreach (modelowmspctitulares item in lista)
                    {
                            cliente = item;
                            break;
                    }
                }

                //Procedimiento para actualizar email del titular
                ModeloActualizarEmail.usuario = AmUsrLog;
                ModeloActualizarEmail.empresa = ComPwm;
                ModeloActualizarEmail.cod_tit = cliente.cod_tit.Trim();
                ModeloActualizarEmail.parametro = "email";
                ModeloActualizarEmail.valor = txtcorreo.Text;
                ModeloActualizarEmail.sucursal = suc_cliente.Text;
                ConsultaDatosTitular.ActualizarDatosTitulares(ModeloActualizarEmail); //Envio de datos para actualizar email en RP
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
                    cabecerafactura.cod_sucursal = lbl_cod_suc_emp.Text.Trim();
                    cabecerafactura.nro_pedido = nro_pedido.Text;
                    cabecerafactura.nro_trans_padre = txt_nro_trans_padre.Text;
                    cabecerafactura.mot_nce = "2";
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
                {
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
                    cabecerafactura.tipo = Session["Ccf_tipo2_NCA"].ToString();// "NCVE";
                    cabecerafactura.porc_descto = Convert.ToDecimal("0.00");
                    cabecerafactura.descuento = Convert.ToDecimal("0.00");
                    cabecerafactura.diar = "0";
                    cabecerafactura.mesr = "0";
                    cabecerafactura.anior = "0";
                    cabecerafactura.cod_proc_aud = "RCOMNCRED";
                    cabecerafactura.cod_sucursal = lbl_cod_suc_emp.Text.Trim();
                    cabecerafactura.nro_pedido = nro_pedido.Text;
                    cabecerafactura.nro_trans_padre = txt_nro_trans_padre.Text;
                    cabecerafactura.mot_nce = "2"; //Motivo DS  1 por anulación
                    cabecerafactura.cod_suc_cli = suc_cliente.Text;
                    cabecerafactura.desctos_rcgos = 0; //Enviar siempre 0 al insetar
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
                listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Session["Ccf_tipo2_NCA"].ToString(), Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
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
                        detallefactura.nro_trans = lbl_trans.Text;
                        detallefactura.linea = contarLinea;
                        detallefactura.cod_emp = ComPwm;
                        detallefactura.cod_articulo = item.cod_articulo;
                        detallefactura.cod_articulo2 = item.cod_articulo2;
                        detallefactura.cod_concepret = item.cod_concepret;
                        detallefactura.porc_descto = item.porc_descto;
                        detallefactura.valor_descto = item.detadescuento;
                        detallefactura.cod_cta_vtas = item.cod_cta_vtas;
                        detallefactura.cod_cta_cos = item.cod_cta_cos;
                        detallefactura.cod_cta_inve = item.cod_cta_inve;
                        detallefactura.usuario_mod = AmUsrLog;
                        detallefactura.nro_audit = conscabcera.nro_audit;
                        detallefactura.fecha_mod = DateTime.Now;
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
                //INSERTAR DESCUENTOS Y CARGOS GLOBALES DE LA FACTURA
                InsertarCDscGlobales();
                return conscabcera;
                
            }
            catch (Exception ex)
            {
                GuardarExcepciones("GuardarDetalle", ex.ToString());
                return null;
            }
        }

        public void InsertarCDscGlobales()
        {
            try
            {
  
                //INSERTAR DESCUENTOS Y CARGOS GLOBALES DE LA FACTURA
                ListaDesc = null;
                ListaDesc = consultaDesc.ConsultaDescCargTrans(ComPwm, AmUsrLog, txt_nro_trans_padre.Text);
                if (ListaDesc.Count > 0)
                {
                    ModeloDescCargoFac modeloDesCargo = new ModeloDescCargoFac();
                    ModeloDescCargoFac modeloCarDscG = new ModeloDescCargoFac();
                    foreach (var desc in ListaDesc)
                    {
                        modeloCarDscG = desc;
                        modeloDesCargo.nro_trans = lbl_trans.Text;
                        modeloDesCargo.linea = modeloCarDscG.linea.ToString();
                        modeloDesCargo.cod_emp = ComPwm;
                        modeloDesCargo.cod_concepto = modeloCarDscG.cod_concepto;
                        modeloDesCargo.nom_concepto = modeloCarDscG.nom_concepto;
                        modeloDesCargo.signo = modeloCarDscG.signo;
                        modeloDesCargo.porc_descto = modeloCarDscG.porc_descto;
                        modeloDesCargo.valor_descto =modeloCarDscG.valor_descto;
                        modeloDesCargo.monto_imponible = modeloCarDscG.monto_imponible;
                        modeloDesCargo.total = modeloCarDscG.total;
                        modeloDesCargo.cod_ccostos = modeloCarDscG.cod_ccostos;
                        modeloDesCargo.cod_cta = modeloCarDscG.cod_cta;
                        modeloDesCargo.usuario_mod = AmUsrLog;
                        modeloDesCargo.fecha_mod = DateTime.Now.ToString();
                        consultaDesc.InsertarDescCargTrans(modeloDesCargo);
                    }
                }

            }
            catch (Exception ex)
            {
                GuardarExcepciones("InsertarCDscGlobales", ex.ToString());

            }
        }


        protected void btn_Fac_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                /* SP wmspc_facturasWM_saldo TRAE SOLO FACTURAS CON SALDO DIFERENTE DE 0*/
                string Ven__cod_tit = dniCliente.Text;

                lista = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi,suc_cliente.Text);

                cliente = null;
                foreach (modelowmspctitulares item in lista)
                {
                    cliente = item;
                    break;
                }
                //vERIFICAR TIPO NCVE O NCV
                string tipo = Session["Ccf_tipo2_NCA"].ToString();

                if (Session["listaFacturas"] == null)
                {
                    Session["listaClienteFac"] = ListaSaldoFacturas;
                    Session["TipoFactura"] = tipo;
                    Session["Sucursal"] = lbl_cod_suc_emp.Text.Trim();
                    Session["cod_Cliente"] = cliente.cod_tit.Trim();
                    this.Page.Response.Write("<script language='JavaScript'>window.open('./BuscaFacturasNCAn.aspx', 'Buscar Facturas', 'top=100,width=800 ,height=400, left=400');</script>");

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


                Session.Remove("ListaFacturas");

                Response.Redirect("FormBuscarNotaCredito.aspx");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Cancelar_Click", ex.ToString());

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

                string StringXml = ModeloResQr.xml;
                string pathTemporal = Modelowmspclogo.pathtmpfac;
                string nombreXml = ModeloResQr.cufe.Trim() + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".xml";
                string pathXml = pathTemporal + nombreXml;
                File.WriteAllText(pathXml, StringXml);
                //-------------OBTENER EL XML Y PDF PARA EL ENVIO-------------------//
                string cod_proceso = "RCOMNCELEC";
                string pathPdf = generer_pdfElectronico.GenerarPDFNotaCreditoElectronica(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
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
                int contador = 0;
                contador++;
                lbl_error.Text = "";
                lbl_validacion.Text = "";
                lbl_validacion.Visible = false;
                bool fec_valida = ValidarFecha();

                if (fec_valida == true)
                {
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Colocar fecha dentro del rango permitido, para poder emitir nota de crédito ')+ error;</script>");
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
                        if (Convert.ToDecimal(txtSumaTotal.Text) == 0)
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
                                ValidarParametrosNC();
                                
                                Confirmar.Enabled = false;
                                string respuestaConfirmacionNC = "";
                                //Boton Coonfirmar hace lo mismo que el salvar solo aumenta la insercion a la tabla wmt_facturas_ins
                                conscabcera = null;
                                if(lbl_tiponc.Text == "NCVE")
                                {
                                    if(txtcorreo.Text ==null || txtcorreo.Text =="")
                                    {
                                        lbl_validacion.Text = "Ingrese correo por favor";
                                        lbl_validacion.Visible = true;
                                    }
                                    else
                                    {
                                        conscabcera = GuardarDetalle();
                                    }
                                }
                                else
                                {
                                    conscabcera = GuardarDetalle();
                                }
                                

                                confirmarinsertar.nro_trans = conscabcera.nro_trans;
                                confirmarinsertar.cod_emp = conscabcera.cod_emp;
                                confirmarinsertar.usuario_mod = AmUsrLog;
                                confirmarinsertar.fecha_mod = DateTime.Now;
                                confirmarinsertar.nro_audit = conscabcera.nro_audit;
                                respuestaConfirmacionNC = ConfirmarFactura.ConfirmarFactura(confirmarinsertar);
                                // respuestaConfirmacionNC = ConfirmarFactura.ConfirmarFactura(confirmarinsertar);
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
                                            ConsumoRestNCFinV2 consumoRest = new ConsumoRestNCFinV2();
                                            respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", "NC", conscabcera.nro_trans, txt_nro_trans_padre.Text);
                                        }
                                        else
                                        {
                                            ConsumoRestNCFinV3 consumoRest = new ConsumoRestNCFinV3();
                                            respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", "NC", conscabcera.nro_trans, txt_nro_trans_padre.Text);
                                        }
                                   
       
                                    if (respuesta == "")
                                    {
                                        mensaje.Text = "Su nota de crédito fue procesada exitosamente";
                                        Confirmar.Enabled = false;
                                        GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "F");//Actualiza NC a Finalizado
                                        GuardarCabezera.ActualizarEstadoFactura(txt_nro_trans_padre.Text, "N");//Actualiza factura a Anulada
                                        EnviarCorreoRemitente(conscabcera.nro_trans, conscabceraTipo.tipo_nce.Trim()); //Enviar correo a remitente
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
                                    if (respuestaConfirmacionNC == "")
                                    {
                                        GuardarCabezera.ActualizarEstadoFactura(txt_nro_trans_padre.Text, "N");//Actualiza factura a Anulada
                                        EnviarCorreoCliente(conscabcera.nro_trans, conscabceraTipo.tipo_nce.Trim());
                                        Session.Remove("listaFacturas");
                                        Response.Redirect("FormBuscarNotaCredito.aspx");
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
            catch (Exception ex)
            {
                GuardarExcepciones("Confirmar_Click", ex.ToString());

            }
        }

        public void EnviarCorreoCliente(string nro_trans, string tipo)
        {
            try
            {

                Ccf_tipo2 = tipo;
                Ccf_nro_trans = nro_trans;
                string pathXml = "";
                cod_proceso = "RCOMNCELEC";
                string pathPdf = generer_pdfElectronico.GenerarPDFNotaCreditoNormal(ComPwm, cod_proceso, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                Boolean error = enviarcorreocliente.EnviarCorreoCliente(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, pathPdf, pathXml);
            }
            catch (Exception ex)
            {
                GuardarExcepciones("EnviarCorreoCliente", ex.ToString());

            }
        }
        protected void btn_desc_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                Session.Remove("Tipo");
                Session.Remove("desc_carg");
                Session["Tipo"] = "VER";
                Session["valor_asignado1"] = txt_nro_trans_padre.Text;
                this.Page.Response.Write("<script language='JavaScript'>window.open('./DescuentosCargosFac.aspx', 'Descuentos y Cargos', 'top=100,width=900 ,height=500, left=500');</script>");

            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_desc_Click", ex.ToString());

            }
        }
        protected void btnImpuestos_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                if (Session["valor_asignado"] != null)
                {
                    //Despues de confirmar puede usar el valor asignado
                    string transa = Session["valor_asignado"].ToString();
                    ListaModeloimpuesto = consultaImpuesto.BuscarImpuestoRest(AmUsrLog, ComPwm, transa, "0");
                    Session["listaImpuestos"] = ListaModeloimpuesto;
                    this.Page.Response.Write("<script language='JavaScript'>window.open('./FormDetalleImpuestos.aspx', 'Detalle Impuesto', 'top=100,width=800 ,height=400, left=400');</script>");
                }
                else
                {
                    //Si no confirma toma los datos de la factura para consultar los impuestos
                    string transa = txt_nro_trans_padre.Text;
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

        public Boolean ValidarFecha()
        {
            try
            {
                lbl_validacion.Text = "";
                lbl_validacion.Visible = false;
                bool fecha_validar = false;
                DateTime Fecha_seleccion = Convert.ToDateTime(fecha.Text);
                if (Session["Ccf_tipo2_NCA"].ToString() == "NCVE")
                {

                    DateTime Fecha_actual = DateTime.Today;
                    DateTime Fecha_minima = DateTime.Today.AddDays(-5);
                    int Actual = DateTime.Today.Day;
                    if (Fecha_seleccion < Fecha_minima)
                    {
                        lbl_validacion.Text = "La fecha de la nota de crédito no puede ser menor a cinco días de la fecha actual";
                        lbl_validacion.Visible = true;
                        fecha_validar = true;
                    }
                    if (Fecha_seleccion > Fecha_actual)
                    {

                        lbl_validacion.Text = "La fecha de la nota de crédito no puede ser mayor a  la fecha actual";
                        lbl_validacion.Visible = true;
                        fecha_validar = true;
                    }
                }
                return fecha_validar;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("ValidarFecha", ex.ToString());
                return true;
            }
        }



        protected void fecha_TextChanged(object sender, EventArgs e)
        {
            try
            {

                bool fec_valida = ValidarFecha();

                if (fec_valida == true)
                {
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Colocar fecha dentro del rango permitido, para poder emitir nota de crédito ')+ error;</script>");
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("fecha_TextChanged", ex.ToString());

            }

        }

        protected void serie_docum_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mensaje.Text = "";
                if (serie_docum.SelectedValue.Trim() == "serie")
                {
                    mensaje.Text = "Seleccione una Serie Documento para continuar";
                    Session.Remove("Ccf_tipo2_NCA");
                    lbl_tiponc.Text = "";
                }
                else
                {
                    //Buscar los datos cuando selecciona un prefijo
                    listaRes1 = null;
                    listaRes1 = ConsultaResolucion.ConsultaResolusiones(AmUsrLog, ComPwm, ResF_estado, serie_docum.SelectedValue.Trim(), ResF_tipo);
                    resolucion = null;
                    foreach (modelowmspcresfact item in listaRes1)
                    {
                        resolucion = item;

                    }
                    if (resolucion.tipo_fac == "S")
                    {
                        Session["Ccf_tipo2_NCA"] = "NCVE";
                        lbl_tiponc.Text = "NCVE";
                    }
                    else
                    {
                        Session["Ccf_tipo2_NCA"] = "NCV";
                        lbl_tiponc.Text = "NCV";
                    }
                }
            }

            catch (Exception ex)
            {
                GuardarExcepciones("serie_docum_SelectedIndexChanged", ex.ToString());

            }
        }
    }
}