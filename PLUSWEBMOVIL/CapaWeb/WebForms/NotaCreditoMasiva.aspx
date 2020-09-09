<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotaCreditoMasiva.aspx.cs" Inherits="CapaWeb.WebForms.NotaCreditoMasiva" %>
<link href="../Tema/css/StylePront.css" rel="stylesheet" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 13px;
            color: #DD6D29;
            width: 118px;
        }
        .auto-style2 {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 13px;
            color: #DD6D29;
            width: 197px;
        }
    </style>
</head>
<body>
    <form id="form1" name="form1" class="forms-sample" runat="server" method="post">
         <div style="align-items: left">
            <table  width="95%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="white">
                           
                   
                      <tr>
                    <td>

                         <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_error" runat="server"  class="textos_error" Text=""></asp:Label>
                        
                        </td>
                    </tr>
                <tr>
                    <td colspan="4" >
                        <asp:Label ID="lbl_mensaje" runat="server"  CssClass="textos_error" Text=""></asp:Label>
                        
                        </td>
                    </tr>
                 <tr>
                    <td  colspan="4">
                        <asp:Label ID="Label2" runat="server"  CssClass="Subtitulo2" Text="Sucursal: "></asp:Label>
                        <asp:Label ID="lbl_cod_suc" runat="server"  CssClass="Subtitulo2" Text=""></asp:Label>
                        <asp:Label ID="lbl_sucursal" runat="server"  CssClass="Subtitulo2" Text=""></asp:Label>&nbsp;&nbsp;
                        <asp:Label ID="lbl_pre" runat="server"  CssClass="Subtitulo2" Text="Prefijo:" Visible="false"></asp:Label>
                        <asp:Label ID="lbl_prefijo" runat="server" CssClass="Subtitulo2" Text="" Visible="false"></asp:Label>
                        </td>
                    
                    </tr>
                <tr>
                    <td>
                        
                    </td>
                </tr>
                 <tr>
                        <td>
                         
                      <table align="center">
                        <tr >
                          <td  class="auto-style1">Factura desde:</td>
                          <td>
                              <asp:TextBox ID="txtx_fac_desde" class="textos"  width="203" runat="server"  ></asp:TextBox>
                              
                              </td>
                             <td class="auto-style2">Factura hasta:</td>
                          <td>
                              <asp:TextBox ID="txt_fac_hasta"  class="textos"  width="203" runat="server"></asp:TextBox>
                          </td>
                            <td>
                                <asp:Button ID="btn_verificar" runat="server" CssClass="botones" Text="Verificar" OnClick="btn_verificar_Click" />

                            </td>
                           
                        </tr>
                          <tr >
                              <td>
                              <asp:Label ID="lbl_total_fac" runat="server" visible="false"  class="textos" Text="Total Facturas a procesar:"></asp:Label>

                              </td>
                             <td>
                                  <asp:Label ID="lbl_facturas_total" class="textos"  runat="server" Text=""></asp:Label>

                             </td> 
                              <td>
                                  <asp:Button ID="btn_procesar" class="botones" visible="false" runat="server" Text="Procesar" OnClick="btn_procesar_Click" />
                              </td>
                          </tr>
                          </table>
                            </td>
                     </tr>
                       
                </table>
                    </div>
                  </form>
</body>
</html>
