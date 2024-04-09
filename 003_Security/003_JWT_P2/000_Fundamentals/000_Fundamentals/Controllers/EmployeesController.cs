using _000_Fundamentals.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _000_Fundamentals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = ("administrador"))]
        public IActionResult Get()
        {
            var listEmployee = EmployeesConstants.employees;
            return Ok(listEmployee);
        }
    }
}
