<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="BuscarUnidadMedida.aspx.cs" Inherits="CapaWeb.WebForms.BuscarUnidadMedida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <iframe width="700" height="550" src="<%Response.Write(Modelowmspclogo.sitio_erp + "/iListaUnidadMedida.aspx"); %>" frameborder="0" allowfullscreen align="center"></iframe>
</asp:Content>
