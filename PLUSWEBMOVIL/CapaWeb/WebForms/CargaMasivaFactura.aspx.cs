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

        public string ComPwm;
        public string socio;
        public string AmUsrLog;
        public string cod_proceso;
        public string sesion;
        public string AmComCod;
        public string ResF_estado = "S";
        public string ResF_serie = "0";
        public string ResF_tipo = "F";
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
                        count++;
                    }
                    if (lista.Count > 0)
                    {
                        btn_verificar.Visible = false;
                        btn_procesar.Visible = true;
                    }
                    lbl_facturas.Text = Convert.ToString(count);
                   
                }
            }   
        }

        protected void btn_procesar_Click(object sender, EventArgs e)
        {
            //Proceso de insercion de las facturas
           
            mensaje.Text = carga.BuscartaDatosFacturasMasivas(AmUsrLog, ComPwm, lbl_cod_suc.Text.Trim());
            btn_procesar.Enabled = false;
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
    }
}