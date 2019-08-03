using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CalculatorUI.Models
{
    public class MainModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PickUpDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DropOffDate { get; set; }
        public IList<CountryModel> Countries { get; set; }
        public int SelectedCountry { get; set; }
        public string PenaltyFee { get; set; }
    }
}
