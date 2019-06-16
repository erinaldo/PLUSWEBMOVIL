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
   public  class ConsultawmusuarioSucursal
    {
        //Buscar unico usuario x sucursal
        UsuarioSucursal UnicoUsuario = new UsuarioSucursal();
        modeloUsuariosucursal ModeloUsuarioSucUnico = new modeloUsuariosucursal();
        public List<modeloUsuariosucursal> UnicoUsuarioSucursal(string Ccf_cod_emp, string usuario, string cod_sucursal)
        {

            List<modeloUsuariosucursal> lista = new List<modeloUsuariosucursal>();
            lista = UnicoUsuario.UnicoUsuarioxSucursal(Ccf_cod_emp, usuario, cod_sucursal);
            
            return lista;
        }
        //Buscar usuario x sucursal
        UsuarioSucursal consultaUsuario = new UsuarioSucursal();
        modeloUsuariosucursal ModeloUsuarioSuc = new modeloUsuariosucursal();
        public List<modeloUsuariosucursal> ConsultaUsuarioSucursal(string Ccf_cod_emp, string usuario)
        {

            List<modeloUsuariosucursal> lista = new List<modeloUsuariosucursal>();
            lista = consultaUsuario.ConsultaUsuarioxSucursal(Ccf_cod_emp, usuario);            
            return lista;
        }

        //Lista de usuarios por sucursal
        UsuarioSucursal ListaUsuario = new UsuarioSucursal();
        modeloUsuariosucursal ModeloUsuarioSucursal = new modeloUsuariosucursal();
        public List<modeloUsuariosucursal> ListaUsuarioSucursal(string Ccf_cod_emp, string cod_sucursal)
        {

            List<modeloUsuariosucursal> lista = new List<modeloUsuariosucursal>();
            lista = ListaUsuario.ListaUsuarioxSucursal(Ccf_cod_emp, cod_sucursal);            
            return lista;
        }
    }
}
