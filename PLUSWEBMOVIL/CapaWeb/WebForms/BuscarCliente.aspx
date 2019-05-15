<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarCliente.aspx.cs" Inherits="CapaWeb.WebForms.BuscarCliente" %>

<link href="../Tema/css/modal.css" rel="stylesheet" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="white">
       <tr>
           <td colspan="4">
            
               <asp:Label ID="Label1" runat="server" class="texto" Text="Label">Buscar Cliente</asp:Label>
                
              </td>
            <td colspan="4">
                <asp:TextBox class="texto" size="40" maxlength="50"  ID="TxtBuscarCliente" AutoPostBack="True"  OnTextChanged="TxtBuscarCliente_TextChanged" placeholder="Identificación/ Nombre" runat="server" />
           </tr>
        <tr>

        </tr>   
                <tr>
                  <br />
                    <br />  
         
       
                   

                        <table border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#0E748A">
                            <tr>
                                <td>

                                    <asp:GridView ID="gvPerson" runat="server" AutoGenerateColumns="False"
                                        CellPadding="4" BackColor="#DD6D29" DataKeyNames="cod_tit"
                                         OnPageIndexChanging="gvPerson_PageIndexChanging" AllowPaging="true" OnSelectedIndexChanged="gvPerson_SelectedIndexChanged">
                                        <RowStyle BackColor="#EFF3FB" />
                                        <Columns>

                                            <asp:BoundField DataField="nom_tit" HeaderText="Cliente" />
                                            <asp:BoundField DataField="nro_dgi1" HeaderText="Cédula" />
                                            <asp:BoundField DataField="tel_tit" HeaderText="Teléfono" />

                                            <asp:ButtonField ButtonType="Button"  ControlStyle-CssClass="botones" CommandName="Select" HeaderText="Seleccionar" ShowHeader="True" Text="Seleccionar" />

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
         
           </tr>
                              
    </table>
        </form>
      
</body>
</html>
