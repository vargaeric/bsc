using System;

namespace SortEmployees
{
    class FormatDateTime
    {
        public static DateTime getDateTimeFormat(string date)
        {
            DateTime formatedDateTime;
            var usCulture = new System.Globalization.CultureInfo("en-US");

            if (DateTime.TryParse(date, usCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out formatedDateTime))
            {
                formatedDateTime = DateTime.ParseExact(date, "yyyy-MM-dd", usCulture.DateTimeFormat);

                return formatedDateTime;
            }
            else
                throw new Exception("Invalid date format, cannot convert to valid DateTime object!");
        }

        public static string getDateTimeInString(DateTime date)
            => date.ToString("yyyy-MM-dd");

        public static string yearsAndMonthsInString(DateTime hireDate)
        {
            string output = "";

            double totalDays = (DateTime.Now - hireDate).TotalDays;

            int years = Convert.ToInt32(Math.Truncate(totalDays / 365));

            if (years != 0)
            {
                output += $"{years} year";

                if (years > 1)
                    output += 's';
            }

            int months = Convert.ToInt32(Math.Truncate((totalDays % 365) / 30));

            if (months != 0)
            {
                if (years != 0)
                    output += " and ";

                output += $"{months} month";

                if (months > 1)
                    output += 's';
            }

            return output;
        }
    }
}
