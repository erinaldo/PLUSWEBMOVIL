<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="BuscarVendedor.aspx.cs" Inherits="CapaWeb.WebForms.BuscarVendedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <iframe width="1200" height="550" src="<%Response.Write(Modelowmspclogo.sitio_erp + "/vListaVendedor.aspx"); %>" frameborder="0" allowfullscreen align="center"></iframe>
</asp:Content>
