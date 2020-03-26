<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarCliente.aspx.cs" Inherits="CapaWeb.WebForms.BuscarCliente" %>

<link href="../Tema/css/modal.css" rel="stylesheet" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="white">
       <tr>
           <td colspan="4">
            
               <asp:Label ID="Label1" runat="server" class="Subtitulo1"  Text="Label">Buscar Cliente</asp:Label>
                
              </td>
            <td colspan="4">
                <asp:TextBox  size="40" maxlength="50" class="texto"  ID="TxtBuscarCliente" AutoPostBack="True"  OnTextChanged="TxtBuscarCliente_TextChanged" placeholder="Identificación/ Nombre" runat="server" />
           </tr>
        <tr>

        </tr>
          <tr>
                    <td>
                        <asp:Label ID="lbl_error" runat="server"  class="textos_error" Text=""></asp:Label>
                        
                        </td>
                    </tr>   
                <tr>
                  <br />
                    <br />  
         
       
                   

                        <table border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#0E748A">
                            <tr>
                                <td>

                                     <asp:DataGrid ID="gvPerson" runat="server" onrowcreated="GriTipoUsuario_RowCreated"
                                        onrowcommand="GriTipoUsuario_RowCommand"
                                        AutoGenerateColumns="False" AllowPaging="True" class="table table-hover"
                                        OnItemCommand="Grid_ItemCommand" AllowSorting="True" ShowFooter="True"
                                        OnPageIndexChanged="Grid_PageIndexChanged" PageSize="9" CellPadding="2"  BackColor="White" BorderColor="#DD6D29" BorderStyle="None" BorderWidth="0px" CellSpacing="1">


                                        <Columns>

                                             <asp:TemplateColumn HeaderText="COD_TIT" Visible="false" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="cod_tit" class="textos" runat="server" Text='<%#Eval("cod_tit") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="SUCURSAL" Visible="false" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="cod_sucursal" class="textos" runat="server" Text='<%#Eval("cod_sucursal") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                             <asp:TemplateColumn HeaderText="SUCURSAL"  >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="codnom_suc" class="textos" runat="server" Text='<%#Eval("codnom_suc") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="CLIENTE">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="nom_tit" runat="server" class="textos" Text='<%#Eval("nom_tit") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="CÉDULA">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        
                                                        <asp:Label ID="nro_dgi2"  class="textos" runat="server" Text='<%#Eval("nro_dgi2") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="CIUDAD">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="ciu_sucursal" runat="server" class="textos" Text='<%#Eval("nom_ciudad") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateColumn>

                                            <asp:ButtonColumn ButtonType="PushButton" CommandName="Select"  Text="Seleccionar" ItemStyle-CssClass="botones"></asp:ButtonColumn>
                                            
                                         </Columns>


                                        <FooterStyle BackColor="White" ForeColor="#00000f" />
                                        <HeaderStyle BackColor="#DD6D29" CssClass="busqueda" Font-Bold="True" ForeColor="White" />
                                        <ItemStyle ForeColor="#00000f" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />


                                    </asp:DataGrid>
                                </td>
                            </tr>
                        </table>
         
           </tr>
                              
    </table>
        </form>
      
</body>
</html>
