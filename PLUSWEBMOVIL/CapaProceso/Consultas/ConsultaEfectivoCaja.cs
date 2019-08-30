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
   public class ConsultaEfectivoCaja
    {
        EfectivoCaja efectivocaja = new EfectivoCaja();
        modeloEfectivoCaja modeloECaja = new modeloEfectivoCaja();

        //Consulta  BuscarEfectivoSecuencial wmt_efectivocaja
        public Int64 BuscarEfectivoSecuencial(string fecha)
        {

            return efectivocaja.BuscarEfectivoCajaSecuencial(fecha);
        }

        //ultimo secuencial wmt_efectivocaja
        public Int64 UltimoEfectivoSecuencial(string fecha)
        {

            return efectivocaja.UltimoEfectivoCajaSecuencial(fecha);
        }

        //lista ultimo efectivo caja
        //Consulta total pagos efectivo pos, y pose
        public List<modeloEfectivoCaja> ListaCCajaFecha(string fecha, Int64 secuencial)
        {
            List<modeloEfectivoCaja> lista = new List<modeloEfectivoCaja>();
            lista = efectivocaja.BuscarEfectivoCF(fecha, secuencial);
            return lista;
        }
        //insertar efectivo caja
        public string InsertarECaja(modeloEfectivoCaja ModeloECaja)
        {
            string respuesta = efectivocaja.InsertarEfectivoCaja(ModeloECaja);
            return respuesta;
        }

        //Consulta total pagos efectivo pos, y pose
        public List<modeloTotalPgsFacturas> ConsultaCCajaFecha(string fecha)
        {
            List<modeloTotalPgsFacturas> lista = new List<modeloTotalPgsFacturas>();
            lista = efectivocaja.ListaEfectivoCF(fecha);
            return lista;
        }

        //Consulta total NVTA
        public List<modeloTotalPgsFacturas> ConsultaTotalNVTA(string fecha)
        {
            List<modeloTotalPgsFacturas> lista = new List<modeloTotalPgsFacturas>();
            lista = efectivocaja.ListaTotalNVTA(fecha);
            return lista;
        }
    }
}
