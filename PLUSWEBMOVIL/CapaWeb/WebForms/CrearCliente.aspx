<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearCliente.aspx.cs" Inherits="CapaWeb.WebForms.CrearCliente" %>
<link href="../Tema/css/Style.css" rel="stylesheet" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table  border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="white">
       <tr>

                    
              <table border="0" cellspacing="3" cellpadding="0" id="Tabla_Det3"  bgcolor="white">
                   <tr>
                       <td>&nbsp;</td>
                       <td  colspan="2" class="Titulo">
            
                       <asp:Label ID="Label1" runat="server"  Text="Label">Registro Nuevo Cliente</asp:Label>
                
                      </td>
                       
                       </tr>
                            <tr valign="top">
                                <td class="busqueda">Doc. Legal:</td>
                                <td class="textos">
                                    <asp:TextBox ID="doc_legal" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Nombres:*</td>
                                <td class="textos">
                                    <label>
                                        <input name="primer_nombre" type="text" class="textos" id="primer_nombre" tabindex="1" maxlength="30" />
                                    </label>
                                    <label>
                                        <input name="segundo_nombre" type="text" class="textos" id="segundo_nombre" tabindex="2" maxlength="30" />
                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Apellidos:*</td>
                                <td class="textos">
                                    <label>
                                        <input name="primer_apellido" type="text" class="textos" id="primer_apellido" tabindex="3" maxlength="30" />
                                    </label>
                                    <label>
                                        <input name="segundo_apellido" type="text" class="textos" id="segundo_apellido" tabindex="4" maxlength="30" />
                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Abreviacion:*</td>
                                <td>
                                    <input name="cod_sop" type="text" id="cod_sop" tabindex="5" size="6" maxlength="3" /><span class="textos_sm"> 3 Caracteres</span></td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Direccion:*</td>
                                <td class="textos">
                                    <label>
                                        <asp:TextBox name="dir_tit" cols="40" width="400" rows="3" class="textos" id="dir_tit" runat="server"></asp:TextBox>
                                       
                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Telefonos:*</td>
                                <td class="textos">
                                    <label>
                                        <input name="tel_tit" type="text" class="textos" id="tel_tit" tabindex="7" size="15" maxlength="20" />
                                    </label>
                                    <label>
                                        <input name="fax_tit" type="text" class="textos" id="fax_tit" tabindex="8" size="15" maxlength="20" />
                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Email:</td>
                                <td class="textos">
                                    <label>
                                        <input name="email_tit" type="text" class="textos" id="email_tit" tabindex="9" size="40" maxlength="40" />
                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Clasificacion DIAN:*</td>
                                <td class="textos">
                                    <label>
                                        <select name="cod_tipo_emp_iva" class="textos" id="cod_tipo_emp_iva" tabindex="10">
                                        </select>
                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="busqueda">Tipo Regimen:*</td>
                                <td class="textos">
                                    <label>
                                        <select name="cod_tipo_emp_gan" class="textos" id="cod_tipo_emp_gan" tabindex="11">
                                        </select>
                                    </label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td>&nbsp;</td>
                                <td>
                                    <input name="button2" type="submit" class="botones" id="button2" tabindex="12" value="Informacion Geografica" />
                                    <div class="textos_sm">* Campos Obligatorios</div>
                                </td>
                            </tr>
                             <tr valign="top">
                                <td>&nbsp;</td>
                                 
                                <td>
                                    <asp:Button ID="Cancelar" runat="server" Text="Cancelar" CssClass="botones" />
                                    <asp:Button ID="Guardar" runat="server" Text="Guardar" CssClass="botones" />
                                </td>
                            </tr>
                        </table>
                    
                        

             </tr>
                              
    </table>
    </form>
</body>
</html>
