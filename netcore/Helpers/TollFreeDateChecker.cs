using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congestion.Calculator.Helpers
{
    public static class TollFreeDateChecker
    {
        public static bool IsTollFreeDate(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return true;

            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            if (year == 2013)
            {
                // List of public holidays or toll-free days in Gothenburg
                if ((month == 1 && day == 1) ||  // New Year's Day
                    (month == 3 && (day == 28 || day == 29)) ||  // Maundy Thursday and Good Friday
                    (month == 4 && (day == 1 || day == 30)) ||  // Easter Monday and Walpurgis Night
                    (month == 5 && (day == 1 || day == 8 || day == 9)) ||  // Labour Day, Ascension Day
                    (month == 6 && (day == 5 || day == 6 || day == 21)) ||  // National Day, Midsummer
                    (month == 7) ||  // Entire month of July is toll-free
                    (month == 11 && day == 1) ||  // All Saints Day
                    (month == 12 && (day == 24 || day == 25 || day == 26 || day == 31)))  // Christmas and New Year holidays
                {
                    return true;
                }
            }
            return false;
        }
    }
}