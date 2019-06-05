using System;
using CapaProceso.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace CapaDatos.Sql
{
    public class RespuestaDC
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        public SqlDataReader ConsultaRespuestaQR(string nro_trans)
        {
            cn = conexion.genearConexion();
            string consulta = "SELECT * FROM dbo.wmt_respuestaDS WHERE nro_trans =@nro_trans ORDER BY linea DESC";
            SqlCommand conmand = new SqlCommand(consulta, cn);

            conmand.Parameters.Add("nro_trans", SqlDbType.VarChar).Value = nro_trans;

            SqlDataReader dr = conmand.ExecuteReader();

            return dr;
        }

        public string InsertarRespuestaDS(JsonRespuestaDE jsonRespuestaDE)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "INSERT INTO  wmt_respuestaDS (nro_trans, linea, qrdata, xml, id, cufe, error,json) VALUES (@nro_trans, @linea, @qrdata, @xml, @id, @cufe, @error, @json)";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = jsonRespuestaDE.nro_trans;
                conmand.Parameters.Add("@linea", SqlDbType.Int).Value = jsonRespuestaDE.linea;
                conmand.Parameters.Add("@qrdata", SqlDbType.VarChar).Value = jsonRespuestaDE.qrdata;
                conmand.Parameters.Add("@xml", SqlDbType.VarChar).Value = jsonRespuestaDE.xml;
                conmand.Parameters.Add("@id", SqlDbType.VarChar).Value = jsonRespuestaDE.id;
                conmand.Parameters.Add("@cufe", SqlDbType.VarChar).Value = jsonRespuestaDE.cufe;
                conmand.Parameters.Add("@error", SqlDbType.VarChar).Value = jsonRespuestaDE.error;
                conmand.Parameters.Add("@json", SqlDbType.VarChar).Value = jsonRespuestaDE.json;


                int dr = conmand.ExecuteNonQuery();
                return "insercion correcta";
            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }
    }
}
