<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="ParametrosComerciales.aspx.cs" Inherits="CapaWeb.WebForms.ParametrosComerciales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">
        <div style="align-items: left">
            <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
                        <td colspan="9">
                            <table width="100%" border="0" cellspacing="0">
                                <tr>
                                    <td  class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;Parametros Comerciales</td>
                                </tr>
                            </table>
                        </td>

                    </tr> 
                <tr>
                    <td colspan="9" align="left"><asp:Label ID="Label5" CssClass="Titulo" runat="server" Text="Parametros Comerciales"></asp:Label> </td>
                    
                </tr>
                <tr>
                    <td colspan="9" align="center"><asp:Label ID="Label6" CssClass="Subtitulo1" runat="server" Text="DOCUMENTOS ELECTRONICOS"></asp:Label> </td>
                    
                </tr>
                <tr>
                    <td colspan="9">
                        <asp:Label ID="txtAcceso" runat="server" Visible="false" CssClass="Titulo" Text="El Usuario registrado no tiene permiso para ejecutar estos procesos"></asp:Label>
                        
                        </td>
                    </tr>
                <tr>
                    <td>
                        <asp:Button ID="btn_formatosim" class="btnTabs" runat="server" Text="Formatos de Impresion" OnClick="btn_formatosim_Click" /></td>
                    <td>
                        <asp:Button ID="btn_contenido" class="btnTabs" runat="server" Text="Contenido Facturas" OnClick="btn_contenido_Click" /></td>
                    <td>
                        <asp:Button ID="btn_facturacion" class="btnTabs" runat="server" Text="Facturacion Electronica" OnClick="btn_facturacion_Click" /></td>
                </tr>
                 <tr>
                    <td colspan="9">
                        <asp:Label ID="lbl_error" CssClass="textos_error" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                <asp:Panel ID="Panel3"  Visible="false" runat="server">

                    <table  border="0"  cellpadding="0" cellspacing="3" >
                        <tr>
                            <td colspan="9" align="center">
                                <asp:Label ID="Label4" runat="server" class="Subtitulo2" align="center" Text="SUSCRIPCIONES FACTURACION ELECTRONICA"></asp:Label>
                            </td>
                       </tr>
                        <tr>
                        
                            <td colspan="9">
                                <asp:Label ID="Label8" runat="server" CssClass="Subtitulo1" Text="Registre la informacion solicitada:"></asp:Label>
                            </td>
                        </tr>
                        <asp:Panel ID="Panel4" Visible ="false" runat="server">
                        <tr>
                            <td class="titulos" > <asp:Label ID="lbl_fec1" runat="server" class="titulos"  Text="FECHA"></asp:Label></td>
                            <td class="titulos"> <asp:Label ID="lbl_tip1" runat="server" class="titulos"  Text="TIPO CONTRATO"></asp:Label></td>
                            <td class="titulos"> <asp:Label ID="lbl_tip2"  runat="server" class="titulos"  Text="TIPO DOCUMENTO"></asp:Label></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr valign="top">
                            <td align="center">
                                <asp:TextBox ID="fechainicio"  type="date"  Width="202"   runat="server"></asp:TextBox>
                                </td>
                            <td align="center">
                                <asp:DropDownList ID="cbx_tipo_contrato"  class="textos" runat="server" Height="16px" Width="204px">
                                  <asp:ListItem Value="C">Cantidad</asp:ListItem>
                                  <asp:ListItem Value="F">Rango Fechas</asp:ListItem>
                                  <asp:ListItem Value="N">Rango Numeracion</asp:ListItem>
                              </asp:DropDownList>
                            </td>
                            <td align="center">
                                <asp:DropDownList ID="cbx_tipo_doc" class="textos" runat="server" Height="16px" Width="204px">
                                  <asp:ListItem Value="0">TODOS</asp:ListItem>
                                  <asp:ListItem Value="FV">FACTURAS</asp:ListItem>
                                  <asp:ListItem Value="NC">NOTAS DE CREDITO</asp:ListItem>
                                  <asp:ListItem Value="ND">NOTAS DE DEBITO</asp:ListItem>
                                  <asp:ListItem Value="GR">REMISIONES</asp:ListItem>
                              </asp:DropDownList>
                                </td>
                            <td>
                                <asp:Button ID="btn_agregar_con"  CssClass="botones" OnClick="btn_agregar_con_Click" runat="server" Text="Siguiente" />
                             </td>
                        </tr>
                            </asp:Panel>

                        <asp:Panel ID="Pnl_cant" Visible="false" runat="server">
                            <tr>
                                <td class="titulos">
                                    <asp:Label ID="lbl_con"  runat="server" class="titulos" Text="CONTRATO"></asp:Label></td>
                                <td class="titulos">
                                    <asp:Label ID="lbl_doc" runat="server" class="titulos" Text="DOCUMENTO"></asp:Label></td>
                                <td class="titulos">
                                    <asp:Label ID="lbl_can"  runat="server" class="titulos" Text="CANTIDAD"></asp:Label></td>
                                <td class="titulos">
                                    <asp:Label ID="lbl_tol"  runat="server" class="titulos" Text="TOLERANCIA"></asp:Label></td>
                                <td class="titulos">
                                    <asp:Label ID="lbl_det"  runat="server" class="titulos" Text="DETALLE"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_contrato" CssClass="textos" runat="server" Text="Label"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lbl_documento" CssClass="textos" runat="server" Text="Label"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txt_cantidad" type="number" CssClass="textos" runat="server"></asp:TextBox></td>
                             
                                <td>
                                    <asp:TextBox ID="txt_tolerancia" type="number" CssClass="textos" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_detalle" CssClass="textos" runat="server"></asp:TextBox></td>
                                 <td>
                                     <asp:Button ID="btn_cantidad" runat="server" CssClass="botones" OnClick="btn_cantidad_Click" Text="Aceptar" /> </td>
                                <td>
                                    <asp:Button ID="btn_volver" CssClass="botones" runat="server" Text="Volver" OnClick="btn_volver_Click" /> </td>
                            </tr>

                        </asp:Panel>
                        <asp:Panel ID="Pnl_numero" Visible="false" runat="server">
                            <tr>
                            <td class="titulos"> <asp:Label ID="lbl_con1"  runat="server" class="titulos"  Text="CONTRATO"></asp:Label></td>
                            <td class="titulos"> <asp:Label ID="lbl_doc1"  runat="server" class="titulos"  Text="DOCUMENTO"></asp:Label></td>
                            <td class="titulos"> <asp:Label ID="lbl_ini"  runat="server" class="titulos"  Text="INICIO"></asp:Label></td>
                            <td class="titulos"> <asp:Label ID="lbl_fin"  runat="server" class="titulos"  Text="FIN"></asp:Label></td>
                            <td class="titulos"> <asp:Label ID="lbl_tol1"  runat="server" class="titulos"  Text="TOLERANCIA"></asp:Label></td>
                            <td class="titulos"> <asp:Label ID="lbl_det1" runat="server" class="titulos"  Text="DETALLE"></asp:Label></td>
                        </tr>
                        <tr>
                             <td> <asp:Label ID="lbl_contrato1" Width="100" CssClass="textos" runat="server" Text="Label"></asp:Label></td>
                            <td> <asp:Label ID="lbl_docu1" CssClass="textos" runat="server" Text="Label"></asp:Label></td>
                            <td> <asp:TextBox ID="txt_inicio" type="number" CssClass="textos"  runat="server"></asp:TextBox></td>
                            <td> <asp:TextBox ID="txt_fin"  type="number" CssClass="textos" runat="server"></asp:TextBox> </td>
                            <td> <asp:TextBox ID="txt_tot1" type="number" CssClass="textos"  runat="server"></asp:TextBox></td>
                            <td> <asp:TextBox ID="txt_det1" CssClass="textos"  runat="server"></asp:TextBox></td>
                             <td>
                                     <asp:Button ID="btn_aceptar_num" runat="server" OnClick="btn_aceptar_num_Click" CssClass="botones" Text="Aceptar" /> </td>
                                <td>
                                    <asp:Button ID="btn_volver_num" CssClass="botones" runat="server" Text="Volver" onclick="btn_volver_num_Click" /> </td>
                        </tr>
                        </asp:Panel>
                        <asp:Panel ID="Pnl_fec" Visible="false" runat="server">
                            <tr>
                                <td class="titulos">
                                    <asp:Label ID="Label7" runat="server" class="titulos" Text="CONTRATO"></asp:Label></td>
                                <td class="titulos">
                                    <asp:Label ID="Label12"  runat="server" class="titulos" Text="DOCUMENTO"></asp:Label></td>
                                <td class="titulos">
                                    <asp:Label ID="Label20"  runat="server" class="titulos" Text="FECHA INICIO"></asp:Label></td>
                                <td class="titulos">
                                    <asp:Label ID="Label21"  runat="server" class="titulos" Text="FECHA FIN"></asp:Label></td>
                                <td class="titulos">
                                    <asp:Label ID="Label22" runat="server" class="titulos" Text="TOLERANCIA"></asp:Label></td>
                                <td class="titulos">
                                    <asp:Label ID="Label23"  runat="server" class="titulos" Text="DETALLE"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_con2" CssClass="textos" Width="100"  runat="server" Text="Label"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lbl_docu2" CssClass="textos" Width="100"  runat="server" Text="Label"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="fec_ini" CssClass="textos"  type="date" Width="202" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="fec_fin" CssClass="textos" type="date" Width="202" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_to2" CssClass="textos" type="number" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_det2" CssClass="textos"  runat="server"></asp:TextBox></td>
                                 <td>
                                     <asp:Button ID="btn_aceptar_fec" runat="server" CssClass="botones" OnClick="btn_aceptar_fec_Click" Text="Aceptar" /> </td>
                                <td>
                                    <asp:Button ID="btn_volver_fec" CssClass="botones" runat="server" Text="Volver" OnClick="btn_volver_fec_Click"/> </td>
                            </tr>

                        </asp:Panel>
                        
                        <tr>
                    <td colspan="9">
                        <asp:Label ID="txt_avisoemail" runat="server" Visible="false" CssClass="Subtitulo2" Text="No se han activado las notificaciones automaticas de Facturacion Electronica. Por favor revise el modulo de Notificaciones en el menu de Administracion, o comuniquese con su Administrador del Sistema."></asp:Label>
                        
                        </td>
                    </tr>
                        <tr>
                            <td colspan="9" align="center">
                                <asp:Label ID="Label9" runat="server" CssClass="Subtitulo1" Text="SUSCRIPCIONES REGISTRADAS"></asp:Label>
                            </td>
                        </tr>
                             <tr>
                    <td colspan="9">
                        <asp:Label ID="txt_mensaje" runat="server" Visible="false" CssClass="Subtitulo2" Text=""></asp:Label>
                        
                        </td>
                    </tr>
                        <tr>
                            <td colspan="9" align="center"> 
                                <asp:DataGrid ID="gv_Producto" runat="server" 
                                        
                                        AutoGenerateColumns="False" AllowPaging="True" class="table table-hover"
                                         AllowSorting="True" ShowFooter="True"
                                          CellPadding="2"  BackColor="White" BorderColor="#DD6D29" BorderStyle="None" BorderWidth="0px" CellSpacing="1" OnItemCommand="gv_Producto_ItemCommand" PageSize="2000">


                                        <Columns>
                                                <asp:TemplateColumn HeaderText="TRX" Visible="false" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="linea" runat="server" class="textos" Text='<%#Eval("linea") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="REGISTRO" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="cod_articulo" runat="server" class="textos" Text='<%#Eval("registro") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="TIPO CONTRATO">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="nom_articulo" runat="server" class="textos" Text='<%#Eval("tipo_con") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="TIPO DOCUMENTO">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="nom_articulo2" runat="server" class="textos" Text='<%#Eval("tipo_doc") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="VALOR">
                                                <ItemTemplate>
                                                    <span style="float: right;">
                                                        <asp:Label ID="cantidad" runat="server" class="textos" Text='<%#Eval("valor") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="TOLERANCIA">
                                                <ItemTemplate>
                                                    <span style="float: right;">
                                                        <asp:Label ID="precio_unit" runat="server" class="textos" Text='<%#Eval("tolerancia") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="DETALLE">
                                                <ItemTemplate> 
                                                    <span style="float: left;"">
                                                        <asp:Label ID="subtotal" runat="server" class="textos"  Text='<%#Eval("detalle") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="ESTADO">
                                                <ItemTemplate>
                                                    <span style="float: center;">
                                                        <asp:Label ID="detadescuento" runat="server" class="textos" Text='<%#Eval("estado") %>'></asp:Label>
                                                    </span>
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
                                        <HeaderStyle BackColor="#DD6D29" Font-Bold="True" CssClass="busqueda" ForeColor="White" />
                                        <ItemStyle ForeColor="#00000f" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />


                                    </asp:DataGrid>
                            </td>
                        </tr>

                     <tr>
                    <td colspan="9">
                        <asp:Label ID="lbl_conusu" runat="server" Visible="false" CssClass="Subtitulo2" Text="Se encuentra activado el Control Automatico de usuarios para los procesos de facturacion del sistema. Este control desactiva los permisos de usuario cuando no existe un contrato vigente."></asp:Label>
                        
                        </td>
                    </tr>
                    </table>

                </asp:Panel>
              
                <asp:Panel ID="Panel1" runat="server" Visible="false">
                     <table  border="0" cellpadding="0" cellspacing="3" >
                        <td colspan="2" align="center">
                                <asp:Label ID="Label1" runat="server" class="Subtitulo2" align="center" Text="INFORMACION GENERAL"></asp:Label>
                            </td>
                        <tr>
                            <td class="busqueda">Formato Factura:</td>
                            <td>
                                <asp:DropDownList ID="cbx_forfactura" class="textos" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="busqueda">Formato Factura POS:</td>
                            <td>
                                <asp:DropDownList ID="cbx_fac_pos" class="textos" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="busqueda">Formato Pedido:</td>
                            <td>
                                <asp:DropDownList ID="cbx_for_pedido" class="textos" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="busqueda">Formato Proforma:</td>
                            <td>
                                <asp:DropDownList ID="cbx_for_proforma" class="textos" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="busqueda">Formato Remision:</td>
                            <td>
                                <asp:DropDownList ID="cbx_for_remision" class="textos" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="busqueda">Formato Nota de Credito:</td>
                            <td>
                                <asp:DropDownList ID="cbx_for_nc" class="textos" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="busqueda">Formato Nota de Debito:</td>
                            <td>
                                <asp:DropDownList ID="cbx_for_nd" class="textos" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="busqueda">Formato Interfaz Contable</td>
                            <td>
                                <asp:DropDownList ID="cbx_int_con" class="textos" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="busqueda">Maneja Recurso:</td>
                            <td>
                                <asp:DropDownList ID="cbx_maneja_recurso" class="textos" runat="server">
                                    <asp:ListItem Value="N">No</asp:ListItem>
                                    <asp:ListItem Value="S">Si</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="busqueda">Meses de Historia para Consultas:</td>
                            <td>
                                <asp:TextBox ID="txt_historia" class="textos" type="number" MaxLength="3" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                             <td></td>
                             <td>
                                 <asp:Button ID="btn_guardar_fimp" runat="server" CssClass="botones" Text="Aceptar" OnClick="btn_guardar_fimp_Click" /> </td>
                         </tr>
                    </table>
                </asp:Panel>
             
                <asp:Panel ID="Panel2" Visible="false" runat="server">
              
                    <table  border="0" cellpadding="0" cellspacing="3" >
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="Label2" runat="server" class="Subtitulo2" align="center" Text="INFORMACION TRIBUTARIA"></asp:Label>
                            </td>
                        </tr>
                    <tr valign="top">
                        <td class="busqueda">Regimen:</td>
                        <td class="textos2">
                            <label for="info_trib1"></label>
                             <asp:TextBox ID="txt_info1" cols="60" rows="4" class="textos" Width="420" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="busqueda">Ret. Fuente:</td>
                        <td class="textos2">
                            <asp:TextBox ID="txt_info2" cols="60" rows="4" class="textos" Width="420" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="busqueda">Contribuyente:</td>
                        <td class="textos2">
                             <asp:TextBox ID="txt_info3" cols="60" rows="4" class="textos" Width="420" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="busqueda">Autorretenedor:</td>
                        <td class="textos2">
                             <asp:TextBox ID="txt_info4" cols="60" rows="4" class="textos" Width="420" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="busqueda">Act. Economica:</td>
                        <td class="textos2">
                             <asp:TextBox ID="txt_info5" cols="60" rows="4" class="textos" Width="420" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="Label3" runat="server" class="Subtitulo2" align="center" Text="LETRA DE CAMBIO"></asp:Label>
                            </td>
                        </tr>
                        <tr valign="top">
                          <td width="80" class="busqueda">Texto 1:</td>
                          <td  class="textos2">
                            <asp:TextBox ID="txt_letra1" cols="60" rows="4" class="textos" Width="420" TextMode="MultiLine" runat="server"></asp:TextBox>
                          </td>
                        </tr>
                        <tr>
                          <td valign="top" class="busqueda">Texto 2:</td>
                          <td class="textos2">
                            <asp:TextBox ID="txt_letra2" cols="60" rows="4" class="textos" Width="420" TextMode="MultiLine" runat="server"></asp:TextBox>
                          </td>
                        </tr>
                        <tr>
                          <td valign="top" class="busqueda">Texto 3:</td>
                          <td class="textos2">
                            <asp:TextBox ID="txt_letra3" cols="60" rows="4" class="textos" Width="420" TextMode="MultiLine" runat="server"></asp:TextBox>
                          </td>
                        </tr>
                        <tr>
                             <td></td>
                             <td align="right">
                                 <asp:Button ID="btn_cont_fac" runat="server" CssClass="botones" Text="Aceptar" OnClick="btn_cont_fac_Click" /> </td>
                         </tr>
                </table>
                </asp:Panel>
                

            </table>

        </div>

    </form>
</asp:Content>
