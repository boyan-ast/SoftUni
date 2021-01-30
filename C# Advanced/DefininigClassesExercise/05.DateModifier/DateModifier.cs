using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DefiningClasses
{
    public static class DateModifier
    {
        public static int DifferenceCalculator(string firstDateAsString, string secondDataAsString)
        {            

            DateTime firstDate = DateTime.ParseExact(
                firstDateAsString, "yyyy MM dd", CultureInfo.CurrentCulture);
            DateTime secondDate = DateTime.ParseExact(
                secondDataAsString, "yyyy MM dd", CultureInfo.CurrentCulture);

            var differenceInDays = (firstDate - secondDate).TotalDays;

            return Math.Abs((int)differenceInDays);
        }
    }
}
