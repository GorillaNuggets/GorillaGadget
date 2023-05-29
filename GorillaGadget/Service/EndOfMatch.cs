using System;

namespace GorillaGadget.Service
{
    public class EndOfMatch
    {
        // 
        //  Create the "Match ends" string that appears at the bottom of the form
        //

        public static string GetEndOfMatch(DateTime EoM)
        {
            var diff = EoM - DateTime.Now;
            var result = "Match ends in ";
            result += diff.Days > 1 ? string.Format("{0} days ", diff.Days) :
              diff.Days == 1 ? string.Format("{0} day ", diff.Days) : "";

            result += diff.Hours > 1 ? string.Format("{0} hours ", diff.Hours) :
              diff.Hours == 1 ? string.Format("{0} hour ", diff.Hours) : "";

            result += diff.Minutes > 1 ? string.Format("{0} minutes ", diff.Minutes) :
              diff.Minutes == 1 ? string.Format("{0} minute", diff.Minutes) : "";
            result = EoM < DateTime.Now ? "Time has expired" : result;
            return result;
        }
    }
}