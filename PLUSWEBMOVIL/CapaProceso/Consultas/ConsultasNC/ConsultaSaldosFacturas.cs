using CapaDatos.Modelos.ModelosNC;
using CapaDatos.Sql.SqlNC;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
   public class ConsultaSaldosFacturas
    {
        
        SaldosFacturas consultaSaldoa = new SaldosFacturas();
        //Saldos sin restricciones
        public List<modeloSaldosFacturas> BuscartaFacturaSaldos( string Ccf_usuario, string Ccf_cod_emp, string Ccf_tipo1, string Ccf_tipo2)
        {
            modeloFacturasElecSaldos modeloFacturasElecSaldos = new modeloFacturasElecSaldos();
            List<modeloSaldosFacturas> lista = new List<modeloSaldosFacturas>();
            List<modeloSaldosFacturas> listaAux = new List<modeloSaldosFacturas>();
            lista = consultaSaldoa.ConsultaFacturasSaldos(Ccf_usuario, Ccf_cod_emp, Ccf_tipo1, Ccf_tipo2);

            foreach (var item in lista)
            {
                modeloFacturasElecSaldos = BuscartaFacEleSaldos(Ccf_tipo1, Ccf_cod_emp, item.nro_trans);
                if (modeloFacturasElecSaldos != null )
                {
                    listaAux.Add(item);
                }
               
            }
           
            return listaAux;
        }

        //sql saldos de FE nuevo 
        public modeloFacturasElecSaldos BuscartaFacEleSaldos(string cod_cliente, string cod_emp, string nro_trans)
        {
            modeloFacturasElecSaldos item = new modeloFacturasElecSaldos();
            item = consultaSaldoa.ConsultaFacEleSaldos(cod_cliente, cod_emp, nro_trans);
            return item;
        }

        
    }
}
