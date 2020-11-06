using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaDatos.Sql;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using CapaProceso.RestCliente;

namespace CapaProceso.FacturaMasiva
{
   public class MasivoNDebito
    {
        //Leer tabla wmh_cargafaturas
        modeloFacturasPagos modeloTiposPagos = new modeloFacturasPagos(); //Modelo tipos de pagos
        public List<modeloFacturasPagos> listaTiposPagos = null;

        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "MasivoNDebito.cs";
        public string numerador = "trans";
        CabezeraFactura GuardarCabezera = new CabezeraFactura();
        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        public string valor_asignado = null;
        ConsultawmusuarioSucursal consultaUsuarioSucursal = new ConsultawmusuarioSucursal();
        modeloUsuariosucursal ModeloUsuSucursal = new modeloUsuariosucursal();
        List<modeloUsuariosucursal> ListaUsuSucursal = null;
        modelocabecerafactura cabecerafactura = new modelocabecerafactura();

        Cosnsultawmspcarticulos ConsultaArticulo = new Cosnsultawmspcarticulos();
        List<modelowmspcarticulos> listaArticulos = null;
        modelowmspcarticulos articulo = new modelowmspcarticulos();

        List<modeloFPagosF> ListaFPagosF = null;
        modeloFPagosF modeloFPagosFactura = new modeloFPagosF();

        List<modeloCargosDscGlobalesF> ListaCarDscG = null;
        modeloCargosDscGlobalesF modeloCarDscG = new modeloCargosDscGlobalesF();
        List<ModeloDetalleFactura> ModeloDetalleFactura = new List<ModeloDetalleFactura>();
        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        List<modelowmtfacturascab> listaConsCab = null;

        Consultawmspcresfact ConsultaResolucion = new Consultawmspcresfact();
        modelowmspcresfact resolucion = new modelowmspcresfact();
        List<modelowmspcresfact> listaRes = null;

        Consultawmspccostos ConsultaCCostos = new Consultawmspccostos();
        List<modelowmspcccostos> listaCostos = null;
        modelowmspcccostos ccostos = new modelowmspcccostos();

        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

        modelowmtfacturascab conscabceraTipo = new modelowmtfacturascab();
        ModeloDetalleFactura detallefactura = new ModeloDetalleFactura();
        DetalleFactura GuardarDetalles = new DetalleFactura();

        modeloinsertarconfirmar confirmarinsertar = new modeloinsertarconfirmar();
        Consultaconfirmarfactura ConfirmarFactura = new Consultaconfirmarfactura();
        List<modeloinsertarconfirmar> modeloinsertarconfirmar = new List<modeloinsertarconfirmar>();
        public modeloActualizarDatosTitular ModeloActualizarEmail = new modeloActualizarDatosTitular();
        public ConsultaActualizarTitular ConsultaDatosTitular = new ConsultaActualizarTitular();

        Consultawmsptitulares ConsultaTitulares = new Consultawmsptitulares();
        modelowmspctitulares clientes = new modelowmspctitulares();
        List<modelowmspctitulares> listaClientes = null;

        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();
        ConsultaMediosPago consultaMediosPago = new ConsultaMediosPago();

        public List<modeloMediosPago> listaMedios = null;
        modeloMediosPago modeloMedios = new modeloMediosPago(); //Medios de pago por empresa

        public List<ModeloTipoPagoTem> listaTemporal = null; //para temporales sp
        ModeloTipoPagoTem modeloTemporal = new ModeloTipoPagoTem(); //para temporales sp
        public List<modeloFacturasPagos> listaPagosFactura = null; //Modelos guardar tabla wmt_facturas_pgs
        modeloFacturasPagos modeloPagosFactura = new modeloFacturasPagos();
        modeloFacturasPagos detallePagosFactura = new modeloFacturasPagos();
        List<modeloFacturasPagos> modeloFacturasPagos = new List<modeloFacturasPagos>();
        ConsultaMediosPago guardarPagos = new ConsultaMediosPago(); //Guarda en tabla wmt_facturas_pgs
        FacturaDescuento consultaDesc = new FacturaDescuento();
        Articulos concepto = new Articulos();
        ModeloFacturaDescuento ModeloDescuento = new ModeloFacturaDescuento();
        CabezeraFactura BuscarDescuento = new CabezeraFactura();
        List<ModeloFacturaDescuento> ListaDescuento = new List<ModeloFacturaDescuento>();

        modeloFacturaEMasiva modeloNCF = new modeloFacturaEMasiva();
        public string Ccf_tipo1 = "C";
        public string Ccf_tipo2 = "VTAE";
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
        public string ResF_estado = "S";
        public string ResF_serie = "0";
        public string ResF_tipo = "D";
        public string CC__cod_dpto = "0";
        public string Ven__cod_tipotit = "clientes";
        public string Ven__cod_dgi = "0";
        public string Ven__fono = "0";
        public string tipo_factura;
        string stringConexionERP = "";// Aqui va la consulta de la table de parametros conexion_erp
        string nro_trans_padre = null;
        ValidarParametrizacionFactura conexion_erp = new ValidarParametrizacionFactura();
        modeloFacturaEMasiva modeloNC = new modeloFacturaEMasiva();
        List<ModeloDetalleFactura> listaConsDetalle = null;
        Consultawmtfacturasdet ConsultaDeta = new Consultawmtfacturasdet();
        public string nro_tras_padre;
        //____________________________________________________PROCESO ND FINANCIERA CARGA MASIVA________________________________________________
        public string ProcesarNotaDebitoFinanciera(string Ccf_usuario, string Ccf_cod_emp, string nro_docum, string serie, string cod_suc_emp, string tipo_nc, string motivo)
        {
            try
            {
                string error = null;
                List<modeloFacturaEMasiva> lista = new List<modeloFacturaEMasiva>();

                lista = BuscarNDFinancieraXDocum(Ccf_usuario, Ccf_cod_emp, nro_docum, serie, tipo_nc.Trim(), motivo.Trim());

                //Insertar en la cabecera de nc
                error = InsertarCabecera(Ccf_usuario, Ccf_cod_emp, nro_docum, serie, lista, cod_suc_emp, tipo_nc);
                if (string.IsNullOrEmpty(error))
                {
                    error = InsertarDetalle(Ccf_usuario, Ccf_cod_emp, lista);
                    if (string.IsNullOrEmpty(error))
                    {
                        ModeloDetalleFactura = new List<ModeloDetalleFactura>();
                        //Finalizar factura
                        error =FinalizarNDFinanciera (Ccf_usuario, Ccf_cod_emp, serie, nro_docum, motivo.Trim());
                    }

                    else
                    {
                        return error;
                    }
                }
                else
                {
                    return error;
                }

                return error;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ProcesarNotaDebitoFinanciera", e.ToString(), DateTime.Now, Ccf_usuario);
                return e.ToString();
            }
        }

        public string FinalizarNDFinanciera(string AmUsrLog, string ComPwm, string serie, string nro_docum, string motivo)
        {
            try
            {
                string error = null;

                ListaModelowmspclogo = consultaLogo.BuscartaLogo(ComPwm, AmUsrLog);
                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }

                string respuestaConfirmacionFAC = "";
                //Boton Coonfirmar hace lo mismo que el salvar solo aumenta la insercion a la tabla wmt_facturas_ins

                confirmarinsertar.nro_trans = conscabcera.nro_trans;
                confirmarinsertar.cod_emp = conscabcera.cod_emp;
                confirmarinsertar.usuario_mod = AmUsrLog;
                confirmarinsertar.fecha_mod = DateTime.Now;
                confirmarinsertar.nro_audit = conscabcera.nro_audit;

                respuestaConfirmacionFAC = ConfirmarFactura.ConfirmarFactura(confirmarinsertar);

                if (conscabcera.tipo == "NDVE")
                {

                    if (respuestaConfirmacionFAC == "")
                    {

                        //AVERIGUAR LA VERSION DE NC QUE USA
                        string respuesta = "";
                        if (Modelowmspclogo.version_fe == "2")
                        {
                            ConsumoRestNDV3 consumoRest = new ConsumoRestNDV3();
                            respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", conscabcera.tipo.Trim(), conscabcera.nro_trans, nro_trans_padre.Trim());
                        }

                        if (respuesta == "")
                        {

                            GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "F");
                            ActualizarEstadoNDFinanciera(AmUsrLog, ComPwm, nro_docum.Trim(), serie.Trim(), "P", conscabcera.tipo.Trim(), motivo.Trim());//ESTADO PROCESADO
                            if(motivo.Trim()=="4")
                            {
                                GuardarCabezera.ActualizarEstadoFactura(nro_trans_padre.Trim(), "N");//Actualiza factura a Anulada
                            }

                        }
                        else
                        {
                            GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "C");
                            ActualizarEstadoNDFinanciera(AmUsrLog, ComPwm, nro_docum.Trim(), serie.Trim(), "P", conscabcera.tipo.Trim(), motivo.Trim());//ESTADO PROCESADO

                        }
                    }

                    else
                    {
                        GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "C");
                        ActualizarEstadoNDFinanciera(AmUsrLog, ComPwm, nro_docum.Trim(), serie.Trim(), "P", conscabcera.tipo.Trim(), motivo.Trim());//ESTADO PROCESADO
                        error = respuestaConfirmacionFAC;
                    }
                }
                else
                {
                    if (respuestaConfirmacionFAC == "")
                    {
                        if (motivo.Trim() == "4")
                        {
                            GuardarCabezera.ActualizarEstadoFactura(nro_trans_padre.Trim(), "N");//Actualiza factura a Anulada
                        }
                        ActualizarEstadoNDFinanciera(AmUsrLog, ComPwm, nro_docum.Trim(), serie.Trim(), "P", conscabcera.tipo.Trim(), motivo.Trim());//ESTADO PROCESADO
                    }
                    else
                    {
                        ActualizarEstadoNDFinanciera(AmUsrLog, ComPwm, nro_docum.Trim(), serie.Trim(), "P", conscabcera.tipo.Trim(), motivo.Trim());//ESTADO PROCESADO
                        error = respuestaConfirmacionFAC;
                    }
                }
                return error;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "FinalizarNDFinanciera", e.ToString(), DateTime.Now, AmUsrLog);
                return e.ToString();
            }
        }
   
        public string InsertarCabecera(string AmUsrLog, string ComPwm, string nro_docum, string serie, List<modeloFacturaEMasiva> lista, string cod_sucursal, string tipo_nc)
        {
            try
            {
                string error = null;
                foreach (var item in lista)
                {
                    modeloNCF = item;
                    break;
                }
                //Buscar  los datos de la factura
                listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, "", Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, serie, nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                    conscabcera = item;
                }
                nro_trans_padre = conscabcera.nro_trans;
                //obtener numero de transaccion
                nrotrans = ConsultaNroTran.ConsultaNumeradores(numerador);
                valor_asignado = nrotrans.valor_asignado;


                //LIsta Resolucion facturas(serie documento)
                listaRes = ConsultaResolucion.ConsultaResolusionXSucursalND(AmUsrLog, ComPwm, ResF_estado, ResF_serie, ResF_tipo, cod_sucursal.Trim());
                resolucion = null;
                foreach (modelowmspcresfact item in listaRes)
                {
                    resolucion = item;
                    break;
                }
                //TIPO nc viene desde la vista
                tipo_factura = tipo_nc.Trim();
                //Procedimiento para actualizar email del titular
                ModeloActualizarEmail.usuario = AmUsrLog;
                ModeloActualizarEmail.empresa = ComPwm;
                ModeloActualizarEmail.cod_tit = modeloNCF.socio_negocio.ToString();
                ModeloActualizarEmail.parametro = "email";
                ModeloActualizarEmail.valor = modeloNCF.correo;
                ModeloActualizarEmail.sucursal = modeloNCF.cod_suc_cli;
                //Envio de datos para actualizar email en RP  
                ConsultaDatosTitular.ActualizarDatosTitulares(ModeloActualizarEmail);
                //------------------------INSERTAR CABCERA--------------------//
                DateTime Fecha = modeloNCF.fecha_emision;
                cabecerafactura.cod_cliente = modeloNCF.socio_negocio.ToString();
                cabecerafactura.dia = string.Format("{0:00}", Fecha.Day);
                cabecerafactura.mes = string.Format("{0:00}", Fecha.Month);
                cabecerafactura.anio = Fecha.Year.ToString();
                cabecerafactura.fec_doc = Fecha.ToString();
                cabecerafactura.serie_docum = resolucion.serie_docum;
                cabecerafactura.cod_ccostos = conscabcera.cod_ccostos;
                cabecerafactura.cod_vendedor = modeloNCF.cod_vendedor;
                cabecerafactura.cod_fpago = modeloNCF.cod_termino;
                cabecerafactura.observaciones = modeloNCF.observaciones;
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
                cabecerafactura.ocompra = "";
                cabecerafactura.cod_moneda = modeloNCF.cod_moneda;
                cabecerafactura.tipo = tipo_factura;//"NCME";
                cabecerafactura.porc_descto = Convert.ToDecimal("0.00");
                cabecerafactura.descuento = Convert.ToDecimal("0.00");
                cabecerafactura.diar = "0";
                cabecerafactura.mesr = "0";
                cabecerafactura.anior = "0";
                cabecerafactura.cod_proc_aud = "RCOMNDEB";
                cabecerafactura.cod_sucursal = cod_sucursal.Trim();
                cabecerafactura.nro_pedido = "";
                cabecerafactura.nro_trans_padre = nro_trans_padre;
                cabecerafactura.mot_nce = modeloNCF.tipo_docum;
                cabecerafactura.cod_suc_cli = modeloNCF.cod_suc_cli;
                cabecerafactura.desctos_rcgos = 0; //Enviar siempre 0 al insetar
                error = GuardarCabezera.InsertarCabezeraNotaCredito(cabecerafactura);
                return error;
            }
            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "InsertarCabecera", ex.ToString(), DateTime.Now, AmUsrLog);

                return ex.ToString();
            }
        }

        //Insertar Detalle
        public string InsertarDetalle(string AmUsrLog, string ComPwm, List<modeloFacturaEMasiva> listaD)
        {
            try
            {
                string error_det = null;
                modeloFacturaEMasiva ModeloDetalle = new modeloFacturaEMasiva();
                foreach (var proDet in listaD)
                {
                    ModeloDetalle = proDet;


                    ModeloDetalleFactura item = new ModeloDetalleFactura();
                    articulo = null;
                    articulo = BuscarProducto(ComPwm, AmUsrLog, ModeloDetalle.articulo);
                    //Elimino cualquier registro anterior
                    Articulos referencia_C = new Articulos();
                    referencia_C.EliminarArticuloTem(AmUsrLog, ComPwm, valor_asignado);
                    //Insertar el producto seleccionado
                    FacturaDetalle insertar_art = new FacturaDetalle();
                    insertar_art.InsertarArticuloTemp(valor_asignado, articulo.cod_articulo, valor_asignado, 0, ComPwm, AmUsrLog);

                    string cod_articulo2 = referencia_C.ReferenciaCArticulo(AmUsrLog, ComPwm, valor_asignado);

                    item.cod_articulo = ModeloDetalle.articulo;
                    item.cod_articulo2 = cod_articulo2;
                    item.nom_articulo = articulo.nom_articulo; //Verificar cuando viene vacio no es permitido xpor ds
                    item.nom_articulo2 = ModeloDetalle.descripcion2;
                    item.cod_ccostos = "000";//ccostos.cod_dpto;  //Traer valor por defecto
                    item.cantidad = Convert.ToDecimal(ModeloDetalle.cant_pro);
                    item.precio_unit = Convert.ToDecimal(ModeloDetalle.precio_unit);
                    item.porc_iva = Convert.ToDecimal(articulo.porc_impuesto);
                    item.porc_descto = ModeloDetalle.porc_desc;
                    item.cod_cta_cos = articulo.cod_cta_cos;
                    item.cod_cta_inve = articulo.cod_cta_inve;
                    item.cod_cta_vtas = articulo.cod_cta_vtas;
                    item.base_imp = Convert.ToDecimal(articulo.porc_aiu);
                    item.tasa_iva = articulo.cod_tasa_impu;
                    item.cod_concepret = articulo.cod_concepret;
                    item.cod_doca = "FV";
                    item.nro_doca = ModeloDetalle.nro_docum;
                    item.serie_doca = ModeloDetalle.serie_docum;
                    ModeloDetalleFactura.Add(item);

                    referencia_C.EliminarArticuloTem(AmUsrLog, ComPwm, valor_asignado); //eliminar de tabla temporal
                    item = null;
                }
                return error_det = GuardarDetalle(ComPwm, AmUsrLog, ModeloDetalleFactura);
            }
            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "InsertarDetalle", ex.ToString(), DateTime.Now, AmUsrLog);
                return ex.ToString();
            }
        }

        //Insertar detalle detalle en pwm
        public string GuardarDetalle(string ComPwm, string AmUsrLog, List<ModeloDetalleFactura> listaD)
        {
            try
            {
                string error = null;
                //Busca en gv_producto todos los items añadidos que estan en la variable de session detalle
                ModeloDetalleFactura = new List<ModeloDetalleFactura>();
                ModeloDetalleFactura = (listaD as List<ModeloDetalleFactura>);
                //Busca el nro de auditoria
                conscabcera = null;
                conscabcera = BuscarCabecera(ComPwm, AmUsrLog);

                //Va añadiendo linea por linea al modelo insertar detalle factura
                int contarLinea = 0;
                foreach (var item in ModeloDetalleFactura)
                {
                    contarLinea++;
                    detallefactura.cod_doca = item.cod_doca;
                    detallefactura.nro_doca = item.nro_doca;
                    detallefactura.serie_doca = item.serie_doca;
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

                }

                return error;
            }
            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "GuardarDetalle", ex.ToString(), DateTime.Now, AmUsrLog);
                return ex.ToString();

            }
        }
        //-----------------------------------------------------------------FIN ND FINANCIERA--------------------------------------------------------------------
        //-------------------------------------------------------------------PROCESAR NOTA DEBITO POR ANULACION--------------------------------------------------
        public string ProcesarNotaDebitoAnulacion(string Ccf_usuario, string Ccf_cod_emp, string serie, string nro_docum, string cod_sucursal, string tipo_nc, string motivo)
        {
            try
            {
                string error = null;
                List<modeloFacturaEMasiva> lista = new List<modeloFacturaEMasiva>();
                lista =BuscarNDFinancieraXDocum (Ccf_usuario, Ccf_cod_emp, nro_docum.Trim(), serie.Trim(), tipo_nc.Trim(), motivo.Trim()); //Traer Datos de factura desde wmh_cargaMasiva
                if (lista.Count > 0)
                {
                    //Insertar en la cabecera de la factura
                    error = InsertarCabeceraMasivo(Ccf_usuario, Ccf_cod_emp, serie.Trim(), nro_docum.Trim(), cod_sucursal.Trim(), lista,  tipo_nc.Trim());
                    if (string.IsNullOrEmpty(error))
                    {
                        //Referencia cruzada ---insertar detallle factura
                        error = GuardarDetalleMasivo(Ccf_cod_emp, Ccf_usuario, nro_tras_padre.Trim());
                        if (string.IsNullOrEmpty(error))
                        {
                            ModeloDetalleFactura = new List<ModeloDetalleFactura>();
                            //Finalizar factura
                            error = FinalizarNDFinanciera(Ccf_usuario, Ccf_cod_emp, nro_docum.Trim(), serie.Trim(),motivo.Trim());
                        }
                        else { return error; }
                    }
                    else { return error; }
                }
                else { return error = "No existe factura"; }

                return error;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ProcesarNotaDebitoAnulacion", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }
        public string InsertarCabeceraMasivo(string AmUsrLog, string ComPwm, string serie, string nro_docum, string cod_sucursal, List<modeloFacturaEMasiva> lista, string tipo_nc)
        {
            try
            {
                string error = null;
                foreach (var item in lista)
                {
                    modeloNC = item;
                    break;
                }
                //Cargamos los datos de la factura
                listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, "", Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, serie, nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                    conscabcera = item;
                }
                nro_trans_padre = conscabcera.nro_trans;
                //obtener numero de transaccion
                nrotrans = ConsultaNroTran.ConsultaNumeradores(numerador);
                valor_asignado = nrotrans.valor_asignado;


                //LIsta Resolucion facturas(serie documento)
                listaRes = ConsultaResolucion.ConsultaResolusionXSucursalND(AmUsrLog, ComPwm, ResF_estado, ResF_serie, ResF_tipo, cod_sucursal.Trim());
                resolucion = null;
                foreach (modelowmspcresfact item in listaRes)
                {
                    resolucion = item;
                    break;
                }
                //TIPO nc

                tipo_factura = tipo_nc.Trim();

                DateTime Fecha = modeloNC.fecha_emision;
                cabecerafactura.cod_cliente = conscabcera.cod_cliente;
                cabecerafactura.dia = string.Format("{0:00}", Fecha.Day);
                cabecerafactura.mes = string.Format("{0:00}", Fecha.Month);
                cabecerafactura.anio = Fecha.Year.ToString();
                cabecerafactura.fec_doc = Fecha.ToString();
                cabecerafactura.serie_docum = resolucion.serie_docum;
                cabecerafactura.cod_ccostos = conscabcera.cod_ccostos;
                cabecerafactura.cod_vendedor = modeloNC.cod_vendedor;
                cabecerafactura.cod_fpago = conscabcera.cod_fpago;
                cabecerafactura.observaciones = modeloNC.observaciones;
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
                cabecerafactura.ocompra = conscabcera.ocompra;
                cabecerafactura.cod_moneda = conscabcera.cod_moneda;
                cabecerafactura.tipo = tipo_factura;// "NDVE";
                cabecerafactura.porc_descto = Convert.ToDecimal("0.00");
                cabecerafactura.descuento = Convert.ToDecimal("0.00");
                cabecerafactura.diar = "0";
                cabecerafactura.mesr = "0";
                cabecerafactura.anior = "0";
                cabecerafactura.cod_proc_aud = "RCOMNDEB";
                cabecerafactura.cod_sucursal = cod_sucursal;
                cabecerafactura.nro_pedido = conscabcera.nro_pedido;
                cabecerafactura.nro_trans_padre = conscabcera.nro_trans;
                cabecerafactura.mot_nce = modeloNC.tipo_docum.Trim(); //Motivo DS  4 por anulación
                cabecerafactura.cod_suc_cli = conscabcera.cod_suc_cli;
                cabecerafactura.desctos_rcgos = 0; //Enviar siempre 0 al insetar
                error = GuardarCabezera.InsertarCabezeraNotaCredito(cabecerafactura);
                return error;

            }
            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "InsertarCabeceraMasivo", ex.ToString(), DateTime.Now, AmUsrLog);
                return ex.ToString();

            }
        }
        //Insertar detalle de nc anulacion
        public string GuardarDetalleMasivo(string ComPwm, string AmUsrLog, string nro_trans)
        {
            try
            {
                string error = null;
                listaConsDetalle = ConsultaDeta.ConsultaDetalleFacura(nro_trans);
                //Busca en gv_producto todos los items añadidos que estan en la variable de session detalle
                ModeloDetalleFactura = new List<ModeloDetalleFactura>();
                ModeloDetalleFactura = (listaConsDetalle as List<ModeloDetalleFactura>);
                conscabcera = null;
                conscabcera = BuscarCabecera(ComPwm, AmUsrLog);

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
                    error = GuardarDetalles.InsertarDetalleFactura(detallefactura);

                }

                return error;
            }
            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "GuardarDetalleMasivo", ex.ToString(), DateTime.Now, AmUsrLog);
                return ex.ToString();

            }
        }
        //--------------------------------------------------------------------FIN ND ANULACION-------------------------------------------------------------------
        //Buscar aritulo
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
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "BuscarProducto", ex.ToString(), DateTime.Now, AmUsrLog);

                return null;
            }
        }
        //Buscar Cabecera de factura
        public modelowmtfacturascab BuscarCabecera(string ComPwm, string AmUsrLog)
        {

            try
            {
                //Busca el nro de auditoria para poder insertar el detalle factura
                //consulta nro_auditoria de la cabecera
                string Ccf_nro_trans = valor_asignado;
                listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, "", Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);

                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                    conscabcera = item;
                }
                return conscabcera;
            }
            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "BuscarCabecera", ex.ToString(), DateTime.Now, AmUsrLog);
                return null;
            }
        }
        //Actualizar estado de ActualizarEstadoNDFinanciera en wmh_cargaMasiva por nro_prefijo
        public string ActualizarEstadoNDFinanciera(string ArtB__usuario, string ArtB__cod_emp, string nro_docum, string prefijo, string estado_fac, string tipo_nc, string motivo)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {

                    string consulta = "UPDATE wmh_cargaMasiva SET estado_fac=@estado_fac WHERE nro_docum =@nro_docum and serie_docum=@serie_docum AND estado_fac='A' and razon_social =@tipo and tipo_docum=@motivo";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = nro_docum;
                    conmand.Parameters.Add("@serie_docum", SqlDbType.VarChar).Value = prefijo;
                    conmand.Parameters.Add("@estado_fac", SqlDbType.VarChar).Value = estado_fac;
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo_nc;
                    conmand.Parameters.Add("@motivo", SqlDbType.VarChar).Value = motivo;
                    int dr = conmand.ExecuteNonQuery();
                    return "";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ActualizarEstadoNDFinanciera", e.ToString(), DateTime.Now, ArtB__usuario);
                return e.ToString();
            }
        }
        //Actualizar estados de nd anulacion en wmh_cargaMasiva
        public string ActualizarEstadosNDAnulacion(string ArtB__usuario, string ArtB__cod_emp, string estado_fac, string tipo)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);
                using (cn = conexion.genearConexionERP(stringConexionERP))
                {

                    string consulta = "UPDATE wmh_cargaMasiva SET estado_fac = @estado_fac where estado_fac = 'A' and razon_social = @tipo and tipo_docum ='4' ";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                    conmand.Parameters.Add("@estado_fac", SqlDbType.VarChar).Value = estado_fac;
                    int dr = conmand.ExecuteNonQuery();
                    return "";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ActualizarEstadosNCAnulacion", e.ToString(), DateTime.Now, ArtB__usuario);
                return e.ToString();
            }
        }
        //Actualizar estados de nc financiera en wmh_cargaMasiva
        public string ActualizarEstadosNDFinanciera(string ArtB__usuario, string ArtB__cod_emp, string estado_fac, string tipo)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);
                using (cn = conexion.genearConexionERP(stringConexionERP))
                {

                    string consulta = "UPDATE wmh_cargaMasiva SET estado_fac = @estado_fac where estado_fac = 'A' and razon_social = @tipo and tipo_docum in('1','2','3') ";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                    conmand.Parameters.Add("@estado_fac", SqlDbType.VarChar).Value = estado_fac;
                    int dr = conmand.ExecuteNonQuery();
                    return "";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ActualizarEstadosNCFinanciera", e.ToString(), DateTime.Now, ArtB__usuario);
                return e.ToString();
            }
        }
        //Total de nd financieras a procesar mandar tipo es decir normales o electronicas
        public List<modeloFacturaEMasiva> BuscarNDFinancieraXDocum(string ArtB__usuario, string ArtB__cod_emp, string nro_docum, string prefijo, string tipo, string motivo)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    List<modeloFacturaEMasiva> lista = new List<modeloFacturaEMasiva>();

                    string consulta = "SELECT * from wmh_cargaMasiva where estado_fac ='A' and nro_docum =@nro_docum and serie_docum = @serie_docum and razon_social=@tipo and tipo_docum =@motivo";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = nro_docum;
                    conmand.Parameters.Add("@serie_docum", SqlDbType.VarChar).Value = prefijo;
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                    conmand.Parameters.Add("@motivo", SqlDbType.VarChar).Value = motivo;
                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloFacturaEMasiva item = new modeloFacturaEMasiva();
                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.tipo_docum = Convert.ToString(dr["tipo_docum"]);
                        item.serie_docum = Convert.ToString(dr["serie_docum"]);
                        item.nro_docum = Convert.ToString(dr["nro_docum"]);
                        item.dni_cliente = Convert.ToString(dr["dni_cliente"]);
                        item.socio_negocio = Convert.ToInt64(dr["socio_negocio"]);
                        item.razon_social = Convert.ToString(dr["razon_social"]);
                        item.direccion = Convert.ToString(dr["direccion"]);
                        item.correo = Convert.ToString(dr["correo"]);
                        item.terminos_pago = Convert.ToString(dr["terminos_pago"]);
                        item.cod_termino = Convert.ToString(dr["cod_termino"]);
                        item.fecha_emision = Convert.ToDateTime(dr["fecha_emision"]);
                        item.fecha_vencimiento = Convert.ToDateTime(dr["fecha_vencimiento"]);
                        item.vendedor = Convert.ToString(dr["vendedor"]);
                        item.moneda = Convert.ToString(dr["moneda"]);
                        item.observaciones = Convert.ToString(dr["observaciones"]);
                        item.linea_pro = Convert.ToInt64(dr["linea_pro"]);
                        item.articulo = Convert.ToString(dr["articulo"]);
                        item.descripcion2 = Convert.ToString(dr["descripcion2"]);
                        item.cant_pro = Convert.ToDecimal(dr["cant_pro"]);
                        item.precio_unit = Convert.ToDecimal(dr["precio_unit"]);
                        item.porc_desc = Convert.ToDecimal(dr["porc_desc"]);
                        item.estado_fac = Convert.ToString(dr["estado_fac"]);
                        item.fecha_carga = Convert.ToDateTime(dr["fecha_carga"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.cod_vendedor = Convert.ToString(dr["cod_vendedor"]);
                        item.cod_moneda = Convert.ToString(dr["cod_moneda"]);
                        item.cod_articulo = Convert.ToString(dr["cod_articulo"]);
                        item.cod_suc_cli = Convert.ToString(dr["cod_suc_cli"]);
                        lista.Add(item);

                    }

                    return lista;

                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "BuscarNDFinancieraXDocum", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }
        //TRAE NC ACTIVA PARA PROCESR DENDIENDO DEL TIPO--top 1
        public modeloFacturaEMasiva BuscarNDActiva(string usuario, string cod_emp, string tipo)
        {
            try
            {
                stringConexionERP = conexion_erp.ConsultaConexionERP(cod_emp, usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    modeloFacturaEMasiva clientes_suc = new modeloFacturaEMasiva();
                    string consulta = ("SELECT TOP 1 nro_docum, serie_docum,fecha_carga, nro_trans, tipo_docum from wmh_cargaMasiva where estado_fac='A' and razon_social =@tipo and tipo_docum in('1','2','3')");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        clientes_suc.nro_docum = Convert.ToString(dr["nro_docum"]);
                        clientes_suc.serie_docum = Convert.ToString(dr["serie_docum"]);
                        clientes_suc.fecha_carga = Convert.ToDateTime(dr["fecha_carga"]);
                        clientes_suc.nro_trans = Convert.ToString(dr["nro_trans"]);
                        clientes_suc.motivo = Convert.ToString(dr["tipo_docum"]);

                    }
                    return clientes_suc;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(usuario, metodo, "BuscarNDActiva", e.ToString(), DateTime.Now, cod_emp);
                return null;
            }
        }
        //Total de nc financieras a procesar mandar tipo es decir normales o electronicas
        public List<modeloFacturaEMasiva> TotalNDFinancieras(string ArtB__usuario, string ArtB__cod_emp, string tipo)
        {
            try
            {
                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    List<modeloFacturaEMasiva> lista = new List<modeloFacturaEMasiva>();

                    string consulta = "SELECT DISTINCT nro_docum, serie_docum,fecha_carga from wmh_cargaMasiva where estado_fac='A' and razon_social =@tipo and tipo_docum in('1','2','3')";
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloFacturaEMasiva item = new modeloFacturaEMasiva();
                        item.nro_docum = Convert.ToString(dr["nro_docum"]);
                        item.fecha_carga = Convert.ToDateTime(dr["fecha_carga"]);
                        item.serie_docum = Convert.ToString(dr["serie_docum"]);

                        lista.Add(item);

                    }

                    return lista;

                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "TotalNDFinancieras", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }

        //Total de nc financieras a procesar mandar tipo es decir normales o electronicas
        public List<modeloFacturaEMasiva> TotalNDAnulacion(string ArtB__usuario, string ArtB__cod_emp, string tipo)
        {
            try
            {
                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    List<modeloFacturaEMasiva> lista = new List<modeloFacturaEMasiva>();

                    string consulta = "SELECT DISTINCT nro_docum, serie_docum,fecha_carga from wmh_cargaMasiva where estado_fac='A' and razon_social =@tipo and tipo_docum ='4'";
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloFacturaEMasiva item = new modeloFacturaEMasiva();
                        item.nro_docum = Convert.ToString(dr["nro_docum"]);
                        item.fecha_carga = Convert.ToDateTime(dr["fecha_carga"]);
                        item.serie_docum = Convert.ToString(dr["serie_docum"]);

                        lista.Add(item);

                    }

                    return lista;

                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, " TotalNDAnulacion", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }
        //Eliminar todas las nd por anulacin es estado A
        public string EliminarNDMasivaAnulacion(string cod_emp, string usuario_mod)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(cod_emp, usuario_mod);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    string delete = "DELETE FROM wmh_cargaMasiva where estado_fac ='A' and tipo_docum='4' and razon_social in('NDVE', 'NDV')";//Motivo DS  4 por anulación
                    SqlCommand conmand = new SqlCommand(delete, cn);
                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "";

                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "EliminarNDMasivaAnulacion", e.ToString(), DateTime.Now, usuario_mod);
                return e.ToString();
            }
        }

        public string EliminarNDMasivaFinanciera(string cod_emp, string usuario_mod)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(cod_emp, usuario_mod);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    string delete = "DELETE FROM wmh_cargaMasiva where estado_fac ='A' and tipo_docum in('1','2','3')and razon_social in('NDVE', 'NDV')";//Motivo DS  4 por anulación
                    SqlCommand conmand = new SqlCommand(delete, cn);
                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "";

                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "EliminarNDMasivaFinanciera", e.ToString(), DateTime.Now, usuario_mod);
                return e.ToString();
            }
        }
    }
}
