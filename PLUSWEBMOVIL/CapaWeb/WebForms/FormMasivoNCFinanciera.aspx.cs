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
using CapaProceso.ReslClientePdf;
using CapaDatos.Sql;
using CapaProceso.FacturaMasiva;
using SpreadsheetLight;

namespace CapaWeb.WebForms
{
    public partial class FormMasivoNCFinanciera : System.Web.UI.Page
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

        Cosnsultawmspcarticulos ConsultaArticulo = new Cosnsultawmspcarticulos();
        List<modelowmspcarticulos> listaArticulos = null;
        modelowmspcarticulos articulo = new modelowmspcarticulos();


        Consultawmsptitulares ConsultaTitulares = new Consultawmsptitulares();
        modelowmspctitulares cliente = new modelowmspctitulares();
        List<modelowmspctitulares> lista = null;

        Consultawmspcresfact ConsultaResolucion = new Consultawmspcresfact();
        modelowmspcresfact resolucion = new modelowmspcresfact();
        List<modelowmspcresfact> listaRes = null;
        MasivoNCFinanciera guardarNC = new MasivoNCFinanciera();


        ConsultawmusuarioSucursal consultaUsuarioSucursal = new ConsultawmusuarioSucursal();
        modeloUsuariosucursal ModeloUsuSucursal = new modeloUsuariosucursal();
        List<modeloUsuariosucursal> ListaUsuSucursal = null;
        UsuarioSucursal BuscarSucursal = new UsuarioSucursal();

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();

        CabezeraFactura GuardarCabezera = new CabezeraFactura();
        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();
        List<modelowmtfacturascab> listaConsCab = null;
        List<modeloFacturaEMasiva> listaAux = new List<modeloFacturaEMasiva>();
        modeloFacturaEMasiva conscabcera = new modeloFacturaEMasiva();
        modeloFacturaEMasiva modeloNC = new modeloFacturaEMasiva();
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

        GenerarPDFDocumentos generer_pdfElectronico = new GenerarPDFDocumentos();
        Enviarcorreocliente enviarcorreocliente = new Enviarcorreocliente();

        Consultavendedores ConsultaVendedores = new Consultavendedores();
        List<modelovendedores> listaVendedores = null;
        Consultawmspcmonedas ConsultaCMonedas = new Consultawmspcmonedas();
        List<modelowmspcmonedas> listaMonedas = null;

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
                   
                    cargarListaDesplegables();

                }

            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());
            }
        }

        public void cargarListaDesplegables()
        {
            try
            {
                lbl_error.Text = "";

                //Cargar la sucursal del usuario logeado
                ListaModeloUsuarioSucursal = ConsultaUsuxSuc.UnicoUsuarioSucursal(ComPwm, AmUsrLog, ""); //Solo se envia empresa y usuario
                if (ListaModeloUsuarioSucursal.Count == 0)
                {
                    lbl_error.Text = "Usuario no tiene sucursal asignada, por favor asignar sucursarl para continuar.";
                }
                else
                {
                    foreach (var item in ListaModeloUsuarioSucursal)
                    {
                        ModelousuarioSucursal = item;
                        break;
                    }
                    lbl_cod_suc_emp.Text = ModelousuarioSucursal.cod_sucursal.Trim();
                    lbl_suc_emp.Text = "-" + ModelousuarioSucursal.nom_sucursal.Trim();
                }

                listaRes = null;
                listaRes = ConsultaResolucion.ConsultaResolusionXSucursalNC(AmUsrLog, ComPwm, ResF_estado, ResF_serie, ResF_tipo, lbl_cod_suc_emp.Text.Trim());
                resolucion = null;
                foreach (modelowmspcresfact item in listaRes)
                {
                    resolucion = item;
                }
                if (listaRes.Count == 0)
                {

                    lbl_mensaje.Text = "No existe una resolución activa para emitir nota crédito.";
                }
                else
                {
                    if (listaRes.Count > 1)
                    {

                        lbl_mensaje.Text = "Existe más de una resolución activa, para Facturar habilite una solamente.";
                    }
                    else
                    {
                        lbl_tipo_prefijo.Text = resolucion.prefijo.Trim();
                        //Aqui se va a traer que tipo de facturacion es
                        if (resolucion.tipo_fac == "S")
                        {
                            Session["Masivo_NCF"] = "NCME";
                            lbl_tipo_nc.Text = "NCME";

                        }
                        else
                        {
                            Session["Masivo_NCF"] = "NCM";
                            lbl_tipo_nc.Text = "NCM";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("cargarListaDesplegables", ex.ToString());
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
        public void GuardarExcepciones(string metodo, string error)
        {
            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "FormMasivoNCFinanciera.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            lbl_error.Text = "No se pudo completar la acción" + metodo + "." + " Por favor notificar al administrador.";

        }

        public string ValidacionPrevia(modeloFacturaEMasiva modelo)
        {
            try
            {
                string error = null;
                //Validar que exista la factura para dicho cliente

                switch (Session["Masivo_NCF"].ToString())
                {
                    case "NCM":
                        ListaSaldoFacturas = consultaSaldoFactura.ConsultaFacVTASaldosXNroPrefijo(AmUsrLog, ComPwm, modelo.cod_cliente, "C", "N", lbl_cod_suc_emp.Text.Trim(), modelo.nro_docum.Trim(), modelo.serie_docum.Trim());
                        break;
                    case "NCME":
                        ListaSaldoFacturas = consultaSaldoFactura.BuscarFacSaldosXNroPrefijoEle(AmUsrLog, ComPwm, modelo.cod_cliente, "C", "N", lbl_cod_suc_emp.Text.Trim(), modelo.nro_docum.Trim(), modelo.serie_docum.Trim());
                        break;

                }
                if (ListaSaldoFacturas.Count == 0)
                {
                    error = "Factura N° " + modelo.serie_docum + "-" + modelo.nro_docum + " no existe/ no es valida para el cliente: " + modelo.dni_cliente;
                }
                else
                {
                    if (ListaSaldoFacturas.Count > 1)
                    {
                        error = "Factura N° " + modelo.serie_docum + "-" + modelo.nro_docum + " no se puede procesar, por favor revisar. ";
                    }
                }
                //Validar que la factura no se mayor en fecha de emision que la nc.
                foreach (var item in ListaSaldoFacturas)
                {
                    ModeloSaldoFactura = item;
                    break;
                }
                if (ModeloSaldoFactura.fec_doc > modelo.fecha_emision)
                {
                    error = "La fecha de nota de crédito no pude ser menor que la fecha de la Factura N° " + modelo.serie_docum + "-" + modelo.nro_docum;
                }
                //Validar que la nc no sea mayor a la nc
                //por linea
                decimal total = modelo.cant_pro * modelo.precio_unit;
                if (total > ModeloSaldoFactura.saldo)
                {
                    error = "La nota de crédito no pude ser mayor a la factura: " + modelo.serie_docum + "-" + modelo.nro_docum;
                }

                return error;
            }

            catch (Exception ex)
            {
                GuardarExcepciones("ValidacionPrevia", ex.ToString());
                return ex.ToString();
            }
        }
        protected void btn_importar_Click(object sender, EventArgs e)
        {

            try
            {
              
                //string Path;
                string pathtmpfac = Modelowmspclogo.pathtmpfac;  //Traemos el path, la ruta 
                string fileName = pathtmpfac + Path.GetFileName(FileUpload1.FileName);
                FileUpload1.PostedFile.SaveAs(fileName);
                string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                //Al importar eliminar todas las que estan en estado A solo nc
                guardarNC.EliminarNCMasivaFinanciera(ComPwm, AmUsrLog);

                if (extension.ToLower() == ".xlsx")
                {

                    SLDocument doc = new SLDocument(fileName);
                    int rowm = 3;
                    Boolean tot_eror = false;
                    while (!string.IsNullOrEmpty(doc.GetCellValueAsString(rowm, 1))) //VALIDAR CLIENTE ANTES DE INSERTAR
                    {
                        conscabcera.fecha_emision = doc.GetCellValueAsDateTime(rowm, 1); //Fecha emision
                        if (string.IsNullOrEmpty(Convert.ToString(conscabcera.fecha_emision)))
                        {
                            lbl_error.Text = "Fecha no puede estar vacía." + " Fila: " + rowm + "Columna: 1";
                            tot_eror = true;
                            break;
                        }
                        else
                        {
                            DateTime Fecha_actual = DateTime.Today;
                            DateTime Fecha_minima = DateTime.Today.AddDays(-5);
                            if (conscabcera.fecha_emision < Fecha_minima)
                            {
                                lbl_error.Text = "La fecha de la nota de crédito no puede ser menor a cinco días de la fecha actual." + " Fila: " + rowm + "Columna: 1";
                                return;
                            }
                            if (conscabcera.fecha_emision > Fecha_actual)
                            {

                                lbl_error.Text = "La fecha de la nota de crédito no puede ser mayor a  la fecha actual." + " Fila: " + rowm + "Columna: 1";
                                return;

                            }
                        }
                        conscabcera.serie_docum = doc.GetCellValueAsString(rowm, 2);//Serie
                        if (string.IsNullOrEmpty(conscabcera.serie_docum.Trim()))
                        {
                            lbl_error.Text = "Prefijo no puede estar vacío." + " Fila: " + rowm + "Columna: 2";
                            return;
                        }
                        conscabcera.nro_docum = doc.GetCellValueAsString(rowm, 3);//Nro_docum
                        if (string.IsNullOrEmpty(conscabcera.nro_docum.Trim()))
                        {
                            lbl_error.Text = "Número documento no puede estar vacío." + " Fila: " + rowm + "Columna: 3";
                            return;
                        }
                        conscabcera.dni_cliente = doc.GetCellValueAsString(rowm, 4);//identificacion cliente
                        if (string.IsNullOrEmpty(conscabcera.dni_cliente.Trim()))
                        {
                            lbl_error.Text = "Cliente no puede estar vacío." + " Fila: " + rowm + "Columna: 4";
                            return;
                        }
                        else
                        {
                            string Ven__cod_tit = conscabcera.dni_cliente.Trim();
                            conscabcera.cod_suc_cli = doc.GetCellValueAsString(rowm, 17);//Sucursal cliente
                            string suc_cliente = conscabcera.cod_suc_cli.Trim();//sucursal cliente
                            if (suc_cliente == "" || suc_cliente == null) //busca la matriz es decir 0
                            {
                                lista = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi, "0");
                                conscabcera.cod_suc_cli = "0";
                            }
                            else
                            {
                                lista = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi, suc_cliente);
                            }
                            if (lista.Count > 1)
                            {
                                lbl_error.Text = "Cliente tiene varias sucursales." + " Fila: " + rowm + "Columna: 4";
                                return;
                            }
                            if (lista.Count == 0)
                            {
                                lbl_error.Text = "Cliente no valido." + " Fila: " + rowm + "Columna: 4";
                                return;
                            }
                            else
                            {
                                foreach (var item in lista)
                                {
                                    cliente = item;
                                    break;
                                }
                                conscabcera.cod_cliente = cliente.cod_tit;//Codigo del cliente
                            }
                        }
                        conscabcera.correo = doc.GetCellValueAsString(rowm, 5);//correo
                        if (string.IsNullOrEmpty(conscabcera.correo.Trim()))
                        {
                            lbl_error.Text = "Correo no puede estar vacío." + " Fila: " + rowm + "Columna: 5";
                            return;
                        }
                        conscabcera.cod_termino = doc.GetCellValueAsString(rowm, 6);//terminos pago
                        if (string.IsNullOrEmpty(conscabcera.cod_termino.Trim()))
                        {
                            lbl_error.Text = "Termino de pago  no puede estar vacío." + " Fila: " + rowm + "Columna: 6";
                            return;
                        }
                        else
                        {
                            //Validar que exista termino de pago
                            string cod_termino = TerminoPago(conscabcera.cod_termino.Trim());
                            if (string.IsNullOrEmpty(cod_termino))
                            {
                                lbl_error.Text = "Termino de pago  no valido." + " Fila: " + rowm + "Columna: 6";
                                return;
                            }
                        }

                        conscabcera.fecha_vencimiento = doc.GetCellValueAsDateTime(rowm, 7); //fecha vencimiento
                        if (string.IsNullOrEmpty(Convert.ToString(conscabcera.fecha_vencimiento)))
                        {
                            lbl_error.Text = "Fecha vencimiento no puede estar vacía." + " Fila: " + rowm + "Columna: 7";
                            return;
                        }
                        conscabcera.cod_vendedor = doc.GetCellValueAsString(rowm, 8);//vendedor
                        if (string.IsNullOrEmpty(conscabcera.cod_vendedor.Trim()))
                        {
                            lbl_error.Text = "Vendedor  no puede estar vacío." + " Fila: " + rowm + "Columna: 8";
                            return;
                        }
                        else
                        {
                            //Validar que exista vendedor
                            listaVendedores = ConsultaVendedores.ConsultaVendedores(AmUsrLog, ComPwm, Vend__cod_tipotit, conscabcera.cod_vendedor.Trim(), Ven__cod_dgi);
                            if (listaVendedores.Count == 0)
                            {
                                lbl_error.Text = "Vendedor  no válido." + " Fila: " + rowm + "Columna: 8";
                                return;
                            }
                        }
                        int linea = doc.GetCellValueAsInt32(rowm, 10);//linea
                        string linea_v = Convert.ToString(linea);
                        if (string.IsNullOrEmpty(linea_v.Trim()))
                        {
                            lbl_error.Text = "Linea no es válida." + " Fila: " + rowm + "Columna: 10";
                            return;
                        }
                        conscabcera.cod_articulo = doc.GetCellValueAsString(rowm, 11);//articulo
                        if (string.IsNullOrEmpty(conscabcera.cod_articulo.Trim()))
                        {
                            lbl_error.Text = "Articulo no es válido." + " Fila:" + rowm + " Columna: 11";
                            return;
                        }
                        else
                        {
                            listaArticulos = ConsultaArticulo.ConsultaArticulos(AmUsrLog, ComPwm, conscabcera.cod_articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);
                            if (listaArticulos.Count == 0)
                            {
                                lbl_error.Text = "Articulo no es válido." + " Fila:" + rowm + " Columna: 11";
                                return;
                            }

                        }
                        conscabcera.cant_pro = doc.GetCellValueAsDecimal(rowm, 13);//Cantidad
                        string cantidad = Convert.ToString(conscabcera.cant_pro);
                        if (string.IsNullOrEmpty(cantidad.Trim()))
                        {
                            lbl_error.Text = "Cantidad no  válida." + " Fila:" + rowm + " Columna: 13";
                            return;
                        }
                        else
                        {
                            if (conscabcera.cant_pro < 0)
                            {

                                lbl_error.Text = "Cantidad no  válida." + " Fila:" + rowm + " Columna: 13";
                                return;
                            }
                        }
                        conscabcera.precio_unit = doc.GetCellValueAsDecimal(rowm, 14);//Precio
                        string precio = Convert.ToString(conscabcera.precio_unit);
                        if (string.IsNullOrEmpty(precio.Trim()))
                        {
                            lbl_error.Text = "Precio no  válido." + " Fila:" + rowm + " Columna: 14";
                            return;
                        }
                        else
                        {
                            if (conscabcera.precio_unit < 0)
                            {

                                lbl_error.Text = "Precio no  válido." + " Fila:" + rowm + " Columna: 14";
                                return;
                            }
                        }

                        conscabcera.porc_desc = doc.GetCellValueAsDecimal(rowm, 15);//Descuento
                        string descuento = Convert.ToString(conscabcera.porc_desc);
                        if (string.IsNullOrEmpty(descuento.Trim()))
                        {
                            lbl_error.Text = "Descuento no  válido." + " Fila:" + rowm + " Columna: 15";
                            return;
                        }
                        else
                        {
                            if (conscabcera.porc_desc < 0 || conscabcera.porc_desc > 100)
                            {

                                lbl_error.Text = "Descuento no  válido." + " Fila:" + rowm + " Columna: 15";
                                return;
                            }
                        }
                        conscabcera.moneda = doc.GetCellValueAsString(rowm, 16);//Moneda
                        if (!string.IsNullOrEmpty(conscabcera.moneda.Trim()))
                        {
                            listaMonedas = ConsultaCMonedas.ConsultaCMonedas(AmUsrLog, ComPwm, conscabcera.moneda.Trim());
                            if (listaMonedas.Count == 0)
                            {
                                lbl_error.Text = "Moneda no  válida." + " Fila:" + rowm + " Columna: 16";
                                return;
                            }
                        }
                        conscabcera.motivo = doc.GetCellValueAsString(rowm, 18);//Motivo
                        if (string.IsNullOrEmpty(conscabcera.motivo.Trim()))
                        {
                            lbl_error.Text = "Motivo de nota de crédito no puede ser nulo." + " Fila:" + rowm + " Columna: 18";
                            return;
                        }
                        else
                        {
                            if (conscabcera.motivo.Trim() == "3" || conscabcera.motivo.Trim() == "4" || conscabcera.motivo.Trim() == "5" || conscabcera.motivo.Trim() == "6")
                            {
                               
                            }
                            else
                            {
                                lbl_error.Text = "Motivo de nota de crédito no válido." + " Fila:" + rowm + " Columna: 18";
                                return;
                            }
                        }
                        string validar = ValidacionPrevia(conscabcera);
                        if (!string.IsNullOrEmpty(validar))
                        {
                            lbl_error.Text = validar;
                            tot_eror = true;
                            return;
                        }

                        rowm++;
                    }
                    int rowm2 = 3;
                    if (tot_eror == false)
                    {
                        while (!string.IsNullOrEmpty(doc.GetCellValueAsString(rowm2, 1))) //VALIDAR CLIENTE ANTES DE INSERTAR
                        {
                            conscabcera.fecha_emision = doc.GetCellValueAsDateTime(rowm2, 1); //Fecha emision
                            conscabcera.serie_docum = doc.GetCellValueAsString(rowm2, 2);//Serie
                            conscabcera.nro_docum = doc.GetCellValueAsString(rowm2, 3);//Nro_docum
                            conscabcera.dni_cliente = doc.GetCellValueAsString(rowm2, 4);//identificacion cliente

                            string Ven__cod_tit = conscabcera.dni_cliente.Trim();
                            conscabcera.cod_suc_cli = doc.GetCellValueAsString(rowm2, 17); //Sucursal cliente
                            string suc_cliente = conscabcera.cod_suc_cli.Trim();//sucursal cliente
                            if (suc_cliente == "" || suc_cliente == null) //busca la matriz es decir 0
                            {
                                lista = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi, "0");
                                conscabcera.cod_suc_cli = "0";
                            }
                            else
                            {
                                lista = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi, suc_cliente);
                            }
                            foreach(var item in lista)
                            {
                                cliente = item;
                                break;
                            }
                            
                            conscabcera.cod_cliente = cliente.cod_tit;//Codigo del cliente
                            conscabcera.correo = doc.GetCellValueAsString(rowm2, 5);//correo
                            conscabcera.terminos_pago = doc.GetCellValueAsString(rowm2, 6);//terminos pago
                            conscabcera.cod_termino = TerminoPago(conscabcera.terminos_pago.Trim());
                            conscabcera.fecha_vencimiento = doc.GetCellValueAsDateTime(rowm2, 7); //fecha vencimiento
                            conscabcera.cod_vendedor = doc.GetCellValueAsString(rowm2, 8);//vendedor
                            conscabcera.observaciones = doc.GetCellValueAsString(rowm2, 9);//observaciones
                            conscabcera.linea_pro = doc.GetCellValueAsInt32(rowm2, 10);//linea
                            conscabcera.cod_articulo = doc.GetCellValueAsString(rowm2, 11);//articulo
                            conscabcera.descripcion2 = doc.GetCellValueAsString(rowm2, 12);//descripcion2
                            conscabcera.cant_pro = doc.GetCellValueAsDecimal(rowm2, 13);//Cantidad
                            conscabcera.precio_unit = doc.GetCellValueAsDecimal(rowm2, 14);//Precio
                            conscabcera.porc_desc = doc.GetCellValueAsDecimal(rowm2, 15);//Descuento
                            conscabcera.moneda = doc.GetCellValueAsString(rowm2, 16);//Moneda
                            conscabcera.motivo = doc.GetCellValueAsString(rowm2, 18);//Motivo
                            conscabcera.cod_emp = ComPwm;
                            conscabcera.usuario_mod = AmUsrLog;
                            conscabcera.fecha_carga = DateTime.Now;
                            conscabcera.estado_fac = "A";
                            conscabcera.razon_social = Session["Masivo_NCF"].ToString();
                           string error= guardarNC.InsertarNCMasiva(conscabcera);
                            if(!string.IsNullOrEmpty(error.Trim()))
                            {
                                lbl_mensaje.Text = error;
                                return;
                            }
                            else
                            {
                                tot_eror = false;
                            }
                            rowm2++;
                        }
                       
                    }
                    if (tot_eror == false)
                    {
                        lbl_mensaje.Text = "Carga finalizada";
                        btn_importar.Visible = false;
                        FileUpload1.Visible = false;
                        lbl_carga.Visible = false;
                        //habilitar
                        lbl_verificar.Visible = true;
                        btn_verificar.Visible = true;
                        lbl_total_nc.Visible = true;

                    }
                }
                        

            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_importar_Click", ex.ToString());

            }
        }

        //Buscar aritulo unico por codigo
        public modelowmspcarticulos BuscarProducto(string ComPwm, string AmUsrLog, string ArtB__articulo)
        {
            try
            {
                listaArticulos = ConsultaArticulo.ConsultaArticuloUnico(AmUsrLog, ComPwm, ArtB__articulo);

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
        public string TerminoPago(string termino)
        {
            string cod_termino = null;
            switch (termino.Trim())
            {
                case "CONTADO":
                    cod_termino = "00";
                    break;

                case "15 DIAS":
                    cod_termino = "01";
                    break;

                case "30 DIAS":
                    cod_termino = "02";
                    break;

                case "45 DIAS":
                    cod_termino = "03";
                    break;

                case "60 DIAS":
                    cod_termino = "04";
                    break;

                case "90 DIAS":
                    cod_termino = "05";
                    break;

                case "120 DIAS":
                    cod_termino = "06";
                    break;

                default:
                    cod_termino = null;
                    break;
            }
            return cod_termino;

        }

        protected void btn_verificar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_mensaje.Text = "";
                //Total NC A PROCESAR 
                listaAux = guardarNC.TotalNCFinancieras(AmUsrLog, ComPwm, Session["Masivo_NCF"].ToString());
                if (listaAux.Count == 0)
                {
                    lbl_error.Text = "Notas de crédito no disponibles";
                }
                else
                {
                    int count = 0;
                    foreach (modeloFacturaEMasiva item in listaAux)
                    {

                        modeloNC = item;
                        lbl_carga_fec.Text = item.fecha_carga.ToString();
                        count++;
                    }
                    lbl_total_nc.Text = count.ToString();
                    btn_verificar.Visible = false;
                    BtnIniciar.Enabled = true;
                    BtnIniciar.Visible = true;
                    btn_cancelar.Visible = true;
                    lbl_carga_fec.Visible = true;
                    lbl_fec_ca.Visible = true;

                }
            }

            catch (Exception ex)
            {
                GuardarExcepciones("btn_verificar_Click", ex.ToString());

            }
        }
        //Progress bar
        private int Prop_CoTareas
        {
            get
            {
                if (ViewState["CoTareas"] == null)
                {
                    ViewState["CoTareas"] = 0;
                }
                return (int)ViewState["CoTareas"];
            }

            set
            {
                ViewState["CoTareas"] = value;
            }
        }

        private int Prop_TotalTareas = 0;


        private int f_PorcentajeAvance(int Par_TotalTareas, int Par_TareaActual)
        {
            int liPorcentaje = 0;
            //aplicar una regla de 3 simple
            liPorcentaje = (Par_TareaActual * 100) / Par_TotalTareas;
            return liPorcentaje;
        }

        private int f_ancho_control_porcentaje(int Par_AnchoTotalControl, int Par_Porcentaje)
        {
            int liAnchoControl = 0;
            liAnchoControl = (Par_Porcentaje * Par_AnchoTotalControl) / 100;
            return liAnchoControl;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

            Prop_TotalTareas = Convert.ToInt16(lbl_total_nc.Text);
            //limitar el numero de tareas al total de tareas a realizar
            if (Prop_CoTareas <= Prop_TotalTareas)
            {
                int liPorcentajeAvance = 0;

                //contador de tarea??
                Prop_CoTareas += 1;

                //tarea actual con total tareas
                LblAvance.Text = Prop_CoTareas.ToString() + " de " + Prop_TotalTareas.ToString();

                //porcentaje de avance segun el numero de tareas
                liPorcentajeAvance = f_PorcentajeAvance(Prop_TotalTareas, Prop_CoTareas);
                LblPorcentajeAvance.Text = liPorcentajeAvance.ToString() + "%";

                //barra de progreso
                LblProgressBar.Visible = true;
                LblProgressBar.Width = f_ancho_control_porcentaje(400, liPorcentajeAvance);

                //tareas a realizar poner todo el codigo para notas de credito electronicamente
                string error_fac = null;

                modeloNC = guardarNC.BuscarNCActiva(AmUsrLog, ComPwm, Session["Masivo_NCF"].ToString());

                try
                {
                    if (!string.IsNullOrEmpty(modeloNC.nro_docum.Trim()))
                    {
                        error_fac = guardarNC.ProcesarNotaCreditoFinanciera(AmUsrLog, ComPwm, modeloNC.nro_docum.Trim(), modeloNC.serie_docum.Trim(), lbl_cod_suc_emp.Text.Trim());

                        if (!string.IsNullOrEmpty(error_fac))
                        {
                            guardarNC.ActualizarEstadosNCFinanciera(AmUsrLog, ComPwm, "E", Session["Masivo_NCF"].ToString());//Estado E cuando ocurre un error 

                            lbl_error_factura.Text = "Excepción al aplicar nota de crédito a la factura: " + modeloNC.serie_docum + "-" + modeloNC.nro_docum + "Incidencia: " + error_fac; 
                            lbl_error_factura.Visible = true;
                            return;

                        }
                    }
                }
                catch (Exception aee)
                {

                    throw;
                }

                //.....
            }

            if (Prop_CoTareas == Prop_TotalTareas)
            {
                Prop_CoTareas = 0;
                Timer1.Enabled = false;
                LblAvance.Text = "Tarea finalizada";
                BtnIniciar.Visible = false;
                
            }
        }
        protected void BtnIniciar_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = true;
            BtnIniciar.Enabled = false;
            Prop_TotalTareas = 10;
            btn_cancelar.Visible = false;
        }
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            btn_verificar.Visible= false;
            BtnIniciar.Enabled = false;
            BtnIniciar.Visible = false;
            btn_cancelar.Visible = false;
            lbl_carga_fec.Visible = false;
            lbl_fec_ca.Visible = false;
            lbl_total_nc.Text = "";
            //Habiliar la carga masiva
            btn_importar.Visible = true;
            FileUpload1.Visible = true;
            lbl_carga.Visible = true;
        }
    }
}