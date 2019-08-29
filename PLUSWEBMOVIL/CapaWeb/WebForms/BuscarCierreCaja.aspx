<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="BuscarCierreCaja.aspx.cs" Inherits="CapaWeb.WebForms.BuscarCierreCaja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <form id="form1" name="form1" class="forms-sample" runat="server" method="post">
         <div style="align-items: left">
            <table>
                 <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0">
                                <tr>
                                    <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;Cierre Caja</td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                <tr>
                    <td>
                      
                        <asp:Label ID="lblAyuda" runat="server"  CssClass="Titulo" Text="Cierre de Caja Diario"></asp:Label>
                        
                        </td>
                    </tr>
                <tr>
                    <td>
                        <p class="Subtitulo2">Para realizar&nbsp; nuevo Cierre de Caja 
                                <asp:Button ID="NuevoCierre" onclick="NuevoCierre_Click"  class="botones" runat="server" Text="AQUI" />
                          </p>
                        </td>
                    </tr>
               
                
                 <tr>
                    <td>
                        <asp:Label ID="txtAcceso" runat="server" Visible="false" CssClass="Titulo" Text="El Usuario registrado no tiene permiso para ejecutar estos procesos"></asp:Label>
                        
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
                      
                         
                        
                        
                        <tr valign="top">
                         <td width="20%" class="busqueda">Fecha Cierre:</td>
                          <td>
                                <asp:TextBox ID="fechainicio" type="date"  Width="202"   runat="server"></asp:TextBox>
                            </td>
                           

                             <td aling="rigth">
                                 <asp:Button ID="Buscar" runat="server" onclick="Buscar_Click" class="botones" Text="Buscar" /></td>
                            
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

                        <div class="Subtitulo1">Listado de Cierres de Caja</div>
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


                                            <asp:TemplateColumn HeaderText="FECHA" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="fecha_cie" class="textos" runat="server" Text='<%#Eval("fecha_cie") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                           

                                            <asp:TemplateColumn HeaderText="NOMBRE">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        
                                                        <asp:Label ID="nombre" Type="date" class="textos" runat="server" Text='<%#Eval("nombre") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                           
                                             <asp:TemplateColumn HeaderText="VALOR">
                                                <ItemTemplate>
                                                    <span style="float: right;">
                                                        <asp:Label ID="valor"  runat="server" class="textos" Text='<%#Eval("valor", "{0:N}") %>'></asp:Label>
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

                                             <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgImpuestos" runat="server" CausesValidation="false" CommandName="Impuestos"
                                                        ImageUrl="~/Tema/imagenes/notebook_search.png" ToolTip="Impuestos" Width="16" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgImprimir" runat="server" CausesValidation="false" CommandName="Imprimir"
                                                        ImageUrl="~/Tema/imagenes/print.png" ToolTip="Imprimir" Width="16" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgVisualizar" runat="server" CausesValidation="false" CommandName="Ver"
                                                        ImageUrl="~/Tema/imagenes/search.png" ToolTip="Visualizar" Width="16" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            
                                            <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgError" runat="server" CausesValidation="false" CommandName="Mostrar"
                                                        ImageUrl="~/Tema/imagenes/application_search.png" ToolTip="Mostrar" Width="16" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgReenviar" runat="server" CausesValidation="false" CommandName="Reenviar"
                                                        ImageUrl="~/Tema/imagenes/up.png" ToolTip="Reenviar" Width="16" />
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
