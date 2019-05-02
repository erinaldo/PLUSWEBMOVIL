<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FPagoPos.aspx.cs" Inherits="CapaWeb.WebForms.FPagoPos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <tr>
    <td>
    <table border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#0E748A">
    <tr>
        <td>

            <asp:DataGrid ID="Grid" runat="server" AutoGenerateColumns="False" >
                <Columns>
                    <asp:TemplateColumn  HeaderText="Empresa" Visible="False">
                        <ItemTemplate>
                            <span style="float: left;">
                                <asp:Label  ID="lblId" runat="server" Text='<%#Eval("cod_emp") %>'></asp:Label>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateColumn>

                    <asp:TemplateColumn HeaderText="Codigo">
                        <ItemTemplate>
                            <span style="float: left;">
                                <asp:Label ID="cod_fpago" runat="server" Text='<%#Eval("cod_fpago") %>'></asp:Label>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateColumn>

                    <asp:TemplateColumn HeaderText="Forma Pago">
                        <ItemTemplate>
                            <span style="float: left;">
                                <asp:Label ID="cod_docum" runat="server" Text='<%#Eval("nom_fpago") %>'></asp:Label>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateColumn>


                    



                </Columns>


                <FooterStyle BackColor="White" ForeColor="#00000f" />
                <HeaderStyle  BackColor="#DD6D29" Font-Bold="True" ForeColor="#FFFFFF" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                <ItemStyle ForeColor="#000000" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                <SelectedItemStyle BackColor="#0E748A" Font-Bold="True" ForeColor="White" />


            </asp:DataGrid>


        </td>
    </tr>
</table>
    </td>
</tr>
</asp:Content>
