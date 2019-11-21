<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="BuscarSectorVenta.aspx.cs" Inherits="CapaWeb.WebForms.BuscarSectorVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <iframe width="1200" height="550" src="<%Response.Write(Modelowmspclogo.sitio_erp + "/vListaSectoresVenta.aspx"); %>" frameborder="0" allowfullscreen align="center"></iframe>
</asp:Content>
