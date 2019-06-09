﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PortalFacturas.aspx.cs" Inherits="CapaWeb.WebForms.PortalFacturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <form id="form1" class="forms-sample" runat="server" method="post">
          <div style="align-items: center">
            <table>
                <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0">
                                <tr>
                                    <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;<a href="BuscarFacturas.aspx">Facturas Venta</a>---&gt;Nuevo</td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                <tr>
                    <td>
                        <p class="Subtitulo1">Lista de incidencias</p>
                    </td>
                </tr>
                <tr>
                    <td>

                        <hr />
                    </td>
                </tr>
                 <tr>
                    <td>
                        <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#0E748A">
                            <tr>
                                <td>
                                                                  
                                    <asp:DataGrid ID="Grid" runat="server" onrowcreated="GriTipoUsuario_RowCreated"
                                        onrowcommand="GriTipoUsuario_RowCommand"
                                        AutoGenerateColumns="False" AllowPaging="True" class="table table-hover"
                                         AllowSorting="True" ShowFooter="True" OnItemCommand="Grid_ItemCommand"
                                        OnPageIndexChanged="Grid_PageIndexChanged" PageSize="9" CellPadding="2"  BackColor="White" BorderColor="#DD6D29" BorderStyle="None" BorderWidth="0px" CellSpacing="1">


                                        <Columns>


                                            <asp:TemplateColumn HeaderText="TRX" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="nro_trans" runat="server" Text='<%#Eval("nro_trans") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="LINEA">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="linea" runat="server" Text='<%#Eval("linea") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                             <asp:TemplateColumn HeaderText="QRDATA">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="qrdata" runat="server" Text='<%#Eval("qrdata") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>



                                              <asp:TemplateColumn HeaderText="ERROR">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="error" runat="server" Text='<%#Eval("error") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgError" runat="server" CausesValidation="false" CommandName="Mostrar"
                                                        ImageUrl="~/Tema/imagenes/application_search.png" ToolTip="Mostrar" Width="16" />
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
                    </td>
                </tr>
                  <tr>
                    <td>
                        <table align="center" id="FormularioRes" runat="server" visible="False" >
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="mensaje" name="mensaje" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>

                            <tr valign="top">
                                <td align="right"  nowrap="nowrap" class="busqueda">
                                    <div align="left" >N° Transacción:</div>
                                </td>

                                <td class="textos">
                                    
                                    <asp:TextBox ID="txt_nro_trans"  class="textos" size="27"  ReadOnly="true" runat="server"></asp:TextBox>

                                </td>
                                 </tr>
                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Id:</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_id"  class="textos" size="27"  ReadOnly="true" runat="server"></asp:TextBox>
                                    
                                </td>
                            </tr>
                                <tr valign="top">
                                 <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Linea:</div>
                                </td>
                                <td class="textos">
                                    <asp:TextBox ID="txt_linea" class="textos" size="27"   runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr valign="top">
                                    <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Qrdata:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:TextBox ID="txt_qrdata" Width="880" class="textos"  ReadOnly="true" TextMode="MultiLine" cols="100" Rows="3" runat="server"></asp:TextBox>

                                    </label>
                                </td>
                                </tr>
                                <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Xml:</div>
                                </td>
                                <td>
                                   <asp:TextBox ID="txt_xml" Width="880" class="textos" ReadOnly="true" TextMode="MultiLine" cols="100" Rows="3"  runat="server"></asp:TextBox>

                                </td>
                               </tr>
                            
                            <tr valign="top">
                                <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div align="left">Cufe:</div>
                                </td>
                                <td valign="top">
                                    <label>
                                        <asp:TextBox ID="txt_cufe" Width="880" class="textos" ReadOnly="true" TextMode="MultiLine" cols="100" Rows="3" runat="server"></asp:TextBox>

                                    </label>
                                </td>
                                </tr>
                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Error:</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_error" Width="880" class="textos" ReadOnly="true" TextMode="MultiLine" cols="100" Rows="3" runat="server"></asp:TextBox>
                                </td>
                                </tr>
                            <tr valign="top">
                               <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Json:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:TextBox ID="txt_json" Width="880" class="textos" ReadOnly="true" TextMode="MultiLine" cols="200" Rows="10" runat="server"></asp:TextBox>
                                        
                                    </label>
                                </td>


                            </tr>

                        </table>
                    </td>
                </tr>
                       
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
                                    <asp:Button ID="Cancelar" Class="btnFactura1"  runat="server" onClick="Cancelar_Click" UseSubmitBehavior="False" Text="Cancelar" />
                                    
                                </td>
                    
                            </tr>
                        </table>
                    </td>
                </tr>
          </table>
        </div>
    </form>
</asp:Content>
