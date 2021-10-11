using System;
using Project.Domain.Constants;

namespace Project.Domain.Helpers
{
    public static class TimeHelper
    {
        public static DateTime GetCurrentDateTime()
        {
            return DateTime.Today;
        }

        public static DateTime GetFirstDayOfNextMonth(DateTime currentDateTime)
        {
            return currentDateTime.Month < Time.DecemberNumber ?
                new DateTime(currentDateTime.Year, currentDateTime.Month + 1, Time.JanuaryNumber) :
                new DateTime(currentDateTime.Year + 1, Time.JanuaryNumber, Time.FirstDayNumber); ;
        }

        public static DateTime GetFirstDayOfPreviousYear(DateTime currentDateTime)
        {
            return GetFirstDayOfNextMonth(currentDateTime).AddMonths(Time.LastNMonths);
        }

        public static string SetToDateOfFirstDayOfMonth(int year, int month)
        {
            return $"{year}-{month}-0{Time.JanuaryNumber}";
        }
    }
}
