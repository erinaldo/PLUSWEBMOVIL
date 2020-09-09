using CapaDatos;
using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using CapaProceso.RestCliente;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.FacturaMasiva
{
    public class NotaCreditoMasivaE
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "CargaFacturaMasiva.cs";
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

        List<ModeloDetalleFactura> listaConsDetalle = null;
        Consultawmtfacturasdet ConsultaDeta = new Consultawmtfacturasdet();
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
        public string nro_tras_padre;
        ValidarParametrizacionFactura conexion_erp = new ValidarParametrizacionFactura();
        public string ProcesarNotaCredito(string Ccf_usuario, string Ccf_cod_emp, string desde, string hasta, string cod_sucursal)
        {
            try
            {

                List<modeloFacturaEMasiva> lista = new List<modeloFacturaEMasiva>();

                List<modeloFacturaEMasiva> listaAux = new List<modeloFacturaEMasiva>();
                lista = TotalFacturasNC(Ccf_usuario, Ccf_cod_emp, desde, hasta, cod_sucursal);

                foreach (var item in lista)
                {

                    //Insertar en la cabecera de la factura
                    InsertarCabecera(Ccf_usuario, Ccf_cod_emp, item.nro_trans, cod_sucursal.Trim());
                    //Referencia cruzada ---insertar detallle factura
                    GuardarDetalle(Ccf_cod_emp, Ccf_usuario, item.nro_trans);

                    ModeloDetalleFactura = new List<ModeloDetalleFactura>();
                    //Finalizar factura
                    FinalizarFactura(Ccf_usuario, Ccf_cod_emp);
                    listaAux = null;
                }

                return "Carga Finalizada";
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscartaDatosFacturasMasivas", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }
        public void FinalizarFactura(string AmUsrLog, string ComPwm)
        {
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

            confirmarinsertar.nro_trans = conscabcera.nro_trans;
            confirmarinsertar.cod_emp = conscabcera.cod_emp;
            confirmarinsertar.usuario_mod = AmUsrLog;
            confirmarinsertar.fecha_mod = DateTime.Now;
            confirmarinsertar.nro_audit = conscabcera.nro_audit;

            respuestaConfirmacionFAC = ConfirmarFactura.ConfirmarFactura(confirmarinsertar);

            if (conscabcera.tipo == "NCVE")
            {

                if (respuestaConfirmacionFAC == "")
                {

                    //AVERIGUAR LA VERSION DE NC QUE USA
                    string respuesta = "";
                    if (Modelowmspclogo.version_fe == "1")
                    {
                        ConsumoRestNCFinV2 consumoRest = new ConsumoRestNCFinV2();
                        respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", "NC", conscabcera.nro_trans, nro_tras_padre);
                    }
                    else
                    {
                        ConsumoRestNCFinV3 consumoRest = new ConsumoRestNCFinV3();
                        respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", "NC", conscabcera.nro_trans, nro_tras_padre);
                    }




                    if (respuesta == "")
                    {
                        mensaje = "Nota credito fue procesada exitosamente";
                        GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "F");
                        GuardarCabezera.ActualizarEstadoFactura(nro_tras_padre, "N");
                    }
                    else
                    {
                        GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "C");
                        GuardarCabezera.ActualizarEstadoFactura(nro_tras_padre, "N");
                        mensaje = respuesta;

                    }
                }

                else
                {
                    GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "C");
                }
            }
            else
            {
                if (respuestaConfirmacionFAC == "")
                {
                    string men_fn = "Finalizado";
                    GuardarCabezera.ActualizarEstadoFactura(nro_tras_padre, "N");
                }
                else
                {
                    string men_fn = respuestaConfirmacionFAC;
                }
            }
        }
        public void InsertarCabecera(string AmUsrLog, string ComPwm, string Ccf_nro_trans, string cod_sucursal)
        {
            try
            {
                //Cargamos los datos de la factura
                listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, "", Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                    conscabcera = item;
                }
                nro_tras_padre = conscabcera.nro_trans;
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
                //TIPO FACTURA VTA----VTAE

                if (resolucion.tipo_fac == "S")
                {
                    tipo_factura = "NCVE";
                }
                else
                {
                    tipo_factura = "NCV";
                }

                //Procedimiento para actualizar email del titular
                /*  ModeloActualizarEmail.usuario = AmUsrLog;
                  ModeloActualizarEmail.empresa = ComPwm;
                  ModeloActualizarEmail.cod_tit = clientes.cod_tit.Trim();
                  ModeloActualizarEmail.parametro = "email";
                  ModeloActualizarEmail.valor = factura.correo;
                  ModeloActualizarEmail.sucursal = clientes.cod_sucursal;
                  //Envio de datos para actualizar email en RP  
                  ConsultaDatosTitular.ActualizarDatosTitulares(ModeloActualizarEmail);*/

                DateTime Fecha = DateTime.Today;
                cabecerafactura.cod_cliente = conscabcera.cod_cliente;
                cabecerafactura.dia = string.Format("{0:00}", Fecha.Day);
                cabecerafactura.mes = string.Format("{0:00}", Fecha.Month);
                cabecerafactura.anio = Fecha.Year.ToString();
                cabecerafactura.fec_doc = Fecha.ToString();
                cabecerafactura.serie_docum = resolucion.serie_docum;
                cabecerafactura.cod_ccostos = conscabcera.cod_ccostos;
                cabecerafactura.cod_vendedor = conscabcera.cod_vendedor;
                cabecerafactura.cod_fpago = conscabcera.cod_fpago;
                cabecerafactura.observaciones = "ANULACION FACTURA: " + conscabcera.observacion;
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
                cabecerafactura.tipo = tipo_factura;// "NCVE";
                cabecerafactura.porc_descto = Convert.ToDecimal("0.00");
                cabecerafactura.descuento = Convert.ToDecimal("0.00");
                cabecerafactura.diar = "0";
                cabecerafactura.mesr = "0";
                cabecerafactura.anior = "0";
                cabecerafactura.cod_proc_aud = "RCOMNCRED";
                cabecerafactura.cod_sucursal =cod_sucursal;
                cabecerafactura.nro_pedido = conscabcera.nro_pedido;
                cabecerafactura.nro_trans_padre = conscabcera.nro_trans;
                cabecerafactura.mot_nce = "2"; //Motivo DS  1 por anulación
                cabecerafactura.cod_suc_cli = conscabcera.cod_suc_cli;
                cabecerafactura.desctos_rcgos = 0; //Enviar siempre 0 al insetar
                string error = GuardarCabezera.InsertarCabezeraNotaCredito(cabecerafactura);
                if (string.IsNullOrEmpty(error))
                {

                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "InsertarCabecera", ex.ToString(), DateTime.Now, AmUsrLog);


            }
        }

        //Insertar Detalle
        public void InsertarDetalle(string AmUsrLog, string ComPwm, string nor_trans)
        {
            try
            {
                /*
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
                    ModeloDetalleFactura.Add(item);

                    referencia_C.EliminarArticuloTem(AmUsrLog, ComPwm, valor_asignado); //eliminar de tabla temporal
                    item = null;
                }
                GuardarDetalle(ComPwm, AmUsrLog, ModeloDetalleFactura);*/
            }
            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "InsertarDetalle", ex.ToString(), DateTime.Now, AmUsrLog);

            }
        }

        //Insertar detalle detalle en pwm
        public modelowmtfacturascab GuardarDetalle(string ComPwm, string AmUsrLog, string nro_trans)
        {
            try
            {
                string error;
                listaConsDetalle = ConsultaDeta.ConsultaDetalleFacura(nro_trans);
                //Busca en gv_producto todos los items añadidos que estan en la variable de session detalle
                ModeloDetalleFactura = new List<ModeloDetalleFactura>();
                ModeloDetalleFactura = (listaConsDetalle as List<ModeloDetalleFactura>);

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

                    }

                }

                return conscabcera;
            }
            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "GuardarDetalle", ex.ToString(), DateTime.Now, AmUsrLog);
                return null;

            }
        }
        public List<modeloFacturaEMasiva> TotalFacturasNC(string ArtB__usuario, string ArtB__cod_emp, string desde, string hasta, string cod_suc)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloFacturaEMasiva> lista = new List<modeloFacturaEMasiva>();

                    string consulta = "SELECT * FROM wmt_facturas_cab WHERE CAST(nro_docum AS numeric) BETWEEN @desde AND @hasta AND cod_emp =@cod_emp AND cod_sucursal = @cod_suc AND cod_docum ='FV' AND estado ='F' ORDER BY CAST(nro_docum AS numeric)";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = ArtB__cod_emp;
                    conmand.Parameters.Add("@desde", SqlDbType.VarChar).Value = desde;
                    conmand.Parameters.Add("@hasta", SqlDbType.VarChar).Value = hasta;
                    conmand.Parameters.Add("@cod_suc", SqlDbType.VarChar).Value = cod_suc;
                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloFacturaEMasiva item = new modeloFacturaEMasiva();
                        item.nro_docum = Convert.ToString(dr["nro_docum"]);
                        item.serie_docum = Convert.ToString(dr["serie_docum"]);
                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        lista.Add(item);

                    }

                    return lista;

                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "TotalFacturasNC", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }
        public modelowmtfacturascab BuscarCabecera(string ComPwm, string AmUsrLog)
        {

            try
            {
                //Busca el nro de auditoria para poder insertar el detalle factura
                //consulta nro_auditoria de la cabecera
                string Ccf_nro_trans = valor_asignado;

                listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, "nc", Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);

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
