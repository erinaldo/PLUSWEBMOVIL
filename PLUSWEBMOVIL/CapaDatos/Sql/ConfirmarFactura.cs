﻿using CapaDatos.Modelos;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public  class ConfirmarFactura
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public string ConfirmarInsertarFactura(modeloinsertarconfirmar confirmarfactura)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO  wmt_facturas_ins  (nro_trans, cod_emp, usuario_mod, fecha_mod, nro_audit)VALUES( @nro_trans, @cod_emp, @usuario_mod, @fecha_mod, @nro_audit)";

                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = confirmarfactura.nro_trans;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = confirmarfactura.cod_emp;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = confirmarfactura.usuario_mod;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = confirmarfactura.fecha_mod;
                    conmand.Parameters.Add("@nro_audit", SqlDbType.VarChar).Value = confirmarfactura.nro_audit;
                    int dr = conmand.ExecuteNonQuery();
                    return "";
                }               
                
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(confirmarfactura.cod_emp, "ConfirmarFactura.cs", "ConfirmarInsertarFactura", e.ToString(), DateTime.Now, confirmarfactura.usuario_mod);
                return "No se pudo completar la acción." + "ConfirmarInsertarFactura." + " Por favor notificar al administrador.";
            }




        }
    }
}
