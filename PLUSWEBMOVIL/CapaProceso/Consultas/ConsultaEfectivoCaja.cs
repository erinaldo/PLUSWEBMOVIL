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
