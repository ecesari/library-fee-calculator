using System;
using System.ComponentModel.DataAnnotations;

namespace CalculatorApi.Entities
{
    public class Holiday
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
