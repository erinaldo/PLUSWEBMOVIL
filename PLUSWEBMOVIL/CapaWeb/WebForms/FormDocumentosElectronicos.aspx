﻿<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="FormDocumentosElectronicos.aspx.cs" Inherits="CapaWeb.WebForms.FormDocumentosElectronicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <form id="form1" name="form1" class="forms-sample" runat="server" method="post">
         <div style="align-items: left">
            <table>
                 <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0">
                                <tr>
                                    <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;Documentos Electrónicos</td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                <tr>
                    <td>
                        <asp:ImageButton ID="ImgAyuda"  runat="server" src="../Tema/imagenes/help.png" width="16" height="16" />
                        <asp:Label ID="lblAyuda" runat="server"  CssClass="Titulo" Text="Envío Documentos Electrónicos"></asp:Label>
                        
                        </td>
                    </tr>
               
                 <tr>
                    <td>
                        <asp:Label ID="txtAcceso" runat="server" Visible="false" CssClass="Titulo" Text="El Usuario registrado no tiene permiso para ejecutar estos procesos"></asp:Label>
                        
                        </td>
                    </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lbl_error" runat="server"  class="textos_error" Text=""></asp:Label>
                        
                        </td>
                    </tr>
                 <tr>
                    <td >
                        <asp:Label ID="lbl_mensaje" runat="server"  CssClass="textos_error" Text=""></asp:Label>
                        
                        </td>
                    </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server"  CssClass="Subtitulo2" Text="Sucursal: "></asp:Label>
                        <asp:Label ID="lbl_cod_suc" runat="server"  CssClass="Subtitulo2" Text=""></asp:Label>
                        <asp:Label ID="lbl_sucursal" runat="server"  CssClass="Subtitulo2" Text=""></asp:Label>
                        
                        </td>
                    </tr>
                <tr>
                    <td>
                         <p class="Subtitulo1">Busque el registro deseado por:</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                         
                      <table align="center">
                        <tr >
                          <td width="20%" class="busqueda">Cliente:</td>
                          <td>
                              <asp:TextBox ID="txtCliente" class="textos" value="0" width="203" runat="server" maxlength="50" ></asp:TextBox>
                              
                              <div class="textos_sm">Codigo, Nombre, NIT (0 = Todos)</div></td>
                             <td width="20%" class="busqueda">Prefijo:</td>
                          <td>
                              <asp:TextBox ID="txtSerie"  class="textos" value="xxx" width="203" runat="server"></asp:TextBox>
                          <div class="textos_sm">xxx = Todos</div></td>
                           <td class="busqueda">Documento:</td>
                             <td>
                            <asp:TextBox ID="txtDocumento" class="textos" width="215" value="0" runat="server"></asp:TextBox>
                          <div class="textos_sm">0 = Todos</div></td> 
                        </tr>
                         
                        
                        
                        <tr valign="top">
                         <td width="20%" class="busqueda">Fecha inicio:</td>
                          <td>
                                <asp:TextBox ID="fechainicio" type="date"  Width="202"   runat="server"></asp:TextBox>
                            </td>
                            <td width="20%" class="busqueda">Fecha fin:</td>
                          <td>
                                <asp:TextBox ID="fechafin" type="date"  Width="202"  runat="server"></asp:TextBox>
                            </td>

                           <td width="80%" class="busqueda">Tipo Documento:</td>
                          <td>
                              <asp:DropDownList ID="cbx_tipo_doc" Width="224px" class="textos" runat="server" Height="16px">
                                  <asp:ListItem Value="VTAE">Factura</asp:ListItem>
                                  <asp:ListItem Value="POSE">Factura POS</asp:ListItem>
                                  <asp:ListItem Value="NC">Nota Crédito</asp:ListItem>
                                  <asp:ListItem Value="NDVE">Nota Débito</asp:ListItem>
                              </asp:DropDownList>
                          </td>
                        </tr>
                        <tr valign="top">
                            
                            
                            <td> </td>
                            <td aling="rigth"><asp:Button ID="Buscar" runat="server" OnClick="Buscar_Click" class="botones" Text="Buscar" /></td>
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

                        <div class="Subtitulo1">Listado de Documentos</div>
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
                                        OnItemCommand="Grid_ItemCommand" AllowSorting="True" ShowFooter="True"
                                        OnPageIndexChanged="Grid_PageIndexChanged" PageSize="9" CellPadding="2"  BackColor="White" BorderColor="#DD6D29" BorderStyle="None" BorderWidth="0px" CellSpacing="1">


                                        <Columns>


                                            <asp:TemplateColumn HeaderText="TRX" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="nro_trans" class="textos" runat="server" Text='<%#Eval("nro_trans") %>'></asp:Label>
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

                                            <asp:TemplateColumn HeaderText="ESTADO">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="nom_corto" runat="server" class="textos" Text='<%#Eval("nom_corto") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                             <asp:TemplateColumn HeaderText="TOTAL">
                                                <ItemTemplate>
                                                    <span style="float: right;">
                                                        <asp:Label ID="total"  runat="server" class="textos" Text='<%#Eval("total", "{0:N}") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                         
                                        <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgReenviar" runat="server" OnClientClick="return confirm('¿Desea enviar el documento al remitente?');"  CausesValidation="false" CommandName="Reenviar"
                                                        ImageUrl="~/Tema/imagenes/mail_send.png" ToolTip="Correo Remitente" Width="20" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        

                                        <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ReenviarCorreo" runat="server" OnClientClick="return confirm('¿Desea enviar el documento al cliente?');"  CausesValidation="false" CommandName="Reenviar Cliente"
                                                        ImageUrl="~/Tema/imagenes/up.png" ToolTip="Correo Cliente" Width="16" />
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


                     
                </table>
                    </div>
                  </form>
</asp:Content>
