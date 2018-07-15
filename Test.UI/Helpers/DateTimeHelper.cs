using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.UI.Helpers
{
    public static class DateTimeHelper
    {
        private static string[] dateStrings = {"05/01/2009 14:57:32.8", "2009-05-01 14:57:32.8",
                              "2009-05-01T14:57:32.8375298-04:00", "5/01/2008",
                              "5/01/2008 14:57:32.80 -07:00",
                              "1 May 2008 2:57:32.8 PM", "16-05-2009 1:00:32 PM",
                              "Fri, 15 May 2009 20:10:57 GMT" };
        public static DateTime? CustomConvert(this DateTime dateTime,string dateTimeToConvert)
        {
            DateTime dateTimeForOut = DateTime.MinValue;
            foreach (string dateString in dateStrings)
            {
                if (DateTime.TryParse(dateString, out dateTimeForOut))
                    break;
                else
                    return null;
            }
            return dateTimeForOut;
        }

    }
}
