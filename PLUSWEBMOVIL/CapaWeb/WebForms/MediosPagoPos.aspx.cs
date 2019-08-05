using CapaDatos.Modelos;
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

        ConsultaMediosPago guardarPagos = new ConsultaMediosPago(); //Guarda en tabla wmt_facturas_pgs

        public List<modeloFacturasPagos> listaPagosFactura = null; //Modelos guardar tabla wmt_facturas_pgs
        modeloFacturasPagos modeloPagosFactura = new modeloFacturasPagos();
        List<modeloFacturasPagos> modeloFacturasPagos = new List<modeloFacturasPagos>();
        modeloFacturasPagos modeloTiposPagos = new modeloFacturasPagos(); //Modelo tipos de pagos
        public List<modeloFacturasPagos> listaTiposPagos= null;
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
            txt_Banco.Visible = true;
            txt_Precio.Visible = true;
            AgregarPago.Visible = true;
            cbx_medios.Visible = false;
            Agregar_MedioPago.Visible = false;

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

        protected void AgregarPago_Click(object sender, EventArgs e)
        {
           //Buscamos medios de pago seleccionado

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
            
            HabilitarCajas();
        }
    }
    }
