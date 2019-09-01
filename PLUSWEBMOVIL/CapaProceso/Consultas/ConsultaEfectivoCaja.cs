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
        public Int64 BuscarEfectivoSecuencial(string fecha ,string cod_emp)
        {

            return efectivocaja.BuscarEfectivoCajaSecuencial(fecha, cod_emp);
        }

        //ultimo secuencial wmt_efectivocaja
        public Int64 UltimoEfectivoSecuencial(string fecha, string cod_emp)
        {

            return efectivocaja.UltimoEfectivoCajaSecuencial(fecha, cod_emp);
        }

        //lista ultimo efectivo caja
        //Consulta total pagos efectivo pos, y pose
        public List<modeloEfectivoCaja> ListaCCajaFecha(string fecha, Int64 secuencial, string cod_emp)
        {
            List<modeloEfectivoCaja> lista = new List<modeloEfectivoCaja>();
            lista = efectivocaja.BuscarEfectivoCF(fecha, secuencial, cod_emp);
            return lista;
        }

        //lista de secuenciales para cbx_secuencial
        public List<modeloEfectivoCaja> ListaSecuencialFecha(string fecha,  string cod_emp)
        {
            List<modeloEfectivoCaja> lista = new List<modeloEfectivoCaja>();
            lista = efectivocaja.ListaEfectivoFecha(fecha, cod_emp);
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
