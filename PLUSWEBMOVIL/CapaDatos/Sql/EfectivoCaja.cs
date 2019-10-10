using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public class EfectivoCaja
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "EfectivoCaja.cs";
        //Buscar por fecha
        public Int64 BuscarEfectivoCajaSecuencial(string fecha_efe, string cod_emp)
        {
            try
            {

                Int64 secuencial = 0;

                using (cn = conexion.genearConexion())
                {
                    string insert = "SELECT TOP 1  secuencial FROM wmt_efectivoCaja where fecha_efe = @fecha_efe AND cod_emp =@cod_emp ORDER BY wmt_efectivoCaja.secuencial DESC ";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@fecha_efe", SqlDbType.VarChar).Value = fecha_efe;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        secuencial = Convert.ToInt64(dr["secuencial"]);


                    }

                    return secuencial + 1;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "BuscarEfectivoCajaSecuencia", e.ToString(), DateTime.Today, "consulta");
                return 0;
            }
        }

        //Ultimo secuencial
        public Int64 UltimoEfectivoCajaSecuencial(string fecha_efe, string cod_emp, string nro_caja)
        {
            try
            {
                Int64 secuencial = 0;

                using (cn = conexion.genearConexion())
                {
                    string insert = "SELECT TOP 1  secuencial FROM wmt_efectivoCaja where fecha_efe = @fecha_efe AND cod_emp =@cod_emp AND nro_caja=@nro_caja ORDER BY wmt_efectivoCaja.secuencial DESC ";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@fecha_efe", SqlDbType.VarChar).Value = fecha_efe;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@nro_caja", SqlDbType.VarChar).Value = nro_caja;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        secuencial = Convert.ToInt64(dr["secuencial"]);


                    }

                    return secuencial;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "UltimoEfectivoCajaSecuencial", e.ToString(), DateTime.Today, "consulta");
                return 0;
            }
        }

        //Buscar lista de Efectivo Caja
        public List<modeloEfectivoCaja> BuscarEfectivoCF(string nro_trans, Int64 secuencial, string cod_emp, string usuario)
        {
            try {
                using (cn = conexion.genearConexion())
                {
                    List<modeloEfectivoCaja> lista = new List<modeloEfectivoCaja>();
                    string consulta = (" SELECT wmt_efectivoCaja.id,wmt_efectivoCaja.denominacionMId,wmt_efectivoCaja.valor,wmt_efectivoCaja.cantidad,wmt_efectivoCaja.total,wmt_efectivoCaja.fecha_efe,wmt_efectivoCaja.usuario_mod,wmt_efectivoCaja.cod_pro_aud,wmt_efectivoCaja.secuencial,wmm_denominacionMB.nombre,wmt_efectivoCaja.fecha_mod,wmt_efectivoCaja.nro_audit, wmt_efectivoCaja.cod_emp, wmt_efectivoCaja.nro_caja FROM wmt_efectivoCaja INNER JOIN wmm_denominacionMB ON wmt_efectivoCaja.denominacionMId = wmm_denominacionMB.id WHERE wmt_efectivoCaja.secuencial =@secuencial AND wmt_efectivoCaja.nro_trans=@nro_trans AND wmt_efectivoCaja.cod_emp =@cod_emp");

                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("nro_trans", SqlDbType.VarChar).Value =nro_trans;
                    conmand.Parameters.Add("secuencial", SqlDbType.BigInt).Value = secuencial;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    
                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloEfectivoCaja item = new modeloEfectivoCaja();
                        item.id = Convert.ToString(dr["denominacionMId"]);

                        item.denominacionMId = Convert.ToDecimal(dr["denominacionMId"]);
                        item.valor = Convert.ToDecimal(dr["valor"]);
                        string valor1 = String.Format("{0:N0}", item.valor).ToString();
                        item.Observaciones = Convert.ToString(dr["nombre"]) + " " + "DE " + valor1;
                        item.cantidad = Convert.ToDecimal(dr["cantidad"]);

                        item.total = Convert.ToDecimal(dr["total"]);
                        item.canti = String.Format("{0:N2}", item.total).ToString();
                        item.fecha_efe = Convert.ToString(dr["fecha_efe"]);
                        item.secuencial = Convert.ToInt64(dr["secuencial"]);
                        item.cbx_secuencias = "Cierre N° " + item.secuencial;
                        item.cod_emp = Convert.ToString(dr["cod_emp"]);
                        item.nro_caja = Convert.ToString(dr["nro_caja"]);
                        lista.Add(item);

                    }

                    return lista;
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "BuscarEfectivoCF", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

        //ListaEfectivoFechaGeneral, wmt_efectivoCaja, busqueda x fecha , usuario y las cajas especifica 
        public List<modeloEfectivoCaja> ListaEfectivoFechaCajaUsuarioEspec(string cod_emp, string fecha_inicio, string fecha_fin, string usuario, string usuario_caja, string nro_caja)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloEfectivoCaja> lista = new List<modeloEfectivoCaja>();
                    string consulta = ("SELECT  DISTINCT(secuencial), nro_trans, fecha_efe, nro_caja, usuario_mod FROM wmt_efectivoCaja WHERE cod_emp= @cod_emp AND nro_caja=@nro_caja AND usuario_mod=@usuario_caja  AND fecha_efe  BETWEEN @fecha_inicio  AND @fecha_fin ORDER BY wmt_efectivoCaja.secuencial DESC");

                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("fecha_inicio", SqlDbType.VarChar).Value = fecha_inicio;
                    conmand.Parameters.Add("fecha_fin", SqlDbType.VarChar).Value = fecha_fin;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@nro_caja", SqlDbType.VarChar).Value = nro_caja;
                    conmand.Parameters.Add("@usuario_caja", SqlDbType.VarChar).Value = usuario_caja;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloEfectivoCaja item = new modeloEfectivoCaja();
                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        DateTime fec_doc_str = Convert.ToDateTime(dr["fecha_efe"]);
                        item.fecha_st = fec_doc_str.ToString("yyyy-MM-dd");
                        item.fecha_efe = Convert.ToString(dr["fecha_efe"]);
                        item.nro_caja = Convert.ToString(dr["nro_caja"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.secuencial = Convert.ToInt64(dr["secuencial"]);
                        item.cbx_secuencias = "Cierre N° " + item.secuencial;

                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, " ListaEfectivoFechaCajaUsuarioEspec", e.ToString(), DateTime.Today, usuario);
                return null;
            }

        }

        //ListaEfectivoFechaGeneral, wmt_efectivoCaja, busqueda x fecha y usuario especifica y todas las cajas
        public List<modeloEfectivoCaja> ListaEfectivoFechaCajaUsuario(string cod_emp, string fecha_inicio, string fecha_fin, string usuario,  string usuario_caja)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloEfectivoCaja> lista = new List<modeloEfectivoCaja>();
                    string consulta = ("SELECT  DISTINCT(secuencial), nro_trans, fecha_efe, nro_caja, usuario_mod FROM wmt_efectivoCaja WHERE cod_emp= @cod_emp AND usuario_mod=@usuario_caja  AND fecha_efe  BETWEEN @fecha_inicio  AND @fecha_fin ORDER BY wmt_efectivoCaja.secuencial DESC");

                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("fecha_inicio", SqlDbType.VarChar).Value = fecha_inicio;
                    conmand.Parameters.Add("fecha_fin", SqlDbType.VarChar).Value = fecha_fin;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    //conmand.Parameters.Add("@nro_caja", SqlDbType.VarChar).Value = nro_caja;
                    conmand.Parameters.Add("@usuario_caja", SqlDbType.VarChar).Value = usuario_caja;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloEfectivoCaja item = new modeloEfectivoCaja();
                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        DateTime fec_doc_str = Convert.ToDateTime(dr["fecha_efe"]);
                        item.fecha_st = fec_doc_str.ToString("yyyy-MM-dd");
                        item.fecha_efe = Convert.ToString(dr["fecha_efe"]);
                        item.nro_caja = Convert.ToString(dr["nro_caja"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.secuencial = Convert.ToInt64(dr["secuencial"]);
                        item.cbx_secuencias = "Cierre N° " + item.secuencial;

                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaEfectivoFechaCajaUsuario", e.ToString(), DateTime.Today, usuario);
                return null;
            }

        }


        //ListaEfectivoFechaGeneral, wmt_efectivoCaja, busqueda x fecha y caja especifica
        public List<modeloEfectivoCaja> ListaEfectivoFechaCaja(string cod_emp, string fecha_inicio, string fecha_fin, string usuario, string nro_caja)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloEfectivoCaja> lista = new List<modeloEfectivoCaja>();
                    string consulta = ("SELECT  DISTINCT(secuencial), nro_trans, fecha_efe, nro_caja, usuario_mod FROM wmt_efectivoCaja WHERE cod_emp= @cod_emp AND nro_caja=@nro_caja  AND fecha_efe  BETWEEN @fecha_inicio  AND @fecha_fin ORDER BY wmt_efectivoCaja.secuencial DESC");

                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("fecha_inicio", SqlDbType.VarChar).Value = fecha_inicio;
                    conmand.Parameters.Add("fecha_fin", SqlDbType.VarChar).Value = fecha_fin;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@nro_caja", SqlDbType.VarChar).Value = nro_caja;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloEfectivoCaja item = new modeloEfectivoCaja();
                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        DateTime fec_doc_str = Convert.ToDateTime(dr["fecha_efe"]);
                        item.fecha_st = fec_doc_str.ToString("yyyy-MM-dd");
                        item.fecha_efe = Convert.ToString(dr["fecha_efe"]);
                        item.nro_caja = Convert.ToString(dr["nro_caja"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.secuencial = Convert.ToInt64(dr["secuencial"]);
                        item.cbx_secuencias = "Cierre N° " + item.secuencial;

                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaEfectivoFechaCaja", e.ToString(), DateTime.Today, usuario);
                return null;
            }

        }


        //ListaEfectivoFechaGeneral, wmt_efectivoCaja
        public List<modeloEfectivoCaja> ListaEfectivoFechaGeneral(string cod_emp, string fecha_inicio, string fecha_fin, string usuario)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloEfectivoCaja> lista = new List<modeloEfectivoCaja>();
                    string consulta = ("SELECT  DISTINCT(secuencial), nro_trans, fecha_efe, nro_caja, usuario_mod FROM wmt_efectivoCaja WHERE cod_emp= @cod_emp AND fecha_efe  BETWEEN @fecha_inicio  AND @fecha_fin ORDER BY wmt_efectivoCaja.secuencial DESC");

                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("fecha_inicio", SqlDbType.VarChar).Value = fecha_inicio;
                    conmand.Parameters.Add("fecha_fin", SqlDbType.VarChar).Value = fecha_fin;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                   // conmand.Parameters.Add("@nro_caja", SqlDbType.VarChar).Value = nro_caja;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloEfectivoCaja item = new modeloEfectivoCaja();
                        item.nro_trans = Convert.ToString(dr["nro_trans"]);
                        DateTime fec_doc_str = Convert.ToDateTime(dr["fecha_efe"]);
                        item.fecha_st = fec_doc_str.ToString("yyyy-MM-dd");
                        item.fecha_efe = Convert.ToString(dr["fecha_efe"]);
                        item.nro_caja = Convert.ToString(dr["nro_caja"]);
                        item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                        item.secuencial = Convert.ToInt64(dr["secuencial"]);
                        item.cbx_secuencias = "Cierre N° " + item.secuencial;

                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaEfectivoFechaGeneral", e.ToString(), DateTime.Today, usuario);
                return null;
            }

        }

        //Lista de cierres por fecha especifica
        public List<modeloEfectivoCaja> ListaEfectivoFecha(string fecha_efe, string cod_emp, string nro_caja)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloEfectivoCaja> lista = new List<modeloEfectivoCaja>();
                    string consulta = (" SELECT DISTINCT(secuencial) FROM wmt_efectivoCaja WHERE fecha_efe =@fecha_efe AND cod_emp= @cod_emp AND nro_caja=@nro_caja ORDER BY wmt_efectivoCaja.secuencial DESC");

                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("fecha_efe", SqlDbType.VarChar).Value = fecha_efe;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@nro_caja", SqlDbType.VarChar).Value = nro_caja;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloEfectivoCaja item = new modeloEfectivoCaja();
                        item.secuencial = Convert.ToInt64(dr["secuencial"]);
                        item.cbx_secuencias = "Cierre N° " + item.secuencial;

                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaEfectivoFecha", e.ToString(), DateTime.Today, "consulta");
                return null;
            }

        }
        //Insertar cierre en tabla wmt_cierre_resumencaja
        public string InsertarEfectivoCaja(modeloEfectivoCaja Efectivocaja)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "INSERT INTO  wmt_efectivoCaja (denominacionMId,  valor,cantidad,total, usuario_mod, fecha_mod,fecha_efe, secuencial, cod_emp, nro_trans,nro_caja, cod_pro_aud ) VALUES (@denominacionMId,  @valor,@cantidad,@total, @usuario_mod, @fecha_mod,@fecha_efe, @secuencial, @cod_emp, @nro_trans, @nro_caja, @cod_proc_aud )";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@denominacionMId", SqlDbType.Decimal).Value = Efectivocaja.denominacionMId;
                    conmand.Parameters.Add("@valor", SqlDbType.Decimal).Value = Efectivocaja.valor;
                    conmand.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = Efectivocaja.cantidad;
                    conmand.Parameters.Add("@total", SqlDbType.Decimal).Value = Efectivocaja.total;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = Efectivocaja.usuario_mod;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = Efectivocaja.fecha_mod;
                    conmand.Parameters.Add("@fecha_efe", SqlDbType.VarChar).Value = Efectivocaja.fecha_efe;
                    conmand.Parameters.Add("@secuencial", SqlDbType.BigInt).Value = Efectivocaja.secuencial;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = Efectivocaja.cod_emp;
                    conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = Efectivocaja.nro_trans;
                    conmand.Parameters.Add("@nro_caja", SqlDbType.VarChar).Value = Efectivocaja.nro_caja;
                    conmand.Parameters.Add("@cod_proc_aud", SqlDbType.VarChar).Value = Efectivocaja.cod_proc_aud;
                    int dr = conmand.ExecuteNonQuery();
                    return "Efectivo Caja guardada correctamente";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Efectivocaja.cod_emp, metodo, "InsertarEfectivoCaja", e.ToString(), DateTime.Today, Efectivocaja.usuario_mod);
                return "No se pudo completar la acción." + "InsertarEfectivoCajaActualizarDatTitular." + " Por favor notificar al administrador.";
            }

        }
        //Actualizar cierre en tabla wmt_cierre_resumencaja
        public string ActualizarEfectivoCaja(modeloEfectivoCaja Efectivocaja)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "UPDATE  wmt_efectivoCaja SET denominacionMBId =@denominacionMBId,  valor =@valor,cantidad =@cantidad,total =@total, usuario_mod =@usuario_mod , fecha_mod = @fecha_mod WHERE id= @id";
                    SqlCommand conmand = new SqlCommand(insert, cn);
                    conmand.Parameters.Add("@denominacionMBId", SqlDbType.VarChar).Value = Efectivocaja.denominacionMId;
                    conmand.Parameters.Add("@valor", SqlDbType.VarChar).Value = Efectivocaja.valor;
                    conmand.Parameters.Add("@cantidad", SqlDbType.VarChar).Value = Efectivocaja.cantidad;
                    conmand.Parameters.Add("@total", SqlDbType.Decimal).Value = Efectivocaja.total;
                    conmand.Parameters.Add("@usuario_mod", SqlDbType.VarChar).Value = Efectivocaja.usuario_mod;
                    conmand.Parameters.Add("@fecha_mod", SqlDbType.DateTime).Value = Efectivocaja.fecha_mod;
                    conmand.Parameters.Add("@fecha_efe", SqlDbType.VarChar).Value = Efectivocaja.fecha_efe;
                    conmand.Parameters.Add("@id", SqlDbType.VarChar).Value = Efectivocaja.id;

                    int dr = conmand.ExecuteNonQuery();
                    return "Efectivo Caja guardada correctamente";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Efectivocaja.cod_emp, metodo, "ActualizarEfectivoCaja", e.ToString(), DateTime.Today, Efectivocaja.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarEfectivoCaja." + " Por favor notificar al administrador.";
            }

        }

        //Eliminar cierre en tabla wmt_cierre_resumencaja
        public string EliminarEfectivoCaja(modeloEfectivoCaja Efectivocaja)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    string insert = "DELETE  wmt_efectivoCaja  WHERE id= @id";
                    SqlCommand conmand = new SqlCommand(insert, cn);

                    conmand.Parameters.Add("@id", SqlDbType.VarChar).Value = Efectivocaja.id;

                    int dr = conmand.ExecuteNonQuery();
                    return "Efectivo  Caja eliminado correctamente";
                }

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Efectivocaja.cod_emp, metodo, "ActualizarEfectivoCaja", e.ToString(), DateTime.Today, Efectivocaja.usuario_mod);
                return "No se pudo completar la acción." + "ActualizarEfectivoCaja." + " Por favor notificar al administrador.";
            }

        }

        //Trae total de pagos en efectivo por facturas pos, pose
        public List<modeloTotalPgsFacturas> ListaEfectivoCF(string fecha)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloTotalPgsFacturas> lista = new List<modeloTotalPgsFacturas>();
                    string consulta = (" SELECT SUM(wmt_facturas_pgs.valor) AS total, SUM (wmt_facturas_pgs.recibido) as recibido, SUM(wmt_facturas_pgs.diferencia) AS vueltos FROM wmm_fpagoPOS, wmt_facturas_pgs, wmt_facturas_cab WHERE wmm_fpagoPOS.vuelto = 's' AND wmt_facturas_pgs.cod_fpago = wmm_fpagoPOS.cod_fpago AND wmt_facturas_cab.fec_doc = @fecha and wmt_facturas_cab.nro_trans = wmt_facturas_pgs.nro_trans AND wmt_facturas_cab.tipo IN ('POS','POSE') AND wmt_facturas_cab.estado in('C','F')");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("fecha", SqlDbType.VarChar).Value = fecha;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloTotalPgsFacturas item = new modeloTotalPgsFacturas();
                        item.total = Convert.ToString(dr["total"]);

                        item.recibido = Convert.ToString(dr["recibido"]);
                        item.vueltos = Convert.ToString(dr["vueltos"]);
                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "ListaEfectivoCF", e.ToString(), DateTime.Today, "consulta");
                return null;
            }

        }

        //Trae total de NOTAS DE VENTA TIPO NVTA
        public List<modeloTotalPgsFacturas> ListaTotalNVTA(string fecha)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloTotalPgsFacturas> lista = new List<modeloTotalPgsFacturas>();
                    string consulta = (" SELECT SUM(wmt_facturas_pgs.valor) AS total, SUM (wmt_facturas_pgs.recibido) as recibido, SUM(wmt_facturas_pgs.diferencia) AS vueltos FROM wmm_fpagoPOS, wmt_facturas_pgs, wmt_facturas_cab WHERE wmm_fpagoPOS.vuelto = 's' AND wmt_facturas_pgs.cod_fpago = wmm_fpagoPOS.cod_fpago AND wmt_facturas_cab.fec_doc = @fecha and wmt_facturas_cab.nro_trans = wmt_facturas_pgs.nro_trans AND wmt_facturas_cab.tipo ='NVTA'");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("fecha", SqlDbType.VarChar).Value = fecha;

                    SqlDataReader dr = conmand.ExecuteReader();
                    while (dr.Read())
                    {

                        modeloTotalPgsFacturas item = new modeloTotalPgsFacturas();
                        item.total = Convert.ToString(dr["total"]);

                        item.recibido = Convert.ToString(dr["recibido"]);
                        item.vueltos = Convert.ToString(dr["vueltos"]);


                        lista.Add(item);

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "ListaTotalNVTA", e.ToString(), DateTime.Today, "consulta");
                return null;
            }

        }


    }
}
