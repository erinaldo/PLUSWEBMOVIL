<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="CapaWeb.WebForms.Factura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function validarCamposArticulo(){
            var BuscarArticulo = document.getElementById("<%= BuscarArticulo.ClientID %>").value;
            var precio = document.getElementById("<%= precio.ClientID %>").value;
            var cantidad = document.getElementById("<%= cantidad.ClientID %>").value;
            var porcdescto = document.getElementById("<%= porcdescto.ClientID %>").value;
            var respuesta;
            if (BuscarArticulo == null || BuscarArticulo == "") {
                alert("Ingrese el artículo");
                respuesta =  false;
            } else {             
                respuesta = true;
            }
            if (cantidad == null || cantidad == "" || cantidad <= 0) {
                alert("Ingrese cantidad");
                respuesta = false;
            } else {
                respuesta = true;
            }
            
            if (porcdescto < 0 || porcdescto == "" || porcdescto == null ) {
                alert("Descuento no puede ser menor que cero");
                respuesta = false;
            } else {
                respuesta = true;
            }
            if (precio == null || precio == "" || precio <= 0) {
                alert("Ingrese precio");
                respuesta = false;
            } else {
                respuesta = true;
            }



            return respuesta
        }

       
    </script>


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
                        <p class="Subtitulo1">Por favor ingrese los datos solicitados:</p>
                    </td>
                </tr>

                <tr>
                    <td>

                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>


                        <table align="center">
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="mensaje" name="mensaje" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>

                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Cliente:</div>
                                </td>

                                <td class="textos">
                                    <asp:TextBox ID="dniCliente" required="required" placeholder="Buscar..." size="25" runat="server" AutoPostBack="True" OnTextChanged="dniCliente_TextChanged"></asp:TextBox>


                                </td>
                                <td class="textos" colspan="2">
                                    <asp:Label ID="cod_tit" required="required" runat="server" Text="" Visible="False"></asp:Label>
                                    <asp:TextBox required="required" ID="nombreCliente" class="textos" size="44" MaxLength="50" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                                 <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Teléfono:</div>
                                </td>
                                <td class="textos">
                                    <asp:TextBox required="required" ID="fonoCliente" class="textos" size="27" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr valign="top">
                                    <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Correo:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:TextBox ID="txtcorreo"  Width="202" class="textos" runat="server"></asp:TextBox>

                                    </label>
                                </td>
                                
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Fecha:</div>
                                </td>
                                <td>

                                    <asp:TextBox ID="fecha" type="date" onkeyup="FechaActual();" Width="248" required="required" value="today" runat="server"></asp:TextBox>

                                </td>

                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">F. Pago:</div>
                                </td>
                                <td>

                                    <asp:DropDownList class="textos" Width="209" name="cod_fpago" ID="cod_fpago" runat="server">
                                    </asp:DropDownList>
                                </td>

                            </tr>
                            <tr valign="top">
                                <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div align="left">N° Pedido:</div>
                                </td>
                                <td valign="top">
                                    <label>
                                        <asp:TextBox ID="nro_pedido" class="textos" Width="202" name="nro_pedido" runat="server"></asp:TextBox>

                                    </label>
                                </td>
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">C. Costos:</div>
                                </td>
                                <td>
                                    <asp:DropDownList class="textos" name="cod_costos" Width="252" ID="cod_costos" runat="server">
                                    </asp:DropDownList>
                                </td>

                               <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Moneda:</div>
                                </td>
                                <td>
                                    <label>

                                        <asp:DropDownList class="textos" name="cmbCod_moneda" Width="210" ID="cmbCod_moneda" runat="server">
                                        </asp:DropDownList>
                                    </label>
                                </td>


                            </tr>

                            <tr valign="top">
                                 <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">O.Compra:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:TextBox ID="ocompra" name="ocompra" Width="202" class="textos" runat="server"></asp:TextBox>

                                    </label>
                                </td>
                               
                                 <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Vendedor:</div>
                                </td>
                                <td>

                                    <asp:DropDownList class="textos" Width="252" name="cod_vendedor" ID="cod_vendedor" runat="server">
                                    </asp:DropDownList>
                                </td>
                                 <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Serie Documento:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:DropDownList class="textos" name="serie_docum" Width="210" ID="serie_docum" runat="server">
                                        </asp:DropDownList>

                                    </label>
                                </td>
                            </tr>
                           <tr>
                               <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div align="left">% Descuento:</div>
                                </td>
                                <td valign="top">
                                    <label>
                                        <asp:TextBox ID="porc_descto" class="textos" value="0" Width="202" name="porc_descto" runat="server"></asp:TextBox>

                                    </label>
                                </td>
                               </tr>
                            <tr>
                                <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <asp:Label align="center" ID="lbl_proforma" Visible="false" runat="server" Text="Proformas:"></asp:Label>
                                </td>
                                <td valign="top">
                                    <label>
                                        <asp:DropDownList class="textos" Visible="false" name="cbx_proformas" Width="200" ID="cbx_proformas" runat="server">
                                        </asp:DropDownList>

                                    </label>
                                </td>
                               
                               <td>
                                   <asp:Button ID="btn_Proforma" CssClass="botones" Visible="false" onclick="btn_Proforma_Click" runat="server" Text="Cargar Proforma" />
                                  </td>
                               <td align="right"  valign="top" nowrap="nowrap" class="busqueda">
                                   <asp:Label ID="lbl_remision" Visible="false" runat="server" Text="Remisiones:"></asp:Label>
                                    
                                </td>
                                <td valign="top">
                                    <label>
                                       <asp:DropDownList class="textos" Visible="false" name="cbx_remisiones" Width="150" ID="cbx_remisiones" runat="server">
                                        </asp:DropDownList>

                                    </label>
                                </td>
                               <td valign="top">
                                   <label>
                                   <asp:Button ID="btn_Remision" CssClass="botones" Visible="false" onclick="btn_Remision_Click" runat="server" Text="Cargar Remision" />
                                       </label>
                                  </td>

                           </tr>
                            <tr>
                                
                                <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div align="left">Observaciones:</div>
                                </td>
                                <td colspan="5">
                                    <asp:TextBox ID="area" runat="server" Width="900" class="textos" TextMode="MultiLine" cols="150" Rows="3"></asp:TextBox>
                                    <div class="textos2" align="left">Caracteres disponibles: <b><span id="myCounter">250</span></b></div>
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
                        <asp:Label ID="lbl_trx" visible="false" class="Subtitulo2" runat="server" Text=""></asp:Label>

                        
                    </td>
                </tr>

                <tr>
                    <td>

                        <div class="Subtitulo1">Nuevos Productos o Servicios</div>
                    </td>
                </tr>
                <tr>
                    <td>


                        <table border="0" id="MostrarDetalle" align="center" >
                            <tr>
                                <td class="busqueda">
                                    <asp:Label ID="Articulo" class="busqueda" runat="server" Text="Label">Articulo</asp:Label></td>
                                <td>
                                    <asp:Label ID="Producto" class="busqueda" runat="server" Text="Label">Descripción</asp:Label>
                                </td>
                                
                                <td>
                                    <asp:Label ID="lblCantidad" runat="server" class="busqueda" Text="Label">Cantidad</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="pvp" runat="server" class="busqueda" Text="Label">Precio</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" class="busqueda" Text="Label">% Descto</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" class="busqueda" Text="Label">% IVA</asp:Label>
                                </td>
                              
                            </tr>
                            <tr>

                                <td>
                                    <asp:TextBox ID="BuscarArticulo" runat="server" placeholder="Buscar..."  size="20" MaxLength="50" AutoPostBack="True" OnTextChanged="BuscarArticulo_TextChanged"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="articulos" CssClass="textos" runat="server" Rows="2" Size="40" ReadOnly="true"></asp:TextBox>
                                </td>
                                
                                <td>
                                    <asp:TextBox ID="cantidad" CssClass="textos"  min="1" step="0.01" type="number" value="1" Width="60px" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="precio"   CssClass="textos"  type="number"  step="0.01" value="0" runat="server" Width="100px"></asp:TextBox>
                                </td>
                                 <td>
                                    <asp:TextBox ID="porcdescto" CssClass="textos" min="0" step="0.01" type="number" value="0"  Width="60px" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="iva" CssClass="textos" type="number" readonly="true" Width="60px" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="AgregarProducto"  CssClass="botones" runat="server" Text="Agregar" OnClick="AgregarProducto_Click" OnClientClick="return validarCamposArticulo();" />
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
                        <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#0E748A">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" runat="server" Height="250px" Width="100%" ScrollBars="Auto">
                                        <asp:DataGrid ID="gv_Producto" runat="server" 
                                        
                                        AutoGenerateColumns="False" AllowPaging="True" class="table table-hover"
                                         AllowSorting="True" ShowFooter="True"
                                          CellPadding="2"  BackColor="White" BorderColor="#DD6D29" BorderStyle="None" BorderWidth="0px" CellSpacing="1" OnItemCommand="gv_Producto_ItemCommand">


                                        <Columns>
                                            <asp:TemplateColumn HeaderText="Código" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="cod_articulo" runat="server" class="textos" Text='<%#Eval("cod_articulo") %>'></asp:Label>
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

                                            <asp:TemplateColumn HeaderText="Cantidad">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="cantidad" runat="server" class="textos" Text='<%#Eval("cantidad") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="Precio">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="precio_unit" runat="server" class="textos" Text='<%#Eval("precio_unit", "{0:N}") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="Sub total">
                                                <ItemTemplate> 
                                                    <span style="float: left;">
                                                        <asp:Label ID="subtotal" runat="server" class="textos"  Text='<%#Eval("subtotal", "{0:N}") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Descto">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="detadescuento" runat="server" class="textos" Text='<%#Eval("detadescuento", "{0:N}") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                           
                                             <asp:TemplateColumn HeaderText="IVA">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="detaiva" runat="server" class="textos" Text='<%#Eval("detaiva", "{0:N}") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Total">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="total" runat="server" class="textos" Text='<%#Eval("total", "{0:N}") %>'></asp:Label>
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
                                                                                                                                    
                                        </Columns>

                                        <FooterStyle BackColor="White" ForeColor="#00000f" />
                                        <HeaderStyle BackColor="#DD6D29" Font-Bold="True" ForeColor="White" />
                                        <ItemStyle ForeColor="#00000f" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />


                                    </asp:DataGrid>
                                        </asp:Panel>
                                        
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
                        <table border="1" align="right" cellpadding="0" cellspacing="0" bordercolor="#0E748A">
                            <tr>
                                <td>
                                    <asp:Label  CssClass="busqueda" ID="Label5" runat="server" Text="Descuento:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSumaDesc" CssClass="textos" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                              </tr>
                            <tr>
                                <td>
                                    <asp:Label  CssClass="busqueda" ID="Label6" runat="server" Text="Iva:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSumaIva" CssClass="textos" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label CssClass="busqueda"  ID="Label4" runat="server" Text="Sub Total:"></asp:Label>
                                </td>
                                     <td>
                                    <asp:TextBox ID="txtSumaSubTo" CssClass="textos" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                              </tr>
                            <tr>
                                <td>
                                    <asp:Label CssClass="busqueda" ID="Label3" runat="server" Text="Total:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSumaTotal" CssClass="textos" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                                
                            </tr>
                            
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                               <tr>
                                <td >
                                    <asp:Button ID="btnGuardarDetalle" Class="btnFactura1" visible="false" runat="server" OnClick="GuardarDetalle_Click"  Text="Salvar" />
                                </td>
                                <td >
                                    <asp:Button ID="Cancelar" Class="btnFactura1"  runat="server" onclick="Cancelar_Click" UseSubmitBehavior="False" Text="Cancelar" />
                                    <asp:Button ID="Confirmar"  Class="btnFactura1" runat="server" OnClientClick="return confirm('¿Desea guardar la factura?');" OnClick="Confirmar_Click" Text="Confirmar" />
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
            </table>
        </div>
    </form>
</asp:Content>
