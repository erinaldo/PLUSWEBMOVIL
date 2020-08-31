<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="Site1.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="CapaWeb.WebForms.Factura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;&nbsp;&nbsp;
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
            var BuscarArticulo = document.getElementById("<%= BuscarArticulo.ClientID %>").value;
            var precio = document.getElementById("<%= precio.ClientID %>").value;
            var cantidad = document.getElementById("<%= cantidad.ClientID %>").value;
            var porcdescto = document.getElementById("<%= porcdescto.ClientID %>").value;
            var area = document.getElementById("<%= area.ClientID %>").value;
            var txt = document.getElementById("<%= area.ClientID %>").value;
            var txtcorreo = document.getElementById("<%= txtcorreo.ClientID %>").value;
           var  lbl_tipofac = document.getElementById("<%= lbl_tipofac.ClientID %>").value;
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
            if (precio == null || precio == "" ) {
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
                                    <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;<a href="BuscarFacturas.aspx">Facturas Venta</a>---&gt;Nuevo</td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                <tr>
                    <td>
                       
                        <asp:Label ID="lblAyuda" runat="server"  CssClass="Titulo" Text="Facturas de venta"></asp:Label>
                        
                        </td>
                </tr>
                 <tr>
                    <td>
                         <asp:Label ID="Label1" runat="server"  CssClass="Subtitulo2" Text="Sucursal: "></asp:Label>
                        <asp:Label ID="lbl_cod_suc_emp" runat="server"  CssClass="Subtitulo2" Text=""></asp:Label>
                        <asp:Label ID="lbl_suc_emp" runat="server"  CssClass="Subtitulo2" Text=""></asp:Label>
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
                                    <asp:Label ID="cod_tit" required="required" runat="server" Text="" Visible="False"></asp:Label>
                                </td>
                            </tr>

                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Cliente:</div>
                                </td>

                                <td class="textos">
                                    <asp:TextBox ID="dniCliente" required="required" placeholder="Buscar..." Width="202" runat="server" AutoPostBack="True" OnTextChanged="dniCliente_TextChanged"></asp:TextBox>


                                </td>
                                <td class="textos" colspan="2" align="left">
                                    <asp:TextBox required="required" ID="nombreCliente" class="textos" Width="325" MaxLength="50" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                                 <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Teléfono:</div>
                                </td>
                                <td class="textos">
                                    <asp:TextBox required="required" ID="fonoCliente" class="textos" Width="206" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr valign="top">
                                    <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Correo:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:TextBox ID="txtcorreo"  type="email"  title="correo@gmail.com"  Width="202" class="textos" runat="server"></asp:TextBox>

                                    </label>
                                </td>
                                
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Fecha:</div>
                                </td>
                                <td>

                                    <asp:TextBox ID="fecha" type="date"  Width="248" required="required" AutoPostBack="True" runat="server" OnTextChanged="fecha_TextChanged"></asp:TextBox>

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
                                        <asp:DropDownList class="textos" name="serie_docum" Width="210" ID="serie_docum" AutoPostBack="True" runat="server" OnSelectedIndexChanged="serie_docum_SelectedIndexChanged">
                                        </asp:DropDownList>

                                    </label>
                                </td>
                            </tr>
                           <tr>
                               <td></td>
                                <td valign="top">
                                    <label>
                                        <asp:TextBox ID="porc_descto" visible="false" class="textos" value="0" Width="202" name="porc_descto" runat="server"></asp:TextBox>

                                    </label>
                                </td>
                                  <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div align="left">TRX:</div>
                                </td>
                                <td valign="top">
                                    <asp:Label ID="lbl_tipofac" class="textos" runat="server" Text=""></asp:Label>
                                    <label>
                                       
                                        <asp:Label ID="lbl_trans" class="textos"  Width="202" ReadOnly="true" runat="server"></asp:Label>
                                    </label>
                                </td>
                                <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div align="left">Sucursal:</div>
                                </td>
                                <td>
                                    <asp:Label ID="suc_cliente" runat="server" class="textos" Visible="false" Text=""></asp:Label>
                                      <asp:Label ID="sucursal_lbl" runat="server" class="textos" ></asp:Label>
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
                                <td>
                                    <asp:Label ID="lbl_adjunto" Visible ="false" runat="server" class="busqueda" Text="Adjuntar Documento:"></asp:Label></td>
                                <td><asp:FileUpload ID="FileUpload1" runat="server" Visible ="false" /></td>
                                <td>
                                    <asp:Button ID="btn_cargar_doc" runat="server" Visible ="false" CssClass="botones" Text="Cargar Archivo" OnClick="btn_cargar_doc_Click" /></td>
                                 <td>  
                                  <asp:Label ID="LblNombreArchivo" class="busqueda" runat="server"></asp:Label>
                                </td>
                                
                            </tr>
                            
                            <tr>
                                
                                <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div align="left">Observaciones:</div>
                                </td>
                                <td colspan="5">
                                    <asp:TextBox ID="area" runat="server" Width="900"  class="textos" MaxLength="250" TextMode="MultiLine" AutoPostBack="True" onKeyDown="cuentaCaracteres()" onKeyUp="cuentaCaracteres()" cols="150" Rows="3" OnTextChanged="area_TextChanged"></asp:TextBox>
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
                                    <asp:Label ID="Label12" class="busqueda" runat="server" visible="false">linea</asp:Label></td>
                                
                                <td class="busqueda">
                                    <asp:Label ID="Articulo" class="busqueda" runat="server" Text="Label">Articulo</asp:Label></td>
                                <td>
                                    <asp:Label ID="Producto" class="busqueda" runat="server" Text="Label">Descripción</asp:Label>
                                </td>
                                 <td>
                                    <asp:Label ID="lbl_desc2" class="busqueda" runat="server" Text="Label">Descripción</asp:Label>
                                </td>
                                
                                <td>
                                    <asp:Label ID="lblCantidad" runat="server" class="busqueda" Text="Label">Cantidad</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="pvp" runat="server" class="busqueda" Text="Label">Precio</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_cbx_dsc" runat="server" class="busqueda" Text="Label">Descuento</asp:Label>
                                </td>
                                <td style="width: 150px">
                                    <asp:Label ID="lbl_valor_dsc" runat="server" class="busqueda" Text="Label">Valor Dscto</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_prc_dsc" runat="server" class="busqueda" Text="Label">% Dscto</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" class="busqueda" Text="Label">% IVA</asp:Label>
                                </td>
                              
                            </tr>
                            <tr>
                                 <td>
                                    <asp:TextBox ID="txt_linea" CssClass="textos" visible="false" runat="server"></asp:TextBox>
                                  </td>

                                <td>
                                    <asp:TextBox ID="BuscarArticulo" runat="server" placeholder="Buscar..."  size="20" MaxLength="50" AutoPostBack="True" OnTextChanged="BuscarArticulo_TextChanged"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="articulos" CssClass="textos" runat="server" Rows="2" Size="40" ReadOnly="true"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="articulo_2" CssClass="textos" Rows="2" Size="40" runat="server"></asp:TextBox>
                                    </td>
                                
                                <td>
                                    
                                    <asp:TextBox ID="cantidad" CssClass="textos"   step="0.001" type="number" value="1" Width="60px" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="precio"   CssClass="textos"  type="number" step="any"   value="0" runat="server" Width="100px"></asp:TextBox>
                                </td>
                                <td>
                                <asp:DropDownList ID="cbx_tipo_dsc"  class="textos"  AutoPostBack="true"  runat="server" OnSelectedIndexChanged="cbx_tipo_dsc_SelectedIndexChanged" >
                                  <asp:ListItem Value="P">Porcentaje</asp:ListItem>
                                  <asp:ListItem Value="V">Valor</asp:ListItem>
                               </asp:DropDownList>
                                    </td>
                                <td style="width: 122px">
                                    <asp:TextBox ID="txt_valor_dscl" CssClass="textos" type="number" step="any" value="0"  Width="100px" runat="server"></asp:TextBox>
                                </td>
                                 <td>
                                    <asp:TextBox ID="porcdescto" CssClass="textos" min="0" step="0.000001" type="number" value="0"  Width="60px" runat="server"></asp:TextBox>
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
                                          CellPadding="2"  BackColor="White" BorderColor="#DD6D29" BorderStyle="None" BorderWidth="0px" CellSpacing="1" OnItemCommand="gv_Producto_ItemCommand" PageSize="2000">


                                        <Columns>
                                             <asp:TemplateColumn HeaderText="TRX" Visible="false" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="nro_trans" runat="server" class="textos" Text='<%#Eval("nro_trans") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
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
                                        <HeaderStyle BackColor="#DD6D29" CssClass="busqueda" Font-Bold="True" ForeColor="White" />
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
                        <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#0E748A">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel2" runat="server" Height="250px" Width="100%" ScrollBars="Auto">
                                     <asp:DataGrid ID="gv_descuentos" runat="server" 
                                        
                                        AutoGenerateColumns="False" AllowPaging="True" class="table table-hover"
                                         AllowSorting="True" ShowFooter="True"
                                          CellPadding="2"  BackColor="White" BorderColor="#DD6D29" BorderStyle="None" BorderWidth="0px" CellSpacing="1" OnItemCommand="gv_Producto_ItemCommand" PageSize="200">


                                        <Columns>
                                            

                                            <asp:TemplateColumn HeaderText="Código" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="cod_concepto" runat="server" class="textos" Text='<%#Eval("cod_concepto") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="Descripción">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="nom_concepto" runat="server" class="textos" Text='<%#Eval("nom_concepto") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                                 <asp:TemplateColumn HeaderText="CDIAN">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="signo" runat="server" class="textos" Text='<%#Eval("signo") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Tipo Descto">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="detalle" runat="server" class="textos" Text='<%#Eval("detalle") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="%">
                                                <ItemTemplate>
                                                    <span style="float: right;">
                                                        <asp:Label ID="porcen_desc" runat="server" class="textos" Text='<%#Eval("porcen_desc") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="Monto">
                                                <ItemTemplate> 
                                                    <span style="float: right;">
                                                        <asp:Label ID="total_for" runat="server" class="textos"  Text='<%#Eval("total_for") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>                                                                                          
                                        </Columns>

                                        <FooterStyle BackColor="White" ForeColor="#00000f" />
                                        <HeaderStyle BackColor="#DD6D29" CssClass="busqueda" Font-Bold="True" ForeColor="White" />
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
                        <table border="1" align="right" cellpadding="0" cellspacing="0" bordercolor="#0E748A">
                          
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
                                    <asp:Label CssClass="busqueda"  ID="Label4" runat="server" Text="Sub Total:"></asp:Label>
                                </td>
                                     <td>
                                    <asp:TextBox ID="txtSumaSubTo" CssClass="textos" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                              </tr>
                            <tr>
                                <td>
                                    <asp:Label  CssClass="busqueda" ID="Label15" runat="server" Text="Descuento:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSumaDesc" CssClass="textos" ReadOnly="true"  runat="server"></asp:TextBox>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label  CssClass="busqueda" ID="Label8" runat="server" Text="Base Iva:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBaseIva19" CssClass="textos" ReadOnly="true"  runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label  CssClass="busqueda" ID="Label6"  runat="server" Text="Iva:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSumaIva" CssClass="textos"  ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                              <tr>
                                <td>
                                    <asp:Label  CssClass="busqueda" ID="Label5" runat="server" Text="Descuento"></asp:Label>
                                </td>
                                <td>
                                     <asp:ImageButton ID="btn_desc" onclick="btn_desc_Click"  ImageAlign="left" src="../Tema/imagenes/add.png"  runat="server" />
                               
                                </td>
                              </tr>
                             
                              
                            <tr>
                                <td>
                                    <asp:Label CssClass="busqueda" ID="Label13" runat="server" Text="Descto Global:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_descuento_apli" CssClass="textos" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                                
                            </tr>
                             
                            <tr>
                                <td>
                                    <asp:Label CssClass="busqueda" ID="Label14" runat="server" Text="Cargo Global:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_cargos" CssClass="textos" ReadOnly="true" runat="server"></asp:TextBox>
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
