using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class CMonedas
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();

        //Monedas por empresa dependiendo de las q tenga registradas
        public List<modelowmspcmonedas> ListaBuscaCMonedas(string MonB__usuario, string MonB__cod_emp, string MonB__moneda)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelowmspcmonedas> lista = new List<modelowmspcmonedas>();
                    string consulta = ("wmspc_monedas");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = MonB__usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = MonB__cod_emp;
                    conmand.Parameters.Add("@moneda", SqlDbType.VarChar).Value = MonB__moneda;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modelowmspcmonedas item = new modelowmspcmonedas();
                        item.descripcion = Convert.ToString(dr["cod_moneda"]) + " - " + Convert.ToString(dr["simbolo_moneda"]);
                        item.cod_moneda = Convert.ToString(dr["cod_moneda"]);
                        item.nom_moneda = Convert.ToString(dr["nom_moneda"]);
                        item.simbolo_moneda = Convert.ToString(dr["simbolo_moneda"]);
                        item.redondeo = Convert.ToString(dr["redondeo"]);
                        item.redondeo_pu = Convert.ToString(dr["redondeo_pu"]);

                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(MonB__cod_emp, "CMonedas.cs", "ListaBuscaCMonedas", e.ToString(), DateTime.Today, MonB__usuario);
                return null;
            }

        }

        //Denominaciones de monedas maestro de  Denominacion wmm_denominacionMB por ID
        public List<modeloDenominacionesMoneda> ListaDenominacionUDP(string id)
        {
            try
            {

                using (cn = conexion.genearConexion())
                {
                    List<modeloDenominacionesMoneda> lista = new List<modeloDenominacionesMoneda>();
                    string consulta = ("SELECT  * FROM wmm_denominacionMB WHERE id= @id ");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloDenominacionesMoneda item = new modeloDenominacionesMoneda();
                        item.observaciones = Convert.ToString(dr["nombre"]) + " DE " + Convert.ToString(dr["valor"]);
                        item.cod_moneda = Convert.ToString(dr["cod_moneda"]);
                        item.nombre = Convert.ToString(dr["nombre"]);
                        item.valor = Convert.ToDecimal(dr["valor"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "CMonedas.cs", "ListaDenominacionUDP", e.ToString(), DateTime.Today, "consulta");
                return null;
            }

        }
        //Denominaciones de monedas maestro de  Denominacion wmm_denominacionMB por cod_moneda
        public List<modeloDenominacionesMoneda> ListaDenominacionEmpresa(string cod_moneda)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloDenominacionesMoneda> lista = new List<modeloDenominacionesMoneda>();
                    string consulta = ("SELECT  * FROM wmm_denominacionMB WHERE cod_moneda= @cod_moneda ");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("cod_moneda", SqlDbType.VarChar).Value = cod_moneda;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloDenominacionesMoneda item = new modeloDenominacionesMoneda();
                        item.id = Convert.ToString(dr["id"]);

                        item.cod_moneda = Convert.ToString(dr["cod_moneda"]);
                        item.nombre = Convert.ToString(dr["nombre"]);
                        item.valor = Convert.ToDecimal(dr["valor"]);
                        string valor1 = String.Format("{0:N0}", item.valor).ToString();
                        item.observaciones = Convert.ToString(dr["nombre"]) + " DE " + valor1;
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        item.cantidad = 0;
                        item.total = 0;
                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "CMonedas.cs", "ListaDenominacionEmpresa", e.ToString(), DateTime.Today, "consulta");
                return null;
            }

        }

        //Denominaciones de monedas maestro de  Denominacion wmm_denominacionMB
        public List<modeloDenominacionesMoneda> ListaDenominacionMoneda()
        {
            try
            {

                using (cn = conexion.genearConexion())
                {
                    List<modeloDenominacionesMoneda> lista = new List<modeloDenominacionesMoneda>();
                    string consulta = ("SELECT  * FROM wmm_denominacionMB ");
                    SqlCommand conmand = new SqlCommand(consulta, cn);



                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloDenominacionesMoneda item = new modeloDenominacionesMoneda();
                        item.id = Convert.ToString(dr["id"]);
                        item.observaciones = Convert.ToString(dr["nombre"]) + "  " + Convert.ToString(dr["valor"]);
                        item.cod_moneda = Convert.ToString(dr["cod_moneda"]);
                        item.nombre = Convert.ToString(dr["nombre"]);
                        item.valor = Convert.ToDecimal(dr["valor"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "CMonedas.cs", "ListaDenominacionMoneda", e.ToString(), DateTime.Today, "consulta");
                return null;
            }

        }

        //Buscar si ya existe la  Denominacion wmm_denominacionMB
        public List<modeloDenominacionesMoneda> UnicoDenominacion(string cod_moneda, string nombre, string valor)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloDenominacionesMoneda> lista = new List<modeloDenominacionesMoneda>();
                    string consulta = "SELECT  * FROM wmm_denominacionMB WHERE cod_moneda = @cod_moneda  and  nombre =@nombre and valor =@valor ";
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("cod_moneda", SqlDbType.VarChar).Value = cod_moneda;
                    conmand.Parameters.Add("nombre", SqlDbType.VarChar).Value = nombre;
                    conmand.Parameters.Add("valor", SqlDbType.VarChar).Value = valor;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {
                        modeloDenominacionesMoneda item = new modeloDenominacionesMoneda();
                        item.observaciones = Convert.ToString(dr["nombre"]) + "  " + Convert.ToString(dr["valor"]);
                        item.cod_moneda = Convert.ToString(dr["cod_moneda"]).Trim();
                        item.nombre = Convert.ToString(dr["nombre"]).Trim();
                        item.valor = Convert.ToDecimal(dr["valor"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.fecha_mod = Convert.ToString(dr["fecha_mod"]);
                        item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                        item.nro_audit = Convert.ToString(dr["nro_audit"]);
                        lista.Add(item);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "CMonedas.cs", "UnicoDenominacion", e.ToString(), DateTime.Today, "consulta");
                return null;
            }

        }

        //Insertar Denominacion wmm_denominacionMB
        public string InsertarDenominacion(modeloDenominacionesMoneda Denominacion)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO  wmm_denominacionMB (cod_moneda, nombre, valor, usuario_mod, fecha_mod) VALUES (@cod_moneda, @nombre, @valor, @usuario_mod, @fecha_mod)";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@cod_moneda", SqlDbType.VarChar).Value = Denominacion.cod_moneda;
                    conmand.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Denominacion.nombre;
                    conmand.Parameters.Add("@valor", SqlDbType.VarChar).Value = Denominacion.valor;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = Denominacion.usuario_mod;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = Denominacion.fecha_mod;

                    int dr = conmand.ExecuteNonQuery();
                    return "Denominacion guardada correctamente";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", "CMonedas.cs", "InsertarDenominacion", e.ToString(), DateTime.Today, Denominacion.usuario_mod);
                return "No se pudo completar la acción." + "InsertarDenominacion." + " Por favor notificar al administrador.";
            }

        }
        string metodo = "CMonedas.cs";
        //actualizar Denominacion wmm_denominacionMB
        public string ActualizarDenominacion(modeloDenominacionesMoneda Denominacion)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "UPDATE wmm_denominacionMB SET  cod_moneda = @cod_moneda, nombre =@nombre, valor =@valor, usuario_mod= @usuario_mod,fecha_mod = @fecha_mod WHERE id = @id";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@cod_moneda", SqlDbType.VarChar).Value = Denominacion.cod_moneda;
                    conmand.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Denominacion.nombre;
                    conmand.Parameters.Add("@valor", SqlDbType.Decimal).Value = Denominacion.valor;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = Denominacion.usuario_mod;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.VarChar).Value = Denominacion.fecha_mod;
                    conmand.Parameters.Add("@id", SqlDbType.Decimal).Value = Denominacion.id;

                    int dr = conmand.ExecuteNonQuery();
                    return "Denominacion guardada correctamente";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "ActualizarDenominacion", e.ToString(), DateTime.Today, Denominacion.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarDenominacion." + " Por favor notificar al administrador.";
            }

        }

        //Eliminar Denominacion wmm_denominacionMB
        public string EliminarDenominacion(modeloDenominacionesMoneda Denominacion)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "DELETE FROM wmm_denominacionMB WHERE  id = @id";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@id", SqlDbType.Decimal).Value = Denominacion.id;

                    int dr = conmand.ExecuteNonQuery();
                    return "Denominacion eliminada correctamente";
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "EliminarDenominacion", e.ToString(), DateTime.Today, Denominacion.usuario_mod);
                return "No se pudo completar la acción." + "EliminarDenominacion." + " Por favor notificar al administrador.";
            }

        }

    }
}
