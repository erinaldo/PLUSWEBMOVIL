<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="BuscarCentroCosto.aspx.cs" Inherits="CapaWeb.WebForms.BuscarCentroCosto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <iframe width="1000" height="550" src="<%Response.Write(Modelowmspclogo.sitio_erp + "/cListaCentroCostos.aspx"); %>" frameborder="0" allowfullscreen align="center"></iframe>
</asp:Content>
