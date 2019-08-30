<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="FormCierreCaja.aspx.cs" Inherits="CapaWeb.WebForms.FormCierreCaja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


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

                                @media print {
                                    .noimp {
                                        display: none;
                                    }
                                }

                                .label {
                                    color: #ffffff;
                                }

                                @media print {
                                    .label {
                                        color: #DD6D29;
                                    }
                                }

                                .hr {
  
   height: 1px;
  background-color: white;
}

                                @media print {
                                .hr {
  
   height: 1px;
  background-color:  #DD6D29;
}
                                }

                                
                  
                                

                                .auto-style1 {
                                    height: 23px;
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
                                                    <table align="center" border="1" class="tftable">

                                                        <tr valign="top">
                                                            <td class="textos">
                                                                <div align="left">+</div>
                                                            </td>
                                                            <td class="textos">
                                                                <asp:Label ID="lbl_idc" runat="server" Text="VALOR EN CAJA INICIO DEL DIA"></asp:Label>

                                                            </td>

                                                            <td class="busqueda">
                                                                <asp:TextBox ID="txt_valor_id"  required="required" runat="server" value="0" AutoPostBack="True" Style="text-align: right" OnTextChanged="txt_valor_id_TextChanged"></asp:TextBox>
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

                                                            <td class="textos_td">
                                                                <asp:TextBox ID="txt_ingreso_facturas" ReadOnly="true" required="required" runat="server" AutoPostBack="True" Style="text-align: right" OnTextChanged="txt_ingreso_facturas_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="noimp">
                                                                    <asp:ImageButton ID="btn_ingreso_facturas" src="../Tema/imagenes/search.png" runat="server" />
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
                                                                <asp:TextBox ID="txt_ingreso_nventas" required="required" ReadOnly="true" runat="server" AutoPostBack="True" Style="text-align: right" OnTextChanged="txt_ingreso_nventas_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="noimp">
                                                                    <asp:ImageButton ID="btn_ingreso_nventas" src="../Tema/imagenes/search.png" runat="server" />
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
                                                                <asp:TextBox ID="txt_pefectivo_facturas" required="required" runat="server" AutoPostBack="True" Style="text-align: right" value="0" OnTextChanged="txt_pefectivo_facturas_TextChanged"></asp:TextBox>
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

                                                            <td class="busqueda">
                                                                <asp:TextBox ID="txt_pefectivo_otros" required="required" runat="server" AutoPostBack="True" Style="text-align: right" value="0" OnTextChanged="txt_pefectivo_otros_TextChanged"></asp:TextBox>
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
                                                                <asp:TextBox ID="txt_depositos" required="required" AutoPostBack = "True" Style = "text-align: right" runat="server" value="0" OnTextChanged="txt_depositos_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="noimp">
                                                                    <asp:ImageButton ID="btn_depositos" src="../Tema/imagenes/search.png" runat="server" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:GridView ID="Grid" runat="server"
                                                        AutoGenerateColumns="False" AllowPaging="True" class="table table-hover"
                                                        OnItemCommand="Grid_ItemCommand" AllowSorting="True" ShowFooter="True"
                                                        PageSize="11" CellPadding="2" BackColor="White" BorderColor="#DD6D29" BorderStyle="None" BorderWidth="0px" CellSpacing="1" ShowHeader="False">
                                                        <Columns>
                                                            <asp:BoundField DataField="id" HeaderText="Id" ItemStyle-CssClass="textos_prueba" SortExpression="id" ItemStyle-ForeColor="White" />
                                                            <asp:BoundField DataField="Observaciones" HeaderText="Denominación" ItemStyle-CssClass="textos" SortExpression="Observaciones" />
                                                            <asp:TemplateField HeaderText="valor" Visible="false" SortExpression="valor">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="valor" runat="server" Text='<%# Bind("valor") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Cantidad">
                                                                <ItemTemplate>
                                                                    <span style="float: right;">
                                                                        <asp:TextBox ID="cantidad" type="number" Title="Ingrese el valor" aling="right" required="requeried" Width="50" class="textos" runat="server" Text="">0</asp:TextBox>
                                                                    </span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Total">
                                                                <ItemTemplate>
                                                                    <span style="float: right;">
                                                                        <asp:Label ID="total" runat="server"   Style="text-align: right" Text=""  class="textos" >0</asp:Label>
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
                                                                <asp:TextBox ID="txt_saldo_caja" CssClass="textos" ReadOnly="true" runat="server"></asp:TextBox>
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
                                                                <asp:TextBox ID="txt_valor_caja" CssClass="textos" ReadOnly="true" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" CssClass="fondo" Text="DIFERENCIA"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txt_diferencia" CssClass="textos" ReadOnly="true" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>
                                                                <label class="label">
                                                                    -------------------------------------
                                                             
                                                                </label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label class="label">
                                                                    Firma 
                                                             
                                                                </label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td></td>
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
                        <asp:Button ID="Btn_Calcular" CssClass="botones" runat="server" OnClick="Btn_Calcular_Click" Text="Calcular" />
                        &nbsp;&nbsp;&nbsp;
                                    <input type="button" class="botones" onclick="printDiv('areaImprimir')" value="Imprimir" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_cancelar" CssClass="botones" runat="server" UseSubmitBehavior="False" Text="Cancelar" OnClick="btn_cancelar_Click" />
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
