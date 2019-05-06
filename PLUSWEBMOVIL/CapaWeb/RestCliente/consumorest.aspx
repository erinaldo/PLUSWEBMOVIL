<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="consumorest.aspx.cs" Inherits="CapaWeb.RestCliente.consumorest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <tr>
        <td>
            <form id="form1" runat="server">
               
                    <br />
<asp:Button ID="Button1" runat="server" OnClick="generar" Text="Generar" />
                    <br />
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" Height="800px" ReadOnly="True" Rows="10" TextMode="MultiLine" Width="800px"></asp:TextBox>
                    
                
            </form>
        </td>
    </tr>
</asp:Content>
