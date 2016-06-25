using System;

namespace AustinSite.Utils
{
    public static class DateFormatter
    {
        private static string[] months = new string[]
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

            return $"{days[(int)dateToFormat.DayOfWeek]} {months[(int)dateToFormat.Month]} {dateToFormat.Day} {dateToFormat.Year}";
        }

        public static string GetMonthYear(DateTime dateToFormat)
        {
            return $"{months[(int)dateToFormat.Month]} {dateToFormat.Year}";
        }
    }
}