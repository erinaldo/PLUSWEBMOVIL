using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
    public class Consultawmspcresfact
    {
        SerieDocumento seriedocumento = new SerieDocumento();
        modelowmspcresfact resolucionesfac = new modelowmspcresfact();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        UsuarioSucursal BuscarSucursal = new UsuarioSucursal();
        string metodo = "Consultawmspresfact.cs";
        public List<modelowmspcresfact> ConsultaResolusiones(string ResF_usuario, string ResF_cod_emp, string ResF_estado, string ResF_serie, string ResF_tipo)
        {
            try
            {
                List<modelowmspcresfact> lista = new List<modelowmspcresfact>();
                lista = seriedocumento.ListaBuscaSerieDocumento(ResF_usuario, ResF_cod_emp, ResF_estado, ResF_serie, ResF_tipo);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ResF_cod_emp,metodo, "ConsultaResolusiones", e.ToString(), DateTime.Now, ResF_usuario);
                return null;
            }

        }
        //PROCESO PARA TRAER LA RESOLUCON DE FACTURA POR SUCURSAL-usuario
        public List<modelowmspcresfact> ConsultaResolusionXSucursal(string ResF_usuario, string ResF_cod_emp, string ResF_estado, string ResF_serie, string ResF_tipo, string sucursal)
        {
            try
            {
                List<modelowmspcresfact> lista = new List<modelowmspcresfact>();
                List<modelowmspcresfact> listaAux = new List<modelowmspcresfact>();
                modeloUsuariosucursal modeloSucursal = new modeloUsuariosucursal();
                modeloUsuariosucursal modeloSucursal2 = new modeloUsuariosucursal();
                lista = seriedocumento.ListaBuscaSerieDocumento(ResF_usuario, ResF_cod_emp, ResF_estado, ResF_serie, ResF_tipo);
   
                foreach (var item in lista)
                {
                    modeloSucursal = BuscarSucursal.PrefijoSucursalXUsuFactura(ResF_cod_emp, ResF_usuario, item.serie_docum.Trim());
                    if(modeloSucursal.cod_sucursal ==null || modeloSucursal.cod_sucursal == "")
                    {
                        modeloSucursal2 = BuscarSucursal.PrefijoSucursalXUsuFacturaN(ResF_cod_emp, ResF_usuario, item.serie_docum.Trim());
                        if (modeloSucursal2.cod_sucursal == null || modeloSucursal2.cod_sucursal == "")
                        {

                        }
                        else
                        {
                            item.cod_sucursal = modeloSucursal2.cod_sucursal;
                            item.nom_sucursal = modeloSucursal2.nom_sucursal;
                            listaAux.Add(item);
                        }
                    }
                    else
                    {
                        item.cod_sucursal = modeloSucursal.cod_sucursal;
                        item.nom_sucursal = modeloSucursal.nom_sucursal;
                        listaAux.Add(item);
                    }
                }
                    return listaAux;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ResF_cod_emp, metodo, "ConsultaResolusionXSucursal", e.ToString(), DateTime.Now, ResF_usuario);
                return null;
            }

        }
        //PROCESO PARA TRAER LA RESOLUCON DE FACTURA POR SUCURSAL-usuario
        public List<modelowmspcresfact> ConsultaResolusionXSucursalNC(string ResF_usuario, string ResF_cod_emp, string ResF_estado, string ResF_serie, string ResF_tipo, string sucursal)
        {
            try
            {
                List<modelowmspcresfact> lista = new List<modelowmspcresfact>();
                List<modelowmspcresfact> listaAux = new List<modelowmspcresfact>();
                modeloUsuariosucursal modeloSucursal = new modeloUsuariosucursal();
                modeloUsuariosucursal modeloSucursal2 = new modeloUsuariosucursal();
                lista = seriedocumento.ListaBuscaSerieDocumento(ResF_usuario, ResF_cod_emp, ResF_estado, ResF_serie, ResF_tipo);

                foreach (var item in lista)
                {
                    modeloSucursal = BuscarSucursal.PrefijoSucursalXUsuNC(ResF_cod_emp, ResF_usuario, item.serie_docum.Trim());

                    if (modeloSucursal.cod_sucursal == null || modeloSucursal.cod_sucursal == "")
                    {
                        modeloSucursal2 = BuscarSucursal.PrefijoSucuXUsuNCERP(ResF_cod_emp, ResF_usuario, item.serie_docum.Trim());
                        if (modeloSucursal2.cod_sucursal == null || modeloSucursal2.cod_sucursal == "")
                        {

                        }
                        else
                        {
                            item.cod_sucursal = modeloSucursal2.cod_sucursal;
                            item.nom_sucursal = modeloSucursal2.nom_sucursal;
                            listaAux.Add(item);

                        }
                    }
                    else
                    {
                        item.cod_sucursal = modeloSucursal.cod_sucursal;
                        item.nom_sucursal = modeloSucursal.nom_sucursal;
                        listaAux.Add(item);
                    }
                }
                return listaAux;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ResF_cod_emp, metodo, "ConsultaResolusionXSucursalNC", e.ToString(), DateTime.Now, ResF_usuario);
                return null;
            }

        }
        //PROCESO PARA TRAER LA RESOLUCON DE FACTURA POR SUCURSAL-usuario
        public List<modelowmspcresfact> ConsultaResolusionXSucursalND(string ResF_usuario, string ResF_cod_emp, string ResF_estado, string ResF_serie, string ResF_tipo, string sucursal)
        {
            try
            {
                List<modelowmspcresfact> lista = new List<modelowmspcresfact>();
                List<modelowmspcresfact> listaAux = new List<modelowmspcresfact>();
                modeloUsuariosucursal modeloSucursal = new modeloUsuariosucursal();
                lista = seriedocumento.ListaBuscaSerieDocumento(ResF_usuario, ResF_cod_emp, ResF_estado, ResF_serie, ResF_tipo);

                foreach (var item in lista)
                {
                    modeloSucursal = BuscarSucursal.PrefijoSucursalXUsuND(ResF_cod_emp, ResF_usuario, item.serie_docum.Trim());
                    if (modeloSucursal.cod_sucursal == null || modeloSucursal.cod_sucursal == "")
                    {
                        modeloSucursal = BuscarSucursal.PrefijoSucXUsuNDERP(ResF_cod_emp, ResF_usuario, item.serie_docum.Trim());
                        if (modeloSucursal.cod_sucursal == null || modeloSucursal.cod_sucursal == "")
                        {
                        }
                        else
                        {
                            item.cod_sucursal = modeloSucursal.cod_sucursal;
                            item.nom_sucursal = modeloSucursal.nom_sucursal;
                            listaAux.Add(item);
                        }
                    }
                    else
                    {
                        item.cod_sucursal = modeloSucursal.cod_sucursal;
                        item.nom_sucursal = modeloSucursal.nom_sucursal;
                        listaAux.Add(item);
                    }
                }
                return listaAux;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ResF_cod_emp, metodo, "ConsultaResolusionXSucursalND", e.ToString(), DateTime.Now, ResF_usuario);
                return null;
            }

        }
    }
}
