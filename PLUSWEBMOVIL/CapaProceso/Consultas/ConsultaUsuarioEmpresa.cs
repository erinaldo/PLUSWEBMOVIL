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
        public List<modeloUsuarioxempresa> ConsultaUsuariosEmpresa(string Ccf_cod_emp)
        {

            List<modeloUsuarioxempresa> lista = new List<modeloUsuarioxempresa>();
        SqlDataReader dr =consulta.ConsultaUsuarioEmpresa(Ccf_cod_emp);

            while (dr.Read())
            {
                modeloUsuarioxempresa item = new modeloUsuarioxempresa();
               
                item.cod_emp = Convert.ToString(dr["cod_emp"]);
                item.usuario = Convert.ToString(dr["usuario"]);
                item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                item.nro_audit = Convert.ToString(dr["nro_audit"]);
                lista.Add(item);
            }
            return lista;
        }
    }
}
