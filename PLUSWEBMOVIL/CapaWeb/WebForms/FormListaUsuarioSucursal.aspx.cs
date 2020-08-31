using System;
using System.Collections.Generic;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using System.Web.UI.WebControls;
using CapaWeb.Urlencriptacion;
using CapaDatos.Modelos;

namespace CapaWeb
{
    public partial class FormListaUsuarioSucursal : System.Web.UI.Page
    {
        public modelowmspclogo Modelowmspclogo = new modelowmspclogo();
        public ConsultaLogo consultaLogo = new ConsultaLogo();
        public List<modelowmspclogo> ListaModelowmspclogo = new List<modelowmspclogo>();

        public modeloUsuariosucursal ModelousuarioSucursal = new modeloUsuariosucursal();
        public List<modeloUsuariosucursal> ListaModeloUsuarioSucursal = new List<modeloUsuariosucursal>();
        public ConsultausuarioSucursal consultaUsuarioSucursal = new ConsultausuarioSucursal();
        public ConsultawmusuarioSucursal ConsultaUsuxSuc = new ConsultawmusuarioSucursal();
        public modeloUsuariosucursal UsuarioSucursal = new modeloUsuariosucursal();

        ConsultaNumerador ConsultaNroTran = new ConsultaNumerador();
        modelonumerador nrotrans = new modelonumerador();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();
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

                    CargarGrilla(ComPwm);
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
            ModeloExcepcion.proceso = "FormListaUsuarioSucursal.aspx";
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

        private void CargarGrilla(string ComPwm)
        {
            try
            {
                lbl_error.Text = "";


                ListaModeloUsuarioSucursal = ConsultaUsuxSuc.ListaUsuarioSucursal(ComPwm);
                Grid.DataSource = ListaModeloUsuarioSucursal;
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
                CargarGrilla(ComPwm);
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

                string Id;
                string cod_sucursal;

                switch (e.CommandName) //ultilizo la variable para la opcion
                {

                    case "Editar": //ejecuta el codigo si el usuario ingresa el numero 1
                        try
                        {
                            Id = Convert.ToString(((Label)e.Item.Cells[1].FindControl("usuario")).Text);
                            cod_sucursal = Convert.ToString(((Label)e.Item.Cells[1].FindControl("cod_sucursal")).Text);
                            //2 voy a agregando los valores que deseo
                            qs.Add("TRN", "UDP");
                            qs.Add("Id", Id.ToString());
                            qs.Add("suc", cod_sucursal.ToString());

                            Response.Redirect("FormUsuariosucursal.aspx" + Encryption.EncryptQueryString(qs).ToString());
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
                            Id = Convert.ToString(((Label)e.Item.Cells[1].FindControl("usuario")).Text);
                            cod_sucursal = Convert.ToString(((Label)e.Item.Cells[1].FindControl("cod_sucursal")).Text);
                            qs.Add("TRN", "DLT");
                            qs.Add("Id", Id.ToString());
                            qs.Add("suc", cod_sucursal.ToString());
                            Response.Redirect("FormUsuariosucursal.aspx" + Encryption.EncryptQueryString(qs).ToString());
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
                GuardarExcepciones("Grid_ItemCommand", ex.ToString());

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
        protected void NuevoUsuSucursal_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";
                //1 primero creo un objeto Clave/Valor de QueryString 
                QueryString qs = new QueryString();

                //2 voy a agregando los valores que deseo
                qs.Add("TRN", "INS");
                qs.Add("Id", "");
                Response.Redirect("FormUsuariosucursal.aspx" + Encryption.EncryptQueryString(qs).ToString());
            }
            catch (Exception ex)
            {
                GuardarExcepciones("NuevoUsuSucursal_Click", ex.ToString());

            }
        }
    }
}