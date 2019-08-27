<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="FormCierreCaja.aspx.cs" Inherits="CapaWeb.WebForms.FormCierreCaja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                border-bottom:  #DD6D29 1px dashed; 
            }
    </style>

    <form id="form1" class="forms-sample" runat="server" method="post">


        <div style="align-items: center">
            <table>
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0">
                            <tr>
                                <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;<a href="BuscarCierreCaja.aspx">Cierre Caja</a>---&gt;Nuevo</td>
                            </tr>
                        </table>
                    </td>

                </tr>
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

                        <asp:Label ID="lbl_fecha0" runat="server" class="Subtitulo1" Text="LUNES"></asp:Label>

                    </td>
                </tr>
                <tr rowspan="4">
                    <td colspan="4">
                        <p class="Subtitulo1">Por favor ingrese los datos solicitados:</p>
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
                                    <asp:Label ID="mensaje" name="mensaje" runat="server" class="busqueda" Text="RESÚMEN DEL DÍA"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="mensaje1" name="mensaje1" runat="server" class="busqueda" Text="DETALLE DEL EFECTIVO DE CAJA"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table align="center" border="1" class="tftable" >

                                        <tr valign="top">
                                            <td class="textos">
                                                <div align="left">+</div>
                                            </td>
                                            <td class="textos">
                                                <div align="left">VALOR EN CAJA INICIO DEL DIA</div>
                                            </td>

                                            <td class="busqueda">
                                                <asp:TextBox ID="txt_valor_id" required="required" runat="server" value="0"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td class="textos">
                                                <div align="left">+</div>
                                            </td>
                                            <td class="textos">
                                                <div align="left">INGRESOS POR FACTURAS</div>
                                            </td>

                                            <td class="textos">
                                                <asp:TextBox ID="txt_ingreso_facturas" ReadOnly="true" required="required" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btn_ingreso_facturas" src="../Tema/imagenes/search.png" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="textos">
                                                <div align="left">+</div>
                                            </td>
                                            <td class="textos">
                                                <div align="left">INGRESOS POR NOTAS DE VENTA</div>
                                            </td>

                                            <td class="textos">
                                                <asp:TextBox ID="txt_ingreso_nventas" required="required" ReadOnly="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btn_ingreso_nventas" src="../Tema/imagenes/search.png" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="textos">
                                                <div align="left">-</div>
                                            </td>
                                            <td class="textos">
                                                <div align="left">PAGOS EN EFECTIVO DE FACTURAS</div>
                                            </td>

                                            <td class="textos">
                                                <asp:TextBox ID="txt_pefectivo_facturas" required="required" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btn_pefectivo_facturas" src="../Tema/imagenes/search.png" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="textos">
                                                <div align="left">-</div>
                                            </td>
                                            <td class="textos">
                                                <div align="left">PAGOS EN EFECTIVO OTROS</div>
                                            </td>

                                            <td class="busqueda">
                                                <asp:TextBox ID="txt_pefectivo_otros" required="required" runat="server" value="0"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td class="textos">
                                                <div align="left">-</div>
                                            </td>
                                            <td class="textos">
                                                <div align="left">DEPOSITOS DEL DIA</div>
                                            </td>

                                            <td class="textos">
                                                <asp:TextBox ID="txt_depositos" required="required" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btn_depositos" src="../Tema/imagenes/search.png" runat="server" />
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
                                            <asp:BoundField DataField="Id" Visible="false" HeaderText="Id" SortExpression="BodNom" />
                                            <asp:BoundField DataField="Observaciones" HeaderText="Denominación" ItemStyle-CssClass="textos" SortExpression="Observaciones" />
                                            <asp:TemplateField HeaderText="valor" Visible="false" SortExpression="valor">
                                                <ItemTemplate>
                                                    <asp:Label ID="valor" runat="server" Text='<%# Bind("valor") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Cantidad">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:TextBox ID="cantidad" type="number" Title="Ingrese el valor" required="requeried" Width="50" class="textos" runat="server" Text="">0</asp:TextBox>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Total">
                                                <ItemTemplate>
                                                    <span style="float: left;">
                                                        <asp:Label ID="total" runat="server" class="textos" Text="">0</asp:Label>
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
                                    <table style="width:100%;">
                                        <tr>
                                            <td style="background-color: #DD6D29">
                                                <asp:Label ID="Label1" runat="server" Text="SALDO EN CAJA FINAL DEL DÍA" Font-Bold="True" ForeColor="White"></asp:Label>
                                            </td>
                                            <td>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        
                                    </table>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <table style="width:100%;">
                                        <tr>
                                            <td style="background-color: #DD6D29">
                                                <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="White" Text="VALOR EN CAJA"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td style="background-color: #DD6D29">
                                                <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="White" Text="DIFERENCIA"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Btn_Calcular" runat="server" OnClick="Btn_Calcular_Click" Text="Calcular" />
                                &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btn_imprimir" o runat="server" Text="Imprimir" OnClick="btn_imprimir_Click" />
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                   
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>



            </table>
        </div>
    </form>
</asp:Content>
