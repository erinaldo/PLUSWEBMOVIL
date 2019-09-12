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
    public class Consultawmsptitulares
    {
        Documento documento = new Documento();
        modelowmspctitulares modelotitulares = new modelowmspctitulares();
        UsuariosSistema usuarioDatos = new UsuariosSistema();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        //usuarios del sistema
        public List<modeloUsuarioSistema> ConsultaUsuarios(string usuario_mod, string cod_emp)
        {
            try
            {
                List<modeloUsuarioSistema> lista = new List<modeloUsuarioSistema>();
                lista = usuarioDatos.ListaUsuariosSistema(usuario_mod, cod_emp);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "Consultawmsptitulares.cs", "ConsultaUsuarios", e.ToString(), DateTime.Today, usuario_mod);
                return null;
            }
        }
        public List<modelowmspctitulares> ConsultaTitulares(string Ven__usuario, string Ven__cod_emp, string Ven__cod_tipotit, string Ven__cod_tit, string Ven__cod_dgi)
        {
            try
            {
                List<modelowmspctitulares> lista = new List<modelowmspctitulares>();
                lista = documento.ListaBuscaTitulares(Ven__usuario, Ven__cod_emp, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ven__cod_emp, "Consultawmsptitulares.cs", "ConsultaTitulares", e.ToString(), DateTime.Today, Ven__usuario);
                return null;
            }
        }
        //TRaer nombre de usuario dl sistema
        public string BuscarNombreUsuario(string usuario)
        {
            try
            {

                return usuarioDatos.NombreUsuario(usuario);
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "Consultawmsptitulares.cs", "BuscarNombreUsuario", e.ToString(), DateTime.Today, usuario);
                return "No se pudo completar la acción." + "BuscarNombreUsuario." + " Por favor notificar al administrador.";
            }
        }


    }
}
