using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _001_Basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {

        [Authorize]
        [HttpGet("lista")]
        public async Task<IActionResult> Lista()
        {
            var listaPaises = await Task.FromResult(new List<string> { "Francia", "Argentina", "Croacia", "Marruecos" });
            return Ok(listaPaises);
        }

    }
}
