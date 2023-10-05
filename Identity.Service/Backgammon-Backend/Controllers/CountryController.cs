using Identity_DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backgammon_Backend.Controllers
{
    [Route("api/country")]
    [ApiController]
    [AllowAnonymous]
    public class CountryController : ControllerBase
    {
        private ICountryRepository _countryRepository { get; set; }
        public CountryController(ICountryRepository countryRepository) { _countryRepository = countryRepository; }


        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            return Ok(await _countryRepository.GetAllAsync());
        }
    }
}
