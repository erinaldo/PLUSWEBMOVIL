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

        public string Ven__usuario = "desarrollo";
        public string Ven__cod_emp = "04";
        public string Ven__cod_tipotit = "cliente";
        public string Ven__cod_tit = " ";
        public string Ven__cod_dgi = "0";
        public string Ven__fono = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
           
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
       
        protected void TxtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            CargarGrilla(TxtBuscarCliente.Text);
        }


        private void CargarGrilla(string Ven__cod_tit)
        {
            
            lista = ConsultaTitulares.ConsultaTitulares(Ven__usuario, Ven__cod_emp, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi, Ven__fono);

            Session["lista"] = lista;
            gvPerson.DataSource = lista;
            gvPerson.DataBind();
           
        }
       
        protected void gvPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            // Se obtiene la fila seleccionada del gridview
            //
            GridViewRow row = gvPerson.SelectedRow;
            
            //
            // Obtengo el id de la entidad que se esta editando
            // en este caso de la entidad Person
            //
            string cod_tit = Convert.ToString(gvPerson.DataKeys[row.RowIndex].Value);

            lista = (List<modelowmspctitulares>) Session["lista"];
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

       

        protected void gvPerson_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPerson.PageIndex = 0;
            gvPerson.PageIndex = e.NewPageIndex;

            CargarGrilla(TxtBuscarCliente.Text);
        }

       
    }
}