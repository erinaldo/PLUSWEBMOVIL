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
                     <asp:Label ID="lbl_tot_fac" class="busqueda" runat="server" Text="Label">Total a Pagar:</asp:Label></td>
               <td>
                   <asp:TextBox ID="txt_total_factura" ReadOnly="true" CssClass="textos" runat="server"></asp:TextBox>
               </td>
               <td class="busqueda">
                     <asp:Label ID="Label3" class="busqueda" runat="server" Text="Label">TRX:</asp:Label></td>
               <td>
                   <asp:TextBox ID="txt_nro_trans" ReadOnly="true" CssClass="textos" runat="server"></asp:TextBox>
                     <asp:Label ID="Label1" class="busqueda" runat="server" Text="Label">Total  Pago:</asp:Label>
                   <asp:TextBox ID="txt_total_pago" ReadOnly="true" CssClass="textos" runat="server"></asp:TextBox>
               </td>
               </tr>
              <tr>
               <td class="busqueda">
                     <asp:Label ID="Label5" class="busqueda" runat="server" Text="Label">Cambio:</asp:Label></td>
               <td>
                   <asp:TextBox ID="txt_vuelto" ReadOnly="true" CssClass="textos" runat="server"></asp:TextBox>
               </td>
               <td class="busqueda">
                     <asp:Label ID="Label2" class="busqueda" runat="server" Text="Label">Diferencia:</asp:Label></td>
               <td>
                   <asp:TextBox ID="txt_Diferencia" ReadOnly="true" CssClass="textos" runat="server"></asp:TextBox>
               </td>
               </tr>
          
           <tr>
               <td colspan="2">
                   <asp:Label ID="Label4" class="Subtitulo1" runat="server" Text="Label">Seleccione la Forma de Pago que desea aplicar:</asp:Label>
                   
               </td>

           </tr>
            <tr>
               <td colspan="2">
                   <asp:Label ID="lbl_mensaje" class="textos" runat="server" Text=""></asp:Label>
                   
               </td>

           </tr>
            
               
           <tr>
               <td>
                   <asp:DropDownList ID="cbx_medios" runat="server" CssClass="textos"></asp:DropDownList>
               </td>
               
               <td>
                   <asp:Button ID="Agregar_MedioPago" OnClick="Agregar_MedioPago_Click" runat="server" CssClass="botones" Text="Aceptar" />
               </td>
            </tr>
            <tr>
                    <td class="busqueda">
                        <asp:Label ID="lblMedio" Visible="false" class="busqueda" runat="server" Text="Label">Medio de Pago</asp:Label></td>

                    <td class="busqueda">
                        <asp:Label ID="lblDes" Visible="false" class="busqueda" runat="server" Text="Label">Tercero</asp:Label></td>
                    <td class="busqueda">
                        <asp:Label ID="lblBanco" Visible="false" class="busqueda" runat="server" Text="Label">Número</asp:Label></td>
                    <td class="busqueda">
                        <asp:Label ID="lblPre" Visible="false" class="busqueda" runat="server" Text="Label">Valor</asp:Label></td>



                </tr>
           <tr>

               <td>
                   <asp:TextBox ID="txt_Descripcion" Visible="false" readonly="true" CssClass="textos" Size="30" runat="server"></asp:TextBox>
                   

               </td>
               <td>
                   <asp:DropDownList ID="cbx_tercero" Visible="false" CssClass="textos"  runat="server"></asp:DropDownList>
                    
               </td>
               <td>
                   <asp:TextBox ID="txt_numero" Visible="false" CssClass="textos" value="0" runat="server"></asp:TextBox>

               </td>
               <td>
                   <asp:TextBox ID="txt_Precio" Visible="false" CssClass="textos" type="number" step="0.01" value="0" size="20" runat="server"></asp:TextBox>

               </td>
               <td>
                   <asp:TextBox ID="txt_cal_vuelto" Visible="false" runat="server"></asp:TextBox>
               </td>

               <td>
                   <asp:Button ID="AgregarPago" Visible="false" OnClick="AgregarPago_Click" runat="server" CssClass="botones" Text="Agregar" />
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
                                                        <asp:Label ID="cod_fpago"  Visible="false" runat="server" class="textos" Text='<%#Eval("cod_fpago") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Medio Pago" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="forma_pago" runat="server" class="textos" Text='<%#Eval("forma_pago") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="Tercero">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="tercero" runat="server" class="textos" Text='<%#Eval("tercero") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="Número">
                                                <ItemTemplate>
                                                    <span style="float: right;">
                                                        <asp:Label ID="nro_docum" runat="server" class="textos" Text='<%#Eval("nro_docum") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="Valor">
                                                <ItemTemplate>
                                                    <span style="float: right;">
                                                        <asp:Label ID="recibido" runat="server" class="textos" Text='<%#Eval("recibido", "{0:N}") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
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
                                        <HeaderStyle BackColor="#DD6D29" Font-Bold="True" ForeColor="White" />
                                        <ItemStyle ForeColor="#00000f" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />


                                    </asp:DataGrid>

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
                                                                     
                               
                                  </td>
                    
                            </tr>
                        </table>
                    </td>
                </tr>
  </table>
    </form>
</body>
</html>
