<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="BuscarParametros.aspx.cs" Inherits="CapaWeb.WebForms.BuscarParametros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <form id="form1" name="form1" class="forms-sample" runat="server" method="post">
         <div style="align-items: left">
            <table>
                 <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0">
                                <tr>
                                    <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;Parámetros</td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                  <tr>
                    <td>
                        <p class="Subtitulo2">Para agregar nueva conexión
                                <asp:Button ID="NuevaDenominacion" OnClick="NuevaDenominacion_Click"  class="botones" runat="server" Text="AQUI" />
                          </p>
                        </td>
                    </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lbl_error" CssClass="textos_error" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                <tr>
                    <td>
                         <p class="Subtitulo1">Busque conexión :</p>
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
                                              <asp:TemplateColumn HeaderText="EMPRESA"  >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="cod_emp" CssClass="textos" runat="server" Text='<%#Eval("cod_emp") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="CONEXIÓN" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="conexion_erp" CssClass="textos" runat="server" Text='<%#Eval("conexion_erp") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                                                      

                                            <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandName="Editar"
                                                        ImageUrl="~/Tema/imagenes/edit.png" ToolTip="Editar" Width="16" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                           

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
</asp:Content>
