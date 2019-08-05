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
               </td>
               </tr>
              <tr>
               <td class="busqueda">
                     <asp:Label ID="Label1" class="busqueda" runat="server" Text="Label">Total  Pago:</asp:Label></td>
               <td>
                   <asp:TextBox ID="txt_total_pago" ReadOnly="true" CssClass="textos" runat="server"></asp:TextBox>
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
                   <asp:TextBox ID="txt_Descripcion" Visible="false" CssClass="textos" Size="30" runat="server"></asp:TextBox>
                   

               </td>
               <td>
                     <asp:TextBox ID="txt_Banco" Visible="false" CssClass="textos" Size="30" runat="server"></asp:TextBox>
               </td>
               <td>
                   <asp:TextBox ID="txt_Precio" Visible="false" CssClass="textos" type="number" step="0.01" value="0" size="20" runat="server"></asp:TextBox>

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

                      <asp:GridView ID="gvProducto" runat="server" AutoGenerateColumns="False"
                          CellPadding="4" BackColor="#DD6D29" DataKeyNames="cod_articulo">

                          <RowStyle BackColor="#EFF3FB" />
                          <Columns>
                              <asp:BoundField DataField="observacion" HeaderText="Medio Pago" />
                              <asp:BoundField DataField="cliente" HeaderText="Cliente" />
                              <asp:BoundField DataField="mumero" HeaderText="Número" />
                              <asp:BoundField DataField="valor" HeaderText="Valor" />
                              <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="botones" CommandName="Select" HeaderText="Seleccionar" ShowHeader="True" Text="Seleccionar" />
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
