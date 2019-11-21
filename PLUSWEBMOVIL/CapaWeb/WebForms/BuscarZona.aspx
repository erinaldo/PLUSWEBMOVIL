<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="BuscarZona.aspx.cs" Inherits="CapaWeb.WebForms.BuscarZona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <iframe width="1000" height="550" src="<%Response.Write(Modelowmspclogo.sitio_erp + "/xListaZona.aspx"); %>" frameborder="0" allowfullscreen align="center"></iframe>

</asp:Content>
