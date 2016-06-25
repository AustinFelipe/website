using System;

namespace AustinSite.Utils
{
    public static class DateFormatter
    {
        public static string GetFormattedDate(DateTime dateToFormat)
        {
            var days = new string[]
            {
                "Sunday",
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday"
            };

            var months = new string[]
            {
                "",
                "Jan",
                "Fev",
                "Mar",
                "Apr",
                "May",
                "Jun",
                "Jul",
                "Ago",
                "Set",
                "Out",
                "Nov",
                "Dez"
            };

            return $"{days[(int)dateToFormat.DayOfWeek]} {months[(int)dateToFormat.Month]} {dateToFormat.Day} {dateToFormat.Year}";
        }
    }
}