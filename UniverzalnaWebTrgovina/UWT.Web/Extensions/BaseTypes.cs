using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UWT.Web.Extensions {
    public static class BaseTypes {

        public static DateTime GetMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

    }
}