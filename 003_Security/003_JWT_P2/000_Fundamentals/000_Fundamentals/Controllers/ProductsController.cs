using _000_Fundamentals.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _000_Fundamentals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var listProduct = ProductsConstants.Products;

            return Ok(listProduct);
        }

    }
}
