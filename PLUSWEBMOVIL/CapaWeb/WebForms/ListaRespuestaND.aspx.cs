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
    public partial class ListaRespuestaND : System.Web.UI.Page
    {
        modelocabecerafactura cabecerafactura = new modelocabecerafactura();
        Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();

        List<ModeloDetalleFactura> ModeloDetalleFactura = new List<ModeloDetalleFactura>();
        Consultawmtfacturasdet ConsultaDeta = new Consultawmtfacturasdet();
        ModeloDetalleFactura detallefactura = new ModeloDetalleFactura();

        modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        ModeloDetalleFactura consdetalle = new ModeloDetalleFactura();
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        public List<JsonRespuestaDE> ListaModelorespuestaDs = null;
        public JsonRespuestaDE ModeloResQr = new JsonRespuestaDE();
        public ConsultawmtrespuestaDS consultaRespuestaDS = new ConsultawmtrespuestaDS();

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
        List<JsonEstadoDocElec> ListaEstado = new List<JsonEstadoDocElec>();
        RespuestaDC consEstado = new RespuestaDC();
        ConsultaEstadoDE consumo = new ConsultaEstadoDE();
        public string numerador = "trans";

        public string ComPwm;
        public string AmUsrLog;
        public string nro_trans = null;
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

                        case "MTR":
                            try
                            {
                                Int64 ide = Int64.Parse(qs["Id"].ToString());
                                nro_trans = ide.ToString();
                                Session["numero_nd"] = ide.ToString();
                                ConsultarEstado(nro_trans);
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
               
                lbl_error.Text = consumo.ConsultaEstadoDocumento(ComPwm, AmUsrLog, "C", "", nro_trans);
                ListaEstado = consEstado.ConsultaEstados(Session["numero_nd"].ToString());

                foreach (var item in ListaEstado)
                {
                    if (item.cargopdf.Trim() == "false")
                    {
                        txt_estado.Text = "Documento  no autorizado. PDF no enviado, revisar incidencias.";
                    }
                    if (string.IsNullOrEmpty(item.cargopdf.Trim()))
                    {
                        txt_estado.Text = "Documento  no autorizado. PDF no enviado, revisar incidencias.";
                    }
                    if (item.cargopdf.Trim() == "true")
                    {
                        txt_estado.Text = "Documento   autorizado correctamente.";
                    }
                    break;
                }

            }
            catch (Exception ex)
            {
                GuardarExcepciones("ConsultarEstado", ex.ToString());

            }

        }
        public void GuardarExcepciones(string metodo, string error)
        {
            //obtener numero de transaccion

            ModeloExcepcion.cod_emp = ComPwm;
            ModeloExcepcion.proceso = "ListaRespuestaND.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;

            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }


        private void CargarGrilla()
        {
            try
            {
                lbl_error.Text = "";


                ListaModelorespuestaDs = consultaRespuestaDS.ConsultaRespuestaQr(Session["numero_nd"].ToString());
                Grid.DataSource = ListaModelorespuestaDs;
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

                    case "Mostrar": //ejecuta el codigo si el usuario ingresa el numero 3
                        try
                        {
                            Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                            linea = Convert.ToInt32(((Label)e.Item.Cells[2].FindControl("linea")).Text);
                            qs.Add("TRN", "MTR");
                            qs.Add("Id", Id.ToString());
                            qs.Add("linea", linea.ToString());

                            Response.Redirect("FormRespuestaNDJson.aspx" + Encryption.EncryptQueryString(qs).ToString());

                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("Grid_ItemCommand, Mostrar", ex.ToString());

                        }
                        break;

                    case "Ver": //ejecuta el codigo si el usuario ingresa el numero 3
                        try
                        {
                            Id = Convert.ToInt32(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                            linea = Convert.ToInt32(((Label)e.Item.Cells[2].FindControl("linea")).Text);
                            qs.Add("TRN", "VER");
                            qs.Add("Id", Id.ToString());
                            qs.Add("linea", linea.ToString());

                            Response.Redirect("FormRespuestaNDDIAN.aspx" + Encryption.EncryptQueryString(qs).ToString());

                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("Grid_ItemCommand, VER", ex.ToString());

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

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                Session.Remove("numero_nd");
                Response.Redirect("BuscarNotaDebito.aspx");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Cancelar_Click", ex.ToString());

            }
        }

        protected void btn_estado_Click(object sender, EventArgs e)
        {
            try
            {
                QueryString qs = new QueryString();

                qs.Add("TRN", "VER");
                qs.Add("Id", Session["numero_nd"].ToString());
                Response.Redirect("FormEstadoDE.aspx" + Encryption.EncryptQueryString(qs).ToString());
            }

            catch (Exception ex)
            {
                GuardarExcepciones("btn_estado_Click", ex.ToString());

            }
        }
    }
}