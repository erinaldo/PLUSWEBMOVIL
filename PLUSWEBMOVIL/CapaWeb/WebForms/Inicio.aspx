<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="CapaWeb.WebForms.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 
 <link rel="shortcut icon" href="../Tema/imagenes/logo_ico.jpg" />
<title>Facturas de Venta - Nuevo</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link rel="stylesheet" href="../../Tema/css/Style.css" />

</head>
<body>
    <table width="984" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr height="100">

                        <td>
                            <div align="center">
                                <img src="../Tema/imagenes/Titulo_Superior.png" alt="Version" /></div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr>

            <td>


                <table width="950" border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#0E748A">
                    <tr>
                        <td class="Subtitulo1">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td><a href="Tablero_Control.asp">
                                        <img src="../Tema/imagenes/32X32/application_search.png" alt="Tablero Control" width="32" height="32" border="0" /></a></td>
                                    <td><a href="Tablero_Control.asp">TABLERO DE CONTROL</a></td>
                                </tr>
                            </table>
                        </td>

                        <td class="Subtitulo1">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td><a href="MenuAdmin.asp">
                                        <img src="../Tema/imagenes/32X32/lock.png" alt="Administracion" width="32" height="32" border="0" /></a></td>
                                    <td><a href="MenuAdmin.asp">ADMINISTRACION</a></td>
                                </tr>
                            </table>
                        </td>
                        <td class="Subtitulo1">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td><a href="Menu_Ppal.asp">
                                        <img src="../Tema/imagenes/32X32/home.png" alt="Home" width="32" height="32" border="0" /></a></td>
                                    <td><a href="Menu_Ppal.asp">MENU PRINCIPAL</a></td>
                                </tr>
                            </table>
                        </td>
                        <td class="Subtitulo1">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td><a href="Menu_Ppal.asp">
                                        <img src="../Tema/imagenes/32X32/block.png" alt="Log Off" width="32" height="32" border="0" /></a></td>
                                    <td><a href="Menu_Ppal.asp">SALIR</a></td>
                                </tr>
                            </table>
                        </td>
                        <td class="Subtitulo2" width="20%">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <img src="../Tema/imagenes/32X32/user.png" alt="Usuario" width="32" height="32" border="0" title="Usuario Activo" /></td>

                                </tr>
                            </table>
                        </td>
                </table>

            </td>
        </tr>



        <tr>
            <td>
                <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0">
                                <tr>
                                    <td class="nav">---&gt;<a href="Menu_Ppal.asp">Menu Principal</a>---&gt;<a href="Reg_MenuFacturasV.asp?cod_proceso=RCOMFACT">Facturas Venta</a>---&gt;Nuevo</td>
                                </tr>
                            </table>
                        </td>

                    </tr>

                    <form id="form1" runat="server">
                        <div>

                            <table align="left">
                                <tr valign="top">
                                    <td align="right" nowrap="nowrap" class="busqueda">
                                        <div align="left">Cliente:</div>
                                    </td>
                                    <td class="textos"><select name="cod_cliente" class="textos" tabindex="1"></select></td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top" nowrap="nowrap" class="busqueda">
                                        <div align="left">% Descuento:</div>
                                    </td>
                                    <td valign="top">
                                        <label>
                                            <input name="porc_descto" type="text" class="textos" id="porc_descto" tabindex="8" value="0" size="10" maxlength="8" />
                                        </label>
                                    </td>
                                </tr>

                                <tr valign="top">
                                    <td align="right" nowrap="nowrap" class="busqueda">
                                        <div align="left">O.Compra:</div>
                                    </td>
                                    <td>
                                        <label>
                                            <input name="ocompra" type="text" class="textos" id="ocompra" tabindex="6" size="15" maxlength="20" />
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </form>
            </td>

        </tr>


    <tr>
        <td>
            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td>
                        <img src="../Tema/imagenes/version.png" alt="Version" border="0" /></td>
                    <td align="right"><span id="siteseal">
                        <script async type="text/javascript" src="https://seal.starfieldtech.com/getSeal?sealID=GLZk7IZ70bn0PSCGC1QHZQgsLDOUt4YBxd2FhY9Gb07hNqDShY93DUuJrUof"></script>
                    </span></td>
                </tr>
            </table>
        </td>
    </tr>
  </table>
</body>
</html>
