﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarFacturasNC.aspx.cs" Inherits="CapaWeb.WebForms.BuscarFacturasNC" %>

<link href="../Tema/css/StylePront.css" rel="stylesheet" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" name="form1" class="forms-sample" runat="server" method="post">
         <div style="align-items: left">
            <table  width="95%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="white">
       <tr>
                    
                   
                      <tr>
                    <td colspan="4">

                         <hr />
                    </td>
                </tr>
        
                 <tr>
                     <td colspan="4">
                        <asp:Label ID="lbl_error" runat="server"  class="textos_error" Text=""></asp:Label>
                        
                        </td>
                    </tr>
                 <tr>
                     <td >
                        <asp:Label ID="Label1" runat="server"  class="busqueda" Text="Busqueda por: "></asp:Label>
                        </td>
                     <td>
                              <asp:DropDownList ID="cbx_tipo_filtro" OnSelectedIndexChanged="cbx_tipo_filtro_SelectedIndexChanged" AutoPostBack="true" class="textos" runat="server" Height="16px" Width="204px">
                                  <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                  <asp:ListItem Value="FEC">FECHA</asp:ListItem>
                                  <asp:ListItem Value="NRO">NRO DOCUMENTO</asp:ListItem>
                              </asp:DropDownList>
                          </td>

                    </tr>
   <tr>
                    <td>
                        <asp:Label ID="lbl_fec_ini" CssClass="busqueda" Visible="false" runat="server" Text="Fecha inicio:"></asp:Label>
                    </td>
                          <td>
                             <asp:TextBox ID="fechainicio" type="date" Visible="false"  Width="220px" required="required"   runat="server"></asp:TextBox>
                              </td>
                             <td >
                                 <asp:Label ID="lbl_fecha_fin" CssClass="busqueda" Visible="false" runat="server" Text="Fecha fin:"></asp:Label>
                             </td>
                          <td>
                              <asp:TextBox ID="fechafin" type="date" Visible="false" Width="202" required="required"   runat="server"></asp:TextBox>
                          </td>
                </tr>
              
              
                <tr>
                    <td>
                        <asp:Label ID="lbl_doc" Visible="false" runat="server" CssClass="busqueda" Text="Documento:"></asp:Label>
                    </td>
                                        
                             <td>
                            <asp:TextBox ID="txtDocumento" class="textos" Visible="false" width="215" value="" required="required"  runat="server"></asp:TextBox>
                           
                     <td> </td>
                            <td aling="rigth"><asp:Button ID="btn_buscar" runat="server" Visible="false" onclick="btn_buscar_Click" class="botones" Text="Buscar" /></td>

                </tr>
               <tr>
                    <td colspan="4">

                         <hr />
                    </td>
                </tr>
                 <tr>
                    <td>

                        <div class="Subtitulo1">Listado de Facturas</div>
                    </td>
                </tr>
                        <tr>
                     <td colspan="4">
                        <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#0E748A">
                            <tr>
                                <td>
                                                                  
                                    <asp:DataGrid ID="Grid" runat="server" onrowcreated="GriTipoUsuario_RowCreated"
                                        onrowcommand="GriTipoUsuario_RowCommand"
                                        AutoGenerateColumns="False" AllowPaging="True" class="table table-hover"
                                        OnItemCommand="Grid_ItemCommand" AllowSorting="True" ShowFooter="True"
                                        OnPageIndexChanged="Grid_PageIndexChanged" PageSize="100" CellPadding="2"  BackColor="White" BorderColor="#DD6D29" BorderStyle="None" BorderWidth="0px" CellSpacing="1">


                                        <Columns>


                                            <asp:TemplateColumn HeaderText="TRX" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="nro_trans" class="textos" runat="server" Text='<%#Eval("nro_trans") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            

                                            <asp:TemplateColumn HeaderText="FECHA">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        
                                                        <asp:Label ID="fec_doc" Type="date" class="textos" runat="server" Text='<%#Eval("fec_doc_str") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="DOCUMENTO">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="descripcion" runat="server" class="textos" Text='<%#Eval("observacion") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                            </asp:TemplateColumn>

                                           
                                             <asp:TemplateColumn HeaderText="TOTAL">
                                                <ItemTemplate>
                                                    <span style="float: right;">
                                                        <asp:Label ID="total"  runat="server" class="textos" Text='<%#Eval("total", "{0:N}") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="SALDO">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="saldo" runat="server" class="textos" Text='<%#Eval("saldo", "{0:N}") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                                                                  
                                            <asp:ButtonColumn ButtonType="PushButton" ItemStyle-CssClass="botones" CommandName="Select" Text="Seleccionar"></asp:ButtonColumn>
                                        </Columns>


                                        <FooterStyle BackColor="White" ForeColor="#00000f" />
                                        <HeaderStyle BackColor="#DD6D29" Font-Bold="True" CssClass="busqueda" ForeColor="White" />
                                        <ItemStyle ForeColor="#00000f" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />


                                    </asp:DataGrid>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>


                     
                </table>
                    </div>
                  </form>
</body>
</html>
