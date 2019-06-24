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
         

                        <h2 class="Titulo">Detalle de Impuestos</h2>
                        


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
                                         OnPageIndexChanging="gvProducto_PageIndexChanging" AllowPaging="true" >
                                        <RowStyle BackColor="#EFF3FB" />
                                            <Columns>
                                                <asp:BoundField  DataField="cod_tipo_impu"  HeaderText="IMPUESTO" />
                                                <asp:BoundField  DataField="nom_impuesto"  HeaderText="DESCRIPCION"  />
                                                <asp:BoundField  DataField="cod_tasa_impu" HeaderText="TASA"  />
                                                <asp:BoundField  DataField="nom_tasa"  HeaderText="NOMBRE" />
                                                <asp:BoundField  DataField="base_impu"  HeaderText="BASE" />
                                                <asp:BoundField  DataField="porc_impu"  HeaderText="%" DataFormatString="{0:N}"/>
                                                <asp:BoundField  DataField="valor_impu"  HeaderText="VALOR" />
                                                
                                            </Columns>
                                              <FooterStyle BackColor="#CC0066" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#DD6D29" ForeColor="White" HorizontalAlign="Center" BorderStyle="None" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#DD6D29" Font-Bold="True" ForeColor="White" />
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
