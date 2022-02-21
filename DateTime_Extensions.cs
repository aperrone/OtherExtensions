using System;
using System.Globalization;

namespace System
{
    public static class DateTime_Extensions
    {
        public static string ToISO8601(this DateTime date)
        {
            return date.ToString("yyyy-MM-ddTHH:mm:ss.fff");
        }

        public static int WeekOfYear(this DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
                time = time.AddDays(3);

            // Return the week of our adjusted day
            return CultureInfo
                .InvariantCulture
                .Calendar
                .GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        /// <summary>
        /// Return month name
        /// </summary>
        /// <param name="dateTime">>Reference date</param>
        /// <returns></returns>
        public static string GetMonthName(this DateTime dateTime, CultureInfo cultureInfo = null)
        {
            return (cultureInfo ?? CultureInfo.CurrentCulture).DateTimeFormat.GetMonthName(dateTime.Month);
        }
    }
}
