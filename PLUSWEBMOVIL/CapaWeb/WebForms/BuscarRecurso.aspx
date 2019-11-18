<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="BuscarRecurso.aspx.cs" Inherits="CapaWeb.WebForms.BuscarRecurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <iframe width="845" height="700" src="<%Response.Write(Modelowmspclogo.sitio_erp + "/cListaRecursos.aspx"); %>" frameborder="0" allowfullscreen></iframe>
</asp:Content>
