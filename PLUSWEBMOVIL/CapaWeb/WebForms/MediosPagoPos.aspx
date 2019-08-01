<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MediosPagoPos.aspx.cs" Inherits="CapaWeb.WebForms.MediosPagoPos" %>
<link href="../Tema/css/modal.css" rel="stylesheet" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="white">
  
                
                       

       <table border="0" id="MostrarOpciones" align="center" >
           <tr valign="center" >
               <td align="center" nowrap="nowrap" colspan="3" >
                      <h2 class="textos">Medios de Pago</h2>
               </td>
               </tr>

                <tr>
                                 <td class="busqueda">
                                    <asp:Label ID="lblMedio" class="busqueda" runat="server" Text="Label">Medio de Pago</asp:Label></td>
                                
                                 <td class="busqueda">
                                    <asp:Label ID="lblDes" class="busqueda" runat="server" Text="Label">N Tarjeta/N Cheque</asp:Label></td>
                                 <td class="busqueda">
                                    <asp:Label ID="lblBanco" class="busqueda" runat="server" Text="Label">Banco</asp:Label></td>
                                 <td class="busqueda">
                                    <asp:Label ID="lblPre" class="busqueda" runat="server" Text="Label">Monto</asp:Label></td>
                                 
                                 
                                
                            </tr>
                            <tr>
                               <td>
                                    <asp:DropDownList ID="cbx_medios" runat="server" CssClass="textos"></asp:DropDownList>    
                                </td>
                                <td >
                                    <asp:TextBox ID="txt_Descripcion" CssClass="textos" Size="30"  runat="server"></asp:TextBox>
                                 </td>
                                
                                <td>
                                    <asp:TextBox ID="txt_Banco" CssClass="textos" Size="30"  runat="server"></asp:TextBox>
                                    
                                </td>
                                 <td>
                                    <asp:TextBox ID="txt_Precio" CssClass="textos" type="number"   step="0.01" value="0" size="20" runat="server"></asp:TextBox>
                                    
                                </td>
                                 
                                 
                                <td>
                                    <asp:Button ID="AgregarNC" runat="server"  CssClass="botones" Text="Agregar" />
                                </td>
                            </tr>
                   </table>
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
                                        CellPadding="4" BackColor="#DD6D29" DataKeyNames="cod_articulo">
                                        
                                        <RowStyle BackColor="#EFF3FB" />
                                            <Columns>
                                                <asp:BoundField  DataField="cod_articulo"  HeaderText="Código" />
                                                <asp:BoundField  DataField="nom_articulo"  HeaderText="Descripción" />
                                                <asp:BoundField  DataField="porc_impuesto" HeaderText="% IVA" />
                                                <asp:BoundField  DataField="precio_total"  HeaderText="P.V.P" />
                                                <asp:ButtonField ButtonType="Button"  ControlStyle-CssClass="botones" CommandName="Select" HeaderText="Seleccionar" ShowHeader="True" Text="Seleccionar" />
                                            </Columns>
                                              <FooterStyle BackColor="#CC0066" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#DD6D29" ForeColor="White" HorizontalAlign="Center" BorderStyle="None" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#DD6D29" Font-Bold="True" ForeColor="White" />
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
