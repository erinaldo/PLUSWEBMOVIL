using CapaDatos.Modelos.ModeloHost;
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
        public List<modeloHostmail> BuscarHostmail(string cod_emp)
        {
            List<modeloHostmail> lista = new List<modeloHostmail>();
            lista = consultHost.ListaHostMail(cod_emp);
            return lista;
        }

        //Insertar sucursal empresa
        
        modeloHostmail ModeloHost = new modeloHostmail();
        public string InsertarHostmail(modeloHostmail ModelosHostMail)
        {
            string respuesta = consultHost.InsertarHostmaila(ModelosHostMail);
            return respuesta;
        }

        //Actualizar sucursal empresa 
       
        public string ActualizarHostmaila(modeloHostmail ModelosHostMail)
        {
            string respuesta = consultHost.ActualizarHostMail(ModelosHostMail);
            return respuesta;
        }
              
        public string EliminarHostmail(modeloHostmail ModelosHostMail)
        {
            string respuesta = consultHost.EliminarHostMail(ModelosHostMail);
            return respuesta;
        }
    }
}
