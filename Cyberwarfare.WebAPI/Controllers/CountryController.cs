using ClassWarfare.Models;
using CyberWarfare.Models;
using CyberWarfare.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace Cyberwarfare.WebAPI.Controllers
{
    [Authorize]
    public class CountryController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            CountryService countryService = CreateCountryService();
            var countries = countryService.GetCountries();
            return Ok(countries);
        }

        public IHttpActionResult Get(int id)
        {
            CountryService countryService = CreateCountryService();
            var country = countryService.GetCountryById(id);
            return Ok(country);
        }

        public IHttpActionResult Post(CountryCreate country)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCountryService();

            if (!service.CreateCountry(country))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(CountryEdit country)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCountryService();

            if (!service.UpdateCountry(country))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCountryService();

            if (!service.DeleteCountry(id))
            return InternalServerError();

            return Ok();
        }

        private CountryService CreateCountryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var countryService = new CountryService(userId);
            return countryService;
        }
    }
}
