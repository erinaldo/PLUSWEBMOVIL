﻿using CapaDatos.Modelos;
using CapaDatos.Sql;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaProceso.Consultas
{
    public class ConsultaBancos
    {
        CuentasBanco consultaBanco = new CuentasBanco();
        public List<modelobancos> BuscartaBancos(string usuario, string cod_emp, string banco, string tipo, string cuenta, string imprime)
        {
            List<modelobancos> lista = new List<modelobancos>();
            lista = consultaBanco.ConsultaBancos(usuario,cod_emp, banco,  tipo,  cuenta,  imprime);           
            return lista;
        }
    }
}
