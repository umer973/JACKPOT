using System;
using System.Collections.Generic;
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


    }


    public class PrintJobSettings
    {
        public static string PrinterName { get; set; }
        public static string PaperSize { get; set; }
        public static int Height { get; set; }
        public static int Width { get; set; }
        public static bool IsDirectPrint { get; set; }
    }
}
