using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
    public class Consultaconfirmarfactura
    {
        ConfirmarFactura insertar = new ConfirmarFactura();
        modeloinsertarconfirmar modeloinsertar = new modeloinsertarconfirmar();
        public string ConfirmarFactura(modeloinsertarconfirmar confirmarfactura)
        {
            string respuesta = insertar.ConfirmarInsertarFactura(confirmarfactura);
            return respuesta;
        }
    }
}
