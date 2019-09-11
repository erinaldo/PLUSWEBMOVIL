using System;
using CapaProceso.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using CapaDatos.Modelos;

namespace CapaDatos.Sql
{
    public class CuentasBanco
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<modelobancos> ConsultaBancos(string usuario, string cod_emp, string banco, string tipo, string cuenta, string imprime)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelobancos> lista = new List<modelobancos>();

                    string consulta = ("wmspc_ctasbco");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@banco", SqlDbType.VarChar).Value = banco;
                    conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                    conmand.Parameters.Add("@cuenta", SqlDbType.VarChar).Value = cuenta;
                    conmand.Parameters.Add("@imprime", SqlDbType.VarChar).Value = imprime;


                    SqlDataReader dr = conmand.ExecuteReader();


                    while (dr.Read())
                    {

                        modelobancos item = new modelobancos();

                        item.cod_tit = Convert.ToString(dr["cod_tit"]);
                        item.nom_tit = Convert.ToString(dr["nom_tit"]);
                        item.tipocta_banco = Convert.ToString(dr["tipocta_banco"]);
                        item.nomtcta_banco = Convert.ToString(dr["nomtcta_banco"]);
                        item.nrocta_banco = Convert.ToString(dr["nrocta_banco"]);
                        item.cod_cta = Convert.ToString(dr["cod_cta"]);
                        item.cod_moneda = Convert.ToString(dr["cod_moneda"]);

                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, "CuentaBanco.cs", "ConsultaBancos", e.ToString(), DateTime.Today, usuario);
                return null;
            }

        }
    }
}
