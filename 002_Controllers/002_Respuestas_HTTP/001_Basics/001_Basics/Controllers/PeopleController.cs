using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _001_Basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;

        [HttpGet("{id}")]
        public ActionResult<People> GetPerson(int id) {
            var people = Repository.People.FirstOrDefault(x => x.Id == id);
            if(people == null) return NotFound();

            return Ok(people);
            
        } 

        [HttpGet("search/{search}")]
        public List<People> GetPerson(string search) => Repository.People.Where(x => x.Name.ToUpper().Contains(search.ToUpper())).ToList();

        [HttpPost]
        public IActionResult AddPerson(People people)
        {
            if(string.IsNullOrEmpty(people.Name)) return BadRequest();
            Repository.People.Add(people);
            return NoContent();
        }
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public DateTime BirthDate { get; set; } = DateTime.Now;

    }

    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People ()
            {
                Id = 1,
                Name = "Felipe",
                BirthDate = new DateTime(1990,11,16)
            },

            new People ()
            {
                Id = 2,
                Name = "Juan",
                BirthDate = new DateTime(1990,2,26)
            },

            new People ()
            {
                Id = 3,
                Name = "Ximena",
                BirthDate = new DateTime(1959,12,26)
            },

            new People ()
            {
                Id = 4,
                Name = "Pablo",
                BirthDate = new DateTime(1990,6,29)
            }
        };
    }
}
