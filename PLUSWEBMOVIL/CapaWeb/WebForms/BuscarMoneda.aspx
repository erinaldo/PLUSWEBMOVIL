<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="BuscarMoneda.aspx.cs" Inherits="CapaWeb.WebForms.BuscarMoneda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <iframe width="800" height="550" src="<%Response.Write(Modelowmspclogo.sitio_erp + "/aListaMoneda.aspx"); %>" frameborder="0" allowfullscreen align="center"></iframe>

</asp:Content>
