<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormDetalleImpuestos.aspx.cs" Inherits="CapaWeb.WebForms.FormDetalleImpuestos" %>

<!DOCTYPE html>
<link href="../Tema/css/modal.css" rel="stylesheet" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="tipo_contenido"  http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="white">
  
    <div>
         

                        <h2 class="Subtitulo1">Detalle de Impuestos</h2>
                        


                       </div>
         <tr>
                    <td>

                        <hr />
                    </td>
                </tr>
                    <div>
                            <table border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#0E748A">
                                <tr>
                                    <td>

                                             <asp:GridView ID="gvProducto"  runat="server" AutoGenerateColumns="False"
                                        CellPadding="4" BackColor="#DD6D29" DataKeyNames="cod_tipo_impu"
                                         OnPageIndexChanging="gvProducto_PageIndexChanging" AllowPaging="True" >
                                        <RowStyle BackColor="#EFF3FB" />
                                            <Columns>
                                                <asp:BoundField  DataField="cod_tipo_impu" ItemStyle-CssClass="textos"  HeaderText="IMPUESTO" >
<ItemStyle CssClass="textos"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField  DataField="nom_impuesto" ItemStyle-CssClass="textos" HeaderText="DESCRIPCION"  >
<ItemStyle CssClass="textos"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField  DataField="cod_tasa_impu" ItemStyle-CssClass="textos" HeaderText="TASA"   >
<ItemStyle CssClass="textos"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField  DataField="nom_tasa" ItemStyle-CssClass="textos" HeaderText="NOMBRE"   >
<ItemStyle CssClass="textos"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField  DataField="base_impu1" ItemStyle-CssClass="textos" HeaderText="BASE" DataFormatString="{0:N}" >
<ItemStyle CssClass="textos"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField  DataField="porc_impu1" ItemStyle-CssClass="textos" HeaderText="%" DataFormatString="{0:N}">
<ItemStyle CssClass="textos"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField  DataField="valor_impu1" ItemStyle-CssClass="textos" HeaderText="VALOR"  DataFormatString="{0:N}" >
                                                
<ItemStyle CssClass="textos"></ItemStyle>
                                                </asp:BoundField>
                                                
                                            </Columns>
                                              <FooterStyle BackColor="#CC0066" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#DD6D29" ForeColor="White" HorizontalAlign="Center" BorderStyle="None" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#DD6D29" Font-Bold="True"  CssClass="busqueda" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle BackColor="White" />

                                        </asp:GridView> 

                                    </td>
                                </tr>
                            </table>

    
    </div>
     
      </table>
               <tr>
                    <td>

                         <hr />
                    </td>
                </tr>
    </div>
          <table>
                               <tr>
       
                                <td >
                                    <asp:Button ID="Cancelar" Class="botones"  runat="server" onclick="Cancelar_Click" UseSubmitBehavior="False" Text="Cancelar" />
                                    
                                </td>
                    
                            </tr>
                        </table>
    </form>
</body>
</html>
