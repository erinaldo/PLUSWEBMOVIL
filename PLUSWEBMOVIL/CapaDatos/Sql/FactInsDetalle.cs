using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class FactInsDetalle
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;


   /*     public string InsertarDetalle()
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "INSERT INTO  wmt_facturas_det  (nom_articulo, nom_articulo2, cantidad, precio_unit, base_imp, porc_iva, nro_trans, linea, cod_emp, cod_articulo, cod_concepret, porc_descto, valor_descto, cod_cta_vtas, cod_cta_cos, cod_cta_inve, usuario_mod, nro_audit, fecha_mod, tasa_iva, cod_ccostos) VALUES (@nom_articulo, @nom_articulo2, @cantidad, @precio_unit, @base_imp, @porc_iva, @nro_trans, @linea, @cod_emp, @cod_articulo, @cod_concepret, @porc_descto, @valor_descto, @cod_cta_vtas, @cod_cta_cos, @cod_cta_inve, @usuario_mod, @nro_audit, @fecha_mod,@tasa_iva, @cod_ccostos)";

                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@nom_articulo", SqlDbType.VarChar).Value = 
            }
                 int dr = conmand.ExecuteNonQuery();
            return "Cabezera de factura guardada correctamente";


            catch (Exception e)
            {

                return e.ToString();
            }
        }*/
    }
}
