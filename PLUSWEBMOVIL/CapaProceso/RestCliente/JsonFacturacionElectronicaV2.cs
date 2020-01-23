using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.RestCliente
{
    public class JsonFacturacionElectronicaV2
    {
        public modelowmtfacturascab conscabcera = new modelowmtfacturascab();
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

        public List<JsonRespuestaDE> ListaModelorespuestaDs = new List<JsonRespuestaDE>();
        public List<JsonRespuestaDE> ListaBuscarQr = null;
        public JsonRespuestaDE ModeloResQr = new JsonRespuestaDE();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();

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
        string metodo = "JsonFacturacionElectronicaV2.cs";
        public ComprobanteFacturaElecV2JSON LlenarJSONFactura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                ComprobanteFacturaElecV2JSON comprobanteFacturaJSON = new ComprobanteFacturaElecV2JSON();
                DocumentoFEV2 documento = new DocumentoFEV2();
                /* Datos de encabezado de la factura */

                documento.encabezado= LlenarEnacabezadoFacturaJSON(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                documento.detalle = LlenarDetalleFacturaJSON(Ccf_cod_emp, Ccf_usuario, Ccf_nro_trans);
                documento.impuesto = LlenarImpuestoFacturaJSON(Ccf_cod_emp, Ccf_usuario, Ccf_nro_trans, impuesto_rest);
                documento.sucursal = LlenarSucursalFacturaJSON(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                documento.tercero = LlenarTerceroFacturaJSON(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);

                comprobanteFacturaJSON.documento = documento;
                return comprobanteFacturaJSON;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarJSONFactura", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        public EncabezadoFEV2 LlenarEnacabezadoFacturaJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                EncabezadoFEV2 encabezado = new EncabezadoFEV2();

                listaConsDet = ConsultaDeta.ConsultaDetalleFacura(Ccf_nro_trans);

                conscabcera = null;
                conscabcera = buscarCabezeraFactura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);

                Modeloempresa = null;
                Modeloempresa = BuscarCabEmpresa(Ccf_usuario, Ccf_cod_emp);

                ModeloCotizacion = null;
                ModeloCotizacion = BuscarCotizacion(Ccf_usuario, Ccf_cod_emp, Ccf_nro_trans);

                Modelowmspclogo = null;
                Modelowmspclogo = BuscarUsuarioLogo(Ccf_cod_emp, Ccf_usuario);
                //Pruebas emisor 830106032
                //Produccion emisor =Convert.ToInt32(Modeloempresa.nro_dgi2);
                //nUEVOS CAMPOS FE version2
                encabezado.baseimpuesto = Convert.ToDecimal(conscabcera.monto_imponible); //base imponible
                encabezado.codmoneda = conscabcera.cod_moneda.Trim();
                encabezado.comentarios = conscabcera.observaciones;
                encabezado.emisor = Convert.ToInt32(Modeloempresa.nro_dgi2);
                encabezado.factortrm = Convert.ToDecimal(ModeloCotizacion.tc_mov1c);
                encabezado.fecha = conscabcera.fec_doc.ToString("yyyy-MM-dd");
                encabezado.fvence = conscabcera.fec_venc.ToString("yyyy-MM-dd");
                encabezado.idsuc = 1;
                encabezado.idvendedor = Convert.ToInt32(conscabcera.cod_vendedor);
                encabezado.iva = Convert.ToDecimal(conscabcera.iva);
                encabezado.mediopago = "ZZZ";//POR DEFECTO ZZZ-------------
                if (conscabcera.cod_fpago.Trim() =="00") //1 = contado, 2= credito
                 { encabezado.metodopago = 1; }
                else
                {
                    encabezado.metodopago = 2;
                }

                
                encabezado.nit = Convert.ToInt64(conscabcera.nro_dgi2);
                encabezado.numero = Convert.ToInt32(conscabcera.nro_docum);
                encabezado.ordencompra = Convert.ToString(conscabcera.ocompra);
                // para prueba set
                encabezado.prefijo =  Convert.ToString(conscabcera.serie_docum.Trim());
                encabezado.subtotal = Convert.ToInt32(conscabcera.subtotal);
                encabezado.sucursal = Convert.ToInt16(conscabcera.cod_sucursal);
                encabezado.terminospago = "30"; //por defecto 30
                encabezado.total = Convert.ToInt32(conscabcera.total);
                encabezado.totalDet = listaConsDet.Count; //la cantidad de lineas del detalle de la factura
                encabezado.totalImp = 1; //la cantidad de lineas de los impuestos
                encabezado.usuario = Ccf_usuario;  //Usuario que facturo
                encabezado.versionfe = Modelowmspclogo.version_fe.Trim(); //version de facturacion electronica



                return encabezado;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarEnacabezadoPdfJSON", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        public List<DetalleFEV2> LlenarDetalleFacturaJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_nro_trans)
        {
            try
            {

                listaConsDet = ConsultaDeta.ConsultaDetalleFacura(Ccf_nro_trans);
                List<DetalleFEV2> detalle = new List<DetalleFEV2>();
                ModeloCotizacion = null;
                ModeloCotizacion = BuscarCotizacion(Ccf_usuario, Ccf_cod_emp, Ccf_nro_trans);

                foreach (var item in listaConsDet)
                {
                    DetalleFEV2 itemDetalle = new DetalleFEV2();
                    itemDetalle.adicional = "";
                    itemDetalle.cantidad = Convert.ToInt32(item.cantidad);
                    itemDetalle.idproducto = item.cod_articulo.Trim();
                    itemDetalle.idunidad = "EA";//Por defecto
                    itemDetalle.iva = Convert.ToInt32(item.valor_iva);
                    if (conscabcera.cod_moneda.Trim() != "COP")
                    {
                        itemDetalle.ivausd = Convert.ToDecimal(ModeloCotizacion.tc_mov1c) * itemDetalle.iva;
                    }
                    else
                    { itemDetalle.ivausd = 0; }

                    itemDetalle.nombreproducto = item.nom_articulo.Trim()+ " "+item.nom_articulo2.Trim();
                    itemDetalle.operacion = "SA"; //Factura en venta
                    itemDetalle.porcdcto = Convert.ToInt32(item.porc_descto);
                    itemDetalle.porciva = Convert.ToInt32(item.porc_iva);
                    itemDetalle.pos = item.linea;
                    itemDetalle.precio = Convert.ToInt32(item.precio_unit);
                    if (conscabcera.cod_moneda.Trim() != "COP")
                    {
                        itemDetalle.preciousd = Convert.ToDecimal(ModeloCotizacion.tc_mov1c) * itemDetalle.precio;
                    }
                    else { itemDetalle.preciousd = 0; }
                    itemDetalle.subpartidaarancelaria = ""; //por defecto en blanco
                    itemDetalle.subtotal = Convert.ToInt32(item.subtotal);
                    if (conscabcera.cod_moneda.Trim() != "COP")
                    {
                                             
                        itemDetalle.subtotalusd = Convert.ToDecimal(ModeloCotizacion.tc_mov1c) * itemDetalle.subtotal;
                    }
                    else
                    {
                        
                       
                        itemDetalle.subtotalusd = 0;
                    }
                    detalle.Add(itemDetalle);

                }



                return detalle;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarDetalleFacturaJSON", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        public List<ImpuestoFEV2> LlenarImpuestoFacturaJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_nro_trans, string impuesto_rest)
        {
            try
            {
                List<ImpuestoFEV2> impuesto = new List<ImpuestoFEV2>();
                ImpuestoFEV2 item = new ImpuestoFEV2();
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarImpuestoFacturaJSON", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }


        public SucursalFEV2 LlenarSucursalFacturaJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                SucursalFEV2 sucursal = new SucursalFEV2();
                TerceroFEV2 tercero = new TerceroFEV2();
                modelowmspctitulares vendedor = new modelowmspctitulares();
                modelowmspctitulares cliente = new modelowmspctitulares();

                string Ven__cod_tit = conscabcera.cod_cliente;
                cliente = null;
                cliente = buscarCliente(Ccf_usuario, Ccf_cod_emp, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi);

                ModeloUsuSucursal = BuscarUsuarioSucursal(Ccf_cod_emp, Ccf_usuario);

                vendedor = null;
                vendedor = buscarCliente(Ccf_usuario, Ccf_cod_emp, "vendedores", conscabcera.cod_vendedor, Ven__cod_dgi);

                sucursal.ciudad = vendedor.nom_ciudad;
                sucursal.codcliente = conscabcera.cod_cliente;
                sucursal.codpostal = "000000"; //por defecto
                sucursal.contacto1 = cliente.razon_social; //persona cotacto
                sucursal.ctoemail1 = cliente.email_tit; //email contacto
                sucursal.departamento = vendedor.nom_provincia;
                sucursal.direccion1 = vendedor.dir_tit;
                sucursal.dpto = vendedor.cod_provincia;
                sucursal.email = vendedor.email_tit;
                sucursal.emailfe = cliente.email_tit;
                sucursal.idsuc = Convert.ToInt16(conscabcera.cod_sucursal.Trim());
                sucursal.idvendedor = Convert.ToInt64(conscabcera.cod_vendedor);
                sucursal.movil = "";
                sucursal.mun = vendedor.ciudad_tit;
                sucursal.paisreceptor = "CO";//cliente.cod_pais; //pais del cliente iso 3166-1
                sucursal.razonsocial = vendedor.razon_social;
                sucursal.telefono1 = vendedor.tel_tit;
                sucursal.telefono2 = "";
                return sucursal;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarSucursalFacturaJSON", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        public TerceroFEV2 LlenarTerceroFacturaJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {

                TerceroFEV2 tercero = new TerceroFEV2();

                modelowmspctitulares cliente = new modelowmspctitulares();

                string Ven__cod_tit = conscabcera.cod_cliente;
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
                tercero.obligacionfiscal = "O-99"; //por defecto
                tercero.razonsocial = cliente.razon_social;
                tercero.regimentributacion = cliente.regimen_tributacion;//48-49
                tercero.tdoc = Convert.ToInt16(cliente.cod_dgi);
                tercero.tipopersona = cliente.control_tit;
                tercero.tributoreceptor = "01";//POR DEFECTO

                return tercero;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarTerceroFacturaJSON", e.ToString(), DateTime.Now, Ccf_usuario);
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

                guardarExcepcion.ClaseInsertarExcepcion(Ven__cod_emp, metodo, " buscarCliente", e.ToString(), DateTime.Now, Ven__usuario);
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

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "buscarDetalleFactura", e.ToString(), DateTime.Now, "consulta");
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "buscarCabezeraFactura", e.ToString(), DateTime.Now,Ccf_usuario);
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarUsuarioLogo", e.ToString(), DateTime.Now, Ccf_usuario);
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarImpuestosREst", e.ToString(), DateTime.Now, Ccf_usuario);
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarCotizacion", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }
        public JsonRespuestaDE BuscarRespuestaDS(string Ccf_nro_trans)
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_nro_trans, metodo, "BuscarRespuestaDS", e.ToString(), DateTime.Now, "consulta");
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarCabEmpresa", e.ToString(), DateTime.Now, Ccf_usuario);
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "BuscarUsuarioSucursal", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }


    }
}
