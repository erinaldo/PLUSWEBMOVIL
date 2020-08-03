using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;
using CapaProceso.GenerarPDF.FacturaElectronica;
using System.IO;
using CapaProceso.ReslClientePdf;
using CapaDatos.Sql;

namespace CapaWeb.WebForms
{
    public partial class FormFacturaPostElec : System.Web.UI.Page
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

        ConsultaDetalleProforma ConsultaDetallePro = new ConsultaDetalleProforma();
        modeloDetalleProforma ModeloDetallePro = new modeloDetalleProforma();
        List<modeloDetalleProforma> ListaDetaProforma = null;

        ConsultaDetalleRemision ConsultaDetalleRemision = new ConsultaDetalleRemision();
        modeloDetalleRemision ModeloDetalleRemision = new modeloDetalleRemision();
        List<modeloDetalleRemision> ListaDetalleRemision = null;

        ConsultaProformasFac ConsultaProformas = new ConsultaProformasFac();
        modelowmtproformascab ModeloProformas = new modelowmtproformascab();
        List<modelowmtproformascab> ListaProofrmas = null;
        ConsultaProformaIns InsertarProIns = new ConsultaProformaIns();

        ConsultaRemisionesFac ConsultaRemisiones = new ConsultaRemisionesFac();
        modeloRemisionesFactura ModeloRemision = new modeloRemisionesFactura();
        List<modeloRemisionesFactura> ListaRemision = null;
        ConsultaRemisionIns InsertarRemiIns = new ConsultaRemisionIns();

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
        List<ModeloDetalleFactura> listaConsDetalle = null;
        List<ModeloDetalleFactura> ModeloDetalleFactura = new List<ModeloDetalleFactura>();
        ModeloDetalleFactura detallefactura = new ModeloDetalleFactura();
        DetalleFactura GuardarDetalles = new DetalleFactura();

        public List<JsonRespuestaDE> ListaModelorespuestaDs = null;
        public JsonRespuestaDE ModeloResQr = new JsonRespuestaDE();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();

        modeloinsertarconfirmar confirmarinsertar = new modeloinsertarconfirmar();
        Consultaconfirmarfactura ConfirmarFactura = new Consultaconfirmarfactura();
        List<modeloinsertarconfirmar> modeloinsertarconfirmar = new List<modeloinsertarconfirmar>();

        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        public List<modelowmspctctrxCotizacion> ListaModelocotizacion = new List<modelowmspctctrxCotizacion>();
        public modelowmspctctrxCotizacion ModeloCotizacion = new modelowmspctctrxCotizacion();
        public ConsultawmspctctrxCotizacion consultaMoneda = new ConsultawmspctctrxCotizacion();

        public List<modeloUsuariosucursal> ListaModeloUsuarioSucursal = new List<modeloUsuariosucursal>();
        public ConsultawmusuarioSucursal ConsultaUsuxSuc = new ConsultawmusuarioSucursal();
        public modeloUsuariosucursal ModelousuarioSucursal = new modeloUsuariosucursal();

        public modeloActualizarDatosTitular ModeloActualizarEmail = new modeloActualizarDatosTitular();
        public ConsultaActualizarTitular ConsultaDatosTitular = new ConsultaActualizarTitular();

        ModeloDiferenciaPagos modeloDiferencia = new ModeloDiferenciaPagos(); //Trae los saldos
        public List<ModeloDiferenciaPagos> listaSaldos = null;
        ConsultaMediosPago consultaMediosPago = new ConsultaMediosPago();

        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();

        modelowmtfacturascab conscabceraTipo = new modelowmtfacturascab();
        ConsultaValidarParametrosFactura consultaValidarFactura = new ConsultaValidarParametrosFactura();
        FacturaDescuento consultaDesc = new FacturaDescuento();
        List<ModeloDescCargoFac> ListaDesc = new List<ModeloDescCargoFac>();
        ModeloDescCargoFac modelodescuento = new ModeloDescCargoFac();

        public string ComPwm;
        public string AmUsrLog;
        public string valor_asignado = null;
        public string Ven__cod_tipotit = "clientes";
        public string Ven__cod_dgi = "0";
        public string Ven__fono = "0";
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
        public string Ccf_tipo2 = "POSE";
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
        public string tipo_tran = null;
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
                if (Session["desc_carg"] != null)
                {
                    BuscarDecimales();
                    TraeDetalleFactura();
                    
                }

                ConsultarTasaCambioCanorus();

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
                    Session.Remove("sumaBase19");
                    Session.Remove("sumaBase15");
                    Session.Remove("sumaIva19");
                    Session.Remove("sumaIva15");
                    Session.Remove("Tipo");
                    Session.Remove("valor_asignado1");
                    Session.Remove("Ccf_tipo2");
                    DecimalesMoneda = null;
                    DecimalesMoneda = BuscarDecimales();

                    QueryString qs = ulrDesencriptada();

                    //Recibir opciones
                    switch (qs["TRN"].Substring(0, 3))
                    {

                        case "INS":
                            try
                            {
                                //TRX
                                lbl_trans.Text = ConsultaNroTran.NroTrans(numerador);
                                cargarListaDesplegables();
                                tipo_tran = "INS";
                                Session.Remove("listaCliente");
                                Session.Remove("Tipo_Trans");
                                Session.Remove("valor_asignado");
                                Session.Remove("Tipo_Trans");
                                Session.Remove("Tipo");
                                Session.Remove("valor_asignado1");

                                //Consultar tasa de cambio
                                ConsultarTasaCambioCanorus();
                                ModeloRolMod = BuscarRolModificar(AmUsrLog, ComPwm, "VTA", "PR", "N");
                                if (ModeloRolMod.control_uso == "readonly=\"readonly\"")
                                {
                                    txt_Precio.Enabled = false;
                                }
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
                                Int64 id = Int64.Parse(qs["Id"].ToString());
                                Session["valor_asignado"] = id.ToString();
                                lbl_trans.Text = id.ToString();
                                Session["Tipo_Trans"] = "UDP";
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
                                Session["Tipo_Trans"] = "VER";
                                cargarListaDesplegables();
                                LlenarFactura();
                                BloquearFactura();
                                break;
                            }
                            catch (Exception ex)
                            {
                                GuardarExcepciones("Page_Load, VER", ex.ToString());
                            }
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());
            }
        }
        public void GuardarExcepciones(string metodo, string error)
        {
           
            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "FormFacturaPostElec.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;
           
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción" + metodo + "." + " Por favor notificar al administrador."; 

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
                    lbl_trx.Text = " No existe Tipo de Cambio registrado para la fecha de la factura. Por favor registrar la tasa del dia y actualizar la pagina";
                    lbl_trx.Visible = true;
                    BloquearFactura();
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("ConsultarTasaCambioCanorus", ex.ToString());
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
            //txtBase15.Enabled = false;
            txtBaseIva19.Enabled = false;
           // txtIva15.Enabled = false;
            //txtIva19.Enabled = false;
            //botones
            AgregarNC.Enabled = false;
            Confirmar.Visible = false;
            
            btnGuardarDetalle.Visible = false;
            //detalle producto
            txt_Codigo.Enabled = false;
            txt_Descripcion.Enabled = false;
            txt_Descripcion2.Enabled = false;
            txt_Cantidad.Enabled = false;
            txt_Precio.Enabled = false;
            txt_Desc.Enabled = false;
            txt_Iva.Enabled = false;
        }
        protected void BloquearFacturaPagos()
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
            ///txtBase15.Enabled = false;
            txtBaseIva19.Enabled = false;
           // txtIva15.Enabled = false;
            //txtIva19.Enabled = false;
            //botones
            AgregarNC.Enabled = false;
            
            btnGuardarDetalle.Visible = false;
            //detalle producto
            txt_Codigo.Enabled = false;
            txt_Descripcion.Enabled = false;
            txt_Descripcion2.Enabled = false;
            txt_Cantidad.Enabled = false;
            txt_Precio.Enabled = false;
            txt_Desc.Enabled = false;
            txt_Iva.Enabled = false;
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
        public modelowmtfacturascab buscarTipoFac(string nro_trans)
        {
            try
            {
                lbl_error.Text = "";

                listaConsCab = ConsultaCabe.ConsultaTipoFactura(nro_trans);
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
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
        protected void LlenarFactura()
        {
            //llenar formulario para la actualizacion de datos
            try
            {
                lbl_error.Text = "";

                string Ccf_nro_trans = lbl_trans.Text;
                conscabceraTipo = buscarTipoFac(Ccf_nro_trans);
                Session["Ccf_tipo2"] = conscabceraTipo.tipo_nce.Trim();
                lbl_tipofac.Text = conscabceraTipo.tipo_nce.Trim(); 
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
                cmbCod_moneda.SelectedValue = conscabcera.cod_moneda.Trim();
                cod_vendedor.SelectedValue = conscabcera.cod_vendedor;
                suc_cliente.Text = conscabcera.cod_suc_cli;
                sucursal_lbl.Text = conscabcera.codnom_suc;
                //Consultamos cuantos descimales se van a usar redondeo
                // DecimalesMoneda = null;
                //DecimalesMoneda = BuscarDecimales();
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


                //Carga detalle factura
                string nro_trans = Ccf_nro_trans;

                listaConsDetalle = ConsultaDeta.ConsultaDetalleFacura(nro_trans);
                Session["detalle"] = listaConsDetalle;
                BuscarTotales();
                gv_Producto.DataSource = listaConsDetalle;
                gv_Producto.DataBind();
                gv_Producto.Height = 100;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("LlenarFactura", ex.ToString());

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
        public void cargarListaDesplegables()
        {
            //lista proformas
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
                    Session["Ccf_tipo2"]  = "POSE";
                    lbl_tipofac.Text = "POSE";
                    DateTime hoy = DateTime.Today;
                    fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                }
                else
                {
                    Session["Ccf_tipo2"] = "POS";
                    lbl_tipofac.Text = "POS";
                    fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                }
                cbx_tipo_dsc.Items.Insert(0, new ListItem("Seleccione...", "0"));
                cbx_tipo_dsc.SelectedIndex = 0;
                lbl_prc_dsc.Visible = false;
                txt_Desc.Visible = false;
                lbl_valor_dsc.Visible = false;
                txt_valor_dscl.Visible = false;
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

        public void TraeDetalleFactura()
        {

            listaConsCab = null;
            listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Session["Ccf_tipo2"].ToString(),lbl_trans.Text, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);

            conscabcera = null;
            foreach (modelowmtfacturascab item in listaConsCab)
            {
                conscabcera = item;

            }
            decimal SubTotal = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), conscabcera.subtotal);
            txtSumaSubTo.Text = ConsultaCMonedas.FormatorNumero(Session["redondeo"].ToString(), SubTotal );
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
            //Despues de guardar
            listaConsDetalle = null;
            listaConsDetalle = ConsultaDeta.ConsultaDetalleFacura(lbl_trans.Text);
            BuscarTotales();

            gv_Producto.DataSource = listaConsDetalle;
            gv_Producto.DataBind();
            gv_Producto.Height = 100;

        }

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

                lista = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi,suc_cliente.Text);

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
                    cabecerafactura.cod_suc_cli = suc_cliente.Text; //sucursal cliente

                    error = GuardarCabezera.ActualizarCabeceraFactura(cabecerafactura);
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
                    cabecerafactura.tipo = Session["Ccf_tipo2"].ToString(); //tipo vtae
                    cabecerafactura.porc_descto = Convert.ToDecimal("0.00");
                    cabecerafactura.descuento = Convert.ToDecimal("0.00");
                    cabecerafactura.diar = "0";
                    cabecerafactura.mesr = "0";
                    cabecerafactura.anior = "0";
                    cabecerafactura.cod_proc_aud = "RCOMFACT";
                    cabecerafactura.cod_sucursal = ModeloUsuSucursal.cod_sucursal;
                    cabecerafactura.nro_pedido = nro_pedido.Text;
                    cabecerafactura.cod_suc_cli = suc_cliente.Text; //sucursal cliente
                    cabecerafactura.desctos_rcgos = 0; //Enviar siempre 0 al insetar
                    error = GuardarCabezera.InsertarCabezeraFactura(cabecerafactura);
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

        public void InsertarDetalleSL()
        {
            try
            {
                lbl_error.Text = "";
                //Busca el nro de auditoria
                conscabcera = null;
                conscabcera = BuscarCabecera();
                articulo = null;
                articulo = BuscarProducto(txt_Codigo.Text);
                cmbCod_moneda.Enabled = false;
                //Insertar producto en la grilla calcular totales
                DateTime hoy = Convert.ToDateTime(fecha.Text);
        
                //Consultar tasa de cambio
                string dia = string.Format("{0:00}", hoy.Day);
                string mes = string.Format("{0:00}", hoy.Month);
                string anio = hoy.Year.ToString();
                //Consultar la referencia cruzada
                Articulos referencia_C = new Articulos();

                string cod_articulo2 = referencia_C.ReferenciaCArticulo(AmUsrLog, ComPwm, lbl_trans.Text);
                if (txt_valor_dscl.Text == "")
                {
                    txt_valor_dscl.Text = "0";
                }
                if (txt_Desc.Text == "")
                {
                    txt_Desc.Text = "0";
                }
                string linea_nueva = null; //ultimalinea
                //CONSULTAR Y VERIFICAR SI EXISTE O NO EL DETALLE
                //verificar si es insert, update
                if (txt_linea.Text == null || txt_linea.Text == "")
                {

                    linea_nueva = GuardarDetalles.UltimaLinea(lbl_trans.Text.Trim(), ComPwm, AmUsrLog);
                    if (linea_nueva == null)//Primera insercion
                    {
                        int linea_detalle = Convert.ToInt32(linea_nueva) + 1;
                        GuardarDetalles.InsertarDetalleFacturaSL(txt_Descripcion.Text, txt_Descripcion2.Text, Convert.ToDecimal(txt_Cantidad.Text), Convert.ToDecimal(txt_Precio.Text), Convert.ToDecimal(articulo.porc_aiu), Convert.ToDecimal(txt_Iva.Text), lbl_trans.Text.Trim(), linea_detalle, ComPwm, txt_Codigo.Text, articulo.cod_concepret, Convert.ToDecimal(txt_Desc.Text), Convert.ToDecimal(txt_valor_dscl.Text), articulo.cod_cta_vtas,
                        articulo.cod_cta_cos, articulo.cod_cta_inve, AmUsrLog, conscabcera.nro_audit, DateTime.Now, articulo.cod_tasa_impu, cod_costos.SelectedValue, cod_articulo2);
                        referencia_C.EliminarArticuloTem(AmUsrLog, ComPwm, lbl_trans.Text); //eliminar de tabla temporal
                    }
                    else
                    { //si ya existen registros
                        int linea_detalle = Convert.ToInt32(linea_nueva) + 1;
                        GuardarDetalles.InsertarDetalleFacturaSL(txt_Descripcion.Text, txt_Descripcion2.Text, Convert.ToDecimal(txt_Cantidad.Text), Convert.ToDecimal(txt_Precio.Text), Convert.ToDecimal(articulo.porc_aiu), Convert.ToDecimal(txt_Iva.Text), lbl_trans.Text.Trim(), linea_detalle, ComPwm,txt_Codigo.Text, articulo.cod_concepret, Convert.ToDecimal(txt_Desc.Text), Convert.ToDecimal(txt_valor_dscl.Text), articulo.cod_cta_vtas,
                        articulo.cod_cta_cos, articulo.cod_cta_inve, AmUsrLog, conscabcera.nro_audit, DateTime.Now, articulo.cod_tasa_impu, cod_costos.SelectedValue, cod_articulo2);
                        referencia_C.EliminarArticuloTem(AmUsrLog, ComPwm, lbl_trans.Text); //eliminar de tabla temporal
                    }
                }
                else
                {
                    //Actualizacion de producto
                    GuardarDetalles.ActualizarDetalleFacturaSL(txt_Descripcion2.Text, Convert.ToDecimal(txt_Cantidad.Text), Convert.ToDecimal(txt_Precio.Text), lbl_trans.Text.Trim(), Convert.ToInt32(txt_linea.Text), ComPwm, Convert.ToDecimal(txt_Desc.Text), AmUsrLog, cod_costos.SelectedValue, Convert.ToDecimal(txt_valor_dscl.Text));

                }
                txt_Codigo.Text = "";
                txt_Descripcion.Text = "";
                txt_Descripcion2.Text = "";
                txt_Precio.Text = "0";
                txt_Iva.Text = "0";
                txt_Desc.Text = "0";
                txt_Cantidad.Text = "1";
                txt_linea.Text = null;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("InsertarDetalleSL", ex.ToString());


            }
        }

        public void InsertarDetalle()
        {
            try
            {
                lbl_error.Text = "";
                cmbCod_moneda.Enabled = false;
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
                   

                    if (!existe)
                    {
                        item.cod_articulo = txt_Codigo.Text;
                        item.nom_articulo = txt_Descripcion.Text;
                        item.nom_articulo2 = txt_Descripcion2.Text;
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
                    txt_Descripcion2.Text = "";
                    txt_Precio.Text = "0";
                    txt_Iva.Text = "0";
                    txt_Desc.Text = "0";
                    txt_Cantidad.Text = "1";
                    item = null;
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("InsertarDetalle", ex.ToString());


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
                ConsultaDatosTitular.ActualizarDatosTitulares(ModeloActualizarEmail);

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
                cabecerafactura.tipo = Session["Ccf_tipo2"].ToString(); //TIPO POSE
                cabecerafactura.porc_descto = Convert.ToDecimal("0.00");
                cabecerafactura.descuento = Convert.ToDecimal("0.00");
                cabecerafactura.diar = "0";
                cabecerafactura.mesr = "0";
                cabecerafactura.anior = "0";
                cabecerafactura.cod_proc_aud = "RCOMFACPOS";
                cabecerafactura.cod_sucursal = ModeloUsuSucursal.cod_sucursal;
                cabecerafactura.nro_pedido = nro_pedido.Text;
                cabecerafactura.cod_suc_cli = suc_cliente.Text; //sucursal cliente

                error = GuardarCabezera.InsertarCabezeraFactura(cabecerafactura);
                if (string.IsNullOrEmpty(error))
                {

                }
                else
                {
                    //mensaje.Text = error;

                    //  this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                    Session["cabecera"] = cabecerafactura;
                    ///Insertar en la tabla proforma ins luego de q escoja

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("InsertarCabecera", ex.ToString());

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
                    //Buscar si existe detalle
                 

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
                            //this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                            lbl_trx.Text = error;

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
                        cmbCod_moneda.SelectedValue = cliente.moncli.Trim();
                        suc_cliente.Text = cliente.cod_sucursal;
                        sucursal_lbl.Text = cliente.codnom_suc;
                        //Consulta las proofrmas de ese cliente
                        ListaProofrmas = ConsultaProformas.BuscarProformas(cliente.cod_tit, "A", "PF");
                        cbx_proformas.DataSource = ListaProofrmas;
                        cbx_proformas.DataTextField = "proformas";
                        cbx_proformas.DataValueField = "nro_trans";
                        cbx_proformas.DataBind();

                        if (ListaProofrmas.Count > 0)
                        {
                            lbl_proforma.Visible = true;
                            btn_Proforma.Visible = true;
                            cbx_proformas.Visible = true;
                        }
                        else
                        {
                            lbl_proforma.Visible = false;
                            btn_Proforma.Visible = false;
                            cbx_proformas.Visible = false;
                        }

                        //Consulta remisiones
                        ListaRemision = ConsultaRemisiones.BuscarRemisiones(cliente.cod_tit, "A", "GR");
                        cbx_remisiones.DataSource = ListaRemision;
                        cbx_remisiones.DataTextField = "proformas";
                        cbx_remisiones.DataValueField = "nro_trans";
                        cbx_remisiones.DataBind();

                        if (ListaRemision.Count > 0)
                        {
                            lbl_remision.Visible = true;
                            btn_Remision.Visible = true;
                            cbx_remisiones.Visible = true;
                        }
                        else
                        {
                            lbl_remision.Visible = false;
                            btn_Remision.Visible = false;
                            cbx_remisiones.Visible = false;
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("dniCliente_TextChanged", ex.ToString());

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
        protected void BuscarArticulo_TextChanged(object sender, EventArgs e)
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
                        //Elimino cualquier registro anterior
                        Articulos referencia_C = new Articulos();
                        referencia_C.EliminarArticuloTem(AmUsrLog, ComPwm, lbl_trans.Text);
                        //Insertar el producto seleccionado
                        FacturaDetalle insertar_art = new FacturaDetalle();
                        insertar_art.InsertarArticuloTemp(lbl_trans.Text, articulo.cod_articulo, lbl_trans.Text, 0, ComPwm, AmUsrLog);

                        lblCan.Visible = true;
                        txt_Cantidad.Visible = true;
                        Session.Remove("articulo");
                        txt_Codigo.Text = articulo.cod_articulo;
                        txt_Descripcion.Text = articulo.nom_articulo;
                        //Redondear el numero a precios_uni

                        decimal precio_unitario = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo_pu, Convert.ToDecimal(articulo.precio));
                       
                        txt_Precio.Text = precio_unitario.ToString();
                        txt_Iva.Text = articulo.porc_impuesto;
                        txt_Desc.Text = "0";
                        Session.Remove("articulo");

                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarArticulo_TextChanged", ex.ToString());

            }
        }

        public void ValidarParametrosFactura()
        {
            try
            {
                lbl_error.Text = "";
                //Buscar Datos de parametrizacion------periodo contable
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

        protected void AgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                lbl_validacion.Text = "";
                lbl_validacion.Visible = false;
                ValidarParametrosFactura();
                //Agrega el producto a la grilla gv_Producto  
                articulo = null;
                articulo = BuscarProducto(txt_Codigo.Text);
                if (Convert.ToDecimal(txt_Precio.Text) < 0)
                {
                    if (articulo.negativo == "S")
                    {
                        if (lbl_tipofac.Text.Trim() == "POSE")
                        {
                            if (txtcorreo.Text == null || txtcorreo.Text == "")
                            {
                                lbl_validacion.Text = "Ingrese correo por favor";
                                lbl_validacion.Visible = true;
                            }
                            else
                            {

                                InsertarCabeceraSL();
                                InsertarDetalleSL();
                                TraeDetalleFactura();
                            }
                        }
                            else
                            {

                            InsertarCabeceraSL();
                            InsertarDetalleSL();
                            TraeDetalleFactura();
                        }

                    }
                    else
                    {
                        lbl_validacion.Text = "No se puede ingresar valores negativos";
                        lbl_validacion.Visible = true;
                    }
                }
                else
                {
                    if (lbl_tipofac.Text.Trim() == "POSE")
                    {
                        if (txtcorreo.Text == null || txtcorreo.Text == "")
                        {
                            lbl_validacion.Text = "Ingrese correo por favor";
                            lbl_validacion.Visible = true;
                        }
                        else
                        {
                            InsertarCabeceraSL();
                            InsertarDetalleSL();
                            TraeDetalleFactura();
                        }
                    }
                    else
                    {
                        InsertarCabeceraSL();
                        InsertarDetalleSL();
                        TraeDetalleFactura();
                    }
                }
                //Validar  que los precios no sean cero
                ValidarPrecioDetalle();
            }
            catch (Exception ex)
            {
                GuardarExcepciones("AgregarProducto_Click", ex.ToString());

            }

        }

        public void ValidarPrecioDetalle()
        {
            try
            {
                lbl_trx.Text = "";
                lbl_trx.Visible = false;
                Confirmar.Visible = true;
                //Validar que los precios de las remisiones y proformas no sean cero 
                listaConsDetalle = null;
                listaConsDetalle = ConsultaDeta.ConsultaDetalleFacura(lbl_trans.Text);
                // ModeloDetalleFactura modeloPro = new ModeloDetalleFactura();
                foreach (ModeloDetalleFactura det in listaConsDetalle)
                {
                    if (det.precio_unit == 0)
                    {
                        lbl_trx.Text = "El articulo/servicio " + det.cod_articulo + " " + det.nom_articulo + " El precio no puede ser 0.";
                        lbl_trx.Visible = true;
                        Confirmar.Visible = false;
                    }
                }

            }

            catch (Exception ex)
            {
                GuardarExcepciones("ValidarPrecioDetalle", ex.ToString());

            }

        }
        protected void GuardarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                //Boton Salvar
                GuardarDetalle();
            }
            catch (Exception ex)
            {
                GuardarExcepciones("GuardarDetalle_Click", ex.ToString());

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

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                Response.Redirect("BuscarFacturaPos.aspx");
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
                
                /*Antes de guardar verificar q esten guardados los medios de pago*/
                listaSaldos = consultaMediosPago.BuscarDiferenciaSaldos(AmUsrLog, ComPwm, lbl_trans.Text);
                foreach (var item in listaSaldos)
                {
                    modeloDiferencia = item;
                }
                //Total_cons = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), Convert.ToDecimal(modeloDiferencia.total));
                decimal Total_cons= ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), Convert.ToDecimal(txtSumaTotal.Text));
                decimal Pago = ConsultaCMonedas.RedondearNumero(Session["redondeo"].ToString(), Convert.ToDecimal(modeloDiferencia.pagado));

                if (Total_cons != Pago)
                {
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Pago no existente, verifique que los pagos sean correctos ')+ error;</script>");

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
                    else
                    {
                        //Preguntar si existe detalle antes de confirmar
                        if (txtSumaTotal.Text == "")
                        {
                            this.Page.Response.Write("<script language='JavaScript'>window.alert('No existen productos para facturar')+ error;</script>");
                        }
                        else
                        {
                            if (Convert.ToDecimal(txtSumaTotal.Text) == 0)
                            {
                                this.Page.Response.Write("<script language='JavaScript'>window.alert('No existen productos para facturar')+ error;</script>");
                            }
                            else
                            {
                                Confirmar.Enabled = false;

                                // ValidarParametrosFactura();
                                string respuestaConfirmacionFAC = "";
                                //Boton Coonfirmar hace lo mismo que el salvar solo aumenta la insercion a la tabla wmt_facturas_ins
                                InsertarCabeceraSL();
                                conscabcera = null;
                                conscabcera = BuscarCabecera();

                                    /*Consultar la cabacecera de la factura sacar los datos e insertar en ins para q no se borre de la tabla wmt_facturas_pgs*/

                                    confirmarinsertar.nro_trans = conscabcera.nro_trans;
                                    confirmarinsertar.cod_emp = conscabcera.cod_emp;
                                    confirmarinsertar.usuario_mod = AmUsrLog;
                                    confirmarinsertar.fecha_mod = DateTime.Now;
                                    confirmarinsertar.nro_audit = conscabcera.nro_audit;

                                    respuestaConfirmacionFAC = ConfirmarFactura.ConfirmarFactura(confirmarinsertar);

                                    //CONSULTA BUSCAR TIPO DE FACTURA
                                    conscabceraTipo = null;
                                    conscabceraTipo = buscarTipoFac(conscabcera.nro_trans.Trim());
                                    if (conscabceraTipo.tipo_nce.Trim() == "POSE")
                                    {
                                        if (respuestaConfirmacionFAC == "")
                                        {

                                           string respuesta = "";
                                        switch (Modelowmspclogo.version_fe.Trim())  //AVERIGUAR QUE VERSION  DE FACTURACION USA
                                        {
                                            case "1":
                                                 ConsumoRestFEV2 consumoRest1 = new ConsumoRestFEV2();
                                                 respuesta = consumoRest1.EnviarFactura(ComPwm, AmUsrLog, "C", "POSE", conscabcera.nro_trans);
                                               
                                                break;
                                            case "2":
                                                ConsumoRestFEV3 consumoRest = new ConsumoRestFEV3();
                                                respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", "POSE", conscabcera.nro_trans);
                                                break;
                                        }
     
                                            if (respuesta == "")
                                            {
                                                mensaje.Text = "Su factura fue procesada exitosamente";
                                                Confirmar.Enabled = false;
                                                GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "F");
                                            //Enviar correo al remitente si no da error
                                            EnviarCorreoRemitente(conscabcera.nro_trans, conscabceraTipo.tipo_nce.Trim());
                                                Response.Redirect("BuscarFacturaPos.aspx");

                                            }
                                            else
                                            {
                                                GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "C");
                                                mensaje.Text = respuesta;
                                                Response.Redirect("BuscarFacturaPos.aspx");

                                            }
                                        }
                                        else
                                        {
                                            lbl_trx.Visible = true;
                                            lbl_trx.Text = respuestaConfirmacionFAC;
                                        }
                                    }
                                    else
                                {
                                    if (respuestaConfirmacionFAC == "")
                                    {
                                        //Enviar correo al remitente si no da error
                                        EnviarCorreoCliente(conscabcera.nro_trans, conscabceraTipo.tipo_nce.Trim());
                                        Response.Redirect("BuscarFacturaPos.aspx");
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

                Enviarcorreocliente enviarcorreocliente = new Enviarcorreocliente();
                string pathPdf = "";
                string pathXml = "";

                ConsultaLogoSql tipo_factura = new ConsultaLogoSql();
                string cod_proceso = "RCOMFELECT";
                string tipo_doc = tipo_factura.TipoDocImprimir(ComPwm, cod_proceso, AmUsrLog);
                //-------------OBTENER PDF PARA EL ENVIO-------------------//
                if (tipo_doc.Trim() == "DEFECTO2")
                {

                    PdfFacVTAV2 pdf = new PdfFacVTAV2();
                    pathPdf = pdf.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                }
                else
                {
                    if (tipo_doc.Trim() == "DEFECTO3")
                    {
                        PdfFacVTAV3 pdf = new PdfFacVTAV3();
                        pathPdf = pdf.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    }

                }
                Boolean error = enviarcorreocliente.EnviarCorreoCliente(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, pathPdf, pathXml);
            }
            catch (Exception ex)
            {
                GuardarExcepciones("EnviarCorreoCliente", ex.ToString());

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
                ConsultaLogoSql tipo_factura = new ConsultaLogoSql();
                string cod_proceso = "RCOMFELECT";
                string tipo_doc = tipo_factura.TipoDocImprimir(ComPwm, cod_proceso, AmUsrLog);
                //-------------OBTENER PDF PARA EL ENVIO-------------------//
                if (tipo_doc.Trim() == "DEFECTO2")
                {

                    PdfFacVTAV2 pdf = new PdfFacVTAV2();
                    pathPdf = pdf.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                }
                else
                {
                    if (tipo_doc.Trim() == "DEFECTO3")
                    {
                        PdfFacVTAV3 pdf = new PdfFacVTAV3();
                        pathPdf = pdf.generarPdf(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                    }

                }
                Boolean error = enviarcorreocliente.EnviarCorreoRemitente(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, pathPdf, pathXml);
            }
            catch (Exception ex)
            {
                GuardarExcepciones("EnviarCorreoRemitente", ex.ToString());

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
            }
            catch (Exception ex)
            {
                GuardarExcepciones("RecuperarCokie", ex.ToString());

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
                        txt_valor_dscl.Text = "0";
                        cbx_tipo_dsc.SelectedValue = "P";
                        lbl_prc_dsc.Visible = true;
                        txt_Desc.Visible = true;

                        break;
                        case "Eliminar":
                        /*Eliminar item de la grilla*/
                        //Elimino fisicamente
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

        public void CargarDetalleFacturaRP()
        {
            try
            {
                lbl_error.Text = "";

                listaConsCab = null;
                listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Session["Ccf_tipo2"].ToString(), lbl_trans.Text, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);

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
        
                Session["sumaSubtotal"] = Convert.ToString(conscabcera.subtotal);
                Session["sumaDescuento"] = Convert.ToString(conscabcera.descuento);
                Session["sumaIva"] = Convert.ToString(conscabcera.iva);
                Session["sumaTotal"] = Convert.ToString(conscabcera.total);
                //Despues de guardar
                listaConsDetalle = null;
                listaConsDetalle = ConsultaDeta.ConsultaDetalleFacura(lbl_trans.Text);
                // ModeloDetalleFactura modeloPro = new ModeloDetalleFactura();
                foreach (ModeloDetalleFactura det in listaConsDetalle)
                {
                    if (det.precio_unit == 0)
                    {
                        lbl_trx.Text = "El articulo/servicio " + det.cod_articulo + " " + det.nom_articulo + " El precio no puede ser 0.";
                        lbl_trx.Visible = true;
                        Confirmar.Visible = false;
                    }
                }
                gv_Producto.DataSource = listaConsDetalle;
                gv_Producto.DataBind();
                gv_Producto.Height = 100;
            }

            catch (Exception ex)
            {
                GuardarExcepciones("CargarDetalleFacturaRP", ex.ToString());

            }

        }
        protected void btn_Proforma_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                lbl_trx.Text = "";
                lbl_trx.Visible = false;
                Confirmar.Visible = true;
                //Consulta y Cargar datos  del detalle de la proforma
                if (cbx_proformas.SelectedValue == null)
                {
                    cbx_proformas.Visible = false;
                    lbl_proforma.Visible = false;
                    btn_Proforma.Visible = false;
                }
                else
                {
                    //traer el detalle de la proforma
                    string nro_trans_pro = Convert.ToString(cbx_proformas.SelectedValue);
                    ListaDetaProforma = ConsultaDetallePro.BuscarProformasDetalle(nro_trans_pro);

                    //Insertar primero la cabecera
                    InsertarCabeceraSL();
                   
                    //Insertar en la tabla proforma ins luego de q escoja
                    if (cbx_proformas != null)
                    {

                        ListaProofrmas = ConsultaProformas.BuscarProformasCab(cbx_proformas.SelectedValue);
                        foreach (var item in ListaProofrmas)
                        {
                            ModeloProformas = item;
                        }
                        string docpro = ModeloProformas.nro_trans;
                        ModeloProformas.nro_trans = valor_asignado;
                        ModeloProformas.nro_docum = docpro;
                        ModeloProformas.cod_proceso = "FV";
                        InsertarProIns.InsertarProformaIns(ModeloProformas);
                    }
                    //TraeDetalleFactura();
                    CargarDetalleFacturaRP();
                    ListaProofrmas = ConsultaProformas.BuscarProformas(cliente.cod_tit, "A", "PF");
                    cbx_proformas.DataSource = ListaProofrmas;
                    cbx_proformas.DataTextField = "proformas";
                    cbx_proformas.DataValueField = "nro_trans";
                    cbx_proformas.DataBind();

                    if (ListaProofrmas.Count > 0)
                    {
                        lbl_proforma.Visible = true;
                        btn_Proforma.Visible = true;
                        cbx_proformas.Visible = true;
                    }
                    else
                    {
                        lbl_proforma.Visible = false;
                        btn_Proforma.Visible = false;
                        cbx_proformas.Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_Proforma_Click", ex.ToString());

            }
        }

        protected void btn_Remision_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                lbl_trx.Text = "";
                lbl_trx.Visible = false;
                Confirmar.Visible = true;
                //Consultar y cargar la remision
                if (cbx_remisiones.SelectedValue == null)
                {

                }
                else
                {
                    string nro_trans_remi = Convert.ToString(cbx_remisiones.SelectedValue);
                    //traer el detalle de la proforma
                    ListaDetalleRemision = ConsultaDetalleRemision.BuscarRemisionDetalle(nro_trans_remi);

                    //Insertar primero la cabecera
                    InsertarCabeceraSL();
                    
                    ListaRemision = ConsultaRemisiones.BuscarRemisionUnica(cbx_remisiones.SelectedValue);
                    foreach (var item in ListaRemision)
                    {
                        ModeloRemision = item;

                    }
                    string documento = ModeloRemision.nro_trans;
                    ModeloRemision.nro_trans = valor_asignado;
                    ModeloRemision.nro_docum = documento;
                    ModeloRemision.cod_proceso = "FV";

                    InsertarRemiIns.InsertarRemisionaIns(ModeloRemision);
                    //TraeDetalleFactura();
                    CargarDetalleFacturaRP();

                    //Consulta remisiones
                    ListaRemision = ConsultaRemisiones.BuscarRemisiones(cliente.cod_tit, "A", "GR");
                    cbx_remisiones.DataSource = ListaRemision;
                    cbx_remisiones.DataTextField = "proformas";
                    cbx_remisiones.DataValueField = "nro_trans";
                    cbx_remisiones.DataBind();

                    if (ListaRemision.Count > 0)
                    {
                        lbl_remision.Visible = true;
                        btn_Remision.Visible = true;
                        cbx_remisiones.Visible = true;
                    }
                    else
                    {
                        lbl_remision.Visible = false;
                        btn_Remision.Visible = false;
                        cbx_remisiones.Visible = false;
                    }


                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_Remision_Click", ex.ToString());

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
        protected void ImgAyuda_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                //Enviar codigo de porceso = nombre del proceso
                //rEcibir de cookie
                ModeloCodProceso = BuscarCodProceso(AmUsrLog);
                Response.Redirect("Ayuda.asp");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("ImgAyuda_Click", ex.ToString());

            }
        }

        protected void BuscarTotales()
        {
            try
            {
                decimal cargo = 0;
                decimal descuento = 0;
                ListaDesc = consultaDesc.ConsultaDescCargTrans(ComPwm, AmUsrLog, lbl_trans.Text);
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

        protected void btnImpuestos_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                if (Session["valor_asignado"] != null)
                {
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

        protected void btn_Pagos_Click(object sender, EventArgs e)
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
                Session.Remove("valor_asignado1");
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
                            
                                if (txtSumaTotal.Text == "0.00" || txtSumaTotal.Text == null || txtSumaTotal.Text == "")
                                {
                                    this.Page.Response.Write("<script language='JavaScript'>window.alert('No existe productos para Facturar')+ error;</script>");
                                }
                                else
                                {
                                    Session.Remove("detallePagos");
                                    Session.Remove("Tipo");
                                    Session.Remove("valor_asignado1");
                                    Session.Remove("TotalFactura");
                                    BloquearFacturaPagos();
                                    Session["Tipo"] = Session["Tipo_Trans"];
                                    Session["valor_asignado1"] = lbl_trans.Text;
                                    Session["Ccf_tipo2_Pagos"] = Session["Ccf_tipo2"];
                                    this.Page.Response.Write("<script language='JavaScript'>window.open('./MediosPagoPos.aspx', 'Medios Pago', 'top=100,width=900 ,height=500, left=500');</script>");

                                }
                            }
                        }
                    }
                
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_Pagos_Click", ex.ToString());

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
        protected void btn_desc_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                Session.Remove("Tipo");
                Session.Remove("desc_carg");
                Session["Tipo"] = Session["Tipo_Trans"];
                Session["valor_asignado1"] = lbl_trans.Text;
                this.Page.Response.Write("<script language='JavaScript'>window.open('./DescuentosCargosFac.aspx', 'Descuentos y Cargos', 'top=100,width=900 ,height=500, left=500');</script>");

            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_desc_Click", ex.ToString());

            }
        }

        protected void fecha_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_validacion.Text = "";
                lbl_validacion.Visible = false;
                DateTime Fecha_seleccion = Convert.ToDateTime(fecha.Text);
                if (Session["Ccf_tipo2"].ToString() == "POSE")
                {

                    DateTime Fecha_actual = DateTime.Today;
                    DateTime Fecha_minima = DateTime.Today.AddDays(-5);
                    int Actual = DateTime.Today.Day;
                    if (Fecha_seleccion < Fecha_minima)
                    {
                        lbl_validacion.Text = "La fecha de la factura no puede ser menor a cinco días de la fecha actual";
                        lbl_validacion.Visible = true;
                    }
                    if (Fecha_seleccion > Fecha_actual)
                    {

                        lbl_validacion.Text = "La fecha de la factura no puede ser mayor a  la fecha actual";
                        lbl_validacion.Visible = true;

                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("fecha_TextChanged", ex.ToString());

            }
        }

        protected void cbx_tipo_dsc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                if (cbx_tipo_dsc.SelectedValue == "P")
                {
                    lbl_prc_dsc.Visible = true;
                    txt_Desc.Visible = true;
                    lbl_valor_dsc.Visible = false;
                    txt_valor_dscl.Visible = false;
                    txt_valor_dscl.Text = "0";

                }
                else
                {
                    if (cbx_tipo_dsc.SelectedValue == "V")
                    {
                        lbl_prc_dsc.Visible = false;
                        txt_Desc.Visible = false;
                        lbl_valor_dsc.Visible = true;
                        txt_valor_dscl.Visible = true;
                        txt_Desc.Text = "0";
                    }
                    else
                    {
                        lbl_prc_dsc.Visible = false;
                        txt_Desc.Visible = false;
                        lbl_valor_dsc.Visible = false;
                        txt_valor_dscl.Visible = false;
                        txt_valor_dscl.Text = "0";
                        txt_Desc.Text = "0";
                    }

                }

            }
            catch (Exception ex)
            {
                GuardarExcepciones("cbx_tipo_dsc_SelectedIndexChanged", ex.ToString());

            }
        }
    }
}
