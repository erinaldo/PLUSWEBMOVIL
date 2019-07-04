﻿using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;

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


        Consultawmspccostos ConsultaCCostos = new Consultawmspccostos();
        List<modelowmspcccostos> listaCostos = null;

        Consultawmspcmonedas ConsultaCMonedas = new Consultawmspcmonedas();
        List<modelowmspcmonedas> listaMonedas = null;

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

        public string ComPwm;
        public string AmUsrLog;
        public string valor_asignado = null;
        public string Ven__cod_tipotit = "clientes";
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
            //Variable de listaClienteFac busqueda de facturas
            if (Session["listaFacturas"] != null)
            {
                conscabcera = (modelowmtfacturascab)Session["listaFacturas"];
                txtSumaTotal.Text = conscabcera.total.ToString();
                txtSumaDesc.Text = conscabcera.descuento.ToString();
            }


            ConsultarTasaCambioCanorus();

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

                    case "INS":
                        cargarListaDesplegables();
                        Session.Remove("listaCliente");
                        Session.Remove("valor_asignado");
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
                    //Consulta de facturas por cliente

                    listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, dniCliente.Text, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                    cbx_facturas.DataSource = listaConsCab;
                    cbx_facturas.DataTextField = "observacion";
                    cbx_facturas.DataValueField = "nro_trans";
                    cbx_facturas.DataBind();

                    if (listaConsCab.Count > 0)
                    {
                        lbl_factura.Visible = true;
                        btn_Facturas.Visible = true;
                        cbx_facturas.Visible = true;
                    }
                    else
                    {
                        lbl_factura.Visible = false;
                        btn_Facturas.Visible = false;
                        cbx_facturas.Visible = false;
                    }

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

            //botones
            AgregarNC.Enabled = false;
            Confirmar.Visible = false;
            btnGuardarDetalle.Visible = false;
            //detalle producto
            txt_Observacion.Enabled = false;
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
            //Formato totales
            decimal formSubtot = Convert.ToDecimal(conscabcera.subtotal);
            txtSumaSubTo.Text = String.Format("{0:N}", formSubtot).ToString();
            decimal formTotal = Convert.ToDecimal(conscabcera.total);
            txtSumaTotal.Text = String.Format("{0:N}", formTotal).ToString();
            decimal formIva = Convert.ToDecimal(conscabcera.iva);
            txtSumaIva.Text = String.Format("{0:N}", formIva).ToString();
            decimal formDesc = Convert.ToDecimal(conscabcera.descuento);
            txtSumaDesc.Text = String.Format("{0:N}", formDesc).ToString();

            Session["sumaSubtotal"] = Convert.ToString(conscabcera.subtotal);
            Session["sumaDescuento"] = Convert.ToString(conscabcera.descuento);
            Session["sumaIva"] = Convert.ToString(conscabcera.iva);
            Session["sumaTotal"] = Convert.ToString(conscabcera.total);


            //Carga detalle factura
            string nro_trans = Ccf_nro_trans;

            listaConsDetalle = ConsultaDeta.ConsultaDetalleFacura(nro_trans);
            Session["detalle"] = listaConsDetalle;

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
        protected void AgregarNC_Click(object sender, EventArgs e)
        {
            // Guardar en el detalle de la factura 

        }

        protected void btn_Facturas_Click(object sender, EventArgs e)
        {
            //Agregar totales a la NC CORRESPONDIENTES DE LA FACTURA
            
            if (cbx_facturas.SelectedValue == null)
            {
                cbx_facturas.Visible = false;
                lbl_factura.Visible = false;
                btn_Facturas.Visible = false;
            }
            else
            {
                //traer el detalle de la factura seleccionada
                string nro_trans_fac = Convert.ToString(cbx_facturas.SelectedValue);
                listaConsDetalle = ConsultaDeta.ConsultaDetalleFacura(nro_trans_fac);
                //Cargar en la grilla 
                foreach (var proDet in listaConsDetalle)
                {
                    consdetalle = proDet;


                    ModeloDetalleFactura item = new ModeloDetalleFactura();
                    articulo = null;
                    articulo = BuscarProducto(consdetalle.cod_articulo);


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

                            /* sumo los numebos valores agregados al producto
                            itemSuma.cantidad += Convert.ToDecimal(cantidad.Text);
                            itemSuma.precio_unit = Math.Round(Convert.ToDecimal(precio.Text), 2);


                            itemSuma.porc_iva = Math.Round(Convert.ToDecimal(iva.Text), 0);
                            itemSuma.porc_descto = Math.Round(Convert.ToDecimal(porcdescto.Text), 0);*/
                            itemSuma.subtotal = Math.Round((itemSuma.precio_unit * itemSuma.cantidad), 2);
                            itemSuma.poriva = itemSuma.porc_iva / 100;



                            sumaSubtotal += itemSuma.subtotal;
                            Session["sumaSubtotal"] = sumaSubtotal.ToString();
                            txtSumaSubTo.Text = String.Format("{0:N}", sumaSubtotal).ToString();

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
                            txtSumaDesc.Text = String.Format("{0:N}", sumaDescuento).ToString();

                            sumaIva += itemSuma.detaiva;
                            Session["sumaIva"] = sumaIva.ToString();
                            txtSumaIva.Text = String.Format("{0:N}", sumaIva).ToString();

                            sumaTotal += itemSuma.total;
                            Session["sumaTotal"] = sumaTotal.ToString();
                            txtSumaTotal.Text = String.Format("{0:N}", sumaTotal).ToString();

                            //Suma base ivas
                            if (itemSuma.poriva.ToString() == "0.19")
                            {
                                sumaBase19 += itemSuma.subtotal;
                                Session["sumaBase19"] = sumaBase19.ToString();
                                txtBaseIva19.Text = String.Format("{0:N}", sumaBase19).ToString();
                            }

                            if (itemSuma.poriva.ToString() == "0.05")
                            {
                                sumaBase15 += itemSuma.subtotal;
                                Session["sumaBase15"] = sumaBase15.ToString();
                                txtBase15.Text = String.Format("{0:N}", sumaBase15).ToString();
                            }
                            //Ivas
                            if (itemSuma.poriva.ToString() == "0.19")
                            {
                                sumaIva19 += itemSuma.detaiva;
                                Session["sumaIva19"] = sumaIva19.ToString();
                                txtIva19.Text = String.Format("{0:N}", sumaIva19).ToString();
                            }
                            if (itemSuma.poriva.ToString() == "0.05")
                            {
                                sumaIva15 += itemSuma.detaiva;
                                Session["sumaIva15"] = sumaIva15.ToString();
                                txtIva15.Text = String.Format("{0:N}", sumaIva15).ToString();
                            }

                            /*Suma detalle*/

                            break;
                        }

                    }

                    if (!existe)
                    {
                        item.cod_articulo = consdetalle.cod_articulo;
                        item.nom_articulo = consdetalle.nom_articulo;
                        item.nom_articulo2 = consdetalle.nom_articulo2;
                        item.cod_ccostos = cod_costos.SelectedValue;
                        item.cantidad = consdetalle.cantidad;
                        item.precio_unit = consdetalle.precio_unit;
                        item.porc_iva = consdetalle.porc_iva;
                        item.porc_descto = consdetalle.porc_descto;
                        item.subtotal = consdetalle.subtotal;
                        item.poriva = item.porc_iva / 100;

                        if (Session["sumaSubtotal"] != null)
                        {
                            sumaSubtotal = Convert.ToDecimal(Session["sumaSubtotal"]);
                        }

                        sumaSubtotal += item.subtotal;
                        Session["sumaSubtotal"] = sumaSubtotal.ToString();
                        txtSumaSubTo.Text = String.Format("{0:N}", sumaSubtotal).ToString();

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
                        txtSumaIva.Text = String.Format("{0:N}", sumaIva).ToString();

                        if (Session["sumaDescuento"] != null)
                        {
                            sumaDescuento = Convert.ToDecimal(Session["sumaDescuento"]);
                        }

                        sumaDescuento += item.detadescuento;
                        Session["sumaDescuento"] = sumaDescuento.ToString();
                        txtSumaDesc.Text = String.Format("{0:N}", sumaDescuento).ToString();

                        if (Session["sumaTotal"] != null)
                        {
                            sumaTotal = Convert.ToDecimal(Session["sumaTotal"]);
                        }

                        sumaTotal += item.total;
                        Session["sumaTotal"] = String.Format("{0:N}", sumaTotal).ToString();
                        txtSumaTotal.Text = String.Format("{0:N}", sumaTotal).ToString();

                        //base iva 19 totales

                        if (Session["sumaBase19"] != null)
                        {
                            sumaBase19 = Convert.ToDecimal(Session["sumaBase19"]);
                        }
                        if (Math.Round(item.poriva, 2).ToString() == "0.19")
                        {
                            sumaBase19 += item.subtotal;
                            Session["sumaBase19"] = sumaBase19.ToString();
                            txtBaseIva19.Text = String.Format("{0:N}", sumaBase19).ToString();
                        }
                        //base iva 5 totales
                        if (Session["sumaBase15"] != null)
                        {
                            sumaBase15 = Convert.ToDecimal(Session["sumaBase15"]);
                        }
                        if (Math.Round(item.poriva, 2).ToString() == "0.05")
                        {
                            sumaBase15 += item.subtotal;
                            Session["sumaBase15"] = sumaBase15.ToString();
                            txtBase15.Text = String.Format("{0:N}", sumaBase15).ToString();
                        }
                        //Iva 19 totales

                        if (Session["sumaIva19"] != null)
                        {
                            sumaIva19 = Convert.ToDecimal(Session["sumaIva19"]);
                        }
                        if (Math.Round(item.poriva, 2).ToString() == "0.19")
                        {
                            sumaIva19 += item.detaiva;
                            Session["sumaIva19"] = sumaIva19.ToString();
                            txtIva19.Text = String.Format("{0:N}", sumaIva19).ToString();
                        }

                        //Iva 5 totales

                        if (Session["sumaIva15"] != null)
                        {
                            sumaIva15 = Convert.ToDecimal(Session["sumaIva15"]);
                        }
                        if (Math.Round(item.poriva, 2).ToString() == "0.05")
                        {
                            sumaIva15 += item.detaiva;
                            Session["sumaIva15"] = sumaIva15.ToString();
                            txtIva15.Text = String.Format("{0:N}", sumaIva15).ToString();
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
                   
                    item = null;
                    //Bloquear combo box xq solo debe cargar una sola factura para la DIAN
                    cbx_facturas.Enabled = false;
                    btn_Facturas.Enabled = false;


                }

            }
        }

        

        protected void btn_Fac_Click(object sender, EventArgs e)
        {
            
            string Ccf_estado = "F";
            string Ccf_cliente = dniCliente.Text;
            


            listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
            Session["listaClienteFac"] = listaConsCab;
            this.Page.Response.Write("<script language='JavaScript'>window.open('./BuscarFacturasNC.aspx', 'Buscar Facturas', 'top=100,width=800 ,height=400, left=400');</script>");
        }
    }
}