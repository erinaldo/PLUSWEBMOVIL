﻿<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="CargaMasivaFactura.aspx.cs" Inherits="CapaWeb.WebForms.CargaMasivaFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <table align="center">
              <tr>
     
                    <td colspan="4">
                        
                        <asp:Label ID="Label1" runat="server"  CssClass="Titulo" Text="Importar Facturas de Venta"></asp:Label>
                        
                        </td>
                </tr>
         </table>
     <iframe src="<%Response.Write(Modelowmspclogo.sitio_erp + "/CargaMasivaFEPWM.aspx"); %>" frameborder="0" allowfullscreen align="center" style="width: 821px; height: 135px; margin-left: 0px;"></iframe>
         <form id="form1" runat="server">
 
         <table align="center">
            
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="mensaje" name="mensaje" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="cod_tit" required="required" runat="server" Text="" Visible="False"></asp:Label>
                                </td>
                            </tr>

                            <tr valign="top">
                                  <td align="right" nowrap="nowrap" class="busqueda">
                                      <asp:FileUpload ID="FileUpload1" Visible="false" runat="server" />
                                </td>
                                  <td class="botones" colspan="2" align="left">
                                    <asp:Button ID="btn_importar" CssClass="botones" Visible="false" onclick="btn_importar_Click" runat="server" Text="Importar" />
                                 </td>
                               </tr>
             <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Total Facturas a procesar:</div>
                                </td>

                                <td class="textos">
                                   
                                    <asp:Label ID="lbl_facturas" runat="server" Text=""></asp:Label>

                                </td>
                                <td class="botones" colspan="2" align="left">
                                    <asp:Button ID="btn_verificar" CssClass="botones" OnClick="btn_verificar_Click" runat="server" Text="Verificar" />
                                    <asp:Button ID="btn_procesar" CssClass="botones" OnClick="btn_procesar_Click" runat="server" Text="Procesar" Visible="false" /> </td>
                               
                               
                            </tr>
                        

                         
                   
                            
                        </table>
     </form>
</asp:Content>
