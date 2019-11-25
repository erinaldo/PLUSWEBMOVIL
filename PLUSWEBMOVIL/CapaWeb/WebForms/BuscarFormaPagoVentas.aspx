<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="BuscarFormaPagoVentas.aspx.cs" Inherits="CapaWeb.WebForms.BuscarFormaPagoVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <iframe width="1000" height="550" src="<%Response.Write(Modelowmspclogo.sitio_erp + "/tListaFormaPago.aspx"); %>" frameborder="0" allowfullscreen align="center"></iframe>
</asp:Content>
