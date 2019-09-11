using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public class CotizacionMonedaTrm
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public List<modelowmspctctrxCotizacion> ListaMonedaTrm(string usuario, string cod_emp, string nro_trans)
        {
            try
            {
                //Buscar cotizacion moneda trm

                using (cn = conexion.genearConexion())
                {
                    List<modelowmspctctrxCotizacion> lista = new List<modelowmspctctrxCotizacion>();
                    string consulta = ("wmspc_tctrx");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modelowmspctctrxCotizacion item = new modelowmspctctrxCotizacion();

                        item.tc_mov1c = Convert.ToString(dr["tc_mov1c"]);
                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.mone_mn = Convert.ToString(dr["mone_mn"]);
                        item.mone_trad = Convert.ToString(dr["mone_trad"]);
                        item.cod_moneda = Convert.ToString(dr["cod_moneda"]);

                        lista.Add(item);
                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "CotizacionMonedaTrm.cs", "ListaMonedaTrm", e.ToString(), DateTime.Today, usuario);
                return null;
            }
        }

        //tasa de la fecha actual
        public List<modelowmspctctrxCotizacion> ActualMonedaTrm(string usuario, string cod_emp, string dia, string mes, string anio, string moneda)
        {
            try
            {
                //Buscar cotizacion moneda trm

                using (cn = conexion.genearConexion())
                {
                    List<modelowmspctctrxCotizacion> lista = new List<modelowmspctctrxCotizacion>();
                    string consulta = ("wmspc_tcambio");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@dia", SqlDbType.VarChar).Value = dia;
                    conmand.Parameters.Add("@mes", SqlDbType.VarChar).Value = mes;
                    conmand.Parameters.Add("@anio", SqlDbType.VarChar).Value = anio;
                    conmand.Parameters.Add("@moneda", SqlDbType.VarChar).Value = moneda;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modelowmspctctrxCotizacion item = new modelowmspctctrxCotizacion();
                        item.tc_mov = Convert.ToString(dr["tc_mov"]);
                        item.tc_trad = Convert.ToString(dr["tc_trad"]);
                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "CotizacionMonedaTrm.cs", "ActualMonedaTrm", e.ToString(), DateTime.Today, usuario);
                return null;
            }


        }

    }
}
