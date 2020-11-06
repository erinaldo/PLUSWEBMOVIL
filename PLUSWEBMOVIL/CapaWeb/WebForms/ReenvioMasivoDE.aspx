<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="ReenvioMasivoDE.aspx.cs" Inherits="CapaWeb.WebForms.ReenvioMasivoDE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        .estiloScroll {
            width: 1%;
            height: 20px;
            border-style: solid;
            border-color: #0E748A;
            border-width: 1px;
            background-color: #DD6D29;
        }
    </style>

     <form id="form1" name="form1" class="forms-sample" runat="server" >
         <div style="align-items: left">
            <table>
                 <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0">
                                <tr>
                                    <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;Reenvío Documentos Electrónicos</td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                <tr>
                    <td>
                        <asp:ImageButton ID="ImgAyuda"  runat="server" src="../Tema/imagenes/help.png" width="16" height="16" />
                        <asp:Label ID="lblAyuda" runat="server"  CssClass="Titulo" Text="Reenvío Documentos Electrónicos"></asp:Label>
                        
                        </td>
                    </tr>
               
                 <tr>
                    <td>
                        &nbsp;</td>
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
   
                        <tr valign="top">
                        

                           <td width="80%" class="busqueda">Tipo Documento:</td>
                          <td>
                              <asp:DropDownList ID="cbx_tipo_doc" Width="224px" class="textos" runat="server" Height="16px">
                                  <asp:ListItem Value="VTAE">Factura</asp:ListItem>
                                  <asp:ListItem Value="POSE">Factura POS</asp:ListItem>
                                  <asp:ListItem Value="NC">Nota Crédito</asp:ListItem>
                                  <asp:ListItem Value="NDVE">Nota Débito</asp:ListItem>
                              </asp:DropDownList>
                          </td>
                            <td aling="rigth"><asp:Button ID="Buscar" runat="server" OnClick="Buscar_Click" class="botones" Text="Buscar" /></td>
                        </tr>
                           &nbsp;
                          
                       
                      </table>
                  </td>
                        </tr>
                      <tr>
                    <td>

                         <hr />
                    </td>
                </tr>
                 <tr>
                      <td >
                          <asp:Label ID="lbl_fac_txt" CssClass="busqueda" Visible="false" runat="server" Text="Total documentos a procesar: "></asp:Label>
                          <asp:Label ID="lbl_tot_doc" CssClass="textos" Visible="false" runat="server" Text=""></asp:Label>
                      </td>

                  </tr>
                 <tr>
                <td >


                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:ScriptManager ID="ScriptManager1" runat="server" />
                            <asp:Timer ID="Timer1" Interval="500" Enabled="false" runat="server" OnTick="Timer1_Tick" />
                             <asp:Button ID="BtnIniciar" CssClass="botones" Visible="false" runat="server" Text="Enviar" OnClick="BtnIniciar_Click" />
                            <asp:Button ID="btn_reenviarpdf" CssClass="botones" Visible="false" runat="server" Text="Enviar PDF" onclick="btn_reenviarpdf_Click"/>
                            <asp:Button ID="btn_limpiar" CssClass="botones" Visible="false" runat="server" Text="Cargar Nuevo" OnClick="btn_limpiar_Click" />
                            <br />
                            <asp:Label ID="LblAvance" runat="server" ForeColor="#0E748A" />
                            <br />
                            <asp:Label ID="LblPorcentajeAvance" runat="server" ForeColor="#DD6D29" />
                            <asp:Panel ID="Panel1" Width="401px" BorderColor="#0E748A" BorderWidth="1px"
                                BorderStyle="Solid" Height="20px" runat="server">
                                <asp:Label ID="LblProgressBar" Visible="False"  CssClass="estiloScroll" Width="0px" runat="server"></asp:Label>
                            </asp:Panel>
                            <asp:Label ID="lbl_error_factura" runat="server" Visible="false" CssClass="textos_error" Text=""></asp:Label>
                            <br />
                            

                           
   
                            <br/>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_lisdoc" runat="server" CssClass="Subtitulo1" Text="Listado de Documentos no autorizados, por favor revisar incidencias." Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table align="center" border="0" bordercolor="#0E748A" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:DataGrid ID="Grid" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DD6D29" BorderStyle="None" BorderWidth="0px" CellPadding="2" CellSpacing="1" class="table table-hover" OnItemCommand="Grid_ItemCommand" OnPageIndexChanged="Grid_PageIndexChanged" onrowcommand="GriTipoUsuario_RowCommand" onrowcreated="GriTipoUsuario_RowCreated" PageSize="9" ShowFooter="True" Visible="false">
                                                    <Columns>
                                                        <asp:TemplateColumn HeaderText="TRX">
                                                            <ItemTemplate>
                                                                <span style="float: left;">
                                                                <asp:Label ID="nro_trans" runat="server" class="textos" Text='<%#Eval("nro_trans") %>'></asp:Label>
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
                                                                <asp:Label ID="fec_doc" runat="server" class="textos" Text='<%#Eval("fec_doc_str") %>' Type="date"></asp:Label>
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
                                                                <asp:Label ID="total" runat="server" class="textos" Text='<%#Eval("total", "{0:N}") %>'></asp:Label>
                                                                </span>
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
                          
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>
            </tr>
                 
                      
                   
                </table>
                    </div>
                  </form>
</asp:Content>
