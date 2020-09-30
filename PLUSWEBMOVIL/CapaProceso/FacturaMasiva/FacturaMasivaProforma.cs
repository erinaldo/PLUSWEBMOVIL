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
  public   class FacturaMasivaProforma
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "FacturaMasivaProforma.cs";
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

        ConsultaProformas ConsProformasM = new ConsultaProformas();
        modelowmtproformascab CabeceraProformaMasiva = new modelowmtproformascab();
        List<modeloproformadetalle> ListaDetalleProforma = null;
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
        public string ResF_tipo = "F";
        public string CC__cod_dpto = "0";
        public string Ven__cod_tipotit = "clientes";
        public string Ven__cod_dgi = "0";
        public string Ven__fono = "0";
        public string Tipo_proforma = "PV";
        public string tipo_factura = null;

        public string GenerarFactura(string Ccf_usuario, string Ccf_cod_emp, string cod_sucursal, string cod_cliente, string nro_trans_pro, string cod_moneda)
        {
            try
            {
                string error = null;
            
                //Insertar en la cabecera de la factura
               error =  InsertarCabecera(Ccf_usuario, Ccf_cod_emp, cod_cliente, cod_sucursal, nro_trans_pro,cod_moneda );
                if(string.IsNullOrEmpty(error))
                {
                     //Referencia cruzada ---insertar detallle factura
                     error= InsertarDetalle(Ccf_usuario, Ccf_cod_emp, nro_trans_pro);
                    if (string.IsNullOrEmpty(error))
                    {

                        ModeloDetalleFactura = new List<ModeloDetalleFactura>();
                        //Finalizar factura
                       error= FinalizarFactura(Ccf_usuario, Ccf_cod_emp, nro_trans_pro.Trim());
                        if (!string.IsNullOrEmpty(error))
                        {
                            return error;
                        }
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "GenerarFactura", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        //Insertar cabecera----------------------------FACTURACION MASIVA MEDIANTE PROFORMA--------------------------------

        public string  InsertarCabecera(string AmUsrLog, string ComPwm, string cod_cliente, string cod_sucursal, string nro_trans_pro, string cod_moneda)
        {
            try
            {
                //obtener numero de transaccion
                nrotrans = ConsultaNroTran.ConsultaNumeradores(numerador);
                valor_asignado = nrotrans.valor_asignado;

                //CABECERA DE LA PROFORMA 
                 CabeceraProformaMasiva = ConsProformasM.ProformasMasivasE(AmUsrLog, ComPwm, Tipo_proforma, nro_trans_pro.Trim(), "A");

                //LIsta Resolucion facturas(serie documento)
                listaRes = ConsultaResolucion.ConsultaResolusionXSucursal(AmUsrLog, ComPwm, ResF_estado, ResF_serie, ResF_tipo, cod_sucursal);
                resolucion = null;
                foreach (modelowmspcresfact item in listaRes)
                {
                    resolucion = item;
                    break;
                }
                if (resolucion.tipo_fac == "S")
                {
                     tipo_factura = "VTAE";

                }
                else
                {
                    
                     tipo_factura = "VTA"; 
                }

                // centro costos
                listaCostos = ConsultaCCostos.ConsultaCCostos(AmUsrLog, ComPwm, CC__cod_dpto);

                ccostos = null;
                foreach (modelowmspcccostos items in listaCostos)
                {
                    ccostos = items;
                    break;
                }

                //obtener cliente
                string error = "";
                string Ven__cod_tit = cod_cliente;

                listaClientes = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi, "0");

                clientes = null;
                foreach (modelowmspctitulares item in listaClientes)
                {
                    clientes = item;
                    break;
                }

                DateTime Fecha = DateTime.Now;
                cabecerafactura.cod_cliente = cod_cliente.Trim();
                cabecerafactura.dia = string.Format("{0:00}", Fecha.Day);
                cabecerafactura.mes = string.Format("{0:00}", Fecha.Month);
                cabecerafactura.anio = Fecha.Year.ToString();
                cabecerafactura.fec_doc = Fecha.ToString();
                cabecerafactura.serie_docum = resolucion.serie_docum;
                cabecerafactura.cod_ccostos = ccostos.cod_dpto;
                cabecerafactura.cod_vendedor = CabeceraProformaMasiva.cod_vendedor;
                cabecerafactura.cod_fpago = CabeceraProformaMasiva.cod_fpago;
                cabecerafactura.observaciones = CabeceraProformaMasiva.observaciones;
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
                cabecerafactura.cod_moneda = cod_moneda.Trim();// CabeceraProformaMasiva.cod_moneda; //cargar excel
                cabecerafactura.tipo = tipo_factura; //tipo vtae electronicas
                cabecerafactura.porc_descto = Convert.ToDecimal("0.00");
                cabecerafactura.descuento = Convert.ToDecimal("0.00");
                cabecerafactura.diar = "0";
                cabecerafactura.mesr = "0";
                cabecerafactura.anior = "0";
                cabecerafactura.cod_proc_aud = "RCOMFACT";
                cabecerafactura.cod_sucursal = cod_sucursal;
                cabecerafactura.nro_pedido = CabeceraProformaMasiva.nro_docum; //numero de proforma
                cabecerafactura.cod_suc_cli = clientes.cod_sucursal;
                cabecerafactura.desctos_rcgos = 0;
                error = GuardarCabezera.InsertarCabezeraFactura(cabecerafactura);
                return error;
            }
            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "InsertarCabecera", ex.ToString(), DateTime.Now, AmUsrLog);
                return ex.ToString();

            }
        }

        //Insertar Detalle
        public string  InsertarDetalle(string AmUsrLog, string ComPwm, string nro_trans_pro)
        {
            try
            {
                string error_det = null;
                modeloproformadetalle ModeloDetalle = new modeloproformadetalle();
                //Buscar detalle de proforma
                ListaDetalleProforma = ConsProformasM.DetalleProformasMasiva(AmUsrLog, ComPwm, nro_trans_pro.Trim());
                foreach (var proDet in ListaDetalleProforma)
                {
                    ModeloDetalle = proDet;


                    ModeloDetalleFactura item = new ModeloDetalleFactura();
                    articulo = null;
                    articulo = BuscarProducto(ComPwm, AmUsrLog, ModeloDetalle.cod_articulo.Trim());
                    //Elimino cualquier registro anterior
                    Articulos referencia_C = new Articulos();
                    referencia_C.EliminarArticuloTem(AmUsrLog, ComPwm, valor_asignado);
                    //Insertar el producto seleccionado
                    FacturaDetalle insertar_art = new FacturaDetalle();
                    insertar_art.InsertarArticuloTemp(valor_asignado, articulo.cod_articulo, valor_asignado, 0, ComPwm, AmUsrLog);

                    string cod_articulo2 = referencia_C.ReferenciaCArticulo(AmUsrLog, ComPwm, valor_asignado);

                    item.cod_articulo = ModeloDetalle.cod_articulo;
                    item.cod_articulo2 = cod_articulo2;
                    item.nom_articulo = articulo.nom_articulo; //Verificar cuando viene vacio no es permitido xpor ds
                    item.nom_articulo2 = ModeloDetalle.nom_articulo2;
                    item.cod_ccostos = "000";//ccostos.cod_dpto;  //Traer valor por defecto
                    item.cantidad = Convert.ToDecimal(ModeloDetalle.cantidad);
                    item.precio_unit = Convert.ToDecimal(ModeloDetalle.precio_unit);
                    item.porc_iva = Convert.ToDecimal(articulo.porc_impuesto);
                    item.porc_descto = ModeloDetalle.porc_descto;
                    item.cod_cta_cos = articulo.cod_cta_cos;
                    item.cod_cta_inve = articulo.cod_cta_inve;
                    item.cod_cta_vtas = articulo.cod_cta_vtas;
                    item.base_imp = Convert.ToDecimal(articulo.porc_aiu);
                    item.tasa_iva = articulo.cod_tasa_impu;
                    item.cod_concepret = articulo.cod_concepret;
                    ModeloDetalleFactura.Add(item);

                    referencia_C.EliminarArticuloTem(AmUsrLog, ComPwm, valor_asignado); //eliminar de tabla temporal
                    item = null;
                }
               return error_det= GuardarDetalle(ComPwm, AmUsrLog, ModeloDetalleFactura);
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

                //Insertar primero la cabecera
                // InsertarCabecera(ComPwm,AmUsrLog,listaD);
                //Busca el nro de auditoria
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

                    if (string.IsNullOrEmpty(error))
                    {

                    }
                    else
                    {
                        return error;
                    }
                }

                return error;
            }
            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "GuardarDetalle", ex.ToString(), DateTime.Now, AmUsrLog);
                return ex.ToString(); ;

            }
        }

        //FINALIZAR FACTURA
        public string FinalizarFactura(string AmUsrLog, string ComPwm, string nro_trans_pro)
        {
            try
            {
                string error_finalizar = null;
                ListaModelowmspclogo = consultaLogo.BuscartaLogo(ComPwm, AmUsrLog);
                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }
                //ValidarParametrosFactura();
                string mensaje;
                string respuestaConfirmacionFAC = "";
                //Boton Coonfirmar hace lo mismo que el salvar solo aumenta la insercion a la tabla wmt_facturas_ins
                conscabcera = null;
                conscabcera = BuscarCabecera(ComPwm, AmUsrLog);

                confirmarinsertar.nro_trans = conscabcera.nro_trans;
                confirmarinsertar.cod_emp = conscabcera.cod_emp;
                confirmarinsertar.usuario_mod = AmUsrLog;
                confirmarinsertar.fecha_mod = DateTime.Now;
                confirmarinsertar.nro_audit = conscabcera.nro_audit;

                respuestaConfirmacionFAC = ConfirmarFactura.ConfirmarFactura(confirmarinsertar);


                if (conscabcera.tipo.Trim() == "VTAE" || conscabcera.tipo.Trim() == "POSE")
                {
                    if (respuestaConfirmacionFAC == "")
                    {
                        string respuesta = "";
                        switch (Modelowmspclogo.version_fe.Trim()) //AVERIGUAR Q TIPO DE FACTURACION USA
                        {
                            case "1":
                                ConsumoRestFEV2 consumoRest1 = new ConsumoRestFEV2();
                                respuesta = consumoRest1.EnviarFactura(ComPwm, AmUsrLog, "C", conscabcera.tipo.Trim(), conscabcera.nro_trans);

                                break;
                            case "2":
                                ConsumoRestFEV3 consumoRest = new ConsumoRestFEV3();
                                respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", conscabcera.tipo.Trim(), conscabcera.nro_trans);
                                break;
                        }


                        if (respuesta == "")
                        {
                            mensaje = "Su factura fue procesada exitosamente";
                            GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "F");
                            //Cambiar a estado 'F'(procesado) en wmt_proformas_tit
                            ActualizarEstadoProformaTit(AmUsrLog, ComPwm, nro_trans_pro.Trim(), "F", conscabcera.cod_cliente.Trim());
                        }
                        else
                        {
                            GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "C");
                            //Cambiar a estado 'F'(procesado) en wmt_proformas_tit
                            ActualizarEstadoProformaTit(AmUsrLog, ComPwm, nro_trans_pro.Trim(), "F", conscabcera.cod_cliente.Trim());
                            return error_finalizar = respuesta;
                        }
                    }

                    else
                    {

                        //Cambiar a estado 'F'(procesado) en wmt_proformas_tit
                        ActualizarEstadoProformaTit(AmUsrLog, ComPwm, nro_trans_pro.Trim(), "F", conscabcera.cod_cliente.Trim());
                        return error_finalizar = respuestaConfirmacionFAC;
                    }
                }
                else
                {
                    if (respuestaConfirmacionFAC == "")
                    {
                        string men_fn = "Finalizado";
                        //Cambiar a estado 'F'(procesado) en wmt_proformas_tit
                        ActualizarEstadoProformaTit(AmUsrLog, ComPwm, nro_trans_pro.Trim(), "F", conscabcera.cod_cliente.Trim());
                    }
                    else
                    {
                        //Cambiar a estado 'F'(procesado) en wmt_proformas_tit
                        ActualizarEstadoProformaTit(AmUsrLog, ComPwm, nro_trans_pro.Trim(), "F", conscabcera.cod_cliente.Trim());
                        return error_finalizar = respuestaConfirmacionFAC;
                    }
                }
                return error_finalizar;
            }
            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "FinalizarFactura", ex.ToString(), DateTime.Now, AmUsrLog);
                return ex.ToString(); 
            }
        }
        //Actualizar estado proforma wmt_proformas_cab
        public string ActualizarEstadoProformaCab(string ArtB__usuario, string ArtB__cod_emp, string nro_trans, string estado_fac)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {


                    string consulta = "UPDATE wmt_proformas_cab SET estado=@estado_fac WHERE nro_trans =@nro_trans and cod_emp =@cod_emp";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.Parameters.Add("@estado_fac", SqlDbType.VarChar).Value = estado_fac;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = ArtB__cod_emp;
                  
                    int dr = conmand.ExecuteNonQuery();
                    return "";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ActualizarEstadoProformaCab", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }
        //Actualizar todas las proformas cuando de error
        public string ActualizarErrorProformaTit(string ArtB__usuario, string ArtB__cod_emp, string estado_fac, string nro_trans)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {


                    string consulta = "UPDATE wmt_proformas_tit SET estado=@estado_fac WHERE nro_trans=@nro_trans and cod_emp =@cod_emp ";
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.Parameters.Add("@estado_fac", SqlDbType.VarChar).Value = estado_fac;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = ArtB__cod_emp;

                    int dr = conmand.ExecuteNonQuery();
                    return "";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ActualizarErrorProformaTit", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }

        //Actualizar estado proforma wmt_proformas_tit
        public string ActualizarEstadoProformaTit(string ArtB__usuario, string ArtB__cod_emp, string nro_trans, string estado_fac, string cod_cliente)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {


                    string consulta = "UPDATE wmt_proformas_tit SET estado=@estado_fac WHERE nro_trans =@nro_trans and cod_emp =@cod_emp and cod_cliente =@cod_cliente ";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.Parameters.Add("@estado_fac", SqlDbType.VarChar).Value = estado_fac;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = ArtB__cod_emp;
                    conmand.Parameters.Add("@cod_cliente", SqlDbType.VarChar).Value = cod_cliente;
                    int dr = conmand.ExecuteNonQuery();
                    return "";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ActualizarEstadoProformaTit", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }

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
                
                listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, tipo_factura.Trim(), Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);

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
    }
}
