using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Sql
{
   public  class FormatoCantidades
    {

        //Dar formato a las cantidades y decir cuantos decimales se quieren para visualizar
        public string FormatoNumero(string nro_decimales, decimal numero)
        {
            try
            {
                //Recibir numero y cantidad de decimales para formatear y aproximar
                string Numero_Afectado = "";

                switch (nro_decimales) //ultilizo la variable para la opcion
                {
                    case "0":
                        Numero_Afectado = String.Format("{0:N0}", numero).ToString();

                        break;
                    case "1":
                        Numero_Afectado = String.Format("{0:N01}", numero).ToString(); ;

                        break;
                    case "2":
                        Numero_Afectado = String.Format("{0:N02}", numero).ToString(); ;

                        break;
                    case "3":
                        Numero_Afectado = String.Format("{0:N03}", numero).ToString();

                        break;
                    case "4":
                        Numero_Afectado = String.Format("{0:N04}", numero).ToString();

                        break;
                    case "5":
                        Numero_Afectado = String.Format("{0:N05}", numero).ToString();

                        break;
                    case "6":
                        Numero_Afectado = String.Format("{0:N06}", numero).ToString();

                        break;
                    case "7":
                        Numero_Afectado = String.Format("{0:N07}", numero).ToString();

                        break;
                    case "8":
                        Numero_Afectado = String.Format("{0:N08}", numero).ToString();

                        break;
                    case "9":
                        Numero_Afectado = String.Format("{0:N09}", numero).ToString();

                        break;
                    case "10":
                        Numero_Afectado = String.Format("{0:N10}", numero).ToString();

                        break;
                }
                return Numero_Afectado;
            }
            catch (Exception)
            {

                return "";
            }
            
        }
        public decimal RedondearNumero(string nro_decimales, decimal numero)
        {
            try
            {
                //Recibir numero y cantidad de decimales para formatear y aproximar
                decimal Numero_Afectado = 0;
                switch (nro_decimales) //ultilizo la variable para la opcion
                {
                    case "0":
                        Numero_Afectado = Math.Round(numero, 0);

                        break;
                    case "1":
                        Numero_Afectado = Math.Round(numero, 1);

                        break;
                    case "2":
                        Numero_Afectado = Math.Round(numero, 2);

                        break;
                    case "3":
                        Numero_Afectado = Math.Round(numero, 3);

                        break;
                    case "4":
                        Numero_Afectado = Math.Round(numero, 4);

                        break;
                    case "5":
                        Numero_Afectado = Math.Round(numero, 5);

                        break;
                    case "6":
                        Numero_Afectado = Math.Round(numero, 6);

                        break;
                    case "7":
                        Numero_Afectado = Math.Round(numero, 7);

                        break;
                    case "8":
                        Numero_Afectado = Math.Round(numero, 8);

                        break;
                    case "9":
                        Numero_Afectado = Math.Round(numero, 9);

                        break;
                    case "10":
                        Numero_Afectado = Math.Round(numero, 10);

                        break;
                }
                return Numero_Afectado;
            }
            catch (Exception)
            {

                return 0;
            }
            
        }

    }
}
