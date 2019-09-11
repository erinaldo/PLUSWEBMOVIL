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
   public class ConsultaActualizarTitular
    {
        //Actualizar datos de titulares en RP
        ActualizarDatosTitular updateTitular = new ActualizarDatosTitular();
        modeloActualizarDatosTitular ModeloActualizarTit = new modeloActualizarDatosTitular();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public string ActualizarDatosTitulares(modeloActualizarDatosTitular ActualizarDatos)
        {
            string respuesta = updateTitular.ActualizarDatTitular(ActualizarDatos);
            return respuesta;
        }
    }
}
