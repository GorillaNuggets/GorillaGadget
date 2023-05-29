using System;

namespace GorillaGadget.Service
{
    public class Relinks
    {
        //
        //  Assemble all the data relating server relinks
        //

        public static DateTime GetRelinkDate()
        {
            var date = DateTime.Today;
            date = date.Month % 2 != 1 ? date.AddMonths(1) : date;
            date = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            while (date.DayOfWeek != DayOfWeek.Friday)
            {
                date = date.AddDays(-1);
            }
            if ((date - DateTime.Today).TotalDays < 0)
            {
                date = new DateTime(date.Year, date.AddMonths(2).Month, DateTime.DaysInMonth(date.Year, date.Month));
                while (date.DayOfWeek != DayOfWeek.Friday)
                {
                    date = date.AddDays(-1);
                }
            }
            return date;
        }
        public static string GetRelinkWeek(DateTime EoM)
        {
            var a = EoM.ToShortDateString();
            var b = EoM.AddDays(7).ToShortDateString();
            return string.Format("Predicted matchup for {0} thru {1}", a, b);
        }
        public static string GetRelinkDateString()
        {
            var date = GetRelinkDate();
            var diff = date - DateTime.Today;
            var days = diff.Days > 1 ? diff.Days.ToString() + " Days" : diff.Days == 1 ? "Tomorrow" : "Today";
            return string.Format("Relinks: {0} - {1}", date.ToShortDateString(), days);
        }
    }
}