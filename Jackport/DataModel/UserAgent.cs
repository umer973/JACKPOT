using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jackport.DataModel
{
    static class UserAgent
    {
        public static string AgentCode { get; set; }

        public static string AgenToken { get; set; }

        public static long ShowBalance { get; set; }

        public static string AppName { get; set; }

        public static string Logo { get; set; }

        public static string AppSignature { get; set; }

        public static string RS { get; set; }

        public static string CompanyName { get; set; }

    }


    public class PrintJobSettings
    {
        public static string PrinterName { get; set; }
        public static string PaperSize { get; set; }
        public static int Height { get; set; }
        public static int Width { get; set; }
        public static bool IsDirectPrint { get; set; }
        public static int ControlWidth { get; set; }
        public static int ControlHeight { get; set; }
        public static int ToolWidth { get; set; }
        public static int ToolHeight { get; set; }
    }
}
