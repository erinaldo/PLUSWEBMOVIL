﻿using CapaDatos.Modelos;
using CapaProceso.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaWeb.WebForms
{
    public partial class MediosPagoPos : System.Web.UI.Page
    {
        ConsultaMediosPago consultaMediosPago = new ConsultaMediosPago();

        public List<modeloMediosPago> listaMedios = null;
        modeloMediosPago modeloMedios = new modeloMediosPago(); //Medios de pago por empresa

        public List<ModeloTipoPagoTem> listaTemporal = null; //para temporales sp
        ModeloTipoPagoTem modeloTemporal = new ModeloTipoPagoTem(); //para temporales sp

        public List<ModelosPagosTitular> listaTitular = null; //para titular sp
        ModelosPagosTitular modeloTitular = new ModelosPagosTitular(); //para temporales sp
        ModeloDiferenciaPagos modeloDiferencia = new ModeloDiferenciaPagos(); //Trae los saldos
        public List<ModeloDiferenciaPagos> listaSaldos = null;

        public List<modeloFacturasPagos> listaPagosPgs = null; //Modelos recuperar de la tabla wmt_facturas_pgs
        modeloFacturasPagos modeloPagosPgs = new modeloFacturasPagos(); //Modelos recuperar de la tabla wmt_facturas_pgs
        public List<modeloFacturasPagos> listaPagosFactura = null; //Modelos guardar tabla wmt_facturas_pgs
        modeloFacturasPagos modeloPagosFactura = new modeloFacturasPagos();
        modeloFacturasPagos detallePagosFactura = new modeloFacturasPagos();
        List<modeloFacturasPagos> modeloFacturasPagos = new List<modeloFacturasPagos>();
        ConsultaMediosPago guardarPagos = new ConsultaMediosPago(); //Guarda en tabla wmt_facturas_pgs

        modeloFacturasPagos modeloTiposPagos = new modeloFacturasPagos(); //Modelo tipos de pagos
        public List<modeloFacturasPagos> listaTiposPagos = null;
        public string ComPwm;
        public string AmUsrLog;
        public decimal sumaTotalPago;
        public decimal sumaDiferencia;

        protected void Page_Load(object sender, EventArgs e)
        {
            RecuperarCokie();

            if (!IsPostBack)
            {



                if (Request.Cookies["ComPwm"] != null)
                {
                    string ComPwm = Request.Cookies["ComPwm"].Value;

                }
                if (Session["TotalFactura"] != null)
                {
                    txt_total_factura.Text = Session["TotalFactura"].ToString();
                }
                if (Session["valor_asignado1"] != null)
                {
                    txt_nro_trans.Text = Session["valor_asignado1"].ToString();
                }
                cargarListaDesplegables();
            }
        }

        public void cargarListaDesplegables()
        {


            //LIsta medios pago
            listaMedios = consultaMediosPago.BuscarMediosPago(ComPwm);
            cbx_medios.DataSource = listaMedios;
            cbx_medios.DataTextField = "observacion";
            cbx_medios.DataValueField = "cod_fpago";
            cbx_medios.DataBind();


        }

        public void HabilitarCajas()
        {
            lblDes.Visible = true;
            lblBanco.Visible = true;
            lblMedio.Visible = true;
            lblPre.Visible = true;
            txt_Descripcion.Visible = true;
            txt_numero.Visible = true;
            txt_Precio.Visible = true;
            AgregarPago.Visible = true;
            cbx_tercero.Visible = true;
            cbx_medios.Visible = false;
            Agregar_MedioPago.Visible = false;

        }

        public void InhabilitarCajas()
        {
            lblDes.Visible = false;
            lblBanco.Visible = false;
            lblMedio.Visible = false;
            lblPre.Visible = false;
            txt_Descripcion.Visible = false;
            txt_numero.Visible = false;
            txt_Precio.Visible = false;
            AgregarPago.Visible = false;
            cbx_tercero.Visible = false;
            cbx_medios.Visible = true;
            Agregar_MedioPago.Visible = true;

        }

        public void RecuperarCokie()
        {
            if (Request.Cookies["ComPwm"] != null)
            {
                ComPwm = Request.Cookies["ComPwm"].Value;
            }
            else
            {
                Response.Redirect("../Inicio.asp");
            }


            if (Request.Cookies["AmUsrLog"] != null)
            {
                AmUsrLog = Request.Cookies["AmUsrLog"].Value;

            }
        }

        public void GuardarPagos()
        {
            string error;
            //Busca en gv_producto todos los items añadidos que estan en la variable de session detallePagos
            modeloFacturasPagos = new List<modeloFacturasPagos>();
            modeloFacturasPagos = (Session["detallePagos"] as List<modeloFacturasPagos>);

            //Elimina forma de pago
            consultaMediosPago.EliminarPagosFactura(txt_nro_trans.Text);
            //Va añadiendo linea por linea al modelo insertar detalle factura
            int contarLinea = 0;
            foreach (var item in modeloFacturasPagos)
            {
                contarLinea++;
                detallePagosFactura.cod_tit = item.cod_tit;
                detallePagosFactura.nro_docum = item.nro_docum;
                detallePagosFactura.recibido = item.recibido;
                detallePagosFactura.nro_trans = item.nro_trans;
                detallePagosFactura.cod_emp = item.cod_emp;
                detallePagosFactura.linea = contarLinea;
                detallePagosFactura.cod_docum = item.cod_docum;
                detallePagosFactura.cod_cta = item.cod_cta;
                detallePagosFactura.cod_fpago = item.cod_fpago;

                error = guardarPagos.InsertarPagosFactura(detallePagosFactura);
                if (string.IsNullOrEmpty(error))
                {

                }
                else
                {
                    //this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "')+ error;</script>");
                    lbl_mensaje.Text = error;

                }
            }

        }
        public ModeloTipoPagoTem BuscarDetallePago(string nro_trans)
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
        /*public modeloFacturasPagos DatosGuardadosPagos()
       {


            listaPagosPgs = guardarPagos.BuscarMediosPago(AmUsrLog, ComPwm, nro_trans);


             modeloTemporal = null;
             foreach (ModeloTipoPagoTem item in listaTemporal)
             {

                 modeloTemporal = item;
                 break;




       } }*/


        public void AgregarPagoGrilla()
        {
            modeloFacturasPagos item = new modeloFacturasPagos();
            modeloTemporal = null;
            modeloTemporal = BuscarDetallePago(txt_nro_trans.Text);

            //Consulta si existe el pago en la lista

            if (Session["detallePagos"] == null)
            {
                modeloFacturasPagos = new List<modeloFacturasPagos>();
            }
            else
            {
                modeloFacturasPagos = (Session["detallePagos"] as List<modeloFacturasPagos>);
            }

            Boolean existe = false;
            foreach (modeloFacturasPagos itemSuma in modeloFacturasPagos)
            {
                if (itemSuma.nro_docum == modeloTemporal.nro_doc && itemSuma.cod_fpago == modeloTemporal.cod_fpago)
                {
                    existe = true;

                    itemSuma.recibido = Convert.ToDecimal(txt_Precio.Text);

                }

            }

            if (!existe)
            {

                item.cod_tit = cbx_tercero.SelectedValue;
                item.nro_docum = txt_numero.Text;
                item.recibido = Convert.ToDecimal(txt_Precio.Text);
                item.nro_trans = txt_nro_trans.Text;
                item.cod_emp = ComPwm;
                item.cod_docum = modeloTemporal.cod_docum;
                item.cod_cta = modeloTemporal.cod_cta;
                item.cod_fpago = modeloTemporal.cod_fpago;
                item.forma_pago = cbx_medios.SelectedItem.ToString();
                item.tercero = cbx_tercero.SelectedItem.ToString();

                modeloFacturasPagos.Add(item);
            }

            Session["detallePagos"] = modeloFacturasPagos;

            modeloFacturasPagos = (Session["detallePagos"] as List<modeloFacturasPagos>);
            gv_Producto.DataSource = modeloFacturasPagos;
            gv_Producto.DataBind();

            txt_Descripcion.Text = "";
            txt_numero.Text = "";
            txt_Precio.Text = "0";

            item = null;
            InhabilitarCajas();
        }
        protected void AgregarPago_Click(object sender, EventArgs e)
        {
            //agregar a grilla medio de pago para insertar
            AgregarPagoGrilla();
            GuardarPagos();
            //Mostrar saldos
            listaSaldos = consultaMediosPago.BuscarDiferenciaSaldos(AmUsrLog, ComPwm, txt_nro_trans.Text);
            foreach (var item in listaSaldos)
            {
                modeloDiferencia = item;
            }
            txt_total_pago.Text = modeloDiferencia.pagado;
            txt_Diferencia.Text = modeloDiferencia.diferencia;
        }

        protected void Agregar_MedioPago_Click(object sender, EventArgs e)
        {
            //Agregar medio de pago en la tabla wmt_facturas_pgstmp
            
            modeloTiposPagos.nro_trans = txt_nro_trans.Text;
            modeloTiposPagos.cod_fpago = cbx_medios.SelectedValue;
            modeloTiposPagos.cod_emp = ComPwm;
            consultaMediosPago.InsertarTipoPago(modeloTiposPagos);
            //Recupero datos con wmspc_fpagoPOS_tmp
            listaTemporal = consultaMediosPago.BuscarMediosPagoTemporal(AmUsrLog, ComPwm, txt_nro_trans.Text);
            foreach (var item in listaTemporal)
            {
                modeloTemporal = item;
            }
            txt_Descripcion.Text = modeloTemporal.nom_fpago;
            //buscar titulars sp wmspc_fpagoPOS_tittmp
            listaTitular = consultaMediosPago.BuscartitularPagos(AmUsrLog, ComPwm, txt_nro_trans.Text);
            cbx_tercero.DataSource = listaTitular;
            cbx_tercero.DataTextField = "nom_tit";
            cbx_tercero.DataValueField = "cod_tit";
            cbx_tercero.DataBind();
            txt_Precio.Text = "0";
            
            HabilitarCajas();
        }
    }
    }
