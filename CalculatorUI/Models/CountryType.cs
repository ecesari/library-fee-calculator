using CalculatorApi.Entities;

namespace CalculatorUI.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CurrencySymbol { get; set; }

        public CountryModel(Country entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            CurrencySymbol = entity.CurrencySymbol;
        }

    }
}
