using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _001_Basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicOperationsController : ControllerBase
    {
        [HttpGet]
        public decimal Add(decimal x, decimal y, [FromHeader] string Host, [FromHeader(Name = "Content-Length")] string ContentLength)
        {
            Console.WriteLine(Host);
            Console.WriteLine(ContentLength);
            return x + y;
        }

        [HttpPost]
        public decimal Sub(NumbersToUse numbers, [FromHeader] string Host, [FromHeader(Name = "Content-Length")] string ContentLength)
        {
            Console.WriteLine(Host);
            Console.WriteLine(ContentLength);
            return numbers.X - numbers.Y;
        }

        [HttpPut]
        public decimal Mult(NumbersToUse numbers, [FromHeader] string Host, [FromHeader (Name = "Content-Length")] string ContentLength)
        {
            Console.WriteLine(Host);
            Console.WriteLine(ContentLength);
            return numbers.Y * numbers.X;
        }

        [HttpDelete]
        public decimal Div(int x, int y, [FromHeader] string Host, [FromHeader(Name = "Content-Lenght")] string ContentLength)
        {
            Console.WriteLine(Host);
            Console.WriteLine(ContentLength);

            try
            {
                return x / y;
            }catch{
                return 0;
            }
        }
    }

    public class NumbersToUse
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }  
    }
}
