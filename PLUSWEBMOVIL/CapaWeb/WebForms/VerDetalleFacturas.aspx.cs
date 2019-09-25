using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;

namespace CapaWeb.WebForms
{
    public partial class VerDetalleFacturas : System.Web.UI.Page
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
                    DecimalesMoneda = null;
                    DecimalesMoneda = BuscarDecimales();

                    QueryString qs = ulrDesencriptada();

                    //Recibir opciones
                    switch (qs["TRN"].Substring(0, 3))
                    {

                        case "INS":
                            cargarListaDesplegables();
                            tipo_tran = "INS";
                            Session.Remove("listaCliente");
                            Session.Remove("Tipo_Trans");
                            Session.Remove("valor_asignado");
                            Session.Remove("Tipo_Trans");
                            DateTime hoy = DateTime.Today;
                            fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                            //Consultar tasa de cambio
                            ConsultarTasaCambioCanorus();
                            ModeloRolMod = BuscarRolModificar(AmUsrLog, ComPwm, "VTA", "PR", "N");
                            if (ModeloRolMod.control_uso == "readonly=\"readonly\"")
                            {
                                txt_Precio.Enabled = false;
                            }
                            break;

                        case "UDP":
                            Int64 id = Int64.Parse(qs["Id"].ToString());
                            Session["valor_asignado"] = id.ToString();
                            Session["Tipo_Trans"] = "UDP";
                            cargarListaDesplegables();
                            //  LlenarFactura();

                            break;

                        case "VER":
                            Int64 ide = Int64.Parse(qs["Id"].ToString());
                            string Tipo = (qs["Tipo"].ToString());
                            Session["valor_asignado"] = ide.ToString();
                            Session["Tipo_Trans"] = "VER";
                            cargarListaDesplegables();
                            LlenarFactura(Tipo);
                            BloquearFactura();
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
            //obtener numero de transaccion

            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "verDetalleFacturas.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Today;
            ModeloExcepcion.usuario_mod = AmUsrLog;

            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

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
            txtBase15.Enabled = false;
            txtBaseIva19.Enabled = false;
            txtIva15.Enabled = false;
            txtIva19.Enabled = false;
            //botones
            AgregarNC.Enabled = false;
            Confirmar.Visible = false;

            btnGuardarDetalle.Visible = false;
            //detalle producto
            txt_Codigo.Enabled = false;
            txt_Descripcion.Enabled = false;
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
            txtBase15.Enabled = false;
            txtBaseIva19.Enabled = false;
            txtIva15.Enabled = false;
            txtIva19.Enabled = false;
            //botones
            AgregarNC.Enabled = false;

            btnGuardarDetalle.Visible = false;
            //detalle producto
            txt_Codigo.Enabled = false;
            txt_Descripcion.Enabled = false;
            txt_Cantidad.Enabled = false;
            txt_Precio.Enabled = false;
            txt_Desc.Enabled = false;
            txt_Iva.Enabled = false;
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
        protected void LlenarFactura(string Tipo2)
        {
            try
            {
                lbl_error.Text = "";

                //llenar formulario para la actualizacion de datos


                string Ccf_nro_trans = Session["valor_asignado"].ToString();

                listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
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
                //Consultamos cuantos descimales se van a usar redondeo

                //Formato totales
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

            try
            {
                lbl_error.Text = "";

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
            catch (Exception ex)
            {
                GuardarExcepciones("cargarListaDesplegables", ex.ToString());

            }
        }



        public void InsertarDetalle()
        {
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
            cabecerafactura.tipo = Ccf_tipo2; //TIPO POSE
            cabecerafactura.porc_descto = Convert.ToDecimal("0.00");
            cabecerafactura.descuento = Convert.ToDecimal("0.00");
            cabecerafactura.diar = "0";
            cabecerafactura.mesr = "0";
            cabecerafactura.anior = "0";
            cabecerafactura.cod_proc_aud = "RCOMFACPOS";
            cabecerafactura.cod_sucursal = ModeloUsuSucursal.cod_sucursal;
            cabecerafactura.nro_pedido = nro_pedido.Text;

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

        public modelowmtfacturascab GuardarDetalle()
        {
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
                    cmbCod_moneda.SelectedValue = cliente.moncli.Trim();
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
        protected void BuscarArticulo_TextChanged(object sender, EventArgs e)
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
                    lblCan.Visible = true;
                    txt_Cantidad.Visible = true;
                    Session.Remove("articulo");
                    txt_Codigo.Text = articulo.cod_articulo;
                    txt_Descripcion.Text = articulo.nom_articulo;
                    //Redondear el numero a precios_uni

                    decimal precio_unitario = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo_pu, Convert.ToDecimal(consdetalle.precio_unit));
                    txt_Precio.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo_pu, precio_unitario);
                    txt_Iva.Text = articulo.porc_impuesto;
                    txt_Desc.Text = "0";
                    Session.Remove("articulo");

                }
            }
        }

        protected void AgregarProducto_Click(object sender, EventArgs e)
        {

            //Agrega el producto a la grilla gv_Producto  
            InsertarDetalle();
            //Boton Salvar
            GuardarDetalle();

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
            Response.Redirect("BuscarFacturaPos.aspx");
        }

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            /*Antes de guardar verificar q esten guardados los medios de pago*/
            listaSaldos = consultaMediosPago.BuscarDiferenciaSaldos(AmUsrLog, ComPwm, Session["valor_asignado"].ToString());
            foreach (var item in listaSaldos)
            {
                modeloDiferencia = item;
            }
            if (modeloDiferencia.total != modeloDiferencia.pagado)
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
                                string respuestaConfirmacionFAC = "";
                                //Boton Coonfirmar hace lo mismo que el salvar solo aumenta la insercion a la tabla wmt_facturas_ins

                                string Ccf_nro_trans = Session["valor_asignado"].ToString();

                                listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                                int count1 = 0;
                                conscabcera = null;
                                foreach (modelowmtfacturascab item in listaConsCab)
                                {
                                    count1++;
                                    conscabcera = item;

                                }
                                /*Consultar la cabacecera de la factura sacar los datos e insertar en ins para q no se borre de la tabla wmt_facturas_pgs*/

                                confirmarinsertar.nro_trans = conscabcera.nro_trans;
                                confirmarinsertar.cod_emp = conscabcera.cod_emp;
                                confirmarinsertar.usuario_mod = AmUsrLog;
                                confirmarinsertar.fecha_mod = DateTime.Now;
                                confirmarinsertar.nro_audit = conscabcera.nro_audit;

                                respuestaConfirmacionFAC = ConfirmarFactura.ConfirmarFactura(confirmarinsertar);
                                if (respuestaConfirmacionFAC == "")
                                {
                                    ConsumoRest consumoRest = new ConsumoRest();
                                    string respuesta = "";
                                    respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", "POSE", conscabcera.nro_trans);
                                    if (respuesta == "")
                                    {
                                        mensaje.Text = "Su factura fue procesada exitosamente";
                                        Confirmar.Enabled = false;
                                        GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "F");
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
                        }
                    }
                }

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

        protected void btn_Proforma_Click(object sender, EventArgs e)
        {
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
                //Cargar en la grilla 
                foreach (var proDet in ListaDetaProforma)
                {
                    ModeloDetallePro = proDet;


                    ModeloDetalleFactura item = new ModeloDetalleFactura();
                    articulo = null;
                    articulo = BuscarProducto(ModeloDetallePro.cod_articulo);


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
                            /* Resto los totales antes de agregar un nuevo por que puede haber variado el precio*/
                            sumaSubtotal -= itemSuma.subtotal;
                            sumaDescuento -= itemSuma.detadescuento;
                            sumaIva -= itemSuma.detaiva;
                            sumaTotal -= itemSuma.total;

                            //Ivas y bases
                            if (itemSuma.poriva.ToString() == "0.19")
                            {
                                sumaBase19 -= itemSuma.subtotal;
                            }
                            if (itemSuma.poriva.ToString() == "0.05")
                            {
                                sumaBase15 -= itemSuma.subtotal;
                            }
                            if (itemSuma.poriva.ToString() == "0.19")
                            {
                                sumaIva19 -= itemSuma.detaiva;
                            }
                            if (itemSuma.poriva.ToString() == "0.05")
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
                        item.cod_articulo = ModeloDetallePro.cod_articulo;
                        item.nom_articulo = ModeloDetallePro.nom_articulo;
                        item.nom_articulo2 = ModeloDetallePro.nom_articulo2;
                        item.cod_ccostos = cod_costos.SelectedValue;
                        item.cantidad = ModeloDetallePro.cantidad;
                        //Redondear el numero a precios_uni
                        item.precio_unit = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo_pu, Convert.ToDecimal(ModeloDetallePro.precio_unit));
                        //Redondear el numero a totales
                        item.porc_iva = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(ModeloDetallePro.porc_iva));
                        //Redondear el numero a totales
                        item.porc_descto = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(ModeloDetallePro.porc_descto));
                        //Redondear el numero a totales
                        item.subtotal = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(ModeloDetallePro.subtotal));

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
                            //Redondear el numero a totales

                            item.detaiva = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (item.subtotal * item.poriva));
                            item.subdos = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, item.subtotal);
                            item.total = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (item.subdos + item.detaiva)); //Suma total
                        }
                        else
                        {
                            item.descuento = item.porc_descto / 100;
                            item.detadescuento = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(item.subtotal - item.descuento));
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
                    item = null;

                }

                //LLAMAR EL METODO SALVAR
                GuardarDetalle();
                ///Insertar en la tabla proforma ins luego de q escoja
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

        protected void btn_Remision_Click(object sender, EventArgs e)
        {
            //Consultar y cargar la remision
            if (cbx_remisiones.SelectedValue == null)
            {

            }
            else
            {
                string nro_trans_remi = Convert.ToString(cbx_remisiones.SelectedValue);
                //traer el detalle de la proforma
                ListaDetalleRemision = ConsultaDetalleRemision.BuscarRemisionDetalle(nro_trans_remi);

                foreach (var proDet in ListaDetalleRemision)
                {
                    ModeloDetalleRemision = proDet;


                    ModeloDetalleFactura item = new ModeloDetalleFactura();
                    articulo = null;
                    articulo = BuscarProducto(ModeloDetalleRemision.cod_articulo);
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
                            /* Resto los totales antes de agregar un nuevo por que puede haber variado el precio*/
                            sumaSubtotal -= itemSuma.subtotal;
                            sumaDescuento -= itemSuma.detadescuento;
                            sumaIva -= itemSuma.detaiva;
                            sumaTotal -= itemSuma.total;

                            if (itemSuma.poriva.ToString() == "0.19")
                            {
                                sumaBase19 -= itemSuma.subtotal;
                            }
                            if (itemSuma.poriva.ToString() == "0.05")
                            {
                                sumaBase15 -= itemSuma.subtotal;
                            }
                            if (itemSuma.poriva.ToString() == "0.19")
                            {
                                sumaIva19 -= itemSuma.detaiva;
                            }
                            if (itemSuma.poriva.ToString() == "0.05")
                            {
                                sumaIva15 -= itemSuma.detaiva;
                            }

                            /* sumo los numebos valores agregados al producto*/
                            itemSuma.cantidad += Convert.ToDecimal(txt_Cantidad.Text);
                            //Redondear el numero a precios_uni
                            decimal precio_unitario = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo_pu, Convert.ToDecimal(txt_Precio.Text));
                            itemSuma.precio_unit = precio_unitario;

                            //Redondear valore totales
                            decimal precio_iva = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(txt_Iva.Text));
                            itemSuma.porc_iva = precio_iva;
                            //Redondear valore totales
                            decimal precio_des = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(txt_Desc.Text));
                            itemSuma.porc_descto = precio_des;
                            //Redondear valore totales
                            decimal precio_sub = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(itemSuma.precio_unit * itemSuma.cantidad));
                            itemSuma.subtotal = precio_sub;
                            itemSuma.poriva = itemSuma.porc_iva / 100;

                            sumaSubtotal = itemSuma.subtotal;
                            Session["sumaSubtotal"] = sumaSubtotal.ToString();
                            txtSumaSubTo.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, sumaSubtotal);

                            if (itemSuma.porc_descto == 0)
                            {
                                itemSuma.descuento = 0;
                                itemSuma.detadescuento = 0;
                                itemSuma.detaiva = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(itemSuma.subtotal * itemSuma.poriva));
                                itemSuma.subdos = itemSuma.subtotal;
                                itemSuma.total = itemSuma.subdos + itemSuma.detaiva; //Suma total
                            }
                            else
                            {
                                itemSuma.descuento = itemSuma.porc_descto / 100;
                                itemSuma.detadescuento = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(itemSuma.subtotal - itemSuma.descuento));
                                itemSuma.detaiva = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(itemSuma.detadescuento * itemSuma.poriva));
                                itemSuma.subdos = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(itemSuma.subtotal - itemSuma.descuento));
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
                        item.cod_articulo = ModeloDetalleRemision.cod_articulo;
                        item.nom_articulo = ModeloDetalleRemision.nom_articulo;
                        item.nom_articulo2 = ModeloDetalleRemision.nom_articulo2;
                        item.cod_ccostos = cod_costos.SelectedValue;
                        item.cantidad = ModeloDetalleRemision.cantidad;
                        //Redondear el numero a precios_uni
                        item.precio_unit = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo_pu, Convert.ToDecimal(ModeloDetalleRemision.precio_unit));
                        //Redondear el numero a totales
                        item.porc_iva = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(ModeloDetalleRemision.porc_iva));
                        //Redondear el numero a totales
                        item.porc_descto = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(ModeloDetalleRemision.porc_descto));
                        //Redondear el numero a totales
                        item.subtotal = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Convert.ToDecimal(ModeloDetalleRemision.subtotal)); ;
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
                    item = null;

                }
                //LLAMAR AL METODO SALVAR
                GuardarDetalle();

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
        protected void ImgAyuda_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            //Enviar codigo de porceso = nombre del proceso
            //rEcibir de cookie
            ModeloCodProceso = BuscarCodProceso(AmUsrLog);
            Response.Redirect("Ayuda.asp");
        }

        protected void area_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnImpuestos_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (Session["valor_asignado"] != null)
            {
                string transa = Session["valor_asignado"].ToString();
                ListaModeloimpuesto = consultaImpuesto.BuscarImpuestoRest(AmUsrLog, ComPwm, transa, "0");
                Session["listaImpuestos"] = ListaModeloimpuesto;
                this.Page.Response.Write("<script language='JavaScript'>window.open('./FormDetalleImpuestos.aspx', 'Detalle Impuesto', 'top=100,width=800 ,height=400, left=400');</script>");
            }


        }

        protected void btn_Pagos_Click(object sender, EventArgs e)
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
                        if (Session["detalle"] == null)
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
                                BloquearFacturaPagos();
                                Session["Tipo"] = Session["Tipo_Trans"];
                                Session["valor_asignado1"] = Session["valor_asignado"];
                                Session["TotalFactura"] = txtSumaTotal.Text;
                                this.Page.Response.Write("<script language='JavaScript'>window.open('./MediosPagoPos.aspx', 'Medios Pago', 'top=100,width=900 ,height=500, left=500');</script>");

                            }
                        }
                    }
                }
            }
        }
    }
}