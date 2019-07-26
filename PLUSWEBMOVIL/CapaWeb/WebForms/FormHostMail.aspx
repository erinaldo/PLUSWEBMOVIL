<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="FormHostMail.aspx.cs" Inherits="CapaWeb.WebForms.FormHostMail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <form id="form1" class="forms-sample" runat="server" method="post">
        
       
        <div style="align-items: center">
            <table>
                 <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0">
                                <tr>
                                    <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;<a href="FormListaSucursalEmpresa.aspx">Host Mail</a>---&gt;Nuevo</td>
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
                                    <asp:Label ID="mensaje" name="mensaje" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>

                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Remitente:</div>
                                </td>

                                <td class="textos">
                                    <asp:TextBox ID="txt_remitente" required="required" Width="200" class="textos" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                           
                               <tr>
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Correo:</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_correo" type="email" title="email@hotmail.com"  pattern="^[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*@[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*[.][a-zA-Z]{1,5}*$" required="required"  class="textos" Width="200" runat="server"></asp:TextBox>

                                </td>
                            </tr>
                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Contraseña:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:TextBox ID="txt_contrasenia" required="required" class="textos" Width="200" runat="server"></asp:TextBox>

                                    </label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Puerto:</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_puerto" class="textos" pattern="^([0-9])*$" maxlength="13"  title="Ingrese solo números"  required="required" Width="200" runat="server"></asp:TextBox>

                                </td>
                            </tr>
                          <tr>
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Smtp:</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_smtp"   title="Ingrese solo letras"  Width="200" class="textos"  runat="server" required="required" ></asp:TextBox>

                                </td>
                            </tr>
                         <tr>
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Autentificación:</div>
                                </td>
                                <td>
                                    <asp:CheckBox ID="check_aut" runat="server" value="1" />
                                  
                                </td>
                            </tr>
                             <tr>
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Seguro:</div>
                                </td>
                                <td>
                                     <asp:CheckBox ID="check_secure" runat="server" />
                                </td>
                            </tr>
                             <tr>
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Tema:</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_subject" pattern="^[a-zA-Z\sñÑÁÉÍÓÚáéíóú'´]*$" title="Ingrese solo letras"  Width="200" class="textos"  runat="server" required="required"></asp:TextBox>

                                </td>
                            </tr>
                             <tr>
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Texto:</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_html"   required="required" Width="200" runat="server"></asp:TextBox>

                                </td>
                            </tr>
                             <tr>
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Firma:</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_firma" class="textos"  required="required" Width="200" runat="server"></asp:TextBox>

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
                                    <asp:Button ID="btn_guardar" Class="botones"  runat="server" OnClick="btn_guardar_Click" OnClientClick="return validarCamposSucursal();" Text="Confirmar" />
                                </td>
                                <td >
                                    <asp:Button ID="btn_cancela" Class="botones"  runat="server" OnClick="btn_cancela_Click"  UseSubmitBehavior="False" Text="Cancelar" /> 
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
          </div>
      </form>
</asp:Content>
