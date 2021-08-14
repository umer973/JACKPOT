using Jackport.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace Jackport.Helper
{
    public static class CommonHelper
    {

        // public static string filePath = Environment.(Environment.SpecialFolder.MyDocuments) + "\\Settings.xml";

        public static string filePath = Application.StartupPath + "/PrinterConfig";

        public static string GetdateFormat(string time)
        {

            return ConvertFromToTime(time, "HH:mm:ss", "h:mm:ss tt");
        }

        public static string ConvertFromToTime(this string timeHour, string inputFormat, string outputFormat)
        {
            var timeFromInput = DateTime.ParseExact(timeHour, inputFormat, null, DateTimeStyles.None);
            string timeOutput = timeFromInput.ToString(
                outputFormat,
                CultureInfo.InvariantCulture);
            return timeOutput;
        }

        public static string SetTimeFormat(string time)
        {

            return ConvertFromToTime(time, "HH:mm:ss", "h:mm tt");
        }


        public static string SetDateFormat(string date)
        {

            return DateTime.ParseExact(date.ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

        }


        public static string ReadXMlData()
        {
            string resullt = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                if (CreateXmlFile())
                {
                    ds.Clear();
                    ds.ReadXml(filePath);
                    int table = Convert.ToInt32(ds.Tables.Count);

                    PrintJobSettings.PrinterName = ds.Tables[1].Rows[0][0].ToString();
                    PrintJobSettings.PaperSize = ds.Tables[1].Rows[0][1].ToString();
                    PrintJobSettings.Height = Convert.ToInt16(ds.Tables[1].Rows[0][2].ToString());
                    PrintJobSettings.Width = Convert.ToInt16(ds.Tables[1].Rows[0][3].ToString());
                    PrintJobSettings.IsDirectPrint = Convert.ToBoolean(ds.Tables[1].Rows[0][4].ToString());




                }

            }
            catch { return resullt; }

            return resullt;
        }
        public static bool CreateXmlFile()
        {
            bool result = false;
            try
            {
                if (File.Exists(filePath))// Checking the file if exist
                {

                    result = true;
                }
                else
                {
                    XmlDocument doc = new XmlDocument();
                    XmlElement element1 = doc.CreateElement("", "XML", "");
                    doc.AppendChild(element1);

                    //--------------creating the node elements

                    XmlElement element2 = doc.CreateElement("", "PrinterName", "");
                    element1.AppendChild(element2);

                    doc.Save(filePath);


                    //writeXml(filePath);

                    result = true;
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
                result = false; ;
            }

            return result;
        }

        public static bool InsertDataIntoXML()
        {
            bool result = false;

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Clear();
            CreateXmlFile();
            ds.ReadXml(filePath);
            int i = 0;
            i = Convert.ToInt32(ds.Tables[0].Rows.Count) - 1;
            dt.Columns.Add("PrinterName");
            dt.Columns.Add("PaperSize");
            dt.Columns.Add("Height");
            dt.Columns.Add("Width");
            dt.Columns.Add("IsDirectPrint");
            dt.Rows.Add(dt.NewRow());
            dt.Rows[i]["PrinterName"] = PrintJobSettings.PrinterName;
            dt.Rows[i]["PaperSize"] = PrintJobSettings.PaperSize;
            dt.Rows[i]["Height"] = PrintJobSettings.Height;
            dt.Rows[i]["Width"] = PrintJobSettings.Width;
            dt.Rows[i]["IsDirectPrint"] = PrintJobSettings.IsDirectPrint;
            ds.Tables.Add(dt);


            ds.WriteXml(filePath);
            result = true;
            return result;
        }
    }
}
