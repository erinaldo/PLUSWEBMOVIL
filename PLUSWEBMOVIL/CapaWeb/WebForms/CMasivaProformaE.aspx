<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="CMasivaProformaE.aspx.cs" Inherits="CapaWeb.WebForms.CMasivaProformaE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .estiloScroll {
            width: 1%;
            height: 20px;
            border-style: solid;
            border-color: #0E748A;
            border-width: 1px;
            background-color: #DD6D29;
        }
    </style>

    <form id="form1" runat="server">

    <table align="center">
        <tr>

            <td colspan="4">

                <asp:Label ID="Label1" runat="server" CssClass="Titulo" Text="Facturación Masiva"></asp:Label>

            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lbl_mensaje" runat="server" CssClass="textos_error" Text=""></asp:Label>

                 <asp:Label ID="lbl_error" CssClass="textos_error" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td aling="center">
                <asp:Label ID="Label2" runat="server" CssClass="Subtitulo2" Text="Sucursal: "></asp:Label>
                <asp:Label ID="lbl_cod_suc" runat="server" CssClass="Subtitulo2" Text=""></asp:Label>
                <asp:Label ID="lbl_sucursal" runat="server" CssClass="Subtitulo2" Text=""></asp:Label>&nbsp;&nbsp;
                 <asp:Label ID="lbl_pre" runat="server" CssClass="Subtitulo2" Text="Prefijo:" Visible="false"></asp:Label>
                <asp:Label ID="lbl_prefijo" runat="server" CssClass="Subtitulo2" Text="" Visible="false"></asp:Label>
            </td>

        </tr>
             <tr>
                    <td>

                         <hr />
                    </td>
                </tr>
                        <tr>
                    <td colspan="3">

                        <asp:Label ID="Label3" CssClass="Subtitulo1" runat="server" Text="Pedidos: "></asp:Label>
                       

                        <asp:Button ID="btn_proformas" runat="server" CssClass="btnFactura1" Text="Buscar Pedidos" OnClick="btn_proformas_Click" />

                    </td>
                      <td>

                      </td>
                </tr>
    </table>
    
   

        <table align="center">

            <tr>
                <td colspan="3">
                    <asp:Label ID="mensaje" name="mensaje" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lbl_nro" visible="false" class="busqueda" runat="server" Text="N° Pedido:"></asp:Label>
                    <asp:Label ID="nro_trans_pro_sele" required="required" CssClass="textos" runat="server" Text="" Visible="False"></asp:Label>
                </td>
            </tr>

          
         
         


            <tr valign="top">
                <td align="right" nowrap="nowrap" class="busqueda">
                    <div align="left">Total Facturas a procesar:</div>
                </td>

                <td class="textos">

                    <asp:Label ID="lbl_facturas" runat="server" Text=""></asp:Label>

                </td>
                <td class="botones" align="left">
                    <asp:Button ID="btn_verificar" CssClass="botones" OnClick="btn_verificar_Click" visible="false" runat="server" Text="Verificar" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_moneda" Visible="false" CssClass="busqueda" runat="server" Text="Moneda: "></asp:Label>
                </td>
                <td >
                    <asp:DropDownList class="textos" Visible="false"  ID="cbx_moneda" runat="server">
                    </asp:DropDownList>
                     
                </td>
                <td>
                    <asp:Button ID="btn_cancelar" CssClass="botones" runat="server" Visible="false" Text="Cancelar" OnClick="btn_cancelar_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">


                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:ScriptManager ID="ScriptManager1" runat="server" />
                            <asp:Timer ID="Timer1" Interval="500" Enabled="false" runat="server" OnTick="Timer1_Tick" />
                            <asp:Label ID="LblAvance" runat="server" ForeColor="#0E748A" />
                            <br />
                            <asp:Label ID="LblPorcentajeAvance" runat="server" ForeColor="#DD6D29" />
                            <asp:Panel ID="Panel1" Width="401px" BorderColor="#0E748A" BorderWidth="1px"
                                BorderStyle="Solid" Height="20px" runat="server">
                                <asp:Label ID="LblProgressBar" Visible="False"  CssClass="estiloScroll" Width="0px" runat="server"></asp:Label>
                            </asp:Panel>
                            <asp:Label ID="lbl_error_factura" runat="server" Visible="false" CssClass="textos_error" Text=""></asp:Label>
                            <br />
                            

                            <asp:Button ID="BtnIniciar" CssClass="botones" Visible="false" runat="server" Text="Procesar" OnClick="BtnIniciar_Click" />
                            <asp:Button ID="btn_limpiar" CssClass="botones" Visible="false" runat="server" Text="Cargar Nuevo" OnClick="btn_limpiar_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>
            </tr>

        </table>
    </form>
</asp:Content>
