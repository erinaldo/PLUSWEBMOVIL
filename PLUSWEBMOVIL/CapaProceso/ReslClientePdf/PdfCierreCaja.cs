using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;

using CapaDatos.Modelos;
using System.Globalization;
using System.IO;
using System.Web;

using CapaDatos.Sql;

using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace CapaProceso.ReslClientePdf
{
  public   class PdfCierreCaja
    {

        public modeloSucuralempresa ModelosucursalEmpresa = new modeloSucuralempresa();
        public List<modeloSucuralempresa> ListaModeloSucursalEmpresa = new List<modeloSucuralempresa>();
        public Consultawmsucempresa ConsultaSucEmpresa = new Consultawmsucempresa();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        ConsultaCierecaja ConsultaCCaja = new ConsultaCierecaja();
        modeloCierreCaja modeloCCcaja = new modeloCierreCaja();
        modeloCierreCaja guardarCCcaja = new modeloCierreCaja();
        List<modeloCierreCaja> listaCCaja = null;

        ConsultaEfectivoCaja ConsultaEfectivoC = new ConsultaEfectivoCaja();
        modeloEfectivoCaja modeloEfectivoC = new modeloEfectivoCaja();
        modeloEfectivoCaja guardarEfectivoC = new modeloEfectivoCaja();
        List<modeloEfectivoCaja> listaEfectivoC = new List<modeloEfectivoCaja>();

        Consultawmspcmonedas ConsultaCMonedas = new Consultawmspcmonedas();
        List<modelowmspcmonedas> listaMonedas = null;
        modelowmspcmonedas DecimalesMoneda = new modelowmspcmonedas();
        modeloDenominacionesMoneda denominacion = new modeloDenominacionesMoneda();

        ConsultaEmpresa consultaEmpresa = new ConsultaEmpresa();
        List<modelowmspcempresas> listaEmpresa = null;
        modelowmspcempresas Modeloempresa = new modelowmspcempresas();
        modelowmspcempresas modeloEmpresa = new modelowmspcempresas();
        public List<modelowmspcempresas> ListaModeloempresa = new List<modelowmspcempresas>();

        Consultawmsptitulares UsuarioDatos = new Consultawmsptitulares();

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();

        modeloCajasCierre modeloCajasUsuario = new modeloCajasCierre();
        List<modeloCajasCierre> listaCajasUsuario = null;
        public string numerador = "trans";
        public string ComPwm;
        public string AmUsrLog;
        public string nro_trans = null;
        public string cod_proceso;

        public modelowmspcmonedas BuscarDecimales(string AmUsrLog, string ComPwm)
        {
            try
            {
                //lbl_error.Text = "";
                listaEmpresa = consultaEmpresa.BuscartaEmpresa(AmUsrLog, ComPwm);
                modeloEmpresa = null;
                foreach (modelowmspcempresas item in listaEmpresa)
                {

                    modeloEmpresa = item;
                    break;

                }

                listaMonedas = ConsultaCMonedas.ConsultaCMonedas(AmUsrLog, ComPwm, modeloEmpresa.mone_mn.Trim());

                DecimalesMoneda = null;
                foreach (modelowmspcmonedas item in listaMonedas)
                {

                    DecimalesMoneda = item;
                    break;

                }

                return DecimalesMoneda;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("BuscarDecimales", ex.ToString());
                return null;

            }

        }

        public void GuardarExcepciones(string metodo, string error)
        {

            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "BuscarCierreCaja.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Today;
            ModeloExcepcion.usuario_mod = AmUsrLog;

            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            //lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }
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

               // guardarExcepcion.ClaseInsertarExcepcion(empresa, metodo, "BuscarEmpresa", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }

        public modelowmspcempresas BuscarCabEmpresa(string usuario, string empresa)
        {
            try
            {
                ListaModeloempresa = consultaEmpresa.BuscartaEmpresa(usuario, empresa);
                foreach (var item in ListaModeloempresa)
                {
                    Modeloempresa = item;
                    break;
                }

                return Modeloempresa;
            }
            catch (Exception e)
            {

                //guardarExcepcion.ClaseInsertarExcepcion(empresa, "PdfCierreCaja", "BuscarCabEmpresa", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
        public string generarPdf(string Ccf_cod_emp, string Ccf_usuario, string nro_trans, Int64 secuencial,  string caja, string fecha)
        {
            try
            {
                Modelowmspclogo = null;
                Modelowmspclogo = BuscarEmpresa(Ccf_cod_emp, Ccf_usuario);

                DecimalesMoneda = null;
                DecimalesMoneda = BuscarDecimales(Ccf_usuario, Ccf_cod_emp);
                decimal totalCaja = 0;
                decimal SaldoCaja = 0;
                decimal SaldoN = 0;


                listaEfectivoC = ConsultaEfectivoC.ListaCCajaFecha(nro_trans, secuencial, Ccf_cod_emp, Ccf_usuario);

                foreach (modeloEfectivoCaja item in listaEfectivoC)
                {
                    modeloEfectivoC = item;
                    totalCaja += modeloEfectivoC.total;
                }
                decimal valorCaja = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, totalCaja);
                string txt_valor_caja = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, valorCaja);

                ///campo uno
                Int64 secCierre = Convert.ToInt64(secuencial);
                string codigo = "VIDA";
                listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(nro_trans, secCierre, codigo, Ccf_cod_emp, Ccf_usuario);
                modeloCCcaja = null;
                foreach (modeloCierreCaja item in listaCCaja)
                {
                    modeloCCcaja = item;
                }
                decimal valor_id = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
                string txt_valor_id = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, valor_id);

                SaldoCaja = modeloCCcaja.valor;
                //campo dos
                listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(nro_trans, secCierre, "INFA", Ccf_cod_emp, Ccf_usuario);
                modeloCCcaja = null;
                foreach (modeloCierreCaja item in listaCCaja)
                {
                    modeloCCcaja = item;
                }
                decimal ingreso_facturas = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
                string txt_ingreso_facturas = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, ingreso_facturas);

                SaldoCaja += modeloCCcaja.valor;
                //campo tres
                listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(nro_trans, secCierre, "INVT", Ccf_cod_emp, Ccf_usuario);
                modeloCCcaja = null;
                foreach (modeloCierreCaja item in listaCCaja)
                {
                    modeloCCcaja = item;
                }
                decimal ingreso_nventas = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
                string txt_ingreso_nventas = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, ingreso_nventas);

                SaldoCaja += modeloCCcaja.valor;
                //campo cuatro
                listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(nro_trans, secCierre, "PEFA", Ccf_cod_emp, Ccf_usuario);
                modeloCCcaja = null;
                foreach (modeloCierreCaja item in listaCCaja)
                {
                    modeloCCcaja = item;
                }
                decimal pefectivo_facturas = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
                string txt_pefectivo_facturas = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, pefectivo_facturas);

                SaldoN = modeloCCcaja.valor;
                //campoCINCO
                listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(nro_trans, secCierre, "PEOT", Ccf_cod_emp, Ccf_usuario);
                modeloCCcaja = null;
                foreach (modeloCierreCaja item in listaCCaja)
                {
                    modeloCCcaja = item;
                }
                decimal pefectivo_otros = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
                string txt_pefectivo_otros = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, pefectivo_otros);

                SaldoN += modeloCCcaja.valor;
                //CAMPO SEIS           
                listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(nro_trans, secCierre, "DEPD", Ccf_cod_emp, Ccf_usuario);
                modeloCCcaja = null;
                foreach (modeloCierreCaja item in listaCCaja)
                {
                    modeloCCcaja = item;
                }
                decimal depositos = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
                string txt_depositos = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, depositos);

                SaldoN += modeloCCcaja.valor;
                //CAMPO SIETE
                listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(nro_trans, secCierre, "EFPC", Ccf_cod_emp, Ccf_usuario);
                modeloCCcaja = null;
                foreach (modeloCierreCaja item in listaCCaja)
                {
                    modeloCCcaja = item;
                }
                decimal efectivoCaja = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
                string txt_efectivo_caja = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, efectivoCaja);

                SaldoCaja += modeloCCcaja.valor;

                decimal totalS = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (SaldoCaja - SaldoN));

                string txt_saldo_caja = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, totalS);
                decimal Diferencia = Convert.ToDecimal(txt_valor_caja) - Convert.ToDecimal(txt_saldo_caja);
                decimal dif = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Diferencia);

                string txt_diferencia = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, dif);



                listaCajasUsuario = null;
                listaCajasUsuario = ConsultaCCaja.ConsultadatosCaja(Ccf_usuario, Ccf_cod_emp, "", "", caja);
                modeloCajasUsuario = null;
                foreach (modeloCajasCierre item in listaCajasUsuario)
                {
                    modeloCajasUsuario = item;
                }
                string lbl_caja_usuario = modeloCajasUsuario.nomtcta_banco;

                string Lbl_Usuario = UsuarioDatos.BuscarNombreUsuario(Ccf_usuario.Trim());
                

                Modeloempresa = null;
                Modeloempresa = BuscarCabEmpresa(Ccf_usuario, Ccf_cod_emp);
                //Recupera path

                string pathtmpfac = Modelowmspclogo.pathtmpfac;  //Traemos el path, la ruta 
                string qrPath = pathtmpfac + Ccf_cod_emp.Trim() + nro_trans.Trim() + "qrcode.png";
                string bpathPdfGenrado = pathtmpfac + Ccf_cod_emp.Trim() + nro_trans.Trim() + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "factura.pdf";




                FileStream fs = new FileStream(bpathPdfGenrado, FileMode.Create);
                Document document = new Document(PageSize.A4, 30, 30, 30, 30);
                PdfWriter pw = PdfWriter.GetInstance(document, fs);



                document.Open();
               
                /*Tipo de letra y tamaño del documento pdf*/
                var path = HttpContext.Current.Server.MapPath("~/Tema/fonts/VerdanaVf.ttf");
                BaseFont bf = BaseFont.CreateFont(path, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font fontText = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL, new BaseColor(14, 116, 138));
                iTextSharp.text.Font fontText1 = new iTextSharp.text.Font(bf, 8, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font fontText2 = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL );
                iTextSharp.text.Font fontText3 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL, new BaseColor(221, 109, 41));
                PdfPCell cell = new PdfPCell();//creo variable de celda


                PdfPTable tablaLogos = new PdfPTable(3);//cantidad de columnas que va tener la tabla
                tablaLogos.WidthPercentage = 100;
                tablaLogos.SpacingAfter = 10;
                // Creamos la imagen y le ajustamos el tamaño
                var pathLogo = "";
                if (Modelowmspclogo.sitio_app.Contains("http"))
                {

                    pathLogo = Modelowmspclogo.sitio_app + "/Logo/" + Modelowmspclogo.logo;

                }
                else
                {
                    pathLogo = HttpContext.Current.Server.MapPath("~/Logo/" + Modelowmspclogo.logo);
                }

                iTextSharp.text.Image imagen1 = iTextSharp.text.Image.GetInstance(pathLogo);
                imagen1.BorderWidth = 0;
                imagen1.Alignment = Element.ALIGN_RIGHT;
                float percentage = 0.0f;
                percentage = 150 / imagen1.Width;
                imagen1.ScalePercent(percentage * 100);

                cell = new PdfPCell(imagen1);
                cell.Border = 0;
                tablaLogos.AddCell(cell);

                cell = new PdfPCell(new Paragraph());
                cell.BorderWidthBottom = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthTop = 0;
                cell.BorderWidthRight = 0;
                cell.Colspan = 1;
                cell.HorizontalAlignment = 0;
                tablaLogos.AddCell(cell);
     

                PdfPTable tabladetaEmpresaPW = new PdfPTable(1);
                tabladetaEmpresaPW.WidthPercentage = 100;

                cell = new PdfPCell(new Phrase(""));
                cell.Border = 0;
                cell.HorizontalAlignment = 2;
                tabladetaEmpresaPW.AddCell(cell);

                cell = new PdfPCell(new Phrase(Modeloempresa.nom_emp, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 2;
                tabladetaEmpresaPW.AddCell(cell);

                cell = new PdfPCell(new Phrase("NIT " + Modeloempresa.nro_dgi2 + "-" + Modeloempresa.nro_dgi1, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 2;
                tabladetaEmpresaPW.AddCell(cell);

                cell = new PdfPCell(new Phrase(Modeloempresa.dir_tit, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 2;
                tabladetaEmpresaPW.AddCell(cell);


                cell = new PdfPCell(new Phrase("Teléfono: " + Modeloempresa.tel_tit + "-" + Modeloempresa.fax_tit, fontText2));
                cell.HorizontalAlignment = 2;
                cell.Border = 0;

                tabladetaEmpresaPW.AddCell(cell);

                cell = new PdfPCell(new Phrase(Modeloempresa.email_tit + " " + Modeloempresa.dir_web, fontText2));
                cell.HorizontalAlignment = 2;
                cell.Border = 0;
                tabladetaEmpresaPW.AddCell(cell);

                cell = new PdfPCell(tabladetaEmpresaPW);//this line made the difference
                cell.HorizontalAlignment = 2;
                cell.Border = 0;
                tablaLogos.AddCell(cell);
                // Insertamos la imagen en el documento

                document.Add(tablaLogos);



                PdfPTable tablaLogo = new PdfPTable(4);//cantidad de columnas que va tener la tabla
                tablaLogo.WidthPercentage = 100;
                tablaLogo.SpacingAfter = 20;
                // Creamos la imagen y le ajustamos el tamaño
               
                cell = new PdfPCell(new Phrase("CIERRE CAJA ", fontText3));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tablaLogo.AddCell(cell);

                cell = new PdfPCell(new Phrase(lbl_caja_usuario, fontText));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tablaLogo.AddCell(cell);

                DateTime fecha_st = DateTime.Parse(fecha);
               string  lbl_dia = fecha_st.ToString("dddd", new CultureInfo("es-ES")).ToUpper();
               string  lbl_fecha = fecha;
                cell = new PdfPCell(new Phrase("DÍA: " +lbl_dia, fontText));
                cell.HorizontalAlignment = 0;
                cell.Border = 0;
                tablaLogo.AddCell(cell);

                cell = new PdfPCell(new Phrase(lbl_fecha, fontText));
                cell.HorizontalAlignment = 0;
                cell.Border = 0;
                tablaLogo.AddCell(cell);
              


                document.Add(tablaLogo);
                //tabla titulos
                PdfPTable tablaTitulos = new PdfPTable(3);//cantidad de columnas que va tener la tabla
                tablaTitulos.WidthPercentage = 100;
                tablaTitulos.SpacingAfter = 20;

                cell = new PdfPCell(new Phrase("RESÚMEN DEL DÍA", fontText3));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tablaTitulos.AddCell(cell);

                cell = new PdfPCell(new Phrase("", fontText));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tablaTitulos.AddCell(cell);

                cell = new PdfPCell(new Phrase("DETALLE DEL EFECTIVO DE CAJA", fontText3));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tablaTitulos.AddCell(cell);
                document.Add(tablaTitulos);

                //tabla pie de pagina principal
                PdfPTable tabladetaEmpresa = new PdfPTable(3);
                tabladetaEmpresa.WidthPercentage = 100;
                tabladetaEmpresa.SpacingAfter = 10;
                cell = new PdfPCell();

                //tabla secundaria RESUMEN CAJA
                PdfPTable tabladetaEmpresa1 = new PdfPTable(1);
                tabladetaEmpresa1.WidthPercentage = 200;
                tabladetaEmpresa1.SpacingAfter = 10;
                cell = new PdfPCell();

                         
                  cell = new PdfPCell(new Phrase("+ VALOR EN CAJA INICIO DEL DIA", fontText2));
                  cell.Border = 0;
                  cell.HorizontalAlignment = 0;
                  tabladetaEmpresa1.AddCell(cell);

                  cell = new PdfPCell(new Phrase("+ INGRESOS POR FACTURAS" , fontText2));
                  cell.Border = 0;
                  cell.HorizontalAlignment = 0;
                  tabladetaEmpresa1.AddCell(cell);

                cell = new PdfPCell(new Phrase("+ INGRESOS POR NOTAS DE VENTA", fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tabladetaEmpresa1.AddCell(cell);

                cell = new PdfPCell(new Phrase("- PAGOS EN EFECTIVO DE FACTURA", fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tabladetaEmpresa1.AddCell(cell);

                cell = new PdfPCell(new Phrase("- PAGOS EN EFECTIVO OTROS", fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tabladetaEmpresa1.AddCell(cell);

                cell = new PdfPCell(new Phrase("- DEPOSITOS DEL DIA", fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tabladetaEmpresa1.AddCell(cell);

                cell = new PdfPCell(new Phrase("+ EFECTIVO PARA CAJA", fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tabladetaEmpresa1.AddCell(cell);

                cell = new PdfPCell(tabladetaEmpresa1);//this line made the difference
                tabladetaEmpresa.AddCell(cell);

              
                //tabla secundaria 3 valores RESUMEN CAJA
                PdfPTable tabladetaEmpresa2 = new PdfPTable(1);
                tabladetaEmpresa2.WidthPercentage = 20;
                tabladetaEmpresa2.SpacingAfter = 10;
                cell = new PdfPCell();
               
                cell = new PdfPCell(new Phrase(txt_valor_id, fontText2));
                cell.Border = 0;
              
                cell.HorizontalAlignment = 2;
                tabladetaEmpresa2.AddCell(cell);

                cell = new PdfPCell(new Phrase(txt_ingreso_facturas, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 2;
                
                tabladetaEmpresa2.AddCell(cell);

                cell = new PdfPCell(new Phrase(txt_ingreso_nventas, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 2;
                
                tabladetaEmpresa2.AddCell(cell);

                cell = new PdfPCell(new Phrase(txt_pefectivo_facturas, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 2;
             
                tabladetaEmpresa2.AddCell(cell);

                cell = new PdfPCell(new Phrase(txt_pefectivo_otros, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 2;
                
                tabladetaEmpresa2.AddCell(cell);

                cell = new PdfPCell(new Phrase(txt_depositos, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 2;
                tabladetaEmpresa2.AddCell(cell);

                cell = new PdfPCell(new Phrase(txt_efectivo_caja, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 2;
               
                tabladetaEmpresa2.AddCell(cell);

                cell = new PdfPCell(tabladetaEmpresa2);//this line made the difference
                tabladetaEmpresa.AddCell(cell);

                float[] values = new float[3];
                //grid tabla secundaria 2
                PdfPTable detalle = new PdfPTable(3);//cantidad de columnas que va tener la tabla
                detalle.WidthPercentage = 200f;
                detalle.SpacingAfter = 10;
                cell = new PdfPCell();

                values = new float[3];
                values[0] = 300;

                values[1] = 80;
                values[2] = 120;
               
              
                detalle.HorizontalAlignment = 2;
                detalle.SetWidths(values);
                foreach (modeloEfectivoCaja item in listaEfectivoC)
                {
                    detalle.DefaultCell.HorizontalAlignment = 0; detalle.AddCell(new Paragraph(item.Observaciones, fontText1));

                    decimal cantidadP = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, item.cantidad);
                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, cantidadP), fontText1));
                    decimal precio_un = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, item.total);
                    detalle.DefaultCell.HorizontalAlignment = 2; detalle.AddCell(new Paragraph(ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, precio_un), fontText1));


                }

                //  document.Add(detalle);
                cell = new PdfPCell(detalle);//this line made the difference
                tabladetaEmpresa.AddCell(cell);
                // Insertamos la imagen en el documento
                document.Add(tabladetaEmpresa);


                //Tabla de saldos
                PdfPTable tablaSaldos = new PdfPTable(2);
                tablaSaldos.WidthPercentage = 100;
                tablaSaldos.SpacingAfter = 30;
                cell = new PdfPCell();
                //SALDOS SECUANDARIA  1
                PdfPTable tablaSaldos1 = new PdfPTable(2);
                tablaSaldos1.WidthPercentage = 100;
                tablaSaldos1.SpacingAfter = 10;
               
                cell = new PdfPCell();
                

                cell = new PdfPCell(new Phrase("SALDO EN CAJA FINAL DE DÍA", fontText3));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tablaSaldos1.AddCell(cell);

                cell = new PdfPCell(new Phrase(txt_saldo_caja, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 2;
                tablaSaldos1.AddCell(cell);

                cell = new PdfPCell(tablaSaldos1);//this line made the difference
                tablaSaldos.AddCell(cell);

                //SALDOS SECUANDARIA  2
                PdfPTable tablaSaldos2 = new PdfPTable(2);
                tablaSaldos2.WidthPercentage = 100;
                tablaSaldos2.SpacingAfter = 10;
                cell = new PdfPCell();

                cell = new PdfPCell(new Phrase("VALOR EN CAJA", fontText3));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tablaSaldos2.AddCell(cell);

                cell = new PdfPCell(new Phrase(txt_valor_caja, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 2;
                tablaSaldos2.AddCell(cell);

                cell = new PdfPCell(new Phrase("DIFERENCIA", fontText3));
                cell.Border = 0;
                cell.HorizontalAlignment = 0;
                tablaSaldos2.AddCell(cell);

                cell = new PdfPCell(new Phrase(txt_diferencia, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 2;
                tablaSaldos2.AddCell(cell);

                cell = new PdfPCell(tablaSaldos2);//this line made the difference
                tablaSaldos.AddCell(cell);
                
                document.Add(tablaSaldos);

                //Tabla de saldos
                PdfPTable tablaPie = new PdfPTable(2);
                tablaPie.WidthPercentage = 100;
                tablaPie.SpacingAfter = 10;
                cell = new PdfPCell();
                cell.BorderWidthTop = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthRight = 0;

                PdfPTable tablaPie1 = new PdfPTable(1);
                tablaPie1.WidthPercentage = 100;
                tablaPie1.SpacingAfter = 10;
                cell = new PdfPCell();
                cell.BorderWidthTop = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthRight = 0;

                cell = new PdfPCell(new Phrase("   ", fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 1;
                tablaPie1.AddCell(cell);

                cell = new PdfPCell(new Phrase("   ", fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 1;
                tablaPie1.AddCell(cell);

                cell = new PdfPCell(new Phrase("__________________________", fontText2));
               cell.Border = 0;
                cell.HorizontalAlignment = 1;
                tablaPie1.AddCell(cell);


                cell = new PdfPCell(new Phrase(Lbl_Usuario, fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 1;
                tablaPie1.AddCell(cell);

                cell = new PdfPCell(new Phrase("RESPONSABLE DE LA CAJA", fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 1;
                tablaPie1.AddCell(cell);

                cell = new PdfPCell(tablaPie1);//this line made the difference
                tablaPie.AddCell(cell);

                PdfPTable tablaPie2 = new PdfPTable(1);
                tablaPie2.WidthPercentage = 100;
                tablaPie2.SpacingAfter = 10;
                cell = new PdfPCell();
                cell.BorderWidthTop = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthRight = 0;

                cell = new PdfPCell(new Phrase("   ", fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 1;
                tablaPie2.AddCell(cell);

                cell = new PdfPCell(new Phrase("   ", fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 1;
                tablaPie2.AddCell(cell);

                cell = new PdfPCell(new Phrase("__________________________", fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 1;
                tablaPie2.AddCell(cell);

                cell = new PdfPCell(new Phrase("SUPERVISOR", fontText2));
                cell.Border = 0;
                cell.HorizontalAlignment = 1;
                tablaPie2.AddCell(cell);

                cell = new PdfPCell(tablaPie2);//this line made the difference
                tablaPie.AddCell(cell);
                document.Add(tablaPie);
                document.Close();

                return bpathPdfGenrado;
            }
            catch (Exception e)
            {

               // guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp,"jenn", "generarPdf", e.ToString(), DateTime.Today, Ccf_usuario);
                return "No se pudo completar la acción." + "generarPdf." + " Por favor notificar al administrador.";
            }
        }
    }
}
