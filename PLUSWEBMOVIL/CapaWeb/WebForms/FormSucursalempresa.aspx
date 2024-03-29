﻿<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="FormSucursalempresa.aspx.cs" Inherits="CapaWeb.WebForms.FormSucursalempresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
      <form id="form1" class="forms-sample" runat="server" method="post">
        
       
        <div style="align-items: center">
            <table>
                 <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0">
                                <tr>
                                    <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;<a href="FormListaSucursalEmpresa.aspx">Sucursal Empresa</a>---&gt;Nuevo</td>
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


                        <table align="center">
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="mensaje" name="mensaje" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>

                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Código Sucursal:</div>
                                </td>

                                <td class="textos">
                                    <asp:TextBox ID="txt_cod_sucursal" required="required" Width="200" class="textos" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Nombre:</div>
                                </td>
                                <td class="textos">
                                    <asp:TextBox required="required"  ID="txt_nom_sucursal" Width="200" class="textos" size="27" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                             <tr>
                                 <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Pais:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:DropDownList class="textos"  required="required" AutoPostBack="true" Width="210" ID="cbx_pais" runat="server" OnSelectedIndexChanged="cbx_pais_SelectedIndexChanged">
                                        </asp:DropDownList>

                                    </label>
                                </td>
                            </tr>
                             <tr>
                                 <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Provincia:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:DropDownList class="textos" AutoPostBack="true"  required="required" Width="210" ID="cbx_provincia" runat="server" OnSelectedIndexChanged="cbx_provincia_SelectedIndexChanged">
                                        </asp:DropDownList>

                                    </label>
                                </td>
                            </tr>
                              <tr>
                                 <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Ciudad:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:DropDownList class="textos"  Width="210"  required="required" ID="cbx_ciudad" runat="server">
                                        </asp:DropDownList>

                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Dirección:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:TextBox ID="txt_dir_sucursal" required="required" class="textos" Width="200" runat="server"></asp:TextBox>

                                    </label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Teléfono:</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_tel_sucursal" class="textos" pattern="^([0-9])*$"  title="Ingrese solo números"  required="required" Width="200" runat="server"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Correo:</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_email_sucursal" type="email" title="email@hotmail.com"  required="required"  class="textos" Width="200" runat="server"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                 <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Prefijo Factura:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:DropDownList class="textos"  required="required"  Width="210" ID="cbx_serie_factura" runat="server">
                                        </asp:DropDownList>

                                    </label>
                                </td>
                            </tr>
                            <tr>
                                 <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Prefijo Factura por computador:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:DropDownList class="textos"  Width="210" ID="cbx_serie_facn" runat="server">
                                        </asp:DropDownList>

                                    </label>
                                </td>
                            </tr>
                             <tr>
                                 <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Prefijo Nota Crédito:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:DropDownList class="textos"  required="required" Width="210" ID="cbx_serie_nc" runat="server">
                                        </asp:DropDownList>

                                    </label>
                                </td>
                            </tr>
                            <tr>
                                 <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Prefijo Nota Crédito por computador:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:DropDownList class="textos"  Width="210" ID="cbx_serie_ncn" runat="server">
                                        </asp:DropDownList>

                                    </label>
                                </td>
                            </tr>
                                <tr>
                                 <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Prefijo Nota Débito:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:DropDownList class="textos" required="required" Width="210" ID="cbx_serie_nd" runat="server">
                                        </asp:DropDownList>

                                    </label>
                                </td>
                            </tr>
                             <tr>
                                 <td align="right" nowrap="nowrap" class="busqueda">
                                    <div align="left">Prefijo Nota Débito por computador:</div>
                                </td>
                                <td>
                                    <label>
                                        <asp:DropDownList class="textos"  Width="210" ID="cbx_serie_ndn" runat="server">
                                        </asp:DropDownList>

                                    </label>
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
                                    <asp:Button ID="btn_guardar" Class="botones"  runat="server" OnClientClick="return validarCamposSucursal();" onclick="btn_guardar_Click"  Text="Confirmar" />
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
