using System;

namespace UWT.Web.Extensions {
    public static class BaseTypes {

        public static DateTime GetMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        public static double Round(this double number, int places)
        {
            return Math.Round(number, places);
        }

    }
}