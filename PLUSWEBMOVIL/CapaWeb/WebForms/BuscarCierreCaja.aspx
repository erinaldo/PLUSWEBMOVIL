<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="BuscarCierreCaja.aspx.cs" Inherits="CapaWeb.WebForms.BuscarCierreCaja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <form id="form1" name="form1" class="forms-sample" runat="server" method="post">
         <div style="align-items: left">
            <table>
                 <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0">
                                <tr>
                                    <td class="nav">---&gt;<a href="<%Response.Write(Modelowmspclogo.sitio_app + "Menu_Ppal.asp"); %>">Menu Principal</a>---&gt;Cierre Caja</td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                <tr>
                    <td>
                      
                        <asp:Label ID="lblAyuda" runat="server"  CssClass="Titulo" Text="Cierre de Caja Diario"></asp:Label>
                        
                        </td>
                    </tr>
                <tr>
                    <td>
                        <p class="Subtitulo2">Para realizar&nbsp; nuevo Cierre de Caja 
                                <asp:Button ID="NuevoCierre" onclick="NuevoCierre_Click"  class="botones" runat="server" Text="AQUI" />
                          </p>
                        </td>
                    </tr>
               
                
                 <tr>
                    <td>
                        <asp:Label ID="txtAcceso" runat="server" Visible="false" CssClass="Titulo" Text="El Usuario registrado no tiene permiso para ejecutar estos procesos"></asp:Label>
                        
                        </td>
                    </tr>
                <tr>
                    <td>
                         <p class="Subtitulo1">Busque el registro deseado por:</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                         
                      <table align="center">
                      
                         
                        
                        
                        <tr valign="top">
                         <td width="20%" class="busqueda">Fecha Cierre:</td>
                         
                          <td>
                                <asp:TextBox ID="fechainicio" type="date"  Width="202" AutoPostBack = "True"  runat="server" OnTextChanged="fechainicio_TextChanged"></asp:TextBox>
                            </td>
                           
                            <td width="20%" class="busqueda">Lista Cierres Caja</td>
                            <td>
                                <asp:DropDownList ID="cbx_lista_cierres" CssClass="textos" runat="server"></asp:DropDownList>
                            </td>
                             <td aling="rigth">
                                 <asp:Button ID="Buscar" runat="server" onclick="Buscar_Click" class="botones" Text="Buscar" /></td>
                            
                            
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

                        <div class="Subtitulo1">Listado de Cierres de Caja</div>
                    </td>
                </tr>
                <tr>
                    <td>
                    <div id="areaImprimir" style="align-items: center">
                            <style type="text/css">

                                 @media print {
                                     body {
        background: #fff !important;
    }
                                    }

                                .tftable {
                                    width: 100%;
                                    border-width: 0px;
                                    border-color: #DD6D29;
                                    border-collapse: collapse;
                                }


                                    .tftable td {
                                        border-width: 0px;
                                        padding: 6px;
                                        border-style: solid;
                                        border-top: #DD6D29 1px dashed;
                                        border-bottom: #DD6D29 1px dashed;
                                    }


                                .fondo {
                                    color: #DD6D29;
                                    font-weight: bold;
                                }

                                @media print {
                                    .noimp {
                                        display: none;
                                    }
                                }

                                .label {
                                    color: #ffffff;
                                }

                                @media print {
                                    .label {
                                        color: black;
                                    }
                                }
                            </style>
                        <table style="width: 100%;">
                       <tr rowspan="4">
                                    <td colspan="4">
                                        <table style="width: 100%;" runat="server" id="Tabla">
                                            <tr>
                                                <td colspan="3">
                                                    <table style="width: 100%;">
                                                    <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" CssClass="Titulo" Text="Cierre Caja"></asp:Label>
                                    </td>
                                    <td style="width: 33px">
                                        <div class="Subtitulo1">DIA:</div>
                                    </td>
                                    <td>

                                        <asp:Label ID="lbl_fecha" runat="server" class="Subtitulo1" Text="Label"></asp:Label>

                                    </td>
                                    <td>

                                        <asp:Label ID="lbl_dia" runat="server" class="Subtitulo1" Text="LUNES"></asp:Label>

                                    </td>
                                </tr>
                                                    <tr>
                                    <td colspan="4">
                                        <hr />
                                    </td>
                                </tr>
                                       </table>                  </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="mensaje" name="mensaje" runat="server" class="fondo" Text="RESÚMEN DEL DÍA"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Label ID="mensaje1" name="mensaje1" runat="server" class="fondo" Text="DETALLE DEL EFECTIVO DE CAJA"></asp:Label>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <table align="center" border="1" class="tftable">

                                                        <tr valign="top">
                                                            <td class="textos">
                                                                <div align="left">+</div>
                                                            </td>
                                                            <td class="textos">
                                                                <asp:Label ID="lbl_idc" runat="server" Text="VALOR EN CAJA INICIO DEL DIA"></asp:Label>
                                                               
                                                            </td>

                                                            <td class="busqueda">
                                                                <asp:TextBox ID="txt_valor_id" Style="text-align: right" required="required" runat="server" value="0"></asp:TextBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="textos">
                                                                <div align="left">+</div>
                                                            </td>
                                                            <td class="textos">
                                                                <asp:Label ID="lbl_2" runat="server" Text="INGRESOS POR FACTURAS"></asp:Label>
                                                              
                                                            </td>

                                                            <td class="textos">
                                                                <asp:TextBox ID="txt_ingreso_facturas" Style="text-align: right" ReadOnly="true" required="required" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="noimp">
                                                                    <asp:ImageButton ID="btn_ingreso_facturas" src="../Tema/imagenes/search.png" runat="server" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="textos">
                                                                <div align="left">+</div>
                                                            </td>
                                                            <td class="textos">
                                                                <asp:Label ID="lbl_3" runat="server" Text="INGRESOS POR NOTAS DE VENTA"></asp:Label>
                                                                
                                                            </td>

                                                            <td class="textos">
                                                                <asp:TextBox ID="txt_ingreso_nventas" Style="text-align: right" required="required" ReadOnly="true" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="noimp">
                                                                    <asp:ImageButton ID="btn_ingreso_nventas" src="../Tema/imagenes/search.png" runat="server" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="textos">
                                                                <div align="left">-</div>
                                                            </td>
                                                            <td class="textos">
                                                                <asp:Label ID="lbl_4" runat="server" Text="PAGOS EN EFECTIVO DE FACTURAS"></asp:Label>
                                                                
                                                            </td>

                                                            <td class="textos">
                                                                <asp:TextBox ID="txt_pefectivo_facturas" Style="text-align: right" required="required" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="noimp">
                                                                    <asp:ImageButton ID="btn_pefectivo_facturas" src="../Tema/imagenes/search.png" runat="server" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="textos">
                                                                <div align="left">-</div>
                                                            </td>
                                                            <td class="textos">
                                                                <asp:Label ID="lbl_5" runat="server" Text="PAGOS EN EFECTIVO OTROS"></asp:Label>
                                                                
                                                            </td>

                                                            <td class="busqueda">
                                                                <asp:TextBox ID="txt_pefectivo_otros" Style="text-align: right" required="required" runat="server" value="0"></asp:TextBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="textos">
                                                                <div align="left">-</div>
                                                            </td>
                                                            <td class="textos">
                                                                <asp:Label ID="lbl_6" runat="server" Text="DEPOSITOS DEL DIA"></asp:Label>
                                                                
                                                            </td>

                                                            <td class="textos">
                                                                <asp:TextBox ID="txt_depositos" Style="text-align: right" required="required" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="noimp">
                                                                    <asp:ImageButton ID="btn_depositos" src="../Tema/imagenes/search.png" runat="server" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:GridView ID="Grid" runat="server"
                                                        AutoGenerateColumns="False" AllowPaging="True" class="table table-hover"
                                                        OnItemCommand="Grid_ItemCommand" AllowSorting="True" ShowFooter="True"
                                                        PageSize="11" CellPadding="2" BackColor="White" BorderColor="#DD6D29" BorderStyle="None" BorderWidth="0px" CellSpacing="1" ShowHeader="False">
                                                        <Columns>
                                                            
                                                             <asp:BoundField DataField="Observaciones"  HeaderText="Observaciones" ItemStyle-CssClass="textos" SortExpression="id"  />
                                                            <asp:BoundField DataField="valor"  Visible="false" HeaderText="valor" ItemStyle-CssClass="textos" SortExpression="id"  />
                                                            <asp:BoundField DataField="cantidad"  HeaderText="cantidad" ItemStyle-CssClass="textos" SortExpression="id"  />
                                                            <asp:BoundField DataField="canti"  HeaderText="total" ItemStyle-CssClass="textos" SortExpression="id"  />
                                                           

                                                        </Columns>

                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" colspan="3">

                                                    <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>

                                                                <asp:Label ID="Label1" CssClass="fondo" runat="server" Text="SALDO EN CAJA FINAL DEL DÍA"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txt_saldo_caja" CssClass="textos" ReadOnly="true" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" CssClass="fondo" Text="VALOR EN CAJA"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txt_valor_caja" CssClass="textos" ReadOnly="true" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" CssClass="fondo" Text="DIFERENCIA"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txt_diferencia" CssClass="textos" ReadOnly="true" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td></td>
                                                <td>&nbsp;</td>
                                                <td></td>
                                            </tr>

                                            <tr>
                                                <td><table style="width: 100%;  text-align: center;">
                                                        <tr>
                                                            <td>
                                                                <label class="label">
                                                                    _____________________________________
                                                             
                                                                </label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td >
                                                                
                                                                <asp:Label ID="Lbl_Usuario" CssClass="label" runat="server" Text=""></asp:Label>
                                                                
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td >
                                                               <label  class="label">
                                                                  RESPONSABLE DE LA CAJA                                                             
                                                                </label></td>
                                                        </tr>
                                                    </table></td>
                                                <td>&nbsp;</td>
                                                <td><table style="width: 100%;  text-align: center;">
                                                        <tr>
                                                            <td>
                                                                <label class="label">
                                                                    _____________________________________
                                                             
                                                                </label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td >
                                                                
                                                                
                                                                
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td >
                                                               <label  class="label">
                                                                  SUPERVISOR                                                            
                                                                </label></td>
                                                        </tr>
                                                    </table></td>
                                            </tr>
                                        </table></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
  </table>
                                   
                   </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                        &nbsp;&nbsp;&nbsp;
                                    <input type="button" id="imp" runat="server" class="botones" onclick="printDiv('areaImprimir')" value="Imprimir" />
                         &nbsp;&nbsp;&nbsp;
                        
                    </td>
                </tr>
          
                     
                </table>
                    </div>
                  </form>
     <script>
        function printDiv(nombreDiv) {
            var contenido = document.getElementById(nombreDiv).innerHTML;
            var contenidoOriginal = document.body.innerHTML;

            document.body.innerHTML = contenido;

            window.print();

            document.body.innerHTML = contenidoOriginal;
        }
    </script>
</asp:Content>
