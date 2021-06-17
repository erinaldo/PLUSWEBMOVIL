using CapaDatos.Modelos;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class ConsultaEValle
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        ValidarParametrizacionFactura conexion_valle = new ValidarParametrizacionFactura();
        string metodo = "ConsultaEValle.cs";
        string stringConexionValle = "";

        public string ActualizarDatoDian(modeloValleDian modelo)
        {
            try
            {
                stringConexionValle = conexion_valle.ConsultaConexionEValle(modelo.cod_emp, modelo.usuario_mod);
                using (cn = conexion.genearConexionEValle(stringConexionValle))
                {
                    string insert = "UPDATE  DatoDian SET  cufe =@cufe, qr =@qr, nro_factura_electronica =@nro_factura_electronica, fecha_autorizacion = @fecha_autorizacion, fecha_generacion =@fecha_generacion, link =@link WHERE nro_factura =@nro_factura";

                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@cufe", SqlDbType.VarChar).Value = modelo.cufe;
                    conmand.Parameters.Add("@qr", SqlDbType.VarChar).Value = modelo.qr;
                    conmand.Parameters.Add("@nro_factura_electronica", SqlDbType.VarChar).Value = modelo.nro_factura_electronica;
                    conmand.Parameters.Add("@fecha_autorizacion", SqlDbType.DateTime).Value = modelo.fecha_autorizacion;
                    conmand.Parameters.Add("@fecha_generacion", SqlDbType.VarChar).Value = modelo.fecha_generacion;
                    conmand.Parameters.Add("@link", SqlDbType.VarChar).Value = modelo.link;
                    conmand.Parameters.Add("@nro_factura", SqlDbType.VarChar).Value = modelo.nro_factura;
                    int dr = conmand.ExecuteNonQuery();
                    return "";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(modelo.cod_emp, metodo, "ActualizarDatoDian", e.ToString(), DateTime.Now, modelo.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarDatoDian." + " Por favor notificar al administrador.";
            }
        }
    }
}
