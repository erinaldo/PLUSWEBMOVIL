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
   public  class ConsultawmusuarioSucursal
    {
        //Buscar unico usuario x sucursal
        UsuarioSucursal UnicoUsuario = new UsuarioSucursal();
       string metodo ="ConsultawmusuarioSucursal.cs";
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<modeloUsuariosucursal> UnicoUsuarioSucursal(string Ccf_cod_emp, string usuario, string cod_sucursal)
        {
            try
            {
                List<modeloUsuariosucursal> lista = new List<modeloUsuariosucursal>();
                lista = UnicoUsuario.UnicoUsuarioxSucursal(Ccf_cod_emp, usuario, cod_sucursal);

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "UnicoUsuarioSucursal", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
        //Buscar usuario x sucursal
        UsuarioSucursal consultaUsuario = new UsuarioSucursal();
       
        public List<modeloUsuariosucursal> ConsultaUsuarioSucursal(string Ccf_cod_emp, string usuario)
        {
            try
            {
                List<modeloUsuariosucursal> lista = new List<modeloUsuariosucursal>();
                lista = consultaUsuario.ConsultaUsuarioxSucursal(Ccf_cod_emp, usuario);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ConsultaUsuarioSucursal", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

        //Lista de usuarios por sucursal
        UsuarioSucursal ListaUsuario = new UsuarioSucursal();
       
        public List<modeloUsuariosucursal> ListaUsuarioSucursal(string Ccf_cod_emp)
        {
            try
            {
                List<modeloUsuariosucursal> lista = new List<modeloUsuariosucursal>();
                lista = ListaUsuario.ListaUsuarioxSucursal(Ccf_cod_emp);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "ListaUsuarioSucursal", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
    }
}
