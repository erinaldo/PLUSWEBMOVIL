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
    public class ConusltaDetalleCajaEfectivo
    {
        EfectivoCaja fcaja = new EfectivoCaja();
        modeloEfectivoCaja modeloFCaja = new modeloEfectivoCaja();


      

        //Insertar ciereCaja en wmt_cierre_resumencaja
        public string InsertarEfectivoCaja(modeloEfectivoCaja EfectivoCaja)
        {
            string respuesta = fcaja.InsertarEfectivoCaja(EfectivoCaja);
            return respuesta;
        }

        //Actualizar ciereCaja en wmt_cierre_resumencaja
        public string ActualizarEfectivoCaja(modeloEfectivoCaja EfectivoCaja)
        {
            string respuesta = fcaja.ActualizarEfectivoCaja(EfectivoCaja);
            return respuesta;
        }

        //Eliminar ciereCaja en wmt_cierre_resumencaja
        public string EliminarEfectivoCaja(modeloEfectivoCaja EfectivoCaja)
        {
            string respuesta = fcaja.EliminarEfectivoCaja(EfectivoCaja);
            return respuesta;
        }
    }
}
