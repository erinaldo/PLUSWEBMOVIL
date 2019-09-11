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
    public class Cosnsultawmspcarticulos
    {
        Articulos articulos = new Articulos();
        modelowmspcarticulos modeloarticulos = new modelowmspcarticulos();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<modelowmspcarticulos> ConsultaArticulos(string ArtB__usuario, string ArtB__cod_emp, string ArtB__articulo, string ArtB__tipo, string ArtB__compras, string ArtB__ventas)
        {
            try
            {
                List<modelowmspcarticulos> lista = new List<modelowmspcarticulos>();
                lista = articulos.ListaArticulos(ArtB__usuario, ArtB__cod_emp, ArtB__articulo, ArtB__tipo, ArtB__compras, ArtB__ventas);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(ArtB__cod_emp, "Consultawmspcarticulos.cs", "ConsultaArticulos", e.ToString(), DateTime.Today, ArtB__usuario);
                return null;
            }
        }
    }
}
    

