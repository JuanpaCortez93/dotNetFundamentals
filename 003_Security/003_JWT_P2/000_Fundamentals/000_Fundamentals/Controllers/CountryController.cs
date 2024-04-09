using _000_Fundamentals.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _000_Fundamentals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var listCountries = CountriesContants.countries;
            return Ok(listCountries);
        }
    }
}
