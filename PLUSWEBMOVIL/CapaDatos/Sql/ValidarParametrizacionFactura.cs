using CapaDatos.Modelos;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public class ValidarParametrizacionFactura
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo ="ValidarParametrizacionFactura.cs";
        string stringConexionERP = "";// Aqui va la consulta de la table de alfredo desia que va ir el string

        //Consulta wmm_parametros conexion_erp
        public string ConsultaConexionERP(string cod_emp, string usuario)
        {
            try
            {
                
                using (cn = conexion.genearConexion())
                {
                    string consulta = ("SELECT conexion_erp FROM wmm_parametros where cod_emp =@cod_emp");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;


                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        stringConexionERP = Convert.ToString(dr["conexion_erp"]);
                    }
                    return stringConexionERP;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ConsultaConexionERP", e.ToString(), DateTime.Today, usuario);
                return "No se pudo completar la acción." + "ConsultaConexionERP." + " Por favor notificar al administrador.";
            }
        }



        //Consulta ERP , periodo contable tabla(CmPrC)
        public string ValidarPeriodoContable(string cod_emp, string usuario, string fecha)
        {
            try
            {
                stringConexionERP = ConsultaConexionERP(cod_emp, usuario);
                string nombre_periodo = "";
                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    string consulta = ("SELECT CmPrC.CmPrCNom as periodo FROM CmPrC WHERE @fecha BETWEEN CmPrC.CmPrCIni AND CmPrC.CmPrCFin");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.Parameters.Add("@fecha", SqlDbType.VarChar).Value = fecha;
                  

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        nombre_periodo = Convert.ToString(dr["periodo"]);
                    }
                    return nombre_periodo;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp,metodo, "ValidarPeriodoContable", e.ToString(), DateTime.Now, usuario);
                return "No se pudo completar la acción." + "ValidarPeriodoContable." + " Por favor notificar al administrador.";
            }
        }

        //Consulta codigo pais, cuidad, cod_moenda empresa ERP TABLA(AmCom)
        
         public Boolean ValidarMonCiudEmpresaERP(string cod_emp, string usuario)
        {
            try
            {
                Boolean repuesta = false;
                stringConexionERP = ConsultaConexionERP(cod_emp, usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {
                    
                    string consulta = ("SELECT TOP 1 AmComMonB, AmComCiuM FROM AmCom");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {                       
                        if (Convert.ToString(dr["AmComCiuM"]) != null && Convert.ToString(dr["AmComMonB"]) != null)
                        {
                            repuesta = true;
                        }                       

                    }

                    return repuesta;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ValidarMonCiudEmpresaERP", e.ToString(), DateTime.Now, usuario);
                return false;
            }
        }

        //Consulta BUSCAR RESOLUCION DE Factura
        public Boolean ValidarResolucionERP(string cod_emp, string usuario, string estado , string serie, string fecha,string emp_erp)
        {
            try
            {
                Boolean repuesta = false;
                stringConexionERP = ConsultaConexionERP(cod_emp, usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {

                    string consulta = ("SELECT * FROM AdSer WHERE AdSer.AmComCod=@cod_emp AND AdSer.AdSerEst=@estado AND AdSer.AcSerCod=@serie AND @fecha BETWEEN AdSer.AdSerFHR AND AdSer.AdSerFCd");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = emp_erp;
                    conmand.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;
                    conmand.Parameters.Add("@serie", SqlDbType.VarChar).Value = serie;
                    conmand.Parameters.Add("@fecha", SqlDbType.VarChar).Value = fecha;
                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        if (Convert.ToString(dr["AdSerEst"]) != null && Convert.ToString(dr["AcSerCod"]) != null)
                        {
                            repuesta = true;
                        }

                    }

                    return repuesta;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ValidarResolucionERP", e.ToString(), DateTime.Today, usuario);
                return false;
            }
        }

        //Validar nro_docum , rango fecha (AdSer)

        public Boolean ValidarNroDocumERP(string cod_emp, string usuario, string serie_docum , string nro_docum)
        {
            try
            {
                Boolean repuesta = false;
                stringConexionERP = ConsultaConexionERP(cod_emp, usuario);

                using (cn = conexion.genearConexionERP(stringConexionERP))
                {

                    string consulta = ("SELECT AdSerDcI,AdSerDcF FROM AdSer WHERE AmComCod= @cod_emp AND AcSerCod=@serie_docum AND @nro_docum  BETWEEN AdSerDcI AND AdSerDcF");
                    SqlCommand conmand = new SqlCommand(consulta, cn);
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                    conmand.Parameters.Add("@serie_docum", SqlDbType.VarChar).Value = serie_docum;
                    conmand.Parameters.Add("@@nro_docum", SqlDbType.VarChar).Value = nro_docum;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {
                        if (Convert.ToString(dr["AdSerDcI"]) != null && Convert.ToString(dr["AdSerDcF"]) != null)
                        {
                            repuesta = true;
                        }

                    }

                    return repuesta;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ValidarNroDocumERP", e.ToString(), DateTime.Today, usuario);
                return false;
            }
        }
    }
}