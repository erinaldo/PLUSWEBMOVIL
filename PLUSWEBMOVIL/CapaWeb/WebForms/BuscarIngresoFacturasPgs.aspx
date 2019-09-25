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
         

                        <h2  class="Subtitulo1">INGRESOS POR FACTURAS</h2>
                        


                       </div>
          <tr>
                    <td>
                        <asp:Label ID="lbl_error" runat="server"  class="textos_error" Text=""></asp:Label>
                        
                        </td>
                    </tr>
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
                                        CellPadding="4" BackColor="#DD6D29"  OnItemCommand="Grid_ItemCommand" DataKeyNames="nro_trans" 
                                         OnPageIndexChanging="gvProducto_PageIndexChanging" AllowPaging="True" PageSize="20" OnLoad="gvProducto_DataBound" OnSelectedIndexChanged="gvProducto_SelectedIndexChanged" ShowFooter="True" >
                                        <RowStyle BackColor="#EFF3FB" />
                                            <Columns>
                                                <asp:BoundField  DataField="nro_trans"  ItemStyle-CssClass="textos" HeaderText="TRX" >
<ItemStyle CssClass="textos"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField  DataField="nom_tit" ItemStyle-CssClass="textos" HeaderText="CLIENTE"  >
<ItemStyle CssClass="textos"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField  DataField="fec_st" ItemStyle-CssClass="textos" HeaderText="FECHA"   >
<ItemStyle CssClass="textos"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField  DataField="documento" ItemStyle-CssClass="textos" HeaderText="DOCUMENTO"   >
                                                <FooterStyle ForeColor="#D55500" CssClass="busqueda" />

<ItemStyle CssClass="textos"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField  DataField="total" ItemStyle-CssClass="textos"  HeaderText="TOTAL" DataFormatString="{0:N}" >
                                                <ControlStyle CssClass="textos" />
                                                <FooterStyle ForeColor="Black" CssClass="textos" />

<ItemStyle CssClass="textos"></ItemStyle>
                                                </asp:BoundField>

                                                 <asp:ButtonField ButtonType="Image"  ControlStyle-CssClass="botones" CommandName="Select" ShowHeader="True"   ImageUrl="~/Tema/imagenes/search.png" >
                                                <ControlStyle CssClass="botones"></ControlStyle>
                                                </asp:ButtonField>
                                               
                                                
                                            </Columns>
                                              <FooterStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#DD6D29" ForeColor="White" HorizontalAlign="Center" BorderStyle="None" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#DD6D29" Font-Bold="True" ForeColor="White" CssClass="busqueda" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle BackColor="White" />

                                        </asp:GridView> 

                                    

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
