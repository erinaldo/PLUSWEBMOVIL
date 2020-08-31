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
    public class ConsultaUsuarioEmpresa
    {
        //Buscar usuario  empresa
        
        UsuarioxEmpresa consulta = new UsuarioxEmpresa();
        modeloUsuarioxempresa ModeloUsuarioempresa = new modeloUsuarioxempresa();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        public List<modeloUsuarioxempresa> ConsultaUsuariosEmpresa(string Ccf_cod_emp)
        {
            try
            {

                List<modeloUsuarioxempresa> lista = new List<modeloUsuarioxempresa>();
                lista = consulta.ConsultaUsuarioEmpresa(Ccf_cod_emp);
                return lista;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, "UsuarioxEmpresa.cs", "ConsultaUsuarioEmpresa", e.ToString(), DateTime.Now, "consulta");
                return null;
            }
        }
    }
}
