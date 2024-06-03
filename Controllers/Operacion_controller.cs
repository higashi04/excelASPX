using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using excelASPX.Models;
using System.Web.WebPages;
using Newtonsoft.Json.Linq;

namespace excelASPX.Controllers
{
    public class Operacion_controller
    {

        private static string path = HttpContext.Current.Server.MapPath("~/App_Data/data.json");
        public static List<Operacion_model> ListaOperaciones(DateTime fechaIni, DateTime fechaFin)
        {
            try
            {
                string jsonContent = File.ReadAllText(path);

                List<Operacion_model> operacionesSinFiltrar = new List<Operacion_model>();


                JArray jsonArray = JArray.Parse(jsonContent);

                foreach (JObject jsonOperacion in jsonArray)
                {
                    Operacion_model operacion = new Operacion_model();

                    operacion.Cliente = jsonOperacion["cliente"]?.ToString();
                    operacion.ClavePedimento = jsonOperacion["clave pedimento"]?.ToString();
                    operacion.TipoOperacion = jsonOperacion["tipo operacion"]?.ToString();
                    operacion.Referencia = jsonOperacion["referencia"]?.ToString();
                    operacion.Pedimento = jsonOperacion["pedimento"]?.ToString();
                    operacion.Remesa = jsonOperacion["remesa"]?.ToString();
                    operacion.Caja = jsonOperacion["caja"]?.ToString();
                    operacion.Sello = jsonOperacion["sello"]?.ToString();
                    operacion.DODA = jsonOperacion["DODA"]?.ToString();
                    operacion.CPfolios = jsonOperacion["CP folios"]?.ToString();
                    operacion.CruceSOIA = jsonOperacion["cruce/SOIA"]?.ToString();
                    operacion.Usuario = jsonOperacion["usuario"]?.ToString();
                    operacion.TiempoReciboBGTS = jsonOperacion["TIEMPO RECIBO BGTS"]?.ToString();
                    operacion.TiempoACGConfirmado = jsonOperacion["TIEMPO ACG CONFIRMADO"]?.ToString();
                    operacion.FechaCartaPorte = jsonOperacion["FECHA CCP"]?.ToString();
                    operacion.FechaRemesa = jsonOperacion["Fecha de remesa"]?.ToString();

                    operacionesSinFiltrar.Add(operacion);
                }

                List<Operacion_model> operaciones = operacionesSinFiltrar.Where(operacion => operacion.TiempoReciboBGTS.AsDateTime() >= fechaIni && operacion.TiempoReciboBGTS.AsDateTime() <= fechaFin).ToList();

                return operaciones;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static List<Operacion_model> GetOperacionByReferencias(List<string> referencias) 
        {
            try
            {

                string jsonContent = File.ReadAllText(path);

                List<Operacion_model> operacionesSinFiltrar = new List<Operacion_model>();


                JArray jsonArray = JArray.Parse(jsonContent);

                foreach (JObject jsonOperacion in jsonArray)
                {
                    Operacion_model operacion = new Operacion_model();

                    operacion.Cliente = jsonOperacion["cliente"]?.ToString();
                    operacion.ClavePedimento = jsonOperacion["clave pedimento"]?.ToString();
                    operacion.TipoOperacion = jsonOperacion["tipo operacion"]?.ToString();
                    operacion.Referencia = jsonOperacion["referencia"]?.ToString();
                    operacion.Pedimento = jsonOperacion["pedimento"]?.ToString();
                    operacion.Remesa = jsonOperacion["remesa"]?.ToString();
                    operacion.Caja = jsonOperacion["caja"]?.ToString();
                    operacion.Sello = jsonOperacion["sello"]?.ToString();
                    operacion.DODA = jsonOperacion["DODA"]?.ToString();
                    operacion.CPfolios = jsonOperacion["CP folios"]?.ToString();
                    operacion.CruceSOIA = jsonOperacion["cruce/SOIA"]?.ToString();
                    operacion.Usuario = jsonOperacion["usuario"]?.ToString();
                    operacion.TiempoReciboBGTS = jsonOperacion["TIEMPO RECIBO BGTS"]?.ToString();
                    operacion.TiempoACGConfirmado = jsonOperacion["TIEMPO ACG CONFIRMADO"]?.ToString();
                    operacion.FechaCartaPorte = jsonOperacion["FECHA CCP"]?.ToString();
                    operacion.FechaRemesa = jsonOperacion["Fecha de remesa"]?.ToString();

                    operacionesSinFiltrar.Add(operacion);
                }

                List<Operacion_model> operaciones = new List<Operacion_model>();

                foreach(string referencia in referencias)
                {
                    foreach(Operacion_model operacion in operacionesSinFiltrar)
                    {
                        if(operacion.Referencia == referencia)
                        {
                            operaciones.Add(operacion);
                        }
                    }
                }

                return operaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}