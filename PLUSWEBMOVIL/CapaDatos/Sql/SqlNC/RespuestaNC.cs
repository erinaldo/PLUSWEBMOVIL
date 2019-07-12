using System;
using CapaProceso.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using CapaDatos.Modelos;
using CapaDatos.Modelos.ModelosNC;

namespace CapaDatos.Sql
{
    public class RespuestaNC
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        public List<JsonRespuestaNC> ConsultaRespuestaQR(string nro_trans)
        {
            using (cn = conexion.genearConexion())
            {
                List<JsonRespuestaNC> lista = new List<JsonRespuestaNC>();
                string consulta = "SELECT * FROM dbo.wmt_respuestaDS WHERE nro_trans =@nro_trans ORDER BY linea DESC";
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("nro_trans", SqlDbType.VarChar).Value = nro_trans;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {
                    JsonRespuestaNC item = new JsonRespuestaNC();
                    item.nro_trans = Convert.ToString(dr["nro_trans"]);
                    item.linea = Convert.ToInt16(dr["linea"]);
                    item.qrdata = Convert.ToString(dr["qrdata"]);
                    item.xml = Convert.ToString(dr["xml"]);
                    item.id = Convert.ToString(dr["id"]);
                    item.cufe = Convert.ToString(dr["cufe"]);
                    item.error = Convert.ToString(dr["error"]);
                    item.json = Convert.ToString(dr["json"]);
                    item.result = Convert.ToString(dr["result"]);
                    lista.Add(item);
                }

                return lista;
            }
            
            
        }
        //Consultar por linea la respuesta
        public List<JsonRespuestaNC> RespuestaLineaQR(string nro_trans,  string linea)
        {
            using (cn = conexion.genearConexion())
            {
                List<JsonRespuestaNC> lista = new List<JsonRespuestaNC>();
                string consulta = "SELECT * FROM dbo.wmt_respuestaDS WHERE nro_trans =@nro_trans AND linea = @linea";
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("nro_trans", SqlDbType.VarChar).Value = nro_trans;
                conmand.Parameters.Add("linea", SqlDbType.VarChar).Value = linea;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {
                    JsonRespuestaNC item = new JsonRespuestaNC();
                    item.nro_trans = Convert.ToString(dr["nro_trans"]);
                    item.linea = Convert.ToInt16(dr["linea"]);
                    item.qrdata = Convert.ToString(dr["qrdata"]);
                    item.xml = Convert.ToString(dr["xml"]);
                    item.id = Convert.ToString(dr["id"]);
                    item.cufe = Convert.ToString(dr["cufe"]);
                    item.error = Convert.ToString(dr["error"]);
                    item.json = Convert.ToString(dr["json"]);
                    item.result = Convert.ToString(dr["result"]);
                    lista.Add(item);
                }

                return lista;
            }           
           
        }

        public string InsertarRespuestaNC(JsonRespuestaNC jsonRespuestaNC)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO  wmt_respuestaDS (nro_trans, linea, qrdata, xml, id, cufe, error,json, result) VALUES (@nro_trans, @linea, @qrdata, @xml, @id, @cufe, @error, @json, @result)";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = jsonRespuestaNC.nro_trans;
                    conmand.Parameters.Add("@linea", SqlDbType.Int).Value = jsonRespuestaNC.linea;
                    conmand.Parameters.Add("@qrdata", SqlDbType.VarChar).Value = jsonRespuestaNC.qrdata;
                    conmand.Parameters.Add("@xml", SqlDbType.VarChar).Value = jsonRespuestaNC.xml;
                    conmand.Parameters.Add("@id", SqlDbType.VarChar).Value = jsonRespuestaNC.id;
                    conmand.Parameters.Add("@cufe", SqlDbType.VarChar).Value = jsonRespuestaNC.cufe;
                    conmand.Parameters.Add("@error", SqlDbType.VarChar).Value = jsonRespuestaNC.error;
                    conmand.Parameters.Add("@json", SqlDbType.VarChar).Value = jsonRespuestaNC.json;
                    conmand.Parameters.Add("@result", SqlDbType.VarChar).Value = jsonRespuestaNC.result;


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
