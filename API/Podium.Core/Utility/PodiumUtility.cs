using System;
using System.Collections.Generic;
using System.Text;

namespace Podium.Core.Utility
{
    public static class PodiumUtility
    {
        public static decimal CalculateLTV(decimal propertyValue, decimal depositAmount)
        {
            // MA Mortgage Amount
            var MA = propertyValue - depositAmount;

            //APV Appraised Property Value
            var APV = propertyValue;
            return  (MA/ APV)*100;

        }
        public static bool IsUnder18(DateTime dob)
        {
            var today = DateTime.Today;
            var age = today.Year - dob.Year;
            if (dob > today.AddYears(-age))
                age--;
            if (age < 18)
                return true;
            return false;
        }
    }
}
