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

        //Consulta cierre caja por fecha en wmt_cierre_resumencaja
        public Int64 BuscarCCajaFechaSecuencial(string fecha , string cod_emp)
        {          
            
            return ccaja.BuscarCierreDiaSecuencial(fecha, cod_emp);
        }
        //ultimo secuencial
        public Int64 UltimoCCajaFechaSecuencial(string fecha, string cod_emp)
        {

            return ccaja.UltimoCierreDiaSecuencial(fecha, cod_emp);
        }

        //Consulta lista de cierre caja por fecha en wmt_cierre_resumencaja
        public List<modeloCierreCaja> ConsultaCCajaFecha(string fecha, Int64 secuencial, string codigo, string cod_emp)
        {
            List<modeloCierreCaja> lista = new List<modeloCierreCaja>();
            lista = ccaja.ListaCierreCF(fecha, secuencial, codigo, cod_emp);
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
