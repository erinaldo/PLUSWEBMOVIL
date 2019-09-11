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
    public class Consultaconfirmarfactura
    {
        ConfirmarFactura insertar = new ConfirmarFactura();
        modeloinsertarconfirmar modeloinsertar = new modeloinsertarconfirmar();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public string ConfirmarFactura(modeloinsertarconfirmar confirmarfactura)
        {
            try
            {
                string respuesta = insertar.ConfirmarInsertarFactura(confirmarfactura);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(confirmarfactura.cod_emp, "Consultaconfirmarfactura.cs", "ConfirmarFactura", e.ToString(), DateTime.Today, confirmarfactura.usuario_mod);
                return "No se pudo completar la acción." + "ConfirmarInsertarFactura." + " Por favor notificar al administrador.";
            }
        }
    }
}
