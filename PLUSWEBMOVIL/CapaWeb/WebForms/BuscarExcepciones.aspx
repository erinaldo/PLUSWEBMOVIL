<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="BuscarExcepciones.aspx.cs" Inherits="CapaWeb.WebForms.BuscarExcepciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <form id="form1" name="form1" class="forms-sample" runat="server" method="post">
         <div style="align-items: left">
            <table>
                 <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0">
                                <tr>
                                    <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;Excepciones</td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                <tr>
                    <td>
                        <asp:ImageButton ID="ImgAyuda"  runat="server" src="../Tema/imagenes/help.png" width="16" height="16" />
                        <asp:Label ID="lblAyuda" runat="server"  CssClass="Titulo" Text="Excepciones"></asp:Label>
                        
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
                    <td>
                         <p class="Subtitulo1">Busque el registro deseado por:</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                         
                      <table align="center">
                        <tr >
                          <td width="20%" class="busqueda">Usuario:</td>
                          <td>
                              
                              <asp:DropDownList ID="cbx_usuario" runat="server" Width="202px"></asp:DropDownList>
                              <div class="textos_sm">0 = Todos</div></td>
                             
                          
                           <td class="busqueda">Proceso:</td>
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
                                <asp:TextBox ID="fechafin" type="date"  Width="213px"  runat="server"></asp:TextBox>
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

                        <div class="Subtitulo1">Listado de Excepciones</div>
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
                                        OnPageIndexChanged="Grid_PageIndexChanged" PageSize="30" CellPadding="2"  BackColor="White" BorderColor="#DD6D29" BorderStyle="None" BorderWidth="0px" CellSpacing="1">


                                        <Columns>


                                            <asp:TemplateColumn HeaderText="TRX" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="id" class="textos" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="FECHA">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="fecha_for" runat="server" class="textos" Text='<%#Eval("fecha_for") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="PROGRAMA">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        
                                                        <asp:Label ID="proceso" Type="date" class="textos" runat="server" Text='<%#Eval("proceso") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                          

                                         
                                        <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgVer" runat="server"  CausesValidation="false" CommandName="Ver"
                                                        ImageUrl="~/Tema/imagenes/search.png" ToolTip="Ver" Width="16" />
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
