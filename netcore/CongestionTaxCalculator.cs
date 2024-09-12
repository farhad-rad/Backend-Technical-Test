using System;
using System.Collections.Generic;
using System.Linq;
using Congestion.Calculator.Contracts;
using Congestion.Calculator.Helpers;

namespace Congestion.Calculator
{
    public class CongestionTaxCalculator
    {
        /**
        * Calculate the total toll fee for one day
        *
        * @param vehicle - the vehicle
        * @param dates   - date and time of all passes on one day
        * @return - the total congestion tax for that day
        */
        public int GetTax(IVehicle vehicle, List<DateTime> dates)
        {
            if (dates.Count == 0)
            {
                throw new ArgumentException("Dates should contains at least one element", nameof(dates));
            }
            int totalTax = 0;
            DateTime intervalStart = dates.First();

            foreach (var date in dates)
            {

                if (TollFreeDateChecker.IsTollFreeDate(date) || TollFreeVehicleChecker.IsTollFreeVehicle(vehicle))
                    continue;
                var nextFee = TollFeeCalculator.GetTollFee(date);
                var tempFee = TollFeeCalculator.GetTollFee(intervalStart);

                var diffInMinutes = (date - intervalStart).TotalMinutes;

                if (diffInMinutes <= 60)
                {
                    if (totalTax > 0)
                        totalTax -= tempFee;
                    totalTax += Math.Max(tempFee, nextFee);
                }
                else
                {
                    totalTax += nextFee;
                    intervalStart = date;
                }

                if (totalTax > 60)
                {
                    totalTax = 60;
                    break;
                }
            }
            return totalTax;
        }
    }
}