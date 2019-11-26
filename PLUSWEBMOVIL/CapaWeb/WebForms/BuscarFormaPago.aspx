<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="BuscarFormaPago.aspx.cs" Inherits="CapaWeb.WebForms.BuscarFormaPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <iframe width="1000" height="550" src="<%Response.Write(Modelowmspclogo.sitio_erp + "/mListaTerminosPago.aspx"); %>" frameborder="0" allowfullscreen align="center"></iframe>
</asp:Content>
