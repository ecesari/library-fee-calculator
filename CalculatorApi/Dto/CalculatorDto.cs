using System;
using System.Collections.Generic;

namespace CalculatorApi.Dto
{
    public class CountryDto

    {
        public IList<DateTime> Holidays { get; set; }
        public DayOfWeek FirstDayOfWeekend { get; set; }
        public string Currency { get; set; }

        public CountryDto()
        {
            Holidays = new List<DateTime>();
        }
    }
}
