<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="BuscarRecurso.aspx.cs" Inherits="CapaWeb.WebForms.BuscarRecurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <iframe width="1045" height="550" src="<%Response.Write(Modelowmspclogo.sitio_erp + "/cListaRecursos.aspx"); %>" frameborder="0" allowfullscreen align="center"></iframe>
    
</asp:Content>
