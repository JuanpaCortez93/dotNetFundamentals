using _001_Basics.DTOs;
using _001_Basics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _001_Basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {

        private IToDosService _toDosService;

        public ToDosController(IToDosService toDosService) => _toDosService = toDosService;

        [HttpGet("get")]
        public Task<IEnumerable<ToDosDTO>> GetToDos() => _toDosService.GetToDos();
    }
}
