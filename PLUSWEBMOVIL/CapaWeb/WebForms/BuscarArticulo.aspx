<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarArticulo.aspx.cs" Inherits="CapaWeb.WebForms.BuscarArticulo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
  <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="white">
    <form id="form1" runat="server">
    <div>
         

                        <h2 class="textos">Buscar Producto/ servicio</h2>
                        <asp:TextBox class="form-control" ID="TxtBuscarProducto" AutoPostBack="True" OnTextChanged="TxtBuscarProducto_TextChanged" placeholder="Buscar..." runat="server"  />


                       </div>
        </br>
        </br>
                    <div >
                            <table border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#0E748A">
                                <tr>
                                    <td>

                                        <asp:DataGrid ID="Grid" runat="server" AutoGenerateColumns="False" AllowSorting="True" PageSize="4" AllowPaging="True">
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="Codigo" Visible="False">
                                                    <ItemTemplate>
                                                        <span style="float: left;">
                                                            <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>

                                                <asp:TemplateColumn HeaderText="Codigo">
                                                    <ItemTemplate>
                                                        <span style="float: left;">
                                                            <asp:Label ID="cod_articulo" class="textos" runat="server" Text='<%#Eval("cod_articulo") %>'></asp:Label>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>

                                                <asp:TemplateColumn HeaderText="Descripción">
                                                    <ItemTemplate>
                                                        <span style="float: left;">
                                                            <asp:Label ID="nom_articulo" runat="server" class="textos" Text='<%#Eval("nom_articulo") %>'></asp:Label>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>

                                                <asp:TemplateColumn HeaderText="%IVA">
                                                    <ItemTemplate>
                                                        <span style="float: left;">
                                                            <asp:Label ID="porc_impuesto" runat="server" class="textos" Text='<%#Eval("porc_impuesto") %>'></asp:Label>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>

                                                <asp:TemplateColumn HeaderText="P.V.P">
                                                    <ItemTemplate>
                                                        <span style="float: left;">
                                                            <asp:Label ID="precio" runat="server" class="textos" Text='<%#Eval("precio") %>'></asp:Label>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>

                                                <asp:TemplateColumn HeaderText="I.V.A">
                                                    <ItemTemplate>
                                                        <span style="float: left;">
                                                            <asp:Label ID="valor_impu" runat="server" class="textos" Text='<%#Eval("valor_impu") %>'></asp:Label>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>

                                                <asp:TemplateColumn HeaderText="Total">
                                                    <ItemTemplate>
                                                        <span style="float: left;">
                                                            <asp:Label ID="precio_total" runat="server" class="textos" Text='<%#Eval("precio_total") %>'></asp:Label>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>


                                                <asp:TemplateColumn>
                                                    <ItemTemplate>
                                                        <asp:Button ID="Button1" runat="server" toolping="Seleccionar" Class="botones" Text="Seleccionar" />


                                                    </ItemTemplate>
                                                </asp:TemplateColumn>

                                            </Columns>


                                            <FooterStyle BackColor="White" ForeColor="#00000f" />
                                            <HeaderStyle BackColor="#DD6D29" Font-Bold="True" ForeColor="#FFFFFF" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                            <ItemStyle ForeColor="#000000" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                                            <SelectedItemStyle BackColor="#0E748A" Font-Bold="True" ForeColor="White" />


                                        </asp:DataGrid>


                                    </td>
                                </tr>
                            </table>

    
    </div>
    </form>
</body>
</html>
