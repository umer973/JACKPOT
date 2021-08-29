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
                    for (int i = ds.Tables.Count - 1; i < ds.Tables.Count; i++)
                    {
                        PrintJobSettings.PrinterName = ds.Tables[i].Rows[0][0].ToString();
                        PrintJobSettings.PaperSize = ds.Tables[i].Rows[0][1].ToString();
                        PrintJobSettings.Height = Convert.ToInt16(ds.Tables[i].Rows[0][2].ToString());
                        PrintJobSettings.Width = Convert.ToInt16(ds.Tables[i].Rows[0][3].ToString());
                        PrintJobSettings.IsDirectPrint = Convert.ToBoolean(ds.Tables[i].Rows[0][4].ToString());
                        PrintJobSettings.ControlWidth = !string.IsNullOrEmpty(ds.Tables[i].Rows[0][5].ToString()) ? Convert.ToInt16(ds.Tables[i].Rows[0][5].ToString()) : 0;
                        PrintJobSettings.ControlHeight = !string.IsNullOrEmpty(ds.Tables[i].Rows[0][6].ToString()) ? Convert.ToInt16(ds.Tables[i].Rows[0][6].ToString()) : 0;
                        PrintJobSettings.ToolHeight = !string.IsNullOrEmpty(ds.Tables[i].Rows[0][7].ToString()) ? Convert.ToInt16(ds.Tables[i].Rows[0][7].ToString()) : 0;
                        PrintJobSettings.ToolWidth = !string.IsNullOrEmpty(ds.Tables[i].Rows[0][8].ToString()) ? Convert.ToInt16(ds.Tables[i].Rows[0][8].ToString()) : 0;
                    }




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

            try
            {

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
                dt.Columns.Add("ControlWidth");
                dt.Columns.Add("ControlHeight");
                dt.Columns.Add("ToolHeight");
                dt.Columns.Add("ToolWidth");
                dt.Rows.Add(dt.NewRow());
                dt.Rows[i]["PrinterName"] = PrintJobSettings.PrinterName;
                dt.Rows[i]["PaperSize"] = PrintJobSettings.PaperSize;
                dt.Rows[i]["Height"] = PrintJobSettings.Height;
                dt.Rows[i]["Width"] = PrintJobSettings.Width;
                dt.Rows[i]["IsDirectPrint"] = PrintJobSettings.IsDirectPrint;
                dt.Rows[i]["ControlWidth"] = PrintJobSettings.ControlWidth;
                dt.Rows[i]["ControlHeight"] = PrintJobSettings.ControlHeight;
                dt.Rows[i]["ToolHeight"] = PrintJobSettings.ToolHeight;
                dt.Rows[i]["ToolWidth"] = PrintJobSettings.ToolWidth;
                ds.Tables.Add(dt);


                ds.WriteXml(filePath);
                result = true;
            }
            catch { }
            return result;

        }
    }
}
