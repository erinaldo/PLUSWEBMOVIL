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
    public class RespuestaNDebito
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        public List<JsonRespuestaNDV2> ConsultaRespuestaQR(string nro_trans)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<JsonRespuestaNDV2> lista = new List<JsonRespuestaNDV2>();
                    string consulta = "SELECT * FROM wmt_respuestaDS WHERE nro_trans =@nro_trans ORDER BY linea DESC";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("nro_trans", SqlDbType.VarChar).Value = nro_trans;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        JsonRespuestaNDV2 item = new JsonRespuestaNDV2();
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
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, "RespuestaNC.cs", "ConsultaRespuestaQR", e.ToString(), DateTime.Now, "consulta");
                return null;
            }

        }

        //consultar cufe de una factura
        public List<JsonRespuestaNDV2> ConsultaCUFE(string nro_trans)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<JsonRespuestaNDV2> lista = new List<JsonRespuestaNDV2>();
                    string consulta = "SELECT TOP 1 * FROM wmt_respuestaDS WHERE nro_trans =@nro_trans AND cufe <> ' '";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("nro_trans", SqlDbType.VarChar).Value = nro_trans;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        JsonRespuestaNDV2 item = new JsonRespuestaNDV2();
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
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, "RespuestaNC.cs", " ConsultaCUFE", e.ToString(), DateTime.Now, "consulta");
                return null;
            }

        }

        //Consultar por linea la respuesta
        public List<JsonRespuestaNDV2> RespuestaLineaQR(string nro_trans,  string linea)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<JsonRespuestaNDV2> lista = new List<JsonRespuestaNDV2>();
                    string consulta = "SELECT * FROM wmt_respuestaDS WHERE nro_trans =@nro_trans AND linea = @linea";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("nro_trans", SqlDbType.VarChar).Value = nro_trans;
                    conmand.Parameters.Add("linea", SqlDbType.VarChar).Value = linea;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        JsonRespuestaNDV2 item = new JsonRespuestaNDV2();
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
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(nro_trans, "RespuestaNC.cs", "RespuestaLineaQR", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }

        public string InsertarRespuestaNC(JsonRespuestaNDV2 jsonRespuestaNC)
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

                guardarExcepcion.ClaseInsertarExcepcion(jsonRespuestaNC.nro_trans, "RespuestaDC.cs", "InsertarRespuestaNC", e.ToString(), DateTime.Now, "INS");
                return "No se pudo completar la acción." + "InsertarRespuestaNC." + " Por favor notificar al administrador.";
            }

        }



        //INSERTAR RESPUESTA DS-DIAN FEV2 TABLA item
        public string InsertarRespuestaDS_DIANNCV2(JsonRespuestaNDV2 item)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO  wmt_respuestaDS (nro_trans, linea, qrdata, xml, id, cufe, error,json, result, jsonrRespuesta) VALUES (@nro_trans, @linea, @qrdata, @xml, @id, @cufe, @error, @json, @result, @jsonrRespuesta)";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = item.nro_trans;
                    conmand.Parameters.Add("@linea", SqlDbType.Int).Value = item.linea;
                    conmand.Parameters.Add("@qrdata", SqlDbType.VarChar).Value = item.qrdata;
                    conmand.Parameters.Add("@xml", SqlDbType.VarChar).Value = item.xml;
                    conmand.Parameters.Add("@id", SqlDbType.VarChar).Value = item.id;
                    conmand.Parameters.Add("@cufe", SqlDbType.VarChar).Value = item.cufe;
                    conmand.Parameters.Add("@error", SqlDbType.VarChar).Value = item.error;
                    conmand.Parameters.Add("@json", SqlDbType.VarChar).Value = item.json;
                    conmand.Parameters.Add("@result", SqlDbType.VarChar).Value = item.result;
                    conmand.Parameters.Add("@jsonrRespuesta", SqlDbType.VarChar).Value = item.jsonrRespuesta;

                    int dr = conmand.ExecuteNonQuery();
                    return "insercion correcta";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(item.nro_trans, "RespuestaDC.cs", "InsertarRespuestaDS_DIANFEV2", e.ToString(), DateTime.Now, "INS");
                return "No se pudo completar la acción." + "Insertar" + " Por favor notificar al administrador.";
            }

        }
    }
}
