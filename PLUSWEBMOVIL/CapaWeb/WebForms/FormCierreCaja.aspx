<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="FormCierreCaja.aspx.cs" Inherits="CapaWeb.WebForms.FormCierreCaja" %>

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

    <form id="form1" class="forms-sample" runat="server" method="post">


        <div style="align-items: center">
            <table style="width: 100%;">
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0">
                            <tr>
                                <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;<a href="BuscarCierreCaja.aspx">Cierre Caja</a>---&gt;Nuevo</td>
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
                                    <td>
                                        <asp:Label ID="lblAyuda" runat="server" CssClass="Titulo" Text="Cierre Caja"></asp:Label>
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

                                <tr rowspan="4">
                                    <td colspan="4">

                                        <asp:Label ID="lbl_mensaje" runat="server" ForeColor="Red"></asp:Label>

                                    </td>
                                </tr>
                                <tr rowspan="4">
                                    <td colspan="4">

                                        <hr />
                                    </td>
                                </tr>
                                <tr rowspan="4">
                                    <td colspan="4">
                                        <table style="width: 100%;">
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
                                                    <table align="center" border="1" class="tftable" style="width: 100%;">

                                                        <tr valign="top">
                                                            <td class="textos">
                                                                <div align="left">+</div>
                                                            </td>
                                                            <td class="textos">
                                                                <asp:Label ID="lbl_idc" runat="server" Text="VALOR EN CAJA INICIO DEL DIA"></asp:Label>

                                                            </td>

                                                            <td class="auto-style2">
                                                                <asp:TextBox ID="txt_valor_id" CssClass="sinBorde" required="required" runat="server" value="0" AutoPostBack="True" Style="text-align: right" OnTextChanged="txt_valor_id_TextChanged"></asp:TextBox>
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

                                                            <td class="auto-style3">
                                                                <asp:TextBox ID="txt_ingreso_facturas" CssClass="sinBorde" ReadOnly="true" required="required" runat="server" AutoPostBack="True" Style="text-align: right" OnTextChanged="txt_ingreso_facturas_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="noimp">
                                                                    <asp:ImageButton ID="btn_ingreso_facturas" OnClick="btn_ingreso_facturas_Click" src="../Tema/imagenes/search.png" runat="server" />
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

                                                            <td class="auto-style3">
                                                                <asp:TextBox ID="txt_ingreso_nventas" CssClass="sinBorde" required="required" ReadOnly="true" runat="server" AutoPostBack="True" Style="text-align: right" OnTextChanged="txt_ingreso_nventas_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="noimp">
                                                                    <asp:ImageButton ID="btn_ingreso_nventas" OnClick="btn_ingreso_nventas_Click" src="../Tema/imagenes/search.png" runat="server" />
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

                                                            <td class="auto-style3">
                                                                <asp:TextBox ID="txt_pefectivo_facturas" CssClass="sinBorde" required="required" runat="server" AutoPostBack="True" Style="text-align: right" value="0" OnTextChanged="txt_pefectivo_facturas_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="noimp">
                                                                    <asp:ImageButton ID="btn_pefectivo_facturas" src="../Tema/imagenes/search.png" runat="server" />
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

                                                            <td class="auto-style2">
                                                                <asp:TextBox ID="txt_pefectivo_otros" CssClass="sinBorde" required="required" runat="server" AutoPostBack="True" Style="text-align: right" value="0" OnTextChanged="txt_pefectivo_otros_TextChanged"></asp:TextBox>
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

                                                            <td class="auto-style3">
                                                                <asp:TextBox ID="txt_depositos" CssClass="sinBorde" required="required" AutoPostBack="True" Style="text-align: right" runat="server" value="0" OnTextChanged="txt_depositos_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="noimp">
                                                                    <asp:ImageButton ID="btn_depositos" src="../Tema/imagenes/search.png" runat="server" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="textos">
                                                                <div align="left">+</div></td>
                                                            <td class="textos">
                                                                 <asp:Label ID="lbl_7" runat="server" Text="EFECTIVO PARA CAJA"></asp:Label></td>

                                                            <td class="auto-style3">
                                                                <asp:TextBox ID="txt_efectivo_caja" CssClass="sinBorde" required="required" AutoPostBack="True" Style="text-align: right" runat="server" value="0" OnTextChanged="txt_efectivo_caja_TextChanged" ></asp:TextBox></td>
                                                            <td>
                                                               <div class="noimp">
                                                                    <asp:ImageButton ID="btn_efectivo_caja" src="../Tema/imagenes/search.png" runat="server" />
                                                                </div></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td></td>
                                                <td valign="top">
                                                    <asp:GridView ID="Grid" runat="server"
                                                        AutoGenerateColumns="False" AllowPaging="True" CssClass="tftable"
                                                        OnItemCommand="Grid_ItemCommand" AllowSorting="True" ShowFooter="False"
                                                        PageSize="1000" CellPadding="2" BorderWidth="1px" CellSpacing="1" ShowHeader="False">
                                                        <Columns>
                                                            <asp:BoundField DataField="id" HeaderText="Id" ItemStyle-CssClass="textos_prueba" SortExpression="id" ItemStyle-ForeColor="White">
                                                                <ItemStyle CssClass="noimp" ForeColor="White"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Observaciones" HeaderText="Denominación" ItemStyle-CssClass="textos" SortExpression="Observaciones">
                                                                <ItemStyle CssClass="textos"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="valor" Visible="false" SortExpression="valor">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="valor" runat="server" Text='<%# Bind("valor") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Cantidad">
                                                                <ItemTemplate>
                                                                    <span style="float: right;">
                                                                        <asp:TextBox ID="cantidad" type="number" CssClass="sinBorde" Title="Ingrese el valor" required="requeried" Width="50" class="textos" runat="server" Text="">0</asp:TextBox>
                                                                    </span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Total">
                                                                <ItemTemplate>
                                                                    <span style="float: right;">
                                                                        <asp:Label ID="total" runat="server" Style="text-align: right" Text="" class="textos">0</asp:Label>
                                                                    </span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

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
                                                <td valign="top">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
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
                                                <td></td>
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
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Btn_Calcular" CssClass="botones" runat="server" OnClientClick="return validarCampos();" OnClick="Btn_Calcular_Click" Text="Calcular" />
                        &nbsp;&nbsp;&nbsp;
                                    <input type="button" class="botones" onclick="printDiv('areaImprimir')" value="Imprimir" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_cancelar" CssClass="botones" runat="server" Text="Cancelar" OnClick="btn_cancelar_Click" />
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
