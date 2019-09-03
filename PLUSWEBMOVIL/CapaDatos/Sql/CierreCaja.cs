using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public class CierreCaja
    {
        
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        //Modelo cierre de caja tabla wmt_cierre_resumencaja

        //Buscar por fecha
        public Int64 BuscarCierreDiaSecuencial(string fecha_cie, string cod_emp)
        {

            Int64 secuencial = 0;
            
            using (cn = conexion.genearConexion())
            {
                string insert = "SELECT TOP 1  secuencial FROM wmt_cierre_resumencaja where fecha_cie = @fecha_cie AND cod_emp =@cod_emp ORDER BY wmt_cierre_resumencaja.secuencial DESC ";
                SqlCommand conmand = new SqlCommand(insert, cn);

                conmand.Parameters.Add("@fecha_cie", SqlDbType.VarChar).Value = fecha_cie;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {                    
                    secuencial = Convert.ToInt64(dr["secuencial"]);
                    

                }

                return secuencial + 1;
            }
        }

        //ultimo secuencial
        public Int64 UltimoCierreDiaSecuencial(string fecha_cie,string cod_emp)
        {

            Int64 secuencial = 0;

            using (cn = conexion.genearConexion())
            {
                string insert = "SELECT TOP 1  secuencial FROM wmt_cierre_resumencaja where fecha_cie = @fecha_cie and cod_emp=@cod_emp ORDER BY dbo.wmt_cierre_resumencaja.secuencial DESC ";
                SqlCommand conmand = new SqlCommand(insert, cn);

                conmand.Parameters.Add("@fecha_cie", SqlDbType.VarChar).Value = fecha_cie;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {
                    secuencial = Convert.ToInt64(dr["secuencial"]);


                }

                return secuencial;
            }
        }
        //Resumen de ciere por fecha
        public List<modeloCierreCaja> ListaCierreCF(string fecha, Int64 secuencial, string codigo, string cod_emp)
        {

            using (cn = conexion.genearConexion())
            {
                List<modeloCierreCaja> lista = new List<modeloCierreCaja>();
                string consulta = ("select * from wmt_cierre_resumencaja WHERE fecha_cie =@fecha_cie and secuencial = @secuencial and codigo= @codigo and cod_emp= @cod_emp");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("fecha_cie", SqlDbType.VarChar).Value = fecha;
                conmand.Parameters.Add("secuencial", SqlDbType.BigInt).Value = secuencial;
                conmand.Parameters.Add("codigo", SqlDbType.VarChar).Value = codigo;
                conmand.Parameters.Add("cod_emp", SqlDbType.VarChar).Value = cod_emp;

                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {

                    modeloCierreCaja item = new modeloCierreCaja();
                    item.id = Convert.ToString(dr["id"]);
                    item.secuencial = Convert.ToInt64(dr["secuencial"]);
                    item.signo = Convert.ToString(dr["signo"]);
                    item.codigo = Convert.ToString(dr["codigo"]);
                    item.nombre = Convert.ToString(dr["nombre"]);
                    item.valor = Convert.ToDecimal(dr["valor"]);
                    item.valor1 = String.Format("{0:N2}", item.valor).ToString();
                    item.fecha_cie = Convert.ToString(dr["fecha_cie"]);
                    item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                    item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                    item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                    item.nro_audit = Convert.ToString(dr["nro_audit"]);
                    item.cod_emp = Convert.ToString(dr["cod_emp"]);

                    lista.Add(item);

                }

                return lista;
            }

        }

        //Insertar cierre en tabla wmt_cierre_resumencaja
        public string InsertarCierreCaja(modeloCierreCaja Cierrecaja)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO  wmt_cierre_resumencaja (signo, codigo,nombre, valor, usuario_mod, fecha_mod,fecha_cie, secuencial, cod_emp, nro_trans) VALUES (@signo, @codigo,@nombre, @valor, @usuario_mod, @fecha_mod,@fecha_cie, @secuencial, @cod_emp,@nro_trans)";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@signo", SqlDbType.VarChar).Value = Cierrecaja.signo;
                    conmand.Parameters.Add("@codigo", SqlDbType.VarChar).Value = Cierrecaja.codigo;
                    conmand.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Cierrecaja.nombre;
                    conmand.Parameters.Add("@valor", SqlDbType.Decimal).Value = Cierrecaja.valor;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = Cierrecaja.usuario_mod;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = Cierrecaja.fecha_mod;
                    conmand.Parameters.Add("@fecha_cie", SqlDbType.VarChar).Value = Cierrecaja.fecha_cie;
                    conmand.Parameters.Add("@secuencial", SqlDbType.VarChar).Value = Cierrecaja.secuencial;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = Cierrecaja.cod_emp;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = Cierrecaja.nro_trans;
                    int dr = conmand.ExecuteNonQuery();
                    return "Cierre Caja guardada correctamente";
                }

            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }
        //Actualizar cierre en tabla wmt_cierre_resumencaja
        public string ActualizarCierreCaja(modeloCierreCaja Cierrecaja)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "UPDATE  wmt_cierre_resumencaja SET signo =@signo, codigo =@codigo,nombre= @nombre, valor= @valor, usuario_mod = @usuario_mod, fecha_mod =@fecha_mod WHERE id= @id";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@signo", SqlDbType.VarChar).Value = Cierrecaja.signo;
                    conmand.Parameters.Add("@codigo", SqlDbType.VarChar).Value = Cierrecaja.codigo;
                    conmand.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Cierrecaja.nombre;
                    conmand.Parameters.Add("@valor", SqlDbType.Decimal).Value = Cierrecaja.valor;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = Cierrecaja.usuario_mod;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = Cierrecaja.fecha_mod;
                    conmand.Parameters.Add("@id", SqlDbType.VarChar).Value = Cierrecaja.id;

                    int dr = conmand.ExecuteNonQuery();
                    return "Cierre Caja guardada correctamente";
                }

            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }

        //Eliminar cierre en tabla wmt_cierre_resumencaja
        public string EliminarCierreCaja(modeloCierreCaja Cierrecaja)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "DELETE  wmt_cierre_resumencaja  WHERE id= @id";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@id", SqlDbType.VarChar).Value = Cierrecaja.id;

                    int dr = conmand.ExecuteNonQuery();
                    return "Cierre Caja eliminado correctamente";
                }

            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }
    }
}
