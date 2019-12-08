using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaProceso.Consultas;
using CapaProceso.Modelos;
using CapaDatos.Modelos;

namespace CapaWeb.WebForms
{
    public partial class BuscarCliente : System.Web.UI.Page
    {
        Consultawmsptitulares ConsultaTitulares = new Consultawmsptitulares();
        public List<modelowmspctitulares> lista = null;
        modelowmspctitulares cliente = new modelowmspctitulares();
        ConsultaExcepciones consultaExcepcion = new ConsultaExcepciones();
        modeloExepciones ModeloExcepcion = new modeloExepciones();

        public string ComPwm;
        public string AmUsrLog;        
        public string Ven__cod_tipotit = "clientes";
        public string Ven__cod_tit = " ";
        public string Ven__cod_dgi = "0";
        public string Ven__fono = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                RecuperarCokie();
                if (!IsPostBack)
                {

                    Session.Remove("cliente");

                    if (Request.Cookies["ComPwm"] != null)
                    {
                        string ComPwm = Request.Cookies["ComPwm"].Value;

                    }

                    if (Session["listaCliente"] != null)
                    {
                        // recupera la variable de secion con el objeto persona   
                        lista = (List<modelowmspctitulares>)Session["listaCliente"];
                        Session["lista"] = lista;
                        gvPerson.DataSource = lista;
                        gvPerson.DataBind();

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
            ModeloExcepcion.proceso = "BuscarCliente.aspx";
            ModeloExcepcion.metodo = metodo;
            ModeloExcepcion.error = error;
            ModeloExcepcion.fecha_hora = DateTime.Now;
            ModeloExcepcion.usuario_mod = AmUsrLog;

            consultaExcepcion.InsertarExcepciones(ModeloExcepcion);
            //mandar mensaje de error a label
            lbl_error.Text = "No se pudo completar la acción." + metodo + "." + " Por favor notificar al administrador.";

        }

        protected void TxtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                CargarGrilla(TxtBuscarCliente.Text);
            }
            catch (Exception ex)
            {
                GuardarExcepciones("TxtBuscarCliente_TextChanged", ex.ToString());

            }
        }


        private void CargarGrilla(string Ven__cod_tit)
        {
            try
            {
                lbl_error.Text = "";

                lista = ConsultaTitulares.ConsultaTitulares(AmUsrLog, ComPwm, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi);

                Session["lista"] = lista;
                gvPerson.DataSource = lista;
                gvPerson.DataBind();
            }
            catch (Exception ex)
            {
                GuardarExcepciones("CargarGrilla", ex.ToString());

            }

        }
       
        protected void gvPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                //
                // Se obtiene la fila seleccionada del gridview
                //
                GridViewRow row = gvPerson.SelectedRow;

                //
                // Obtengo el id de la entidad que se esta editando
                // en este caso de la entidad Person
                //
                string cod_tit = Convert.ToString(gvPerson.DataKeys[row.RowIndex].Value);

                lista = (List<modelowmspctitulares>)Session["lista"];
                foreach (var item in lista)
                {
                    if (item.cod_tit == cod_tit)
                    {
                        cliente = item;

                        break;
                    }

                }
                // Crea la variable de sessión
                Session["cliente"] = cliente;

                // Refrescamos el formuario padre
                ClientScript.RegisterClientScriptBlock(GetType(), "Refresca", "window.opener.location.reload(); window.close();", true);
            }
            catch (Exception ex)
            {
                GuardarExcepciones("gvPerson_SelectedIndexChanged", ex.ToString());

            }


        }

       

        protected void gvPerson_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                lbl_error.Text = "";

                gvPerson.PageIndex = 0;
                gvPerson.PageIndex = e.NewPageIndex;

                CargarGrilla(TxtBuscarCliente.Text);
            }
            catch (Exception ex)
            {
                GuardarExcepciones("gvPerson_PageIndexChanging", ex.ToString());

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


    }
}