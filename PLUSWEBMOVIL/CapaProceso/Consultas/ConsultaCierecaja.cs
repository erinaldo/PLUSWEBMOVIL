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
   public  class ConsultaCierecaja
    {
        CierreCaja ccaja = new CierreCaja();
        modeloCierreCaja modeloCCaja = new modeloCierreCaja();

        //Consulta lista de cierre caja por fecha en wmt_cierre_resumencaja
        public List<modeloCierreCaja> ConsultaCCajaFecha(string fecha)
        {
            List<modeloCierreCaja> lista = new List<modeloCierreCaja>();
            lista = ccaja.ListaCierreCF(fecha);
            return lista;
        }

        //Insertar ciereCaja en wmt_cierre_resumencaja
        public string InsertarCierreCaja(modeloCierreCaja ModeloCCaja)
        {
            string respuesta = ccaja.InsertarCierreCaja(ModeloCCaja);
            return respuesta;
        }

        //Actualizar ciereCaja en wmt_cierre_resumencaja
        public string ActualizarCierreCaja(modeloCierreCaja ModeloCCaja)
        {
            string respuesta = ccaja.ActualizarCierreCaja(ModeloCCaja);
            return respuesta;
        }

        //Eliminar ciereCaja en wmt_cierre_resumencaja
        public string EliminarCierreCaja(modeloCierreCaja ModeloCCaja)
        {
            string respuesta = ccaja.EliminarCierreCaja(ModeloCCaja);
            return respuesta;
        }
    }
}
