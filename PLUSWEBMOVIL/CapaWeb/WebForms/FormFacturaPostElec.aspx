<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="FormFacturaPostElec.aspx.cs" Inherits="CapaWeb.WebForms.FormFacturaPostElec" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script type="text/javascript">

        function cuentaCaracteres() {
            var cantidadCaracteresPermitidos = 250;
            var cantidadCaracteres = document.getElementById("<%= area.ClientID %>").value.length;
            var caracteresRestantes = cantidadCaracteresPermitidos - cantidadCaracteres;
            myCounter.innerHTML = caracteresRestantes;
            if (caracteresRestantes == 0) {
                document.getElementById("<%= area.ClientID %>").value = texto
            } else {
                 texto = document.getElementById("<%= area.ClientID %>").value
            }
        }

        function validarCamposArticulo(){
            var BuscarArticulo = document.getElementById("<%= txt_Codigo.ClientID %>").value;
            var precio = document.getElementById("<%= txt_Precio.ClientID %>").value;
            var cantidad = document.getElementById("<%= txt_Cantidad.ClientID %>").value;
            var porcdescto = document.getElementById("<%= txt_Desc.ClientID %>").value;
            var area = document.getElementById("<%= area.ClientID %>").value;
            var txt = document.getElementById("<%= area.ClientID %>").value;
             var txtcorreo = document.getElementById("<%= txtcorreo.ClientID %>").value;
            var n = txt.length;
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

            if (porcdescto < 0 || porcdescto == "" || porcdescto == null) {
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

      <script LANGUAGE="JavaScript">

var cuenta=0;

function enviado() { 
if (cuenta == 0)
{
cuenta++;
return true;
}
else 
{
alert("La Factura ya ha sido enviado, espere por favor.");
return false;
}
}
// -->
</script>

    <form id="form1" class="forms-sample" runat="server" method="post" onSubmit="return enviado()">
        
       
        <div style="align-items: center">
            <table>
                 <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0">
                                <tr>
                                    <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;<a href="BuscarFacturaPos.aspx">Facturas Venta POS</a>---&gt;Nuevo</td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                <tr>
                    <td>
                       
                        <asp:Label ID="lblAyuda" runat="server"  CssClass="Titulo" Text="Facturas de Venta POS"></asp:Label>
                        
                        </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lbl_error" CssClass="textos_error" runat="server" Text=""></asp:Label>
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
                                    <asp:TextBox ID="dniCliente" required="required" placeholder="Buscar..." size="28" runat="server" AutoPostBack="True" OnTextChanged="dniCliente_TextChanged"></asp:TextBox>


                                </td>
                                <td class="textos" colspan="2" align="right">
                                    <asp:Label ID="cod_tit" required="required" runat="server" Text="" Visible="False"></asp:Label>
                                    <asp:TextBox required="required" ID="nombreCliente" class="textos" size="44" MaxLength="50" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                                 <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Teléfono:</div>
                                </td>
                                <td class="textos">
                                    <asp:TextBox required="required" ID="fonoCliente" class="textos" size="28" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr valign="top">
                                    <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Correo:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:TextBox ID="txtcorreo"  type="email" required="required" title="correo@gmail.com"  Width="202" class="textos" runat="server"></asp:TextBox>

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
                                        <asp:TextBox ID="nro_pedido" class="textos" Width="202" name="nro_pedido" runat="server" ></asp:TextBox>

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
                                   <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div align="left">TRX:</div>
                                </td>
                                <td valign="top">
                                    <label>
                                       
                                        <asp:Label ID="lbl_trans" class="textos"  Width="202" ReadOnly="true" runat="server"></asp:Label>
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
                                    <asp:TextBox ID="area" runat="server" Width="900"  class="textos" MaxLength="250" TextMode="MultiLine" onKeyDown="cuentaCaracteres()" onKeyUp="cuentaCaracteres()" AutoPostBack="True" cols="150" Rows="3" OnTextChanged="area_TextChanged"></asp:TextBox>
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

                          <asp:Label ID="lbl_validacion" visible="false" class="Subtitulo2" runat="server" Text=""></asp:Label>
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
                                    <asp:Label ID="Label13" class="busqueda" Visible="false" runat="server" Text="Label"></asp:Label></td>
                                 <td class="busqueda">
                                    <asp:Label ID="lblCod" class="busqueda" runat="server" Text="Label">Código</asp:Label></td>
                                
                                 <td class="busqueda">
                                    <asp:Label ID="lblDes" class="busqueda" runat="server" Text="Label">Descripción</asp:Label></td>
                                 <td class="busqueda">
                                    <asp:Label ID="Label12" class="busqueda" runat="server" Text="Label">Descripción</asp:Label></td>
                                 <td class="busqueda">
                                    <asp:Label ID="lblCan" class="busqueda" runat="server" Text="Label">Cantidad</asp:Label></td>
                                 <td class="busqueda">
                                    <asp:Label ID="lblPre" class="busqueda" runat="server" Text="Label">Precio</asp:Label></td>
                                 <td class="busqueda">
                                    <asp:Label ID="Label1" class="busqueda" runat="server" Text="Label">% Descto</asp:Label></td>
                                 <td class="busqueda">
                                    <asp:Label ID="Label2" class="busqueda" runat="server" Text="Label">% IVA</asp:Label></td>
                                
                            </tr>
                            <tr>
                                 <td>
                                    <asp:TextBox ID="txt_linea" CssClass="textos" visible="false" runat="server"></asp:TextBox>
                                  </td>
                               <td>
                                       <asp:TextBox ID="txt_Codigo"  CssClass="textos" placeholder="Buscar..."  AutoPostBack="True" OnTextChanged="BuscarArticulo_TextChanged" size="20" MaxLength="50" runat="server"></asp:TextBox>
                                </td>
                                <td >
                                    <asp:TextBox ID="txt_Descripcion" CssClass="textos" Size="40" ReadOnly="true" runat="server"></asp:TextBox>
                                 </td>
                                <td >
                                    <asp:TextBox ID="txt_Descripcion2" CssClass="textos" Size="40"  runat="server"></asp:TextBox>
                                 </td>
                                <td>
                                    <asp:TextBox ID="txt_Cantidad" CssClass="textos" min="1" step="0.01"  type="number" value="1" Width="60px"  runat="server"></asp:TextBox>
                                    
                                </td>
                                 <td>
                                    <asp:TextBox ID="txt_Precio" CssClass="textos" type="number"   step="any" value="0" Width="100px" runat="server" ></asp:TextBox>
                                    
                                </td>
                                 <td>
                                    <asp:TextBox ID="txt_Desc" CssClass="textos" min="0" step="0.01"  type="number" value="0"  Width="60px" runat="server"></asp:TextBox>
                                    
                                </td>
                                 <td>
                                    <asp:TextBox ID="txt_Iva" CssClass="textos" type="number" ReadOnly="true" Width="60px" runat="server"></asp:TextBox>
                                    
                                </td>
                                <td>
                                    <asp:Button ID="AgregarNC" onclick="AgregarProducto_Click" runat="server" OnClientClick="return validarCamposArticulo();" CssClass="botones" Text="Agregar" />
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
                                                <asp:TemplateColumn HeaderText="TRX" Visible="false" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="linea" runat="server" class="textos" Text='<%#Eval("linea") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

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

                                            <asp:TemplateColumn HeaderText="Descripción">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="nom_articulo2" runat="server" class="textos" Text='<%#Eval("nom_articulo2") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="Cantidad">
                                                <ItemTemplate>
                                                    <span style="float: right;">
                                                        <asp:Label ID="cantidad" runat="server" class="textos" Text='<%#Eval("cantidad",  "{0:N}") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="Precio">
                                                <ItemTemplate>
                                                    <span style="float: right;">
                                                        <asp:Label ID="precio_unit" runat="server" class="textos" Text='<%#Eval("precio_unit", "{0:N}") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="Sub total">
                                                <ItemTemplate> 
                                                    <span style="float: right;">
                                                        <asp:Label ID="subtotal" runat="server" class="textos"  Text='<%#Eval("subtotal", "{0:N}") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Descto">
                                                <ItemTemplate>
                                                    <span style="float: right;">
                                                        <asp:Label ID="detadescuento" runat="server" class="textos" Text='<%#Eval("detadescuento", "{0:N}") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                           <asp:TemplateColumn HeaderText="Base IVA">
                                                <ItemTemplate>
                                                    <span style="float: right;">
                                                        <asp:Label ID="baseIva" runat="server" class="textos" Text='<%#Eval("base_iva", "{0:N}") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="% IVA">
                                                <ItemTemplate>
                                                    <span style="float: right;">
                                                        <asp:Label ID="porcIva" runat="server" class="textos" Text='<%#Eval("porc_iva", "{0:N}") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                             <asp:TemplateColumn HeaderText="IVA">
                                                <ItemTemplate>
                                                    <span style="float: right;">
                                                        <asp:Label ID="detaiva" runat="server" class="textos" Text='<%#Eval("detaiva", "{0:N}") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Total">
                                                <ItemTemplate>
                                                    <span style="float: right;">
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
                                        <HeaderStyle BackColor="#DD6D29" Font-Bold="True" CssClass="busqueda" ForeColor="White" />
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
                                    <asp:Label  CssClass="busqueda" ID="Label7" runat="server" Text="Impuestos:"></asp:Label>
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnImpuestos" OnClick="btnImpuestos_Click" ImageAlign="left" src="../Tema/imagenes/search.png"  runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label  CssClass="busqueda" ID="Label6" Visible="false" runat="server" Text="Iva:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSumaIva" CssClass="textos" Visible="false" ReadOnly="true" runat="server"></asp:TextBox>
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
                                    <asp:Label  CssClass="busqueda" ID="Label8" runat="server" Text="Base Iva:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBaseIva19" CssClass="textos" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label  CssClass="busqueda" ID="Label9" Visible="false" runat="server" Text="Base Iva 5%:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBase15" CssClass="textos" Visible="false" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label  CssClass="busqueda" ID="Label10" runat="server" Text="Iva:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIva19" CssClass="textos" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label  CssClass="busqueda" ID="Label11" Visible="false" runat="server" Text="Iva 5%:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIva15" CssClass="textos" Visible="false" ReadOnly="true" runat="server"></asp:TextBox>
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
                            <tr  aling="center">
                                
                                    <td aling="center">


                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                        <asp:Button ID="btn_Pagos"  Class="btnFactura1" runat="server" OnClick="btn_Pagos_Click" Text="Medios Pago" />
                                   </td>
                            </tr>
                               <tr>
                                <td >
                                    <asp:Button ID="btnGuardarDetalle" Class="btnFactura1" visible="false" runat="server" OnClick="GuardarDetalle_Click"  Text="Salvar" />
                      
                                    <asp:Button ID="Cancelar" Class="btnFactura1"  runat="server" onclick="Cancelar_Click" UseSubmitBehavior="False" Text="Cancelar" />
                                    <asp:Button ID="Confirmar"  Class="btnFactura1" runat="server"  OnClick="Confirmar_Click" Text="Confirmar" />
                                    
                               
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
