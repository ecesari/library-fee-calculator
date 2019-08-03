using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CalculatorApi.Dto;
using CalculatorApi.Entities;
using Microsoft.AspNetCore.Mvc;
using CalculatorUI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using DayOfWeek = System.DayOfWeek;

namespace CalculatorUI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            IEnumerable<Country> countries = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5794/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/Countries");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<IEnumerable<Country>>();
                    if (result != null)
                    {
                        countries = result;
                    }
                }
            }
            var countryList = countries?.Select(country => new CountryModel(country)).ToList();
            var model = new MainModel { Countries = countryList, PickUpDate = DateTime.Now, DropOffDate = DateTime.Now };
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public async Task<ActionResult> Calculate(MainModel model)
        {
            var dto = new CountryDto();
            IEnumerable<Country> countries = null;

            #region Http Request
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5794/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/Countries/GetCurrency/" + model.SelectedCountry);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<CountryDto>();
                    if (result != null)
                    {
                        dto = result;
                    }
                }

                var response2 = await client.GetAsync("api/Countries");
                if (response2.IsSuccessStatusCode)
                {
                    var result = await response2.Content.ReadAsAsync<IEnumerable<Country>>();
                    if (result != null)
                    {
                        countries = result;
                    }
                }
            }
            #endregion


            var secondDayOfWeekend = dto.FirstDayOfWeekend == DayOfWeek.Saturday ? DayOfWeek.Sunday : dto.FirstDayOfWeekend + 1;
            var days = 0;
            while (model.PickUpDate <= model.DropOffDate)
            {
                if (model.PickUpDate.DayOfWeek != dto.FirstDayOfWeekend && model.PickUpDate.DayOfWeek != secondDayOfWeekend && !dto.Holidays.Contains(model.PickUpDate))
                {
                    ++days;
                }
                model.PickUpDate = model.PickUpDate.AddDays(1);
            }


            model.PenaltyFee = days > 10 ? $"{(days - 10) * 5} {dto.Currency}" : "You have no late fees.";
            model.Countries = countries?.Select(country => new CountryModel(country)).ToList();


            return View("Index", model);
        }

    }
}
