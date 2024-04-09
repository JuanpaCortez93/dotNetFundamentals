using _002_Ejercicio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _002_Ejercicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {

        private ITeachersService _teachersService;

        public TeachersController([FromKeyedServices("TeachersServiceSingleton")] ITeachersService teachersService)
        {
            _teachersService = teachersService;
        }

        [HttpGet("all")]
        public ActionResult<List<Teachers>> GetAll() => Ok(TeachersRepository.teachers);

        [HttpPost]
        public IActionResult AddTeacher(Teachers teachers)
        {
            if(_teachersService.TeachersValidator(teachers)) return BadRequest();
            TeachersRepository.teachers.Add(teachers);
            return NoContent();
        }

    }


    public class TeachersRepository
    {
        public static List<Teachers> teachers = new List<Teachers>()
        {
            new Teachers()
            {
                Name = "Soñita",
                Email = "soñita@correo",
                Level = "C2"
            },
            new Teachers()
            {
                Name = "Nachita",
                Email = "nachita@correo",
                Level = "C1"
            },
            new Teachers()
            {
                Name = "Sofia",
                Email = "sofia@correo",
                Level = "C2"
            }
        };
    }

    public class Teachers
    {
        public Teachers()
        {
            _id = Guid.NewGuid();
        }

        public Guid Id { get { return _id; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Level { get { return _level; } set { _level = value; } }


        private Guid _id;
        private string _name = string.Empty;
        private string _email = string.Empty;
        private string _level = string.Empty;
    }
}
