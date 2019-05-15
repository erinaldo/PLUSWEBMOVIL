<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="prueba.aspx.cs" Inherits="CapaWeb.WebForms.prueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<script >
function abrir_ventana_total(x) {
	y = screen.availWidth;
	z = screen.availHeight;
	var ventana = window.open(x+".htm", x, "width="+y+", height="+z+", status=no, scrollbars=no, toolbars=no, menubar=no");
	ventana.moveTo(0,0);
}

</script>
<form runat="server">
<p><a href="javascript:abrir_ventana_total('tu_pagina')">esto abre una ventana al 100%</a></p>
 <asp:Button runat="server" ID="btoSelec"  Text="Selecionar"  OnClientClick="window.open('./SelecBandera.aspx','MiPagina', 'top=300,width=650 ,height=210, left=350, status=no, scrollbars=no, toolbars=no, menubar=no');" />
</form>
</asp:Content>
