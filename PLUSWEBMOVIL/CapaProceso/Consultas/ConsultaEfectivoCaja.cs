using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
   public class ConsultaEfectivoCaja
    {
        EfectivoCaja efectivocaja = new EfectivoCaja();
        modeloEfectivoCaja modeloECaja = new modeloEfectivoCaja();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "ConsultaEfectivoCaja.cs";

        //Consulta  BuscarEfectivoSecuencial wmt_efectivocaja
        public Int64 BuscarEfectivoSecuencial(string fecha ,string cod_emp)
        {

            return efectivocaja.BuscarEfectivoCajaSecuencial(fecha, cod_emp);
        }

        //ultimo secuencial wmt_efectivocaja
        public Int64 UltimoEfectivoSecuencial(string fecha, string cod_emp, string nro_caja)
        {

            return efectivocaja.UltimoEfectivoCajaSecuencial(fecha, cod_emp, nro_caja);
        }

        //lista ultimo efectivo caja
        //Consulta total pagos efectivo pos, y pose
        public List<modeloEfectivoCaja> ListaCCajaFecha(string fecha, Int64 secuencial, string cod_emp, string nro_caja)
        {
            try
            {
                List<modeloEfectivoCaja> lista = new List<modeloEfectivoCaja>();
                lista = efectivocaja.BuscarEfectivoCF(fecha, secuencial, cod_emp, nro_caja);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaCCajaFecha", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }

        //lista de secuenciales para cbx_secuencial
        public List<modeloEfectivoCaja> ListaSecuencialFecha(string fecha,  string cod_emp,string nro_caja)
        {
            try
            {
                List<modeloEfectivoCaja> lista = new List<modeloEfectivoCaja>();
                lista = efectivocaja.ListaEfectivoFecha(fecha, cod_emp, nro_caja);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(cod_emp, metodo, "ListaSecuencialFecha", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
        //insertar efectivo caja
        public string InsertarECaja(modeloEfectivoCaja ModeloECaja)
        {
            try
            {
                string respuesta = efectivocaja.InsertarEfectivoCaja(ModeloECaja);
                return respuesta;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ModeloECaja.cod_emp, metodo, "InsertarECaja", e.ToString(), DateTime.Today, ModeloECaja.usuario_mod);
                return "No se pudo completar la acción." + "InsertarECaja." + " Por favor notificar al administrador.";
            }
        }

        //Consulta total pagos efectivo pos, y pose
        public List<modeloTotalPgsFacturas> ConsultaCCajaFecha(string fecha)
        {
            try
            {
                List<modeloTotalPgsFacturas> lista = new List<modeloTotalPgsFacturas>();
                lista = efectivocaja.ListaEfectivoCF(fecha);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "ConsultaCCajaFecha", e.ToString(), DateTime.Today, "consulta");
                return null;
            }

        }

        //Consulta total NVTA
        public List<modeloTotalPgsFacturas> ConsultaTotalNVTA(string fecha)
        {
            try
            {
                List<modeloTotalPgsFacturas> lista = new List<modeloTotalPgsFacturas>();
                lista = efectivocaja.ListaTotalNVTA(fecha);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion("0", metodo, "ConsultaTotalNVTA", e.ToString(), DateTime.Today, "consulta");
                return null;
            }
        }
    }
}
