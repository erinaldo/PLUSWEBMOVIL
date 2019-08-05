using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CapaProceso.Modelos;
using CapaDatos.Modelos;

namespace CapaDatos.Sql
{
   public  class MediosPago
    {
        Conexion conexion = new Conexion();
        public SqlConnection cn = null;
        modelowmspcarticulos modeloarticulos = new modelowmspcarticulos();
        //Lista d medios de pago por empresa
        public List<modeloMediosPago> ListaMediosPago(string cod_emp)
        {

            using (cn = conexion.genearConexion())
            {
                List<modeloMediosPago> lista = new List<modeloMediosPago>();

                string consulta = ("SELECT * FROM wmm_fpagoPOS WHERE cod_emp = @cod_emp ORDER BY nom_fpago ASC");
                SqlCommand conmand = new SqlCommand(consulta, cn);

                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
             
                
                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {

                    modeloMediosPago item = new modeloMediosPago();
                    item.cod_emp = Convert.ToString(dr["cod_emp"]);
                    item.cod_fpago = Convert.ToString(dr["cod_fpago"]);
                    item.nom_fpago = Convert.ToString(dr["nom_fpago"]);
                    item.cod_docum = Convert.ToString(dr["cod_docum"]);
                    item.cod_cta = Convert.ToString(dr["cod_cta"]);
                    item.plazo = Convert.ToString(dr["plazo"]);
                    item.cuotas = Convert.ToString(dr["cuotas"]);
                    item.dias_cuotas = Convert.ToString(dr["dias_cuotas"]);
                    item.maneja_ter = Convert.ToString(dr["maneja_ter"]);
                    item.maneja_doc = Convert.ToString(dr["maneja_doc"]);
                    item.usuario_mod = Convert.ToString(dr["usuario_mod"]);
                    item.fecha_mod = Convert.ToDateTime(dr["fecha_mod"]);
                    item.nro_audit = Convert.ToString(dr["nro_audit"]);
                    item.cod_pro_aud = Convert.ToString(dr["cod_proc_aud"]);
                    item.abierto = Convert.ToString(dr["abierto"]);
                    
                    item.numero_propio = Convert.ToString(dr["numero_propio"]);
                    item.observacion = item.cod_fpago+ '-'+ item.nom_fpago;
                    lista.Add(item);

                }

                return lista;
            }
        }

        //Recupera datos de medio de pago para insertar en tabla wmt_facturas_pgs
        public List<ModeloTipoPagoTem> BuscarPagosTemporal(string usuario,string cod_emp, string nro_trans)
        {

            using (cn = conexion.genearConexion())
            {
                List<ModeloTipoPagoTem> lista = new List<ModeloTipoPagoTem>();

                string consulta = ("wmspc_fpagoPOS_tmp");
                SqlCommand conmand = new SqlCommand(consulta, cn);
                conmand.CommandType = CommandType.StoredProcedure;
                conmand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                conmand.Parameters.Add("@cod_emp", SqlDbType.VarChar).Value = cod_emp;
                conmand.Parameters.Add("@nro_trans", SqlDbType.VarChar).Value = nro_trans;


                SqlDataReader dr = conmand.ExecuteReader();

                while (dr.Read())
                {

                    ModeloTipoPagoTem item = new ModeloTipoPagoTem();
                    item.nro_trans = Convert.ToString(dr["nro_trans"]);
                    item.cod_emp = Convert.ToString(dr["cod_emp"]);
                    item.cod_fpago = Convert.ToString(dr["cod_fpago"]);
                    item.nom_fpago = Convert.ToString(dr["nom_fpago"]);
                    item.cod_docum = Convert.ToString(dr["cod_docum"]);
                    item.cod_cta = Convert.ToString(dr["cod_cta"]);
                    
                    item.modif_ter = Convert.ToString(dr["modif_ter"]);
                    item.cod_ter = Convert.ToString(dr["cod_ter"]);
                    item.ter_campo = Convert.ToString(dr["ter_campo"]);
                    item.modif_doc = Convert.ToString(dr["modif_doc"]);
                    item.nro_doc= Convert.ToString(dr["nro_doc"]);
                    item.doc_campo= Convert.ToString(dr["doc_campo"]);
                    
                    lista.Add(item);

                }

                return lista;
            }
        }
    }
}
