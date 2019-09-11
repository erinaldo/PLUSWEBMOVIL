using CapaDatos.Modelos.ModeloHost;
using CapaDatos.Sql;
using CapaDatos.Sql.HostMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas.ConsultaHost
{
    public class ConsultaHostmail
    {
        HostaMail consultHost = new HostaMail();
        string metodo ="ConsultaHostmail.cs";
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<modeloHostmail> BuscarHostmail(string cod_emp)
        {
            try
            {
                List<modeloHostmail> lista = new List<modeloHostmail>();
                lista = consultHost.ListaHostMail(cod_emp);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "BuscarHostmail", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

        //Insertar sucursal empresa
        
        modeloHostmail ModeloHost = new modeloHostmail();
        public string InsertarHostmail(modeloHostmail ModelosHostMail)
        {
            try
            {
                string respuesta = consultHost.InsertarHostmaila(ModelosHostMail);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ModelosHostMail.cod_emp, metodo, "InsertarHostmail", e.ToString(), DateTime.Today, "INS");
                return "No se pudo completar la acción." + "InsertarHostmail." + " Por favor notificar al administrador.";
            }

        }

        //Actualizar sucursal empresa 
       
        public string ActualizarHostmaila(modeloHostmail ModelosHostMail)
        {
            try
            {
                string respuesta = consultHost.ActualizarHostMail(ModelosHostMail);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ModelosHostMail.cod_emp, metodo, "ActualizarHostMail", e.ToString(), DateTime.Today, "UDP");
                return "No se pudo completar la acción." + "ActualizarHostMail." + " Por favor notificar al administrador.";
            }
        }
              
        public string EliminarHostmail(modeloHostmail ModelosHostMail)
        {
            try
            {
                string respuesta = consultHost.EliminarHostMail(ModelosHostMail);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ModelosHostMail.cod_emp, metodo, "EliminarHostMail", e.ToString(), DateTime.Today, "DLT");
                return "No se pudo completar la acción." + "EliminarHostMail." + " Por favor notificar al administrador.";
            }
        }
    }
}
