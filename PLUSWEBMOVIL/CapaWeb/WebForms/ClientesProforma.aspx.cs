using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;
using System.IO;
using SpreadsheetLight;

namespace CapaWeb.WebForms
{
    public partial class ClientesProforma : System.Web.UI.Page
    {
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();

        ConsultaProformasFac ConsultaProformas = new ConsultaProformasFac();
        modelowmtproformascab ModeloProformas = new modelowmtproformascab();

        Consultawmsptitulares ConsultaTitulares = new Consultawmsptitulares();
        modelowmspctitulares clientes = new modelowmspctitulares();
        List<modelowmspctitulares> listaClientes = null;
        public string ComPwm;
        public string AmUsrLog;
        public string cod_proceso;
        public string nro_trans;
        public string Ven__cod_tipotit = "clientes";
        public string Ven__cod_dgi = "0";
        public string Ven__fono = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                RecuperarCokie();
                ListaModelowmspclogo = consultaLogo.BuscartaLogo(ComPwm, AmUsrLog);
                foreach (var item in ListaModelowmspclogo)
                {
                    Modelowmspclogo = item;
                    break;
                }
                if (!IsPostBack)
                {

                    
                

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());
            }
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
                if (Request.Cookies["PedGen"] != null)
                {
                    nro_trans = Request.Cookies["PedGen"].Value;
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("RecuperarCokie", ex.ToString());

            }


        }
        public void GuardarExcepciones(string metodo, string error)
        {

            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "ClientesProforma.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;

            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }

        protected void btn_importar_Click(object sender, EventArgs e)
        {
           
                try
                {
                    List<modeloClientesproforma> ListaClientesP = null;
                    modeloClientesproforma modeloClientesP = new modeloClientesproforma();
                    //string Path;
                    string pathtmpfac = Modelowmspclogo.pathtmpfac;  //Traemos el path, la ruta 
                    string fileName = pathtmpfac + Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.PostedFile.SaveAs(fileName);
                    string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);

                    if (extension.ToLower() == ".xlsx")
                    {
                
                    SLDocument doc = new SLDocument(fileName);
                    int rowm = 2;
                   Boolean tot_eror = false;
                    while(! string.IsNullOrEmpty(doc.GetCellValueAsString(rowm, 1))) //VALIDAR CLIENTE ANTES DE INSERTAR
                    {

                        modeloClientesP.cod_cliente = doc.GetCellValueAsString(rowm, 1);
                        modeloClientesP.cod_suc_cli = doc.GetCellValueAsString(rowm, 2);
                        //Validar que exista
                        listaClientes = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, modeloClientesP.cod_cliente.Trim(), Ven__cod_dgi, modeloClientesP.cod_suc_cli.Trim());


                        if (listaClientes.Count > 1)
                        {
                            foreach(var item in listaClientes)
                            {
                                if(item.nro_dgi2.Trim()== modeloClientesP.cod_cliente.Trim())
                                {
                                   clientes =item;
                                    break;
                                }
                            }
                            if (string.IsNullOrEmpty(clientes.nro_dgi2))
                            {
                                lbl_error.Text = "Cliente no existe por favor revisar: " + modeloClientesP.cod_cliente.Trim() + " Fila:" + rowm;
                                tot_eror = true;
                                return;
                            }

                        }
                        else
                        {
                            if (listaClientes.Count ==0)
                            {
                                lbl_error.Text = "Cliente no existe por favor revisar: " + modeloClientesP.cod_cliente.Trim() + " Fila:" + rowm;
                                tot_eror = true;
                                return;
                            }
                        }
                            
                        rowm++;
                    }
                    int rowm2 = 2;
                    if (tot_eror == false)
                    {
                        while (!string.IsNullOrEmpty(doc.GetCellValueAsString(rowm2, 1))) //VALIDAR CLIENTE ANTES DE INSERTAR
                        {
                            modeloClientesP.cod_cliente = doc.GetCellValueAsString(rowm2, 1);
                            modeloClientesP.cod_suc_cli= doc.GetCellValueAsString(rowm2, 2);
                            //Validar que exista
                            listaClientes = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, modeloClientesP.cod_cliente.Trim(), Ven__cod_dgi, modeloClientesP.cod_suc_cli.Trim());
                            clientes = null;
                            if (listaClientes.Count > 1)
                            {
                                foreach (modelowmspctitulares item in listaClientes)
                                {
                                    if (item.nro_dgi2.Trim() == modeloClientesP.cod_cliente.Trim())
                                    {
                                        clientes = item;
                                        break;
                                    }

                                }
                            }
                            else
                            {
                                foreach (modelowmspctitulares item in listaClientes)
                                {
                                    clientes = item;
                                    break;

                                }
                            }
                          
                            modeloClientesP.cod_cliente = clientes.cod_tit.Trim();
                            modeloClientesP.cod_suc_cli = clientes.cod_sucursal.Trim();
                            modeloClientesP.nro_trans = nro_trans;
                            modeloClientesP.cod_emp = ComPwm;
                            modeloClientesP.estado = "A";
                            modeloClientesP.fecha_mod = DateTime.Now;
                            modeloClientesP.usuario = AmUsrLog;

                            lbl_error.Text = ConsultaProformas.InsertarClienteProformasAFacturar(modeloClientesP);
                            if (!string.IsNullOrEmpty(lbl_error.Text))
                            {
                                return;
                            }
                            lbl_mensaje.Text = "Carga finalizada";
                            rowm2++;
                        }
                    }
               
                }
                    
                }
                catch (Exception ex)
                {
                    GuardarExcepciones("btn_importar_Click", ex.ToString());

                }

        }
    }
}