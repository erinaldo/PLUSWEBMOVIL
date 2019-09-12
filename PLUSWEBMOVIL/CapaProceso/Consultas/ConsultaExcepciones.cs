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
   public  class ConsultaExcepciones
    {
        ExepcionesPW excepcion = new ExepcionesPW();
        //Insertar  wmt_excepcion
        public string InsertarExcepciones(modeloExepciones ModeloExcepcion)
        {
            try
            {
                string respuesta = excepcion.InsertarExcepcion(ModeloExcepcion);
                return respuesta;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        //busca por id
        public List<modeloExepciones> ListaExcepcionPorID(string cod_emp, string id, string usuario_mod)
        {
            try
            {
                List<modeloExepciones> lista = new List<modeloExepciones>();
                lista = excepcion.ListaExcepcionPorID(cod_emp, id, usuario_mod);
                return lista;
            }
            catch (Exception e)
            {


                return null;
            }
        }
        public List<modeloExepciones> ListaExcepcionPC(string cod_emp, string usuario,  string proceso, DateTime fecha_ini, DateTime fecha_fin, string usuario_mod)
        {
            try
            {
                List<modeloExepciones> lista = new List<modeloExepciones>();
                lista = excepcion.ListaExcepcionPC(cod_emp, usuario,  proceso,  fecha_ini, fecha_fin, usuario_mod);
                return lista;
            }
            catch (Exception e)
            {

                
                return null;
            }
        }

        //buscar solo por fecha
        public List<modeloExepciones> ListaExcepcionPFecha(string cod_emp, DateTime fecha_ini, DateTime fecha_fin, string usuario_mod)
        {
            try
            {
                List<modeloExepciones> lista = new List<modeloExepciones>();
                lista = excepcion.ListaExcepcionPFecha(cod_emp,  fecha_ini, fecha_fin, usuario_mod);
                return lista;
            }
            catch (Exception e)
            {


                return null;
            }
        }
        //Buscar excepciones por proceso y fechas

        public List<modeloExepciones> ListaExcepcionProcesoFecha(string cod_emp, string proceso, DateTime fecha_ini, DateTime fecha_fin, string usuario_mod)
        {
            try
            {
                List<modeloExepciones> lista = new List<modeloExepciones>();
                lista = excepcion.ListaExcepcionProcesoFe(cod_emp,proceso, fecha_ini, fecha_fin, usuario_mod);
                return lista;
            }
            catch (Exception e)
            {


                return null;
            }
        }

        //Buscar excepciones por usuario y fechas
        public List<modeloExepciones> ListaExcepcionUsuarioFe(string cod_emp, string usuario, DateTime fecha_ini, DateTime fecha_fin, string usuario_mod)
        {
            try
            {
                List<modeloExepciones> lista = new List<modeloExepciones>();
                lista = excepcion.ListaExcepcionUsuarioFe(cod_emp, usuario, fecha_ini, fecha_fin, usuario_mod);
                return lista;
            }
            catch (Exception e)
            {


                return null;
            }
        }
    }
}
