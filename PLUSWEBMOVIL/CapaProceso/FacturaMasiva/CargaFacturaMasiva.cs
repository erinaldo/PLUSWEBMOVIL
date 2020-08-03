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
   public  class CargaFacturaMasiva
    {
        //Leer tabla wmh_cargafaturas
        modeloFacturasPagos modeloTiposPagos = new modeloFacturasPagos(); //Modelo tipos de pagos
        public List<modeloFacturasPagos> listaTiposPagos = null;

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
        public string tipo_factura;
        string stringConexionERP = "";// Aqui va la consulta de la table de parametros conexion_erp
        ValidarParametrizacionFactura conexion_erp = new ValidarParametrizacionFactura();


        //Total de facturas a insertar 
        public List<modeloFacturaEMasiva> TotalFacturas(string ArtB__usuario, string ArtB__cod_emp)
        {
            try
            {
                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    List<modeloFacturaEMasiva> lista = new List<modeloFacturaEMasiva>();

                    string consulta = "SELECT DISTINCT nro_docum from wmh_cargaMasiva where estado_fac='A' ";
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                  
                   // conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = ArtB__usuario;
                    //conmand.Parameters.Add("@fecha_carga", SqlDbType.VarChar).Value = fecha_carga;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloFacturaEMasiva item = new modeloFacturaEMasiva();
                        item.nro_docum = Convert.ToString(dr["nro_docum"]);
             
                        lista.Add(item);

                    }

                    return lista;

                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "TotalFacturas", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }
        //Actuaizar estado tabla wmh_cargaMasiva
        public string ActualizarEstado(string ArtB__usuario, string ArtB__cod_emp, string nro_docum, string estado_fac)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                  

                    string consulta = "UPDATE wmh_cargaMasiva SET estado_fac=@estado_fac WHERE nro_docum =@nro_docum AND estado_fac='A' ";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = nro_docum;
                    conmand.Parameters.Add("@estado_fac", SqlDbType.VarChar).Value = estado_fac;
                    int dr = conmand.ExecuteNonQuery();
                    return "";


                }
                
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ActualizarEstado", e.ToString(), DateTime.Today, ArtB__usuario);
                return null;
            }
        }

        //Actuaizar estado tabla wmh_facturas_pgs
        public string ActualizarEstadoFPagos(string ArtB__usuario, string ArtB__cod_emp, string nro_docum, string estado_fac)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {


                    string consulta = "UPDATE wmh_facturas_pgs SET estado_pgs=@estado_fac WHERE nro_docum_pgs =@nro_docum AND estado_pgs='A' ";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = nro_docum;
                    conmand.Parameters.Add("@estado_fac", SqlDbType.VarChar).Value = estado_fac;
                    int dr = conmand.ExecuteNonQuery();
                    return "";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ActualizarEstadoFPagos", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }
        //Actuaizar estado tabla wmh_facturas_cdsc
        public string ActualizarEstadoDsc(string ArtB__usuario, string ArtB__cod_emp, string nro_docum, string estado_fac)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {


                    string consulta = "UPDATE wmh_facturas_cdsc SET estado_dsc=@estado_fac WHERE nro_docum_dsc =@nro_docum AND estado_dsc='A' ";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = nro_docum;
                    conmand.Parameters.Add("@estado_fac", SqlDbType.VarChar).Value = estado_fac;
                    int dr = conmand.ExecuteNonQuery();
                    return "";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ActualizarEstadoDsc", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }
        //Leer tabla wmh_cargaMasiva en canorus Factura de venta
        public List<modeloFacturaEMasiva> ListaFacturas(string ArtB__usuario, string ArtB__cod_emp,string nro_docum)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    List<modeloFacturaEMasiva> lista = new List<modeloFacturaEMasiva>();

                    string consulta = "SELECT * from wmh_cargaMasiva where estado_fac ='A' and nro_docum =@nro_docum ";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                     conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = nro_docum;
                    //conmand.Parameters.Add("@fecha_carga", SqlDbType.VarChar).Value = fecha_carga;

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
                        item.ciudad = Convert.ToString(dr["ciudad"]);
                        item.telefono = Convert.ToString(dr["telefono"]);
                        item.correo = Convert.ToString(dr["correo"]);
                        item.terminos_pago = Convert.ToString(dr["terminos_pago"]);
                        item.cod_termino= Convert.ToString(dr["cod_termino"]);
                        item.fecha_emision = Convert.ToDateTime(dr["fecha_emision"]);
                        item.fecha_vencimiento = Convert.ToDateTime(dr["fecha_vencimiento"]);
                        item.vendedor = Convert.ToString(dr["vendedor"]);
                        item.moneda = Convert.ToString(dr["moneda"]);
                        item.observaciones = Convert.ToString(dr["observaciones"]);
                        item.linea_pro = Convert.ToInt64(dr["linea_pro"]);
                        item.articulo = Convert.ToString(dr["articulo"]);
                        item.descripcion1 = Convert.ToString(dr["descripcion1"]);
                        item.descripcion2 = Convert.ToString(dr["descripcion2"]);
                        item.cant_pro= Convert.ToDecimal(dr["cant_pro"]);
                        item.precio_unit = Convert.ToDecimal(dr["precio_unit"]);
                        item.porc_iva = Convert.ToDecimal(dr["porc_iva"]);
                        item.porc_desc = Convert.ToDecimal(dr["porc_desc"]);
                        item.neto = Convert.ToDecimal(dr["neto"]);
                        item.iva = Convert.ToDecimal(dr["iva"]);
                        item.total_fac = Convert.ToDecimal(dr["total_fac"]);
                        item.estado_fac = Convert.ToString(dr["estado_fac"]);
                        item.fecha_carga = Convert.ToDateTime(dr["fecha_carga"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.cod_vendedor = Convert.ToString(dr["cod_vendedor"]);
                        item.cod_moneda = Convert.ToString(dr["cod_moneda"]);
                        item.cod_ciudad = Convert.ToString(dr["cod_ciudad"]);
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

        //Leer tabla wmh_facturas_pgs en canorus Factura de venta--FORMAS DE PAGO POS
        public List<modeloFPagosF> ListaFPagosFacturas(string ArtB__usuario, string ArtB__cod_emp, string nro_docum)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    List<modeloFPagosF> lista = new List<modeloFPagosF>();

                    string consulta = "SELECT * from wmh_facturas_pgs where estado_pgs ='A' and nro_docum_pgs =@nro_docum ";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = nro_docum;
                    //conmand.Parameters.Add("@fecha_carga", SqlDbType.VarChar).Value = fecha_carga;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloFPagosF item = new modeloFPagosF();
                        item.nro_trans_pgs = Convert.ToString(dr["nro_trans_pgs"]);
                        item.nro_docum_pgs = Convert.ToString(dr["nro_docum_pgs"]);
                        item.dni_cliente_pgs = Convert.ToString(dr["dni_cliente_pgs"]);
                        item.socio_negocio = Convert.ToInt64(dr["socio_negocio"]);
                        item.linea_pgs = Convert.ToInt64(dr["linea_pgs"]);
                        item.cod_fpag = Convert.ToString(dr["cod_fpag"]);
                        item.nro_doc_pag = Convert.ToString(dr["nro_doc_pag"]);
                        item.cod_tercero = Convert.ToString(dr["cod_tercero"]);
                        item.valor_pgs = Convert.ToDecimal(dr["valor_pgs"]);
                        item.estado_pgs = Convert.ToString(dr["estado_pgs"]);
                        item.fecha_pgs = Convert.ToDateTime(dr["fecha_pgs"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        lista.Add(item);
                    }

                    return lista;

                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ListaFPagosFacturas", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }
        //Leer tabla wmh_facturas_cdsc en canorus Factura de venta--DESCUENTOS Y CARGOS GLOBALES A FACTURA
        public List<modeloCargosDscGlobalesF> ListaCargosDsctosGFacturas(string ArtB__usuario, string ArtB__cod_emp, string nro_docum)
        {
            try
            {

                stringConexionERP = conexion_erp.ConsultaConexionERP(ArtB__cod_emp, ArtB__usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    List<modeloCargosDscGlobalesF> lista = new List<modeloCargosDscGlobalesF>();

                    string consulta = "SELECT * from wmh_facturas_cdsc where estado_dsc ='A' and nro_docum_dsc =@nro_docum ";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@nro_docum", SqlDbType.VarChar).Value = nro_docum;
                    //conmand.Parameters.Add("@fecha_carga", SqlDbType.VarChar).Value = fecha_carga;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloCargosDscGlobalesF item = new modeloCargosDscGlobalesF();
                        item.nro_trans_dsc = Convert.ToString(dr["nro_trans_dsc"]);
                        item.nro_docum_dsc = Convert.ToString(dr["nro_docum_dsc"]);
                        item.dni_cliente_dsc = Convert.ToString(dr["dni_cliente_dsc"]);
                        item.socio_negocio = Convert.ToInt64(dr["socio_negocio"]);
                        item.linea_dsc = Convert.ToInt64(dr["linea_dsc"]);
                        item.cod_concepto = Convert.ToString(dr["cod_concepto"]);
                        item.valor_dsc = Convert.ToDecimal(dr["valor_dsc"]);
                        item.estado_dsc = Convert.ToString(dr["estado_dsc"]);
                        item.fecha_dsc = Convert.ToDateTime(dr["fecha_dsc"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        lista.Add(item);

                    }

                    return lista;

                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, metodo, "ListaCargosDsctosGFacturas", e.ToString(), DateTime.Now, ArtB__usuario);
                return null;
            }
        }
        //Enviar nro factura para consultar datos d facturas
        //Saldos sin restricciones
        public string BuscartaDatosFacturasMasivas(string Ccf_usuario, string Ccf_cod_emp)
        {
            try
            {
               
                List<modeloFacturaEMasiva> lista = new List<modeloFacturaEMasiva>();
                
                List<modeloFacturaEMasiva> listaAux = new List<modeloFacturaEMasiva>();
                lista = TotalFacturas(Ccf_usuario, Ccf_cod_emp);

                foreach (var item in lista)
                {
                    //Llenar datos de la factura
                   listaAux= ListaFacturas(Ccf_usuario, Ccf_cod_emp, item.nro_docum);
                    //Insertar en la cabecera de la factura
                    InsertarCabecera(Ccf_usuario, Ccf_cod_emp, listaAux);
                    //Referencia cruzada ---insertar detallle factura
                    InsertarDetalle(Ccf_usuario, Ccf_cod_emp, listaAux);
                    //Insertar Formas de pago si es POS /POSE
                    if(tipo_factura.Trim()=="POSE" || tipo_factura.Trim() =="POS")
                    {
                        InsertarFPagos(Ccf_usuario, Ccf_cod_emp, item.nro_docum);
                    }
                    //Insertar Descuentos y Cargos globales
                    InsertarCDscGlobales(Ccf_usuario, Ccf_cod_emp, item.nro_docum);
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
        //INSERTAR CARGOS Y DESCUENTOS GLOBALES EN PWM-----------------------FACTURACION MASIVA------------------------
        public void InsertarCDscGlobales(string AmUsrLog, string ComPwm, string nro_docum)
        {
            try
            {
                //Cargar cargos y descuentos globales de canorus 
                ListaCarDscG = null;
                ListaCarDscG = ListaCargosDsctosGFacturas(AmUsrLog, ComPwm, nro_docum);
                if (ListaCarDscG.Count > 0)
                {
                    ModeloDescCargoFac modeloDesCargo = new ModeloDescCargoFac();
        
                    foreach (var desc in ListaCarDscG)
                    {
                        modeloCarDscG = desc;
                        ModeloDescuento = null;
                        ModeloDescuento = BuscarDescuento.ConceptoUnico(AmUsrLog, ComPwm, modeloCarDscG.cod_concepto.Trim());
                        //Insertar pago en wmt_facturas_descto

                        modeloDesCargo.nro_trans =valor_asignado;
                        modeloDesCargo.linea = modeloCarDscG.linea_dsc.ToString();
                        modeloDesCargo.cod_emp = ComPwm;
                        modeloDesCargo.cod_concepto = ModeloDescuento.cod_concepto;
                        modeloDesCargo.nom_concepto = ModeloDescuento.nom_concepto;
                        modeloDesCargo.signo = ModeloDescuento.signo;
                        modeloDesCargo.porc_descto = 0;
                        modeloDesCargo.valor_descto = Convert.ToDecimal(modeloCarDscG.valor_dsc);
                        modeloDesCargo.monto_imponible = 0;
                        //Calcular total
                        if (modeloDesCargo.porc_descto == 0)
                        {
                            modeloDesCargo.total = modeloDesCargo.valor_descto;
                        }
                       
                        modeloDesCargo.cod_ccostos = ModeloDescuento.cod_ccostos;
                        modeloDesCargo.cod_cta = ModeloDescuento.cod_cta;
                        modeloDesCargo.usuario_mod = AmUsrLog;
                        modeloDesCargo.fecha_mod = DateTime.Now.ToString();
                        consultaDesc.InsertarDescCargTrans(modeloDesCargo);
                    }
                }

            }
            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "InsertarCDscGlobales", ex.ToString(), DateTime.Now, AmUsrLog);


            }
        }
        //INSERTAR FORMA DE PAGO EN PWM-----------------------FACTURACION MASIVA------------------------
        public void InsertarFPagos(string AmUsrLog, string ComPwm, string nro_docum)
        {
            try
            {
                //Cargar formas de pagos de canorus 
                ListaFPagosF = null;
                ListaFPagosF = ListaFPagosFacturas(AmUsrLog, ComPwm, nro_docum);
                foreach (var pagos in ListaFPagosF)
                {
                    modeloFPagosFactura = pagos;
                    //Agregar medio de pago en la tabla wmt_facturas_pgstmp
                    modeloTiposPagos.nro_trans = valor_asignado;
                    modeloTiposPagos.cod_fpago = modeloFPagosFactura.cod_fpag;
                    modeloTiposPagos.cod_emp = ComPwm;
                    consultaMediosPago.InsertarTipoPago(modeloTiposPagos);
                    //Recupero datos con wmspc_fpagoPOS_tmp--Recupera el medio de pago insertado en ese momento con sus restricciones
                    modeloTemporal = null;
                    modeloTemporal = BuscarDetallePago(AmUsrLog, ComPwm, valor_asignado);
                    modeloFacturasPagos item = new modeloFacturasPagos();
                    item.linea = Convert.ToInt32(modeloFPagosFactura.linea_pgs);
                    item.cod_tit = modeloFPagosFactura.socio_negocio.ToString();
                    item.nro_docum = modeloFPagosFactura.nro_doc_pag;
                    item.recibido = Convert.ToDecimal(modeloFPagosFactura.valor_pgs);
                    item.nro_trans =valor_asignado;
                    item.cod_emp = ComPwm;
                    item.cod_docum = modeloTemporal.cod_docum;
                    item.cod_cta = modeloTemporal.cod_cta;
                    item.cod_fpago = modeloTemporal.cod_fpago;
                   
                    guardarPagos.InsertarPagosFactura(item);
                }


            }
            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "InsertarFPagos", ex.ToString(), DateTime.Now, AmUsrLog);


            }
        }

        public ModeloTipoPagoTem BuscarDetallePago(string AmUsrLog,string ComPwm, string nro_trans)
        {
            try
            {
                 listaTemporal = consultaMediosPago.BuscarMediosPagoTemporal(AmUsrLog, ComPwm, nro_trans);
                modeloTemporal = null;
                foreach (ModeloTipoPagoTem item in listaTemporal)
                {

                    modeloTemporal = item;
                    break;

                }

                return modeloTemporal;
            }
            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "BuscarDetallePago", ex.ToString(), DateTime.Now, AmUsrLog);
                return null;
            }
        }
        //Insertar cabecera----------------------------FACTURACION MASIVA--------------------------------

        public void InsertarCabecera( string AmUsrLog, string ComPwm, List<modeloFacturaEMasiva> lista)
        {
            try
            {
                    //obtener numero de transaccion
                   nrotrans = ConsultaNroTran.ConsultaNumeradores(numerador);
                   valor_asignado = nrotrans.valor_asignado;
   
                //Obtener n° sucursal
                ListaUsuSucursal = consultaUsuarioSucursal.ConsultaUsuarioSucursal(ComPwm, AmUsrLog);
                ModeloUsuSucursal = null;
                foreach (modeloUsuariosucursal items in ListaUsuSucursal)
                {
                    ModeloUsuSucursal = items;
                    break;
                }
                //OBTENER DATOS DE LA FACTURA
                modeloFacturaEMasiva factura = new modeloFacturaEMasiva();
                factura = null;
                foreach (modeloFacturaEMasiva item in lista)
                {
                   factura = item;
                    break;
                }
                //Traer resolución
                
                //LIsta Resolucion facturas(serie documento)
                listaRes = ConsultaResolucion.ConsultaResolusiones(AmUsrLog, ComPwm, ResF_estado, ResF_serie, ResF_tipo);
                resolucion = null;
                foreach (modelowmspcresfact item in listaRes)
                {
                    resolucion = item;
                    break;
                }
                //TIPO FACTURA VTA----VTAE
                //Aqui se va a traer que tipo de facturacion es(POS, POSE, VTA, VTAE)
                //CONSULTAR SI EXISTE formas da pago NRO DE DOCUEMNTO EN CANORUS
                ListaFPagosF = ListaFPagosFacturas(AmUsrLog, ComPwm, factura.nro_docum);
    
                if (resolucion.tipo_fac == "S")
                {
                    if(ListaFPagosF.Count >0)
                    {
                        tipo_factura = "POSE";
                    }else
                    { tipo_factura = "VTAE"; }
                    
                }
                else
                {
                    if (ListaFPagosF.Count > 0)
                    {
                        tipo_factura = "POS";
                    }
                    else
                    { tipo_factura = "VTA"; }
                }
                // centro costos
                listaCostos = ConsultaCCostos.ConsultaCCostos(AmUsrLog, ComPwm, CC__cod_dpto);

                ccostos = null;
                foreach(modelowmspcccostos items in listaCostos)
                {
                    ccostos = items;
                    break;
                }

                //obtener cliente
                string error = "";
                string Ven__cod_tit = factura.dni_cliente;

                listaClientes = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi,factura.cod_suc_cli);

                clientes = null;
                foreach (modelowmspctitulares item in listaClientes)
                {
                    clientes = item;
                    break;
                }
                     

                 //Procedimiento para actualizar email del titular
                ModeloActualizarEmail.usuario = AmUsrLog;
                ModeloActualizarEmail.empresa = ComPwm;
                ModeloActualizarEmail.cod_tit = clientes.cod_tit.Trim();
                ModeloActualizarEmail.parametro = "email";
                ModeloActualizarEmail.valor = factura.correo;
                ModeloActualizarEmail.sucursal = clientes.cod_sucursal;
                 //Envio de datos para actualizar email en RP  
                 ConsultaDatosTitular.ActualizarDatosTitulares(ModeloActualizarEmail);
                DateTime Fecha = factura.fecha_emision;
                cabecerafactura.cod_cliente = factura.socio_negocio.ToString();
                cabecerafactura.dia = string.Format("{0:00}", Fecha.Day);
                cabecerafactura.mes = string.Format("{0:00}", Fecha.Month);
                cabecerafactura.anio = Fecha.Year.ToString();
                cabecerafactura.fec_doc =Fecha.ToString();
                cabecerafactura.serie_docum = resolucion.serie_docum;
                cabecerafactura.cod_ccostos = ccostos.cod_dpto;
                cabecerafactura.cod_vendedor = factura.cod_vendedor;
                cabecerafactura.cod_fpago = factura.cod_termino;
                cabecerafactura.observaciones = factura.observaciones;
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
                cabecerafactura.ocompra = factura.nro_docum; //numero de factura que ellos envian en excel
                cabecerafactura.cod_moneda = factura.moneda; //cargar excel
                cabecerafactura.tipo = tipo_factura; //tipo vtae electronicas
                cabecerafactura.porc_descto = Convert.ToDecimal("0.00");
                cabecerafactura.descuento = Convert.ToDecimal("0.00");
                cabecerafactura.diar = "0";
                cabecerafactura.mesr = "0";
                cabecerafactura.anior = "0";
                cabecerafactura.cod_proc_aud = "RCOMFACT";
                cabecerafactura.cod_sucursal = ModeloUsuSucursal.cod_sucursal;
                cabecerafactura.nro_pedido = "";
                cabecerafactura.cod_suc_cli = clientes.cod_sucursal;
                cabecerafactura.desctos_rcgos = 0;
                error = GuardarCabezera.InsertarCabezeraFactura(cabecerafactura);
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
        public void InsertarDetalle( string AmUsrLog, string ComPwm, List<modeloFacturaEMasiva> listaD)
        {
            try
            {
                
                  modeloFacturaEMasiva ModeloDetalle = new modeloFacturaEMasiva();
                foreach (var proDet in listaD)
                {
                    ModeloDetalle = proDet;


                    ModeloDetalleFactura item = new ModeloDetalleFactura();
                    articulo = null;
                    articulo = BuscarProducto(ComPwm,AmUsrLog, ModeloDetalle.articulo);
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
                GuardarDetalle(ComPwm, AmUsrLog, ModeloDetalleFactura);
            }
            catch (Exception ex)
            {
                guardarExcepcion.ClaseInsertarExcepcion(ComPwm, metodo, "InsertarDetalle", ex.ToString(), DateTime.Now, AmUsrLog);

            }
        }

        //Insertar detalle detalle en pwm
        public modelowmtfacturascab GuardarDetalle(string ComPwm, string AmUsrLog, List<ModeloDetalleFactura> listaD)
        {
            try
            {
                string error;
                //Busca en gv_producto todos los items añadidos que estan en la variable de session detalle
                ModeloDetalleFactura = new List<ModeloDetalleFactura>();
                ModeloDetalleFactura = (listaD as List<ModeloDetalleFactura>);
                
                //Insertar primero la cabecera
               // InsertarCabecera(ComPwm,AmUsrLog,listaD);
               //Busca el nro de auditoria
                    conscabcera = null;
                    conscabcera = BuscarCabecera(ComPwm,AmUsrLog);

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

        //FINALIZAR FACTURA
        public void FinalizarFactura( string AmUsrLog, string ComPwm)
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
            conscabcera = null;
            conscabcera = BuscarCabecera(ComPwm,  AmUsrLog);

            confirmarinsertar.nro_trans = conscabcera.nro_trans;
            confirmarinsertar.cod_emp = conscabcera.cod_emp;
            confirmarinsertar.usuario_mod = AmUsrLog;
            confirmarinsertar.fecha_mod = DateTime.Now;
            confirmarinsertar.nro_audit = conscabcera.nro_audit;

            respuestaConfirmacionFAC = ConfirmarFactura.ConfirmarFactura(confirmarinsertar);

            //AVERIGUAR Q TIPO DE FACTURACION USA
            //cOSNULTA BUSCAR TIPO DE FACTURA
            conscabceraTipo = null;
            conscabceraTipo = buscarTipoFac(conscabcera.nro_trans.Trim(), ComPwm,AmUsrLog);
            if (conscabceraTipo.tipo_nce.Trim() == "VTAE" || conscabceraTipo.tipo_nce.Trim() =="POSE")
            {
                if (respuestaConfirmacionFAC == "")
                {
                    string respuesta = "";
                    switch (Modelowmspclogo.version_fe.Trim()) //AVERIGUAR Q TIPO DE FACTURACION USA
                    {
                        case "1":
                            ConsumoRestFEV2 consumoRest1 = new ConsumoRestFEV2();
                            respuesta = consumoRest1.EnviarFactura(ComPwm, AmUsrLog, "C", conscabceraTipo.tipo_nce.Trim(), conscabcera.nro_trans);
                            
                            break;
                        case "2":
                            ConsumoRestFEV3 consumoRest = new ConsumoRestFEV3();
                            respuesta = consumoRest.EnviarFactura(ComPwm, AmUsrLog, "C", conscabceraTipo.tipo_nce.Trim(), conscabcera.nro_trans);
                            break;
                    }
   

                    if (respuesta == "")
                    {
                        mensaje = "Su factura fue procesada exitosamente";
                        GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "F");
                        //Cambiar a estado 'P'(procesado) en wmh_cargaMasiva
                        ActualizarEstado(ComPwm, AmUsrLog, conscabcera.ocompra, "P");
                        //Cambiar a estado 'P'(procesado) en wmh_facturas_pgs
                        ActualizarEstadoFPagos(ComPwm, AmUsrLog, conscabcera.ocompra, "P");
                        //Cambiar a estado 'P'(procesado) en wmh_facturas_cdsc
                        ActualizarEstadoDsc(ComPwm, AmUsrLog, conscabcera.ocompra, "P");
                    }
                    else
                    {
                        GuardarCabezera.ActualizarEstadoFactura(conscabcera.nro_trans, "C");
                        mensaje = respuesta;
                        //Cambiar a estado 'P'(procesado) en wmh_cargaMasiva si a error se puede ver en buscar facturas
                        ActualizarEstado(ComPwm, AmUsrLog, conscabcera.ocompra, "P");
                        //Cambiar a estado 'P'(procesado) en wmh_facturas_pgs
                        ActualizarEstadoFPagos(ComPwm, AmUsrLog, conscabcera.ocompra, "P");
                        //Cambiar a estado 'P'(procesado) en wmh_facturas_cdsc
                        ActualizarEstadoDsc(ComPwm, AmUsrLog, conscabcera.ocompra, "P");
                    }
                }

                else
                {
                    //Cambiar a estado 'P'(procesado) en wmh_cargaMasiva
                    ActualizarEstado(ComPwm, AmUsrLog, conscabcera.ocompra, "P");
                    //Cambiar a estado 'P'(procesado) en wmh_facturas_pgs
                    ActualizarEstadoFPagos(ComPwm, AmUsrLog, conscabcera.ocompra, "P");
                    //Cambiar a estado 'P'(procesado) en wmh_facturas_cdsc
                    ActualizarEstadoDsc(ComPwm, AmUsrLog, conscabcera.ocompra, "P");
                    string respuestaC = respuestaConfirmacionFAC;
                }
            }
            else
            {
                if (respuestaConfirmacionFAC == "")
                {
                    string men_fn = "Finalizado";
                    //Cambiar a estado 'P'(procesado) en wmh_cargaMasiva
                    ActualizarEstado(ComPwm, AmUsrLog, conscabcera.ocompra, "P");
                    //Cambiar a estado 'P'(procesado) en wmh_facturas_pgs
                    ActualizarEstadoFPagos(ComPwm, AmUsrLog, conscabcera.ocompra, "P");
                    //Cambiar a estado 'P'(procesado) en wmh_facturas_cdsc
                    ActualizarEstadoDsc(ComPwm, AmUsrLog, conscabcera.ocompra, "P");
                }
                else {
                    //Cambiar a estado 'P'(procesado) en wmh_cargaMasiva
                    ActualizarEstado(ComPwm, AmUsrLog, conscabcera.ocompra, "P");
                    //Cambiar a estado 'P'(procesado) en wmh_facturas_pgs
                    ActualizarEstadoFPagos(ComPwm, AmUsrLog, conscabcera.ocompra, "P");
                    //Cambiar a estado 'P'(procesado) en wmh_facturas_cdsc
                    ActualizarEstadoDsc(ComPwm, AmUsrLog, conscabcera.ocompra, "P");
                    string men_fn = respuestaConfirmacionFAC; }
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
                conscabceraTipo = null;
                conscabceraTipo = buscarTipoFac(Ccf_nro_trans, ComPwm, AmUsrLog);
                listaConsCab = ConsultaCabe.ConsultaCabFacura(ComPwm, AmUsrLog, Ccf_tipo1, conscabceraTipo.tipo_nce.Trim(), Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);

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


        //Buscar tipo de factura
        public modelowmtfacturascab buscarTipoFac(string nro_trans, string empresa, string usuario)
        {
            try
            {
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
                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "buscarTipoFac", ex.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
        //Buscar aritulo
        public modelowmspcarticulos BuscarProducto(string ComPwm, string AmUsrLog,string ArtB__articulo)
        {
            try
            {
                listaArticulos = ConsultaArticulo.ConsultaArticulos(AmUsrLog, ComPwm, ArtB__articulo, "0", "0", "S");

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
    }
}
