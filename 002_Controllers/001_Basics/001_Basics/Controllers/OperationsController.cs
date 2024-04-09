using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _001_Basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {

        [HttpGet]
        public decimal Add(decimal x, decimal y) => x + y;

        [HttpPost]
        public decimal Sub(Numbers numbers, [FromHeader] string Host) => numbers.X + numbers.Y;

        [HttpPut]
        public decimal Mult(Numbers numbers) => numbers.X * numbers.Y;

        [HttpDelete]
        public decimal Div(decimal x, decimal y)
        {
            try
            {
                return x / y;
            }catch (Exception ex)
            {
                return 0;
            }
        }
    }

    public class Numbers
    {
        public decimal X { get; set; }
        public decimal Y { get; set; } 
    }
}
