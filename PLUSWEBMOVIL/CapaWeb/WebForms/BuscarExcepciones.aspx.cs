using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaProceso.RestCliente;
using CapaDatos.Modelos;
using CapaProceso.GenerarPDF.FacturaElectronica;
using System.IO;
using System.Text;

namespace CapaWeb.WebForms
{
    public partial class BuscarExcepciones : System.Web.UI.Page
    {
        Consultaestadosfactura Consultaestados = new Consultaestadosfactura();
        List<modeloestadosfactura> Listaestados = null;

        public ConsultaRolesFactura ConsultaRoles = new ConsultaRolesFactura();
        public modeloRolesFacturacion ModeloRoles = new modeloRolesFacturacion();
        public List<modeloRolesFacturacion> ListaModelosRoles = null;

        public ConsultaCodProceso ConsultaCodProceso = new ConsultaCodProceso();
        public modeloCodProcesoFactura ModeloCodProceso = new modeloCodProcesoFactura();
        public List<modeloCodProcesoFactura> ListaModeloCodProceso = null;

        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        List<modelowmtfacturascab> listaConsCab = null;
        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

        ConsumoRest consumoRest = new ConsumoRest();

        Consultawmsptitulares ConsultaTitulares = new Consultawmsptitulares();
        public List<modelowmspctitulares> lista = null;
        modelowmspctitulares cliente = new modelowmspctitulares();

        public List<modelowmspcfacturasWMimpuRest> ListaModeloimpuesto = new List<modelowmspcfacturasWMimpuRest>();
        public modelowmspcfacturasWMimpuRest ModeloImpuesto = new modelowmspcfacturasWMimpuRest();
        public ConsultawmspcfacturasWMimpuRest consultaImpuesto = new ConsultawmspcfacturasWMimpuRest();

        public List<JsonRespuestaDE> ListaModelorespuestaDs = null;
        public JsonRespuestaDE ModeloResQr = new JsonRespuestaDE();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        List<modeloExepciones> listaExcepciones = null;
        Consultawmsptitulares UsuarioDatos = new Consultawmsptitulares();
        List<modeloUsuarioSistema> listaUsuarios = null;
        public string numerador = "trans";
        public string ComPwm;
        public string AmUsrLog;
        public string cod_proceso;
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
        public string Ven__cod_tipotit = "cliente";
        public string Ven__cod_tit = " ";

        public string EstF_proceso = "RCOMFACT";
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


                    fechainicio.Text = DateTime.Today.ToString("yyyy-MM-dd");
                    fechafin.Text = DateTime.Today.ToString("yyyy-MM-dd");
                    cargarListaDesplegables();
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());

            }
        }
        public void cargarListaDesplegables()
        {
            try
            {
                lbl_error.Text = "";
                //LIsta Resolucion facturas
                listaUsuarios = UsuarioDatos.ConsultaUsuarios(AmUsrLog, ComPwm);
                cbx_usuario.DataSource = listaUsuarios;
                cbx_usuario.DataTextField = "usuario";
                cbx_usuario.DataValueField = "usuario";
                cbx_usuario.DataBind();
                cbx_usuario.Items.Insert(0, new ListItem("TODOS", "0"));
                cbx_usuario.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("cargarListaDesplegables", ex.ToString());

            }
        }
        public void GuardarExcepciones(string metodo, string error)
        {

            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "BuscarExcepciones.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;

            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }
      




        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                // paginar la grilla asegurarse que la obcion que la propiedad AllowPaging sea True.
                Grid.CurrentPageIndex = 0;
                Grid.CurrentPageIndex = e.NewPageIndex;
                CargarGrilla();
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Grid_PageIndexChanged", ex.ToString());

            }
        }


        private void CargarGrilla()
        {
            try
            {
                //Cuando el usuario envia los datos llenos
                DateTime Fechainicio = Convert.ToDateTime(fechainicio.Text);
                DateTime Fechafin = Convert.ToDateTime(fechafin.Text);

                
                        listaExcepciones = consultaExcepcion.ListaExcepcionPFecha(ComPwm,Fechainicio, Fechafin, AmUsrLog);
                        Grid.DataSource = listaExcepciones;
                        Grid.DataBind();
                        Grid.Height = 100;
                    
                    

            }
            catch (Exception ex)
            {
                GuardarExcepciones("CargarGrilla", ex.ToString());

            }


        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                //Cuando el usuario envia los datos llenos
                DateTime Fechainicio = Convert.ToDateTime(fechainicio.Text);
                DateTime Fechafin = Convert.ToDateTime(fechafin.Text);

                if (cbx_usuario.SelectedValue != "0")
                {
                    if (txtDocumento.Text != "0")
                    {
                        listaExcepciones = consultaExcepcion.ListaExcepcionPC(ComPwm, cbx_usuario.SelectedValue.Trim(), txtDocumento.Text.Trim(), Fechainicio, Fechafin, AmUsrLog);
                        Grid.DataSource = listaExcepciones;
                        Grid.DataBind();
                        Grid.Height = 100;
                    }
                    else

                    {
                        //Busqueda por usuario y fechas
                        listaExcepciones = consultaExcepcion.ListaExcepcionUsuarioFe(ComPwm, cbx_usuario.SelectedValue.Trim(), Fechainicio, Fechafin, AmUsrLog);
                        Grid.DataSource = listaExcepciones;
                        Grid.DataBind();
                        Grid.Height = 100;

                    }


                }
                else
                    if (txtDocumento.Text == "0")
                {
                    //Busca solo por fechas
                    listaExcepciones = consultaExcepcion.ListaExcepcionPFecha(ComPwm, Fechainicio, Fechafin, AmUsrLog);
                    Grid.DataSource = listaExcepciones;
                    Grid.DataBind();
                    Grid.Height = 100;

                }
                else
                {
                    if (txtDocumento.Text != "0")
                    {
                        //Busca por documento(proceso) y fecha
                        listaExcepciones = consultaExcepcion.ListaExcepcionProcesoFecha(ComPwm, txtDocumento.Text.Trim(), Fechainicio, Fechafin, AmUsrLog);
                        Grid.DataSource = listaExcepciones;
                        Grid.DataBind();
                        Grid.Height = 100;
                    }
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Buscar_Click", ex.ToString());

            }


        }



        protected void Grid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                lbl_error.Text = "";


                //1 primero creo un objeto Clave/Valor de QueryString 
                QueryString qs = new QueryString();
                //Escoger opcion

                int Id;
                
                switch (e.CommandName) //ultilizo la variable para la opcion
                {


                    case "Ver":
                        try
                        {
                            Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("id")).Text);

                            qs.Add("TRN", "VER");
                            qs.Add("Id", Id.ToString());

                          

                            Response.Redirect("FormExcepciones.aspx" + Encryption.EncryptQueryString(qs).ToString());

                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("Grid_ItemCommand, Ver", ex.ToString());

                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Grid_ItemCommand", ex.ToString());

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
            }
            catch (Exception ex)
            {
                GuardarExcepciones("RecuperarCokie", ex.ToString());

            }


        }
    }
}