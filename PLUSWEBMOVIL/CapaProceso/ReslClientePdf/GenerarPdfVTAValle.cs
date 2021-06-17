using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using CapaProceso.RestCliente;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace CapaProceso.ReslClientePdf
{
    public class GenerarPdfVTAValle
    {
        Consultawmsptitulares ConsultaTitulares = new Consultawmsptitulares();
        modelowmspctitulares cliente = new modelowmspctitulares();
        List<modelowmspctitulares> lista = null;
        public modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        public ModeloDetalleFactura consdetalle = new ModeloDetalleFactura();
        public List<modelowmtfacturascab> listaConsCab = null;
        public List<ModeloDetalleFactura> listaConsDet = null;
        public Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();
        public Consultawmtfacturasdet ConsultaDeta = new Consultawmtfacturasdet();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public ConsultawmspctctrxCotizacion consultaMoneda = new ConsultawmspctctrxCotizacion();
        public ConsultaBancos consultabanco = new ConsultaBancos();
        public Consultaparamcomercial consultaComercial = new Consultaparamcomercial();
        public ConsultaEmpresa consultaEmpresa = new ConsultaEmpresa();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();
        public List<modelowmspctctrxCotizacion> ListaModelocotizacion = new List<modelowmspctctrxCotizacion>();
        public List<modelobancos> ListaModelobancos = new List<modelobancos>();
        public List<modelowmspcempresas> ListaModeloempresa = new List<modelowmspcempresas>();
        public List<modeloparametrocomercial> ListaModelocomercial = new List<modeloparametrocomercial>();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public modelowmspcempresas Modeloempresa = new modelowmspcempresas();
        public modeloparametrocomercial Modelocomercial = new modeloparametrocomercial();
        public modelobancos ModeloBancos = new modelobancos();
        public modelowmspctctrxCotizacion ModeloCotizacion = new modelowmspctctrxCotizacion();

        modelowmspcmonedas DecimalesMoneda = new modelowmspcmonedas();
        Consultawmspcmonedas ConsultaCMonedas = new Consultawmspcmonedas();
        List<modelowmspcmonedas> listaMonedas = null;

        public List<JsonRespuestaDSFEV2> ListaModelorespuestaDs = new List<JsonRespuestaDSFEV2>();
        public JsonRespuestaDSFEV2 ModeloResQr = new JsonRespuestaDSFEV2();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();

        Consultawmspcresfact ConsultaResolucion = new Consultawmspcresfact();
        modelowmspcresfact resolucion = new modelowmspcresfact();
        List<modelowmspcresfact> listaRes = null;

        public List<modelowmspcfacturasWMimpuRest> ListaModeloimpuesto = new List<modelowmspcfacturasWMimpuRest>();
        public modelowmspcfacturasWMimpuRest ModeloImpuesto = new modelowmspcfacturasWMimpuRest();
        public ConsultawmspcfacturasWMimpuRest consultaImpuesto = new ConsultawmspcfacturasWMimpuRest();

        FacturaDescuento consultaDesc = new FacturaDescuento();
        List<ModeloDescCargoFac> ListaDesc = new List<ModeloDescCargoFac>();
        ModeloDescCargoFac modelodescuento = new ModeloDescCargoFac();

        public modeloSucuralempresa ModelosucursalEmpresa = new modeloSucuralempresa();
        public modeloSucuralempresa PrefijosucursalEmpresa = new modeloSucuralempresa();
        public List<modeloSucuralempresa> ListaModeloSucursalEmpresa = new List<modeloSucuralempresa>();
        public ConsultaSucursalempresa ConsultaSucEmpresa = new ConsultaSucursalempresa();
        public Consultawmsucempresa ConsultaSucursal = new Consultawmsucempresa();

        ConsultaMediosPago consultaMediosPago = new ConsultaMediosPago();
        public List<modeloFacturasPagos> listaPagosPgs = null; //Modelos recuperar de la tabla wmt_facturas_pgs
        modeloFacturasPagos modeloPagosPgs = new modeloFacturasPagos(); //Modelos recuperar de la tabla wmt_facturas_pgs

        modelowmspctitulares cliente_valido = new modelowmspctitulares();

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
        public string Ven__cod_dgi = "0";
        public string Ven__fono = "0";
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        Articulos consulta_uni = new Articulos();
        ConsultaEValle datosValle = new ConsultaEValle();
        modeloValleDian modeloVDian = new modeloValleDian();
        EstructuraValle modeloWService = new EstructuraValle();
        ValidarParametrizacionFactura conexion_valle = new ValidarParametrizacionFactura();
        string metodo = "GenerarPdfVTAValle.cs";

        public modelowmspclogo BuscarEmpresa(string empresa, string usuario)
        {
            try
            {
                ListaModelowmspclogo = consultaLogo.BuscartaLogo(empresa, usuario);
                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }

                return Modelowmspclogo;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "BuscarEmpresa", e.ToString(), DateTime.Now, usuario);
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

        public JsonRespuestaDSFEV2 BuscarRespuestaDS(string nro_trans)
        {
            try
            {
                ListaModelorespuestaDs = consultaRespuestaDS.ConsultaResQrDS(nro_trans);

                foreach (var item in ListaModelorespuestaDs)
                {
                    if (item.qrdata != " ")
                    {
                        ModeloResQr = item;
                        break;
                    }

                }

                return ModeloResQr;
            }
            catch (Exception e)
            {
                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, metodo, "BuscarRespuestaDS", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }
        public string generarPdf(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {
            try
            {
                string pathpdf = "";
                //Consultar ocompra
                conscabcera = null;
                conscabcera = buscarCabezeraFactura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);
                //Consultar cufe, qr
                /* ModeloResQr = null;  //Traemos el QR respuesta
                 ModeloResQr = BuscarRespuestaDS(Ccf_nro_trans);
                 string texto = "";
                 if (ModeloResQr != null)
                 {
                     texto = ModeloResQr.qrdata;
                 }
                 //Actualizar en EValle tabla DatoDian
                 if (texto != "")
                 {
                     modeloVDian.cod_emp = Ccf_cod_emp;
                     modeloVDian.usuario_mod = Ccf_usuario;
                     modeloVDian.nro_factura = conscabcera.ocompra.Trim();
                     modeloVDian.cufe = ModeloResQr.cufe;
                     modeloVDian.qr = ModeloResQr.qrdata;
                     modeloVDian.fecha_autorizacion = ModeloResQr.fecha_mod;
                     modeloVDian.fecha_generacion = conscabcera.fec_doc.ToString();
                     modeloVDian.nro_factura_electronica =conscabcera.serie_docum.Trim()+conscabcera.nro_docum.Trim();
                     string cadena = ModeloResQr.qrdata;
                     string cadena2 = cadena.Substring(cadena.IndexOf("https"));
                     modeloVDian.link = cadena2;
                     datosValle.ActualizarDatoDian(modeloVDian);
                 }*/
                //Consultar web service VALLE PDF

                Modelowmspclogo = null;
                Modelowmspclogo = BuscarEmpresa(Ccf_cod_emp, Ccf_usuario);
                string json = "";
                modeloWService.nroFactura = conscabcera.ocompra.Trim();// "8735";
                modeloWService.connectionString = conexion_valle.ConsultaConexionEVallePDF(Ccf_cod_emp, Ccf_usuario);
                modeloWService.pdfPath = Modelowmspclogo.pathtmpfac;
                json = JsonConvert.SerializeObject(modeloWService);
                bool error = false;
                var client = new RestClient(Modelowmspclogo.linkrestext);
                var request = new RestRequest(Method.POST);

                request.AddHeader("Authorization", "Basic ");
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                request.AddParameter("application/json", json, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                string tipo = response.ContentType;
                if (tipo.Equals("application/json"))
                {
                    pathpdf = response.Content;
                    pathpdf = pathpdf.Replace("\\", @"\");

                }



                return pathpdf;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "generarPdf", e.ToString(), DateTime.Now, Ccf_usuario);
                return "No se pudo completar la acción." + "generarPdf." + " Por favor notificar al administrador.";
            }
        }

    }
}
