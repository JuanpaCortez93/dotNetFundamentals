using _002_Ejercicio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _002_Ejercicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private IStudentsService _studentsService;

        public StudentsController([FromKeyedServices("StudentsServicesSingleton")] IStudentsService studentsService) 
        {
            _studentsService = studentsService;
        }

        [HttpGet("all")]
        public ActionResult<List<Students>> Getall([FromHeader] string host, [FromHeader(Name = "Content-Length")] string contentLength) {
            Console.WriteLine($"Host: {host}\nContent-Length: {contentLength}");
            return Ok(StudentsRepository.students);
        }

        [HttpGet("id/{id}")]
        public ActionResult<Students> GetStudent(Guid id, [FromHeader] string host, [FromHeader(Name = "Content-Length")] string contentLength)
        {
            Console.WriteLine($"Host: {host}\nContent-Length: {contentLength}");
            var student = StudentsRepository.students.Where(student => student.Id == id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpGet("name/{name}")]
        public ActionResult<List<Students>> GetStudents(string name, [FromHeader(Name = "Content-Length")] string contentLength, [FromHeader] string host)
        {
            Console.WriteLine($"Host: {host}\nContent-Length: {contentLength}");
            var students = StudentsRepository.students.Where(student => student.Name.ToUpper().Contains(name.ToUpper()));
            if (students == null) return NotFound();
            return Ok(students);
        }

        [HttpPost]
        public IActionResult AddStudent(Students student)
        {
            if (_studentsService.StudentsValidator(student)) return BadRequest();
            StudentsRepository.students.Add(student);
            return NoContent();
        }
    }


    public class StudentsRepository
    {
        public static List<Students> students = new List<Students>()
        {
            new Students()
            {
                Name = "Felipe",
                Email = "felipe@correo",
                Level = "B2"
            },
            new Students()
            {
                Name = "Byrito",
                Email = "byron@correo",
                Level = "C1"
            },
            new Students()
            {
                Name = "Julito",
                Email = "julio@correo",
                Level = "C2"
            }
        };
    }


    public class Students
    {

        public Students()
        {
            _id = Guid.NewGuid();
        }

        public Guid Id { get {return _id; }}
        public string Name { get {return _name; } set { _name = value; } }    
        public string Email { get {return _email; } set { _email = value; } }    
        public string Level { get {return _level; } set { _level = value; } }


        private Guid _id;
        private string _name = string.Empty;
        private string _email = string.Empty;
        private string _level = string.Empty;
    }
}
