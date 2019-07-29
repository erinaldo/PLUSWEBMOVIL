using CapaDatos.Modelos;
using CapaProceso.Modelos;
using System;
using System.Collections.Generic;


namespace CapaProceso.Consultas
{
   
    public class Enviarcorreocliente
    {
        public modelowmtfacturascab conscabcera = new modelowmtfacturascab();
        public List<modelowmtfacturascab> listaConsCab = null;
        public Consultawmtfacturascab ConsultaCabe = new Consultawmtfacturascab();
        EnviarCorreo correo = new EnviarCorreo();
        Consultawmsptitulares ConsultaTitulares = new Consultawmsptitulares();
        public List<modelowmspctitulares> lista = null;
        modelowmspctitulares cliente = new modelowmspctitulares();

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

        public modelowmtfacturascab buscarCabezeraFactura(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans)
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

        public modelowmspctitulares buscarCliente(string Ven__usuario, string Ven__cod_emp, string Ven__cod_tipotit, string Ven__cod_tit, string Ven__cod_dgi, string Ven__fono)
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


        public Boolean EnviarCorreoCliente(string Ccf_cod_emp, string Ccf_usuario, string Ccf_tipo1, string Ccf_tipo2, string Ccf_nro_trans, string pathPdf, string pathXml)
        {
            
            //Consultamos los datos del cliente
            modelowmspctitulares cliente = new modelowmspctitulares();
            conscabcera = null;
            conscabcera = buscarCabezeraFactura(Ccf_cod_emp, Ccf_usuario, Ccf_tipo1, Ccf_tipo2, Ccf_nro_trans);

            //Buscar datos especificos del cliente

            string Ven__cod_tit = conscabcera.cod_cliente;
            cliente = null;
            cliente = buscarCliente(Ccf_usuario, Ccf_cod_emp, Ven__cod_tipotit, Ven__cod_tit, Ven__cod_dgi, Ven__fono);

            if(cliente != null)
            {
                EnviarCorreo correo = new EnviarCorreo();
                string nombre = "";
                string email = "";

                nombre = cliente.nom_tit;
                email = cliente.email_tit;
                if (email == "")
                {

                  
                    email = "Margarita.quijozaca@gmail.com";//cliente.email_tit;


                    string mensaje = "<strong> Estimado(a): </strong>" + nombre.ToUpper() + "<br/>" + "se a generado el Documento Electrónico N°: " + conscabcera.observacion;

                    List<string> listaPath = new List<string>();// lista de archivos adjuntos
                    listaPath.Add(pathPdf);
                    listaPath.Add(pathXml);
                   correo.enviarcorreo("Documento Electrónico", mensaje, email, listaPath,Ccf_cod_emp);


                    return true;


                }
                else
                {
                    string mensaje = "<strong> Estimado(a): </strong>" + nombre.ToUpper() + "<br/>" + "Se a generado el Documento Electrónico N°: " + conscabcera.observacion;

                    List<string> listaPath = new List<string>();// lista de archivos adjuntos
                    listaPath.Add(pathPdf);
                    listaPath.Add(pathXml);
                    correo.enviarcorreo("Envio de  Documento Electrónico", mensaje, email, listaPath, Ccf_cod_emp);
                    return true;


                }


                
            }
            else
            {

                EnviarCorreo correo = new EnviarCorreo();
                string nombre = "";
                string email = "";

                nombre = cliente.nom_tit;
                email = cliente.email_tit;


                string mensaje = "<strong> Estimado(a): </strong>" + nombre.ToUpper() + "<br/>" + "Se a generado el Documento Electrónico N°: " + conscabcera.observacion;

                List<string> listaPath = new List<string>();// lista de archivos adjuntos
                listaPath.Add(pathPdf);
                listaPath.Add(pathXml);
                correo.enviarcorreo("Envio de  Documento Electrónico", mensaje, email, listaPath, Ccf_cod_emp);


                return true;
            }

          
        }

    }
}
