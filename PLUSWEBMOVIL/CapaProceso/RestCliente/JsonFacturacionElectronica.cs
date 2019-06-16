﻿using CapaDatos.Modelos;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.RestCliente
{
    public class JsonFacturacionElectronica
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
        public string Ven__cod_tipotit = "cliente";
        public string Ven__cod_tit = " ";
        public string impuesto_rest = "0";
        public ComprobanteFacturaJSON LlenarJSONFactura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            ComprobanteFacturaJSON comprobanteFacturaJSON = new ComprobanteFacturaJSON();
            Documento documento = new Documento();
            /* Datos de encabezado de la factura */

            documento.encabezado = LlenarEnacabezadoFacturaJSON(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
            documento.detalle = LlenarDetalleFacturaJSON(Ccf_cod_emp, Ccf_usuario, Ccf_nro_trans);
            documento.impuesto = LlenarImpuestoFacturaJSON(Ccf_cod_emp, Ccf_usuario, Ccf_nro_trans, impuesto_rest);
            documento.sucursal = LlenarSucursalFacturaJSON(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
            documento.tercero = LlenarTerceroFacturaJSON(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);

            comprobanteFacturaJSON.documento = documento;
            return comprobanteFacturaJSON;
        }

        public Encabezado LlenarEnacabezadoFacturaJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            Encabezado encabezado = new Encabezado();

            listaConsDet = ConsultaDeta.ConsultaDetalleFacura(Ccf_nro_trans);

            conscabcera = null;
            conscabcera = buscarCabezeraFactura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);

            Modeloempresa = null;
            Modeloempresa = BuscarCabEmpresa(Ccf_usuario, Ccf_cod_emp);

            ModeloCotizacion = null;
            ModeloCotizacion = BuscarCotizacion(Ccf_usuario, Ccf_cod_emp, Ccf_nro_trans);
           
            encabezado.emisor = Convert.ToInt32(Modeloempresa.nro_dgi2);
            encabezado.codmoneda = conscabcera.cod_moneda.Trim();
            encabezado.comentarios = conscabcera.observaciones;
            encabezado.factortrm = Convert.ToDecimal(ModeloCotizacion.tc_mov1c);
            encabezado.fecha = conscabcera.fec_doc.ToString("yyyy-MM-dd");
            encabezado.fvence = conscabcera.fec_venc.ToString("yyyy-MM-dd");
            encabezado.idsuc = 1;
            encabezado.idvendedor = Convert.ToInt32(conscabcera.cod_vendedor);
            encabezado.iva = Convert.ToDecimal(conscabcera.iva);
            encabezado.nit = Convert.ToInt64(conscabcera.nro_dgi2);
            encabezado.numero = Convert.ToInt32(conscabcera.nro_docum);
            encabezado.ordencompra = Convert.ToString(conscabcera.ocompra);
            encabezado.prefijo = Convert.ToString(conscabcera.serie_docum.Trim()); ;  // va quemado por defecto para los comprobantes de factura
            encabezado.subtotal = Convert.ToInt32(conscabcera.subtotal);
            encabezado.sucursal = Convert.ToInt16(conscabcera.cod_sucursal); 
            encabezado.total = Convert.ToInt32(conscabcera.total);
            encabezado.usuario = Ccf_usuario;  //Usuario que facturo
            encabezado.totalDet = listaConsDet.Count; //la cantidad de lineas del detalle de la factura
            encabezado.totalImp = 1; //la cantidad de lineas de los impuestos
            
            return encabezado;
        }

        public List<Detalle> LlenarDetalleFacturaJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_nro_trans)
        {

            
            listaConsDet = ConsultaDeta.ConsultaDetalleFacura(Ccf_nro_trans);
            List<Detalle> detalle = new List<Detalle>();
            ModeloCotizacion = null;
            ModeloCotizacion = BuscarCotizacion(Ccf_usuario, Ccf_cod_emp, Ccf_nro_trans);

            foreach (var item in listaConsDet)
            {
                Detalle itemDetalle = new Detalle();
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

        public List<Impuesto> LlenarImpuestoFacturaJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_nro_trans, string impuesto_rest)
        {
            List<Impuesto> impuesto = new List<Impuesto>();
            Impuesto item = new Impuesto();
            //Buscamos todos los impuestos de la factura
            ModeloImpuesto = null;
            ModeloImpuesto = BuscarImpuestosREst(Ccf_usuario, Ccf_cod_emp, Ccf_nro_trans, impuesto_rest);



            item.base_calculo = Convert.ToDecimal(ModeloImpuesto.base_impu);
            item.porciva = Convert.ToDecimal(ModeloImpuesto.porc_impu);
            item.valor = Convert.ToDecimal(ModeloImpuesto.valor_impu);

            impuesto.Add(item);

            return impuesto;
        }


        public Sucursal LlenarSucursalFacturaJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {

            Sucursal sucursal = new Sucursal();
            Tercero tercero = new Tercero();
            modelowmspctitulares vendedor = new modelowmspctitulares();

            ModeloUsuSucursal  = BuscarUsuarioSucursal (Ccf_cod_emp, Ccf_usuario);
          
            vendedor = null;
            vendedor = buscarCliente(Ccf_usuario, Ccf_cod_emp, "VEN", conscabcera.cod_vendedor);

            sucursal.ciudad = vendedor.nom_ciudad;
            sucursal.codcliente = conscabcera.cod_cliente;
            sucursal.departamento = vendedor.nom_provincia;
            sucursal.direccion1 = vendedor.dir_tit;
            sucursal.dpto = vendedor.cod_provincia;
            sucursal.email = vendedor.email_tit;
            sucursal.emailfe = vendedor.email_tit;
            sucursal.idsuc = Convert.ToInt16(ModeloUsuSucursal.cod_sucursal.Trim());
            sucursal.idvendedor = Convert.ToInt64(conscabcera.cod_vendedor);
            sucursal.movil = "";
            sucursal.mun = vendedor.ciudad_tit;            
            sucursal.razonsocial = vendedor.razon_social;
            sucursal.telefono1 = vendedor.tel_tit;
            sucursal.telefono2 = ""; 
            return sucursal;
        }

        public Tercero LlenarTerceroFacturaJSON(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {

            Tercero tercero = new Tercero();

            modelowmspctitulares cliente = new modelowmspctitulares();

            string Ven__cod_tit = conscabcera.cod_cliente;
            cliente = null;
            cliente = buscarCliente(Ccf_usuario, Ccf_cod_emp, Ven__cod_tipotit, Ven__cod_tit);

            tercero.apli1 = cliente.nom_tit;
            tercero.apl2 = "";
            tercero.comentarios = "";
            tercero.dv = cliente.nro_dgi1; //digito verificador
            tercero.identificacion = Convert.ToInt64(cliente.nro_dgi2);
            tercero.idtipoempresa = Convert.ToInt16(Modeloempresa.cod_emp);
            tercero.nit = Convert.ToInt64(cliente.nro_dgi2);
            tercero.nom1 = cliente.nom_tit;
            tercero.nom2 = "";
            tercero.razonsocial = cliente.razon_social;
            tercero.tdoc = Convert.ToInt16(cliente.cod_dgi);           
            tercero.tipopersona = cliente.control_tit;

            return tercero;
        }

        public modelowmspctitulares buscarCliente(string Ven__usuario, string Ven__cod_emp, string Ven__cod_tipotit, string Ven__cod_tit)
        {


            lista = ConsultaTitulares.ConsultaTitulares(Ven__usuario, Ven__cod_emp, Ven__cod_tipotit, Ven__cod_tit);
            int count = 0;
            cliente = null;
            foreach (modelowmspctitulares item in lista)
            {
                count++;
                cliente = item;

            }
            return cliente;
        }

        public ModeloDetalleFactura buscarDetalleFactura(string Ccf_nro_trans)
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
        public modelowmtfacturascab buscarCabezeraFactura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
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
        public modelowmspclogo BuscarUsuarioLogo(string Ccf_cod_emp, string Ccf_usuario)
        {
            ListaModelowmspclogo = consultaLogo.BuscartaLogo(Ccf_cod_emp, Ccf_usuario);

            foreach (var item in ListaModelowmspclogo)
            {
                Modelowmspclogo = item;
                break;
            }

            return Modelowmspclogo;
        }
        public modelowmspcfacturasWMimpuRest BuscarImpuestosREst(string Ccf_usuario, string Ccf_cod_emp, string Ccf_nro_trans, string impuesto)
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
        public modelowmspctctrxCotizacion BuscarCotizacion(string Ccf_usuario, string Ccf_cod_emp, string Ccf_nro_trans)
        {
            ListaModelocotizacion = consultaMoneda.BuscartatrmCotizacion(Ccf_usuario, Ccf_cod_emp, Ccf_nro_trans);
            foreach (var item in ListaModelocotizacion)
            {
                ModeloCotizacion = item;
                break;
            }

            return ModeloCotizacion;
        }
        public JsonRespuestaDE BuscarRespuestaDS(string Ccf_nro_trans)
        {
            ListaModelorespuestaDs = consultaRespuestaDS.ConsultaRespuestaQr(Ccf_nro_trans);

            foreach (var item in ListaModelorespuestaDs)
            {
                ModeloResQr = item;
                break;
            }

            return ModeloResQr;
        }
        public modelowmspcempresas BuscarCabEmpresa(string Ccf_usuario, string Ccf_cod_emp)
        {
            ListaModeloempresa = consultaEmpresa.BuscartaEmpresa(Ccf_usuario, Ccf_cod_emp);
            foreach (var item in ListaModeloempresa)
            {
                Modeloempresa = item;
                break;
            }

            return Modeloempresa;
        }

        public modeloUsuariosucursal BuscarUsuarioSucursal(string Ccf_cod_emp, string Ccf_usuario)
        {
            ListaUsuSucursal = ConsultaUsuSucursal.ConsultaUsuarioSucursal(Ccf_cod_emp, Ccf_usuario);
            foreach (var item in ListaUsuSucursal)
            {
                ModeloUsuSucursal = item;
                break;
            }

            return ModeloUsuSucursal;
        }


    }
}
