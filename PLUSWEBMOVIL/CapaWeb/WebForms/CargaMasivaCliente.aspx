<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="CargaMasivaCliente.aspx.cs" Inherits="CapaWeb.WebForms.CargaMasivaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <table align="center">
              <tr>
     
                    <td colspan="4">
                        
                        <asp:Label ID="Label1" runat="server"  CssClass="Titulo" Text="Importar Clientes"></asp:Label>
                        
                        </td>
                </tr>
         </table>
     <iframe src="<%Response.Write(Modelowmspclogo.sitio_erp + "/CMClienteS.aspx"); %>" frameborder="0" allowfullscreen align="center" style="width: 821px; height: 135px; margin-left: 0px;"></iframe>
</asp:Content>
