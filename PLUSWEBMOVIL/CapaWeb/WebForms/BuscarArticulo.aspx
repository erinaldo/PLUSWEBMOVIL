﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarArticulo.aspx.cs" Inherits="CapaWeb.WebForms.BuscarArticulo" %>
<link href="../Tema/css/modal.css" rel="stylesheet" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="tipo_contenido"  content="text/html;" http-equiv="content-type" charset="utf-8"/>
    <title></title>
</head>
<body>
 <form id="form1" runat="server">
  <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="white">
  
    <div>
         

                        <h2 class="Subtitulo1">Buscar Producto/ servicio</h2>
                        <asp:TextBox class="form-control" ID="TxtBuscarProducto" AutoPostBack="True" OnTextChanged="TxtBuscarProducto_TextChanged" placeholder="Buscar..." runat="server"  />


                       </div>
         <tr>
                    <td>

                        <hr />
                    </td>
                </tr>
                    <div>
                            <table border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#0E748A">
                                <tr>
                                    <td>

                                             <asp:GridView ID="gvProducto"  runat="server" AutoGenerateColumns="False"
                                        CellPadding="4" BackColor="#DD6D29" DataKeyNames="cod_articulo"
                                         OnPageIndexChanging="gvProducto_PageIndexChanging" AllowPaging="true" OnSelectedIndexChanged="gvProducto_SelectedIndexChanged">
                                        <RowStyle BackColor="#EFF3FB" />
                                            <Columns>
                                                <asp:BoundField  DataField="cod_articulo" ItemStyle-CssClass="textos"  HeaderText="Código" />
                                                <asp:BoundField  DataField="nom_articulo"  ItemStyle-CssClass="textos" HeaderText="Descripción" />
                                                <asp:BoundField  DataField="porc_impuesto"  ItemStyle-CssClass="textos" HeaderText="% IVA" />
                                                <asp:BoundField  DataField="precio_total" ItemStyle-CssClass="textos"  HeaderText="P.V.P" />
                                                <asp:ButtonField ButtonType="Button"  ControlStyle-CssClass="botones" ItemStyle-CssClass="textos" CommandName="Select" HeaderText="Seleccionar" ShowHeader="True" Text="Seleccionar" />
                                            </Columns>
                                              <FooterStyle BackColor="#CC0066" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#DD6D29" ForeColor="White" HorizontalAlign="Center" BorderStyle="None" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#DD6D29" Font-Bold="True" CssClass="busqueda" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle BackColor="White" />

                                        </asp:GridView> 

                                    </td>
                                </tr>
                            </table>

    
    </div>
     
      </table>
    </form>
</body>
</html>
