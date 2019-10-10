using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaDatos.Modelos;
using System.Globalization;

namespace CapaWeb.WebForms
{
    public partial class BuscarCierreCaja : System.Web.UI.Page
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
        modelowmspcempresas modeloEmpresa = new modelowmspcempresas();

        Consultawmsptitulares UsuarioDatos = new Consultawmsptitulares();
       
        List<modeloUsuarioSistema> listaUsuarios = null;

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


                    //fechainicio.Text = DateTime.Today.ToString("yyyy-MM-dd");
                    Tabla.Visible = false;
                    imp.Visible = false;
                    
                    fechainicio.Text = DateTime.Today.ToString("yyyy-MM-dd");
                    fechafin.Text = DateTime.Today.ToString("yyyy-MM-dd");

                    Btn_Refrescar.Visible = false;
                    Lbl_Usuario.Text = UsuarioDatos.BuscarNombreUsuario(AmUsrLog.Trim());
                   
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
                //Lista DE CAJAS POR USUARIO
                listaCajasUsuario = ConsultaCCaja.ConsultaCajasCierre(AmUsrLog, ComPwm, "", "");
                cbx_caja_usuario.DataSource = listaCajasUsuario;
                cbx_caja_usuario.DataTextField = "observacion";
                cbx_caja_usuario.DataValueField = "nrocta_banco";
                cbx_caja_usuario.DataBind();
                cbx_caja_usuario.Items.Insert(0, new ListItem("TODAS", "0"));
                cbx_caja_usuario.SelectedIndex = 0;
                //LISTA DE USUARIOS DEL SISTEMA

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
            ModeloExcepcion.proceso = "BuscarCierreCaja.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Today;
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
                Grid1.CurrentPageIndex = 0;
                Grid1.CurrentPageIndex = e.NewPageIndex;
                CargarGrilla();
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Grid_PageIndexChanged", ex.ToString());
            }
        }
        private void CargarGrilla()
        {
            try { 
            lbl_error.Text = "";
                if (cbx_caja_usuario.SelectedValue == "0" && cbx_usuario.SelectedValue == "0")//Busca todas las cajas y usuarios por empresa
                {
                    listaEfectivoC = ConsultaEfectivoC.ListaEfectivoFechaGeneral(ComPwm, fechainicio.Text, fechafin.Text, AmUsrLog);
                }
                if (cbx_caja_usuario.SelectedValue != "0" && cbx_usuario.SelectedValue == "0")//Buscar por caja especifica y todos los usuarios por empresa
                {
                    listaEfectivoC = ConsultaEfectivoC.ListaEfectivoFechaCaja(ComPwm, fechainicio.Text, fechafin.Text, AmUsrLog, cbx_caja_usuario.SelectedValue.Trim());
                }
                if (cbx_caja_usuario.SelectedValue == "0" && cbx_usuario.SelectedValue != "0")//Buscar por usuario especifica y todas las cajas por empresa
                {
                    listaEfectivoC = ConsultaEfectivoC.ListaEfectivoFechaCajaUsuario(ComPwm, fechainicio.Text, fechafin.Text, AmUsrLog, cbx_usuario.SelectedValue.Trim());
                }
                if (cbx_caja_usuario.SelectedValue != "0" && cbx_usuario.SelectedValue != "0")//Buscar por usuario y cajas especifica  por empresa
                {
                    listaEfectivoC = ConsultaEfectivoC.ListaEfectivoFechaCajaUsuarioEspec(ComPwm, fechainicio.Text, fechafin.Text, AmUsrLog, cbx_usuario.SelectedValue.Trim(), cbx_caja_usuario.SelectedValue.Trim());
                }
                Grid1.DataSource = listaEfectivoC;
            Grid1.DataBind();
            Grid1.Height = 100;
            }
            catch (Exception ex)
            {
                GuardarExcepciones("CargarGrilla", ex.ToString());

            }
        }

        //Buscar cantidad de decimales q se va ausar x tipo de moneda
        public modelowmspcmonedas BuscarDecimales()
        {
            try
            {
                lbl_error.Text = "";
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

        protected void Grid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                lbl_error.Text = "";


                //1 primero creo un objeto Clave/Valor de QueryString 
                QueryString qs = new QueryString();
                //Escoger opcion

                string Id;
                string secuencial;
                string caja;
                string fecha_c;
                string usuario;

                switch (e.CommandName) //ultilizo la variable para la opcion
                {

                    case "Ver": //ejecuta el codigo si el usuario ingresa el numero 1
                        try
                        {
                            Id = Convert.ToString(((Label)e.Item.Cells[1].FindControl("nro_trans")).Text);
                            secuencial = Convert.ToString(((Label)e.Item.Cells[2].FindControl("secuencial")).Text);
                            caja = Convert.ToString(((Label)e.Item.Cells[3].FindControl("nro_caja")).Text);
                            usuario = Convert.ToString(((Label)e.Item.Cells[4].FindControl("usuario_mod")).Text);
                            fecha_c = Convert.ToString(((Label)e.Item.Cells[5].FindControl("fecha_st")).Text);
                            //2 voy a agregando los valores que deseo
                            qs.Add("TRN", "VER");
                             qs.Add("Id", Id.ToString());
                            Session["Nro_trans"] = Id;
                            Session["Secuencial"] = secuencial;
                            Session["Caja"] = caja;
                            Session["fecha_c"] = fecha_c;
                            Session["usuario"] = usuario;

                            Response.Write("<script>window.open('" + "ReporteCierreC.aspx" + Encryption.EncryptQueryString(qs).ToString() + "')</script>");
                            break;//termina la ejecucion del programa despues de ejecutar el codigo
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("Grid_ItemCommand, Editar", ex.ToString());

                        }
                        break;


                    case "Eliminar": //ejecuta el codigo si el usuario ingresa el numero 3
                        try
                        {
                            Id = Convert.ToString(((Label)e.Item.Cells[1].FindControl("id")).Text);

                            qs.Add("TRN", "DLT");
                            qs.Add("Id", Id.ToString());
                            Response.Write("<script>window.open('"+"FormDenominaciones.aspx" + Encryption.EncryptQueryString(qs).ToString()+"')</script>");
                            //Response.Redirect("FormDenominaciones.aspx" + Encryption.EncryptQueryString(qs).ToString());
                            break;
                        }
                        catch (Exception ex)
                        {
                            GuardarExcepciones("Grid_ItemCommand, Eliminar", ex.ToString());

                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Grid_ItemComman", ex.ToString());

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
        protected void NuevoCierre_Click(object sender, EventArgs e)
        {

            try
            {
                lbl_error.Text = "";

                Response.Redirect("FormCierreCaja.aspx");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("NuevoCierre_Click", ex.ToString());

            }
        }
        public void calculosCC()
        {
          /*  //Consulta si existe o no Cierres pasados

            //Buscamos el ultimo secuancial
            DecimalesMoneda = null;
            DecimalesMoneda = BuscarDecimales();
            decimal totalCaja = 0;
            decimal SaldoCaja = 0;
            decimal SaldoN = 0;
            //Int64 secuEfe = ConsultaEfectivoC.UltimoEfectivoSecuencial(fechainicio.Text);
            Int64 secuEfe = Convert.ToInt64(cbx_lista_cierres.SelectedValue);

            listaEfectivoC = ConsultaEfectivoC.ListaCCajaFecha(fechainicio.Text, secuEfe, ComPwm, cbx_caja_usuario.SelectedValue);
            Grid.DataSource = listaEfectivoC;
            Grid.DataBind();
            Grid.Height = 100;
            foreach (modeloEfectivoCaja item in listaEfectivoC)
            {
                modeloEfectivoC = item;
                totalCaja += modeloEfectivoC.total;
            }
            decimal valorCaja = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, totalCaja);
            txt_valor_caja.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, valorCaja);

            ///campo uno
            Int64 secCierre = Convert.ToInt64(cbx_lista_cierres.SelectedValue);
            string codigo = "VIDA";
            listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(fechainicio.Text, secCierre, codigo, ComPwm, cbx_caja_usuario.SelectedValue.Trim());
            modeloCCcaja = null;
            foreach (modeloCierreCaja item in listaCCaja)
            {
                modeloCCcaja = item;
            }
            decimal valor_id = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
            txt_valor_id.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, valor_id);
            txt_valor_id.ReadOnly = true;
            SaldoCaja = modeloCCcaja.valor;
            //campo dos
            listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(fechainicio.Text, secCierre, "INFA", ComPwm, cbx_caja_usuario.SelectedValue.Trim());
            modeloCCcaja = null;
            foreach (modeloCierreCaja item in listaCCaja)
            {
                modeloCCcaja = item;
            }
            decimal ingreso_facturas = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
            txt_ingreso_facturas.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, ingreso_facturas);
            txt_ingreso_facturas.ReadOnly = true;
            SaldoCaja += modeloCCcaja.valor;
            //campo tres
            listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(fechainicio.Text, secCierre, "INVT", ComPwm, cbx_caja_usuario.SelectedValue.Trim());
            modeloCCcaja = null;
            foreach (modeloCierreCaja item in listaCCaja)
            {
                modeloCCcaja = item;
            }
            decimal ingreso_nventas = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
            txt_ingreso_nventas.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, ingreso_nventas);
            txt_ingreso_nventas.ReadOnly = true;
            SaldoCaja += modeloCCcaja.valor;
            //campo cuatro
            listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(fechainicio.Text, secCierre, "PEFA", ComPwm, cbx_caja_usuario.SelectedValue.Trim());
            modeloCCcaja = null;
            foreach (modeloCierreCaja item in listaCCaja)
            {
                modeloCCcaja = item;
            }
            decimal pefectivo_facturas = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
            txt_pefectivo_facturas.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, pefectivo_facturas);
            txt_pefectivo_facturas.ReadOnly = true;
            SaldoN = modeloCCcaja.valor;
            //campoCINCO
            listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(fechainicio.Text, secCierre, "PEOT", ComPwm, cbx_caja_usuario.SelectedValue.Trim());
            modeloCCcaja = null;
            foreach (modeloCierreCaja item in listaCCaja)
            {
                modeloCCcaja = item;
            }
            decimal pefectivo_otros = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
            txt_pefectivo_otros.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, pefectivo_otros);
            txt_pefectivo_otros.ReadOnly = true;
            SaldoN += modeloCCcaja.valor;
            //CAMPO SEIS           
            listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(fechainicio.Text, secCierre, "DEPD", ComPwm, cbx_caja_usuario.SelectedValue.Trim());
            modeloCCcaja = null;
            foreach (modeloCierreCaja item in listaCCaja)
            {
                modeloCCcaja = item;
            }
            decimal depositos = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
            txt_depositos.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, depositos);
            txt_depositos.ReadOnly = true;
            SaldoN += modeloCCcaja.valor;
            //CAMPO SIETE
            listaCCaja = ConsultaCCaja.ConsultaCCajaFecha(fechainicio.Text, secCierre, "EFPC", ComPwm, cbx_caja_usuario.SelectedValue.Trim());
            modeloCCcaja = null;
            foreach (modeloCierreCaja item in listaCCaja)
            {
                modeloCCcaja = item;
            }
            decimal efectivoCaja = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, modeloCCcaja.valor);
            txt_efectivo_caja.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, efectivoCaja);
            txt_efectivo_caja.ReadOnly = true;
            SaldoCaja += modeloCCcaja.valor;

            decimal totalS = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, (SaldoCaja - SaldoN));

            txt_saldo_caja.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, totalS);
            decimal Diferencia = Convert.ToDecimal(txt_valor_caja.Text) - Convert.ToDecimal(txt_saldo_caja.Text);
            decimal dif = ConsultaCMonedas.RedondearNumero(DecimalesMoneda.redondeo, Diferencia);

            txt_diferencia.Text = ConsultaCMonedas.FormatorNumero(DecimalesMoneda.redondeo, dif);
            Tabla.Visible = true;
            imp.Visible = true;
            cbx_lista_cierres.Items.Clear();
            fechainicio.Text = "";
            cbx_lista_cierres.Visible = false;
            Buscar.Visible = false;
            lbl_busqueda.Visible = false;
            Btn_Refrescar.Visible = true;

            listaCajasUsuario = null;
            listaCajasUsuario = ConsultaCCaja.ConsultadatosCaja(AmUsrLog, ComPwm, "", "", cbx_caja_usuario.SelectedValue.Trim());
            modeloCajasUsuario = null;
            foreach (modeloCajasCierre item in listaCajasUsuario)
            {
                modeloCajasUsuario = item;
            }
            lbl_caja_usuario.Text = modeloCajasUsuario.nomtcta_banco;*/

        }
        protected void Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                //Buscar fecha
                if (cbx_caja_usuario.SelectedValue == "0" && cbx_usuario.SelectedValue == "0")//Busca todas las cajas y usuarios por empresa
                {
                    listaEfectivoC = ConsultaEfectivoC.ListaEfectivoFechaGeneral(ComPwm, fechainicio.Text, fechafin.Text, AmUsrLog);
                }
                if (cbx_caja_usuario.SelectedValue != "0" && cbx_usuario.SelectedValue == "0")//Buscar por caja especifica y todos los usuarios por empresa
                {
                    listaEfectivoC = ConsultaEfectivoC.ListaEfectivoFechaCaja(ComPwm, fechainicio.Text, fechafin.Text, AmUsrLog, cbx_caja_usuario.SelectedValue.Trim());
                }
                if (cbx_caja_usuario.SelectedValue == "0" && cbx_usuario.SelectedValue != "0")//Buscar por usuario especifica y todas las cajas por empresa
                {
                    listaEfectivoC = ConsultaEfectivoC.ListaEfectivoFechaCajaUsuario(ComPwm, fechainicio.Text, fechafin.Text, AmUsrLog, cbx_usuario.SelectedValue.Trim());
                }
                if (cbx_caja_usuario.SelectedValue != "0" && cbx_usuario.SelectedValue != "0")//Buscar por usuario y cajas especifica  por empresa
                {
                    listaEfectivoC = ConsultaEfectivoC.ListaEfectivoFechaCajaUsuarioEspec(ComPwm, fechainicio.Text, fechafin.Text, AmUsrLog, cbx_usuario.SelectedValue.Trim(), cbx_caja_usuario.SelectedValue.Trim());
                }
                Grid1.DataSource = listaEfectivoC;
                Grid1.DataBind();
                Grid1.Height = 100;


            }
            catch (Exception ex)
            {
                GuardarExcepciones("Buscar_Click", ex.ToString());

            }
        }

      
        

        protected void Btn_Refrescar_Click1(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                Response.Redirect("BuscarCierreCaja.aspx");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("Btn_Refrescar_Click1", ex.ToString());

            }
        }

        protected void btn_ingreso_facturas_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                Session["Fecha"] = lbl_fecha.Text;
                this.Page.Response.Write("<script language='JavaScript'>window.open('./BuscarIngresoFacturasPgs.aspx', 'Ingreso Facturas', 'top=100,width=800 ,height=400, left=400');</script>");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_ingreso_facturas_Click", ex.ToString());

            }
        }

        protected void btn_ingreso_nventas_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                Session["Fecha"] = lbl_fecha.Text;
                this.Page.Response.Write("<script language='JavaScript'>window.open('./BuscarNotasVenta.aspx', 'Notas Venta', 'top=100,width=800 ,height=400, left=400');</script>");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_ingreso_nventas_Click", ex.ToString());

            }

        }

        protected void btn_pefectivo_facturas_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                Session["Fecha"] = lbl_fecha.Text;
                this.Page.Response.Write("<script language='JavaScript'>window.open('./BuscarPProveedores.aspx', 'Pago Proveedores', 'top=100,width=800 ,height=400, left=400');</script>");
            }
            catch (Exception ex)
            {
                GuardarExcepciones("btn_pefectivo_facturas_Click", ex.ToString());

            }


        }

        protected void btn_buscar_todos_Click(object sender, EventArgs e)
        {
            //Buscar todos los registros
        }
    }
}