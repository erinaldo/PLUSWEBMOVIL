<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="FormDatosFacturacion.aspx.cs" Inherits="CapaWeb.WebForms.FormDatosFacturacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <form id="form1" class="forms-sample" runat="server" method="post">
        
       
        <div style="align-items: center">
            <table>
                 <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0">
                                <tr>
                                    <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;<a href="BuscarDatosFacturacion.aspx">Conceptos de Facturación</a>---&gt;Nuevo</td>
                                </tr>
                            </table>
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
                                    <asp:Label ID="lbl_error" class="textos_error" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="mensaje" name="mensaje" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>

                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Codigo:</div>
                                </td>

                                <td class="textos">
                                    <asp:TextBox ID="txt_codigo" required="required" Width="200" class="textos" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                           
                               <tr>
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Nombre:</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_nombre" required="required"  class="textos" Width="200" runat="server"></asp:TextBox>

                                </td>
                            </tr>
                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Concepto Fiscal:</div>
                                </td>
                                <td>
                                     <asp:DropDownList ID="cbx_fiscal" class="textos" runat="server" AutoPostBack="True" Height="20px" Width="204px"  OnSelectedIndexChanged="cbx_fiscal_SelectedIndexChanged">
                                         
                              </asp:DropDownList>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td> </td>
                                <td> <asp:Label ID="lbl_descuento" runat="server" class="textos" Text=""></asp:Label> </td>
                            </tr>
                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">% Descuento:</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_desc" min="0" step="0.01" type="number" value="0" Width="200" required="required" runat="server" class="textos"></asp:TextBox>

                                </td>
                            </tr> 
                              <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Cuenta:</div>
                                </td>
                                <td>
                                    
                                    <asp:DropDownList class="textos"  Width="200" ID="cbx_cta_contable" required="required" runat="server">
                                    </asp:DropDownList>

                                </td>
                            </tr> 
                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">C.Costos:</div>
                                </td>
                                <td>
                                      <asp:DropDownList class="textos"  Width="200" ID="cbx_costos" required="required" runat="server">
                                    </asp:DropDownList>

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
                                    <asp:Button ID="btn_guardar" Class="botones"  runat="server" onclick="btn_guardar_Click" Text="Confirmar" />
                                </td>
                                <td >
                                    <asp:Button ID="btn_cancela" Class="botones"  runat="server" onclick="btn_cancela_Click" UseSubmitBehavior="False" Text="Cancelar" /> 
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
          </div>
      </form>
</asp:Content>
