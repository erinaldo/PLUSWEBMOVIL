using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
    public    class CodigosPaiPrvCiu
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        string metodo = "CodigosPaiPrvCiu.cs";

        public List<modelopaises> ListaPaises(string CC__usuario, string CC__cod_emp, string pais)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelopaises> lista = new List<modelopaises>();
                    string consulta = ("wmspc_paises");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = CC__usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = CC__cod_emp;
                    conmand.Parameters.Add("@pais", SqlDbType.VarChar).Value = pais;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                       modelopaises item = new modelopaises();
                        item.cod_pais = Convert.ToString(dr["cod_pais"]);
                        item.nom_pais = Convert.ToString(dr["nom_pais"]);
                        lista.Add(item);
                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(CC__cod_emp, metodo, "ListaPaises", e.ToString(), DateTime.Now, CC__usuario);
                return null;
            }
        }

        public List<modeloprovincias> ListaProvincias(string CC__usuario, string CC__cod_emp, string cod_pais, string provincia)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modeloprovincias> lista = new List<modeloprovincias>();
                    string consulta = ("wmspc_provincias");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = CC__usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = CC__cod_emp;
                    conmand.Parameters.Add("@cod_pais", SqlDbType.VarChar).Value = cod_pais;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modeloprovincias item = new modeloprovincias();
                        item.cod_pais = Convert.ToString(dr["cod_pais"]);
                        item.cod_provincia = Convert.ToString(dr["cod_provincia"]);
                        item.nom_provincia = Convert.ToString(dr["nom_provincia"]);
                        lista.Add(item);
                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(CC__cod_emp, metodo, "ListaProvincias", e.ToString(), DateTime.Now, CC__usuario);
                return null;
            }
        }

        public List<modelociudades> ListaCiudades(string CC__usuario, string CC__cod_emp, string cod_pais, string cod_provincia, string ciudad)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    List<modelociudades> lista = new List<modelociudades>();
                    string consulta = ("wmspc_ciudades");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = CC__usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = CC__cod_emp;
                    conmand.Parameters.Add("@cod_pais", SqlDbType.VarChar).Value = cod_pais;
                    conmand.Parameters.Add("@cod_provincia", SqlDbType.VarChar).Value = cod_provincia;
                   // conmand.Parameters.Add("@ciudad", SqlDbType.VarChar).Value = ciudad;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                        modelociudades item = new modelociudades();
                        item.cod_pais = Convert.ToString(dr["cod_pais"]);
                        item.cod_provincia = Convert.ToString(dr["cod_provincia"]);
                        item.ciudad_tit = Convert.ToString(dr["ciudad_tit"]);
                        item.nom_ciudad = Convert.ToString(dr["nom_ciudad"]);
                        item.nom_provincia = Convert.ToString(dr["nom_provincia"]);
                        item.nombre = Convert.ToString(dr["nombre"]);
                        lista.Add(item);
                    }

                    return lista;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(CC__cod_emp, metodo, "ListaCiudades", e.ToString(), DateTime.Now, CC__usuario);
                return null;
            }
        }

        //ciudad especifica
        public modelociudades Ciudades(string CC__usuario, string CC__cod_emp, string cod_pais, string cod_provincia, string ciudad)
        {
            try
            {
                using (cn = conexion.genearConexion())
                {
                    modelociudades item = new modelociudades();
                    string consulta = ("wmspc_ciudades");
                    SqlCommand conmand = new SqlCommand(consulta, cn);

                    conmand.CommandType = CommandType.StoredProcedure;
                    conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = CC__usuario;
                    conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = CC__cod_emp;
                    conmand.Parameters.Add("@cod_pais", SqlDbType.VarChar).Value = cod_pais;
                    conmand.Parameters.Add("@cod_provincia", SqlDbType.VarChar).Value = cod_provincia;
                     conmand.Parameters.Add("@ciudad", SqlDbType.VarChar).Value = ciudad;

                    SqlDataReader dr = conmand.ExecuteReader();

                    while (dr.Read())
                    {

                       
                        item.cod_pais = Convert.ToString(dr["cod_pais"]);
                        item.cod_provincia = Convert.ToString(dr["cod_provincia"]);
                        item.ciudad_tit = Convert.ToString(dr["ciudad_tit"]);
                        item.nom_ciudad = Convert.ToString(dr["nom_ciudad"]);
                        item.nom_provincia = Convert.ToString(dr["nom_provincia"]);
                        item.nombre = Convert.ToString(dr["nombre"]);
                        
                    }

                    return item;
                }
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(CC__cod_emp, metodo, "ListaCiudades", e.ToString(), DateTime.Now, CC__usuario);
                return null;
            }
        }
    }
}
