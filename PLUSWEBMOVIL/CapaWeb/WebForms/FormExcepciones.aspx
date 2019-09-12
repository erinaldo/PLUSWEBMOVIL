<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="FormExcepciones.aspx.cs" Inherits="CapaWeb.WebForms.FormExcepciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <form id="form1" class="forms-sample" runat="server" method="post">
          <div style="align-items: center">
            <table>
                <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0">
                                <tr>
                                    <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;<a href="BuscarExcepciones.aspx">Excepciones</a>---&gt;Nuevo</td>
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
                        <asp:Label ID="lbl_error" runat="server"  class="textos_error" Text=""></asp:Label>
                        
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
                                <td colspan="2">
                                    <asp:Label ID="mensaje" name="mensaje" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>

                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">TRX:</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_id"  class="textos" Width="157px"  ReadOnly="true" runat="server"></asp:TextBox>
                                    
                                </td>
                            </tr>
                                <tr valign="top">
                                 <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Empresa:</div>
                                </td>
                                <td class="textos">
                                    <asp:TextBox ID="txt_empresa" class="textos" Width="157px"  runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>

                                  <tr valign="top">
                                <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                    <div align="left">Fecha:</div>
                               </td>
                                <td valign="top">
                                    <label>
                                        <asp:TextBox ID="txt_fecha"  class="textos" ReadOnly="true" runat="server" Width="157px"></asp:TextBox>

                               </label>
                                </td>
</tr>
                                 <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Usuario:</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_usuario"  class="textos" ReadOnly="true"  runat="server" Width="157px"></asp:TextBox>
                                </td>
        
                                </tr>
                            <tr valign="top">
                                    <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Proceso:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:TextBox ID="txt_proceso" Width="880" class="textos"  ReadOnly="true"  runat="server"></asp:TextBox>

                                    </label>
                                </td>
                                </tr>
                                <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Metodo:</div>
                                </td>
                                <td>
                                   <asp:TextBox ID="txt_metodo" Width="880" class="textos" ReadOnly="true"   runat="server"></asp:TextBox>

                                </td>
                               </tr>
                            
                      
                         
                            <tr valign="top">
                               <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Error:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:TextBox ID="txt_error" Width="880" class="textos" ReadOnly="true" TextMode="MultiLine" cols="200" Rows="10" runat="server"></asp:TextBox>
                                        
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
