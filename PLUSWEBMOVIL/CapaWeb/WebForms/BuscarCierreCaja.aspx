﻿<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="BuscarCierreCaja.aspx.cs" Inherits="CapaWeb.WebForms.BuscarCierreCaja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">


        function validarCampos() {
            var valor_inicioD = document.getElementById("<%= txt_valor_id.ClientID %>").value;
            var ingreso_facturas = document.getElementById("<%= txt_ingreso_facturas.ClientID %>").value;
            var ingreso_nventas = document.getElementById("<%= txt_ingreso_nventas.ClientID %>").value;
            var pefectivo_facturas = document.getElementById("<%= txt_pefectivo_facturas.ClientID %>").value;
            var pefectivo_otros = document.getElementById("<%=txt_pefectivo_otros.ClientID %>").value;
            var depositos = document.getElementById("<%= txt_depositos.ClientID %>").value;


            var respuesta;
            if (valor_inicioD == null || valor_inicioD == "" || valor_inicioD < 0) {
                alert("Ingrese el valor");
                respuesta = false;
            } else {
                respuesta = true;
            }

            if (ingreso_facturas == null || ingreso_facturas == "" || ingreso_facturas < 0) {
                alert("Ingrese el valor");
                respuesta = false;
            } else {
                respuesta = true;
            }

            if (ingreso_nventas < 0 || ingreso_nventas == "" || ingreso_nventas == null) {
                alert("Ingrese el valor");
                respuesta = false;
            } else {
                respuesta = true;
            }
            if (pefectivo_facturas == null || pefectivo_facturas == "" || pefectivo_facturas < 0) {
                alert("Ingrese el valor");
                respuesta = false;
            } else {
                respuesta = true;
            }
            if (pefectivo_otros == null || pefectivo_otros == "" || pefectivo_otros < 0) {
                alert("Ingrese el valor");
                respuesta = false;
            } else {
                respuesta = true;
            }
            if (depositos == null || depositos == "" || depositos < 0) {
                alert("Ingrese el valor");
                respuesta = false;
            } else {
                respuesta = true;
            }

            return respuesta
        }



    </script>
    <form id="form1" name="form1" class="forms-sample" runat="server" method="post">
        <div style="align-items: left">
            <table>
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0">
                            <tr>
                                <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;Cierre Caja</td>
                            </tr>
                        </table>
                    </td>

                </tr>
                <tr>
                    <td>

                        <asp:Label ID="lblAyuda" runat="server" CssClass="Titulo" Text="Cierre de Caja Diario"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                        <p class="Subtitulo2">
                            Para realizar&nbsp; nuevo Cierre de Caja 
                                <asp:Button ID="NuevoCierre" OnClick="NuevoCierre_Click" class="botones" runat="server" Text="AQUI" />
                        </p>
                    </td>
                </tr>


                <tr>
                    <td>
                        <asp:Label ID="txtAcceso" runat="server" Visible="false" CssClass="Titulo" Text="El Usuario registrado no tiene permiso para ejecutar estos procesos"></asp:Label>

                    </td>
                </tr>
                  <tr>
                    <td>
                        <asp:Label ID="lbl_error" runat="server"  CssClass="textos_error" Text=""></asp:Label>
                        
                        </td>
                    </tr>
                <tr>
                    <td>
                        <p class="Subtitulo1">Busque el registro deseado por:</p>
                    </td>
                </tr>
                <tr>
                    <td>

                        <table align="center">




                            <tr valign="top">
                                <td>
                                    <asp:Label CssClass="busqueda" ID="Label5" runat="server" Text="Fecha inicio:"></asp:Label></td>

                                <td>
                                    <asp:TextBox ID="fechainicio" type="date" Width="202" runat="server"></asp:TextBox>
                                </td>
                                  <td>
                                    <asp:Label CssClass="busqueda" ID="Label6" runat="server" Text="Fecha fin:"></asp:Label></td>

                                <td>
                                    <asp:TextBox ID="fechafin" type="date" Width="202" runat="server"></asp:TextBox>
                                </td>
                                </tr>
                            <tr valign="top">
                                 <td>
                                    <asp:Label ID="lbl_caja" CssClass="busqueda" runat="server" Text="Caja"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="cbx_caja_usuario" CssClass="textos" runat="server" Height="16px" Width="206px"></asp:DropDownList>
                                </td>
                              <td>
                                    <asp:Label ID="lbl_usu" CssClass="busqueda" runat="server" Text="Usuario"></asp:Label>
                              </td>
                                 <td>
                                    <asp:DropDownList ID="cbx_usuario" CssClass="textos" runat="server" Height="16px" Width="206px"></asp:DropDownList>
                                </td>
                                <td aling="rigth">
                                    <asp:Button ID="Buscar" runat="server" OnClick="Buscar_Click" class="botones" Text="Buscar" /></td>

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

                        <div class="Subtitulo1">Listado de Cierres de Caja</div>
                    </td>
                </tr>
                      <tr>
                    <td>
                        <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#0E748A">
                            <tr>
                                <td>
                                                                  
                                    <asp:DataGrid ID="Grid1" runat="server" onrowcreated="GriTipoUsuario_RowCreated"
                                        onrowcommand="GriTipoUsuario_RowCommand"
                                        AutoGenerateColumns="False" AllowPaging="True" class="table table-hover"
                                        OnItemCommand="Grid_ItemCommand" AllowSorting="True" ShowFooter="True"
                                        OnPageIndexChanged="Grid_PageIndexChanged" PageSize="9" CellPadding="2"  BackColor="White" BorderColor="#DD6D29" BorderStyle="None" BorderWidth="0px" CellSpacing="1">


                                        <Columns>


                                            <asp:TemplateColumn HeaderText="TRX" >
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="nro_trans" class="textos" runat="server" Text='<%#Eval("nro_trans") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="CIERRE N">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="secuencial" runat="server" class="textos" Text='<%#Eval("secuencial") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                              <asp:TemplateColumn HeaderText="CAJA">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="nro_caja" runat="server" class="textos" Text='<%#Eval("nro_caja") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                             <asp:TemplateColumn HeaderText="USUARIO">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="usuario_mod" runat="server" class="textos" Text='<%#Eval("usuario_mod") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn HeaderText="FECHA">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        
                                                        <asp:Label ID="fecha_st" Type="date" class="textos" runat="server" Text='<%#Eval("fecha_st") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>

                                            <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgVisualizar" runat="server" CausesValidation="false" CommandName="Ver"
                                                        ImageUrl="~/Tema/imagenes/search.png" ToolTip="Visualizar" Width="16" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            

                                        </Columns>


                                        <FooterStyle BackColor="White" ForeColor="#00000f" />
                                        <HeaderStyle BackColor="#DD6D29" CssClass="busqueda" Font-Bold="True" ForeColor="White" />
                                        <ItemStyle ForeColor="#00000f" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />


                                    </asp:DataGrid>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="areaImprimir" style="align-items: center">
                            <style type="text/css">
                                .label {
                                    color: white;
                                }

                                @media print {
                                    body {
                                        background: #fff !important;
                                    }

                                    .noimp {
                                        display: none;
                                    }

                                    .label {
                                        color: black;
                                    }

                                    .sinBorde {
                                        border: none;
                                        text-align: right;
                                    }
                                }

                                .sinBorde {
                                    text-align: right;
                                }

                                .tftable {
                                    width: 100%;
                                    border-width: 0px;
                                    border-color: #DD6D29;
                                    border-collapse: collapse;
                                }


                                    .tftable td {
                                        border-width: 0px;
                                        padding: 6px;
                                        border-style: solid;
                                        border-top: #DD6D29 1px dashed;
                                        border-bottom: #DD6D29 1px dashed;
                                    }


                                .fondo {
                                    color: #DD6D29;
                                    font-weight: bold;
                                }

                                .auto-style2 {
                                    font-family: Verdana, Arial, Helvetica, sans-serif;
                                    font-size: 13px;
                                    color: #DD6D29;
                                    width: 140px;
                                }

                                .auto-style3 {
                                    font-family: Verdana, Arial, Helvetica, sans-serif;
                                    font-size: 12px;
                                    color: #000000;
                                    width: 140px;
                                }
                            </style>
                            <table style="width: 100%;">
                                <tr rowspan="4">
                                    <td colspan="4">
                                        <table style="width: 100%;" runat="server" id="Tabla">
                                            <tr>
                                                <td colspan="3">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" CssClass="Titulo" Text="Cierre Caja"></asp:Label>
                                                            </td>
                                                              <td>

                                                                <asp:Label ID="lbl_caja_usuario" runat="server" class="Subtitulo1" Text="Label"></asp:Label>

                                                            </td>
                                                            <td style="width: 33px">
                                                                <div class="Subtitulo1">DIA:</div>
                                                            </td>
                                                            <td>

                                                                <asp:Label ID="lbl_fecha" runat="server" class="Subtitulo1" Text="Label"></asp:Label>

                                                            </td>
                                                            <td>

                                                                <asp:Label ID="lbl_dia" runat="server" class="Subtitulo1" Text="LUNES"></asp:Label>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="5">
                                                                <hr />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="mensaje" name="mensaje" runat="server" class="fondo" Text="RESÚMEN DEL DÍA"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Label ID="mensaje1" name="mensaje1" runat="server" class="fondo" Text="DETALLE DEL EFECTIVO DE CAJA"></asp:Label>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <table align="center" border="1" class="tftable">

                                                        <tr valign="top">
                                                            <td class="textos">
                                                                <div align="left">+</div>
                                                            </td>
                                                            <td class="textos">
                                                                <asp:Label ID="lbl_idc" runat="server" Text="VALOR EN CAJA INICIO DEL DIA"></asp:Label>

                                                            </td>

                                                            <td class="busqueda">
                                                                <asp:TextBox ID="txt_valor_id" CssClass="sinBorde" runat="server" ReadOnly="true" value="0"></asp:TextBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="textos">
                                                                <div align="left">+</div>
                                                            </td>
                                                            <td class="textos">
                                                                <asp:Label ID="lbl_2" runat="server" Text="INGRESOS POR FACTURAS"></asp:Label>

                                                            </td>

                                                            <td class="textos">
                                                                <asp:TextBox ID="txt_ingreso_facturas" ReadOnly="true" CssClass="sinBorde" runat="server" value="0"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="noimp">
                                                                    <asp:ImageButton ID="btn_ingreso_facturas" src="../Tema/imagenes/search.png" runat="server" OnClick="btn_ingreso_facturas_Click" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="textos">
                                                                <div align="left">+</div>
                                                            </td>
                                                            <td class="textos">
                                                                <asp:Label ID="lbl_3" runat="server" Text="INGRESOS POR NOTAS DE VENTA"></asp:Label>

                                                            </td>

                                                            <td class="textos">
                                                                <asp:TextBox ID="txt_ingreso_nventas" CssClass="sinBorde" Value="0" ReadOnly="true" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="noimp">
                                                                    <asp:ImageButton ID="btn_ingreso_nventas" src="../Tema/imagenes/search.png" runat="server" OnClick="btn_ingreso_nventas_Click" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="textos">
                                                                <div align="left">-</div>
                                                            </td>
                                                            <td class="textos">
                                                                <asp:Label ID="lbl_4" runat="server" Text="PAGOS EN EFECTIVO DE FACTURAS"></asp:Label>

                                                            </td>

                                                            <td class="textos">
                                                                <asp:TextBox ID="txt_pefectivo_facturas" ReadOnly="true" runat="server" CssClass="sinBorde" Value="0"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="noimp">
                                                                    <asp:ImageButton ID="btn_pefectivo_facturas" OnClick="btn_pefectivo_facturas_Click" src="../Tema/imagenes/search.png" runat="server" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="textos">
                                                                <div align="left">-</div>
                                                            </td>
                                                            <td class="textos">
                                                                <asp:Label ID="lbl_5" runat="server" Text="PAGOS EN EFECTIVO OTROS"></asp:Label>

                                                            </td>

                                                            <td class="busqueda">
                                                                <asp:TextBox ID="txt_pefectivo_otros" ReadOnly="true" CssClass="sinBorde" runat="server" value="0"></asp:TextBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="textos">
                                                                <div align="left">-</div>
                                                            </td>
                                                            <td class="textos">
                                                                <asp:Label ID="lbl_6" runat="server" Text="DEPOSITOS DEL DIA"></asp:Label>

                                                            </td>

                                                            <td class="textos">
                                                                <asp:TextBox ID="txt_depositos" CssClass="sinBorde" ReadOnly="true" Value="0" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="textos">
                                                                <div align="left">+</div>
                                                            </td>
                                                            <td class="textos">
                                                                <asp:Label ID="lbl_7" runat="server" Text="EFECTIVO PARA CAJA"></asp:Label></td>

                                                            <td class="textos">
                                                                <asp:TextBox ID="txt_efectivo_caja" CssClass="sinBorde" ReadOnly="true" Value="0" runat="server"></asp:TextBox>
                                                                <td>
                                                                    <div class="noimp">
                                                                        <asp:ImageButton ID="btn_efectivo_caja" src="../Tema/imagenes/search.png" runat="server" />
                                                                    </div>
                                                                </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td valign="top">
                                                    <asp:GridView ID="Grid" runat="server" ShowFooter="False"
                                                        AutoGenerateColumns="False" AllowPaging="True" class="tftable" BorderWidth="1px"
                                                        OnItemCommand="Grid_ItemCommand" AllowSorting="False"
                                                        PageSize="100" CellPadding="2" BackColor="White" BorderColor="#DD6D29" CellSpacing="1" ShowHeader="False">
                                                        <Columns>

                                                            <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" ItemStyle-CssClass="textos" SortExpression="id" />
                                                            <asp:BoundField DataField="valor" Visible="false" HeaderText="valor" ItemStyle-CssClass="textos" SortExpression="id" />
                                                            <asp:BoundField DataField="cantidad" HeaderText="cantidad" ItemStyle-CssClass="sinBorde" SortExpression="id" />
                                                            <asp:BoundField DataField="canti" HeaderText="total" ItemStyle-CssClass="sinBorde" SortExpression="id" />


                                                        </Columns>

                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" colspan="3">

                                                    <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>

                                                                <asp:Label ID="Label1" CssClass="fondo" runat="server" Text="SALDO EN CAJA FINAL DEL DÍA"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txt_saldo_caja" CssClass="sinBorde" ReadOnly="true" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" CssClass="fondo" Text="VALOR EN CAJA"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txt_valor_caja" CssClass="sinBorde" ReadOnly="true" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" CssClass="fondo" Text="DIFERENCIA"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txt_diferencia" CssClass="sinBorde" ReadOnly="true" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td></td>
                                                <td>&nbsp;</td>
                                                <td></td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <table style="width: 100%; text-align: center;">
                                                        <tr>
                                                            <td>
                                                                <label class="label">
                                                                    _____________________________________
                                                             
                                                                </label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>

                                                                <asp:Label ID="Lbl_Usuario" CssClass="label" runat="server" Text=""></asp:Label>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label class="label">
                                                                    RESPONSABLE DE LA CAJA                                                             
                                                                </label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <table style="width: 100%; text-align: center;">
                                                        <tr>
                                                            <td>
                                                                <label class="label">
                                                                    _____________________________________
                                                             
                                                                </label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label class="label">
                                                                    SUPERVISOR                                                            
                                                                </label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                    </td>
                </tr>
            </table>

        </div>
        </td>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;
                                    <input type="button" id="imp" runat="server" class="botones" onclick="printDiv('areaImprimir')" value="Imprimir" />

                        &nbsp;&nbsp;&nbsp;
                         <asp:Button ID="Btn_Refrescar" runat="server" class="botones" Text="Limpiar" OnClientClick="location.reload(true);" OnClick="Btn_Refrescar_Click1" />

                    </td>
                </tr>


        </table>
                    </div>
                                
    </form>
    <script>
        function printDiv(nombreDiv) {
            var contenido = document.getElementById(nombreDiv).innerHTML;
            var contenidoOriginal = document.body.innerHTML;

            document.body.innerHTML = contenido;

            window.print();

            document.body.innerHTML = contenidoOriginal;
        }
    </script>
</asp:Content>
