using CapaDatos.Modelos;
using CapaDatos.Modelos.ModelosNC;
using CapaDatos.Sql;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.RestCliente
{
    public class JsonNCFinancieraElectronica
    {
        public modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        public modelowmtfacturascab conscabceraTipo = new modelowmtfacturascab();
        public modelowmtfacturascab conscabceraNC = new modelowmtfacturascab();
        public modelowmtfacturascab conscabceraNCMot = new modelowmtfacturascab();
        public List<modelowmtfacturascab> listaConsCabNC = null;
        public List<modelowmtfacturascab> listaConsCabNCMot = null;
        public Consultawmtfacturascab ConsultaCabeNC = new Consultawmtfacturascab();
        public List<modelowmtfacturascab> listaConsCab = null;
        public Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

        public ModeloDetalleFactura consdetalle = new ModeloDetalleFactura();
        public List<ModeloDetalleFactura> listaConsDet = null;
        public Consultawmtfacturasdet ConsultaDeta = new Consultawmtfacturasdet();

        public List<modelowmspcempresas> ListaModeloempresa = new List<modelowmspcempresas>();
        public ConsultaEmpresa consultaEmpresa = new ConsultaEmpresa();
        public modelowmspcempresas Modeloempresa = new modelowmspcempresas();

        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();

        public List<modelobancos> ListaModelobancos = new List<modelobancos>();
        public ConsultaBancos consultabanco = new ConsultaBancos();
        public modelobancos ModeloBancos = new modelobancos();

        public List<modeloUsuariosucursal> ListaUsuSucursal = new List<modeloUsuariosucursal>();
        public ConsultawmusuarioSucursal ConsultaUsuSucursal = new ConsultawmusuarioSucursal();
        public modeloUsuariosucursal ModeloUsuSucursal = new modeloUsuariosucursal();
             
        public List<modeloparametrocomercial> ListaModelocomercial = new List<modeloparametrocomercial>();
        public Consultaparamcomercial consultaComercial = new Consultaparamcomercial();
        public modeloparametrocomercial Modelocomercial = new modeloparametrocomercial();

        public Consultawmsptitulares ConsultaTitulares = new Consultawmsptitulares();
        public List<modelowmspctitulares> lista = null;
        public modelowmspctitulares cliente = new modelowmspctitulares();

        public List<modelowmspctctrxCotizacion> ListaModelocotizacion = new List<modelowmspctctrxCotizacion>();
        public modelowmspctctrxCotizacion ModeloCotizacion = new modelowmspctctrxCotizacion();
        public ConsultawmspctctrxCotizacion consultaMoneda = new ConsultawmspctctrxCotizacion();

        public List<modelowmspcfacturasWMimpuRest> ListaModeloimpuesto = new List<modelowmspcfacturasWMimpuRest>();
        public modelowmspcfacturasWMimpuRest ModeloImpuesto = new modelowmspcfacturasWMimpuRest();
        public ConsultawmspcfacturasWMimpuRest consultaImpuesto = new ConsultawmspcfacturasWMimpuRest();

        public List<JsonRespuestaNC> ListaModelorespuestaDs = new List<JsonRespuestaNC>();
        public List<JsonRespuestaNC> ListaBuscarQr = null;
        public JsonRespuestaNC ModeloResQr = new JsonRespuestaNC();
        public ConsultawmtrespuestaNC consultaRespuestaDS = new ConsultawmtrespuestaNC();

        public GuardarrespuestaDS guardarResJson = new GuardarrespuestaDS();


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
        public string nro_trans = null;
        public string Ven__cod_tipotit = "clientes";
        public string Ven__cod_tit = " ";
        public string impuesto_rest = "0";
        public string Ven__cod_dgi = "0";
        public string Ven__fono = "0";
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "JsonNCFinancieraElectronica.cs";
        public ComprobanteNCJSON LlenarJSONNC(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string nro_factura)
        {
            try
            {
                ComprobanteNCJSON comprobanteNCJSON = new ComprobanteNCJSON();
                DocumentoNC documento = new DocumentoNC();
                /* Datos de encabezado de la nc */

                documento.encabezado = LlenarEnacabezadoNCJSON(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, nro_factura);
                documento.detalle = LlenarDetalleNCJSON(Ccf_cod_emp, Ccf_usuario, Ccf_nro_trans);
                documento.impuesto = LlenarImpuestoNCJSON(Ccf_cod_emp, Ccf_usuario, Ccf_nro_trans, impuesto_rest);
                documento.sucursal = LlenarSucursalNCJSON(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                documento.tercero = LlenarTerceroNCJSON(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);

                comprobanteNCJSON.documento = documento;
                return comprobanteNCJSON;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarJSONNC", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }

        public EncabezadoNC LlenarEnacabezadoNCJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string nro_factura)
        {
            try
            {
                string tipoFactura = "";
                EncabezadoNC encabezado = new EncabezadoNC();
                //Recuperar el cufe ce la factura
                ListaModelorespuestaDs = consultaRespuestaDS.RespuestaLineaQr(nro_factura, "1");
                int count = 0;
                foreach (var item in ListaModelorespuestaDs)
                {
                    ModeloResQr = item;
                    count++;
                    break;
                }

                //Detalle nc
                listaConsDet = ConsultaDeta.ConsultaDetalleFacura(Ccf_nro_trans);
                foreach (var item1 in listaConsDet)
                {
                    consdetalle = item1;
                    count++;
                    break;
                }

                listaConsCab = ConsultaCabe.ConsultaTipoFactura(Ccf_nro_trans);
                conscabceraTipo = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {

                    conscabceraTipo = item;

                }
                if (conscabceraTipo.tipo_nce.Trim() == "POSE")
                {
                    tipoFactura = "POSE";
                }
                if (conscabceraTipo.tipo_nce.Trim() == "VTAE")
                {
                    tipoFactura = "VTAE";
                }
                if (conscabceraTipo.tipo_nce.Trim() == "NCVE")
                {
                    tipoFactura = "NCVE";
                }
                if (conscabceraTipo.tipo_nce.Trim() == "NCME")
                {
                    tipoFactura = "NCME";
                }
                //CABECERA de la FACTURA
                conscabcera = null;
                conscabcera = buscarCabezeraFactura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, tipoFactura, nro_factura);
                //CABECERA NC
                conscabceraNC = null;
                conscabceraNC = buscarCabezeraNC(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                //motivo de NC
                conscabceraNCMot = null;
                conscabceraNCMot = buscarMotNC(Ccf_nro_trans);

                Modeloempresa = null;
                Modeloempresa = BuscarCabEmpresa(Ccf_usuario, Ccf_cod_emp);

                ModeloCotizacion = null;
                ModeloCotizacion = BuscarCotizacion(Ccf_usuario, Ccf_cod_emp, Ccf_nro_trans);
                //Pruebas emisor 830106032
                //Produccion emisor =Convert.ToInt32(Modeloempresa.nro_dgi2);
                encabezado.emisor = 830106032;
                encabezado.codmoneda = conscabceraNC.cod_moneda.Trim();
                encabezado.comentarios = conscabceraNC.observaciones;
                encabezado.factortrm = Convert.ToDecimal(ModeloCotizacion.tc_mov1c);
                encabezado.fecha = conscabceraNC.fec_doc.ToString("yyyy-MM-dd");
                encabezado.fvence = conscabceraNC.fec_venc.ToString("yyyy-MM-dd");
                encabezado.idsuc = 1;
                encabezado.idvendedor = 0;//Convert.ToInt32(conscabceraNC.cod_vendedor);
                encabezado.iva = Convert.ToDecimal(conscabceraNC.iva);
                encabezado.nit = Convert.ToInt64(conscabceraNC.nro_dgi2);
                encabezado.numero = Convert.ToInt32(conscabceraNC.nro_docum);
                encabezado.ordencompra = Convert.ToString(conscabceraNC.ocompra);
                encabezado.prefijo = Convert.ToString(conscabceraNC.serie_docum.Trim());
                //encabezado.prefijo = "DV"; // para pruebas (DV)
                encabezado.subtotal = Convert.ToInt32(conscabceraNC.subtotal);
                encabezado.sucursal = Convert.ToInt16(conscabceraNC.cod_sucursal);
                encabezado.total = Convert.ToInt32(conscabceraNC.total);
                encabezado.usuario = Ccf_usuario;  //Usuario que facturo
                encabezado.totalDet = listaConsDet.Count; //la cantidad de lineas del detalle de la factura
                encabezado.totalImp = 1; //la cantidad de lineas de los impuestos
                encabezado.ref_doc = conscabcera.serie_docum; //prefijo de la factura parapruebas
                encabezado.ref_fecha = conscabcera.fec_doc.ToString("yyyy-MM-dd");
                encabezado.ref_num = Convert.ToInt64(consdetalle.nro_doca); //numero de la factura
                encabezado.ref_cufe = ModeloResQr.cufe; //CUFE Factura emitida
                encabezado.tlmotivodv = Convert.ToInt32(conscabceraNCMot.mot_nce);//NC PARA ANULAR FACTURA (2)
                return encabezado;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarEnacabezadoNCJSON", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }

        public List<DetalleNC> LlenarDetalleNCJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_nro_trans)
        {

            try
            {
                listaConsDet = ConsultaDeta.ConsultaDetalleFacura(Ccf_nro_trans);
                List<DetalleNC> detalle = new List<DetalleNC>();
                ModeloCotizacion = null;
                ModeloCotizacion = BuscarCotizacion(Ccf_usuario, Ccf_cod_emp, Ccf_nro_trans);

                foreach (var item in listaConsDet)
                {
                    DetalleNC itemDetalle = new DetalleNC();
                    itemDetalle.adicional = "";
                    itemDetalle.cantidad = Convert.ToInt32(item.cantidad);
                    itemDetalle.idproducto = item.cod_articulo.Trim();
                    itemDetalle.idunidad = "Und";//Preguntar a alfredo de donde trae la unidad
                    itemDetalle.iva = Convert.ToInt32(item.valor_iva);
                    itemDetalle.nombreproducto = item.nom_articulo;
                    itemDetalle.operacion = "SA"; //Factura en venta
                    itemDetalle.porcdcto = Convert.ToInt32(item.porc_descto);
                    itemDetalle.porciva = Convert.ToInt32(item.porc_iva);
                    itemDetalle.pos = item.linea;
                    itemDetalle.precio = Convert.ToInt32(item.precio_unit);
                    itemDetalle.subtotal = Convert.ToInt32(item.subtotal);
                    if (conscabcera.cod_moneda.Trim() != "COP")
                    {
                        itemDetalle.preciousd = Convert.ToDecimal(ModeloCotizacion.tc_mov1c) * itemDetalle.precio;
                        itemDetalle.ivausd = Convert.ToDecimal(ModeloCotizacion.tc_mov1c) * itemDetalle.iva;
                        itemDetalle.subtotalusd = Convert.ToDecimal(ModeloCotizacion.tc_mov1c) * itemDetalle.subtotal;
                    }
                    else
                    {
                        itemDetalle.preciousd = 0;
                        itemDetalle.ivausd = 0;
                        itemDetalle.subtotalusd = 0;
                    }
                    detalle.Add(itemDetalle);

                }



                return detalle;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarDetalleNCJSON", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }

        public List<ImpuestoNC> LlenarImpuestoNCJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_nro_trans, string impuesto_rest)
        {
            try
            {
                List<ImpuestoNC> impuesto = new List<ImpuestoNC>();
                ImpuestoNC item = new ImpuestoNC();
                //Buscamos todos los impuestos de la factura
                ModeloImpuesto = null;
                ModeloImpuesto = BuscarImpuestosREst(Ccf_usuario, Ccf_cod_emp, Ccf_nro_trans, impuesto_rest);



                item.base_calculo = Convert.ToDecimal(ModeloImpuesto.base_impu);
                item.porciva = Convert.ToDecimal(ModeloImpuesto.porc_impu);
                item.valor = Convert.ToDecimal(ModeloImpuesto.valor_impu);

                impuesto.Add(item);

                return impuesto;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarImpuestoNCJSON", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }


        public SucursalNC LlenarSucursalNCJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                SucursalNC sucursal = new SucursalNC();
                TerceroNC tercero = new TerceroNC();
                modelowmspctitulares vendedor = new modelowmspctitulares();
                modelowmspctitulares cliente = new modelowmspctitulares();

                string Ven__cod_tit = conscabceraNC.cod_cliente;
                cliente = null;
                cliente = buscarCliente(Ccf_usuario, Ccf_cod_emp, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi);

                ModeloUsuSucursal = BuscarUsuarioSucursal(Ccf_cod_emp, Ccf_usuario);

                vendedor = null;
                vendedor = buscarCliente(Ccf_usuario, Ccf_cod_emp, "vendedores", conscabceraNC.cod_vendedor, Ven__cod_dgi);

                sucursal.ciudad = vendedor.nom_ciudad;
                sucursal.codcliente = conscabceraNC.cod_cliente;
                sucursal.departamento = vendedor.nom_provincia;
                sucursal.direccion1 = vendedor.dir_tit;
                sucursal.dpto = vendedor.cod_provincia;
                sucursal.email = vendedor.email_tit;
                sucursal.emailfe = cliente.email_tit;
                sucursal.idsuc = Convert.ToInt16(conscabceraNC.cod_sucursal.Trim());
                sucursal.idvendedor = 0;//Convert.ToInt64(conscabceraNC.cod_vendedor);
                sucursal.movil = "";
                sucursal.mun = vendedor.ciudad_tit;
                sucursal.razonsocial = vendedor.razon_social;
                sucursal.telefono1 = vendedor.tel_tit;
                sucursal.telefono2 = "";
                return sucursal;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarSucursaNCJSON", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }

        public TerceroNC LlenarTerceroNCJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                TerceroNC tercero = new TerceroNC();

                modelowmspctitulares cliente = new modelowmspctitulares();

                string Ven__cod_tit = conscabceraNC.cod_cliente;
                cliente = null;
                cliente = buscarCliente(Ccf_usuario, Ccf_cod_emp, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi);

                tercero.apli1 = cliente.primer_apellido;
                tercero.apl2 = cliente.segundo_apellido;
                tercero.comentarios = "";
                tercero.dv = cliente.nro_dgi1; //digito verificador
                tercero.identificacion = Convert.ToInt64(cliente.nro_dgi2);
                tercero.idtipoempresa = Convert.ToInt16(Modeloempresa.cod_emp);
                tercero.nit = Convert.ToInt64(cliente.nro_dgi2);
                tercero.nom1 = cliente.primer_nombre;
                tercero.nom2 = cliente.segundo_nombre;
                tercero.razonsocial = cliente.razon_social;
                tercero.tdoc = Convert.ToInt16(cliente.cod_dgi);
                tercero.tipopersona = cliente.control_tit;

                return tercero;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarTerceroNCJSON", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }

        public modelowmspctitulares buscarCliente(string Ven__usuario, string Ven__cod_emp, string Ven__cod_tipotit, string Ven__cod_tit, string Ven__cod_dgi)
        {

            try
            {
                lista = ConsultaTitulares.ConsultaTitulares(Ven__usuario, Ven__cod_emp, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi);
                int count = 0;
                cliente = null;
                foreach (modelowmspctitulares item in lista)
                {
                    count++;
                    cliente = item;

                }
                return cliente;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ven__cod_emp, metodo, " buscarCliente", e.ToString(), DateTime.Today, Ven__usuario);
                return null;
            }
        }

        public ModeloDetalleFactura buscarDetalleFactura(string Ccf_nro_trans)
        {
            try
            {

                listaConsDet = ConsultaDeta.ConsultaDetalleFacura(Ccf_nro_trans);
                int count = 0;
                consdetalle = null;
                foreach (ModeloDetalleFactura item in listaConsDet)
                {
                    count++;
                    consdetalle = item;

                }
                return consdetalle;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "buscarDetalleFactura", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
        //Consulta NC CABECERA
        public modelowmtfacturascab buscarCabezeraNC(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                listaConsCabNC = ConsultaCabeNC.ConsultaCabFacura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                int count = 0;
                conscabceraNC = null;
                foreach (modelowmtfacturascab item in listaConsCabNC)
                {
                    count++;
                    conscabceraNC = item;

                }
                return conscabceraNC;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "buscarCabezeraNC", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }
        public modelowmtfacturascab buscarCabezeraFactura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                listaConsCab = ConsultaCabe.ConsultaCabFacura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                int count = 0;
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                    count++;
                    conscabcera = item;

                }
                return conscabcera;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "buscarCabezeraFactura", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }
        //Bucar el motivo de anulacion de NC
        
        public modelowmtfacturascab buscarMotNC(string Ccf_nro_trans)
        {
            try
            {
                listaConsCabNCMot = ConsultaCabeNC.ConsultaNCTransPadre(Ccf_nro_trans);
                int count = 0;
                conscabceraNCMot = null;
                foreach (modelowmtfacturascab item in listaConsCabNCMot)
                {
                    count++;
                    conscabceraNCMot = item;

                }
                return conscabceraNCMot;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_nro_trans, metodo, "buscarMotNC", e.ToString(), DateTime.Today,"consulta");
                return null;
            }
        }

        public modelowmspclogo BuscarUsuarioLogo(string Ccf_cod_emp, string Ccf_usuario)
        {
            try
            {
                ListaModelowmspclogo = consultaLogo.BuscartaLogo(Ccf_cod_emp, Ccf_usuario);

                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }

                return Modelowmspclogo;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarUsuarioLogo", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }
        public modelowmspcfacturasWMimpuRest BuscarImpuestosREst(string Ccf_usuario, string Ccf_cod_emp, string Ccf_nro_trans, string impuesto)
        {
            try
            {
                ListaModeloimpuesto = consultaImpuesto.BuscarImpuestoRest(Ccf_usuario, Ccf_cod_emp, Ccf_nro_trans, impuesto);
                foreach (modelowmspcfacturasWMimpuRest item in ListaModeloimpuesto)
                {
                    if (item.nom_impuesto.Trim() == "IVA GENERADO")
                    {
                        ModeloImpuesto = item;
                        break;
                    }

                }

                return ModeloImpuesto;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarImpuestosREst", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }
        public modelowmspctctrxCotizacion BuscarCotizacion(string Ccf_usuario, string Ccf_cod_emp, string Ccf_nro_trans)
        {
           

            try
            {
                ListaModelocotizacion = consultaMoneda.BuscartatrmCotizacion(Ccf_usuario, Ccf_cod_emp, Ccf_nro_trans);
                foreach (var item in ListaModelocotizacion)
                {
                    ModeloCotizacion = item;
                    break;
                }

                return ModeloCotizacion;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarCotizacion", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }
        public JsonRespuestaNC BuscarRespuestaDS(string Ccf_nro_trans)
        {
            try
            {
                ListaModelorespuestaDs = consultaRespuestaDS.ConsultaRespuestaQr(Ccf_nro_trans);

                foreach (var item in ListaModelorespuestaDs)
                {
                    ModeloResQr = item;
                    break;
                }

                return ModeloResQr;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_nro_trans, metodo, "BuscarRespuestaDS", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
        public modelowmspcempresas BuscarCabEmpresa(string Ccf_usuario, string Ccf_cod_emp)
        {
            try
            {
                ListaModeloempresa = consultaEmpresa.BuscartaEmpresa(Ccf_usuario, Ccf_cod_emp);
                foreach (var item in ListaModeloempresa)
                {
                    Modeloempresa = item;
                    break;
                }

                return Modeloempresa;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarCabEmpresa", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }

        public modeloUsuariosucursal BuscarUsuarioSucursal(string Ccf_cod_emp, string Ccf_usuario)
        {
            try
            {
                ListaUsuSucursal = ConsultaUsuSucursal.ConsultaUsuarioSucursal(Ccf_cod_emp, Ccf_usuario);
                foreach (var item in ListaUsuSucursal)
                {
                    ModeloUsuSucursal = item;
                    break;
                }

                return ModeloUsuSucursal;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarUsuarioSucursal", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }


    }
}
