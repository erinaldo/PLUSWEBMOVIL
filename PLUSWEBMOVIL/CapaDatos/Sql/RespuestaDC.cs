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
    public class RespuestaDC
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        public List<JsonRespuestaDE> ConsultaRespuestaQR(string nro_trans)
        {
            using (cn = conexion.genearConexion())
            {
                List<JsonRespuestaDE> lista = new List<JsonRespuestaDE>();
                string consulta = "SELECT * FROM dbo.wmt_respuestaDS WHERE nro_trans =@nro_trans ORDER BY linea DESC";
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("nro_trans", SqlDbType.VarChar).Value = nro_trans;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {
                    JsonRespuestaDE item = new JsonRespuestaDE();
                    item.nro_trans = Convert.ToString(dr["nro_trans"]);
                    item.linea = Convert.ToInt16(dr["linea"]);
                    item.qrdata = Convert.ToString(dr["qrdata"]);
                    item.xml = Convert.ToString(dr["xml"]);
                    item.id = Convert.ToString(dr["id"]);
                    item.cufe = Convert.ToString(dr["cufe"]);
                    item.error = Convert.ToString(dr["error"]);
                    item.json = Convert.ToString(dr["json"]);
                    lista.Add(item);
                }

                return lista;
            }
            
            
        }
        //Consultar por linea la respuesta
        public List<JsonRespuestaDE> RespuestaLineaQR(string nro_trans,  string linea)
        {
            using (cn = conexion.genearConexion())
            {
                List<JsonRespuestaDE> lista = new List<JsonRespuestaDE>();
                string consulta = "SELECT * FROM dbo.wmt_respuestaDS WHERE nro_trans =@nro_trans AND linea = @linea";
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("nro_trans", SqlDbType.VarChar).Value = nro_trans;
                conmand.Parameters.Add("linea", SqlDbType.VarChar).Value = linea;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {
                    JsonRespuestaDE item = new JsonRespuestaDE();
                    item.nro_trans = Convert.ToString(dr["nro_trans"]);
                    item.linea = Convert.ToInt16(dr["linea"]);
                    item.qrdata = Convert.ToString(dr["qrdata"]);
                    item.xml = Convert.ToString(dr["xml"]);
                    item.id = Convert.ToString(dr["id"]);
                    item.cufe = Convert.ToString(dr["cufe"]);
                    item.error = Convert.ToString(dr["error"]);
                    item.json = Convert.ToString(dr["json"]);
                    lista.Add(item);
                }

                return lista;
            }           
           
        }

        public string InsertarRespuestaDS(JsonRespuestaDE jsonRespuestaDE)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO  wmt_respuestaDS (nro_trans, linea, qrdata, xml, id, cufe, error,json, result) VALUES (@nro_trans, @linea, @qrdata, @xml, @id, @cufe, @error, @json, @result)";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = jsonRespuestaDE.nro_trans;
                    conmand.Parameters.Add("@linea", SqlDbType.Int).Value = jsonRespuestaDE.linea;
                    conmand.Parameters.Add("@qrdata", SqlDbType.VarChar).Value = jsonRespuestaDE.qrdata;
                    conmand.Parameters.Add("@xml", SqlDbType.VarChar).Value = jsonRespuestaDE.xml;
                    conmand.Parameters.Add("@id", SqlDbType.VarChar).Value = jsonRespuestaDE.id;
                    conmand.Parameters.Add("@cufe", SqlDbType.VarChar).Value = jsonRespuestaDE.cufe;
                    conmand.Parameters.Add("@error", SqlDbType.VarChar).Value = jsonRespuestaDE.error;
                    conmand.Parameters.Add("@json", SqlDbType.VarChar).Value = jsonRespuestaDE.json;
                    conmand.Parameters.Add("@result", SqlDbType.VarChar).Value = jsonRespuestaDE.result;


                    int dr = conmand.ExecuteNonQuery();
                    return "insercion correcta";
                }                
                
            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }
    }
}
