using excelASPX.Controllers;
using excelASPX.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using ClosedXML.Excel;
using System.IO;

namespace excelASPX
{
    [System.Web.Script.Services.ScriptService]
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Operacion_model> GetOperationsList(string fechaIni, string fechaFin)
        {
            try
            {

                DateTime fechaIniParsed = fechaIni.AsDateTime();
                DateTime fechaFinParsed = fechaFin.AsDateTime();
                return Operacion_controller.ListaOperaciones(fechaIniParsed, fechaFinParsed);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string GetExcel(List<string> referencias)
        {
            try
            {
                string base64 = string.Empty;

                List<Operacion_model> operaciones = Operacion_controller.GetOperacionByReferencias(referencias);

                using (XLWorkbook workbook = new XLWorkbook()) 
                {
                    IXLWorksheet worksheet = workbook.Worksheets.Add("Operaciones");

                    worksheet.Cell("A3").Value = "#";
                    worksheet.Cell("B3").Value = "Cliente";
                    worksheet.Cell("C3").Value = "Clave Pedimento";
                    worksheet.Cell("D3").Value = "Tipo Operacion";
                    worksheet.Cell("E3").Value = "Referencia";
                    worksheet.Cell("F3").Value = "Pedimento";
                    worksheet.Cell("H3").Value = "Remesa";
                    worksheet.Cell("I3").Value = "Caja";
                    worksheet.Cell("J3").Value = "Sello";
                    worksheet.Cell("K3").Value = "DODA";
                    worksheet.Cell("L3").Value = "CP Folios";
                    worksheet.Cell("M3").Value = "Cruce / SOIA";
                    worksheet.Cell("N3").Value = "Usuario";
                    worksheet.Cell("O3").Value = "Tiempo Recibo BGTS";
                    worksheet.Cell("P3").Value = "Tiempo ACG Confirmado";
                    worksheet.Cell("Q3").Value = "Fecha CCP";
                    worksheet.Cell("R3").Value = "Fecha Remesa";

                    int row = 4;
                    for(int i = 0; i < operaciones.Count - 1; i++)
                    {
                        worksheet.Cell($"A{row}").Value = i + 1;
                        worksheet.Cell($"B{row}").Value = operaciones[i]?.Cliente;
                        worksheet.Cell($"C{row}").Value = operaciones[i]?.ClavePedimento;
                        worksheet.Cell($"D{row}").Value = operaciones[i]?.TipoOperacion;
                        worksheet.Cell($"E{row}").Value = operaciones[i]?.Referencia;
                        worksheet.Cell($"F{row}").Value = operaciones[i]?.Pedimento;
                        worksheet.Cell($"H{row}").Value = operaciones[i]?.Remesa;
                        worksheet.Cell($"I{row}").Value = operaciones[i]?.Caja;
                        worksheet.Cell($"J{row}").Value = operaciones[i]?.Sello;
                        worksheet.Cell($"K{row}").Value = operaciones[i]?.DODA;
                        worksheet.Cell($"L{row}").Value = operaciones[i]?.CPfolios;
                        worksheet.Cell($"M{row}").Value = operaciones[i]?.CruceSOIA;
                        worksheet.Cell($"N{row}").Value = operaciones[i]?.Usuario;
                        worksheet.Cell($"O{row}").Value = operaciones[i]?.TiempoReciboBGTS;
                        worksheet.Cell($"P{row}").Value = operaciones[i]?.TiempoACGConfirmado;
                        worksheet.Cell($"Q{row}").Value = operaciones[i]?.FechaCartaPorte;
                        worksheet.Cell($"R{row}").Value = operaciones[i]?.FechaRemesa;
                        row++;
                    }

                    using(MemoryStream stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);

                        byte[] bytes = stream.ToArray();
                        base64 = Convert.ToBase64String(bytes);
                        stream.Dispose();
                    }
                }

                return base64;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}