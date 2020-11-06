﻿using CapaDatos.Modelos;

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
    public class MasivoNCFinanciera
    {
        //Leer tabla wmh_cargafaturas
        modeloFacturasPagos modeloTiposPagos = new modeloFacturasPagos(); //Modelo tipos de pagos
        public List<modeloFacturasPagos> listaTiposPagos = null;

        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "MasivoNCFinanciera.cs";
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
        public string ResF_tipo = "C";
        public string CC__cod_dpto = "0";
        public string Ven__cod_tipotit = "clientes";
        public string Ven__cod_dgi = "0";
        public string Ven__fono = "0";
        public string tipo_factura;
        string stringConexionERP = "";// Aqui va la consulta de la table de parametros conexion_erp
        string nro_trans_padre = null;
        ValidarParametrizacionFactura conexion_erp = new ValidarParametrizacionFactura();
        //____________________________________________________PROCESO NC FINANCIERA CARGA MASIVA________________________________________________
        public string ProcesarNotaCreditoFinanciera(string Ccf_usuario, string Ccf_cod_emp, string nro_docum, string serie,  string cod_suc_emp, string tipo_nc)
        {
            try
            {
                string error = null;
                List<modeloFacturaEMasiva> lista = new List<modeloFacturaEMasiva>();

                 lista = BuscarNCFinancieraXDocum(Ccf_usuario, Ccf_cod_emp, nro_docum, serie,tipo_nc.Trim());

                //Insertar en la cabecera de nc
                error = InsertarCabecera(Ccf_usuario, Ccf_cod_emp, nro_docum, serie, lista, cod_suc_emp, tipo_nc);
                if (string.IsNullOrEmpty(error))
                {
                    error = InsertarDetalle(Ccf_usuario, Ccf_cod_emp, lista);
                    if (string.IsNullOrEmpty(error))
                    {
                        ModeloDetalleFactura = new List<ModeloDetalleFactura>();
                        //Finalizar factura
                        error = FinalizarNCFinanciera(Ccf_usuario, Ccf_cod_emp, serie, nro_docum);
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ProcesarNotaCreditoFinanciera", e.ToString(), DateTime.Now, Ccf_usuario);
                return e.ToString();
            }
        }

        public string FinalizarNCFinanciera(string AmUsrLog, string ComPwm, string serie, string nro_docum)
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

                if (conscabcera.tipo == "NCME" || conscabcera.tipo=="NCVE")
                {

                    if (respuestaConfirmacionFAC == "")
                    {

                        //AVERIGUAR LA VERSION DE NC QUE USA
                        string respuesta = "";
                        if (Modelowmspclogo.version_fe == "1")
                        {
                            ConsumoRestNCFinV2 consumoRest = new ConsumoRestNCFinV2();
                            respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", "NC", conscabcera.nro_trans, nro_trans_padre);
                        }
                        else
                        {
                            ConsumoRestNCFinV3 consumoRest = new ConsumoRestNCFinV3();
                            respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", "NC", conscabcera.nro_trans, nro_trans_padre);
                        }

                        if (respuesta == "")
                        {
                           
                            GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "F");
                            ActualizarEstadoNCF(AmUsrLog, ComPwm, nro_docum.Trim(), serie.Trim(), "P", conscabcera.tipo.Trim());//ESTADO PROCESADO
                          
                        }
                        else
                        {
                            GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "C");
                            ActualizarEstadoNCF(AmUsrLog, ComPwm, nro_docum.Trim(), serie.Trim(), "P", conscabcera.tipo.Trim());//ESTADO PROCESADO

                        }
                    }

                    else
                    {
                        GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "C");
                        ActualizarEstadoNCF(AmUsrLog, ComPwm, nro_docum.Trim(), serie.Trim(), "P", conscabcera.tipo.Trim());//ESTADO PROCESADO
                        error = respuestaConfirmacionFAC;
                    }
                }
                else
                {
                    if (respuestaConfirmacionFAC == "")
                    {

                        ActualizarEstadoNCF(AmUsrLog, ComPwm, nro_docum.Trim(), serie.Trim(), "P", conscabcera.tipo.Trim());//ESTADO PROCESADO
                    }
                    else
                    {
                        ActualizarEstadoNCF(AmUsrLog, ComPwm, nro_docum.Trim(), serie.Trim(), "P", conscabcera.tipo.Trim());//ESTADO PROCESADO
                        error = respuestaConfirmacionFAC;
                    }
                }
                return error;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "FinalizarNCFinanciera", e.ToString(), DateTime.Now, AmUsrLog);
                return e.ToString();
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

        public string  InsertarCabecera(string AmUsrLog, string ComPwm, string nro_docum, string serie, List<modeloFacturaEMasiva> lista, string cod_sucursal, string tipo_nc)
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
                listaRes = ConsultaResolucion.ConsultaResolusionXSucursalNC(AmUsrLog, ComPwm, ResF_estado, ResF_serie, ResF_tipo, cod_sucursal.Trim());
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
                cabecerafactura.cod_proc_aud = "RCOMNCRED";
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
        //---------------------------------------------------------FIN PROCESO NC------------------------------------------------------------
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
                listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1,"", Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);

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
        //Inseratr notas de credito canorus
        //Leer tabla wmh_cargaMasiva en canorus Factura de venta
        public string InsertarNCMasiva(modeloFacturaEMasiva item)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(item.cod_emp, item.usuario_mod);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    string insert = "INSERT INTO  wmh_cargaMasiva    (fecha_emision, nro_docum, serie_docum,dni_cliente,socio_negocio, correo, terminos_pago,cod_termino,fecha_vencimiento,vendedor,cod_vendedor, observaciones,moneda,cod_moneda ,linea_pro,articulo,cod_articulo,descripcion2,cant_pro,precio_unit,estado_fac,usuario_mod,fecha_carga,porc_desc,cod_suc_cli,tipo_docum, razon_social )values (@fecha_emision,@nro_docum, @serie_docum,@dni_cliente,@socio_negocio, @correo,@terminos_pago,@cod_termino,@fecha_vencimiento, @vendedor, @cod_vendedor, @observaciones,@moneda,@cod_moneda ,@linea_pro,@articulo,@cod_articulo,@descripcion2,@cant_pro,@precio_unit,@estado_fac,@usuario_mod,@fecha_carga,@porc_desc,@cod_suc_cli,@tipo_docum, @razon_social)";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                   // conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = item.cod_cliente.Trim();
                    conmand.Parameters.Add("@fecha_emision", SqlDbType.Date).Value = item.fecha_emision;
                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = item.nro_docum.Trim();
                    conmand.Parameters.Add("@serie_docum", SqlDbType.VarChar).Value = item.serie_docum.Trim();
                    conmand.Parameters.Add("@dni_cliente", SqlDbType.VarChar).Value = item.dni_cliente.Trim();
                    conmand.Parameters.Add("@socio_negocio", SqlDbType.VarChar).Value = item.cod_cliente.Trim();
                    conmand.Parameters.Add("@correo", SqlDbType.VarChar).Value = item.correo.Trim();
                    conmand.Parameters.Add("@terminos_pago", SqlDbType.VarChar).Value = item.terminos_pago.Trim();
                    conmand.Parameters.Add("@cod_termino", SqlDbType.VarChar).Value = item.cod_termino.Trim();
                    conmand.Parameters.Add("@fecha_vencimiento", SqlDbType.VarChar).Value = item.fecha_vencimiento;
                    conmand.Parameters.Add("@vendedor", SqlDbType.VarChar).Value = item.cod_vendedor.Trim();
                    conmand.Parameters.Add("@cod_vendedor", SqlDbType.VarChar).Value = item.cod_vendedor.Trim();
                    conmand.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = item.observaciones.Trim();
                    conmand.Parameters.Add("@moneda", SqlDbType.VarChar).Value = item.moneda.Trim();
                    conmand.Parameters.Add("@cod_moneda", SqlDbType.VarChar).Value = item.moneda.Trim();
                    conmand.Parameters.Add("@linea_pro", SqlDbType.VarChar).Value = item.linea_pro;
                    conmand.Parameters.Add("@articulo", SqlDbType.VarChar).Value = item.cod_articulo.Trim();
                    conmand.Parameters.Add("@cod_articulo", SqlDbType.VarChar).Value = item.cod_articulo.Trim();
                    conmand.Parameters.Add("@descripcion2", SqlDbType.VarChar).Value = item.descripcion2.Trim();
                    conmand.Parameters.Add("@cant_pro", SqlDbType.Decimal).Value = item.cant_pro;
                    conmand.Parameters.Add("@precio_unit", SqlDbType.Decimal).Value = item.precio_unit;
                    conmand.Parameters.Add("@estado_fac", SqlDbType.VarChar).Value = item.estado_fac;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = item.usuario_mod;
                    conmand.Parameters.Add("@fecha_carga", SqlDbType.VarChar).Value = item.fecha_carga;
                    conmand.Parameters.Add("@porc_desc", SqlDbType.Decimal).Value = item.porc_desc;
                    conmand.Parameters.Add("@cod_suc_cli", SqlDbType.VarChar).Value = item.cod_suc_cli.Trim();
                    conmand.Parameters.Add("@tipo_docum", SqlDbType.VarChar).Value = item.motivo.Trim();//Solo para nc
                    conmand.Parameters.Add("@razon_social", SqlDbType.VarChar).Value = item.razon_social.Trim();//Solo para nc

                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "";

                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(item.cod_emp, metodo, "InsertarNCMasiva", e.ToString(), DateTime.Now, item.usuario_mod);
                return e.ToString();
            }
        }

        //Eliminar todas las nc FINANCIERAS que estan en estado A
        public string EliminarNCMasivaFinanciera(string cod_emp, string usuario_mod)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(cod_emp, usuario_mod);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    string delete = "DELETE FROM wmh_cargaMasiva where estado_fac ='A' and razon_social in('NCME', 'NCM')";
                    SqlCommand conmand = new SqlCommand(delete, cn);

                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "";

                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "EliminarNCMasivaFinanciera", e.ToString(), DateTime.Now, usuario_mod);
                return e.ToString();
            }
        }


        //Eliminar todas las nc devolucion que estan en estado A
        public string EliminarNCMasivaDevolucion(string cod_emp, string usuario_mod)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(cod_emp, usuario_mod);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    string delete = "DELETE FROM wmh_cargaMasiva where estado_fac ='A' and razon_social in('NCVE', 'NCV')";
                    SqlCommand conmand = new SqlCommand(delete, cn);

                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "";

                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "EliminarNCMasivaDevolucion", e.ToString(), DateTime.Now, usuario_mod);
                return e.ToString();
            }
        }
        //Eliminar todas las nc por anulacin es estado A
        public string EliminarNCMasivaAnulacion(string cod_emp, string usuario_mod)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(cod_emp, usuario_mod);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    string delete = "DELETE FROM wmh_cargaMasiva where estado_fac ='A' and tipo_docum='2' and razon_social in('NCVE', 'NCV')";
                    SqlCommand conmand = new SqlCommand(delete, cn);
                    int dr = conmand.ExecuteNonQuery();
                    cn.Close();
                    return "";

                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "EliminarNCMasivaAnulacion", e.ToString(), DateTime.Now, usuario_mod);
                return e.ToString();
            }
        }
        //Total de nc devolucion y anuacion a procesar mandar tipo es decir normales o electronicas
        public List<modeloFacturaEMasiva> TotalNCDevAnulacion(string ArtB__usuario, string ArtB__cod_emp, string tipo, string tipo_docum)
        {
            try
            {
                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    List<modeloFacturaEMasiva> lista = new List<modeloFacturaEMasiva>();

                    string consulta = "SELECT DISTINCT nro_docum, serie_docum,fecha_carga from wmh_cargaMasiva where estado_fac='A' and razon_social =@tipo and tipo_docum= @tipo_docum";
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                    conmand.Parameters.Add("@tipo_docum", SqlDbType.VarChar).Value = tipo_docum;
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

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, " TotalNCDevAnulacion", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }
        //Total de nc financieras a procesar mandar tipo es decir normales o electronicas
        public List<modeloFacturaEMasiva> TotalNCFinancieras(string ArtB__usuario, string ArtB__cod_emp, string tipo)
        {
            try
            {
                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    List<modeloFacturaEMasiva> lista = new List<modeloFacturaEMasiva>();

                    string consulta = "SELECT DISTINCT nro_docum, serie_docum,fecha_carga from wmh_cargaMasiva where estado_fac='A' and razon_social =@tipo";
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

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "TotalNCFinancieras", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }

        //TRAE NC ACTIVA PARA PROCESR DENDIENDO DEL TIPO--top 1
        public modeloFacturaEMasiva BuscarNCActiva(string usuario, string cod_emp, string tipo)
        {
            try
            {
                stringConexionERP = conexion_erp.ConsultaConexionERP(cod_emp,usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    modeloFacturaEMasiva clientes_suc = new modeloFacturaEMasiva();
                    string consulta = ("SELECT TOP 1 nro_docum, serie_docum,fecha_carga, nro_trans from wmh_cargaMasiva where estado_fac='A' and razon_social =@tipo");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                    
                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        clientes_suc.nro_docum = Convert.ToString(dr["nro_docum"]);
                        clientes_suc.serie_docum = Convert.ToString(dr["serie_docum"]);
                        clientes_suc.fecha_carga = Convert.ToDateTime(dr["fecha_carga"]);
                        clientes_suc.nro_trans = Convert.ToString(dr["nro_trans"]);
                       
                    }
                    return clientes_suc;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(usuario, metodo, "BuscarNCActiva", e.ToString(), DateTime.Now, cod_emp);
                return null;
            }
        }

        //TRAE NC ACTIVA PARA PROCESR DENDIENDO DEL TIPO--top 1 y motivo reconoce anulacion y devolcion
        public modeloFacturaEMasiva BuscarNCActivaAnulacionDevolucion(string usuario, string cod_emp, string tipo, string tipo_docum)
        {
            try
            {
                stringConexionERP = conexion_erp.ConsultaConexionERP(cod_emp, usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    modeloFacturaEMasiva clientes_suc = new modeloFacturaEMasiva();
                    string consulta = ("SELECT TOP 1 nro_docum, serie_docum,fecha_carga, nro_trans from wmh_cargaMasiva where estado_fac='A' and razon_social =@tipo and tipo_docum=@tipo_docum");
                    SqlCommand conmand = new SqlCommand(consulta, cn);


                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                    conmand.Parameters.Add("@tipo_docum", SqlDbType.VarChar).Value = tipo_docum;
                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        clientes_suc.nro_docum = Convert.ToString(dr["nro_docum"]);
                        clientes_suc.serie_docum = Convert.ToString(dr["serie_docum"]);
                        clientes_suc.fecha_carga = Convert.ToDateTime(dr["fecha_carga"]);
                        clientes_suc.nro_trans = Convert.ToString(dr["nro_trans"]);

                    }
                    return clientes_suc;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(usuario, metodo, "BuscarNCActivaAnulacionDevolucion", e.ToString(), DateTime.Now, cod_emp);
                return null;
            }
        }
        //Buscar NC POR NRO_TRANS
        //Total de nc financieras a procesar mandar tipo es decir normales o electronicas
        public List<modeloFacturaEMasiva> BuscarNCFinancieraXDocum(string ArtB__usuario, string ArtB__cod_emp, string nro_docum, string prefijo, string tipo)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    List<modeloFacturaEMasiva> lista = new List<modeloFacturaEMasiva>();

                    string consulta = "SELECT * from wmh_cargaMasiva where estado_fac ='A' and nro_docum =@nro_docum and serie_docum = @serie_docum and razon_social=@tipo";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = nro_docum;
                    conmand.Parameters.Add("@serie_docum", SqlDbType.VarChar).Value = prefijo;
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
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

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ListalFacturas", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }
        //Actualizar estado de nc financiera en wmh_cargaMasiva por nro_prefijo
        public string ActualizarEstadoNCF(string ArtB__usuario, string ArtB__cod_emp, string nro_docum,string prefijo, string estado_fac, string tipo_nc)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {

                    string consulta = "UPDATE wmh_cargaMasiva SET estado_fac=@estado_fac WHERE nro_docum =@nro_docum and serie_docum=@serie_docum AND estado_fac='A' and razon_social =@tipo";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = nro_docum;
                    conmand.Parameters.Add("@serie_docum", SqlDbType.VarChar).Value = prefijo;
                    conmand.Parameters.Add("@estado_fac", SqlDbType.VarChar).Value = estado_fac;
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo_nc;
                    int dr = conmand.ExecuteNonQuery();
                    return "";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ActualizarEstadoNCF", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }
        //Actualizar estado de ActualizarEstadoNCAnulacionDevolucion en wmh_cargaMasiva por nro_prefijo
        public string ActualizarEstadoNCAnulacionDevolucion(string ArtB__usuario, string ArtB__cod_emp, string nro_docum, string prefijo, string estado_fac, string tipo_nc, string motivo)
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

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ActualizarEstadoNCAnulacionDevolucion", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }

        //Actualizar estados de nc financiera en wmh_cargaMasiva
        public string ActualizarEstadosNCFinanciera(string ArtB__usuario, string ArtB__cod_emp,  string estado_fac, string tipo)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);
                using (cn = conexion.genearConexionERP(stringConexionERP))
                {

                    string consulta = "UPDATE wmh_cargaMasiva SET estado_fac = @estado_fac where estado_fac = 'A' and razon_social = @tipo ";
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

        public string ActualizarEstadosNCDevAnu(string ArtB__usuario, string ArtB__cod_emp, string estado_fac, string tipo, string motivo)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);
                using (cn = conexion.genearConexionERP(stringConexionERP))
                {

                    string consulta = "UPDATE wmh_cargaMasiva SET estado_fac = @estado_fac where estado_fac = 'A' and razon_social = @tipo and tipo_docum=@tipo_docum ";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                    conmand.Parameters.Add("@estado_fac", SqlDbType.VarChar).Value = estado_fac;
                    conmand.Parameters.Add("@tipo_docum", SqlDbType.VarChar).Value = motivo;
                    int dr = conmand.ExecuteNonQuery();
                    return "";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ActualizarEstadosNCDevAnu", e.ToString(), DateTime.Now, ArtB__usuario);
                return e.ToString();
            }
        }

    }
}
