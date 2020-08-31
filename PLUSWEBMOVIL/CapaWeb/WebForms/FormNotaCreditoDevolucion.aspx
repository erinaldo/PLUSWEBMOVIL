<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site1.Master" AutoEventWireup="true" CodeBehind="FormNotaCreditoDevolucion.aspx.cs" Inherits="CapaWeb.WebForms.FormNotaCreditoDevolucion" %>
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
            var txt_Codigo = document.getElementById("<%= txt_Codigo.ClientID %>").value;
            var txt_Precio = document.getElementById("<%= txt_Precio.ClientID %>").value;
            var txt_Cantidad = document.getElementById("<%= txt_Cantidad.ClientID %>").value;
            var porcdescto = document.getElementById("<%= txt_Desc.ClientID %>").value;
            
            var descripcion = document.getElementById("<%= txt_Descripcion.ClientID %>").value;
            var txtcorreo = document.getElementById("<%= txtcorreo.ClientID %>").value;
           
            var respuesta;
            if (txt_Codigo == null || txt_Codigo == "") {
                alert("Ingrese el código");
                respuesta =  false;
            } else {             
                respuesta = true;
            }
           
            if (txt_Cantidad == null || txt_Cantidad == "" || txt_Cantidad <= 0) {
                alert("Ingrese cantidad");
                respuesta = false;
            } else {
                respuesta = true;
            }
            if (descripcion == null || descripcion == "" || descripcion <= 0) {
                alert("Ingrese descripción");
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
            if (txt_Precio == null || txt_Precio == "") {
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
alert("La Nota de Crédito ya ha sido enviado, espere por favor.");
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
                                    <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;<a href="FormBuscarNotaCredito.aspx">Nota de Crédito</a>---&gt;Nuevo</td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                <tr>
                    <td>
                        
                        
                        </td>
                </tr>
                <tr>
                    <td valing="center">
                        <p class="Subtitulo2" >Nota de Crédito por: Devolución de parte de los bienes; no aceptación de partes del servicio</p>
                    </td>
                </tr>
                   <tr>
                    <td>
                         <asp:Label ID="Label11" runat="server"  CssClass="Subtitulo2" Text="Sucursal: "></asp:Label>
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
                                    <asp:TextBox ID="dniCliente" required="required" placeholder="Buscar..." Width="202" title="Ingrese el cliente" runat="server" AutoPostBack="True" OnTextChanged="dniCliente_TextChanged"></asp:TextBox>


                                </td>
                                <td class="textos" colspan="2">

                                    <asp:TextBox required="required" ID="nombreCliente" class="textos" Width="355" MaxLength="50" runat="server" ReadOnly="true"></asp:TextBox>
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
                                   
                                    <asp:TextBox ID="fecha" type="date"  Width="248" required="required"  runat="server" OnTextChanged="fecha_TextChanged" AutoPostBack="true" ></asp:TextBox>

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
                                        <asp:DropDownList class="textos" name="serie_docum" AutoPostBack="true" Width="210" ID="serie_docum" runat="server" OnSelectedIndexChanged="serie_docum_SelectedIndexChanged">
                                        </asp:DropDownList>

                                    </label>
                                </td>
                            </tr>
                           <tr>
                               <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div runat="server" align="left">% Descuento:</div>
                                </td>
                                <td valign="top">
                                    <label>
                                        <asp:TextBox ID="porc_descto" class="textos" value="0" Width="202" name="porc_descto" runat="server"></asp:TextBox>

                                    </label>
                                </td>
                                <td class="busqueda">
                                    <asp:Label align="left" ID="lbl_fac1"  Width="100" runat="server" Text="Facturas:"></asp:Label>
                                  </td>
                               
                               
                               <td>
                                   <asp:Button ID="btn_Fac" onclick="btn_Fac_Click" CssClass="botones"  Width="125" runat="server" Text="Buscar Factura" />
                                  </td>
                               <td class="busqueda">
                                    <asp:Label align="center" Visible="false" ID="lbl_nro_factura"  Width="100" runat="server" Text="Nro Factura:"></asp:Label>
                                  </td>
                                <td>
                                    <asp:TextBox ID="txt_nro_factura" Visible="false" class="textos" Enabled="false" runat="server" Width="202px"></asp:TextBox>
                                </td>
                               </tr>
                            <tr>
                                
                                <td class="busqueda" align="left" valign="top" nowrap="nowrap">
                                    <asp:Label align="center" Visible="False" ID="lbl_subtotal_factura"   Width="124px" runat="server" Text="Subtotal Factura:"></asp:Label>
                                  </td>
                                <td>
                                    <asp:TextBox ID="txt_subtotal_factura" Visible="false" Enabled="false" class="textos" runat="server" Width="200px"></asp:TextBox>
                                </td>
                                <td class="busqueda" align="left" valign="top" nowrap="nowrap">
                                    <asp:Label align="center" ID="lbl_descuento_factura" Visible="False"  Width="129px" runat="server" Text="Descuento Factura:"></asp:Label>
                                  </td>
                                <td>
                                    <asp:TextBox ID="txt_descuento_factura" Visible="false" Enabled="false" class="textos" runat="server" Width="247px"></asp:TextBox>
                                </td>
                                <td class="busqueda">
                                    <asp:Label align="center" ID="lbl_iva_factura" Visible="false" Width="100" runat="server" Text="Iva Factura:"></asp:Label>
                                  </td>
                                <td>
                                    <asp:TextBox ID="txt_iva_factura" Enabled="false" Visible="false" class="textos" runat="server" Width="201px"></asp:TextBox>
                                </td>
                                 
                             </tr>
                            <tr>
                                <td class="busqueda">
                                    <asp:Label align="center" ID="lbl_total_factura" Visible="false"  Width="100" runat="server" Text="Total Factura:"></asp:Label>
                                  </td>
                                <td>
                                    <asp:TextBox ID="txt_total_factura" Visible="false" Enabled="false" class="textos" runat="server" Width="200px"></asp:TextBox>
                                </td>
                                <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div align="left">TRX:</div>
                                </td>
                                <td valign="top">
                                    <label>
                                        <asp:Label ID="lbl_tiponc" class="textos" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="lbl_trans" class="textos"  Width="202" ReadOnly="true" runat="server"></asp:Label>
                                    </label>
                                </td>
                                <td class="busqueda">
                                    <asp:Label align="center" ID="lbl_trx_padre" Visible="false"  Width="100" runat="server" Text="TRX Factura:"></asp:Label>
                                  </td>
                                 <td>
                                   <asp:TextBox ID="txt_nro_trans_padre" Visible="false" Enabled="false" runat="server"></asp:TextBox>
                                     <asp:Label ID="lbl_tipo_fac"  class="textos"   runat="server" ></asp:Label>
                               </td>


                            </tr>
                            <tr>
                               <td>
                                   <asp:TextBox ID="txt_cod_docum" Visible="false" runat="server"></asp:TextBox>
                                  
                               </td>
                              <td>
                                  <asp:TextBox ID="txt_nro_docum" Visible="false" runat="server"></asp:TextBox>
                              </td>
                               <td>
                                   <asp:TextBox ID="txt_serie_docum" Visible="false" runat="server"></asp:TextBox>
                               </td>
                              
                                 <td>
                                   <asp:TextBox ID="txt_cantidad_pro" Visible="false" runat="server"></asp:TextBox>
                               </td>
                                 <td>
                                   <asp:TextBox ID="txt_saldo_factura" Visible="false" runat="server"></asp:TextBox>
                               </td>
                               </tr>
                             <tr>
                                <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div align="left">Sucursal:</div>
                                </td>
                                <td>
                                    <asp:Label ID="suc_cliente" runat="server" class="textos" Visible="false" Text=""></asp:Label>
                                    <asp:Label ID="sucursal_lbl" runat="server" class="textos" Text=""></asp:Label>
                                </td>
                            </tr>
                          
                            <tr>
                                
                                <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div align="left">Observaciones:</div>
                                </td>
                                <td colspan="5">
                                    <asp:TextBox ID="area" runat="server" Width="900"  class="textos" MaxLength="250" TextMode="MultiLine" onKeyDown="cuentaCaracteres()" onKeyUp="cuentaCaracteres()" cols="150" Rows="3" OnTextChanged="area_TextChanged"></asp:TextBox>
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

                        <div class="Subtitulo1">Detalle Nota de Crédito</div>
                    </td>
                </tr
                <tr>
                    <td>

                        <table border="0" id="AgregarObservacion"  align="center" >
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
                                       <asp:TextBox ID="txt_Codigo"  CssClass="textos" placeholder="Buscar..."  AutoPostBack="True" OnTextChanged="txt_Codigo_TextChanged" size="20" MaxLength="50" runat="server"></asp:TextBox>
                                </td>
                                <td >
                                    <asp:TextBox ID="txt_Descripcion" CssClass="textos" Size="40" ReadOnly="true" runat="server"></asp:TextBox>
                                 </td>
                                 <td >
                                    <asp:TextBox ID="txt_Descripcion2" CssClass="textos" Size="40" runat="server"></asp:TextBox>
                                 </td>
                                <td>
                                    <asp:TextBox ID="txt_Cantidad" CssClass="textos" min="1" step="0.01"  type="number" value="1" Width="60px"  runat="server"></asp:TextBox>
                                    
                                </td>
                                 <td>
                                    <asp:TextBox ID="txt_Precio" runat="server" CssClass="textos" type="number"   step="any" value="0" Width="100px" ></asp:TextBox>
                                    
                                </td>
                                 <td>
                                    <asp:TextBox ID="txt_Desc" CssClass="textos" min="0" step="0.01" ReadOnly="true" type="number" value="0"  Width="60px" runat="server"></asp:TextBox>
                                    
                                </td>
                                 <td>
                                    <asp:TextBox ID="txt_Iva" CssClass="textos" type="number" ReadOnly="true" Width="60px" runat="server"></asp:TextBox>
                                    
                                </td>
                                <td>
                                    <asp:Button ID="AgregarNC" onclick="AgregarNC_Click" runat="server" OnClientClick="return validarCamposArticulo();" CssClass="botones" Text="Agregar" />
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
                                             <asp:TemplateColumn HeaderText="linea" Visible="false" >
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

                        <hr />
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
                                    <asp:Label  CssClass="busqueda" ID="Label5" runat="server" Text="Descuento:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSumaDesc" CssClass="textos" ReadOnly="true" runat="server"></asp:TextBox>
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
                                    <asp:Label  CssClass="busqueda" ID="Label6"  runat="server" Text="Iva:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSumaIva" CssClass="textos"  ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                          <tr>
                                <td>
                                    <asp:Label  CssClass="busqueda" ID="Label9" runat="server" Text="Descuento"></asp:Label>
                                </td>
                                <td>
                                     <asp:ImageButton ID="btn_desc" onclick="btn_desc_Click"  ImageAlign="left" src="../Tema/imagenes/add.png"  runat="server" />
                               
                                </td>
                              </tr>
                             
                              
                            <tr>
                                <td>
                                    <asp:Label CssClass="busqueda" ID="Label10" runat="server" Text="Descto Global:"></asp:Label>
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
                                    <asp:Button ID="btnGuardarDetalle" Class="btnFactura1" visible="false" runat="server"   Text="Salvar" />
                                </td>
                                <td >
                                    <asp:Button ID="Cancelar" Class="btnFactura1" OnClick="Cancelar_Click"  runat="server"  UseSubmitBehavior="False" Text="Cancelar" />
                                    <asp:Button ID="Confirmar"  Class="btnFactura1" OnClick="Confirmar_Click" runat="server"  Text="Confirmar" />
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
