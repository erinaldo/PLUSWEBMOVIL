<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="CargaMasivaRecurso.aspx.cs" Inherits="CapaWeb.WebForms.CargaMasivaRecurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table align="center">
              <tr>
     
                    <td colspan="4">
                        
                        <asp:Label ID="Label1" runat="server"  CssClass="Titulo" Text="Importar Recursos"></asp:Label>
                        
                        </td>
                </tr>
         </table>
     <iframe src="<%Response.Write(Modelowmspclogo.sitio_erp + "/CMRecursoS.aspx"); %>" frameborder="0" allowfullscreen align="center" style="width: 821px; height: 135px; margin-left: 0px;"></iframe>
</asp:Content>
