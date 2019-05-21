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
<p><a href="javascript:abrir_ventana_total('tu_pagina')">esto abre una ventana al 100%</a><asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="QR" />
    <asp:Button ID="Button1" target="_blank" runat="server" OnClick="Button1_Click"  Text="PDF" />
    </p>
</form>
</asp:Content>
