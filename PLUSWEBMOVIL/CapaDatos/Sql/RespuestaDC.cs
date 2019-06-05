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

        public string InsertarRespuestaDS(string nro_trans, int linea, string qrdata, string xml, string id, string cufe, string error, string json)
        {
            try
            {
                cn = conexion.genearConexion();

                string insert = "INSERT INTO  wmt_respuestaDS (nro_trans, linea, qrdata, xml, id, cufe, error,json) VALUES (@nro_trans, @linea, @qrdata, @xml, @id, @cufe, @error, @json)";
                SqlCommand conmand = new SqlCommand(insert, cn);
                conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;
                conmand.Parameters.Add("@linea", SqlDbType.Int).Value = linea;
                conmand.Parameters.Add("@qrdata", SqlDbType.VarChar).Value = qrdata;
                conmand.Parameters.Add("@xml", SqlDbType.VarChar).Value = xml;
                conmand.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                conmand.Parameters.Add("@cufe", SqlDbType.VarChar).Value = cufe;
                conmand.Parameters.Add("@error", SqlDbType.VarChar).Value = error;
                conmand.Parameters.Add("@json", SqlDbType.VarChar).Value = json;


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
