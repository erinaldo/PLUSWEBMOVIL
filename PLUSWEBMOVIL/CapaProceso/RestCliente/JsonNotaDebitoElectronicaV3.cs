﻿using CapaDatos.Modelos;
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
    public class JsonNotaDebitoElectronicaV3
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
        FacturaDescuento consultaDesc = new FacturaDescuento();
        List<ModeloDescCargoFac> ListaDesc = new List<ModeloDescCargoFac>();
        ModeloDescCargoFac modelodescuento = new ModeloDescCargoFac();

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
        string metodo = "JsonNotaDebitoElectronicaV3.cs";
        public string nit_validado = null;
        public string nit_dian = null;
        public ComprobanteNDJSONV3 LlenarJSONNC(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string nro_factura)
        {
            try
            {
                ComprobanteNDJSONV3 comprobanteNCJSON = new ComprobanteNDJSONV3();
                DocumentoNDV3 documento = new DocumentoNDV3();
                /* Datos de encabezado de la nc */

                documento.encabezado = LlenarEnacabezadoNCJSON(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, nro_factura);
                documento.detalle = LlenarDetalleNCJSON(Ccf_cod_emp, Ccf_usuario, Ccf_nro_trans);
                documento.concepto = LlenarConceptoNCJSON(Ccf_cod_emp, Ccf_usuario, Ccf_nro_trans);
                documento.impuesto = LlenarImpuestoNCJSON(Ccf_cod_emp, Ccf_usuario, Ccf_nro_trans, impuesto_rest);
                documento.sucursal = LlenarSucursalNCJSON(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                documento.tercero = LlenarTerceroNCJSON(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);

                comprobanteNCJSON.documento = documento;
                return comprobanteNCJSON;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarJSONNC", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        public EncabezadoNDV3 LlenarEnacabezadoNCJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string nro_factura)
        {
            try
            {
                string tipoFactura = "";
                EncabezadoNDV3 encabezado = new EncabezadoNDV3();

                ListaDesc = consultaDesc.ConsultaDescCargTrans(Ccf_cod_emp, Ccf_usuario, Ccf_nro_trans);
                //Recuperar el cufe ce la factura
                ListaModelorespuestaDs = consultaRespuestaDS.ConsultaCUFE(nro_factura);
                int count =0;
                foreach (var item in ListaModelorespuestaDs)
                {
                         ModeloResQr = item;
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

                listaConsCab = ConsultaCabe.ConsultaTipoFactura(nro_factura); //tipo de nc o fc
                conscabceraTipo = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {

                    conscabceraTipo = item;

                }
               
                 tipoFactura = conscabceraTipo.tipo_nce.Trim();
                
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
                if (conscabceraNCMot.mot_nce.Trim() == "4")//por anulacion nc
                {
                    ModeloCotizacion = BuscarCotizacion(Ccf_usuario, Ccf_cod_emp, nro_factura);
                }
                else { ModeloCotizacion = BuscarCotizacion(Ccf_usuario, Ccf_cod_emp, Ccf_nro_trans); }

                Modelowmspclogo = null;
                Modelowmspclogo = BuscarUsuarioLogo(Ccf_cod_emp, Ccf_usuario);

                List<modelowmspcfacturasWMimpuRest> ListaAux = new List<modelowmspcfacturasWMimpuRest>();
                ListaModeloimpuesto = consultaImpuesto.BuscarImpuestoRest(Ccf_usuario, Ccf_cod_emp, Ccf_nro_trans, impuesto_rest);
                foreach (modelowmspcfacturasWMimpuRest items in ListaModeloimpuesto)
                {
                    if (items.nom_impuesto.Trim() == "IVA GENERADO")
                    {
                        ListaAux.Add(items);

                    }

                }
                //vALIDAR NIT, EXTRANJERO Y CONSUMIDOR FINAL
                string nit_dian = ConsumidorFinal(conscabceraNC.nro_dgi2.Trim(), Ccf_usuario, Ccf_cod_emp); //Verific si es consumidor o no
                
                if (conscabceraNC.cod_moneda.Trim() != "COP")
                {
                    encabezado.baseimpuesto = Convert.ToDecimal(conscabceraNC.monto_imponible) * Convert.ToDecimal(ModeloCotizacion.tc_mov1c); //base imponible
                }
                else
                { encabezado.baseimpuesto = Convert.ToDecimal(conscabceraNC.monto_imponible); }
                
                encabezado.codmoneda = conscabceraNC.cod_moneda.Trim();
                encabezado.comentarios = conscabceraNC.observaciones;
                encabezado.emisor = Convert.ToInt32(Modeloempresa.nro_dgi2);
                encabezado.factortrm = Convert.ToDecimal(ModeloCotizacion.tc_mov1c);
                encabezado.fecha = conscabceraNC.fec_doc.ToString("yyyy-MM-dd");
                encabezado.fvence = conscabceraNC.fec_venc.ToString("yyyy-MM-dd");
                encabezado.idsuc = 1;// Convert.ToInt16(conscabceraNC.cod_sucursal); //Va a traer sucursal de la empresa con la que se factura
                encabezado.idvendedor = Convert.ToInt32(conscabceraNC.cod_vendedor);
                if (conscabceraNC.cod_moneda.Trim() != "COP")
                {
                    encabezado.iva = Convert.ToDecimal(conscabceraNC.iva) * Convert.ToDecimal(ModeloCotizacion.tc_mov1c);
                }
                else
                {
                    encabezado.iva = Convert.ToDecimal(conscabceraNC.iva);
                }
                
                encabezado.mediopago = "ZZZ";//POR DEFECTO ZZZ
                if (conscabceraNC.cod_fpago.Trim() == "00") //1 = contado, 2= credito
                { encabezado.metodopago = 1; }
                else
                {
                    encabezado.metodopago = 2;
                }
               
                encabezado.nit = Convert.ToInt64(nit_dian);
                encabezado.numero = Convert.ToInt32(conscabceraNC.nro_docum);
                encabezado.ordencompra = Convert.ToString(conscabceraNC.ocompra);
                encabezado.prefijo = Convert.ToString(conscabceraNC.serie_docum.Trim());
                encabezado.ref_cufe = ModeloResQr.cufe; //CUFE Factura emitida
                encabezado.ref_doc = conscabcera.serie_docum; //prefijo de la factura parapruebas
                encabezado.ref_fecha = conscabcera.fec_doc.ToString("yyyy-MM-dd");
                encabezado.ref_num = Convert.ToInt64(conscabcera.nro_docum); //numero de la factura
                                                                             //encabezado.prefijo = "NC"; // para pruebas (NC)
                if (conscabceraNC.cod_moneda.Trim() != "COP")
                {
                    encabezado.subtotal = Convert.ToDecimal(conscabceraNC.subtotal) * Convert.ToDecimal(ModeloCotizacion.tc_mov1c); //base imponible
                }
                else
                {
                    encabezado.subtotal = conscabceraNC.subtotal; 
                }

                encabezado.sucursal = 1;// Convert.ToInt16(conscabceraNC.cod_sucursal);
                encabezado.terminospago = "30"; //por defecto 30
                encabezado.tlmotivodv = Convert.ToInt32(conscabceraNCMot.mot_nce);//NC PARA ANULAR FACTURA (2)
               
                if (conscabceraNC.cod_moneda.Trim() != "COP")
                {
                    encabezado.total = Convert.ToDecimal(conscabceraNC.total) * Convert.ToDecimal(ModeloCotizacion.tc_mov1c); //base imponible
                }
                else
                {
                    encabezado.total = conscabceraNC.total;
                }
                //OTROA CONCEPTOS
                if (conscabcera.cod_moneda.Trim() != "COP")
                {
                    encabezado.otrosconceptos = Convert.ToDecimal(conscabceraNC.desctos_rcgos) * Convert.ToDecimal(ModeloCotizacion.tc_mov1c); //base imponible
                }
                else
                {
                    encabezado.otrosconceptos = conscabceraNC.desctos_rcgos;
                }
               
                encabezado.totalDet = listaConsDet.Count; //la cantidad de lineas del detalle de la factura
                encabezado.totalImp = ListaAux.Count; //la cantidad de lineas de los impuestos
                encabezado.totalCon = ListaDesc.Count; //Total lineas de conceptos Descuento y Cargos
                encabezado.usuario = Ccf_usuario;  //Usuario que facturo
                encabezado.versionfe = Modelowmspclogo.version_fe.Trim(); //version de facturacion electronica

                return encabezado;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarEnacabezadoNCJSON", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        public List<ConceptoNDV3> LlenarConceptoNCJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_nro_trans)
        {
            try
            {
                ListaDesc = null;
                ListaDesc = consultaDesc.ConsultaDescCargTrans(Ccf_cod_emp, Ccf_usuario, Ccf_nro_trans);
                List<ConceptoNDV3> concepto = new List<ConceptoNDV3>();

                foreach (var item in ListaDesc)
                {
                    ConceptoNDV3 itemDetalle = new ConceptoNDV3();
                    itemDetalle.naturaleza = item.signo.ToLower();
                    itemDetalle.transaccion = item.nom_concepto;
                    itemDetalle.coddescuento = item.cod_concepto_fis.Trim();

                    if (conscabcera.cod_moneda.Trim() != "COP")
                    {
                        itemDetalle.valor = Convert.ToDecimal(ModeloCotizacion.tc_mov1c) * item.valor_descto;
                        itemDetalle.Base = Convert.ToDecimal(ModeloCotizacion.tc_mov1c) * item.valor_descto;
                        itemDetalle.porcentaje = 100;
                    }
                    else
                    {
                        itemDetalle.valor = item.valor_descto;
                        itemDetalle.Base = item.valor_descto;
                        itemDetalle.porcentaje = 100;
                    }

                    concepto.Add(itemDetalle);
                }

                return concepto;
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarConceptoNCJSON", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }
        public List<DetalleNDV3> LlenarDetalleNCJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_nro_trans)
        {

            try
            {
                listaConsDet = ConsultaDeta.ConsultaDetalleFacura(Ccf_nro_trans);
                List<DetalleNDV3> detalle = new List<DetalleNDV3>();

                foreach (var item in listaConsDet)
                {
                    DetalleNDV3 itemDetalle = new DetalleNDV3();
                    itemDetalle.adicional = "";
                    itemDetalle.cantidad = Convert.ToInt32(item.cantidad);
                    itemDetalle.idproducto = item.cod_articulo.Trim();
                    itemDetalle.idunidad = "EA";//Pore defecto v2
                    itemDetalle.iva = Convert.ToInt32(item.valor_iva);
                    if (conscabceraNC.cod_moneda.Trim() != "COP")
                    {
                        itemDetalle.iva = Convert.ToDecimal(ModeloCotizacion.tc_mov1c) * item.valor_iva;
                    }
                    else { itemDetalle.iva = item.valor_iva; }
                    if (conscabceraNC.cod_moneda.Trim() != "COP")
                    {
                        itemDetalle.ivausd = item.valor_iva;
                    }
                    else
                    { itemDetalle.ivausd = 0; }

                    itemDetalle.nombreproducto = item.nom_articulo;
                    itemDetalle.operacion = "SA"; //Factura en venta
                    itemDetalle.porcdcto = Convert.ToInt32(item.porc_descto);
                    itemDetalle.porciva = Convert.ToInt32(item.porc_iva);
                    itemDetalle.pos = item.linea;
                   
                    if (conscabceraNC.cod_moneda.Trim() != "COP")
                    {
                        itemDetalle.precio = Convert.ToDecimal(ModeloCotizacion.tc_mov1c) * item.precio_unit;
                    }
                    else { itemDetalle.precio = item.precio_unit; }

                    if (conscabceraNC.cod_moneda.Trim() != "COP")
                    {
                        itemDetalle.preciousd = item.precio_unit;
                    }
                    else { itemDetalle.preciousd = 0; }
                    itemDetalle.subpartidaarancelaria = "";
                    if (conscabcera.cod_moneda.Trim() != "COP")
                    {
                        itemDetalle.subtotal = Convert.ToDecimal(ModeloCotizacion.tc_mov1c) * item.subtotal;
                    }
                    else { itemDetalle.subtotal = item.subtotal; }


                    if (conscabcera.cod_moneda.Trim() != "COP")
                    {
                        itemDetalle.subtotalusd = item.subtotal;
                    }
                    else
                    {
                        itemDetalle.subtotalusd = 0;
                    }
                    itemDetalle.esexcluido = "N";
                    detalle.Add(itemDetalle);

                }

                return detalle;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarDetalleNCJSON", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        public List<ImpuestoNDV3> LlenarImpuestoNCJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_nro_trans, string impuesto_rest)
        {
            try
            {
                List<ImpuestoNDV3> impuesto = new List<ImpuestoNDV3>();
               
                List<modelowmspcfacturasWMimpuRest> ListaAux = new List<modelowmspcfacturasWMimpuRest>();
                //Buscamos todos los impuestos de la factura
                ListaModeloimpuesto = consultaImpuesto.BuscarImpuestoRest(Ccf_usuario, Ccf_cod_emp, Ccf_nro_trans, impuesto_rest);
                foreach (modelowmspcfacturasWMimpuRest items in ListaModeloimpuesto)
                {
                    if (items.nom_impuesto.Trim() == "IVA GENERADO")
                    {
                        ListaAux.Add(items);

                    }

                }
                foreach (modelowmspcfacturasWMimpuRest ModeloImpuestos in ListaAux)
                {
                    ImpuestoNDV3 item = new ImpuestoNDV3();
                    if (conscabceraNC.cod_moneda.Trim() != "COP")
                    {
                        item.base_calculo = Convert.ToDecimal(ModeloImpuestos.base_impu) * Convert.ToDecimal(ModeloCotizacion.tc_mov1c);
                        item.porciva = Convert.ToDecimal(ModeloImpuestos.porc_impu);
                        item.valor = Convert.ToDecimal(ModeloImpuestos.valor_impu) * Convert.ToDecimal(ModeloCotizacion.tc_mov1c);
                    }
                    else
                    {

                        item.base_calculo = Convert.ToDecimal(ModeloImpuestos.base_impu);
                        item.porciva = Convert.ToDecimal(ModeloImpuestos.porc_impu);
                        item.valor = Convert.ToDecimal(ModeloImpuestos.valor_impu);
                    }
                    impuesto.Add(item);
                }

                return impuesto;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarImpuestoNCJSON", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }


        public SucursalNDV3 LlenarSucursalNCJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                SucursalNDV3 sucursal = new SucursalNDV3();
                TerceroNDV3 tercero = new TerceroNDV3();

                ModeloUsuSucursal = BuscarUsuarioSucursal(Ccf_cod_emp, Ccf_usuario);

                //----------------DATOS PROPISO DE LA SUCURSAL DEL CLIENTE AL QUE SE FACTURA----------------------------
                sucursal.ciudad = cliente.ciudad_tit; //nombre ciudad
                sucursal.codcliente = conscabceraNC.cod_cliente;
                sucursal.codpostal = "000000"; //por defecto
                sucursal.contacto1 = cliente.razon_social; //persona cotacto
                sucursal.ctoemail1 = cliente.email_tit; //email contacto.sucursal
                sucursal.departamento = cliente.nom_provincia;
                sucursal.direccion1 = cliente.dir_tit;
                sucursal.dpto = cliente.cod_provincia;
                sucursal.email = cliente.email_tit;
                sucursal.emailfe = cliente.email_tit;
                sucursal.idsuc = 1;// Convert.ToInt16(conscabceraNC.cod_sucursal); //Va a traer sucursal de la empresa con la que se factura;
                sucursal.idvendedor = Convert.ToInt64(conscabceraNC.cod_vendedor);
                sucursal.movil = "";
                sucursal.mun = cliente.ciudad_tit;
                sucursal.paisreceptor = "CO";//cliente.cod_pais; //pais del cliente iso 3166-1
                sucursal.razonsocial = cliente.razon_social;
                sucursal.telefono1 = cliente.tel_tit;
                sucursal.telefono2 = "";
                return sucursal;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarSucursaNCJSON", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        public TerceroNDV3 LlenarTerceroNCJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                TerceroNDV3 tercero = new TerceroNDV3();

                tercero.apli1 = cliente.primer_apellido;
                tercero.apl2 = cliente.segundo_apellido;
                tercero.comentarios = "";
                tercero.dv = cliente.nro_dgi1; //digito verificador
                tercero.identificacion = Convert.ToInt64(nit_validado);
                tercero.idtipoempresa = Convert.ToInt16(Modeloempresa.cod_emp);
                tercero.nit = Convert.ToInt64(nit_dian); 
                tercero.nom1 = cliente.primer_nombre;
                tercero.nom2 = cliente.segundo_nombre;
                tercero.obligacionfiscal = cliente.obligacion_fiscal; //por defecto
                tercero.razonsocial = cliente.razon_social;
                tercero.regimentributacion = cliente.regimen_tributacion;//48-49
                tercero.tdoc = Convert.ToInt16(cliente.cod_dgi);
                tercero.tipopersona = cliente.control_tit;
                tercero.tributoreceptor = "01";//POR DEFECTO
                return tercero;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "LlenarTerceroNCJSON", e.ToString(), DateTime.Now, Ccf_usuario);
                return null;
            }
        }

        public modelowmspctitulares buscarCliente(string Ven__usuario, string Ven__cod_emp, string Ven__cod_tipotit, string Ven__cod_tit, string Ven__cod_dgi, string cod_suc)
        {

            try
            {
                lista = ConsultaTitulares.ConsultaTitulares(Ven__usuario, Ven__cod_emp, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi, cod_suc);
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "buscarCabezeraNC", e.ToString(), DateTime.Now, Ccf_usuario);
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "buscarCabezeraFactura", e.ToString(), DateTime.Now, Ccf_usuario);
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

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_nro_trans, metodo, "buscarMotNC", e.ToString(), DateTime.Now,"consulta");
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

        public string ConsumidorFinal(string nit_cliente_Cab, string usuario, string empresa)
        {
            try
            {

                //NIT EXTRANJERO SOLO AUTORIZA ENVIANDO 8 NUMEROS
                modelowmspctitulares cliente = new modelowmspctitulares();

                string Ven__cod_tit = nit_cliente_Cab.Trim();
                cliente = null;
                cliente = buscarCliente(usuario, empresa, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi, conscabceraNC.cod_suc_cli.Trim());
                if (cliente.cod_dgi.Trim() == "14" || cliente.cod_dgi.Trim() == "22" || cliente.cod_dgi.Trim() == "42" || cliente.cod_dgi.Trim() == "43" || cliente.cod_dgi.Trim() == "50")
                {
                    //EXTRANJERO SOLO AUTORIZA CON NIT DE 8
                    if (nit_cliente_Cab.Length > 8)
                    {
                        nit_dian = nit_cliente_Cab.Remove(8);
                        nit_validado = nit_cliente_Cab.Remove(8);
                    }
                    else
                    {
                        nit_dian = nit_cliente_Cab.Trim();
                        nit_validado = nit_cliente_Cab.Trim();//Identificacion en sucursal debe se 8 caracteres.
                    }

                }
                else
                {

                    if (nit_cliente_Cab.Trim() == "22222222222" || nit_cliente_Cab.Trim() == "222222222222") //consumidor final
                    {
                        nit_dian = "222222222";
                        nit_validado = "222222222222"; //Identificacion debe ser 12 siempre
                    }
                    else
                    {
                        if (nit_cliente_Cab.Trim() == "2222222222")
                        {
                            nit_dian = "222222222";
                            nit_validado = "222222222222"; //Identificacion debe ser 12 siempre
                        }
                        else
                        {
                            if (nit_cliente_Cab.Length > 10)
                            {
                                nit_dian = nit_cliente_Cab.Remove(10);
                                nit_validado = nit_cliente_Cab.Trim();
                            }
                            else
                            {
                                nit_dian = nit_cliente_Cab.Trim();
                                nit_validado = nit_cliente_Cab.Trim();
                            }
                        }

                    }

                }
                return nit_dian;
            }
            catch (Exception e)
            {

                 guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "ConsumidorFinal", e.ToString(), DateTime.Now, usuario);
                return null;
            }
        }
    }
}
