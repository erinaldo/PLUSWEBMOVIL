using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.EstadoDocEle;

namespace CapaWeb.WebForms
{
    public partial class FormEstadoDE : System.Web.UI.Page
    {
        modelocabecerafactura cabecerafactura = new modelocabecerafactura();
        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

        List<ModeloDetalleFactura> ModeloDetalleFactura = new List<ModeloDetalleFactura>();
        Consultawmtfacturasdet ConsultaDeta = new Consultawmtfacturasdet();
        ModeloDetalleFactura detallefactura = new ModeloDetalleFactura();

        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        ModeloDetalleFactura consdetalle = new ModeloDetalleFactura();
        List<modelowmtfacturascab> listaConsCab = null;

        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        public List<JsonRespuestaDE> ListaModelorespuestaDs = null;
        public JsonRespuestaDE ModeloResQr = new JsonRespuestaDE();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();

        List<JsonEstadoDocElec> ListaEstado = new List<JsonEstadoDocElec>();
        RespuestaDC consEstado = new RespuestaDC();
        ConsultaEstadoDE consumo = new ConsultaEstadoDE();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        modelowmtfacturascab conscabceraTipo = new modelowmtfacturascab();
        CabezeraFactura GuardarCabezera = new CabezeraFactura();
        RolesUserFacturacion activa = new RolesUserFacturacion();
        public string ComPwm;
        public string AmUsrLog;
        public string nro_trans = null;
       public  string activo_estado = null;
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

                    QueryString qs = ulrDesencriptada();

                    //Recibir opciones
                    switch (qs["TRN"].Substring(0, 3))
                    {

                        case "VER":
                            try
                            {
                                lbl_error.Text = "";
                                Int64 ide = Int64.Parse(qs["Id"].ToString());
                                string nro_trans = ide.ToString();
                                Session["numero_trx"] = ide.ToString();
                                ConsultarEstado(nro_trans);
                                CargarGrilla();

                                break;
                            }
                            catch (Exception ex)
                            {
                                GuardarExcepciones("Page_Load, VER", ex.ToString());

                            }
                            break;


                        case "MTR":
                            try
                            {
                                lbl_error.Text = "";
                                Int64 ide = Int64.Parse(qs["Id"].ToString());
                                nro_trans = ide.ToString();
                                Session["numero"] = ide.ToString();
                                //CargarFormularioRespuestaDS(nro_trans);
                                CargarGrilla();

                                break;
                            }
                            catch (Exception ex)
                            {
                                GuardarExcepciones("Page_Load, MTR", ex.ToString());

                            }
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Page_Load", ex.ToString());

            }
        }
        public void ConsultarEstado(string nro_trans)
        {
            try
            {
               

               lbl_error.Text =  consumo.ConsultaEstadoDocumento(ComPwm, AmUsrLog, "C", "", nro_trans);
                //Activar boton finalizar documento
               
                activo_estado =activa.RolModificarEstado(AmUsrLog);

                if(!string.IsNullOrEmpty(activo_estado))
                {
                    btn_udp.Visible = true;
                }
                else { btn_udp.Visible = false; }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("ConsultarEstado", ex.ToString());

            }

}
        public void GuardarExcepciones(string metodo, string error)
        {

            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "FormEstadoDE.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;
            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }


        private void CargarFormularioRespuestaDS(string nro_trans, string linea)
        {
            try
            {
                lbl_error.Text = "";

                ListaModelorespuestaDs = consultaRespuestaDS.RespuestaLineaQr(nro_trans, linea);
                int count = 0;
                foreach (var item in ListaModelorespuestaDs)
                {
                    ModeloResQr = item;
                    count++;
                    break;
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("CargarFormularioRespuestaDS", ex.ToString());

            }



        }
        private void CargarGrilla()
        {

            ListaEstado = consEstado.ConsultaEstados(Session["numero_trx"].ToString());
            Grid.DataSource = ListaEstado;
            Grid.DataBind();
            Grid.Height = 100;
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
            try
            {
                lbl_error.Text = "";

                //1 primero creo un objeto Clave/Valor de QueryString 
                QueryString qs = new QueryString();
                //Escoger opcion

                int Id;
                int linea;

                switch (e.CommandName) //ultilizo la variable para la opcion
                {

                    
                    case "Ver": //ejecuta el codigo si el usuario ingresa el numero 3
                        try
                        {
                            lbl_error.Text = "";
                            Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                            linea = Convert.ToInt32(((Label)e.Item.Cells[2].FindControl("linea")).Text);
                            qs.Add("TRN", "VER");
                            qs.Add("Id", Id.ToString());
                            qs.Add("linea", linea.ToString());

                            Response.Redirect("FormEstadoDocElec.aspx" + Encryption.EncryptQueryString(qs).ToString());

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
            }
            catch (Exception ex)
            {
                GuardarExcepciones("RecuperarCokie", ex.ToString());

            }
        }

        public QueryString ulrDesencriptada()
        {
            try
            {
                lbl_error.Text = "";
                //1- guardo el Querystring encriptado que viene desde el request en mi objeto
                QueryString qs = new QueryString(Request.QueryString);

                ////2- Descencripto y de esta manera obtengo un array Clave/Valor normal
                qs = Encryption.DecryptQueryString(qs);
                return qs;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("ulrDesencriptada", ex.ToString());
                return null;

            }
        }

        public modelowmtfacturascab buscarTipoFac(string nro_trans)
        {
            try
            {
                lbl_error.Text = "";

                listaConsCab = ConsultaCabe.ConsultaTipoFactura(nro_trans);
                int count = 0;
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                    count++;
                    conscabcera = item;

                }
                return conscabcera;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("buscarTipoFac", ex.ToString());
                return null;
            }
        }
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                //Consultar tipo
                conscabceraTipo = null;
                conscabceraTipo = buscarTipoFac(Session["numero_trx"].ToString());
                QueryString qs = new QueryString();
                //2 voy a agregando los valores que deseo
                qs.Add("TRN", "MTR");
                qs.Add("Id", Session["numero_trx"].ToString());
                if (conscabceraTipo.tipo_nce.Trim() == "VTAE" || conscabceraTipo.tipo_nce.Trim() == "POSE")
                {
                    Response.Redirect("PortalFacturas.aspx" + Encryption.EncryptQueryString(qs).ToString());
                }
                if (conscabceraTipo.tipo_nce.Trim() == "NCVE" || conscabceraTipo.tipo_nce.Trim() == "NCME")
                {
                    Response.Redirect("ListaRespuestaNCDS.aspx" + Encryption.EncryptQueryString(qs).ToString());
                }
                if (conscabceraTipo.tipo_nce.Trim() == "NDVE")
                {
                    Response.Redirect("ListaRespuestaND.aspx" + Encryption.EncryptQueryString(qs).ToString());
                }

            }
            catch (Exception ex)
            {
                GuardarExcepciones("Cancelar_Click", ex.ToString());

            }
        }

        protected void btn_udp_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarCabezera.ActualizarEstadoFactura(Session["numero_trx"].ToString().Trim(), "F");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_udp_Click", ex.ToString());

            }
        }
    }
}