using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;
using CapaProceso.FacturaMasiva;
using System.IO;
using System.Diagnostics.Eventing;


namespace CapaWeb.WebForms
{
    public partial class CargaMasivaFactura : System.Web.UI.Page
    {
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();
        CargaFacturaMasiva carga = new CargaFacturaMasiva();
        List<modeloFacturaEMasiva> lista = new List<modeloFacturaEMasiva>();
        modeloFacturaEMasiva modeloFacturas = new modeloFacturaEMasiva();

        Consultawmspcresfact ConsultaResolucion = new Consultawmspcresfact();
        modelowmspcresfact resolucion = new modelowmspcresfact();
        List<modelowmspcresfact> listaRes = null;

        public modeloUsuariosucursal ModelousuarioSucursal = new modeloUsuariosucursal();
        public List<modeloUsuariosucursal> ListaModeloUsuarioSucursal = new List<modeloUsuariosucursal>();
        public ConsultawmusuarioSucursal ConsultaUsuxSuc = new ConsultawmusuarioSucursal();
        public ConsultausuarioSucursal consultaUsuarioSucursal = new ConsultausuarioSucursal();
        List<modeloFacturaEMasiva> listaFacturar = new List<modeloFacturaEMasiva>();

        List<modelowmtfacturascab> listaConsCab = null;
        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

        public string ComPwm;
        public string socio;
        public string AmUsrLog;
        public string cod_proceso;
        public string sesion;
        public string AmComCod;
        public string ResF_estado = "S";
        public string ResF_serie = "0";
        public string ResF_tipo = "F";
        public string Ccf_tipo1 = "C";
        public string Ccf_tipo2 = "VTA";
        public string Ccf_nro_trans = " ";
        public string Ccf_estado = "0";
        public string Ccf_cliente = "0";
        public string Ccf_cod_docum = "0";
        public string Ccf_serie_docum = "xxx";
        public string Ccf_nro_docum = "0";
        public string Ccf_diai = "";
        public string Ccf_mesi = "";
        public string Ccf_anioi = "";
        public string Ccf_diaf = "";
        public string Ccf_mesf = "";
        public string Ccf_aniof = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //lbl_error.Text = "";
                RecuperarCokie();
                ListaModelowmspclogo = consultaLogo.BuscartaLogo(ComPwm, AmUsrLog);
                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }
                //Cargar sucursal del usuario
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
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());
            }
        }

        protected void btn_verificar_Click(object sender, EventArgs e)
        {
            //Analizamos antes de procesar--resolucion por sucursal usuario
            //vALIDAR QUE SOLO EXISTA UNA RESOLUCION ACTIVA-
            listaRes = null;
            listaRes = ConsultaResolucion.ConsultaResolusionXSucursal(AmUsrLog, ComPwm, ResF_estado, ResF_serie, ResF_tipo, lbl_cod_suc.Text.Trim());
            resolucion = null;
            foreach (modelowmspcresfact item in listaRes)
            {
                resolucion = item;
            }
            if (listaRes.Count == 0)
            {
                
                lbl_mensaje.Text = "No existe una resolución activa para Facturar.";
            }
            else
               {
                if (listaRes.Count > 1)
                {

                    lbl_mensaje.Text = "Existe más de una resolución activa, para Facturar habilite una solamente.";
                }
                else
                {
                    lbl_prefijo.Text = resolucion.prefijo;
                    lbl_prefijo.Visible = true;
                    lbl_pre.Visible = true;
                    lista = carga.TotalFacturas(AmUsrLog, ComPwm);
                    int count = 0;
                    modeloFacturas = null;
                    foreach (modeloFacturaEMasiva item in lista)
                    {

                        modeloFacturas = item;
                        lbl_carga_fec.Text = item.fecha_carga.ToString();
                        count++;
                    }
                    if (lista.Count > 0)
                    {
                        btn_verificar.Visible = false;
                        BtnIniciar.Enabled = true;
                        BtnIniciar.Visible = true;
                        btn_cancelar.Visible = true;
                        lbl_carga_fec.Visible = true;
                        lbl_fec_ca.Visible = true;


                    }
                    lbl_facturas.Text = Convert.ToString(count);
                    
                }
            }   
        }

       
        public void RecuperarCokie()
        {
            try
            {
                // lbl_error.Text = "";

                if (Request.Cookies["ComPwm"] != null)
                {
                    ComPwm = Request.Cookies["ComPwm"].Value;
                }
                else
                {
                    Response.Redirect("../Inicio.asp");
                }

                if (Request.Cookies["AmScNCod"] != null)
                {
                    socio = Request.Cookies["AmScNCod"].Value;
                }
                if (Request.Cookies["AmSesId"] != null)
                {
                    sesion = Request.Cookies["AmSesId"].Value;
                }

                if (Request.Cookies["AmComCod"] != null)
                {
                    AmComCod = Request.Cookies["AmComCod"].Value;
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
                //Codigo empresa
                string empresa_codigo = ComPwm;
                string empresa_canorus = AmComCod;
                Response.Cookies["empresa_codigo"].Value = empresa_codigo;
                Response.Cookies["empresa_canorus"].Value = empresa_canorus;
                Response.Cookies["socio_codigo"].Value = socio;
                Response.Cookies["usuario"].Value = AmUsrLog;
                Response.Cookies["sesion"].Value = sesion;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("RecuperarCokie", ex.ToString());

            }

        }
        public void GuardarExcepciones(string metodo, string error)
        {

            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "CargaMasivaFactura.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;

            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            // lbl_error.Text = "No se pudo completar la acción" + metodo + "." + " Por favor notificar al administrador.";

        }

        protected void btn_importar_Click(object sender, EventArgs e)
        {
            List<modeloFacturaEMasiva> listaFacturas = new List<modeloFacturaEMasiva>();
            modeloFacturaEMasiva modeloFacturas1= new modeloFacturaEMasiva();
            //Leer archivo excel
         // if (FileUpload1.PostedFile.ContentType == "application/vnd.ms-excel" ||
           //   FileUpload1.PostedFile.ContentType == "application/vnd.openxmlformats.officedocument.spreadsheetml.sheet")

            {
                try
                {
                    string pathtmpfac = Modelowmspclogo.pathtmpfac;  //Traemos el path, la ruta 
                    string fileName = pathtmpfac + Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.PostedFile.SaveAs(fileName);
                    string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                  
                    if (extension.ToLower() == ".xlsx")
                    {
                        string leerExcel = System.IO.File.ReadAllText(fileName);
                       
                        foreach (string row in leerExcel.Split('\n'))
                        {
                            if(!string.IsNullOrEmpty(row))
                            {
                                listaFacturas.Add(new modeloFacturaEMasiva
                                {
                                    nro_docum = Convert.ToString(row.Split(',')[0]),
                                    tipo_docum = row.Split(',')[1],
                                });
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    GuardarExcepciones("buscarTipoFac", ex.ToString());
                    
                }

            }
        }

        private int Prop_CoTareas
        {
            get
            {
                if (ViewState["CoTareas"] == null)
                {
                    ViewState["CoTareas"] = 0;
                }
                return (int)ViewState["CoTareas"];
            }

            set
            {
                ViewState["CoTareas"] = value;
            }
        }

        private int Prop_TotalTareas = 0;
        

        private int f_PorcentajeAvance(int Par_TotalTareas, int Par_TareaActual)
        {
            int liPorcentaje = 0;
            //aplicar una regla de 3 simple
            liPorcentaje = (Par_TareaActual * 100) / Par_TotalTareas;
            return liPorcentaje;
        }

        private int f_ancho_control_porcentaje(int Par_AnchoTotalControl, int Par_Porcentaje)
        {
            int liAnchoControl = 0;
            liAnchoControl = (Par_Porcentaje * Par_AnchoTotalControl) / 100;
            return liAnchoControl;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

            Prop_TotalTareas = Convert.ToInt16(lbl_facturas.Text);
            //limitar el numero de tareas al total de tareas a realizar
            if (Prop_CoTareas <= Prop_TotalTareas)
            {
                int liPorcentajeAvance = 0;

                //contador de tarea??
                Prop_CoTareas += 1;

                //tarea actual con total tareas
                LblAvance.Text = Prop_CoTareas.ToString() + " de " + Prop_TotalTareas.ToString();

                //porcentaje de avance segun el numero de tareas
                liPorcentajeAvance = f_PorcentajeAvance(Prop_TotalTareas, Prop_CoTareas);
                LblPorcentajeAvance.Text = liPorcentajeAvance.ToString() + "%";

                //barra de progreso
                LblProgressBar.Visible = true;
                LblProgressBar.Width = f_ancho_control_porcentaje(400, liPorcentajeAvance);

                //tareas a realizar poner todo el codigo para facturar electronicamente
                string error_fac = null;

                    string nro_docum = carga.FacturaOCompra(AmUsrLog, ComPwm);
               

                try
                {
                    if (nro_docum != "")
                    {
                       error_fac= carga.BuscartaDatosFacturasMasivas(AmUsrLog, ComPwm, lbl_cod_suc.Text.Trim(), nro_docum.Trim());
                        if(! string.IsNullOrEmpty(error_fac))
                        {
                            carga.ActualizarEstadoLista(AmUsrLog, ComPwm, "E");//Estado E cuando ocurre un error 
                            carga.ErrorFPagosActualizar(AmUsrLog, ComPwm, "E");//Estado E cuando ocurre un error
                            carga.ErrorDscCargActualizar(AmUsrLog, ComPwm, "E");//Estado E cuando ocurre un error
                            lbl_error_factura.Text = error_fac+ " Nro docum: "+nro_docum;
                            lbl_error_factura.Visible = true;
                            return;
                            
                        }
                    }
                }
                catch (Exception aee )
                {

                    throw;
                }
               
                //.....
            }

            if (Prop_CoTareas == Prop_TotalTareas)
            {
                Prop_CoTareas = 0;
                Timer1.Enabled = false;
                LblAvance.Text = "Tarea finalizada";
                BtnIniciar.Visible = false;
                btn_verificar.Visible = true;
                listaFacturar.Clear();
                //MUESTRA CONTABILIZADAS
                CargarGrilla();
                if (listaConsCab.Count > 0)
                {
                    Grid.Visible = true;
                    lbl_lisdoc.Visible = true;
                }
                else
                {
                    lbl_error_factura.Text = "Documentos autorizados correctamente";
                    lbl_error_factura.Visible = true;
                }
            }
        }
        protected void BtnIniciar_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = true;
            BtnIniciar.Enabled = false;
            Prop_TotalTareas = 10;
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            btn_verificar.Visible = true;
            BtnIniciar.Enabled = false;
            BtnIniciar.Visible = false;
            btn_cancelar.Visible = false;
            lbl_carga_fec.Visible = false;
            lbl_fec_ca.Visible = false;
            lbl_facturas.Text = "";

        }
        private void CargarGrilla()
        {
            try
            {

                Ccf_estado = "C";
                Ccf_tipo2 = "VTAE";
                listaConsCab = ConsultaCabe.ConsultaDocsElectronicosXSucursal(ComPwm, AmUsrLog, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof, lbl_cod_suc.Text.Trim());
                Grid.DataSource = listaConsCab;
                Grid.DataBind();
                Grid.Height = 100;
            }

            catch (Exception ex)
            {
                GuardarExcepciones("CargarGrilla", ex.ToString());

            }
        }
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            // paginar la grilla asegurarse que la obcion que la propiedad AllowPaging sea True.
            Grid.CurrentPageIndex = 0;
            Grid.CurrentPageIndex = e.NewPageIndex;
            CargarGrilla();
        }
        protected void Grid_ItemCommand(object source, DataGridCommandEventArgs e)
        {

        }
    }

}
