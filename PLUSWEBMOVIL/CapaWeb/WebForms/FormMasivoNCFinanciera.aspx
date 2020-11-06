<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="FormMasivoNCFinanciera.aspx.cs" Inherits="CapaWeb.WebForms.FormMasivoNCFinanciera" %>
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
    <form id="form1" class="forms-sample" runat="server" >


        <div style="align-items: center">
            <table>
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0">
                            <tr>
                                <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;<a href="AccesoMasivoNC.aspx">Masivo Notas de Crédito</a>---&gt;Nuevo</td>
                            </tr>
                        </table>
                    </td>

                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblAyuda" runat="server" CssClass="Titulo" Text="Importar Notas de Crédito Financieras"></asp:Label>

                    </td>
                </tr>
                   <tr>
                    <td>
                         <asp:Label ID="Label14" runat="server"  CssClass="Subtitulo2" Text="Sucursal: "></asp:Label>
                        <asp:Label ID="lbl_cod_suc_emp" runat="server"  CssClass="Subtitulo2" Text=""></asp:Label>
                        <asp:Label ID="lbl_suc_emp" runat="server"  CssClass="Subtitulo2" Text=""></asp:Label>
                     </td>
                       <td >
                           <asp:Label ID="lbl_prefijio" runat="server" CssClass="Subtitulo2" Text="Prefijo: "></asp:Label>
                           <asp:Label ID="lbl_tipo_prefijo" runat="server" CssClass="Subtitulo2" Text=""></asp:Label>
                       </td>
                       <td >
                           <asp:Label ID="lbl_ve" runat="server" CssClass="Subtitulo2" Text="Tipo: "></asp:Label>
                           <asp:Label ID="lbl_tipo_nc" runat="server" CssClass="Subtitulo2" Text=""></asp:Label>
                       </td>
                </tr>
                      
                 <tr>
                    <td colspan="3">

                         <hr />
                    </td>
                </tr>
                 <tr>
                     <td colspan="3">
                        <asp:Label ID="lbl_error" runat="server"  class="textos_error" Text=""></asp:Label>
                        </td>
                    </tr>
                  <tr>
                     <td colspan="3">
                       <asp:Label ID="lbl_mensaje" runat="server"  class="textos_error" Text=""></asp:Label>
                        
                        </td>
                    </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_carga" runat="server" class="Subtitulo1" Text="Cargar facturas a aplicar: "></asp:Label>
                    </td>

                    <td class="busqueda">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                    <td>
                        <asp:Button ID="btn_importar" CssClass="botones" OnClick="btn_importar_Click" runat="server" Text="Importar" />
                    </td>

                </tr>
                <tr>
                    <td >
                        <asp:Label ID="lbl_verificar" runat="server" Visible="false" CssClass="busqueda" Text="Total notas de crédito a procesar:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lbl_total_nc" runat="server" Visible="false" CssClass="textos" Text=""></asp:Label>
                        </td>
                    <td>
                        <asp:Button ID="btn_verificar" CssClass="botones" Visible="false" runat="server" Text="Verificar" OnClick="btn_verificar_Click" />
                    </td>
                </tr>
                  <tr>
                <td>
                    <asp:Label ID="lbl_fec_ca" CssClass="busqueda"  Visible="false" runat="server" Text="Fecha carga archivo: "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_carga_fec" CssClass="textos" Visible="false"  runat="server" Text=""></asp:Label>
                </td>
                <td class="botones" align="left">
                    <asp:Button ID="btn_cancelar" CssClass="botones" Visible="false"  onclick="btn_cancelar_Click" runat="server" Text="Cancelar" />
                </td>
            </tr>
                 <tr>
                <td colspan="3">


                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:ScriptManager ID="ScriptManager1" runat="server" />
                            <asp:Timer ID="Timer1" Interval="500" Enabled="false" runat="server" OnTick="Timer1_Tick" />
                            <asp:Label ID="LblAvance" runat="server" ForeColor="#0E748A" />
                            <br />
                            <asp:Label ID="LblPorcentajeAvance" runat="server" ForeColor="#DD6D29" />
                            <asp:Panel ID="Panel1" Width="401px" BorderColor="#0E748A" BorderWidth="1px"
                                BorderStyle="Solid" Height="20px" runat="server">
                                <asp:Label ID="LblProgressBar" Visible="False"  CssClass="estiloScroll" Width="0px" runat="server"></asp:Label>
                                
                            </asp:Panel>
                            <asp:Label ID="lbl_error_factura" runat="server" Visible="false" CssClass="textos_error" Text=""></asp:Label>
                            <br />
                            <asp:Button ID="BtnIniciar" CssClass="botones" Visible="false" runat="server" Text="Procesar" OnClick="BtnIniciar_Click" />
                              <br />
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
                                                <asp:DataGrid ID="Grid" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DD6D29" BorderStyle="None" BorderWidth="0px" CellPadding="2" CellSpacing="1" class="table table-hover" OnItemCommand="Grid_ItemCommand" OnPageIndexChanged="Grid_PageIndexChanged" onrowcommand="GriTipoUsuario_RowCommand" onrowcreated="GriTipoUsuario_RowCreated" PageSize="100" ShowFooter="True" Visible="false">
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
    </form>
</asp:Content>
