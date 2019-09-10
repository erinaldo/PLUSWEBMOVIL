<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="FormDenominaciones.aspx.cs" Inherits="CapaWeb.WebForms.FormDenominaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <form id="form1" class="forms-sample" runat="server" method="post">
        
       
        <div style="align-items: center">
            <table>
                 <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0">
                                <tr>
                                    <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;<a href="BuscarDenominaciones.aspx">Denominaciones</a>---&gt;Nuevo</td>
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
                                    <asp:Label ID="lbl_error" name="lbl_error" CssClass="textos_error" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="mensaje" name="mensaje" CssClass="botones" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                                <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Moneda:</div>
                                </td>
                                <td>
                                    <label>
                                        
                                        <asp:DropDownList ID="cbx_cod_moneda" required="required" class="textos" Width="200" runat="server"></asp:DropDownList>
                                    </label>
                                </td>
                            </tr>

                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Nombre:</div>
                                </td>

                                <td class="textos">
                                    <asp:DropDownList ID="cbx_nombrere" required="required" Width="200" class="textos" runat="server">
                                        <asp:ListItem>BILLETE</asp:ListItem>
                                        <asp:ListItem>MONEDA</asp:ListItem>
                                    </asp:DropDownList>
                                   
                                </td>
                            </tr>
                           
                               <tr>
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Valor:</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_valor" type="number" step="any" title="Igrese solo números"  required="required"  class="textos" Width="200" runat="server"></asp:TextBox>

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
                                    <asp:Button ID="btn_guardar" Class="botones"  runat="server" onclick="btn_guardar_Click"  Text="Confirmar" />
                                </td>
                                <td >
                                    <asp:Button ID="btn_cancela" Class="botones"  runat="server" onclick="btn_cancela_Click"  UseSubmitBehavior="False" Text="Cancelar" /> 
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
          </div>
      </form>
</asp:Content>
