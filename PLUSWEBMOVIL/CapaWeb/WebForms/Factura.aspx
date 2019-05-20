<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="CapaWeb.WebForms.Factura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function validarCamposArticulo(){
            var BuscarArticulo = document.getElementById("<%= BuscarArticulo.ClientID %>").value;
            var precio = document.getElementById("<%= precio.ClientID %>").value;
            var respuesta;
            if (BuscarArticulo == null || BuscarArticulo == "") {
                alert("Ingrese el artículo");
                respuesta =  false;
            } else {             
                respuesta = true;
            }

            if (precio == null || precio == "") {
                alert("Ingrese el artículo");
                respuesta = false;
            } else {
                respuesta = true;
            }

            return respuesta
        }

        function FechaActual() {

            var fechaActual = document.getElementById("<%= fecha.ClientID %>").value;

        }
    </script>


    <form id="form1" class="forms-sample" runat="server" method="post">
        
       
        <div style="align-items: center">
            <table>
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
                                    <div align="left">Fecha:</div>
                                </td>
                                <td>

                                    <asp:TextBox ID="fecha" type="date" onkeyup="FechaActual();" Width="202" required="required" value="today" runat="server"></asp:TextBox>

                                </td>

                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">F. Pago:</div>
                                </td>
                                <td>

                                    <asp:DropDownList class="textos" Width="252" name="cod_fpago" ID="cod_fpago" runat="server">
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

                                        <asp:DropDownList class="textos" name="cod_moneda" Width="210" ID="cod_moneda" runat="server">
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
                                 <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div align="left">% Descuento:</div>
                                </td>
                                <td valign="top">
                                    <label>
                                        <asp:TextBox ID="porc_descto" class="textos" value="0" Width="205" name="porc_descto" runat="server"></asp:TextBox>

                                    </label>
                                </td>
                            </tr>
                           
                            <tr>
                                <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div align="left">Observaciones:</div>
                                </td>
                                <td colspan="5">
                                    <asp:TextBox ID="area" runat="server" Width="880" class="textos" TextMode="MultiLine" cols="100" Rows="3"></asp:TextBox>
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
                                    <asp:TextBox ID="precio"   CssClass="textos"  type="number" min="0.01" step="0.01" value="0" runat="server" Width="100px"></asp:TextBox>
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

                                        <asp:GridView ID="gvProducto" runat="server" AutoGenerateColumns="False"
                                            CellPadding="4" BackColor="#DD6D29"
                                            OnSelectedIndexChanged="gvProducto_SelectedIndexChanged" PageSize="1000">
                                            <RowStyle BackColor="#EFF3FB" />
                                            <Columns>
                                                <asp:BoundField DataField="cod_articulo" HeaderText="Código" />
                                                <asp:BoundField DataField="nom_articulo" HeaderText="Descripción" />                                                
                                                <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                                <asp:BoundField DataField="precio_unit" HeaderText="Precio" />
                                                <asp:BoundField DataField="subtotal"    HeaderText="Subtotal" />
                                                <asp:BoundField DataField="detadescuento" HeaderText="% Descto" />
                                                <asp:BoundField DataField="detaiva" HeaderText="IVA" />
                                                <asp:BoundField DataField="total" HeaderText="Total" />
                                                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="botones" CommandName="Select" HeaderText="" ShowHeader="True" Text="Eliminar" >
                                                <ControlStyle CssClass="botones" />
                                                </asp:ButtonField>
                                            </Columns>

                                            <HeaderStyle BackColor="#DD6D29" Font-Bold="True" ForeColor="White" />

                                            <AlternatingRowStyle BackColor="White" />

                                        </asp:GridView>
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
                            <tr>
                                <td>
                                    <asp:Button ID="GuardarDetalle" runat="server" OnClick="GuardarDetalle_Click"  Text="Salvar" />
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
