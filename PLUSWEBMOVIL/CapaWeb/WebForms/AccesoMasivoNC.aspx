<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="AccesoMasivoNC.aspx.cs" Inherits="CapaWeb.WebForms.AccesoMasivoNC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <form id="form1" name="form1" class="forms-sample" runat="server" method="post">
         <div style="align-items: left">
            <table>
                 <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0">
                                <tr>
                                    <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;Masivo Notas de Crédito</td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAyuda" runat="server"  CssClass="Titulo" Text="Masivo Notas de Crédito"></asp:Label>
                        
                        </td>
                </tr>
                            <tr>
                    <td>
                        <asp:Label ID="lbl_error" CssClass="textos_error" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                <tr>
                    <td >
                        <asp:Label ID="lbl_mensaje" runat="server"  CssClass="textos_error" Text=""></asp:Label>
                        
                        </td>
                    </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server"  CssClass="Subtitulo2" Text="Sucursal: "></asp:Label>
                        <asp:Label ID="lbl_cod_suc" runat="server"  CssClass="Subtitulo2" Text=""></asp:Label>
                        <asp:Label ID="lbl_sucursal" runat="server"  CssClass="Subtitulo2" Text=""></asp:Label>
                        
                        </td>
                    </tr>
                <tr>
                    <td>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <p class="Subtitulo2">Para realizar una nueva Nota de Crédito: </p>
                                </td>
                                <td>
                                    <asp:Button ID="notaCreditoFinan" OnClick="notaCreditoFinan_Click" Visible="false" class="botones" runat="server" Text="FINANCIERA" />
                                    &nbsp;
                                <asp:Button ID="btn_AnularFactura" OnClick="btn_AnularFactura_Click" Visible="false" class="botones" runat="server" Text="POR ANULACIÓN DE FACTURA" />
                                    &nbsp;
                        
                                <asp:Button ID="NuevaNC" OnClick="NuevaNC_Click" Visible="false" class="botones" runat="server" Text="POR DEVOLUCIÓN" />
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    </tr>
                  
                
                 <tr>
                    <td>
                        <asp:Label ID="txtAcceso" runat="server" Visible="false" CssClass="Titulo" Text="El Usuario registrado no tiene permiso para ejecutar estos procesos"></asp:Label>
                        
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
