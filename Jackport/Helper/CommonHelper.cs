using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jackport.Helper
{
    public static class CommonHelper
    {
        public static string GetdateFormat(string time)
        {
            
            return ConvertFromToTime(time, "HH:mm:ss", "h:mm tt");
        }

        public static string ConvertFromToTime(this string timeHour, string inputFormat, string outputFormat)
        {
            var timeFromInput = DateTime.ParseExact(timeHour, inputFormat, null, DateTimeStyles.None);
            string timeOutput = timeFromInput.ToString(
                outputFormat,
                CultureInfo.InvariantCulture);
            return timeOutput;
        }
    }
}
