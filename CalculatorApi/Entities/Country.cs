using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculatorApi.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CurrencySymbol { get; set; }
        public DayOfWeek FirstDayOfWeekend { get; set; }
        public IList<Holiday> Holidays { get; set; }

     
    }

}
