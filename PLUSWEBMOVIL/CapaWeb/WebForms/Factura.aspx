<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="CapaWeb.WebForms.Factura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">


        function validarCabecera() {

            var respuesta = false;
        }
        function FechaActual() {

            var fechaActual = document.getElementById("<%= fecha.ClientID %>").value;

        }
    </script>

    <form id="form1" class="forms-sample" runat="server">
        
       
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
                                    <asp:TextBox required="required" ID="nombreCliente" class="textos" size="40" MaxLength="50" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>

                            </tr>
                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Teléfono:</div>
                                </td>
                                <td class="textos">
                                    <asp:TextBox required="required" ID="fonoCliente" class="textos" size="27" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Fecha:</div>
                                </td>
                                <td>

                                    <asp:TextBox ID="fecha" type="date" onkeyup="FechaActual();" required="required" value="today" runat="server"></asp:TextBox>

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
                                    <div align="left">Vendedor:</div>
                                </td>
                                <td>

                                    <asp:DropDownList class="textos" name="cod_vendedor" ID="cod_vendedor" runat="server">
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
                                    <div align="left">F. Pago:</div>
                                </td>
                                <td>

                                    <asp:DropDownList class="textos" name="cod_fpago" ID="cod_fpago" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">O.Compra:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:TextBox ID="ocompra" name="ocompra" class="textos" runat="server"></asp:TextBox>

                                    </label>
                                </td>

                            </tr>
                            <tr valign="top">
                                <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div align="left">N° Pedido:</div>
                                </td>
                                <td valign="top">
                                    <label>
                                        <asp:TextBox ID="nro_pedido" class="textos" name="nro_pedido" runat="server"></asp:TextBox>

                                    </label>
                                </td>
                                <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div align="left">% Descuento:</div>
                                </td>
                                <td valign="top">
                                    <label>
                                        <asp:TextBox ID="porc_descto" class="textos" value="0" name="porc_descto" runat="server"></asp:TextBox>

                                    </label>
                                </td>


                            </tr>
                            <tr>
                                <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div align="left">Observaciones:</div>
                                </td>
                                <td colspan="4">


                                    <asp:TextBox ID="area" runat="server" Width="500" class="textos" TextMode="MultiLine" cols="100" Rows="3"></asp:TextBox>

                                    <div class="textos2" align="left">Caracteres disponibles: <b><span id="myCounter">250</span></b></div>
                                </td>
                            </tr>

                            <tr valign="top">
                                <td>

                                    <asp:Button ID="GuardarCabecera" CssClass="botones" OnClick="GuardarCabecera_Click" runat="server" Text="Aceptar" />
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
                                    <asp:Label ID="pvp" runat="server" class="busqueda" Text="Label">P.V.P</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCantidad" runat="server" class="busqueda" Text="Label">Cantidad</asp:Label>
                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:TextBox ID="BuscarArticulo" runat="server"  placeholder="Buscar..."  size="20" MaxLength="50" AutoPostBack="True" OnTextChanged="BuscarArticulo_TextChanged"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="articulos" CssClass="textos" runat="server" Rows="2" Size="40" ReadOnly="true"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="precio" CssClass="textos" type="number" min="0.00" step="0.01" runat="server" Width="100px"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="cantidad" CssClass="textos" type="number" value="1" Width="60px" runat="server"></asp:TextBox>

                                </td>

                                 <td>
                                    <asp:TextBox ID="iva" CssClass="textos" type="number" value="1" Width="60px" runat="server"></asp:TextBox>

                                </td>

                                <td>
                                    <asp:Button ID="AgregarProducto" CssClass="botones" runat="server" Text="Agregar" OnClick="AgregarProducto_Click" />
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
                                    <asp:Panel ID="Panel1" runat="server" Height="300px" Width="100%" ScrollBars="Auto">

                                        <asp:GridView ID="gvProducto" runat="server" AutoGenerateColumns="False"
                                            CellPadding="4" BackColor="#DD6D29"
                                            OnSelectedIndexChanged="gvProducto_SelectedIndexChanged" PageSize="1000">
                                            <RowStyle BackColor="#EFF3FB" />
                                            <Columns>
                                                <asp:BoundField DataField="cod_articulo" HeaderText="Código" />
                                                <asp:BoundField DataField="nom_articulo" HeaderText="Descripción" />
                                                <asp:BoundField DataField="porc_impuesto" HeaderText="% IVA" />
                                                <asp:BoundField DataField="precio" HeaderText="P.V.P" />
                                                <asp:BoundField DataField="valor_impu" HeaderText="I.V.A" />
                                                <asp:BoundField DataField="precio_total" HeaderText="Total" />
                                                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="botones" CommandName="Select" HeaderText="" ShowHeader="True" Text="Eliminar" />
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
            </table>
        </div>
    </form>
</asp:Content>
