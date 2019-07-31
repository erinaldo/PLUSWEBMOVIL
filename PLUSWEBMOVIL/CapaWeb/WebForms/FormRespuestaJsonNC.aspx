<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master"  AutoEventWireup="true" CodeBehind="FormRespuestaJsonNC.aspx.cs" Inherits="CapaWeb.WebForms.FormRespuestaJson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
         <form id="form1" class="forms-sample" runat="server" method="post">
          <div style="align-items: center">
            <table>
                <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0">
                                <tr>
                                    <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;<a href="FormBuscarNotaCreditos.aspx">Nota Credito</a>---&gt;Nuevo</td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                <tr>
                    <td>
                        <p class="Subtitulo1">Lista de incidencias</p>
                    </td>
                </tr>
                <tr>
                    <td>

                        <hr />
                    </td>
                </tr>
                  <tr>
                    <td>
                        <table align="center" id="FormularioRes" runat="server" visible="False" >
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="mensaje" name="mensaje" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>

                            <tr valign="top">
                                <td align="right"  nowrap="nowrap" class="busqueda">
                                    <div align="left" >N° Transacción:</div>
                                </td>

                                <td class="textos">
                                    
                                    <asp:TextBox ID="txt_nro_trans"  class="textos" size="27"  ReadOnly="true" runat="server"></asp:TextBox>

                                </td>
                                 </tr>
                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Id:</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_id"  class="textos" size="27"  ReadOnly="true" runat="server"></asp:TextBox>
                                    
                                </td>
                            </tr>
                                <tr valign="top">
                                 <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Linea:</div>
                                </td>
                                <td class="textos">
                                    <asp:TextBox ID="txt_linea" class="textos" size="27"   runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr valign="top">
                                    <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Qrdata:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:TextBox ID="txt_qrdata" Width="880" class="textos"  ReadOnly="true" TextMode="MultiLine" cols="100" Rows="3" runat="server"></asp:TextBox>

                                    </label>
                                </td>
                                </tr>
                                <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Xml:</div>
                                </td>
                                <td>
                                   <asp:TextBox ID="txt_xml" Width="880" class="textos" ReadOnly="true" TextMode="MultiLine" cols="100" Rows="3"  runat="server"></asp:TextBox>

                                </td>
                               </tr>
                            
                            <tr valign="top">
                                <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div align="left">Cufe:</div>
                                </td>
                                <td valign="top">
                                    <label>
                                        <asp:TextBox ID="txt_cufe" Width="880" class="textos" ReadOnly="true" TextMode="MultiLine" cols="100" Rows="3" runat="server"></asp:TextBox>

                                    </label>
                                </td>
                                </tr>
                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Error:</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_error" Width="880" class="textos" ReadOnly="true" TextMode="MultiLine" cols="100" Rows="3" runat="server"></asp:TextBox>
                                </td>
                                </tr>
                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Result:</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_result" Width="880" class="textos" ReadOnly="true" TextMode="MultiLine" cols="100" Rows="3" runat="server"></asp:TextBox>
                                </td>
                                </tr>
                            <tr valign="top">
                               <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Json:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:TextBox ID="txt_json" Width="880" class="textos" ReadOnly="true" TextMode="MultiLine" cols="200" Rows="10" runat="server"></asp:TextBox>
                                        
                                    </label>
                                </td>


                            </tr>

                        </table>
                    </td>
                </tr>
                        <tr>
                    <td>

                        <hr />
                    </td>
                </tr>
     <tr>
                    <td>
                        <table>
                               <tr>
       
                                <td >
                                      <input Class="botones" type="button" onclick="javascript: window.history.back();"     value="Cancelar">
                                    
                                </td>
                    
                            </tr>
                        </table>
                    </td>
                </tr>
          </table>
        </div>
    </form>
</asp:Content>
