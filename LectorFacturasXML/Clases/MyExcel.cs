using System;
using System.Data.OleDb;
using System.Linq;
using System.IO;
//using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace LectorFacturasXML.Clases
{
    public class MyExcel
    {
        public string DataSource;

        private bool GuardarRegistro(string cmdText)
        {
            var conStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DataSource + ";Extended Properties=Excel 8.0";
            var da = new OleDbDataAdapter
            {
                InsertCommand = new OleDbCommand
                {
                    Connection = new OleDbConnection
                    {
                        ConnectionString = conStr
                        //ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\victor\Google Drive\Lector XML\MiArchivoExcel.xls;Extended Properties=Excel 8.0";
                    }
                }
            };
            /*
            //da.SelectCommand = new OleDbCommand();
            //da.SelectCommand.Connection = new OleDbConnection();
            //da.SelectCommand.Connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\victor\Google Drive\Lector XML\MiArchivoExcel.xls;Extended Properties=Excel 8.0";
            //da.SelectCommand.CommandText = "Select * from resumenFacturas";
            
            ////Mes	Fecha	RFC	FOLIO	Tipo	Razon Social	Importe	Excento	Desc Imp	Desc Exto	Suma	IVA 16%	Total
            //da.SelectCommand.Connection.Open();
            //OleDbDataReader reader = da.SelectCommand.ExecuteReader();

            //while (reader.Read())
            //{
            //    Console.WriteLine(reader[0].ToString() + " - " + 
            //                      reader[1].ToString() + " - " +
            //                      reader[2].ToString() + " - " +
            //                      reader[3].ToString() + " - " +
            //                      reader[4].ToString() + " - " +
            //                      reader[5].ToString() + " - " +
            //                      reader[6].ToString() + " - " +
            //                      reader[7].ToString() + " - " +
            //                      reader[8].ToString() + " - " +
            //                      reader[9].ToString() + " - " +
            //                      reader[10].ToString() + " - " +
            //                      reader[11].ToString() + " - " +
            //                      reader[12].ToString());
            //}
            //reader.Close();
            //da.SelectCommand.Connection.Close();
            */
            //da.InsertCommand.CommandText = "Insert into resumenFacturas values ('01/06/2014','01/06/2014','3','4','5','6',7,8,9,10,11,12,13)";
            da.InsertCommand.CommandText = cmdText;
            da.InsertCommand.Connection.Open();
            da.InsertCommand.ExecuteNonQuery();
            da.InsertCommand.Connection.Close();
            return true;
        }

        public void GuardarEnExcel2(Comprobante comprobante, string archivo)
        {
            ////Mes	Fecha	RFC	FOLIO	Tipo	Razon Social	Importe	Excento	Desc Imp	Desc Exto	Suma	IVA 16%	Total
            float descuento = String.IsNullOrEmpty(comprobante.Descuento) ? 0 : float.Parse(comprobante.Descuento);
            DateTime miFecha = Convert.ToDateTime(comprobante.Fecha);
            miFecha = Convert.ToDateTime(miFecha.Year + "-" + miFecha.Month + "-" + 1);
            string mes = miFecha.ToShortDateString();
            miFecha = Convert.ToDateTime(comprobante.Fecha);
            string fecha = miFecha.ToShortDateString();
            string rfc = comprobante.Emisor.RFC;
            string folio = String.IsNullOrEmpty(comprobante.Serie)
                ? comprobante.Folio
                : comprobante.Serie + "-" + comprobante.Folio;
            string razonSocial = comprobante.Emisor.Nombre;
            float total = float.Parse(comprobante.Total);
            float subtotal = float.Parse(comprobante.SubTotal);
            float iva16 = comprobante.Impuestos.totalImpuestosTrasladados;
            float impteBase = (from concep in comprobante.Conceptos.conceptos select concep.Importe).Sum();
            float miBase = iva16 / 0.16f;
            float miSubtotal = subtotal;
            float impteExto = 0.1 >= miSubtotal - miBase ? 0 : Math.Abs(miSubtotal - miBase);
            impteBase -= impteExto;
            string fileName = miFecha.ToString("yyyy-MM-dd") + "-" + rfc + "-" + comprobante.Complemento.Timbre.Uuid;

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            xlApp = new Excel.Application();

            try
            {
                if (File.Exists(archivo))
                {
                    xlWorkBook = xlApp.Workbooks.Open(archivo, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                }
                else
                {
                    xlWorkBook = xlApp.Workbooks.Add();
                    xlWorkBook.SaveAs(archivo);
                }
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];
                if (xlWorkSheet != null)
                {
                    //xlApp.Visible = true;
                    xlWorkSheet.Range["$A$1"].Value2 = "NombreArchivo";
                    xlWorkSheet.Range["$B$1"].Value2 = "Mes";
                    xlWorkSheet.Range["$C$1"].Value2 = "Fecha";
                    xlWorkSheet.Range["$D$1"].Value2 = "RFC";
                    xlWorkSheet.Range["$E$1"].Value2 = "Folio";
                    xlWorkSheet.Range["$F$1"].Value2 = "Tipo";
                    xlWorkSheet.Range["$G$1"].Value2 = "Razon Social";
                    xlWorkSheet.Range["$H$1"].Value2 = "Importe";
                    xlWorkSheet.Range["$I$1"].Value2 = "Excento";
                    xlWorkSheet.Range["$J$1"].Value2 = "Desc Imp";
                    xlWorkSheet.Range["$K$1"].Value2 = "Desc Exto";
                    xlWorkSheet.Range["$L$1"].Value2 = "Suma";
                    xlWorkSheet.Range["$M$1"].Value2 = "IVA 16%";
                    xlWorkSheet.Range["$N$1"].Value2 = "Total";

                    xlWorkSheet.Rows[2].Insert();

                    xlWorkSheet.Range["$A$2"].Value2 = fileName;
                    xlWorkSheet.Range["$B$2"].Value2 = miFecha.Year + "-" + miFecha.Month + "-" + 1;
                    xlWorkSheet.Range["$C$2"].Value2 = miFecha.Year + "-" + miFecha.Month + "-" + miFecha.Day; 
                    xlWorkSheet.Range["$D$2"].Value2= rfc;
                    xlWorkSheet.Range["$E$2"].Value2 = " " + folio;
                    xlWorkSheet.Range["$F$2"].Value2 = " ";
                    xlWorkSheet.Range["$G$2"].Value2 = razonSocial;
                    xlWorkSheet.Range["$H$2"].Value2 = impteBase;
                    xlWorkSheet.Range["$I$2"].Value2 = impteExto;
                    xlWorkSheet.Range["$J$2"].Value2 = descuento;
                    xlWorkSheet.Range["$K$2"].Value2 = 0;
                    xlWorkSheet.Range["$L$2"].Value2 = miSubtotal;
                    xlWorkSheet.Range["$M$2"].Value2 = iva16;
                    xlWorkSheet.Range["$N$2"].Value2 = total;

                    xlWorkBook.Save();                    
                    xlWorkBook.Close();

                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    xlWorkBook = null;
                    xlApp.Quit();

                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: " + e.InnerException.Message);
            }
            finally
            {                
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                xlApp = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        public string InsertarDatos(Comprobante cmprbt) 
        {
            string NombreArchivo = "";
            string Version = cmprbt.Version;
            string Serie = cmprbt.Serie;
            string Folio = cmprbt.Folio;
            string Fecha = cmprbt.Fecha;
            string Sello = ""; //cmprbt.Sello;
            string FormaPago = cmprbt.FormaDePago;
            string NoCertificado = cmprbt.NoCertificado;
            string Certificado = ""; // cmprbt.Certificado;
            string CondicionesDePago = cmprbt.CondicionesDePago;
            string SubTotal = cmprbt.SubTotal;
            string Descuento = cmprbt.Descuento;
            string Moneda = cmprbt.Moneda;
            string TipoCambio = cmprbt.TipoCambio;
            string Total = cmprbt.Total;
            string TipoDeComprobante = cmprbt.TipoDeComprobante;
            string MetodoPago = cmprbt.MetodoDePago;
            string LugarExpedicion = cmprbt.LugarExpedicion;
            string Confirmacion = cmprbt.Confirmacion;
            string Emisor_RFC = cmprbt.Emisor.RFC;
            string Emisor_Nombre = cmprbt.Emisor.Nombre;
            string Emisor_RegimenFiscal = cmprbt.Emisor.RegimenFiscal;
            string Receptor_RFC = cmprbt.Receptor.RFC;
            string Receptor_Nombre = cmprbt.Receptor.Nombre;
            string Receptor_ResidenciaFiscal = cmprbt.Receptor.ResidenciaFiscal;
            string Receptor_NumRegIdTrib = cmprbt.Receptor.NumRegIdTrib;
            string Receptor_UsoCFDI = cmprbt.Receptor.UsoCFDI;
            string TotalImpuestosRetenidos = cmprbt.Impuestos.totalImpuestosRetenidos.ToString();
            string TotalImpuestosTrasladados = cmprbt.Impuestos.totalImpuestosTrasladados.ToString();
            DateTime miFecha = Convert.ToDateTime(cmprbt.Fecha);
            NombreArchivo = miFecha.ToString("yyyy-MM-dd") + "-" + Emisor_RFC + "-" + cmprbt.Complemento.Timbre.Uuid;
            string mes = Convert.ToDateTime(miFecha.Year + "-" + miFecha.Month + "-" + 1).ToShortDateString();

            string cmdText = "Insert into resumenFacturas values ('" +
            NombreArchivo + "','" +
            Version + "','" +
            Serie + "','" +
            Folio + "','" +
            Fecha + "','" +
            Sello + "','" +
            FormaPago + "','" +
            NoCertificado + "','" +
            Certificado + "','" +
            CondicionesDePago + "','" +
            SubTotal + "','" +
            Descuento + "','" +
            Moneda + "','" +
            TipoCambio + "','" +
            Total + "','" +
            TipoDeComprobante + "','" +
            MetodoPago + "','" +
            LugarExpedicion + "','" +
            Confirmacion + "','" +
            Emisor_RFC + "','" +
            Emisor_Nombre + "','" +
            Emisor_RegimenFiscal + "','" +
            Receptor_RFC + "','" +
            Receptor_Nombre + "','" +
            Receptor_ResidenciaFiscal + "','" +
            Receptor_NumRegIdTrib + "','" +
            Receptor_UsoCFDI + "','" +
            TotalImpuestosRetenidos + "','" +
            TotalImpuestosTrasladados + "'" +
            ")";
            GuardarRegistro(cmdText);

            return NombreArchivo;
        }

        public string GuardarEnExcel(Comprobante comprobante)
        {
            ////Mes	Fecha	RFC	FOLIO	Tipo	Razon Social	Importe	Excento	Desc Imp	Desc Exto	Suma	IVA 16%	Total
            float descuento = String.IsNullOrEmpty(comprobante.Descuento) ? 0 : float.Parse(comprobante.Descuento);
            const string descExto = "0";
            const string tipo = "";

            DateTime miFecha = Convert.ToDateTime(comprobante.Fecha);
            miFecha = Convert.ToDateTime(miFecha.Year + "-" + miFecha.Month + "-" + 1);
            string mes = miFecha.ToShortDateString();
            miFecha = Convert.ToDateTime(comprobante.Fecha);
            string fecha = miFecha.ToShortDateString();
            string rfc = comprobante.Emisor.RFC;
            string folio = String.IsNullOrEmpty(comprobante.Serie)
                ? comprobante.Folio
                : comprobante.Serie + "-" + comprobante.Folio;
            string razonSocial = comprobante.Emisor.Nombre;
            float total = float.Parse(comprobante.Total);
            float subtotal = float.Parse(comprobante.SubTotal);
            float Traslados = comprobante.Impuestos.totalImpuestosTrasladados;
            float Retenidos = comprobante.Impuestos.totalImpuestosRetenidos;
            float impteBase = (from concep in comprobante.Conceptos.conceptos select concep.Importe).Sum();
            float miBase = Traslados / 0.16f;
            float miSubtotal = subtotal;
            float impteExto = 0.1 >= miSubtotal - miBase ? 0 : Math.Abs(miSubtotal - miBase);
            impteBase -= impteExto;
            string fileName = miFecha.ToString("yyyy-MM-dd") + "-" + rfc + "-" + comprobante.Complemento.Timbre.Uuid;

            string cmdText = "Insert into resumenFacturas values ('" +
                             fileName + "','" +
                             mes + "','" +
                             fecha + "','" +
                             rfc + "','" +
                             folio + "','" +
                             tipo + "','" +
                             razonSocial + "'," +
                             impteBase + "," +
                             impteExto + "," +
                             descuento + "," +
                             descExto + "," +
                             subtotal + "," +
                             Traslados + "," +
                             total + ")";
            GuardarRegistro(cmdText);
            return fileName;
        }

    }
}
//}