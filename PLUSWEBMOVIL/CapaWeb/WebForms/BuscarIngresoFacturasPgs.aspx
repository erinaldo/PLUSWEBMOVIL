<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarIngresoFacturasPgs.aspx.cs" Inherits="CapaWeb.WebForms.BuscarIngresoFacturasPgs" %>

<!DOCTYPE html>
<link href="../Tema/css/modal.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
    <div>
     <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="white">
  
    <div  align="center">
         

                        <h2  class="Titulo">INGRESOS POR FACTURAS</h2>
                        


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
                                         <asp:DataGrid ID="Grid" runat="server" onrowcreated="GriTipoUsuario_RowCreated"
                                        onrowcommand="GriTipoUsuario_RowCommand"
                                        AutoGenerateColumns="False" AllowPaging="True" class="table table-hover"
                                        OnItemCommand="Grid_ItemCommand" AllowSorting="True" ShowFooter="True"
                                        OnPageIndexChanged="Grid_PageIndexChanged" PageSize="9" CellPadding="2"  BackColor="White" BorderColor="#DD6D29" BorderStyle="None" BorderWidth="0px" CellSpacing="1">
                                        <Columns>
                                              <asp:TemplateColumn HeaderText="TRX"  >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="nro_trans" runat="server" Text='<%#Eval("nro_trans") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                             <asp:TemplateColumn HeaderText="TRX" visible="false" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="cod_docum" runat="server" Text='<%#Eval("cod_docum") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                             <asp:TemplateColumn HeaderText="TRX" visible="false" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="nro_docum" runat="server" Text='<%#Eval("nro_docum") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                             <asp:TemplateColumn HeaderText="TRX" visible="false" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="serie_docum" runat="server" Text='<%#Eval("serie_docum") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="TRX" visible="false" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="cod_tit" runat="server" Text='<%#Eval("cod_tit") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="CLIENTE" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="razon_social" runat="server" Text='<%#Eval("razon_social") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="FECHA">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="fec_doc" runat="server" Text='<%#Eval("fec_doc") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="DOCUMENTO">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="documento" runat="server" Text='<%#Eval("documento") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>  
                                               
                                              <asp:TemplateColumn HeaderText="TOTAL">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="total" runat="server" Text='<%#Eval("total", "{0:N}") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>      
                                            
                                             <asp:TemplateColumn HeaderText="EFECTIVO">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="efectivo" runat="server" Text='<%#Eval("efectivo", "{0:N}") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>                          

                                        

                                            <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgEliminar" runat="server" CausesValidation="false" CommandName="Mostrar"
                                                        ImageUrl="~/Tema/imagenes/search.png" ToolTip="Eliminar" Width="16" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                        </Columns>
                                        
                                        <FooterStyle BackColor="White" ForeColor="#00000f" />
                                        <HeaderStyle BackColor="#DD6D29" Font-Bold="True" ForeColor="White" />
                                        <ItemStyle ForeColor="#00000f" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    </asp:DataGrid>

                                    

                                    </td>
                                </tr>
                            </table>

    
    </div>
     
      </table>
        <tr>
                    <td>

                         <hr />
                    </td>
                </tr>
         <table style="width: 100%; text-align: right;">
                               <tr >
      
                                <td valing="right" colspan="4">
                                    
                                        <asp:Label ID="Label2" runat="server" CssClass="busqueda" Text="TOTALES:"></asp:Label>
                                     
                                    <asp:TextBox ID="txt_total_facturas"  CssClass="textos"  ReadOnly ="true" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="txt_total_efectivo" CssClass="textos" ReadOnly ="true" runat="server"></asp:TextBox>
                                    
                                </td>
                    
                            </tr>
                        </table>
               <tr>
                    <td>

                         <hr />
                    </td>
                </tr>
    </div>
          <table>
                               <tr>
       
                                <td >
                                    <asp:Button ID="Cancelar" Class="botones"  runat="server" onclick="Cancelar_Click" UseSubmitBehavior="False" Text="Cancelar" />
                                    
                                </td>
                    
                            </tr>
                        </table>
    </form>
</body>
</html>
