<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DescuentosCargosFac.aspx.cs" Inherits="CapaWeb.WebForms.DescuentosCargosFac" %>
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
               <td align="center" nowrap="nowrap" colspan="7" >
                      <h2 class="Subtitulo1">Descuentos y Recargos</h2>
               </td>
               </tr>
           <tr valign="center" >
               <td align="center" nowrap="nowrap" colspan="3" >
                   <asp:Label ID="lbl_error" CssClass="textos_error" runat="server" Text=""></asp:Label>
               </td>
               </tr>
           <tr>
               
               
               <td class="busqueda">
                     <asp:Label ID="Label3" Visible="false" class="busqueda" runat="server" Text="Label">TRX:</asp:Label></td>
               <td>
                   <asp:TextBox ID="txt_nro_trans" Visible="false"  ReadOnly="true" CssClass="textos" runat="server"></asp:TextBox>
               </td>
               </tr>
     
             
          
           <tr>
               <td colspan="4">
                   <asp:Label ID="Label4" class="Subtitulo1" runat="server" Text="Label">Seleccione la forma de calculo que desea agregar:</asp:Label>

               </td>
            

           </tr>
               <tr>
               <td colspan="2">
                  

                   <br />
                  

               </td>
            

           </tr>
            <tr>
               <td colspan="2">
                   <asp:Label ID="lbl_mensaje" class="textos" runat="server" Text=""></asp:Label>
                   
               </td>

           </tr>
            
               
           <tr>
              
               
               <td>
                   <asp:Button ID="Agregar_Tipo" onclick="Agregar_Tipo_Click" Visible="false" runat="server" CssClass="botones" Text="Aceptar" />
               </td>
               <td><asp:Label ID="lbl_linea" Visible="false" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                    <td class="busqueda">
                        <asp:Label ID="lbl_concepto"  class="busqueda" runat="server" Text="Label">Concepto</asp:Label></td>
                 
                <td class="busqueda">
                        <asp:Label ID="lbl_tipo_cal"  class="busqueda" runat="server" Text="Label">Tipo Calculo</asp:Label></td>
                    <td class="busqueda">
                        <asp:Label ID="lbl_porc" Visible="false" class="busqueda" runat="server" Text="Label">Porcentaje</asp:Label></td>
                    <td class="busqueda">
                        <asp:Label ID="lbl_valor" Visible="false" class="busqueda" runat="server" Text="Label">Valor Desct</asp:Label></td>
                <td class="busqueda">
                     <asp:Label ID="lbl_monto_imp" Visible="false" class="busqueda" runat="server" Text="Label">Base Imponible</asp:Label></td>
                    
                </tr>
           <tr>
               
               <td>
                   <asp:DropDownList ID="cbx_concepto"  CssClass="textos" OnSelectedIndexChanged="cbx_concepto_SelectedIndexChanged" AutoPostBack="true"  runat="server"></asp:DropDownList>
                    
               </td>
              
                <td>
                    <asp:DropDownList ID="cbx_tipo" class="textos" runat="server" Height="16px" Width="204px" AutoPostBack="true"  OnSelectedIndexChanged="cbx_tipo_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>          
                        <asp:ListItem Value="V">VALOR</asp:ListItem>
                                  <asp:ListItem Value="D">PORCENTAJE</asp:ListItem>
                              </asp:DropDownList>
               </td>
                <td>
                   <asp:TextBox ID="txt_porc_desc" Visible="false" CssClass="textos" type="number" step="0.001" value="0" size="20" runat="server"></asp:TextBox>

               </td>
               <td>
                   <asp:TextBox ID="txt_valor" Visible="false"  AutoPostBack="True" CssClass="textos"  value="0" size="20" runat="server" OnTextChanged="txt_valor_TextChanged"></asp:TextBox>

               </td>
               <td>
                   <asp:TextBox ID="txt_total_factura" Visible="false" AutoPostBack="True" value="0" CssClass="textos" runat="server" OnTextChanged="txt_total_factura_TextChanged"></asp:TextBox>
               </td>

               <td>
                   <asp:Button ID="AgregarPago" Visible="false" onclick="AgregarPago_Click" runat="server" CssClass="botones" Text="Agregar" />
               </td>
           </tr>
           <tr>
                <td>
                   <asp:Label ID="lbl_signo" Visible="false" CssClass="textos"  runat="server"></asp:Label>

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
                        <asp:DataGrid ID="gv_Producto" runat="server" 
                                        
                                        AutoGenerateColumns="False" AllowPaging="True" class="table table-hover"
                                         AllowSorting="True" ShowFooter="True"
                                          CellPadding="2"  BackColor="White" BorderColor="#DD6D29" BorderStyle="None" BorderWidth="0px" CellSpacing="1" OnItemCommand="gv_Producto_ItemCommand">


                                        <Columns>
                                            <asp:TemplateColumn HeaderText="Medio Pago" Visible="false" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="linea"  Visible="false" runat="server" class="textos" Text='<%#Eval("linea") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Concepto" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="concepto" runat="server" class="textos" Text='<%#Eval("nomcod") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="% Desct">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="porcentaje" runat="server" class="textos" Text='<%#Eval("porcen_desc") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="Valor Desct">
                                                <ItemTemplate>
                                                    <span style="float: right;">
                                                        <asp:Label ID="valor" runat="server" class="textos" Text='<%#Eval("valor_descuento") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="Total">
                                                <ItemTemplate>
                                                    <span style="float: right;">
                                                        <asp:Label ID="total" runat="server" class="textos" Text='<%#Eval("total_for") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandName="Editar"
                                                        ImageUrl="~/Tema/imagenes/edit.png" ToolTip="Editar" Width="16" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgEliminar" runat="server" CausesValidation="false" CommandName="Eliminar"
                                                        ImageUrl="~/Tema/imagenes/trash.png" ToolTip="Eliminar" Width="16" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                                                                                                                    
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
          <table  align="center" >
                <tr  >
                <td  class="busqueda">
                     <asp:Label ID="lbl_tot_des" class="busqueda" runat="server" Text="">Total Descuento:</asp:Label></td>
               <td>
                   <asp:TextBox ID="txt_tot_des" ReadOnly="true" CssClass="textos" runat="server"></asp:TextBox>
               </td>
               <td class="busqueda">
                     <asp:Label ID="lbl_tot_cargo" class="busqueda" runat="server" Text="Label">Total Cargo :</asp:Label></td>
               <td>
                   <asp:TextBox ID="txt_tot_cargo" ReadOnly="true" CssClass="textos" runat="server"></asp:TextBox>
               </td>
           </tr>
          </table>


      </div>
            <tr>
          <td>

              <hr />
          </td>
      </tr>
         <tr>
                    <td>
                        <table>
                               <tr>
                                
                                <td >
                                    <asp:Button ID="Cancelar" Class="botones"  runat="server" OnClick="Cancelar_Click"  UseSubmitBehavior="False" Text="Cancelar" />
                                       
                                    <asp:Button ID="Button1" Class="botones"  runat="server" OnClick="Cancelar_Click"  UseSubmitBehavior="False" Text="Confirmar" />                              
                               
                                  </td>
                    
                            </tr>
                        </table>
                    </td>
                </tr>
  </table>
    </form>
</body>
</html>
