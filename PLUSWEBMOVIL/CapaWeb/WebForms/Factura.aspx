<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="CapaWeb.WebForms.Factura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Tema/css/modal.css" rel="stylesheet" />
    
   <tr>
       <td>

 

    <p class="Subtitulo1">Por favor ingrese los datos solicitados:</p>
    <form id="form1" class="forms-sample" runat="server">
        
        <table align="center">
            <tr valign="top">
                <td align="right" nowrap="nowrap" class="busqueda">
                    <div align="left">Cliente:</div>
                </td>
                <td class="textos">
                    <asp:TextBox ID="dniCliente" placeholder="Cédula" runat="server"></asp:TextBox>
                 <a href="#modal-one" class="botones ">Nuevo Cliente</a>
                    </td>   
                         <td class="textos">
                                    
                                    <asp:TextBox required="required" ID="nombreCliente" class="textos" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            
            </tr>
            <tr valign="top">
               <td align="right" nowrap="nowrap" class="busqueda">
                    <div align="left">Fecha:</div>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" type="date" runat="server"></asp:TextBox>
                    
                </td>
                     <td align="right" nowrap="nowrap" class="busqueda">
                    <div align="left">Serie Documento:</div>
                </td>
                <td>
                    <label>
                        <select name="serie_docum" class="textos" id="serie_docum" tabindex="3">
                        </select>
                    </label>
                </td>

            </tr>

            <tr valign="top">
                <td align="right" nowrap="nowrap" class="busqueda">
                    <div align="left">C. Costos:</div>
                </td>
                <td>
                    <select name="cod_ccostos" class="textos" tabindex="3">
                    </select>
                </td>

                <td align="right" nowrap="nowrap" class="busqueda">
                    <div align="left">Moneda:</div>
                </td>
                <td>
                    <label>
                        <select name="cod_moneda" class="textos" id="cod_moneda" tabindex="4">
                        </select>
                    </label>
                </td>
            </tr>

            <tr valign="top">
                <td align="right" nowrap="nowrap" class="busqueda">
                    <div align="left">Vendedor:</div>
                </td>
                <td>
                    <select name="cod_vendedor" class="textos" tabindex="5">
                    </select>
                </td>
                <td align="right" nowrap="nowrap" class="busqueda">
                    <div align="left">O.Compra:</div>
                </td>
                <td>
                    <label>
                        <input name="ocompra" type="text" class="textos" id="ocompra" tabindex="6" size="15" maxlength="20" />
                    </label>
                </td>
            </tr>
            <tr valign="top">
                <td align="right" nowrap="nowrap" class="busqueda">
                    <div align="left">F. Pago:</div>
                </td>
                <td>
                    <select name="cod_fpago" class="textos" tabindex="7">
                    </select>
                </td>
                <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                    <div align="left">% Descuento:</div>
                </td>
                <td valign="top">
                    <label>
                        <input name="porc_descto" type="text" class="textos" id="porc_descto" tabindex="8" value="0" size="10" maxlength="8" />
                    </label>
            </tr>

  
            <tr>
                <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                    <div align="left">Observaciones:</div>
                </td>
                <td valign="top">
                    <textarea onkeypress="return taLimit(this)" onkeyup="return taCount(this,'myCounter')" name="observaciones" rows="5" wrap="physical" cols="50" class="textos" id="observaciones" tabindex="9"></textarea>
                    <div class="textos2" align="left">Caracteres disponibles: <b><span id="myCounter">250</span></b></div>
                </td>
            </tr>
            <tr valign="top">
                <td nowrap="nowrap" align="right">&nbsp;</td>
                <td>
                    <input type="submit" class="botones" value="Aceptar" tabindex="10" />
                </td>
            </tr>

        </table>
  
        <div class="Subtitulo2" align="center">Nuevos Productos o Servicios</div>
              <form id="form3" name="form3" method="post" action="Reg_FacturasVN_Art.asp">
                <table border="0" align="center" cellpadding="0" cellspacing="0" id="Tabla_Det3">
                    <tr valign="top">
                      <td class="busqueda">Articulo:</td>
                      <td>
                        <div align="center">
                          <input name="articulo" type="text" class="textos" id="articulo" tabindex="1" size="40" maxlength="50" />
                      </div>
                      <div class="textos_sm">Codigo o Nombre</div>                      </td>
                      <td>
                          <a href="#modal-two" class="botones ">Buscar</a>
                                             </td>
                    </tr>
                  </table>
              </form>
        </br>
        </br>
        <table border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#0E748A">
                    <tr valign="top">
                      <td class="titulos"><div align="center">#</div></td>
                      <td class="titulos"><div align="center">codigo</div></td>
                      <td class="titulos"><div align="center">descripcion</div></td>
                      <td class="titulos"><div align="center">descripcion 2</div></td>
                      <td class="titulos"><div align="center">c.costo</div></td>
                      <td class="titulos"><div align="center">cantidad</div></td>
                      <td class="titulos"><div align="center">precio</div></td>
                      <td class="titulos"><div align="center">% dscto</div></td>
                      <td class="titulos"><div align="center">% iva</div></td>
                      </tr>
                    <tr valign="top">
                      <td class="textos"><div align="right"></div></td>
                      <td class="textos"><div align="center"></div></td>
                      <td class="textos"><div align="center"></div></td>
                      <td class="textos"><textarea onKeyPress="return taLimit(this)" onKeyUp="return taCount(this,'myCounter')" name="nom_articulo2" rows=3 wrap="physical" cols=30 class="textos" id="nom_articulo2" tabindex="2"></textarea>
                   <div class="textos2" align="left">Caracteres disponibles: <B><SPAN id=myCounter>150</SPAN></B></div></td>
                   <td class="textos"><select name="cod_ccostos" class="textos" tabindex="4">

                    </select></td>
                      <td class="textos"><div align="center">
                          <input name="cantidad" type="text" class="textos" id="cantidad" tabindex="5" size="10" maxlength="10" />
                        </div></td>
                      <td class="textos"><div align="center">
                          <input name="precio_unit" type="text" class="textos" id="precio_unit" tabindex="6" size="15" maxlength="20" value=" " />
                        </div></td>
                      <td class="textos"><div align="center">
                        <input name="porc_descto" type="text" class="textos" id="porc_descto" tabindex="7" value=" "  size="8" maxlength="6"/>
                      </div></td>
                      <td class="textos"><div align="center"></div></td>
                      </tr>
                  
                  </table>

<a href="#" class="modal" id="modal-one" aria-hidden="true">
  </a>
  <div class="modal-dialog">
    <div class="modal-header">
      <h2 class="textos">Nuevo Cliente</h2>
      <a href="#" class="btn-close" aria-hidden="true">×</a>
    </div>
    <div class="modal-body">
      <table border="0" cellspacing="3" cellpadding="0" id="Tabla_Det3">
                              <tr valign="top">
                                <td class="busqueda">Doc. Legal:</td>
                                <td class="textos"></td>
                              </tr>
                              <tr valign="top">
                                <td class="busqueda">Nombres:*</td>
                                <td class="textos"><label>
                                  <input name="primer_nombre" type="text" class="textos" id="primer_nombre" tabindex="1" maxlength="30" />
                                  </label>
                                    <label>
                                    <input name="segundo_nombre" type="text" class="textos" id="segundo_nombre" tabindex="2" maxlength="30" />
                                  </label></td>
                              </tr>
                              <tr valign="top">
                                <td class="busqueda">Apellidos:*</td>
                                <td class="textos"><label>
                                  <input name="primer_apellido" type="text" class="textos" id="primer_apellido" tabindex="3" maxlength="30" />
                                  </label>
                                    <label>
                                    <input name="segundo_apellido" type="text" class="textos" id="segundo_apellido" tabindex="4" maxlength="30" />
                                  </label></td>
                              </tr>
                              <tr valign="top">
                                <td class="busqueda">Abreviacion:*</td>
                                <td>
                                <input name="cod_sop" type="text" id="cod_sop" tabindex="5" size="6" maxlength="3" /><span class="textos_sm"> 3 Caracteres</span></td>
                              </tr>
                              <tr valign="top">
                                <td class="busqueda">Direccion:*</td>
                                <td class="textos"><label>
                                  <textarea name="dir_tit" cols="40" rows="3" class="textos" id="dir_tit" tabindex="6"></textarea>
                                </label></td>
                              </tr>
                              <tr valign="top">
                                <td class="busqueda">Telefonos:*</td>
                                <td class="textos"><label>
                                  <input name="tel_tit" type="text" class="textos" id="tel_tit" tabindex="7" size="15" maxlength="20" />
                                  </label>
                                    <label>
                                    <input name="fax_tit" type="text" class="textos" id="fax_tit" tabindex="8" size="15" maxlength="20" />
                                  </label></td>
                              </tr>
                              <tr valign="top">
                                <td class="busqueda">Email:</td>
                                <td class="textos"><label>
                                  <input name="email_tit" type="text" class="textos" id="email_tit" tabindex="9" size="40" maxlength="40" />
                                </label></td>
                              </tr>
                              <tr valign="top">
                                <td class="busqueda">Clasificacion DIAN:*</td>
                                <td class="textos"><label>
                                  <select name="cod_tipo_emp_iva" class="textos" id="cod_tipo_emp_iva" tabindex="10">
                                   
                                  </select>
                                </label></td>
                              </tr>
                              <tr valign="top">
                                <td class="busqueda">Tipo Regimen:*</td>
                                <td class="textos"><label>
                                  <select name="cod_tipo_emp_gan" class="textos" id="cod_tipo_emp_gan" tabindex="11">
                                    
                                  </select>
                                </label></td>
                              </tr>
                              <tr valign="top">
                                <td>&nbsp;</td>
                                <td><input name="button2" type="submit" class="botones" id="button2" tabindex="12"  value="Informacion Geografica" />
                                    <div class="textos_sm">* Campos Obligatorios</div></td>
                              </tr>
                            </table>
    </div>
    <div class="modal-footer">
         <input type="submit" class="botones" value="Guardar" tabindex="10" />
      
    </div>
  </div>


<a href="#" class="modal" id="modal-two" aria-hidden="true">
  </a>
  <div class="modal-dialog">
    <div class="modal-header">
      <h2 class="textos">Nuevo Producto</h2>
      <a href="#" class="btn-close" aria-hidden="true">×</a>
    </div>
    <div class="modal-body">
       
                    <table border="0" cellspacing="3" cellpadding="0" id="Tabla_Det3">
                             
                              <tr valign="top">
                                <td class="busqueda">Codigo:*</td>
                                <td>
                                <input name="cod_sop" type="text" id="cod_sop1" tabindex="5" size="6" maxlength="3" /></td>
                              </tr>
                              <tr valign="top">
                                <td class="busqueda">Descripción:*</td>
                                <td class="textos"><label>
                                  <textarea name="dir_tit" cols="40" rows="3" class="textos" id="dir_tit1" tabindex="6"></textarea>
                                </label></td>
                              </tr>
                              <tr valign="top">
                                <td class="busqueda">Descripcion2:*</td>
                                <td class="textos"><label>
                                  <input name="tel_tit" type="text" class="textos" id="tel_tit1" tabindex="7" size="15" maxlength="20" />
                                  </label>
                                   
                              </tr>
                              <tr valign="top">
                                <td class="busqueda">C.costo:</td>
                                <td class="textos"><label>
                                  <input name="email_tit" type="text" class="textos" id="email_tit1" tabindex="9" size="40" maxlength="40" />
                                </label></td>
                              </tr>
                              <tr valign="top">
                                <td class="busqueda">Cantidad:*</td>
                                <td class="textos"><label>
                                  <input name="email_tit" type="text" class="textos" id="email_tit2" tabindex="9" size="40" maxlength="40" />
                                   
                                  </select>
                                </label></td>
                              </tr>
                              <tr valign="top">
                                <td class="busqueda">Precio:*</td>
                                <td class="textos"><label>
                                  <input name="email_tit" type="text" class="textos" id="email_tit3" tabindex="9" size="40" maxlength="40" />
                                    
                                  </select>
                                </label></td>
                              </tr>
                         <tr valign="top">
                                <td class="busqueda">%dscto:*</td>
                                <td class="textos"><label>
                                  <input name="email_tit" type="text" class="textos" id="email_tit4" tabindex="9" size="40" maxlength="40" />
                                  
                                </label></td>
                              </tr>
                              <tr valign="top">
                                <td class="busqueda">%iva:*</td>
                                <td class="textos"><label>
                                 <input name="email_tit" type="text" class="textos" id="email_tit17" tabindex="9" size="40" maxlength="40" />
                                    
                                  
                                </label></td>
                              </tr>
                            </table>
                
                
               
              
        </div>
    <div class="modal-footer">
         <input type="submit" class="botones" value="Guardar" tabindex="10" />
      
    </div>
  </div>           
                 
               
           </form>
          </td>
   </tr>              
</asp:Content>
