<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="FormMasivoNCFinanciera.aspx.cs" Inherits="CapaWeb.WebForms.FormMasivoNCFinanciera" %>
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
    <form id="form1" class="forms-sample" runat="server" >


        <div style="align-items: center">
            <table>
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0">
                            <tr>
                                <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;<a href="AccesoMasivoNC.aspx">Masivo Notas de Crédito</a>---&gt;Nuevo</td>
                            </tr>
                        </table>
                    </td>

                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblAyuda" runat="server" CssClass="Titulo" Text="Importar Notas de Crédito Financieras"></asp:Label>

                    </td>
                </tr>
                   <tr>
                    <td>
                         <asp:Label ID="Label14" runat="server"  CssClass="Subtitulo2" Text="Sucursal: "></asp:Label>
                        <asp:Label ID="lbl_cod_suc_emp" runat="server"  CssClass="Subtitulo2" Text=""></asp:Label>
                        <asp:Label ID="lbl_suc_emp" runat="server"  CssClass="Subtitulo2" Text=""></asp:Label>
                     </td>
                       <td >
                           <asp:Label ID="lbl_prefijio" runat="server" CssClass="Subtitulo2" Text="Prefijo: "></asp:Label>
                           <asp:Label ID="lbl_tipo_prefijo" runat="server" CssClass="Subtitulo2" Text=""></asp:Label>
                       </td>
                       <td >
                           <asp:Label ID="lbl_ve" runat="server" CssClass="Subtitulo2" Text="Tipo: "></asp:Label>
                           <asp:Label ID="lbl_tipo_nc" runat="server" CssClass="Subtitulo2" Text=""></asp:Label>
                       </td>
                </tr>
                      
                 <tr>
                    <td colspan="3">

                         <hr />
                    </td>
                </tr>
                 <tr>
                     <td colspan="3">
                        <asp:Label ID="lbl_error" runat="server"  class="textos_error" Text=""></asp:Label>
                        </td>
                    </tr>
                  <tr>
                     <td colspan="3">
                       <asp:Label ID="lbl_mensaje" runat="server"  class="textos_error" Text=""></asp:Label>
                        
                        </td>
                    </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_carga" runat="server" class="Subtitulo1" Text="Cargar facturas a aplicar: "></asp:Label>
                    </td>

                    <td class="busqueda">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                    <td>
                        <asp:Button ID="btn_importar" CssClass="botones" OnClick="btn_importar_Click" runat="server" Text="Importar" />
                    </td>

                </tr>
                <tr>
                    <td >
                        <asp:Label ID="lbl_verificar" runat="server" Visible="false" CssClass="busqueda" Text="Total notas de crédito a procesar:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lbl_total_nc" runat="server" Visible="false" CssClass="textos" Text=""></asp:Label>
                        </td>
                    <td>
                        <asp:Button ID="btn_verificar" CssClass="botones" Visible="false" runat="server" Text="Verificar" OnClick="btn_verificar_Click" />
                    </td>
                </tr>
                  <tr>
                <td>
                    <asp:Label ID="lbl_fec_ca" CssClass="busqueda"  Visible="false" runat="server" Text="Fecha carga archivo: "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_carga_fec" CssClass="textos" Visible="false"  runat="server" Text=""></asp:Label>
                </td>
                <td class="botones" align="left">
                    <asp:Button ID="btn_cancelar" CssClass="botones" Visible="false"  onclick="btn_cancelar_Click" runat="server" Text="Cancelar" />
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
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>
            </tr>
    </form>
</asp:Content>
