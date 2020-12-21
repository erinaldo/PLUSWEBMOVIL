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
    public class ConsultaIngresoFacturas
    {
        CapaDatos.Sql.Documento documento = new CapaDatos.Sql.Documento();
        IngresosPFacturas ConsPgsFacturas = new IngresosPFacturas();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        //NV
        public List<modeloIngresoFacturas> BuscarNotasVenta(string Ccf_cod_emp, string fecha, string Ven__usuario, string Ven__cod_tipotit, string Ven__cod_tit, string Ven__cod_dgi)
        {
            try
            {
                modelowmspctitulares modeloClienteDatos = new modelowmspctitulares();
                List<modeloIngresoFacturas> lista = new List<modeloIngresoFacturas>();

                lista = ConsPgsFacturas.ListaNotasVenta(Ccf_cod_emp, fecha);

                foreach (var item in lista)
                {
                    modeloClienteDatos = ConsultaTitulares(Ven__usuario, Ccf_cod_emp, "clientes", item.cod_tit.Trim(), "0");
                    if (modeloClienteDatos != null)
                    {
                        item.razon_social = modeloClienteDatos.razon_social;

                    }

                }

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, "ConsultaIngresoFacturas.cs", "BuscarNotasVenta", e.ToString(), DateTime.Today, Ven__usuario);
                return null;
            }
        }
        public List<modeloIngresoFacturas> BuscarPgsFacturas(string Ccf_cod_emp,string fecha, string Ven__usuario, string Ven__cod_tipotit, string Ven__cod_tit, string Ven__cod_dgi)
        {
            try
            {
                modelowmspctitulares modeloClienteDatos = new modelowmspctitulares();
                List<modeloIngresoFacturas> lista = new List<modeloIngresoFacturas>();

                lista = ConsPgsFacturas.ListaPgsFacEfectivo(Ccf_cod_emp, fecha);

                foreach (var item in lista)
                {
                    modeloClienteDatos = ConsultaTitulares(Ven__usuario, Ccf_cod_emp, "clientes", item.cod_tit.Trim(), "0");
                    if (modeloClienteDatos != null)
                    {
                        item.razon_social = modeloClienteDatos.razon_social;

                    }

                }

                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, "ConsultaIngresoFacturas.cs", "BuscarPgsFacturas", e.ToString(), DateTime.Today, Ven__usuario);
                return null;
            }
        }
        //Consulta datos cliente
        public modelowmspctitulares ConsultaTitulares(string Ven__usuario, string Ven__cod_emp, string Ven__cod_tipotit, string Ven__cod_tit, string Ven__cod_dgi)
        {
            try
            {
                modelowmspctitulares item = new modelowmspctitulares();
                item = documento.ListaBuscaCliente(Ven__usuario, Ven__cod_emp, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi);
                return item;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ven__cod_emp, "ConsultaIngresoFacturas.cs", "ConsultaTitulares", e.ToString(), DateTime.Today, Ven__usuario);
                return null;
            }
        }

    }
}
