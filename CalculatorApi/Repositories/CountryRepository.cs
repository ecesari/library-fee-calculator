using System;
using System.Collections.Generic;
using System.Linq;
using CalculatorApi.Dto;
using CalculatorApi.EF;
using CalculatorApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Repositories
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAll();
        string GetCurrency(int countryId);
        DayOfWeek GetFirstDayOfWeekend(int countryId);
        List<DateTime> GetHolidays(int countryId);
    }
    public class CountryRepository:ICountryRepository
    {
        private readonly CalculatorContext _dbContext;

        public CountryRepository(CalculatorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Country> GetAll()
        {
            return _dbContext.Countries.OrderBy(x => x).ToList();
        }

        public string GetCurrency(int countryId)
        {
            return _dbContext.Countries.FirstOrDefault(x => x.Id == countryId).CurrencySymbol;
        }

        public DayOfWeek GetFirstDayOfWeekend(int countryId)
        {
            return _dbContext.Countries.FirstOrDefault(x => x.Id == countryId).FirstDayOfWeekend;

        }

        public List<DateTime> GetHolidays(int countryId)
        {
            return _dbContext.Holidays.Where(x => x.CountryId == countryId).Select(x=>x.Date).ToList();
        }

   
    }
}
