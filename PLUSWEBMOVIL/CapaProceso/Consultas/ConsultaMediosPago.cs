using CapaDatos.Modelos;
using CapaDatos.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
    public class ConsultaMediosPago
    {
        MediosPago consultaMediosPago = new MediosPago();
        public List<modeloMediosPago> BuscarMediosPago(string cod_emp)
        {
            List<modeloMediosPago> lista = new List<modeloMediosPago>();
            lista = consultaMediosPago.ListaMediosPago(cod_emp);
            return lista;
        }
    }
}
