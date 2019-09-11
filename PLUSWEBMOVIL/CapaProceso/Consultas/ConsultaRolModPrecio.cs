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
   public  class ConsultaRolModPrecio
    {
        
        ModificarPrecioFactura modifircar = new ModificarPrecioFactura();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public List<modeloRolModificarPrecio> BuscartaRolModificar(string usuario, string cod_emp, string tipo, string campo, string accion)
        {
            try
            {
                List<modeloRolModificarPrecio> lista = new List<modeloRolModificarPrecio>();
                lista = modifircar.RespuestaRolModPrecio(usuario, cod_emp, tipo, campo, accion);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "ConsultaRolModPrecio.cs", "BuscartaRolModificar", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }
    }
}
