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
   public  class Consultawmspcmonedas
    {
        CMonedas cmonedas = new CMonedas();
        FormatoCantidades formatoCant = new FormatoCantidades();
        modelowmspcmonedas modelomonedas = new modelowmspcmonedas();
        modeloDenominacionesMoneda modeloDenominaciones = new modeloDenominacionesMoneda();
            
        public List<modelowmspcmonedas> ConsultaCMonedas(string MonB__usuario, string MonB__cod_emp, string MonB__moneda)
        {
            List<modelowmspcmonedas> lista = new List<modelowmspcmonedas>();
            lista = cmonedas.ListaBuscaCMonedas(MonB__usuario, MonB__cod_emp, MonB__moneda);            
            return lista;
        }

        //Consulta lista de denominaciones por cod_moneda  wmm_denominacionM
        public List<modeloDenominacionesMoneda> ConsultaDenominacionesMonedas()
        {
            List<modeloDenominacionesMoneda> lista = new List<modeloDenominacionesMoneda>();
            lista = cmonedas.ListaDenominacionMoneda();
            return lista;
        }

        //Consulta lista de denominaciones por cod_moneda  wmm_denominacionM para actualizar
        public List<modeloDenominacionesMoneda> ConsultaDenominacionesUDP(string id)
        {
            List<modeloDenominacionesMoneda> lista = new List<modeloDenominacionesMoneda>();
            lista = cmonedas.ListaDenominacionUDP(id);
            return lista;
        }
        //Consulta unico denominaciones en  wmm_denominacionM
        public List<modeloDenominacionesMoneda> ConsultaUnicoDenominacion(string cod_moneda, string nombre, string valor)
        {
            List<modeloDenominacionesMoneda> lista = new List<modeloDenominacionesMoneda>();
            lista = cmonedas.UnicoDenominacion( cod_moneda,  nombre,  valor);
            return lista;
        }
        //Insertar denominaciones en wmm_denominacionM
        public string InsertarDenominacion(modeloDenominacionesMoneda ModeloDenominacion)
        {
            string respuesta = cmonedas.InsertarDenominacion(ModeloDenominacion);
            return respuesta;
        }

        //Actualizar denominaciones en wmm_denominacionM
        public string ActualizarDenominacion(modeloDenominacionesMoneda ModeloDenominacion)
        {
            string respuesta = cmonedas.ActualizarDenominacion(ModeloDenominacion);
            return respuesta;
        }

        //eliminar denominaciones en wmm_denominacionM
        public string EliminarDenominacion(modeloDenominacionesMoneda ModeloDenominacion)
        {
            string respuesta = cmonedas.EliminarDenominacion(ModeloDenominacion);
            return respuesta;
        }
        //Redondear numeros necesariamente debe ir numero a cambiar en decimal
        public decimal RedondearNumero(string nro_decimales, decimal numero)
        {
            decimal respuesta = formatoCant.RedondearNumero(nro_decimales, numero);
            return respuesta;
        }

        //Formato 
        public string FormatorNumero(string nro_decimales, decimal numero)
        {
            string respuesta = formatoCant.FormatoNumero(nro_decimales, numero);
            return respuesta;
        }
    }
}
