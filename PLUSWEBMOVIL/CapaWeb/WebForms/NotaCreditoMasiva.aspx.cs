using CapaDatos.Modelos;
using CapaProceso.Consultas;
using CapaProceso.FacturaMasiva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaWeb.WebForms
{
    public partial class NotaCreditoMasiva : System.Web.UI.Page
    {
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        NotaCreditoMasivaE procesar_nc = new NotaCreditoMasivaE();
        List<modeloFacturaEMasiva> lista = new List<modeloFacturaEMasiva>();
        modeloFacturaEMasiva modeloFacturas = new modeloFacturaEMasiva();

        public modeloUsuariosucursal ModelousuarioSucursal = new modeloUsuariosucursal();
        public List<modeloUsuariosucursal> ListaModeloUsuarioSucursal = new List<modeloUsuariosucursal>();
        public ConsultawmusuarioSucursal ConsultaUsuxSuc = new ConsultawmusuarioSucursal();
        public ConsultausuarioSucursal consultaUsuarioSucursal = new ConsultausuarioSucursal();

        Consultawmspcresfact ConsultaResolucion = new Consultawmspcresfact();
        modelowmspcresfact resolucion = new modelowmspcresfact();
        List<modelowmspcresfact> listaRes = null;
        public string ComPwm;
        public string AmUsrLog;
        public string cod_proceso;
        public string ResF_estado = "S";
        public string ResF_serie = "0";
        public string ResF_tipo = "C";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                RecuperarCokie();
              
                if (!IsPostBack)
                {
                    //Cargar la sucursal del usuario logeado
                    ListaModeloUsuarioSucursal = ConsultaUsuxSuc.UnicoUsuarioSucursal(ComPwm, AmUsrLog, ""); //Solo se envia empresa y usuario
                    if (ListaModeloUsuarioSucursal.Count == 0)
                    {
                        lbl_mensaje.Text = "Usuario no tiene sucursal asignada, por favor asignar sucursarl para continuar.";
                    }
                    else
                    {
                        foreach (var item in ListaModeloUsuarioSucursal)
                        {
                            ModelousuarioSucursal = item;
                            break;
                        }
                        lbl_cod_suc.Text = ModelousuarioSucursal.cod_sucursal.Trim();
                        lbl_sucursal.Text = "-" + ModelousuarioSucursal.nom_sucursal.Trim();
                    }

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());
            }
        }
        public void GuardarExcepciones(string metodo, string error)
        {

            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "NotaCreditoMasiva.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;

            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }
        public void RecuperarCokie()
        {

            try
            {
                lbl_error.Text = "";

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
                if (Request.Cookies["ProcAud"] != null)
                {
                    cod_proceso = Request.Cookies["ProcAud"].Value;
                }
                else
                {
                    cod_proceso = Convert.ToString(Request.QueryString["cod_proceso"]);
                    if (cod_proceso != null)
                    {
                        //Crear cookie de cod_proceso
                        Response.Cookies["ProcAud"].Value = cod_proceso;
                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("RecuperarCokie", ex.ToString());

            }


        }
        protected void btn_verificar_Click(object sender, EventArgs e)
        {
            btn_procesar.Enabled = true;
            //vALIDAR QUE SOLO EXISTA UNA RESOLUCION ACTIVA-
            listaRes = null;
            listaRes = ConsultaResolucion.ConsultaResolusionXSucursalNC(AmUsrLog, ComPwm, ResF_estado, ResF_serie, ResF_tipo, lbl_cod_suc.Text.Trim());
            resolucion = null;
            foreach (modelowmspcresfact item in listaRes)
            {
                resolucion = item;
            }
            if (listaRes.Count == 0)
            {

                lbl_mensaje.Text = "No existe una resolución activa para emitir Nota de Crédito.";
            }
            else
            {
                if (listaRes.Count > 1)
                {

                    lbl_mensaje.Text = "Existe más de una resolución activa, para emitir Nota de Crédito habilite una solamente.";
                }
                else
                {
                    lbl_prefijo.Text = resolucion.prefijo;
                    lbl_prefijo.Visible = true;
                    lbl_pre.Visible = true;

                    lista = null;
                    lista = procesar_nc.TotalFacturasNC(AmUsrLog, ComPwm, txtx_fac_desde.Text.Trim(), txt_fac_hasta.Text.Trim(), lbl_cod_suc.Text.Trim()); //trae facturas por sucursal
                    if (lista == null)
                    {
                        lbl_facturas_total.Text = "0";
                    }
                    else
                    {
                        lbl_facturas_total.Text = Convert.ToString(lista.Count);
                        lbl_total_fac.Text = "Total Facturas a procesar:";
                        lbl_total_fac.Visible = true;
                    }
                   
                    if (lista.Count > 0)
                    { btn_procesar.Visible = true; }


                }
            }

        }

        protected void btn_procesar_Click(object sender, EventArgs e)
        {
            //Proceso de insercion de las facturas

            lbl_total_fac.Text = procesar_nc.ProcesarNotaCredito(AmUsrLog, ComPwm, txtx_fac_desde.Text.Trim(), txt_fac_hasta.Text.Trim(), lbl_cod_suc.Text.Trim());
            btn_procesar.Enabled = false;
        }
    }
}