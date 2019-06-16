﻿using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class SerieDocumento
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        public List<modelowmspcresfact> ListaBuscaSerieDocumento(string ResF_usuario, string ResF_cod_emp, string ResF_estado, string ResF_serie, string ResF_tipo)
        {


            using (cn = conexion.genearConexion())
            {
                List<modelowmspcresfact> lista = new List<modelowmspcresfact>();
                string consulta = ("wmspc_resfact");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.CommandType = CommandType.StoredProcedure;

                conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = ResF_usuario;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = ResF_cod_emp;
                conmand.Parameters.Add("@estado", SqlDbType.VarChar).Value = ResF_estado;
                conmand.Parameters.Add("@serie", SqlDbType.VarChar).Value = ResF_serie;
                conmand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = ResF_tipo;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {

                    modelowmspcresfact item = new modelowmspcresfact(Convert.ToString(dr["cod_atrib1"]), Convert.ToString(dr["serie_docum"]), Convert.ToString(dr["nro_docum"]), Convert.ToString(dr["nro_docum_ref"]), Convert.ToString(dr["activo"]), Convert.ToString(dr["numerador"]), Convert.ToDateTime(dr["fec_valor"]), Convert.ToDateTime(dr["fec_venc"]), Convert.ToString(dr["tipo"]));
                    lista.Add(item);

                }

                return lista;
            }          
            

        }
    }
}
