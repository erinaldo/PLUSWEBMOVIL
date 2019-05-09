<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="CapaWeb.WebForms.Factura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <tr>
        <td>

    <tr>
        <td>

    <tr>
        <td>

    <tr>
        <td>

    <link href="../Tema/css/modal.css" rel="stylesheet" />


    <tr>
        <td>



            <p class="Subtitulo1">Por favor ingrese los datos solicitados:</p>
            <form id="form1" class="forms-sample" runat="server">
                <table align="center">
                    <tr valign="top">
                        <td align="right" nowrap="nowrap" class="busqueda">
                            <div align="left">Doc. Ide. cliente:</div>
                        </td>
                        
                        <td class="textos">
                            <asp:TextBox ID="dniCliente" placeholder="Cédula" runat="server" AutoPostBack="True" OnTextChanged="dniCliente_TextChanged"></asp:TextBox>

                            <a href="#modal-one" class="botones ">Nuevo Cliente</a>

                            <asp:HyperLink ID="HyperLink1" href="#modal-tres" onclick="modaltres" class="botones " runat="server" Text="Buscar" />
                            <asp:Button ID="Button3" runat="server" class="botones" Text="Buscar todos" OnClientClick="window.open('./BuscarCliente.aspx','Buscar Cliente', 'top=100,width=800 ,height=600, left=400');"  />
                        </td>
                        <td class="textos">
                            <asp:Label ID="cod_tit" required="required" runat="server" Text="" Visible="False"></asp:Label>
                            <asp:TextBox required="required" ID="nombreCliente" class="textos" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>

                    </tr>
                    <tr valign="top">
                        <td align="right" nowrap="nowrap" class="busqueda">
                            <div align="left">Fecha:</div>
                        </td>
                        <td>
                            <asp:TextBox ID="fecha" type="date" runat="server"></asp:TextBox>

                        </td>
                        <td align="right" nowrap="nowrap" class="busqueda">
                            <div align="left">Serie Documento:</div>
                        </td>
                        <td>
                            <label>
                                <asp:DropDownList class="textos" name="serie_docum" ID="serie_docum" runat="server">
                                </asp:DropDownList>

                            </label>
                        </td>

                    </tr>

                    <tr valign="top">
                        <td align="right" nowrap="nowrap" class="busqueda">
                            <div align="left">C. Costos:</div>
                        </td>
                        <td>
                            <asp:DropDownList class="textos" name="cod_costos" ID="cod_costos" runat="server">
                            </asp:DropDownList>
                        </td>

                        <td align="right" nowrap="nowrap" class="busqueda">
                            <div align="left">Moneda:</div>
                        </td>
                        <td>
                            <label>

                                <asp:DropDownList class="textos" name="cod_moneda" ID="cod_moneda" runat="server">
                                </asp:DropDownList>
                            </label>
                        </td>
                    </tr>

                    <tr valign="top">
                        <td align="right" nowrap="nowrap" class="busqueda">
                            <div align="left">Vendedor:</div>
                        </td>
                        <td>

                            <asp:DropDownList class="textos" name="cod_vendedor" ID="cod_vendedor" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td align="right" nowrap="nowrap" class="busqueda">
                            <div align="left">O.Compra:</div>
                        </td>
                        <td>
                            <label>
                                <input name="ocompra" type="text" class="textos" id="ocompra" tabindex="6" size="15" maxlength="20" />
                            </label>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td align="right" nowrap="nowrap" class="busqueda">
                            <div align="left">F. Pago:</div>
                        </td>
                        <td>

                            <asp:DropDownList class="textos" name="cod_fpago" ID="cod_fpago" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                            <div align="left">% Descuento:</div>
                        </td>
                        <td valign="top">
                            <label>
                                <input name="porc_descto" type="text" class="textos" id="porc_descto" tabindex="8" value="0" size="10" maxlength="8" />
                            </label>
                        </td>
                    </tr>


                    <tr>
                        <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                            <div align="left">Observaciones:</div>
                        </td>
                        <td valign="top">
                            <textarea onkeypress="return taLimit(this)" onkeyup="return taCount(this,'myCounter')" name="observaciones" rows="5" wrap="physical" cols="50" class="textos" id="observaciones" tabindex="9"></textarea>
                            <div class="textos2" align="left">Caracteres disponibles: <b><span id="myCounter">250</span></b></div>
                        </td>
                        <td align="left" valign="top" nowrap="nowrap" class="busqueda">Fecha Auxiliar:</td>

                    </tr>
                    <tr valign="top">
                        <td nowrap="nowrap" align="right">&nbsp;</td>
                        <td>
                           
                            <asp:Button ID="GuardarCabecera" CssClass="botones" onclick="GuardarCabecera_Click" runat="server" Text="Aceptar" />
                        </td>
                        

                    </tr>

                </table>

                <div class="Subtitulo2" align="center">Nuevos Productos o Servicios</div>
                <form id="form3" name="form3" method="post" action="Reg_FacturasVN_Art.asp">
                    <table border="0" align="center" cellpadding="0" cellspacing="0" id="Tabla_Det3">
                        <tr valign="top">
                            <td class="busqueda">Articulo:</td>
                            <td>
                                <div align="center">
                                    <input name="articulo" type="text" class="textos" id="articulo" tabindex="1" size="40" maxlength="50" />
                                </div>
                                <div class="textos_sm">Codigo o Nombre</div>
                            </td>
                            <td>
                                <asp:HyperLink ID="HyperLink2" href="#modal-cuatro" class="botones " runat="server">Buscar</asp:HyperLink>
                                <asp:Button ID="Button4" CssClass="botones" runat="server" Text="Buscar Todos" OnClientClick="window.open('./BuscarArticulo.aspx','MiPagina', 'top=200,width=900 ,height=400, left=350');"  />
                            </td>
                        </tr>
                    </table>
                    <table border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#0E748A">
                        <tr>
                            <td>

                                <asp:DataGrid ID="Grid4" runat="server" AutoGenerateColumns="False" AllowSorting="True" PageSize="4" AllowPaging="True">
                                    <Columns>


                                        <asp:TemplateColumn HeaderText="Codigo">
                                            <ItemTemplate>
                                                <span style="float: left;">
                                                    <asp:Label ID="cod_articulo" class="textos" runat="server" Text='<%#Eval("cod_articulo") %>'></asp:Label>
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>

                                        <asp:TemplateColumn HeaderText="Descripción">
                                            <ItemTemplate>
                                                <span style="float: left;">
                                                    <asp:Label ID="nom_articulo" runat="server" class="textos" Text='<%#Eval("nom_articulo") %>'></asp:Label>
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>

                                        <asp:TemplateColumn HeaderText="%IVA">
                                            <ItemTemplate>
                                                <span style="float: left;">
                                                    <asp:Label ID="porc_impuesto" runat="server" class="textos" Text='<%#Eval("porc_impuesto") %>'></asp:Label>
                                                </span>
                                            </ItemTemplate>
                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                        </asp:TemplateColumn>

                                        <asp:TemplateColumn HeaderText="P.V.P">
                                            <ItemTemplate>
                                                <span style="float: left;">
                                                    <asp:Label ID="precio" runat="server" class="textos" Text='<%#Eval("precio") %>'></asp:Label>
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>

                                        <asp:TemplateColumn HeaderText="I.V.A">
                                            <ItemTemplate>
                                                <span style="float: left;">
                                                    <asp:Label ID="valor_impu" runat="server" class="textos" Text='<%#Eval("valor_impu") %>'></asp:Label>
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>

                                        <asp:TemplateColumn HeaderText="Total">
                                            <ItemTemplate>
                                                <span style="float: left;">
                                                    <asp:Label ID="precio_total" runat="server" class="textos" Text='<%#Eval("precio_total") %>'></asp:Label>
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>


                                        <asp:TemplateColumn>
                                            <ItemTemplate>
                                                <asp:Button ID="Button1" runat="server" ToolTip="Seleccionar" Class="botones" Text="Seleccionar" />


                                            </ItemTemplate>
                                        </asp:TemplateColumn>

                                    </Columns>


                                    <FooterStyle BackColor="White" ForeColor="#00000f" />
                                    <HeaderStyle BackColor="#DD6D29" Font-Bold="True" ForeColor="#FFFFFF" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                    <ItemStyle ForeColor="#000000" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                                    <SelectedItemStyle BackColor="#0E748A" Font-Bold="True" ForeColor="White" />


                                </asp:DataGrid>


                            </td>
                        </tr>
                    </table>






                </form>
                </br>
        </br>
        

                <a href="#" class="modal" id="modal-one" aria-hidden="true"></a>
                <div class="modal-dialog">
                    <div class="modal-header">
                        <h2 class="textos">Nuevo Cliente</h2>
                        <a href="#" class="btn-close" aria-hidden="true">×</a>
                    </div>
                    <div class="modal-body">
                        <table border="0" cellspacing="3" cellpadding="0" id="Tabla_Det3">
                            <tr valign="top">
                                <td class="busqueda">Doc. Legal:</td>
                                <td class="textos">
                                    <asp:TextBox ID="doc_legal" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Nombres:*</td>
                                <td class="textos">
                                    <label>
                                        <input name="primer_nombre" type="text" class="textos" id="primer_nombre" tabindex="1" maxlength="30" />
                                    </label>
                                    <label>
                                        <input name="segundo_nombre" type="text" class="textos" id="segundo_nombre" tabindex="2" maxlength="30" />
                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Apellidos:*</td>
                                <td class="textos">
                                    <label>
                                        <input name="primer_apellido" type="text" class="textos" id="primer_apellido" tabindex="3" maxlength="30" />
                                    </label>
                                    <label>
                                        <input name="segundo_apellido" type="text" class="textos" id="segundo_apellido" tabindex="4" maxlength="30" />
                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Abreviacion:*</td>
                                <td>
                                    <input name="cod_sop" type="text" id="cod_sop" tabindex="5" size="6" maxlength="3" /><span class="textos_sm"> 3 Caracteres</span></td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Direccion:*</td>
                                <td class="textos">
                                    <label>
                                        <textarea name="dir_tit" cols="40" rows="3" class="textos" id="dir_tit" tabindex="6"></textarea>
                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Telefonos:*</td>
                                <td class="textos">
                                    <label>
                                        <input name="tel_tit" type="text" class="textos" id="tel_tit" tabindex="7" size="15" maxlength="20" />
                                    </label>
                                    <label>
                                        <input name="fax_tit" type="text" class="textos" id="fax_tit" tabindex="8" size="15" maxlength="20" />
                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Email:</td>
                                <td class="textos">
                                    <label>
                                        <input name="email_tit" type="text" class="textos" id="email_tit" tabindex="9" size="40" maxlength="40" />
                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Clasificacion DIAN:*</td>
                                <td class="textos">
                                    <label>
                                        <select name="cod_tipo_emp_iva" class="textos" id="cod_tipo_emp_iva" tabindex="10">
                                        </select>
                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Tipo Regimen:*</td>
                                <td class="textos">
                                    <label>
                                        <select name="cod_tipo_emp_gan" class="textos" id="cod_tipo_emp_gan" tabindex="11">
                                        </select>
                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td>&nbsp;</td>
                                <td>
                                    <input name="button2" type="submit" class="botones" id="button2" tabindex="12" value="Informacion Geografica" />
                                    <div class="textos_sm">* Campos Obligatorios</div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <input type="submit" class="botones" value="Guardar" tabindex="10" />

                    </div>
                </div>


                <a href="#" class="modal" id="modal-two" aria-hidden="true"></a>
                <div class="modal-dialog">
                    <div class="modal-header">
                        <h2 class="textos">Nuevo Producto</h2>
                        <a href="#" class="btn-close" aria-hidden="true">×</a>
                    </div>
                    <div class="modal-body">

                        <table border="0" cellspacing="3" cellpadding="0" id="Tabla_Det3">

                            <tr valign="top">
                                <td class="busqueda">Codigo:*</td>
                                <td>
                                    <input name="cod_sop" type="text" id="cod_sop1" tabindex="5" size="6" maxlength="3" /></td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Descripción:*</td>
                                <td class="textos">
                                    <label>
                                        <textarea name="dir_tit" cols="40" rows="3" class="textos" id="dir_tit1" tabindex="6"></textarea>
                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Descripcion2:*</td>
                                <td class="textos">
                                    <label>
                                        <input name="tel_tit" type="text" class="textos" id="tel_tit1" tabindex="7" size="15" maxlength="20" />
                                    </label>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">C.costo:</td>
                                <td class="textos">
                                    <label>
                                        <input name="email_tit" type="text" class="textos" id="email_tit1" tabindex="9" size="40" maxlength="40" />
                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Cantidad:*</td>
                                <td class="textos">
                                    <label>
                                        <input name="email_tit" type="text" class="textos" id="email_tit2" tabindex="9" size="40" maxlength="40" />

                                        </select>
                               
                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Precio:*</td>
                                <td class="textos">
                                    <label>
                                        <input name="email_tit" type="text" class="textos" id="email_tit3" tabindex="9" size="40" maxlength="40" />

                                        </select>
                               
                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">%dscto:*</td>
                                <td class="textos">
                                    <label>
                                        <input name="email_tit" type="text" class="textos" id="email_tit4" tabindex="9" size="40" maxlength="40" />

                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">%iva:*</td>
                                <td class="textos">
                                    <label>
                                        <input name="email_tit" type="text" class="textos" id="email_tit17" tabindex="9" size="40" maxlength="40" />


                                    </label>
                                </td>
                            </tr>
                        </table>




                    </div>
                    <div class="modal-footer">
                        <input type="submit" class="botones" value="Guardar" tabindex="10" />

                    </div>
                </div>






                <a href="#" class="modal" id="modal-tres" aria-hidden="true"></a>

                <div class="modal-dialog">
                    <div class="modal-header">

                       



                        <a href="#" class="btn-close" aria-hidden="true">×</a>
                    </div>
                    <div class="modal-body">

                      <iframe name="nombre" src="BuscarCliente.aspx" width="400" height="400" frameborder="1">Tu navegador no soporta iframes</iframe>


                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <input type="submit" class="botones" value="Guardar" tabindex="10" />

                    </div>
                </div>



                <a href="#" class="modal" id="modal-cuatro" aria-hidden="true"></a>

                <div class="modal-nuevo">
                    <div class="modal-header">
                        <h2 class="textos">Buscar Producto/ Servicio</h2>
                        <asp:TextBox class="botones" ID="BuscarP" OnTextChanged="BuscarP_TextChanged" AutoPostBack="True" placeholder="Buscar..." runat="server" />
                        
                        <asp:LinkButton runat="server" Text="BuscarP" OnClick="BuscarP_Click" />

                        <a href="#" class="btn-close" aria-hidden="true">×</a>
                    </div>
                    <div class="modal-body">
                        <div class="scroll">
                            <table border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#0E748A">
                                <tr>
                                    <td>

                                        <asp:DataGrid ID="Grid3" runat="server" AutoGenerateColumns="False" AllowSorting="True" PageSize="4" AllowPaging="True">
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="Codigo" Visible="False">
                                                    <ItemTemplate>
                                                        <span style="float: left;">
                                                            <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>

                                                <asp:TemplateColumn HeaderText="Codigo">
                                                    <ItemTemplate>
                                                        <span style="float: left;">
                                                            <asp:Label ID="cod_articulo" class="textos" runat="server" Text='<%#Eval("cod_articulo") %>'></asp:Label>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>

                                                <asp:TemplateColumn HeaderText="Descripción">
                                                    <ItemTemplate>
                                                        <span style="float: left;">
                                                            <asp:Label ID="nom_articulo" runat="server" class="textos" Text='<%#Eval("nom_articulo") %>'></asp:Label>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>

                                                <asp:TemplateColumn HeaderText="%IVA">
                                                    <ItemTemplate>
                                                        <span style="float: left;">
                                                            <asp:Label ID="porc_impuesto" runat="server" class="textos" Text='<%#Eval("porc_impuesto") %>'></asp:Label>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>

                                                <asp:TemplateColumn HeaderText="P.V.P">
                                                    <ItemTemplate>
                                                        <span style="float: left;">
                                                            <asp:Label ID="precio" runat="server" class="textos" Text='<%#Eval("precio") %>'></asp:Label>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>

                                                <asp:TemplateColumn HeaderText="I.V.A">
                                                    <ItemTemplate>
                                                        <span style="float: left;">
                                                            <asp:Label ID="valor_impu" runat="server" class="textos" Text='<%#Eval("valor_impu") %>'></asp:Label>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>

                                                <asp:TemplateColumn HeaderText="Total">
                                                    <ItemTemplate>
                                                        <span style="float: left;">
                                                            <asp:Label ID="precio_total" runat="server" class="textos" Text='<%#Eval("precio_total") %>'></asp:Label>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>


                                                <asp:TemplateColumn>
                                                    <ItemTemplate>
                                                        <asp:Button ID="Button1" runat="server" toolping="Seleccionar" Class="botones" Text="Seleccionar" />


                                                    </ItemTemplate>
                                                </asp:TemplateColumn>

                                            </Columns>


                                            <FooterStyle BackColor="White" ForeColor="#00000f" />
                                            <HeaderStyle BackColor="#DD6D29" Font-Bold="True" ForeColor="#FFFFFF" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                            <ItemStyle ForeColor="#000000" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                                            <SelectedItemStyle BackColor="#0E748A" Font-Bold="True" ForeColor="White" />


                                        </asp:DataGrid>


                                    </td>
                                </tr>
                            </table>




                        </div>
                    </div>
                    <div class="modal-footer">
                        <input type="submit" class="botones" value="Guardar" tabindex="10" />

                    </div>
                </div>


            </form>
        </td>
    </tr>

        </td>
    </tr>

        </td>
    </tr>

        </td>
    </tr>

        </td>
    </tr>

</asp:Content>
