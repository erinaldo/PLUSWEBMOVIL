using CapaDatos.Modelos;
using CapaDatos.Modelos.ModeloHost;
using CapaDatos.Sql;
using CapaDatos.Sql.HostMail;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;


namespace CapaProceso.Consultas
{
   
    public class Enviarcorreocliente
    {
        public modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        public List<modelowmtfacturascab> listaConsCab = null;
        public List<modelowmm_correo> listaFormato = null;
        public List<modelowmm_correo_receptor> listaCorreoRece = null;
        public Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();
        EnviarCorreo correo = new EnviarCorreo();
        Consultawmsptitulares ConsultaTitulares = new Consultawmsptitulares();
        public List<modelowmspctitulares> lista = null;
        modelowmspctitulares cliente = new modelowmspctitulares();
        ExepcionesPW guardarExcepcion = new ExepcionesPW();
        HostaMail consultaCorreos = new HostaMail();
        modelowmm_correo modelowmm_correos = new modelowmm_correo();
        modelowmm_correo_receptor modelo_correoreceptor = new modelowmm_correo_receptor();
     

        public string Ccf_estado = null;
        public string Ccf_cliente = null;
        public string Ccf_cod_docum = null;
        public string Ccf_serie_docum = null;
        public string Ccf_nro_docum = null;
        public string Ccf_diai = null;
        public string Ccf_mesi = null;
        public string Ccf_anioi = null;
        public string Ccf_diaf = null;
        public string Ccf_mesf = null;
        public string Ccf_aniof = null;
        public string nro_trans = null;
        public string Ven__cod_tipotit = "clientes";
        public string Ven__cod_tit = " ";
        public string Ven__cod_dgi = "0";
        public string Ven__fono = "0";
        string metodo ="Enviarcorreocliente.cs";

        public modelowmm_correo FormatoEmail(string Ccf_cod_emp, string cod_proceso, string cod_mail, string Ccf_usuario)
        {

            try
            {
                listaFormato = consultaCorreos.ListaFormatoCorreo(Ccf_cod_emp, cod_proceso, cod_mail, Ccf_usuario);

                modelowmm_correos = null;
                foreach (modelowmm_correo item in listaFormato)
                {
                       modelowmm_correos = item;
                }
                return modelowmm_correos;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "buscarCabezeraFactura", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }

        public modelowmm_correo_receptor CorreoReceptor(string Ccf_cod_emp, string cod_proceso, string cod_mail, string Ccf_usuario)
        {

            try
            {
                listaCorreoRece = consultaCorreos.ListaCorreoReceptor(Ccf_cod_emp, cod_proceso, cod_mail, Ccf_usuario);

                modelo_correoreceptor = null;
                foreach (modelowmm_correo_receptor item in listaCorreoRece)
                {
                    modelo_correoreceptor = item;
                }
                return modelo_correoreceptor;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "buscarCabezeraFactura", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }

        public modelowmtfacturascab buscarCabezeraFactura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
        {

            try
            {
                listaConsCab = ConsultaCabe.ConsultaCabFacura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans, Ccf_estado, Ccf_cliente, Ccf_cod_docum, Ccf_serie_docum, Ccf_nro_docum, Ccf_diai, Ccf_mesi, Ccf_anioi, Ccf_diaf, Ccf_mesf, Ccf_aniof);
                int count = 0;
                conscabcera = null;
                foreach (modelowmtfacturascab item in listaConsCab)
                {
                    count++;
                    conscabcera = item;

                }
                return conscabcera;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "buscarCabezeraFactura", e.ToString(), DateTime.Today, Ccf_usuario);
                return null;
            }
        }

        public modelowmspctitulares buscarCliente(string Ven__usuario, string Ven__cod_emp, string Ven__cod_tipotit, string Ven__cod_tit, string Ven__cod_dgi, string Ven__fono)
        {

            try
            {
                lista = ConsultaTitulares.ConsultaTitulares(Ven__usuario, Ven__cod_emp, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi);
                int count = 0;
                cliente = null;
                foreach (modelowmspctitulares item in lista)
                {
                    count++;
                    cliente = item;

                }
                return cliente;
            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ven__cod_emp, metodo, "buscarCliente", e.ToString(), DateTime.Today, Ven__usuario);
                return null;
            }
        }


        public Boolean EnviarCorreoCliente(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string pathPdf, string pathXml)
        {
            try
            {
                //Consultamos los datos del cliente
                modelowmspctitulares cliente = new modelowmspctitulares();
                conscabcera = null;
                conscabcera = buscarCabezeraFactura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);

                //Buscar datos especificos del cliente

                string Ven__cod_tit = conscabcera.cod_cliente;
                cliente = null;
                cliente = buscarCliente(Ccf_usuario, Ccf_cod_emp, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi, Ven__fono);
               //--------TRAER DATOS DE LA TABLA wmm_correos, wmm_correos_emisor--------//
                modelowmm_correos = FormatoEmail( Ccf_cod_emp, "AEMLMA", "RCOMFELECT", Ccf_usuario);
               // modelo_correoreceptor = CorreoReceptor(Ccf_cod_emp, "AEMLMA", "RCOMFELECT", Ccf_usuario);
                listaCorreoRece = consultaCorreos.ListaCorreoReceptor(Ccf_cod_emp, "AEMLMA", "RCOMFELECT", Ccf_usuario);

                modelo_correoreceptor = null;
                foreach (modelowmm_correo_receptor item in listaCorreoRece)
                {
                    if (item.email != null)
                    {
                        EnviarCorreo correo = new EnviarCorreo();
                        string nombre = "";
                        string email = "";

                        nombre = cliente.nom_tit;
                        email = item.email;
                        string mensaje = "<strong>  </strong>" + modelowmm_correos.texto + "<br/>" + modelowmm_correos.firma;

                            List<string> listaPath = new List<string>();// lista de archivos adjuntos
                            listaPath.Add(pathPdf);
                            listaPath.Add(pathXml);
                            correo.enviarcorreo(modelowmm_correos.titulo, mensaje, email, listaPath, Ccf_cod_emp);
                            return true;

                        }
                    else
                    {
                        return false;
                    }


                    }
                return true;

            }
            catch (Exception e)
            {

                guardarExcepcion.ClaseInsertarExcepcion(Ccf_cod_emp, metodo, "EnviarCorreoCliente", e.ToString(), DateTime.Today, Ccf_usuario);
                return false;
            }


        }

    }
}
