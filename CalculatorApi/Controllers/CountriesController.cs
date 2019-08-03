using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorApi.Dto;
using CalculatorApi.Entities;
using CalculatorApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        // GET api/countries
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            var countries = _countryRepository.GetAll();
            return countries;
        }

        // GET api/countries/5
        [HttpGet("GetCurrency/{id}")]
        public ActionResult<CountryDto> GetCurrency(int id)
        {
            var currency = _countryRepository.GetCurrency(id);
            var firstDayOfWeekend = _countryRepository.GetFirstDayOfWeekend(id);
            var holidays = _countryRepository.GetHolidays(id);


           var dto = new CountryDto
           {
               FirstDayOfWeekend = firstDayOfWeekend,
               Holidays = holidays,
               Currency = currency
           };
            return dto;
        }


        // GET api/countries/5
        [HttpGet("GetWeekends/{id}")]
        public ActionResult<DayOfWeek> GetWeekends(int id)
        {
            var weekends = _countryRepository.GetFirstDayOfWeekend(id);
            return weekends;
        }


        // GET api/countries/5
        [HttpGet("GetHolidays/{id}")]
        public ActionResult<IList<DateTime>> GetHolidays(int id)
        {
            var holidays = _countryRepository.GetHolidays(id);
            return holidays;
        }

        // PUT api/countries/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/countries/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
