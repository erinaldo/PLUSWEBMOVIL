<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="BuscarSocioNegocio.aspx.cs" Inherits="CapaWeb.WebForms.BuscarSocioNegocio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="embed-container">
    <iframe width="1245" height="1000" src="<%Response.Write(Modelowmspclogo.sitio_erp + "/cListaClientes.aspx"); %>" frameborder="0" allowfullscreen></iframe>
</div>

    
</asp:Content>
