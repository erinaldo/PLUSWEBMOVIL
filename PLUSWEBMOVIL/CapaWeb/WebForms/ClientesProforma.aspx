<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientesProforma.aspx.cs" Inherits="CapaWeb.WebForms.ClientesProforma" %>
<link href="../Tema/css/StylePront.css" rel="stylesheet" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
     <script LANGUAGE="JavaScript">

var cuenta=0;

function enviado() { 
if (cuenta == 0)
{
cuenta++;
return true;
}
else 
{
alert("Excel de clientes ya ha sido enviado, espere por favor.");
return false;
}
}
// -->
</script>
      <form id="form1" name="form1" class="forms-sample" runat="server" method="post" onSubmit="return enviado()">
         <div style="align-items: left">
            <table  width="95%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="white">
                           
                   
               <tr>
                     <td colspan="4">

                         <hr />
                    </td>
                </tr>
                <tr>
                     <td colspan="4">
                        <asp:Label ID="lbl_error" runat="server"  class="textos_error" Text=""></asp:Label>
                        
                        </td>
                    </tr>
                <tr>
                     <td >
                        <asp:Label ID="Label1" runat="server"  class="Subtitulo1" Text="Carga Masiva Clientes Pedidos "></asp:Label>
                        </td>

                    </tr>
                <tr valign="top">
                    <td align="right" colspan="2" class="busqueda">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                    <td class="botones" colspan="2" align="left">
                        <asp:Button ID="btn_importar" CssClass="botones" OnClick="btn_importar_Click" runat="server" Text="Importar" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_mensaje" runat="server" CssClass="busqueda" Text=""></asp:Label>
                    </td>
                </tr>
              
            
                <tr>
                     <td colspan="4">

                         <hr />
                    </td>
                </tr>
        


                     
                </table>
                    </div>
                  </form>
</body>
</html>
