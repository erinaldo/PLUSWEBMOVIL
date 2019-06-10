using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
   public  class ConsultawmusuarioSucursal
    {
        //Buscar usuario x sucursal
        UsuarioSucursal consultaUsuario = new UsuarioSucursal();
        modeloUsuariosucursal ModeloUsuarioSuc = new modeloUsuariosucursal();
        public List<modeloUsuariosucursal> ConsultaUsuarioSucursal(string Ccf_cod_emp, string usuario)
        {

            List<modeloUsuariosucursal> lista = new List<modeloUsuariosucursal>();
            SqlDataReader dr = consultaUsuario.ConsultaUsuarioxSucursal(Ccf_cod_emp, usuario);

            while (dr.Read())
            {
                modeloUsuariosucursal item = new modeloUsuariosucursal();
                item.cod_emp = Convert.ToString(dr["cod_emp"]);
                item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                item.usuario = Convert.ToString(dr["usuario"]);
                item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                item.nro_audit = Convert.ToString(dr["nro_audit"]);
                item.usu_ante = Convert.ToString(dr["usuario"]);
                lista.Add(item);
            }
            return lista;
        }

        //Lista de usuarios por sucursal
        UsuarioSucursal ListaUsuario = new UsuarioSucursal();
        modeloUsuariosucursal ModeloUsuarioSucursal = new modeloUsuariosucursal();
        public List<modeloUsuariosucursal> ListaUsuarioSucursal(string Ccf_cod_emp, string cod_sucursal)
        {

            List<modeloUsuariosucursal> lista = new List<modeloUsuariosucursal>();
            SqlDataReader dr = ListaUsuario.ListaUsuarioxSucursal(Ccf_cod_emp, cod_sucursal);

            while (dr.Read())
            {
                modeloUsuariosucursal item = new modeloUsuariosucursal();
                item.cod_emp = Convert.ToString(dr["cod_emp"]);
                item.cod_sucursal = Convert.ToString(dr["cod_sucursal"]);
                item.usuario = Convert.ToString(dr["usuario"]);
                item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                item.cod_proc_aud = Convert.ToString(dr["cod_proc_aud"]);
                item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                item.nro_audit = Convert.ToString(dr["nro_audit"]);
                item.nom_sucursal = Convert.ToString(dr["nom_sucursal"]);
                item.usu_ante = Convert.ToString(dr["usuario"]);
                lista.Add(item);
            }
            return lista;
        }
    }
}
