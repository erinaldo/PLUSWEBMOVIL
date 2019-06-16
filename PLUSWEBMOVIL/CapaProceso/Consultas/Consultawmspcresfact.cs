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
    public class Consultawmspcresfact
    {
        SerieDocumento seriedocumento = new SerieDocumento();
        modelowmspcresfact resolucionesfac = new modelowmspcresfact();
        public List<modelowmspcresfact> ConsultaResolusiones(string ResF_usuario, string ResF_cod_emp, string ResF_estado, string ResF_serie, string ResF_tipo)
        {
            List<modelowmspcresfact> lista = new List<modelowmspcresfact>();
            lista = seriedocumento.ListaBuscaSerieDocumento(ResF_usuario, ResF_cod_emp, ResF_estado,  ResF_serie,  ResF_tipo);           
            return lista;
        }

    }
}
