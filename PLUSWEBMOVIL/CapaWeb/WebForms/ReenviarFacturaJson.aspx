﻿<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="ReenviarFacturaJson.aspx.cs" Inherits="CapaWeb.WebForms.ReenviarFacturaJson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" class="forms-sample" runat="server" method="post">
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
                        <p class="Subtitulo1">Reenviar Factura</p>
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
                                    <asp:Label ID="mensaje" name="mensaje" Visible="true" runat="server" Text=""></asp:Label>
                                </td>
                                <td colspan="4">
                                    <asp:Label ID="lbl_nro_trans" name="lbl_nro_trans" Visible="false" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Button ID="btn_reenviar" CssClass ="btnFactura1" runat="server" Text="Enviar" OnClick="btn_reenviar_Click" />
                                </td>
                                <td></td>
                                <td align="right">
                                    <asp:Button ID="btn_cancelar" CssClass ="btnFactura1" runat="server" Text="Cancelar" OnClick="btn_cancelar_Click"  />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                   
                    </table>
              </div>
        </form>
</asp:Content>
