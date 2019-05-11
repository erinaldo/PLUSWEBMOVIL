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
    <tr>
        <td>

    <tr>
        <td>

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
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="mensaje" name="mensaje" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    
                    <tr valign="top">
                        <td align="right" nowrap="nowrap" class="busqueda">
                            <div align="left">Doc. Ide. cliente:</div>
                        </td>
                        
                        <td class="textos">
                            <asp:TextBox ID="dniCliente" required="required" placeholder="Cédula" runat="server" AutoPostBack="True" OnTextChanged="dniCliente_TextChanged"></asp:TextBox>
                           
                            <asp:Button ID="Button3" runat="server" class="botones" Text="Buscar todos" OnClientClick="window.open('./BuscarCliente.aspx','Buscar Cliente', 'top=100,width=800 ,height=600, left=400');"  />
                        </td>
                        <td class="textos" colspan="2">
                            <asp:Label ID="cod_tit" required="required" runat="server" Text="" Visible="False"></asp:Label>
                            <asp:TextBox required="required" ID="nombreCliente" class="textos" size="40" maxlength="50"   runat="server" ReadOnly="true"></asp:TextBox>
                        </td>

                    </tr>
                    <tr valign="top">
                        <td align="right" nowrap="nowrap" class="busqueda">
                            <div align="left">Fecha:</div>
                        </td>
                        <td>

                            <asp:TextBox ID="fecha" type="date" onkeyup="FechaActual();" required="required" value="today" runat="server"></asp:TextBox>

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
                                <asp:TextBox ID="ocompra"  name="ocompra" class="textos" runat="server"></asp:TextBox>
                                
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
                                <asp:TextBox ID="porc_descto" class="textos" value="0" name="porc_descto" runat="server"></asp:TextBox>
                               
                            </label>
                        </td>
                    </tr>


                    <tr>
                        <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                            <div align="left">Observaciones:</div>
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="area" runat="server" TextMode="MultiLine" class="textos" cols="500" rows="3"></asp:TextBox>

                            <div class="textos2" align="left">Caracteres disponibles: <b><span id="myCounter">250</span></b></div>
                        </td>
                       

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
                    <table border="0" align="center"  cellpadding="0" cellspacing="0" id="MostrarDetalle">
                        <tr valign="top">
                            <td class="busqueda">Articulo:</td>
                            <td>
                                <div align="center">
                                    <asp:TextBox ID="BuscarArticulo" visible="false" placeholder="codigo/articulo" runat="server" size="40" maxlength="50" AutoPostBack="True" OnTextChanged="BuscarArticulo_TextChanged"></asp:TextBox>
                                    
                                </div>
                                
                            </td>
                            <td>
                                
                                <asp:Button ID="Button4" CssClass="botones" visible="false" runat="server" Text="Buscar Todos" OnClientClick="window.open('./BuscarArticulo.aspx','MiPagina', 'top=200,width=900 ,height=400, left=350');"  />
                            </td>
                        </tr>
                    </table>
                    </br>
                    </br>
                    </br>
                    <table border="0" align="center" cellpadding="0" cellspacing="0" id="Tabla_Det5">
                        <tr >
                            
                            <td><div></div></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Producto" class="busqueda" visible="false" runat="server" Text="Label">Articulo</asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="pvp" runat="server" class="busqueda" visible="false" Text="Label">PVP</asp:Label>
                            </td>
                           </tr>
                        <tr>
                            
                             
                            <td>
                                <asp:TextBox ID="articulos" CssClass="textos" runat="server" visible="false" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="precio" CssClass="textos" runat="server" visible="false" ReadOnly="true"></asp:TextBox>
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

        </td>
    </tr>

        </td>
    </tr>

</asp:Content>
